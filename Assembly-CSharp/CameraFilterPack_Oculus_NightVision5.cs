﻿using System;
using UnityEngine;

// Token: 0x020001F3 RID: 499
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Night Vision/Night Vision 5")]
public class CameraFilterPack_Oculus_NightVision5 : MonoBehaviour
{
	// Token: 0x170002F7 RID: 759
	// (get) Token: 0x06001092 RID: 4242 RVA: 0x000841E5 File Offset: 0x000823E5
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

	// Token: 0x06001093 RID: 4243 RVA: 0x00084219 File Offset: 0x00082419
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

	// Token: 0x06001094 RID: 4244 RVA: 0x00084233 File Offset: 0x00082433
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

	// Token: 0x06001095 RID: 4245 RVA: 0x0008425C File Offset: 0x0008245C
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
			this.material.SetFloat("_Size", this._Size);
			this.material.SetFloat("_Dist", this._Dist);
			this.material.SetFloat("_Smooth", this._Smooth);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001096 RID: 4246 RVA: 0x000844BF File Offset: 0x000826BF
	private void OnValidate()
	{
		this.ChangeFilters();
	}

	// Token: 0x06001097 RID: 4247 RVA: 0x000844C7 File Offset: 0x000826C7
	private void Update()
	{
	}

	// Token: 0x06001098 RID: 4248 RVA: 0x000844C9 File Offset: 0x000826C9
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001515 RID: 5397
	private string ShaderName = "CameraFilterPack/Oculus_NightVision5";

	// Token: 0x04001516 RID: 5398
	public Shader SCShader;

	// Token: 0x04001517 RID: 5399
	[Range(0f, 1f)]
	public float FadeFX = 1f;

	// Token: 0x04001518 RID: 5400
	[Range(0f, 1f)]
	public float _Size = 0.37f;

	// Token: 0x04001519 RID: 5401
	[Range(0f, 1f)]
	public float _Smooth = 0.15f;

	// Token: 0x0400151A RID: 5402
	[Range(0f, 1f)]
	public float _Dist = 0.285f;

	// Token: 0x0400151B RID: 5403
	private float TimeX = 1f;

	// Token: 0x0400151C RID: 5404
	private Material SCMaterial;

	// Token: 0x0400151D RID: 5405
	private float[] Matrix9;
}
