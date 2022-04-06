﻿using System;
using UnityEngine;

// Token: 0x020001DC RID: 476
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Light/Water2")]
public class CameraFilterPack_Light_Water2 : MonoBehaviour
{
	// Token: 0x170002E0 RID: 736
	// (get) Token: 0x06000FEA RID: 4074 RVA: 0x00080E00 File Offset: 0x0007F000
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

	// Token: 0x06000FEB RID: 4075 RVA: 0x00080E34 File Offset: 0x0007F034
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Light_Water2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FEC RID: 4076 RVA: 0x00080E58 File Offset: 0x0007F058
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
			this.material.SetFloat("_Value", this.Speed);
			this.material.SetFloat("_Value2", this.Speed_X);
			this.material.SetFloat("_Value3", this.Speed_Y);
			this.material.SetFloat("_Value4", this.Intensity);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000FED RID: 4077 RVA: 0x00080F50 File Offset: 0x0007F150
	private void Update()
	{
	}

	// Token: 0x06000FEE RID: 4078 RVA: 0x00080F52 File Offset: 0x0007F152
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400146A RID: 5226
	public Shader SCShader;

	// Token: 0x0400146B RID: 5227
	private float TimeX = 1f;

	// Token: 0x0400146C RID: 5228
	private Material SCMaterial;

	// Token: 0x0400146D RID: 5229
	[Range(0f, 10f)]
	public float Speed = 0.2f;

	// Token: 0x0400146E RID: 5230
	[Range(0f, 10f)]
	public float Speed_X = 0.2f;

	// Token: 0x0400146F RID: 5231
	[Range(0f, 1f)]
	public float Speed_Y = 0.3f;

	// Token: 0x04001470 RID: 5232
	[Range(0f, 10f)]
	public float Intensity = 2.4f;
}
