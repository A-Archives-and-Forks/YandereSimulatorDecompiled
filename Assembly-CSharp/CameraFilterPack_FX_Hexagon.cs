﻿using System;
using UnityEngine;

// Token: 0x020001B7 RID: 439
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Hexagon")]
public class CameraFilterPack_FX_Hexagon : MonoBehaviour
{
	// Token: 0x170002BB RID: 699
	// (get) Token: 0x06000F0A RID: 3850 RVA: 0x0007C9A4 File Offset: 0x0007ABA4
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

	// Token: 0x06000F0B RID: 3851 RVA: 0x0007C9D8 File Offset: 0x0007ABD8
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Hexagon");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F0C RID: 3852 RVA: 0x0007C9FC File Offset: 0x0007ABFC
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
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F0D RID: 3853 RVA: 0x0007CA99 File Offset: 0x0007AC99
	private void Update()
	{
	}

	// Token: 0x06000F0E RID: 3854 RVA: 0x0007CA9B File Offset: 0x0007AC9B
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001359 RID: 4953
	public Shader SCShader;

	// Token: 0x0400135A RID: 4954
	private float TimeX = 1f;

	// Token: 0x0400135B RID: 4955
	private Material SCMaterial;
}
