﻿using System;
using UnityEngine;

// Token: 0x0200016C RID: 364
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/DarkColor")]
public class CameraFilterPack_Colors_DarkColor : MonoBehaviour
{
	// Token: 0x17000270 RID: 624
	// (get) Token: 0x06000D46 RID: 3398 RVA: 0x0007581B File Offset: 0x00073A1B
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

	// Token: 0x06000D47 RID: 3399 RVA: 0x0007584F File Offset: 0x00073A4F
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_DarkColor");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D48 RID: 3400 RVA: 0x00075870 File Offset: 0x00073A70
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
			this.material.SetFloat("_Value", this.Alpha);
			this.material.SetFloat("_Value2", this.Colors);
			this.material.SetFloat("_Value3", this.Green_Mod);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D49 RID: 3401 RVA: 0x00075968 File Offset: 0x00073B68
	private void Update()
	{
	}

	// Token: 0x06000D4A RID: 3402 RVA: 0x0007596A File Offset: 0x00073B6A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400118D RID: 4493
	public Shader SCShader;

	// Token: 0x0400118E RID: 4494
	private float TimeX = 1f;

	// Token: 0x0400118F RID: 4495
	private Material SCMaterial;

	// Token: 0x04001190 RID: 4496
	[Range(-5f, 5f)]
	public float Alpha = 1f;

	// Token: 0x04001191 RID: 4497
	[Range(0f, 16f)]
	private float Colors = 11f;

	// Token: 0x04001192 RID: 4498
	[Range(-1f, 1f)]
	private float Green_Mod = 1f;

	// Token: 0x04001193 RID: 4499
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
