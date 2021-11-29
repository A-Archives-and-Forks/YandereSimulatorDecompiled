﻿using System;
using UnityEngine;

// Token: 0x020001F0 RID: 496
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Night Vision/Night Vision 2")]
public class CameraFilterPack_Oculus_NightVision2 : MonoBehaviour
{
	// Token: 0x170002F5 RID: 757
	// (get) Token: 0x06001080 RID: 4224 RVA: 0x00083966 File Offset: 0x00081B66
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

	// Token: 0x06001081 RID: 4225 RVA: 0x0008399A File Offset: 0x00081B9A
	private void ChangeFilters()
	{
		this.Matrix9 = new float[]
		{
			200f,
			-200f,
			-200f,
			195f,
			4f,
			-160f,
			200f,
			-200f,
			-200f,
			-200f,
			10f,
			-200f
		};
	}

	// Token: 0x06001082 RID: 4226 RVA: 0x000839B4 File Offset: 0x00081BB4
	private void Start()
	{
		this.ChangeFilters();
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001083 RID: 4227 RVA: 0x000839DC File Offset: 0x00081BDC
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
			this.material.SetFloat("_Red_R", this.Matrix9[0] / 100f);
			this.material.SetFloat("_Red_G", this.Matrix9[1] / 100f);
			this.material.SetFloat("_Red_B", this.Matrix9[2] / 100f);
			this.material.SetFloat("_Green_R", this.Matrix9[3] / 100f);
			this.material.SetFloat("_Green_G", this.Matrix9[4] / 100f);
			this.material.SetFloat("_Green_B", this.Matrix9[5] / 100f);
			this.material.SetFloat("_Blue_R", this.Matrix9[6] / 100f);
			this.material.SetFloat("_Blue_G", this.Matrix9[7] / 100f);
			this.material.SetFloat("_Blue_B", this.Matrix9[8] / 100f);
			this.material.SetFloat("_Red_C", this.Matrix9[9] / 100f);
			this.material.SetFloat("_Green_C", this.Matrix9[10] / 100f);
			this.material.SetFloat("_Blue_C", this.Matrix9[11] / 100f);
			this.material.SetFloat("_FadeFX", this.FadeFX);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001084 RID: 4228 RVA: 0x00083BFD File Offset: 0x00081DFD
	private void OnValidate()
	{
		this.ChangeFilters();
	}

	// Token: 0x06001085 RID: 4229 RVA: 0x00083C05 File Offset: 0x00081E05
	private void Update()
	{
	}

	// Token: 0x06001086 RID: 4230 RVA: 0x00083C07 File Offset: 0x00081E07
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001503 RID: 5379
	private string ShaderName = "CameraFilterPack/Oculus_NightVision2";

	// Token: 0x04001504 RID: 5380
	public Shader SCShader;

	// Token: 0x04001505 RID: 5381
	[Range(0f, 1f)]
	public float FadeFX = 1f;

	// Token: 0x04001506 RID: 5382
	private float TimeX = 1f;

	// Token: 0x04001507 RID: 5383
	private Material SCMaterial;

	// Token: 0x04001508 RID: 5384
	private float[] Matrix9;
}
