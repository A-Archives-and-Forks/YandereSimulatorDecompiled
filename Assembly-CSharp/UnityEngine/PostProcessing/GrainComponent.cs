﻿using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055B RID: 1371
	public sealed class GrainComponent : PostProcessingComponentRenderTexture<GrainModel>
	{
		// Token: 0x170004F5 RID: 1269
		// (get) Token: 0x060022F1 RID: 8945 RVA: 0x001F1E42 File Offset: 0x001F0042
		public override bool active
		{
			get
			{
				return base.model.enabled && base.model.settings.intensity > 0f && SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.ARGBHalf) && !this.context.interrupted;
			}
		}

		// Token: 0x060022F2 RID: 8946 RVA: 0x001F1E80 File Offset: 0x001F0080
		public override void OnDisable()
		{
			GraphicsUtils.Destroy(this.m_GrainLookupRT);
			this.m_GrainLookupRT = null;
		}

		// Token: 0x060022F3 RID: 8947 RVA: 0x001F1E94 File Offset: 0x001F0094
		public override void Prepare(Material uberMaterial)
		{
			GrainModel.Settings settings = base.model.settings;
			uberMaterial.EnableKeyword("GRAIN");
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			float value = Random.value;
			float value2 = Random.value;
			if (this.m_GrainLookupRT == null || !this.m_GrainLookupRT.IsCreated())
			{
				GraphicsUtils.Destroy(this.m_GrainLookupRT);
				this.m_GrainLookupRT = new RenderTexture(192, 192, 0, RenderTextureFormat.ARGBHalf)
				{
					filterMode = FilterMode.Bilinear,
					wrapMode = TextureWrapMode.Repeat,
					anisoLevel = 0,
					name = "Grain Lookup Texture"
				};
				this.m_GrainLookupRT.Create();
			}
			Material material = this.context.materialFactory.Get("Hidden/Post FX/Grain Generator");
			material.SetFloat(GrainComponent.Uniforms._Phase, realtimeSinceStartup / 20f);
			Graphics.Blit(null, this.m_GrainLookupRT, material, settings.colored ? 1 : 0);
			uberMaterial.SetTexture(GrainComponent.Uniforms._GrainTex, this.m_GrainLookupRT);
			uberMaterial.SetVector(GrainComponent.Uniforms._Grain_Params1, new Vector2(settings.luminanceContribution, settings.intensity * 20f));
			uberMaterial.SetVector(GrainComponent.Uniforms._Grain_Params2, new Vector4((float)this.context.width / (float)this.m_GrainLookupRT.width / settings.size, (float)this.context.height / (float)this.m_GrainLookupRT.height / settings.size, value, value2));
		}

		// Token: 0x04004ADC RID: 19164
		private RenderTexture m_GrainLookupRT;

		// Token: 0x0200069A RID: 1690
		private static class Uniforms
		{
			// Token: 0x0400504B RID: 20555
			internal static readonly int _Grain_Params1 = Shader.PropertyToID("_Grain_Params1");

			// Token: 0x0400504C RID: 20556
			internal static readonly int _Grain_Params2 = Shader.PropertyToID("_Grain_Params2");

			// Token: 0x0400504D RID: 20557
			internal static readonly int _GrainTex = Shader.PropertyToID("_GrainTex");

			// Token: 0x0400504E RID: 20558
			internal static readonly int _Phase = Shader.PropertyToID("_Phase");
		}
	}
}
