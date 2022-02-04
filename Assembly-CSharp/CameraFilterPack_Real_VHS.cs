﻿using System;
using UnityEngine;

// Token: 0x020001FE RID: 510
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/VHS/Real VHS HQ")]
public class CameraFilterPack_Real_VHS : MonoBehaviour
{
	// Token: 0x17000302 RID: 770
	// (get) Token: 0x060010D5 RID: 4309 RVA: 0x00085465 File Offset: 0x00083665
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

	// Token: 0x060010D6 RID: 4310 RVA: 0x0008549C File Offset: 0x0008369C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Real_VHS");
		this.VHS = (Resources.Load("CameraFilterPack_VHS1") as Texture2D);
		this.VHS2 = (Resources.Load("CameraFilterPack_VHS2") as Texture2D);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060010D7 RID: 4311 RVA: 0x000854F2 File Offset: 0x000836F2
	public static Texture2D GetRTPixels(Texture2D t, RenderTexture rt, int sx, int sy)
	{
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = rt;
		t.ReadPixels(new Rect(0f, 0f, (float)t.width, (float)t.height), 0, 0);
		RenderTexture.active = active;
		return t;
	}

	// Token: 0x060010D8 RID: 4312 RVA: 0x0008552C File Offset: 0x0008372C
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.material.SetTexture("VHS", this.VHS);
			this.material.SetTexture("VHS2", this.VHS2);
			this.material.SetFloat("TRACKING", this.TRACKING);
			this.material.SetFloat("JITTER", this.JITTER);
			this.material.SetFloat("GLITCH", this.GLITCH);
			this.material.SetFloat("NOISE", this.NOISE);
			this.material.SetFloat("Brightness", this.Brightness);
			this.material.SetFloat("CONTRAST", 1f - this.Constrast);
			int width = 382;
			int height = 576;
			RenderTexture temporary = RenderTexture.GetTemporary(width, height, 0);
			temporary.filterMode = FilterMode.Trilinear;
			Graphics.Blit(sourceTexture, temporary, this.material);
			Graphics.Blit(temporary, destTexture);
			RenderTexture.ReleaseTemporary(temporary);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060010D9 RID: 4313 RVA: 0x0008563C File Offset: 0x0008383C
	private void Update()
	{
	}

	// Token: 0x060010DA RID: 4314 RVA: 0x0008563E File Offset: 0x0008383E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001562 RID: 5474
	public Shader SCShader;

	// Token: 0x04001563 RID: 5475
	private Material SCMaterial;

	// Token: 0x04001564 RID: 5476
	private Texture2D VHS;

	// Token: 0x04001565 RID: 5477
	private Texture2D VHS2;

	// Token: 0x04001566 RID: 5478
	[Range(0f, 1f)]
	public float TRACKING = 0.212f;

	// Token: 0x04001567 RID: 5479
	[Range(0f, 1f)]
	public float JITTER = 1f;

	// Token: 0x04001568 RID: 5480
	[Range(0f, 1f)]
	public float GLITCH = 1f;

	// Token: 0x04001569 RID: 5481
	[Range(0f, 1f)]
	public float NOISE = 1f;

	// Token: 0x0400156A RID: 5482
	[Range(-1f, 1f)]
	public float Brightness;

	// Token: 0x0400156B RID: 5483
	[Range(0f, 1.5f)]
	public float Constrast = 1f;
}
