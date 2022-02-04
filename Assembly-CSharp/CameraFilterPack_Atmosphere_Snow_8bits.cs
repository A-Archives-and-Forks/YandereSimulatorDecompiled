﻿using System;
using UnityEngine;

// Token: 0x02000125 RID: 293
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Pixel/Snow_8bits")]
public class CameraFilterPack_Atmosphere_Snow_8bits : MonoBehaviour
{
	// Token: 0x17000229 RID: 553
	// (get) Token: 0x06000B5B RID: 2907 RVA: 0x0006C5B5 File Offset: 0x0006A7B5
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

	// Token: 0x06000B5C RID: 2908 RVA: 0x0006C5E9 File Offset: 0x0006A7E9
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Atmosphere_Snow_8bits");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B5D RID: 2909 RVA: 0x0006C60C File Offset: 0x0006A80C
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
			this.material.SetFloat("_Value", this.Threshold);
			this.material.SetFloat("_Value2", this.Size);
			this.material.SetFloat("_Value3", this.DirectionX);
			this.material.SetFloat("_Value4", this.Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000B5E RID: 2910 RVA: 0x0006C704 File Offset: 0x0006A904
	private void Update()
	{
	}

	// Token: 0x06000B5F RID: 2911 RVA: 0x0006C706 File Offset: 0x0006A906
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F7B RID: 3963
	public Shader SCShader;

	// Token: 0x04000F7C RID: 3964
	private float TimeX = 1f;

	// Token: 0x04000F7D RID: 3965
	private Material SCMaterial;

	// Token: 0x04000F7E RID: 3966
	[Range(0.9f, 2f)]
	public float Threshold = 1f;

	// Token: 0x04000F7F RID: 3967
	[Range(8f, 256f)]
	public float Size = 64f;

	// Token: 0x04000F80 RID: 3968
	[Range(-0.5f, 0.5f)]
	public float DirectionX;

	// Token: 0x04000F81 RID: 3969
	[Range(0f, 1f)]
	public float Fade = 1f;
}
