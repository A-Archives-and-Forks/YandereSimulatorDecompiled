﻿using System;
using UnityEngine;

// Token: 0x02000150 RID: 336
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Radial")]
public class CameraFilterPack_Blur_Radial : MonoBehaviour
{
	// Token: 0x17000254 RID: 596
	// (get) Token: 0x06000C9F RID: 3231 RVA: 0x00072E69 File Offset: 0x00071069
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

	// Token: 0x06000CA0 RID: 3232 RVA: 0x00072E9D File Offset: 0x0007109D
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Radial");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CA1 RID: 3233 RVA: 0x00072EC0 File Offset: 0x000710C0
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
			this.material.SetFloat("_Value", this.Intensity);
			this.material.SetFloat("_Value2", this.MovX);
			this.material.SetFloat("_Value3", this.MovY);
			this.material.SetFloat("_Value4", this.blurWidth);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000CA2 RID: 3234 RVA: 0x00072FB8 File Offset: 0x000711B8
	private void Update()
	{
	}

	// Token: 0x06000CA3 RID: 3235 RVA: 0x00072FBA File Offset: 0x000711BA
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010F3 RID: 4339
	public Shader SCShader;

	// Token: 0x040010F4 RID: 4340
	private float TimeX = 1f;

	// Token: 0x040010F5 RID: 4341
	private Material SCMaterial;

	// Token: 0x040010F6 RID: 4342
	[Range(-0.5f, 0.5f)]
	public float Intensity = 0.125f;

	// Token: 0x040010F7 RID: 4343
	[Range(-2f, 2f)]
	public float MovX = 0.5f;

	// Token: 0x040010F8 RID: 4344
	[Range(-2f, 2f)]
	public float MovY = 0.5f;

	// Token: 0x040010F9 RID: 4345
	[Range(0f, 10f)]
	private float blurWidth = 1f;
}
