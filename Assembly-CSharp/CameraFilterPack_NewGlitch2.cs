﻿using System;
using UnityEngine;

// Token: 0x020001E5 RID: 485
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/NewGlitch2")]
public class CameraFilterPack_NewGlitch2 : MonoBehaviour
{
	// Token: 0x170002E9 RID: 745
	// (get) Token: 0x06001039 RID: 4153 RVA: 0x00082345 File Offset: 0x00080545
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

	// Token: 0x0600103A RID: 4154 RVA: 0x00082379 File Offset: 0x00080579
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/CameraFilterPack_NewGlitch2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600103B RID: 4155 RVA: 0x0008239C File Offset: 0x0008059C
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
			this.material.SetFloat("_Speed", this.__Speed);
			this.material.SetFloat("RedFade", this._RedFade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600103C RID: 4156 RVA: 0x00082468 File Offset: 0x00080668
	private void Update()
	{
	}

	// Token: 0x0600103D RID: 4157 RVA: 0x0008246A File Offset: 0x0008066A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040014AA RID: 5290
	public Shader SCShader;

	// Token: 0x040014AB RID: 5291
	private float TimeX = 1f;

	// Token: 0x040014AC RID: 5292
	private Material SCMaterial;

	// Token: 0x040014AD RID: 5293
	[Range(0f, 1f)]
	public float __Speed = 1f;

	// Token: 0x040014AE RID: 5294
	[Range(0f, 1f)]
	public float _RedFade = 1f;
}
