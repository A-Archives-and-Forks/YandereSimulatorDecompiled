﻿using System;
using UnityEngine;

// Token: 0x02000232 RID: 562
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Warp2")]
public class CameraFilterPack_Vision_Warp2 : MonoBehaviour
{
	// Token: 0x17000336 RID: 822
	// (get) Token: 0x0600120E RID: 4622 RVA: 0x0008A80B File Offset: 0x00088A0B
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

	// Token: 0x0600120F RID: 4623 RVA: 0x0008A83F File Offset: 0x00088A3F
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Warp2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001210 RID: 4624 RVA: 0x0008A860 File Offset: 0x00088A60
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
			this.material.SetFloat("_Value", this.Value);
			this.material.SetFloat("_Value2", this.Value2);
			this.material.SetFloat("_Value3", this.Intensity);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001211 RID: 4625 RVA: 0x0008A958 File Offset: 0x00088B58
	private void Update()
	{
	}

	// Token: 0x06001212 RID: 4626 RVA: 0x0008A95A File Offset: 0x00088B5A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040016B4 RID: 5812
	public Shader SCShader;

	// Token: 0x040016B5 RID: 5813
	private float TimeX = 1f;

	// Token: 0x040016B6 RID: 5814
	private Material SCMaterial;

	// Token: 0x040016B7 RID: 5815
	[Range(0f, 1f)]
	public float Value = 0.5f;

	// Token: 0x040016B8 RID: 5816
	[Range(0f, 1f)]
	public float Value2 = 0.2f;

	// Token: 0x040016B9 RID: 5817
	[Range(-1f, 2f)]
	public float Intensity = 1f;

	// Token: 0x040016BA RID: 5818
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
