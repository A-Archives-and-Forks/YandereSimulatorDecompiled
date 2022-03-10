﻿using System;
using UnityEngine;

// Token: 0x020001CA RID: 458
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glasses/Futuristic Montain")]
public class CameraFilterPack_Glasses_On_5 : MonoBehaviour
{
	// Token: 0x170002CE RID: 718
	// (get) Token: 0x06000F7C RID: 3964 RVA: 0x0007EA81 File Offset: 0x0007CC81
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

	// Token: 0x06000F7D RID: 3965 RVA: 0x0007EAB5 File Offset: 0x0007CCB5
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_Glasses_On6") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/Glasses_On");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F7E RID: 3966 RVA: 0x0007EAEC File Offset: 0x0007CCEC
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

	// Token: 0x06000F7F RID: 3967 RVA: 0x0007EC51 File Offset: 0x0007CE51
	private void Update()
	{
	}

	// Token: 0x06000F80 RID: 3968 RVA: 0x0007EC53 File Offset: 0x0007CE53
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040013E4 RID: 5092
	public Shader SCShader;

	// Token: 0x040013E5 RID: 5093
	private float TimeX = 1f;

	// Token: 0x040013E6 RID: 5094
	[Range(0f, 1f)]
	public float Fade = 0.2f;

	// Token: 0x040013E7 RID: 5095
	[Range(0f, 0.1f)]
	public float VisionBlur = 0.005f;

	// Token: 0x040013E8 RID: 5096
	public Color GlassesColor = new Color(0.1f, 0.1f, 0.1f, 1f);

	// Token: 0x040013E9 RID: 5097
	public Color GlassesColor2 = new Color(0.45f, 0.45f, 0.45f, 0.25f);

	// Token: 0x040013EA RID: 5098
	[Range(0f, 1f)]
	public float GlassDistortion = 0.6f;

	// Token: 0x040013EB RID: 5099
	[Range(0f, 1f)]
	public float GlassAberration = 0.3f;

	// Token: 0x040013EC RID: 5100
	[Range(0f, 1f)]
	public float UseFinalGlassColor;

	// Token: 0x040013ED RID: 5101
	[Range(0f, 1f)]
	public float UseScanLine = 0.4f;

	// Token: 0x040013EE RID: 5102
	[Range(1f, 512f)]
	public float UseScanLineSize = 358f;

	// Token: 0x040013EF RID: 5103
	public Color GlassColor = new Color(0.1f, 0.3f, 1f, 1f);

	// Token: 0x040013F0 RID: 5104
	private Material SCMaterial;

	// Token: 0x040013F1 RID: 5105
	private Texture2D Texture2;
}
