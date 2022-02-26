﻿using System;
using UnityEngine;

// Token: 0x0200014B RID: 331
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Dithering2x2")]
public class CameraFilterPack_Blur_Dithering2x2 : MonoBehaviour
{
	// Token: 0x1700024F RID: 591
	// (get) Token: 0x06000C7F RID: 3199 RVA: 0x00072129 File Offset: 0x00070329
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

	// Token: 0x06000C80 RID: 3200 RVA: 0x0007215D File Offset: 0x0007035D
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Dithering2x2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C81 RID: 3201 RVA: 0x00072180 File Offset: 0x00070380
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
			this.material.SetFloat("_Level", (float)this.Level);
			this.material.SetVector("_Distance", this.Distance);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000C82 RID: 3202 RVA: 0x00072252 File Offset: 0x00070452
	private void Update()
	{
	}

	// Token: 0x06000C83 RID: 3203 RVA: 0x00072254 File Offset: 0x00070454
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010C8 RID: 4296
	public Shader SCShader;

	// Token: 0x040010C9 RID: 4297
	private float TimeX = 1f;

	// Token: 0x040010CA RID: 4298
	private Material SCMaterial;

	// Token: 0x040010CB RID: 4299
	[Range(2f, 16f)]
	public int Level = 4;

	// Token: 0x040010CC RID: 4300
	public Vector2 Distance = new Vector2(30f, 0f);
}
