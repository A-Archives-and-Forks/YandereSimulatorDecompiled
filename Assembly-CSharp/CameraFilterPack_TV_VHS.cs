﻿using System;
using UnityEngine;

// Token: 0x02000219 RID: 537
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/VHS/VHS")]
public class CameraFilterPack_TV_VHS : MonoBehaviour
{
	// Token: 0x1700031D RID: 797
	// (get) Token: 0x06001178 RID: 4472 RVA: 0x00087F09 File Offset: 0x00086109
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

	// Token: 0x06001179 RID: 4473 RVA: 0x00087F3D File Offset: 0x0008613D
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_VHS");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600117A RID: 4474 RVA: 0x00087F60 File Offset: 0x00086160
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
			this.material.SetFloat("_Value", this.Cryptage);
			this.material.SetFloat("_Value2", this.Parasite);
			this.material.SetFloat("_Value3", this.Calibrage);
			this.material.SetFloat("_Value4", this.WhiteParasite);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600117B RID: 4475 RVA: 0x00088058 File Offset: 0x00086258
	private void Update()
	{
	}

	// Token: 0x0600117C RID: 4476 RVA: 0x0008805A File Offset: 0x0008625A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001607 RID: 5639
	public Shader SCShader;

	// Token: 0x04001608 RID: 5640
	private float TimeX = 1f;

	// Token: 0x04001609 RID: 5641
	private Material SCMaterial;

	// Token: 0x0400160A RID: 5642
	[Range(1f, 256f)]
	public float Cryptage = 64f;

	// Token: 0x0400160B RID: 5643
	[Range(1f, 100f)]
	public float Parasite = 32f;

	// Token: 0x0400160C RID: 5644
	[Range(0f, 3f)]
	public float Calibrage;

	// Token: 0x0400160D RID: 5645
	[Range(0f, 1f)]
	public float WhiteParasite = 1f;
}
