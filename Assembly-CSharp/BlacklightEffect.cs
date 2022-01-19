﻿using System;
using UnityEngine;

// Token: 0x020004EA RID: 1258
[ExecuteInEditMode]
public class BlacklightEffect : MonoBehaviour
{
	// Token: 0x060020C5 RID: 8389 RVA: 0x001E32F4 File Offset: 0x001E14F4
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

	// Token: 0x060020C6 RID: 8390 RVA: 0x001E35A4 File Offset: 0x001E17A4
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

	// Token: 0x060020C7 RID: 8391 RVA: 0x001E35FC File Offset: 0x001E17FC
	[ContextMenu("Refresh")]
	public void Refresh()
	{
		UnityEngine.Object.DestroyImmediate(this.post);
		this.post = null;
	}

	// Token: 0x04004848 RID: 18504
	[SerializeField]
	private Color fogColorDark = new Color32(14, 11, 31, byte.MaxValue);

	// Token: 0x04004849 RID: 18505
	[SerializeField]
	private Color fogColorLight = new Color32(87, 89, 111, byte.MaxValue);

	// Token: 0x0400484A RID: 18506
	[SerializeField]
	[Range(0f, 1f)]
	private float fogOpacity = 1f;

	// Token: 0x0400484B RID: 18507
	[SerializeField]
	private float fogDepth = 8f;

	// Token: 0x0400484C RID: 18508
	[Space(5f)]
	[Header("Glow")]
	[SerializeField]
	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	private Color glowColor = new Color(0f, 0.48235294f, 0.7490196f) * 9f;

	// Token: 0x0400484D RID: 18509
	[SerializeField]
	[ColorUsage(true, true, 0f, 3f, 0f, 3f)]
	private Color glowColorSecondary = new Color(0.7490196f, 0f, 0.6784314f) * 9f;

	// Token: 0x0400484E RID: 18510
	[SerializeField]
	private float glowBias = 13f;

	// Token: 0x0400484F RID: 18511
	[SerializeField]
	[Range(0f, 1f)]
	private float glowFlip;

	// Token: 0x04004850 RID: 18512
	[SerializeField]
	private bool glow = true;

	// Token: 0x04004851 RID: 18513
	[Space(5f)]
	[Header("Targetted highlighting")]
	[SerializeField]
	private HighlightTarget[] highlightTargets;

	// Token: 0x04004852 RID: 18514
	[SerializeField]
	[Range(0f, 1f)]
	private float smoothDropoff;

	// Token: 0x04004853 RID: 18515
	[Space(5f)]
	[Header("Edge")]
	[SerializeField]
	private Color edgeColor = new Color32(7, byte.MaxValue, 83, byte.MaxValue);

	// Token: 0x04004854 RID: 18516
	[SerializeField]
	[Range(0.01f, 1f)]
	private float threshold = 0.45f;

	// Token: 0x04004855 RID: 18517
	[SerializeField]
	[Range(0f, 1f)]
	private float edgeOpacity = 1f;

	// Token: 0x04004856 RID: 18518
	[Space(5f)]
	[Header("Overlay")]
	[SerializeField]
	private Color overlayTop = new Color32(233, 0, byte.MaxValue, byte.MaxValue);

	// Token: 0x04004857 RID: 18519
	[SerializeField]
	private Color overlayBottom = new Color32(0, 38, byte.MaxValue, byte.MaxValue);

	// Token: 0x04004858 RID: 18520
	[SerializeField]
	[Range(0f, 1f)]
	private float overlayOpacity = 0.06f;

	// Token: 0x04004859 RID: 18521
	private Color[] hTargets = new Color[100];

	// Token: 0x0400485A RID: 18522
	private float[] hThresholds = new float[100];

	// Token: 0x0400485B RID: 18523
	private Color[] hColors = new Color[100];

	// Token: 0x0400485C RID: 18524
	private float[] hColorInterpolations = new float[100];

	// Token: 0x0400485D RID: 18525
	private Camera camera;

	// Token: 0x0400485E RID: 18526
	private Material post;
}
