﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace AmplifyMotion
{
	// Token: 0x02000585 RID: 1413
	internal class SolidState : MotionState
	{
		// Token: 0x060023F6 RID: 9206 RVA: 0x001F8D17 File Offset: 0x001F6F17
		public SolidState(AmplifyMotionCamera owner, AmplifyMotionObjectBase obj) : base(owner, obj)
		{
			this.m_meshRenderer = this.m_obj.GetComponent<MeshRenderer>();
		}

		// Token: 0x060023F7 RID: 9207 RVA: 0x001F8D32 File Offset: 0x001F6F32
		private void IssueError(string message)
		{
			if (!SolidState.m_uniqueWarnings.Contains(this.m_obj))
			{
				Debug.LogWarning(message);
				SolidState.m_uniqueWarnings.Add(this.m_obj);
			}
			this.m_error = true;
		}

		// Token: 0x060023F8 RID: 9208 RVA: 0x001F8D64 File Offset: 0x001F6F64
		internal override void Initialize()
		{
			MeshFilter component = this.m_obj.GetComponent<MeshFilter>();
			if (component == null || component.sharedMesh == null)
			{
				this.IssueError("[AmplifyMotion] Invalid MeshFilter/Mesh in object " + this.m_obj.name + ". Skipping.");
				return;
			}
			base.Initialize();
			this.m_mesh = component.sharedMesh;
			this.m_sharedMaterials = base.ProcessSharedMaterials(this.m_meshRenderer.sharedMaterials);
			this.m_wasVisible = false;
		}

		// Token: 0x060023F9 RID: 9209 RVA: 0x001F8DE8 File Offset: 0x001F6FE8
		internal override void UpdateTransform(CommandBuffer updateCB, bool starting)
		{
			if (!this.m_initialized)
			{
				this.Initialize();
				return;
			}
			if (!starting && this.m_wasVisible)
			{
				this.m_prevLocalToWorld = this.m_currLocalToWorld;
			}
			this.m_currLocalToWorld = this.m_transform.localToWorldMatrix;
			this.m_moved = true;
			if (!this.m_owner.Overlay)
			{
				this.m_moved = (starting || MotionState.MatrixChanged(this.m_currLocalToWorld, this.m_prevLocalToWorld));
			}
			if (starting || !this.m_wasVisible)
			{
				this.m_prevLocalToWorld = this.m_currLocalToWorld;
			}
			this.m_wasVisible = this.m_meshRenderer.isVisible;
		}

		// Token: 0x060023FA RID: 9210 RVA: 0x001F8E8C File Offset: 0x001F708C
		internal override void RenderVectors(Camera camera, CommandBuffer renderCB, float scale, Quality quality)
		{
			if (this.m_initialized && !this.m_error && this.m_meshRenderer.isVisible)
			{
				bool flag = (this.m_owner.Instance.CullingMask & 1 << this.m_obj.gameObject.layer) != 0;
				if (!flag || (flag && this.m_moved))
				{
					int num = flag ? this.m_owner.Instance.GenerateObjectId(this.m_obj.gameObject) : 255;
					Matrix4x4 value;
					if (this.m_obj.FixedStep)
					{
						value = this.m_owner.PrevViewProjMatrixRT * this.m_currLocalToWorld;
					}
					else
					{
						value = this.m_owner.PrevViewProjMatrixRT * this.m_prevLocalToWorld;
					}
					renderCB.SetGlobalMatrix("_AM_MATRIX_PREV_MVP", value);
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
						renderCB.DrawMesh(this.m_mesh, this.m_transform.localToWorldMatrix, this.m_owner.Instance.SolidVectorsMaterial, i, shaderPass, materialDesc.propertyBlock);
					}
				}
			}
		}

		// Token: 0x04004BAD RID: 19373
		private MeshRenderer m_meshRenderer;

		// Token: 0x04004BAE RID: 19374
		private MotionState.Matrix3x4 m_prevLocalToWorld;

		// Token: 0x04004BAF RID: 19375
		private MotionState.Matrix3x4 m_currLocalToWorld;

		// Token: 0x04004BB0 RID: 19376
		private Mesh m_mesh;

		// Token: 0x04004BB1 RID: 19377
		private MotionState.MaterialDesc[] m_sharedMaterials;

		// Token: 0x04004BB2 RID: 19378
		public bool m_moved;

		// Token: 0x04004BB3 RID: 19379
		private bool m_wasVisible;

		// Token: 0x04004BB4 RID: 19380
		private static HashSet<AmplifyMotionObjectBase> m_uniqueWarnings = new HashSet<AmplifyMotionObjectBase>();
	}
}
