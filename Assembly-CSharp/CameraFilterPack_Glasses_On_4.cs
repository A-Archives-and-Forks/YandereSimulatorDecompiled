﻿using System;
using UnityEngine;

// Token: 0x020001C9 RID: 457
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glasses/Futuristic Desert")]
public class CameraFilterPack_Glasses_On_4 : MonoBehaviour
{
	// Token: 0x170002CD RID: 717
	// (get) Token: 0x06000F76 RID: 3958 RVA: 0x0007E7D5 File Offset: 0x0007C9D5
	private Material material
	{
		get
		{
			if (this.SCMaterial == null)
			{
				this.SCMaterial = new Material(this.SCShader);
				this.SCMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.SCMaterial;
		}
	}

	// Token: 0x06000F77 RID: 3959 RVA: 0x0007E809 File Offset: 0x0007CA09
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_Glasses_On5") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/Glasses_On");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F78 RID: 3960 RVA: 0x0007E840 File Offset: 0x0007CA40
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("UseFinalGlassColor", this.UseFinalGlassColor);
			this.material.SetFloat("Fade", this.Fade);
			this.material.SetFloat("VisionBlur", this.VisionBlur);
			this.material.SetFloat("GlassDistortion", this.GlassDistortion);
			this.material.SetFloat("GlassAberration", this.GlassAberration);
			this.material.SetColor("GlassesColor", this.GlassesColor);
			this.material.SetColor("GlassesColor2", this.GlassesColor2);
			this.material.SetColor("GlassColor", this.GlassColor);
			this.material.SetFloat("UseScanLineSize", this.UseScanLineSize);
			this.material.SetFloat("UseScanLine", this.UseScanLine);
			this.material.SetTexture("_MainTex2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F79 RID: 3961 RVA: 0x0007E9A5 File Offset: 0x0007CBA5
	private void Update()
	{
	}

	// Token: 0x06000F7A RID: 3962 RVA: 0x0007E9A7 File Offset: 0x0007CBA7
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040013D6 RID: 5078
	public Shader SCShader;

	// Token: 0x040013D7 RID: 5079
	private float TimeX = 1f;

	// Token: 0x040013D8 RID: 5080
	[Range(0f, 1f)]
	public float Fade = 0.2f;

	// Token: 0x040013D9 RID: 5081
	[Range(0f, 0.1f)]
	public float VisionBlur = 0.005f;

	// Token: 0x040013DA RID: 5082
	public Color GlassesColor = new Color(0f, 0f, 0f, 1f);

	// Token: 0x040013DB RID: 5083
	public Color GlassesColor2 = new Color(0.25f, 0.25f, 0.25f, 0.25f);

	// Token: 0x040013DC RID: 5084
	[Range(0f, 1f)]
	public float GlassDistortion = 0.6f;

	// Token: 0x040013DD RID: 5085
	[Range(0f, 1f)]
	public float GlassAberration = 0.3f;

	// Token: 0x040013DE RID: 5086
	[Range(0f, 1f)]
	public float UseFinalGlassColor;

	// Token: 0x040013DF RID: 5087
	[Range(0f, 1f)]
	public float UseScanLine = 0.4f;

	// Token: 0x040013E0 RID: 5088
	[Range(1f, 512f)]
	public float UseScanLineSize = 358f;

	// Token: 0x040013E1 RID: 5089
	public Color GlassColor = new Color(1f, 0.4f, 0f, 1f);

	// Token: 0x040013E2 RID: 5090
	private Material SCMaterial;

	// Token: 0x040013E3 RID: 5091
	private Texture2D Texture2;
}
