﻿using System;
using UnityEngine;

// Token: 0x0200017B RID: 379
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Flush")]
public class CameraFilterPack_Distortion_Flush : MonoBehaviour
{
	// Token: 0x1700027F RID: 639
	// (get) Token: 0x06000DA3 RID: 3491 RVA: 0x00077525 File Offset: 0x00075725
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

	// Token: 0x06000DA4 RID: 3492 RVA: 0x00077559 File Offset: 0x00075759
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Flush");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DA5 RID: 3493 RVA: 0x0007757C File Offset: 0x0007577C
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
			this.material.SetFloat("Value", this.Value);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000DA6 RID: 3494 RVA: 0x00077632 File Offset: 0x00075832
	private void Update()
	{
	}

	// Token: 0x06000DA7 RID: 3495 RVA: 0x00077634 File Offset: 0x00075834
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011F6 RID: 4598
	public Shader SCShader;

	// Token: 0x040011F7 RID: 4599
	private float TimeX = 1f;

	// Token: 0x040011F8 RID: 4600
	private Material SCMaterial;

	// Token: 0x040011F9 RID: 4601
	[Range(-10f, 50f)]
	public float Value = 5f;
}
