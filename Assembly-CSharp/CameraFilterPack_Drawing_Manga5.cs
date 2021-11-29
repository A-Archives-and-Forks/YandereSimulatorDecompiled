﻿using System;
using UnityEngine;

// Token: 0x02000193 RID: 403
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Manga5")]
public class CameraFilterPack_Drawing_Manga5 : MonoBehaviour
{
	// Token: 0x17000298 RID: 664
	// (get) Token: 0x06000E33 RID: 3635 RVA: 0x00078EB8 File Offset: 0x000770B8
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

	// Token: 0x06000E34 RID: 3636 RVA: 0x00078EEC File Offset: 0x000770EC
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Manga5");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E35 RID: 3637 RVA: 0x00078F10 File Offset: 0x00077110
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
			this.material.SetFloat("_DotSize", this.DotSize);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E36 RID: 3638 RVA: 0x00078F96 File Offset: 0x00077196
	private void Update()
	{
	}

	// Token: 0x06000E37 RID: 3639 RVA: 0x00078F98 File Offset: 0x00077198
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400126C RID: 4716
	public Shader SCShader;

	// Token: 0x0400126D RID: 4717
	private float TimeX = 1f;

	// Token: 0x0400126E RID: 4718
	private Material SCMaterial;

	// Token: 0x0400126F RID: 4719
	[Range(1f, 8f)]
	public float DotSize = 4.72f;
}
