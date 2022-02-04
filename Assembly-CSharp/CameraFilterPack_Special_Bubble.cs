﻿using System;
using UnityEngine;

// Token: 0x02000201 RID: 513
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Special/Bubble")]
public class CameraFilterPack_Special_Bubble : MonoBehaviour
{
	// Token: 0x17000305 RID: 773
	// (get) Token: 0x060010E8 RID: 4328 RVA: 0x00085945 File Offset: 0x00083B45
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

	// Token: 0x060010E9 RID: 4329 RVA: 0x00085979 File Offset: 0x00083B79
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Special_Bubble");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010EA RID: 4330 RVA: 0x0008599C File Offset: 0x00083B9C
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
			this.material.SetFloat("_Value", this.X);
			this.material.SetFloat("_Value2", this.Y);
			this.material.SetFloat("_Value3", this.Rate);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060010EB RID: 4331 RVA: 0x00085A94 File Offset: 0x00083C94
	private void Update()
	{
	}

	// Token: 0x060010EC RID: 4332 RVA: 0x00085A96 File Offset: 0x00083C96
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001575 RID: 5493
	public Shader SCShader;

	// Token: 0x04001576 RID: 5494
	private float TimeX = 1f;

	// Token: 0x04001577 RID: 5495
	private Material SCMaterial;

	// Token: 0x04001578 RID: 5496
	[Range(-4f, 4f)]
	public float X = 0.5f;

	// Token: 0x04001579 RID: 5497
	[Range(-4f, 4f)]
	public float Y = 0.5f;

	// Token: 0x0400157A RID: 5498
	[Range(0f, 5f)]
	public float Rate = 1f;

	// Token: 0x0400157B RID: 5499
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
