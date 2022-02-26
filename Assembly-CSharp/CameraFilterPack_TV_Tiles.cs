﻿using System;
using UnityEngine;

// Token: 0x02000218 RID: 536
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/Tiles")]
public class CameraFilterPack_TV_Tiles : MonoBehaviour
{
	// Token: 0x1700031C RID: 796
	// (get) Token: 0x06001173 RID: 4467 RVA: 0x00087F94 File Offset: 0x00086194
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

	// Token: 0x06001174 RID: 4468 RVA: 0x00087FC8 File Offset: 0x000861C8
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Tiles");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001175 RID: 4469 RVA: 0x00087FEC File Offset: 0x000861EC
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
			this.material.SetFloat("_Value2", this.Intensity);
			this.material.SetFloat("_Value3", this.StretchX);
			this.material.SetFloat("_Value4", this.StretchY);
			this.material.SetFloat("Fade", this.Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001176 RID: 4470 RVA: 0x000880FA File Offset: 0x000862FA
	private void Update()
	{
	}

	// Token: 0x06001177 RID: 4471 RVA: 0x000880FC File Offset: 0x000862FC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001602 RID: 5634
	public Shader SCShader;

	// Token: 0x04001603 RID: 5635
	private float TimeX = 1f;

	// Token: 0x04001604 RID: 5636
	private Material SCMaterial;

	// Token: 0x04001605 RID: 5637
	[Range(0.5f, 2f)]
	public float Size = 1f;

	// Token: 0x04001606 RID: 5638
	[Range(0f, 10f)]
	public float Intensity = 4f;

	// Token: 0x04001607 RID: 5639
	[Range(0f, 1f)]
	public float StretchX = 0.6f;

	// Token: 0x04001608 RID: 5640
	[Range(0f, 1f)]
	public float StretchY = 0.4f;

	// Token: 0x04001609 RID: 5641
	[Range(0f, 1f)]
	public float Fade = 0.6f;
}
