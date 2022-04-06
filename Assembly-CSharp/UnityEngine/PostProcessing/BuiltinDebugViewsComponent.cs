﻿using System;
using System.Collections.Generic;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000560 RID: 1376
	public sealed class BuiltinDebugViewsComponent : PostProcessingComponentCommandBuffer<BuiltinDebugViewsModel>
	{
		// Token: 0x170004F0 RID: 1264
		// (get) Token: 0x060022F5 RID: 8949 RVA: 0x001F5714 File Offset: 0x001F3914
		public override bool active
		{
			get
			{
				return base.model.IsModeActive(BuiltinDebugViewsModel.Mode.Depth) || base.model.IsModeActive(BuiltinDebugViewsModel.Mode.Normals) || base.model.IsModeActive(BuiltinDebugViewsModel.Mode.MotionVectors);
			}
		}

		// Token: 0x060022F6 RID: 8950 RVA: 0x001F5740 File Offset: 0x001F3940
		public override DepthTextureMode GetCameraFlags()
		{
			BuiltinDebugViewsModel.Mode mode = base.model.settings.mode;
			DepthTextureMode depthTextureMode = DepthTextureMode.None;
			switch (mode)
			{
			case BuiltinDebugViewsModel.Mode.Depth:
				depthTextureMode |= DepthTextureMode.Depth;
				break;
			case BuiltinDebugViewsModel.Mode.Normals:
				depthTextureMode |= DepthTextureMode.DepthNormals;
				break;
			case BuiltinDebugViewsModel.Mode.MotionVectors:
				depthTextureMode |= (DepthTextureMode.Depth | DepthTextureMode.MotionVectors);
				break;
			}
			return depthTextureMode;
		}

		// Token: 0x060022F7 RID: 8951 RVA: 0x001F5787 File Offset: 0x001F3987
		public override CameraEvent GetCameraEvent()
		{
			if (base.model.settings.mode != BuiltinDebugViewsModel.Mode.MotionVectors)
			{
				return CameraEvent.BeforeImageEffectsOpaque;
			}
			return CameraEvent.BeforeImageEffects;
		}

		// Token: 0x060022F8 RID: 8952 RVA: 0x001F57A1 File Offset: 0x001F39A1
		public override string GetName()
		{
			return "Builtin Debug Views";
		}

		// Token: 0x060022F9 RID: 8953 RVA: 0x001F57A8 File Offset: 0x001F39A8
		public override void PopulateCommandBuffer(CommandBuffer cb)
		{
			ref BuiltinDebugViewsModel.Settings settings = base.model.settings;
			Material material = this.context.materialFactory.Get("Hidden/Post FX/Builtin Debug Views");
			material.shaderKeywords = null;
			if (this.context.isGBufferAvailable)
			{
				material.EnableKeyword("SOURCE_GBUFFER");
			}
			switch (settings.mode)
			{
			case BuiltinDebugViewsModel.Mode.Depth:
				this.DepthPass(cb);
				break;
			case BuiltinDebugViewsModel.Mode.Normals:
				this.DepthNormalsPass(cb);
				break;
			case BuiltinDebugViewsModel.Mode.MotionVectors:
				this.MotionVectorsPass(cb);
				break;
			}
			this.context.Interrupt();
		}

		// Token: 0x060022FA RID: 8954 RVA: 0x001F5838 File Offset: 0x001F3A38
		private void DepthPass(CommandBuffer cb)
		{
			Material mat = this.context.materialFactory.Get("Hidden/Post FX/Builtin Debug Views");
			BuiltinDebugViewsModel.DepthSettings depth = base.model.settings.depth;
			cb.SetGlobalFloat(BuiltinDebugViewsComponent.Uniforms._DepthScale, 1f / depth.scale);
			cb.Blit(null, BuiltinRenderTextureType.CameraTarget, mat, 0);
		}

		// Token: 0x060022FB RID: 8955 RVA: 0x001F5894 File Offset: 0x001F3A94
		private void DepthNormalsPass(CommandBuffer cb)
		{
			Material mat = this.context.materialFactory.Get("Hidden/Post FX/Builtin Debug Views");
			cb.Blit(null, BuiltinRenderTextureType.CameraTarget, mat, 1);
		}

		// Token: 0x060022FC RID: 8956 RVA: 0x001F58C8 File Offset: 0x001F3AC8
		private void MotionVectorsPass(CommandBuffer cb)
		{
			Material material = this.context.materialFactory.Get("Hidden/Post FX/Builtin Debug Views");
			BuiltinDebugViewsModel.MotionVectorsSettings motionVectors = base.model.settings.motionVectors;
			int nameID = BuiltinDebugViewsComponent.Uniforms._TempRT;
			cb.GetTemporaryRT(nameID, this.context.width, this.context.height, 0, FilterMode.Bilinear);
			cb.SetGlobalFloat(BuiltinDebugViewsComponent.Uniforms._Opacity, motionVectors.sourceOpacity);
			cb.SetGlobalTexture(BuiltinDebugViewsComponent.Uniforms._MainTex, BuiltinRenderTextureType.CameraTarget);
			cb.Blit(BuiltinRenderTextureType.CameraTarget, nameID, material, 2);
			if (motionVectors.motionImageOpacity > 0f && motionVectors.motionImageAmplitude > 0f)
			{
				int tempRT = BuiltinDebugViewsComponent.Uniforms._TempRT2;
				cb.GetTemporaryRT(tempRT, this.context.width, this.context.height, 0, FilterMode.Bilinear);
				cb.SetGlobalFloat(BuiltinDebugViewsComponent.Uniforms._Opacity, motionVectors.motionImageOpacity);
				cb.SetGlobalFloat(BuiltinDebugViewsComponent.Uniforms._Amplitude, motionVectors.motionImageAmplitude);
				cb.SetGlobalTexture(BuiltinDebugViewsComponent.Uniforms._MainTex, nameID);
				cb.Blit(nameID, tempRT, material, 3);
				cb.ReleaseTemporaryRT(nameID);
				nameID = tempRT;
			}
			if (motionVectors.motionVectorsOpacity > 0f && motionVectors.motionVectorsAmplitude > 0f)
			{
				this.PrepareArrows();
				float num = 1f / (float)motionVectors.motionVectorsResolution;
				float x = num * (float)this.context.height / (float)this.context.width;
				cb.SetGlobalVector(BuiltinDebugViewsComponent.Uniforms._Scale, new Vector2(x, num));
				cb.SetGlobalFloat(BuiltinDebugViewsComponent.Uniforms._Opacity, motionVectors.motionVectorsOpacity);
				cb.SetGlobalFloat(BuiltinDebugViewsComponent.Uniforms._Amplitude, motionVectors.motionVectorsAmplitude);
				cb.DrawMesh(this.m_Arrows.mesh, Matrix4x4.identity, material, 0, 4);
			}
			cb.SetGlobalTexture(BuiltinDebugViewsComponent.Uniforms._MainTex, nameID);
			cb.Blit(nameID, BuiltinRenderTextureType.CameraTarget);
			cb.ReleaseTemporaryRT(nameID);
		}

		// Token: 0x060022FD RID: 8957 RVA: 0x001F5ABC File Offset: 0x001F3CBC
		private void PrepareArrows()
		{
			int motionVectorsResolution = base.model.settings.motionVectors.motionVectorsResolution;
			int num = motionVectorsResolution * Screen.width / Screen.height;
			if (this.m_Arrows == null)
			{
				this.m_Arrows = new BuiltinDebugViewsComponent.ArrowArray();
			}
			if (this.m_Arrows.columnCount != num || this.m_Arrows.rowCount != motionVectorsResolution)
			{
				this.m_Arrows.Release();
				this.m_Arrows.BuildMesh(num, motionVectorsResolution);
			}
		}

		// Token: 0x060022FE RID: 8958 RVA: 0x001F5B34 File Offset: 0x001F3D34
		public override void OnDisable()
		{
			if (this.m_Arrows != null)
			{
				this.m_Arrows.Release();
			}
			this.m_Arrows = null;
		}

		// Token: 0x04004B90 RID: 19344
		private const string k_ShaderString = "Hidden/Post FX/Builtin Debug Views";

		// Token: 0x04004B91 RID: 19345
		private BuiltinDebugViewsComponent.ArrowArray m_Arrows;

		// Token: 0x0200069F RID: 1695
		private static class Uniforms
		{
			// Token: 0x040050DE RID: 20702
			internal static readonly int _DepthScale = Shader.PropertyToID("_DepthScale");

			// Token: 0x040050DF RID: 20703
			internal static readonly int _TempRT = Shader.PropertyToID("_TempRT");

			// Token: 0x040050E0 RID: 20704
			internal static readonly int _Opacity = Shader.PropertyToID("_Opacity");

			// Token: 0x040050E1 RID: 20705
			internal static readonly int _MainTex = Shader.PropertyToID("_MainTex");

			// Token: 0x040050E2 RID: 20706
			internal static readonly int _TempRT2 = Shader.PropertyToID("_TempRT2");

			// Token: 0x040050E3 RID: 20707
			internal static readonly int _Amplitude = Shader.PropertyToID("_Amplitude");

			// Token: 0x040050E4 RID: 20708
			internal static readonly int _Scale = Shader.PropertyToID("_Scale");
		}

		// Token: 0x020006A0 RID: 1696
		private enum Pass
		{
			// Token: 0x040050E6 RID: 20710
			Depth,
			// Token: 0x040050E7 RID: 20711
			Normals,
			// Token: 0x040050E8 RID: 20712
			MovecOpacity,
			// Token: 0x040050E9 RID: 20713
			MovecImaging,
			// Token: 0x040050EA RID: 20714
			MovecArrows
		}

		// Token: 0x020006A1 RID: 1697
		private class ArrowArray
		{
			// Token: 0x17000589 RID: 1417
			// (get) Token: 0x0600274C RID: 10060 RVA: 0x00205F22 File Offset: 0x00204122
			// (set) Token: 0x0600274D RID: 10061 RVA: 0x00205F2A File Offset: 0x0020412A
			public Mesh mesh { get; private set; }

			// Token: 0x1700058A RID: 1418
			// (get) Token: 0x0600274E RID: 10062 RVA: 0x00205F33 File Offset: 0x00204133
			// (set) Token: 0x0600274F RID: 10063 RVA: 0x00205F3B File Offset: 0x0020413B
			public int columnCount { get; private set; }

			// Token: 0x1700058B RID: 1419
			// (get) Token: 0x06002750 RID: 10064 RVA: 0x00205F44 File Offset: 0x00204144
			// (set) Token: 0x06002751 RID: 10065 RVA: 0x00205F4C File Offset: 0x0020414C
			public int rowCount { get; private set; }

			// Token: 0x06002752 RID: 10066 RVA: 0x00205F58 File Offset: 0x00204158
			public void BuildMesh(int columns, int rows)
			{
				Vector3[] array = new Vector3[]
				{
					new Vector3(0f, 0f, 0f),
					new Vector3(0f, 1f, 0f),
					new Vector3(0f, 1f, 0f),
					new Vector3(-1f, 1f, 0f),
					new Vector3(0f, 1f, 0f),
					new Vector3(1f, 1f, 0f)
				};
				int num = 6 * columns * rows;
				List<Vector3> list = new List<Vector3>(num);
				List<Vector2> list2 = new List<Vector2>(num);
				for (int i = 0; i < rows; i++)
				{
					for (int j = 0; j < columns; j++)
					{
						Vector2 item = new Vector2((0.5f + (float)j) / (float)columns, (0.5f + (float)i) / (float)rows);
						for (int k = 0; k < 6; k++)
						{
							list.Add(array[k]);
							list2.Add(item);
						}
					}
				}
				int[] array2 = new int[num];
				for (int l = 0; l < num; l++)
				{
					array2[l] = l;
				}
				this.mesh = new Mesh
				{
					hideFlags = HideFlags.DontSave
				};
				this.mesh.SetVertices(list);
				this.mesh.SetUVs(0, list2);
				this.mesh.SetIndices(array2, MeshTopology.Lines, 0);
				this.mesh.UploadMeshData(true);
				this.columnCount = columns;
				this.rowCount = rows;
			}

			// Token: 0x06002753 RID: 10067 RVA: 0x002060FB File Offset: 0x002042FB
			public void Release()
			{
				GraphicsUtils.Destroy(this.mesh);
				this.mesh = null;
			}
		}
	}
}
