﻿using System;
using UnityEngine;

// Token: 0x020001D6 RID: 470
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Stripe")]
public class CameraFilterPack_Gradients_Stripe : MonoBehaviour
{
	// Token: 0x170002DA RID: 730
	// (get) Token: 0x06000FC4 RID: 4036 RVA: 0x0007FFB4 File Offset: 0x0007E1B4
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

	// Token: 0x06000FC5 RID: 4037 RVA: 0x0007FFE8 File Offset: 0x0007E1E8
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FC6 RID: 4038 RVA: 0x0008000C File Offset: 0x0007E20C
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
			this.material.SetFloat("_Value", this.Switch);
			this.material.SetFloat("_Value2", this.Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000FC7 RID: 4039 RVA: 0x000800D8 File Offset: 0x0007E2D8
	private void Update()
	{
	}

	// Token: 0x06000FC8 RID: 4040 RVA: 0x000800DA File Offset: 0x0007E2DA
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001439 RID: 5177
	public Shader SCShader;

	// Token: 0x0400143A RID: 5178
	private string ShaderName = "CameraFilterPack/Gradients_Stripe";

	// Token: 0x0400143B RID: 5179
	private float TimeX = 1f;

	// Token: 0x0400143C RID: 5180
	private Material SCMaterial;

	// Token: 0x0400143D RID: 5181
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x0400143E RID: 5182
	[Range(0f, 1f)]
	public float Fade = 1f;
}
