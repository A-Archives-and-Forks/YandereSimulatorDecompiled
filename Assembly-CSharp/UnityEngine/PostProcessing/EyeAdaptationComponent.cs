﻿using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000553 RID: 1363
	public sealed class EyeAdaptationComponent : PostProcessingComponentRenderTexture<EyeAdaptationModel>
	{
		// Token: 0x170004F1 RID: 1265
		// (get) Token: 0x060022B9 RID: 8889 RVA: 0x001ED712 File Offset: 0x001EB912
		public override bool active
		{
			get
			{
				return base.model.enabled && SystemInfo.supportsComputeShaders && !this.context.interrupted;
			}
		}

		// Token: 0x060022BA RID: 8890 RVA: 0x001ED738 File Offset: 0x001EB938
		public void ResetHistory()
		{
			this.m_FirstFrame = true;
		}

		// Token: 0x060022BB RID: 8891 RVA: 0x001ED741 File Offset: 0x001EB941
		public override void OnEnable()
		{
			this.m_FirstFrame = true;
		}

		// Token: 0x060022BC RID: 8892 RVA: 0x001ED74C File Offset: 0x001EB94C
		public override void OnDisable()
		{
			RenderTexture[] autoExposurePool = this.m_AutoExposurePool;
			for (int i = 0; i < autoExposurePool.Length; i++)
			{
				GraphicsUtils.Destroy(autoExposurePool[i]);
			}
			if (this.m_HistogramBuffer != null)
			{
				this.m_HistogramBuffer.Release();
			}
			this.m_HistogramBuffer = null;
			if (this.m_DebugHistogram != null)
			{
				this.m_DebugHistogram.Release();
			}
			this.m_DebugHistogram = null;
		}

		// Token: 0x060022BD RID: 8893 RVA: 0x001ED7B0 File Offset: 0x001EB9B0
		private Vector4 GetHistogramScaleOffsetRes()
		{
			EyeAdaptationModel.Settings settings = base.model.settings;
			float num = (float)(settings.logMax - settings.logMin);
			float num2 = 1f / num;
			float y = (float)(-(float)settings.logMin) * num2;
			return new Vector4(num2, y, Mathf.Floor((float)this.context.width / 2f), Mathf.Floor((float)this.context.height / 2f));
		}

		// Token: 0x060022BE RID: 8894 RVA: 0x001ED820 File Offset: 0x001EBA20
		public Texture Prepare(RenderTexture source, Material uberMaterial)
		{
			EyeAdaptationModel.Settings settings = base.model.settings;
			if (this.m_EyeCompute == null)
			{
				this.m_EyeCompute = Resources.Load<ComputeShader>("Shaders/EyeHistogram");
			}
			Material material = this.context.materialFactory.Get("Hidden/Post FX/Eye Adaptation");
			material.shaderKeywords = null;
			if (this.m_HistogramBuffer == null)
			{
				this.m_HistogramBuffer = new ComputeBuffer(64, 4);
			}
			if (EyeAdaptationComponent.s_EmptyHistogramBuffer == null)
			{
				EyeAdaptationComponent.s_EmptyHistogramBuffer = new uint[64];
			}
			Vector4 histogramScaleOffsetRes = this.GetHistogramScaleOffsetRes();
			RenderTexture renderTexture = this.context.renderTextureFactory.Get((int)histogramScaleOffsetRes.z, (int)histogramScaleOffsetRes.w, 0, source.format, RenderTextureReadWrite.Default, FilterMode.Bilinear, TextureWrapMode.Clamp, "FactoryTempTexture");
			Graphics.Blit(source, renderTexture);
			if (this.m_AutoExposurePool[0] == null || !this.m_AutoExposurePool[0].IsCreated())
			{
				this.m_AutoExposurePool[0] = new RenderTexture(1, 1, 0, RenderTextureFormat.RFloat);
			}
			if (this.m_AutoExposurePool[1] == null || !this.m_AutoExposurePool[1].IsCreated())
			{
				this.m_AutoExposurePool[1] = new RenderTexture(1, 1, 0, RenderTextureFormat.RFloat);
			}
			this.m_HistogramBuffer.SetData(EyeAdaptationComponent.s_EmptyHistogramBuffer);
			int kernelIndex = this.m_EyeCompute.FindKernel("KEyeHistogram");
			this.m_EyeCompute.SetBuffer(kernelIndex, "_Histogram", this.m_HistogramBuffer);
			this.m_EyeCompute.SetTexture(kernelIndex, "_Source", renderTexture);
			this.m_EyeCompute.SetVector("_ScaleOffsetRes", histogramScaleOffsetRes);
			this.m_EyeCompute.Dispatch(kernelIndex, Mathf.CeilToInt((float)renderTexture.width / 16f), Mathf.CeilToInt((float)renderTexture.height / 16f), 1);
			this.context.renderTextureFactory.Release(renderTexture);
			settings.highPercent = Mathf.Clamp(settings.highPercent, 1.01f, 99f);
			settings.lowPercent = Mathf.Clamp(settings.lowPercent, 1f, settings.highPercent - 0.01f);
			material.SetBuffer("_Histogram", this.m_HistogramBuffer);
			material.SetVector(EyeAdaptationComponent.Uniforms._Params, new Vector4(settings.lowPercent * 0.01f, settings.highPercent * 0.01f, Mathf.Exp(settings.minLuminance * 0.6931472f), Mathf.Exp(settings.maxLuminance * 0.6931472f)));
			material.SetVector(EyeAdaptationComponent.Uniforms._Speed, new Vector2(settings.speedDown, settings.speedUp));
			material.SetVector(EyeAdaptationComponent.Uniforms._ScaleOffsetRes, histogramScaleOffsetRes);
			material.SetFloat(EyeAdaptationComponent.Uniforms._ExposureCompensation, settings.keyValue);
			if (settings.dynamicKeyValue)
			{
				material.EnableKeyword("AUTO_KEY_VALUE");
			}
			if (this.m_FirstFrame || !Application.isPlaying)
			{
				this.m_CurrentAutoExposure = this.m_AutoExposurePool[0];
				Graphics.Blit(null, this.m_CurrentAutoExposure, material, 1);
				Graphics.Blit(this.m_AutoExposurePool[0], this.m_AutoExposurePool[1]);
			}
			else
			{
				int num = this.m_AutoExposurePingPing;
				Texture source2 = this.m_AutoExposurePool[++num % 2];
				RenderTexture renderTexture2 = this.m_AutoExposurePool[++num % 2];
				Graphics.Blit(source2, renderTexture2, material, (int)settings.adaptationType);
				this.m_AutoExposurePingPing = (num + 1) % 2;
				this.m_CurrentAutoExposure = renderTexture2;
			}
			if (this.context.profile.debugViews.IsModeActive(BuiltinDebugViewsModel.Mode.EyeAdaptation))
			{
				if (this.m_DebugHistogram == null || !this.m_DebugHistogram.IsCreated())
				{
					this.m_DebugHistogram = new RenderTexture(256, 128, 0, RenderTextureFormat.ARGB32)
					{
						filterMode = FilterMode.Point,
						wrapMode = TextureWrapMode.Clamp
					};
				}
				material.SetFloat(EyeAdaptationComponent.Uniforms._DebugWidth, (float)this.m_DebugHistogram.width);
				Graphics.Blit(null, this.m_DebugHistogram, material, 2);
			}
			this.m_FirstFrame = false;
			return this.m_CurrentAutoExposure;
		}

		// Token: 0x060022BF RID: 8895 RVA: 0x001EDBE4 File Offset: 0x001EBDE4
		public void OnGUI()
		{
			if (this.m_DebugHistogram == null || !this.m_DebugHistogram.IsCreated())
			{
				return;
			}
			GUI.DrawTexture(new Rect(this.context.viewport.x * (float)Screen.width + 8f, 8f, (float)this.m_DebugHistogram.width, (float)this.m_DebugHistogram.height), this.m_DebugHistogram);
		}

		// Token: 0x04004A5C RID: 19036
		private ComputeShader m_EyeCompute;

		// Token: 0x04004A5D RID: 19037
		private ComputeBuffer m_HistogramBuffer;

		// Token: 0x04004A5E RID: 19038
		private readonly RenderTexture[] m_AutoExposurePool = new RenderTexture[2];

		// Token: 0x04004A5F RID: 19039
		private int m_AutoExposurePingPing;

		// Token: 0x04004A60 RID: 19040
		private RenderTexture m_CurrentAutoExposure;

		// Token: 0x04004A61 RID: 19041
		private RenderTexture m_DebugHistogram;

		// Token: 0x04004A62 RID: 19042
		private static uint[] s_EmptyHistogramBuffer;

		// Token: 0x04004A63 RID: 19043
		private bool m_FirstFrame = true;

		// Token: 0x04004A64 RID: 19044
		private const int k_HistogramBins = 64;

		// Token: 0x04004A65 RID: 19045
		private const int k_HistogramThreadX = 16;

		// Token: 0x04004A66 RID: 19046
		private const int k_HistogramThreadY = 16;

		// Token: 0x02000697 RID: 1687
		private static class Uniforms
		{
			// Token: 0x04004FEC RID: 20460
			internal static readonly int _Params = Shader.PropertyToID("_Params");

			// Token: 0x04004FED RID: 20461
			internal static readonly int _Speed = Shader.PropertyToID("_Speed");

			// Token: 0x04004FEE RID: 20462
			internal static readonly int _ScaleOffsetRes = Shader.PropertyToID("_ScaleOffsetRes");

			// Token: 0x04004FEF RID: 20463
			internal static readonly int _ExposureCompensation = Shader.PropertyToID("_ExposureCompensation");

			// Token: 0x04004FF0 RID: 20464
			internal static readonly int _AutoExposure = Shader.PropertyToID("_AutoExposure");

			// Token: 0x04004FF1 RID: 20465
			internal static readonly int _DebugWidth = Shader.PropertyToID("_DebugWidth");
		}
	}
}
