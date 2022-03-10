﻿using System;
using UnityEngine;

// Token: 0x0200018D RID: 397
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Halftone")]
public class CameraFilterPack_Drawing_Halftone : MonoBehaviour
{
	// Token: 0x17000291 RID: 657
	// (get) Token: 0x06000E0D RID: 3597 RVA: 0x00078BF5 File Offset: 0x00076DF5
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

	// Token: 0x06000E0E RID: 3598 RVA: 0x00078C29 File Offset: 0x00076E29
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Halftone");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E0F RID: 3599 RVA: 0x00078C4C File Offset: 0x00076E4C
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
			this.material.SetFloat("_Distortion", this.Threshold);
			this.material.SetFloat("_DotSize", this.DotSize);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E10 RID: 3600 RVA: 0x00078CE8 File Offset: 0x00076EE8
	private void Update()
	{
	}

	// Token: 0x06000E11 RID: 3601 RVA: 0x00078CEA File Offset: 0x00076EEA
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400125E RID: 4702
	public Shader SCShader;

	// Token: 0x0400125F RID: 4703
	private float TimeX = 1f;

	// Token: 0x04001260 RID: 4704
	private Material SCMaterial;

	// Token: 0x04001261 RID: 4705
	[Range(0f, 1f)]
	public float Threshold = 0.6f;

	// Token: 0x04001262 RID: 4706
	[Range(1f, 16f)]
	public float DotSize = 4f;
}
