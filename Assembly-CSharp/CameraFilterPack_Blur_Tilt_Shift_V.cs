﻿using System;
using UnityEngine;

// Token: 0x02000155 RID: 341
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Tilt_Shift_V")]
public class CameraFilterPack_Blur_Tilt_Shift_V : MonoBehaviour
{
	// Token: 0x1700025A RID: 602
	// (get) Token: 0x06000CBD RID: 3261 RVA: 0x00072F64 File Offset: 0x00071164
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

	// Token: 0x06000CBE RID: 3262 RVA: 0x00072F98 File Offset: 0x00071198
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/BlurTiltShift_V");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CBF RID: 3263 RVA: 0x00072FBC File Offset: 0x000711BC
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (!(this.SCShader != null))
		{
			Graphics.Blit(sourceTexture, destTexture);
			return;
		}
		int fastFilter = this.FastFilter;
		this.TimeX += Time.deltaTime;
		if (this.TimeX > 100f)
		{
			this.TimeX = 0f;
		}
		this.material.SetFloat("_TimeX", this.TimeX);
		this.material.SetFloat("_Amount", this.Amount);
		this.material.SetFloat("_Value1", this.Smooth);
		this.material.SetFloat("_Value2", this.Size);
		this.material.SetFloat("_Value3", this.Position);
		int width = sourceTexture.width / fastFilter;
		int height = sourceTexture.height / fastFilter;
		if (this.FastFilter > 1)
		{
			RenderTexture temporary = RenderTexture.GetTemporary(width, height, 0);
			RenderTexture temporary2 = RenderTexture.GetTemporary(width, height, 0);
			temporary.filterMode = FilterMode.Trilinear;
			Graphics.Blit(sourceTexture, temporary, this.material, 2);
			Graphics.Blit(temporary, temporary2, this.material, 0);
			this.material.SetFloat("_Amount", this.Amount * 2f);
			Graphics.Blit(temporary2, temporary, this.material, 2);
			Graphics.Blit(temporary, temporary2, this.material, 0);
			this.material.SetTexture("_MainTex2", temporary2);
			RenderTexture.ReleaseTemporary(temporary);
			RenderTexture.ReleaseTemporary(temporary2);
			Graphics.Blit(sourceTexture, destTexture, this.material, 1);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture, this.material, 0);
	}

	// Token: 0x06000CC0 RID: 3264 RVA: 0x0007314C File Offset: 0x0007134C
	private void Update()
	{
	}

	// Token: 0x06000CC1 RID: 3265 RVA: 0x0007314E File Offset: 0x0007134E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001104 RID: 4356
	public Shader SCShader;

	// Token: 0x04001105 RID: 4357
	private float TimeX = 1f;

	// Token: 0x04001106 RID: 4358
	private Material SCMaterial;

	// Token: 0x04001107 RID: 4359
	[Range(0f, 20f)]
	public float Amount = 3f;

	// Token: 0x04001108 RID: 4360
	[Range(2f, 16f)]
	public int FastFilter = 8;

	// Token: 0x04001109 RID: 4361
	[Range(0f, 1f)]
	public float Smooth = 0.5f;

	// Token: 0x0400110A RID: 4362
	[Range(0f, 1f)]
	public float Size = 0.5f;

	// Token: 0x0400110B RID: 4363
	[Range(-1f, 1f)]
	public float Position = 0.5f;
}
