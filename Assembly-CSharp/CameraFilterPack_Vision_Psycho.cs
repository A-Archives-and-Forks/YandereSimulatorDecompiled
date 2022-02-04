﻿using System;
using UnityEngine;

// Token: 0x0200022D RID: 557
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Psycho")]
public class CameraFilterPack_Vision_Psycho : MonoBehaviour
{
	// Token: 0x17000331 RID: 817
	// (get) Token: 0x060011F0 RID: 4592 RVA: 0x00089E63 File Offset: 0x00088063
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

	// Token: 0x060011F1 RID: 4593 RVA: 0x00089E97 File Offset: 0x00088097
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Psycho");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011F2 RID: 4594 RVA: 0x00089EB8 File Offset: 0x000880B8
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
			this.material.SetFloat("_Value", this.HoleSize);
			this.material.SetFloat("_Value2", this.HoleSmooth);
			this.material.SetFloat("_Value3", this.Color1);
			this.material.SetFloat("_Value4", this.Color2);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060011F3 RID: 4595 RVA: 0x00089FB0 File Offset: 0x000881B0
	private void Update()
	{
	}

	// Token: 0x060011F4 RID: 4596 RVA: 0x00089FB2 File Offset: 0x000881B2
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001688 RID: 5768
	public Shader SCShader;

	// Token: 0x04001689 RID: 5769
	private float TimeX = 1f;

	// Token: 0x0400168A RID: 5770
	private Material SCMaterial;

	// Token: 0x0400168B RID: 5771
	[Range(0.01f, 1f)]
	public float HoleSize = 0.6f;

	// Token: 0x0400168C RID: 5772
	[Range(-1f, 1f)]
	public float HoleSmooth = 0.3f;

	// Token: 0x0400168D RID: 5773
	[Range(-2f, 2f)]
	public float Color1 = 0.2f;

	// Token: 0x0400168E RID: 5774
	[Range(-2f, 2f)]
	public float Color2 = 0.9f;
}
