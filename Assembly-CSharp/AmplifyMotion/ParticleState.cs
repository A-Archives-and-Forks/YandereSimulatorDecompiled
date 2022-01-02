﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace AmplifyMotion
{
	// Token: 0x0200057D RID: 1405
	internal class ParticleState : MotionState
	{
		// Token: 0x060023A8 RID: 9128 RVA: 0x001F346C File Offset: 0x001F166C
		public ParticleState(AmplifyMotionCamera owner, AmplifyMotionObjectBase obj) : base(owner, obj)
		{
			this.m_particleSystem = this.m_obj.GetComponent<ParticleSystem>();
			this.m_renderer = this.m_particleSystem.GetComponent<ParticleSystemRenderer>();
			this.rotationOverLifetime = this.m_particleSystem.rotationOverLifetime;
			this.rotationBySpeed = this.m_particleSystem.rotationBySpeed;
		}

		// Token: 0x060023A9 RID: 9129 RVA: 0x001F34C5 File Offset: 0x001F16C5
		private void IssueError(string message)
		{
			if (!ParticleState.m_uniqueWarnings.Contains(this.m_obj))
			{
				Debug.LogWarning(message);
				ParticleState.m_uniqueWarnings.Add(this.m_obj);
			}
			this.m_error = true;
		}

		// Token: 0x060023AA RID: 9130 RVA: 0x001F34F8 File Offset: 0x001F16F8
		private Mesh CreateBillboardMesh()
		{
			int[] triangles = new int[]
			{
				0,
				1,
				2,
				2,
				3,
				0
			};
			Vector3[] vertices = new Vector3[]
			{
				new Vector3(-0.5f, -0.5f, 0f),
				new Vector3(0.5f, -0.5f, 0f),
				new Vector3(0.5f, 0.5f, 0f),
				new Vector3(-0.5f, 0.5f, 0f)
			};
			Vector2[] uv = new Vector2[]
			{
				new Vector2(0f, 0f),
				new Vector2(1f, 0f),
				new Vector2(1f, 1f),
				new Vector2(0f, 1f)
			};
			return new Mesh
			{
				vertices = vertices,
				uv = uv,
				triangles = triangles
			};
		}

		// Token: 0x060023AB RID: 9131 RVA: 0x001F3604 File Offset: 0x001F1804
		private Mesh CreateStretchedBillboardMesh()
		{
			int[] triangles = new int[]
			{
				0,
				1,
				2,
				2,
				3,
				0
			};
			Vector3[] vertices = new Vector3[]
			{
				new Vector3(0f, -0.5f, -1f),
				new Vector3(0f, -0.5f, 0f),
				new Vector3(0f, 0.5f, 0f),
				new Vector3(0f, 0.5f, -1f)
			};
			Vector2[] uv = new Vector2[]
			{
				new Vector2(1f, 1f),
				new Vector2(0f, 1f),
				new Vector2(0f, 0f),
				new Vector2(1f, 0f)
			};
			return new Mesh
			{
				vertices = vertices,
				uv = uv,
				triangles = triangles
			};
		}

		// Token: 0x060023AC RID: 9132 RVA: 0x001F3710 File Offset: 0x001F1910
		internal override void Initialize()
		{
			if (this.m_renderer == null)
			{
				this.IssueError("[AmplifyMotion] Missing/Invalid Particle Renderer in object " + this.m_obj.name + ". Skipping.");
				return;
			}
			base.Initialize();
			if (this.m_renderer.renderMode == ParticleSystemRenderMode.Mesh)
			{
				this.m_mesh = this.m_renderer.mesh;
			}
			else if (this.m_renderer.renderMode == ParticleSystemRenderMode.Stretch)
			{
				this.m_mesh = this.CreateStretchedBillboardMesh();
			}
			else
			{
				this.m_mesh = this.CreateBillboardMesh();
			}
			this.m_sharedMaterials = base.ProcessSharedMaterials(this.m_renderer.sharedMaterials);
			this.m_capacity = this.m_particleSystem.main.maxParticles;
			this.m_particleDict = new Dictionary<uint, ParticleState.Particle>(this.m_capacity);
			this.m_particles = new ParticleSystem.Particle[this.m_capacity];
			this.m_listToRemove = new List<uint>(this.m_capacity);
			this.m_particleStack = new Stack<ParticleState.Particle>(this.m_capacity);
			for (int i = 0; i < this.m_capacity; i++)
			{
				this.m_particleStack.Push(new ParticleState.Particle());
			}
			this.m_wasVisible = false;
		}

		// Token: 0x060023AD RID: 9133 RVA: 0x001F3838 File Offset: 0x001F1A38
		private void RemoveDeadParticles()
		{
			this.m_listToRemove.Clear();
			foreach (KeyValuePair<uint, ParticleState.Particle> keyValuePair in this.m_particleDict)
			{
				if (keyValuePair.Value.refCount <= 0)
				{
					this.m_particleStack.Push(keyValuePair.Value);
					if (!this.m_listToRemove.Contains(keyValuePair.Key))
					{
						this.m_listToRemove.Add(keyValuePair.Key);
					}
				}
				else
				{
					keyValuePair.Value.refCount = 0;
				}
			}
			for (int i = 0; i < this.m_listToRemove.Count; i++)
			{
				this.m_particleDict.Remove(this.m_listToRemove[i]);
			}
		}

		// Token: 0x060023AE RID: 9134 RVA: 0x001F38F4 File Offset: 0x001F1AF4
		internal override void UpdateTransform(CommandBuffer updateCB, bool starting)
		{
			int maxParticles = this.m_particleSystem.main.maxParticles;
			if (!this.m_initialized || this.m_capacity != maxParticles)
			{
				this.Initialize();
				return;
			}
			if (!starting && this.m_wasVisible)
			{
				foreach (KeyValuePair<uint, ParticleState.Particle> keyValuePair in this.m_particleDict)
				{
					ParticleState.Particle value = keyValuePair.Value;
					value.prevLocalToWorld = value.currLocalToWorld;
				}
			}
			this.m_moved = true;
			int particles = this.m_particleSystem.GetParticles(this.m_particles);
			Matrix4x4 lhs = Matrix4x4.TRS(this.m_transform.position, this.m_transform.rotation, Vector3.one);
			bool flag = (this.rotationOverLifetime.enabled && this.rotationOverLifetime.separateAxes) || (this.rotationBySpeed.enabled && this.rotationBySpeed.separateAxes);
			for (int i = 0; i < particles; i++)
			{
				uint randomSeed = this.m_particles[i].randomSeed;
				bool flag2 = false;
				ParticleState.Particle particle;
				if (!this.m_particleDict.TryGetValue(randomSeed, out particle) && this.m_particleStack.Count > 0)
				{
					particle = (this.m_particleDict[randomSeed] = this.m_particleStack.Pop());
					flag2 = true;
				}
				if (particle != null)
				{
					float currentSize = this.m_particles[i].GetCurrentSize(this.m_particleSystem);
					Vector3 s = new Vector3(currentSize, currentSize, currentSize);
					Matrix4x4 from;
					if (this.m_renderer.renderMode == ParticleSystemRenderMode.Mesh)
					{
						Quaternion q;
						if (flag)
						{
							q = Quaternion.Euler(this.m_particles[i].rotation3D);
						}
						else
						{
							q = Quaternion.AngleAxis(this.m_particles[i].rotation, this.m_particles[i].axisOfRotation);
						}
						Matrix4x4 matrix4x = Matrix4x4.TRS(this.m_particles[i].position, q, s);
						if (this.m_particleSystem.main.simulationSpace == ParticleSystemSimulationSpace.World)
						{
							from = matrix4x;
						}
						else
						{
							from = lhs * matrix4x;
						}
					}
					else if (this.m_renderer.renderMode == ParticleSystemRenderMode.Billboard)
					{
						if (this.m_particleSystem.main.simulationSpace == ParticleSystemSimulationSpace.Local)
						{
							this.m_particles[i].position = lhs.MultiplyPoint(this.m_particles[i].position);
						}
						Quaternion rhs;
						if (flag)
						{
							rhs = Quaternion.Euler(-this.m_particles[i].rotation3D.x, -this.m_particles[i].rotation3D.y, this.m_particles[i].rotation3D.z);
						}
						else
						{
							rhs = Quaternion.AngleAxis(this.m_particles[i].rotation, Vector3.back);
						}
						from = Matrix4x4.TRS(this.m_particles[i].position, this.m_owner.Transform.rotation * rhs, s);
					}
					else
					{
						from = Matrix4x4.identity;
					}
					particle.refCount = 1;
					particle.currLocalToWorld = from;
					if (flag2)
					{
						particle.prevLocalToWorld = particle.currLocalToWorld;
					}
				}
			}
			if (starting || !this.m_wasVisible)
			{
				foreach (KeyValuePair<uint, ParticleState.Particle> keyValuePair in this.m_particleDict)
				{
					ParticleState.Particle value2 = keyValuePair.Value;
					value2.prevLocalToWorld = value2.currLocalToWorld;
				}
			}
			this.RemoveDeadParticles();
			this.m_wasVisible = this.m_renderer.isVisible;
		}

		// Token: 0x060023AF RID: 9135 RVA: 0x001F3C98 File Offset: 0x001F1E98
		internal override void RenderVectors(Camera camera, CommandBuffer renderCB, float scale, Quality quality)
		{
			if (this.m_initialized && !this.m_error && this.m_renderer.isVisible)
			{
				bool flag = (this.m_owner.Instance.CullingMask & 1 << this.m_obj.gameObject.layer) != 0;
				if (!flag || (flag && this.m_moved))
				{
					int num = flag ? this.m_owner.Instance.GenerateObjectId(this.m_obj.gameObject) : 255;
					renderCB.SetGlobalFloat("_AM_OBJECT_ID", (float)num * 0.003921569f);
					renderCB.SetGlobalFloat("_AM_MOTION_SCALE", flag ? scale : 0f);
					int num2 = (quality == Quality.Mobile) ? 0 : 2;
					for (int i = 0; i < this.m_sharedMaterials.Length; i++)
					{
						MotionState.MaterialDesc materialDesc = this.m_sharedMaterials[i];
						int shaderPass = num2 + (materialDesc.coverage ? 1 : 0);
						if (materialDesc.coverage)
						{
							Texture mainTexture = materialDesc.material.mainTexture;
							if (mainTexture != null)
							{
								materialDesc.propertyBlock.SetTexture("_MainTex", mainTexture);
							}
							if (materialDesc.cutoff)
							{
								materialDesc.propertyBlock.SetFloat("_Cutoff", materialDesc.material.GetFloat("_Cutoff"));
							}
						}
						foreach (KeyValuePair<uint, ParticleState.Particle> keyValuePair in this.m_particleDict)
						{
							Matrix4x4 value = this.m_owner.PrevViewProjMatrixRT * keyValuePair.Value.prevLocalToWorld;
							renderCB.SetGlobalMatrix("_AM_MATRIX_PREV_MVP", value);
							renderCB.DrawMesh(this.m_mesh, keyValuePair.Value.currLocalToWorld, this.m_owner.Instance.SolidVectorsMaterial, i, shaderPass, materialDesc.propertyBlock);
						}
					}
				}
			}
		}

		// Token: 0x04004B2D RID: 19245
		public ParticleSystem m_particleSystem;

		// Token: 0x04004B2E RID: 19246
		public ParticleSystemRenderer m_renderer;

		// Token: 0x04004B2F RID: 19247
		private Mesh m_mesh;

		// Token: 0x04004B30 RID: 19248
		private ParticleSystem.RotationOverLifetimeModule rotationOverLifetime;

		// Token: 0x04004B31 RID: 19249
		private ParticleSystem.RotationBySpeedModule rotationBySpeed;

		// Token: 0x04004B32 RID: 19250
		private ParticleSystem.Particle[] m_particles;

		// Token: 0x04004B33 RID: 19251
		private Dictionary<uint, ParticleState.Particle> m_particleDict;

		// Token: 0x04004B34 RID: 19252
		private List<uint> m_listToRemove;

		// Token: 0x04004B35 RID: 19253
		private Stack<ParticleState.Particle> m_particleStack;

		// Token: 0x04004B36 RID: 19254
		private int m_capacity;

		// Token: 0x04004B37 RID: 19255
		private MotionState.MaterialDesc[] m_sharedMaterials;

		// Token: 0x04004B38 RID: 19256
		private bool m_moved;

		// Token: 0x04004B39 RID: 19257
		private bool m_wasVisible;

		// Token: 0x04004B3A RID: 19258
		private static HashSet<AmplifyMotionObjectBase> m_uniqueWarnings = new HashSet<AmplifyMotionObjectBase>();

		// Token: 0x020006D5 RID: 1749
		protected class Particle
		{
			// Token: 0x04005181 RID: 20865
			public int refCount;

			// Token: 0x04005182 RID: 20866
			public MotionState.Matrix3x4 prevLocalToWorld;

			// Token: 0x04005183 RID: 20867
			public MotionState.Matrix3x4 currLocalToWorld;
		}
	}
}
