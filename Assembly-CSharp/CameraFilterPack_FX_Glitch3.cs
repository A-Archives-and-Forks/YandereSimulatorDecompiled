﻿using System;
using UnityEngine;

// Token: 0x020001B5 RID: 437
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/Glitch3")]
public class CameraFilterPack_FX_Glitch3 : MonoBehaviour
{
	// Token: 0x170002B9 RID: 697
	// (get) Token: 0x06000EFD RID: 3837 RVA: 0x0007C4C0 File Offset: 0x0007A6C0
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

	// Token: 0x06000EFE RID: 3838 RVA: 0x0007C4F4 File Offset: 0x0007A6F4
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Glitch3");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EFF RID: 3839 RVA: 0x0007C518 File Offset: 0x0007A718
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
			this.material.SetFloat("_Glitch", this._Glitch);
			this.material.SetFloat("_Noise", this._Noise);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F00 RID: 3840 RVA: 0x0007C5E4 File Offset: 0x0007A7E4
	private void Update()
	{
	}

	// Token: 0x06000F01 RID: 3841 RVA: 0x0007C5E6 File Offset: 0x0007A7E6
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400134C RID: 4940
	public Shader SCShader;

	// Token: 0x0400134D RID: 4941
	private float TimeX = 1f;

	// Token: 0x0400134E RID: 4942
	private Material SCMaterial;

	// Token: 0x0400134F RID: 4943
	[Range(0f, 1f)]
	public float _Glitch = 1f;

	// Token: 0x04001350 RID: 4944
	[Range(0f, 1f)]
	public float _Noise = 1f;
}
