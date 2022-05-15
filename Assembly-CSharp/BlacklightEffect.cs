﻿using System;
using UnityEngine;

// Token: 0x020004F8 RID: 1272
[ExecuteInEditMode]
public class BlacklightEffect : MonoBehaviour
{
	// Token: 0x0600212D RID: 8493 RVA: 0x001ECE24 File Offset: 0x001EB024
	private void Update()
	{
		if (this.camera != null)
		{
			this.camera.depthTextureMode = (DepthTextureMode.Depth | DepthTextureMode.DepthNormals);
		}
		if (this.post != null)
		{
			this.post.SetFloat("_DepthDistance", this.fogDepth);
			this.post.SetColor("_FogColorDark", this.fogColorDark);
			this.post.SetColor("_FogColorLight", this.fogColorLight);
			this.post.SetFloat("_FogOpacity", this.fogOpacity);
			this.post.SetFloat("_GlowBias", this.glowBias);
			this.post.SetColor("_GlowColor", this.glowColor);
			this.post.SetColor("_GlowColor2", this.glowColorSecondary);
			this.post.SetFloat("_GlowAmount", (float)(this.glow ? 1 : 0));
			this.post.SetColor("_EdgeColor", this.edgeColor);
			this.post.SetFloat("_EdgeThreshold", this.threshold);
			this.post.SetFloat("_EdgeStrength", this.edgeOpacity);
			this.post.SetColor("_OverlayTop", this.overlayTop);
			this.post.SetColor("_OverlayBottom", this.overlayBottom);
			this.post.SetFloat("_OverlayOpacity", this.overlayOpacity);
			this.post.SetFloat("_HighlightFlip", this.glowFlip);
			this.post.SetFloat("_HighlightTargetSmooth", this.smoothDropoff);
			if (this.highlightTargets != null)
			{
				for (int i = 0; i < this.highlightTargets.Length; i++)
				{
					this.hTargets[i] = this.highlightTargets[i].TargetColor;
					this.hThresholds[i] = this.highlightTargets[i].Threshold;
					this.hColors[i] = this.highlightTargets[i].ReplacementColor;
					this.hColorInterpolations[i] = this.highlightTargets[i].SmoothColorInterpolation;
				}
			}
			if (this.highlightTargets != null && this.highlightTargets.Length != 0)
			{
				this.post.SetInt("_HighlightTargetsLength", Mathf.Clamp(this.highlightTargets.Length, 0, 100));
			}
			this.post.SetColorArray("_HighlightTargets", this.hTargets);
			this.post.SetFloatArray("_HighlightTargetThresholds", this.hThresholds);
			this.post.SetColorArray("_HighlightColors", this.hColors);
			this.post.SetFloatArray("_SmoothColorInterpolations", this.hColorInterpolations);
		}
	}

	// Token: 0x0600212E RID: 8494 RVA: 0x001ED0D4 File Offset: 0x001EB2D4
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (this.camera == null)
		{
			this.camera = base.GetComponent<Camera>();
			return;
		}
		if (this.post == null)
		{
			this.post = new Material(Shader.Find("Abcight/BlacklightPost"));
		}
		Graphics.Blit(source, destination, this.post);
	}

	// Token: 0x0600212F RID: 8495 RVA: 0x001ED12C File Offset: 0x001EB32C
	[ContextMenu("Refresh")]
	public void Refresh()
	{
		UnityEngine.Object.DestroyImmediate(this.post);
		this.post = null;
	}

	// Token: 0x04004975 RID: 18805
	[SerializeField]
	private Color fogColorDark = new Color32(14, 11, 31, byte.MaxValue);

	// Token: 0x04004976 RID: 18806
	[SerializeField]
	private Color fogColorLight = new Color32(87, 89, 111, byte.MaxValue);

	// Token: 0x04004977 RID: 18807
	[SerializeField]
	[Range(0f, 1f)]
	private float fogOpacity = 1f;

	// Token: 0x04004978 RID: 18808
	[SerializeField]
	private float fogDepth = 8f;

	// Token: 0x04004979 RID: 18809
	[Space(5f)]
	[Header("Glow")]
	[SerializeField]
	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	private Color glowColor = new Color(0f, 0.48235294f, 0.7490196f) * 9f;

	// Token: 0x0400497A RID: 18810
	[SerializeField]
	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	private Color glowColorSecondary = new Color(0.7490196f, 0f, 0.6784314f) * 9f;

	// Token: 0x0400497B RID: 18811
	[SerializeField]
	private float glowBias = 13f;

	// Token: 0x0400497C RID: 18812
	[SerializeField]
	[Range(0f, 1f)]
	private float glowFlip;

	// Token: 0x0400497D RID: 18813
	[SerializeField]
	private bool glow = true;

	// Token: 0x0400497E RID: 18814
	[Space(5f)]
	[Header("Targetted highlighting")]
	[SerializeField]
	private HighlightTarget[] highlightTargets;

	// Token: 0x0400497F RID: 18815
	[SerializeField]
	[Range(0f, 1f)]
	private float smoothDropoff;

	// Token: 0x04004980 RID: 18816
	[Space(5f)]
	[Header("Edge")]
	[SerializeField]
	private Color edgeColor = new Color32(7, byte.MaxValue, 83, byte.MaxValue);

	// Token: 0x04004981 RID: 18817
	[SerializeField]
	[Range(0.01f, 1f)]
	private float threshold = 0.45f;

	// Token: 0x04004982 RID: 18818
	[SerializeField]
	[Range(0f, 1f)]
	private float edgeOpacity = 1f;

	// Token: 0x04004983 RID: 18819
	[Space(5f)]
	[Header("Overlay")]
	[SerializeField]
	private Color overlayTop = new Color32(233, 0, byte.MaxValue, byte.MaxValue);

	// Token: 0x04004984 RID: 18820
	[SerializeField]
	private Color overlayBottom = new Color32(0, 38, byte.MaxValue, byte.MaxValue);

	// Token: 0x04004985 RID: 18821
	[SerializeField]
	[Range(0f, 1f)]
	private float overlayOpacity = 0.06f;

	// Token: 0x04004986 RID: 18822
	private Color[] hTargets = new Color[100];

	// Token: 0x04004987 RID: 18823
	private float[] hThresholds = new float[100];

	// Token: 0x04004988 RID: 18824
	private Color[] hColors = new Color[100];

	// Token: 0x04004989 RID: 18825
	private float[] hColorInterpolations = new float[100];

	// Token: 0x0400498A RID: 18826
	private Camera camera;

	// Token: 0x0400498B RID: 18827
	private Material post;
}
