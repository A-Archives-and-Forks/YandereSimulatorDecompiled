﻿using System;
using UnityEngine;

// Token: 0x0200011F RID: 287
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Alien/Vision")]
public class CameraFilterPack_Alien_Vision : MonoBehaviour
{
	// Token: 0x17000223 RID: 547
	// (get) Token: 0x06000B38 RID: 2872 RVA: 0x0006BC30 File Offset: 0x00069E30
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

	// Token: 0x06000B39 RID: 2873 RVA: 0x0006BC64 File Offset: 0x00069E64
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Alien_Vision");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B3A RID: 2874 RVA: 0x0006BC88 File Offset: 0x00069E88
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
			this.material.SetFloat("_Value", this.Therma_Variation);
			this.material.SetFloat("_Value2", this.Speed);
			this.material.SetFloat("_Value3", this.Burn);
			this.material.SetFloat("_Value4", this.SceneCut);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000B3B RID: 2875 RVA: 0x0006BD80 File Offset: 0x00069F80
	private void Update()
	{
	}

	// Token: 0x06000B3C RID: 2876 RVA: 0x0006BD82 File Offset: 0x00069F82
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F48 RID: 3912
	public Shader SCShader;

	// Token: 0x04000F49 RID: 3913
	private float TimeX = 1f;

	// Token: 0x04000F4A RID: 3914
	private Material SCMaterial;

	// Token: 0x04000F4B RID: 3915
	[Range(0f, 0.5f)]
	public float Therma_Variation = 0.5f;

	// Token: 0x04000F4C RID: 3916
	[Range(0f, 1f)]
	public float Speed = 0.5f;

	// Token: 0x04000F4D RID: 3917
	[Range(0f, 4f)]
	private float Burn;

	// Token: 0x04000F4E RID: 3918
	[Range(0f, 16f)]
	private float SceneCut = 1f;
}
