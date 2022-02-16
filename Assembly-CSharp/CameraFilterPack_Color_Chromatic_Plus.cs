﻿using System;
using UnityEngine;

// Token: 0x0200015E RID: 350
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Chromatic_Plus")]
public class CameraFilterPack_Color_Chromatic_Plus : MonoBehaviour
{
	// Token: 0x17000262 RID: 610
	// (get) Token: 0x06000CF1 RID: 3313 RVA: 0x0007404C File Offset: 0x0007224C
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

	// Token: 0x06000CF2 RID: 3314 RVA: 0x00074080 File Offset: 0x00072280
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Chromatic_Plus");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CF3 RID: 3315 RVA: 0x000740A4 File Offset: 0x000722A4
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
			this.material.SetFloat("_Value", this.Size);
			this.material.SetFloat("_Value2", this.Smooth);
			this.material.SetFloat("_Distortion", this.Offset);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000CF4 RID: 3316 RVA: 0x00074186 File Offset: 0x00072386
	private void Update()
	{
	}

	// Token: 0x06000CF5 RID: 3317 RVA: 0x00074188 File Offset: 0x00072388
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001144 RID: 4420
	public Shader SCShader;

	// Token: 0x04001145 RID: 4421
	private float TimeX = 1f;

	// Token: 0x04001146 RID: 4422
	private Material SCMaterial;

	// Token: 0x04001147 RID: 4423
	[Range(0f, 0.8f)]
	public float Size = 0.55f;

	// Token: 0x04001148 RID: 4424
	[Range(0.01f, 0.4f)]
	public float Smooth = 0.26f;

	// Token: 0x04001149 RID: 4425
	[Range(-0.02f, 0.02f)]
	public float Offset = 0.005f;
}
