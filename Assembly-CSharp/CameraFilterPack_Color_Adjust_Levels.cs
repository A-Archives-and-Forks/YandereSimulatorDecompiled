﻿using System;
using UnityEngine;

// Token: 0x0200015B RID: 347
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Levels")]
public class CameraFilterPack_Color_Adjust_Levels : MonoBehaviour
{
	// Token: 0x1700025F RID: 607
	// (get) Token: 0x06000CDE RID: 3294 RVA: 0x00073A8F File Offset: 0x00071C8F
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

	// Token: 0x06000CDF RID: 3295 RVA: 0x00073AC3 File Offset: 0x00071CC3
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Levels");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CE0 RID: 3296 RVA: 0x00073AE4 File Offset: 0x00071CE4
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("levelMinimum", this.levelMinimum);
			this.material.SetFloat("levelMiddle", this.levelMiddle);
			this.material.SetFloat("levelMaximum", this.levelMaximum);
			this.material.SetFloat("minOutput", this.minOutput);
			this.material.SetFloat("maxOutput", this.maxOutput);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000CE1 RID: 3297 RVA: 0x00073BDC File Offset: 0x00071DDC
	private void Update()
	{
	}

	// Token: 0x06000CE2 RID: 3298 RVA: 0x00073BDE File Offset: 0x00071DDE
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400112F RID: 4399
	public Shader SCShader;

	// Token: 0x04001130 RID: 4400
	private float TimeX = 1f;

	// Token: 0x04001131 RID: 4401
	private Material SCMaterial;

	// Token: 0x04001132 RID: 4402
	[Range(0f, 1f)]
	public float levelMinimum;

	// Token: 0x04001133 RID: 4403
	[Range(0f, 1f)]
	public float levelMiddle = 0.5f;

	// Token: 0x04001134 RID: 4404
	[Range(0f, 1f)]
	public float levelMaximum = 1f;

	// Token: 0x04001135 RID: 4405
	[Range(0f, 1f)]
	public float minOutput;

	// Token: 0x04001136 RID: 4406
	[Range(0f, 1f)]
	public float maxOutput = 1f;
}
