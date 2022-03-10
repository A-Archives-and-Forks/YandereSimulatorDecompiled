﻿using System;
using UnityEngine;

// Token: 0x020001C4 RID: 452
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Film/Grain")]
public class CameraFilterPack_Film_Grain : MonoBehaviour
{
	// Token: 0x170002C8 RID: 712
	// (get) Token: 0x06000F58 RID: 3928 RVA: 0x0007DCC3 File Offset: 0x0007BEC3
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

	// Token: 0x06000F59 RID: 3929 RVA: 0x0007DCF7 File Offset: 0x0007BEF7
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Film_Grain");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F5A RID: 3930 RVA: 0x0007DD18 File Offset: 0x0007BF18
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
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F5B RID: 3931 RVA: 0x0007DDCE File Offset: 0x0007BFCE
	private void Update()
	{
	}

	// Token: 0x06000F5C RID: 3932 RVA: 0x0007DDD0 File Offset: 0x0007BFD0
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040013A0 RID: 5024
	public Shader SCShader;

	// Token: 0x040013A1 RID: 5025
	private float TimeX = 1f;

	// Token: 0x040013A2 RID: 5026
	private Material SCMaterial;

	// Token: 0x040013A3 RID: 5027
	[Range(-64f, 64f)]
	public float Value = 32f;
}
