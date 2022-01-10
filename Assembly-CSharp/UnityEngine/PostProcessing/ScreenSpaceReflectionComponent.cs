﻿using System;
using UnityEngine.Rendering;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055C RID: 1372
	public sealed class ScreenSpaceReflectionComponent : PostProcessingComponentCommandBuffer<ScreenSpaceReflectionModel>
	{
		// Token: 0x060022F8 RID: 8952 RVA: 0x001F0A6B File Offset: 0x001EEC6B
		public override DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.Depth;
		}

		// Token: 0x170004F9 RID: 1273
		// (get) Token: 0x060022F9 RID: 8953 RVA: 0x001F0A6E File Offset: 0x001EEC6E
		public override bool active
		{
			get
			{
				return base.model.enabled && this.context.isGBufferAvailable && !this.context.interrupted;
			}
		}

		// Token: 0x060022FA RID: 8954 RVA: 0x001F0A9C File Offset: 0x001EEC9C
		public override void OnEnable()
		{
			this.m_ReflectionTextures[0] = Shader.PropertyToID("_ReflectionTexture0");
			this.m_ReflectionTextures[1] = Shader.PropertyToID("_ReflectionTexture1");
			this.m_ReflectionTextures[2] = Shader.PropertyToID("_ReflectionTexture2");
			this.m_ReflectionTextures[3] = Shader.PropertyToID("_ReflectionTexture3");
			this.m_ReflectionTextures[4] = Shader.PropertyToID("_ReflectionTexture4");
		}

		// Token: 0x060022FB RID: 8955 RVA: 0x001F0B03 File Offset: 0x001EED03
		public override string GetName()
		{
			return "Screen Space Reflection";
		}

		// Token: 0x060022FC RID: 8956 RVA: 0x001F0B0A File Offset: 0x001EED0A
		public override CameraEvent GetCameraEvent()
		{
			return CameraEvent.AfterFinalPass;
		}

		// Token: 0x060022FD RID: 8957 RVA: 0x001F0B10 File Offset: 0x001EED10
		public override void PopulateCommandBuffer(CommandBuffer cb)
		{
			ScreenSpaceReflectionModel.Settings settings = base.model.settings;
			Camera camera = this.context.camera;
			int num = (settings.reflection.reflectionQuality == ScreenSpaceReflectionModel.SSRResolution.High) ? 1 : 2;
			int num2 = this.context.width / num;
			int num3 = this.context.height / num;
			float num4 = (float)this.context.width;
			float num5 = (float)this.context.height;
			float num6 = num4 / 2f;
			float num7 = num5 / 2f;
			Material material = this.context.materialFactory.Get("Hidden/Post FX/Screen Space Reflection");
			material.SetInt(ScreenSpaceReflectionComponent.Uniforms._RayStepSize, settings.reflection.stepSize);
			material.SetInt(ScreenSpaceReflectionComponent.Uniforms._AdditiveReflection, (settings.reflection.blendType == ScreenSpaceReflectionModel.SSRReflectionBlendType.Additive) ? 1 : 0);
			material.SetInt(ScreenSpaceReflectionComponent.Uniforms._BilateralUpsampling, this.k_BilateralUpsample ? 1 : 0);
			material.SetInt(ScreenSpaceReflectionComponent.Uniforms._TreatBackfaceHitAsMiss, this.k_TreatBackfaceHitAsMiss ? 1 : 0);
			material.SetInt(ScreenSpaceReflectionComponent.Uniforms._AllowBackwardsRays, settings.reflection.reflectBackfaces ? 1 : 0);
			material.SetInt(ScreenSpaceReflectionComponent.Uniforms._TraceBehindObjects, this.k_TraceBehindObjects ? 1 : 0);
			material.SetInt(ScreenSpaceReflectionComponent.Uniforms._MaxSteps, settings.reflection.iterationCount);
			material.SetInt(ScreenSpaceReflectionComponent.Uniforms._FullResolutionFiltering, 0);
			material.SetInt(ScreenSpaceReflectionComponent.Uniforms._HalfResolution, (settings.reflection.reflectionQuality != ScreenSpaceReflectionModel.SSRResolution.High) ? 1 : 0);
			material.SetInt(ScreenSpaceReflectionComponent.Uniforms._HighlightSuppression, this.k_HighlightSuppression ? 1 : 0);
			float value = num4 / (-2f * Mathf.Tan(camera.fieldOfView / 180f * 3.1415927f * 0.5f));
			material.SetFloat(ScreenSpaceReflectionComponent.Uniforms._PixelsPerMeterAtOneMeter, value);
			material.SetFloat(ScreenSpaceReflectionComponent.Uniforms._ScreenEdgeFading, settings.screenEdgeMask.intensity);
			material.SetFloat(ScreenSpaceReflectionComponent.Uniforms._ReflectionBlur, settings.reflection.reflectionBlur);
			material.SetFloat(ScreenSpaceReflectionComponent.Uniforms._MaxRayTraceDistance, settings.reflection.maxDistance);
			material.SetFloat(ScreenSpaceReflectionComponent.Uniforms._FadeDistance, settings.intensity.fadeDistance);
			material.SetFloat(ScreenSpaceReflectionComponent.Uniforms._LayerThickness, settings.reflection.widthModifier);
			material.SetFloat(ScreenSpaceReflectionComponent.Uniforms._SSRMultiplier, settings.intensity.reflectionMultiplier);
			material.SetFloat(ScreenSpaceReflectionComponent.Uniforms._FresnelFade, settings.intensity.fresnelFade);
			material.SetFloat(ScreenSpaceReflectionComponent.Uniforms._FresnelFadePower, settings.intensity.fresnelFadePower);
			Matrix4x4 projectionMatrix = camera.projectionMatrix;
			Vector4 value2 = new Vector4(-2f / (num4 * projectionMatrix[0]), -2f / (num5 * projectionMatrix[5]), (1f - projectionMatrix[2]) / projectionMatrix[0], (1f + projectionMatrix[6]) / projectionMatrix[5]);
			Vector3 v = float.IsPositiveInfinity(camera.farClipPlane) ? new Vector3(camera.nearClipPlane, -1f, 1f) : new Vector3(camera.nearClipPlane * camera.farClipPlane, camera.nearClipPlane - camera.farClipPlane, camera.farClipPlane);
			material.SetVector(ScreenSpaceReflectionComponent.Uniforms._ReflectionBufferSize, new Vector2((float)num2, (float)num3));
			material.SetVector(ScreenSpaceReflectionComponent.Uniforms._ScreenSize, new Vector2(num4, num5));
			material.SetVector(ScreenSpaceReflectionComponent.Uniforms._InvScreenSize, new Vector2(1f / num4, 1f / num5));
			material.SetVector(ScreenSpaceReflectionComponent.Uniforms._ProjInfo, value2);
			material.SetVector(ScreenSpaceReflectionComponent.Uniforms._CameraClipInfo, v);
			Matrix4x4 lhs = default(Matrix4x4);
			lhs.SetRow(0, new Vector4(num6, 0f, 0f, num6));
			lhs.SetRow(1, new Vector4(0f, num7, 0f, num7));
			lhs.SetRow(2, new Vector4(0f, 0f, 1f, 0f));
			lhs.SetRow(3, new Vector4(0f, 0f, 0f, 1f));
			Matrix4x4 value3 = lhs * projectionMatrix;
			material.SetMatrix(ScreenSpaceReflectionComponent.Uniforms._ProjectToPixelMatrix, value3);
			material.SetMatrix(ScreenSpaceReflectionComponent.Uniforms._WorldToCameraMatrix, camera.worldToCameraMatrix);
			material.SetMatrix(ScreenSpaceReflectionComponent.Uniforms._CameraToWorldMatrix, camera.worldToCameraMatrix.inverse);
			RenderTextureFormat format = this.context.isHdr ? RenderTextureFormat.ARGBHalf : RenderTextureFormat.ARGB32;
			int normalAndRoughnessTexture = ScreenSpaceReflectionComponent.Uniforms._NormalAndRoughnessTexture;
			int hitPointTexture = ScreenSpaceReflectionComponent.Uniforms._HitPointTexture;
			int blurTexture = ScreenSpaceReflectionComponent.Uniforms._BlurTexture;
			int filteredReflections = ScreenSpaceReflectionComponent.Uniforms._FilteredReflections;
			int finalReflectionTexture = ScreenSpaceReflectionComponent.Uniforms._FinalReflectionTexture;
			int tempTexture = ScreenSpaceReflectionComponent.Uniforms._TempTexture;
			cb.GetTemporaryRT(normalAndRoughnessTexture, -1, -1, 0, FilterMode.Point, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
			cb.GetTemporaryRT(hitPointTexture, num2, num3, 0, FilterMode.Bilinear, RenderTextureFormat.ARGBHalf, RenderTextureReadWrite.Linear);
			for (int i = 0; i < 5; i++)
			{
				cb.GetTemporaryRT(this.m_ReflectionTextures[i], num2 >> i, num3 >> i, 0, FilterMode.Bilinear, format);
			}
			cb.GetTemporaryRT(filteredReflections, num2, num3, 0, this.k_BilateralUpsample ? FilterMode.Point : FilterMode.Bilinear, format);
			cb.GetTemporaryRT(finalReflectionTexture, num2, num3, 0, FilterMode.Point, format);
			cb.Blit(BuiltinRenderTextureType.CameraTarget, normalAndRoughnessTexture, material, 6);
			cb.Blit(BuiltinRenderTextureType.CameraTarget, hitPointTexture, material, 0);
			cb.Blit(BuiltinRenderTextureType.CameraTarget, filteredReflections, material, 5);
			cb.Blit(filteredReflections, this.m_ReflectionTextures[0], material, 8);
			for (int j = 1; j < 5; j++)
			{
				int nameID = this.m_ReflectionTextures[j - 1];
				int num8 = j;
				cb.GetTemporaryRT(blurTexture, num2 >> num8, num3 >> num8, 0, FilterMode.Bilinear, format);
				cb.SetGlobalVector(ScreenSpaceReflectionComponent.Uniforms._Axis, new Vector4(1f, 0f, 0f, 0f));
				cb.SetGlobalFloat(ScreenSpaceReflectionComponent.Uniforms._CurrentMipLevel, (float)j - 1f);
				cb.Blit(nameID, blurTexture, material, 2);
				cb.SetGlobalVector(ScreenSpaceReflectionComponent.Uniforms._Axis, new Vector4(0f, 1f, 0f, 0f));
				nameID = this.m_ReflectionTextures[j];
				cb.Blit(blurTexture, nameID, material, 2);
				cb.ReleaseTemporaryRT(blurTexture);
			}
			cb.Blit(this.m_ReflectionTextures[0], finalReflectionTexture, material, 3);
			cb.GetTemporaryRT(tempTexture, camera.pixelWidth, camera.pixelHeight, 0, FilterMode.Bilinear, format);
			cb.Blit(BuiltinRenderTextureType.CameraTarget, tempTexture, material, 1);
			cb.Blit(tempTexture, BuiltinRenderTextureType.CameraTarget);
			cb.ReleaseTemporaryRT(tempTexture);
		}

		// Token: 0x04004AC8 RID: 19144
		private bool k_HighlightSuppression;

		// Token: 0x04004AC9 RID: 19145
		private bool k_TraceBehindObjects = true;

		// Token: 0x04004ACA RID: 19146
		private bool k_TreatBackfaceHitAsMiss;

		// Token: 0x04004ACB RID: 19147
		private bool k_BilateralUpsample = true;

		// Token: 0x04004ACC RID: 19148
		private readonly int[] m_ReflectionTextures = new int[5];

		// Token: 0x020006A4 RID: 1700
		private static class Uniforms
		{
			// Token: 0x0400508F RID: 20623
			internal static readonly int _RayStepSize = Shader.PropertyToID("_RayStepSize");

			// Token: 0x04005090 RID: 20624
			internal static readonly int _AdditiveReflection = Shader.PropertyToID("_AdditiveReflection");

			// Token: 0x04005091 RID: 20625
			internal static readonly int _BilateralUpsampling = Shader.PropertyToID("_BilateralUpsampling");

			// Token: 0x04005092 RID: 20626
			internal static readonly int _TreatBackfaceHitAsMiss = Shader.PropertyToID("_TreatBackfaceHitAsMiss");

			// Token: 0x04005093 RID: 20627
			internal static readonly int _AllowBackwardsRays = Shader.PropertyToID("_AllowBackwardsRays");

			// Token: 0x04005094 RID: 20628
			internal static readonly int _TraceBehindObjects = Shader.PropertyToID("_TraceBehindObjects");

			// Token: 0x04005095 RID: 20629
			internal static readonly int _MaxSteps = Shader.PropertyToID("_MaxSteps");

			// Token: 0x04005096 RID: 20630
			internal static readonly int _FullResolutionFiltering = Shader.PropertyToID("_FullResolutionFiltering");

			// Token: 0x04005097 RID: 20631
			internal static readonly int _HalfResolution = Shader.PropertyToID("_HalfResolution");

			// Token: 0x04005098 RID: 20632
			internal static readonly int _HighlightSuppression = Shader.PropertyToID("_HighlightSuppression");

			// Token: 0x04005099 RID: 20633
			internal static readonly int _PixelsPerMeterAtOneMeter = Shader.PropertyToID("_PixelsPerMeterAtOneMeter");

			// Token: 0x0400509A RID: 20634
			internal static readonly int _ScreenEdgeFading = Shader.PropertyToID("_ScreenEdgeFading");

			// Token: 0x0400509B RID: 20635
			internal static readonly int _ReflectionBlur = Shader.PropertyToID("_ReflectionBlur");

			// Token: 0x0400509C RID: 20636
			internal static readonly int _MaxRayTraceDistance = Shader.PropertyToID("_MaxRayTraceDistance");

			// Token: 0x0400509D RID: 20637
			internal static readonly int _FadeDistance = Shader.PropertyToID("_FadeDistance");

			// Token: 0x0400509E RID: 20638
			internal static readonly int _LayerThickness = Shader.PropertyToID("_LayerThickness");

			// Token: 0x0400509F RID: 20639
			internal static readonly int _SSRMultiplier = Shader.PropertyToID("_SSRMultiplier");

			// Token: 0x040050A0 RID: 20640
			internal static readonly int _FresnelFade = Shader.PropertyToID("_FresnelFade");

			// Token: 0x040050A1 RID: 20641
			internal static readonly int _FresnelFadePower = Shader.PropertyToID("_FresnelFadePower");

			// Token: 0x040050A2 RID: 20642
			internal static readonly int _ReflectionBufferSize = Shader.PropertyToID("_ReflectionBufferSize");

			// Token: 0x040050A3 RID: 20643
			internal static readonly int _ScreenSize = Shader.PropertyToID("_ScreenSize");

			// Token: 0x040050A4 RID: 20644
			internal static readonly int _InvScreenSize = Shader.PropertyToID("_InvScreenSize");

			// Token: 0x040050A5 RID: 20645
			internal static readonly int _ProjInfo = Shader.PropertyToID("_ProjInfo");

			// Token: 0x040050A6 RID: 20646
			internal static readonly int _CameraClipInfo = Shader.PropertyToID("_CameraClipInfo");

			// Token: 0x040050A7 RID: 20647
			internal static readonly int _ProjectToPixelMatrix = Shader.PropertyToID("_ProjectToPixelMatrix");

			// Token: 0x040050A8 RID: 20648
			internal static readonly int _WorldToCameraMatrix = Shader.PropertyToID("_WorldToCameraMatrix");

			// Token: 0x040050A9 RID: 20649
			internal static readonly int _CameraToWorldMatrix = Shader.PropertyToID("_CameraToWorldMatrix");

			// Token: 0x040050AA RID: 20650
			internal static readonly int _Axis = Shader.PropertyToID("_Axis");

			// Token: 0x040050AB RID: 20651
			internal static readonly int _CurrentMipLevel = Shader.PropertyToID("_CurrentMipLevel");

			// Token: 0x040050AC RID: 20652
			internal static readonly int _NormalAndRoughnessTexture = Shader.PropertyToID("_NormalAndRoughnessTexture");

			// Token: 0x040050AD RID: 20653
			internal static readonly int _HitPointTexture = Shader.PropertyToID("_HitPointTexture");

			// Token: 0x040050AE RID: 20654
			internal static readonly int _BlurTexture = Shader.PropertyToID("_BlurTexture");

			// Token: 0x040050AF RID: 20655
			internal static readonly int _FilteredReflections = Shader.PropertyToID("_FilteredReflections");

			// Token: 0x040050B0 RID: 20656
			internal static readonly int _FinalReflectionTexture = Shader.PropertyToID("_FinalReflectionTexture");

			// Token: 0x040050B1 RID: 20657
			internal static readonly int _TempTexture = Shader.PropertyToID("_TempTexture");
		}

		// Token: 0x020006A5 RID: 1701
		private enum PassIndex
		{
			// Token: 0x040050B3 RID: 20659
			RayTraceStep,
			// Token: 0x040050B4 RID: 20660
			CompositeFinal,
			// Token: 0x040050B5 RID: 20661
			Blur,
			// Token: 0x040050B6 RID: 20662
			CompositeSSR,
			// Token: 0x040050B7 RID: 20663
			MinMipGeneration,
			// Token: 0x040050B8 RID: 20664
			HitPointToReflections,
			// Token: 0x040050B9 RID: 20665
			BilateralKeyPack,
			// Token: 0x040050BA RID: 20666
			BlitDepthAsCSZ,
			// Token: 0x040050BB RID: 20667
			PoissonBlur
		}
	}
}
