﻿using System;
using UnityEngine;

// Token: 0x020001A3 RID: 419
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Edge/Sigmoid")]
public class CameraFilterPack_Edge_Sigmoid : MonoBehaviour
{
	// Token: 0x170002A8 RID: 680
	// (get) Token: 0x06000E94 RID: 3732 RVA: 0x0007A8FD File Offset: 0x00078AFD
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

	// Token: 0x06000E95 RID: 3733 RVA: 0x0007A931 File Offset: 0x00078B31
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Edge_Sigmoid");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E96 RID: 3734 RVA: 0x0007A954 File Offset: 0x00078B54
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
			this.material.SetFloat("_Gain", this.Gain);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E97 RID: 3735 RVA: 0x0007AA03 File Offset: 0x00078C03
	private void Update()
	{
	}

	// Token: 0x06000E98 RID: 3736 RVA: 0x0007AA05 File Offset: 0x00078C05
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012DF RID: 4831
	public Shader SCShader;

	// Token: 0x040012E0 RID: 4832
	private float TimeX = 1f;

	// Token: 0x040012E1 RID: 4833
	private Material SCMaterial;

	// Token: 0x040012E2 RID: 4834
	[Range(1f, 10f)]
	public float Gain = 3f;
}
