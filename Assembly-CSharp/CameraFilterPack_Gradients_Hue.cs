﻿using System;
using UnityEngine;

// Token: 0x020001D3 RID: 467
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Hue")]
public class CameraFilterPack_Gradients_Hue : MonoBehaviour
{
	// Token: 0x170002D7 RID: 727
	// (get) Token: 0x06000FB2 RID: 4018 RVA: 0x0007FCA0 File Offset: 0x0007DEA0
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

	// Token: 0x06000FB3 RID: 4019 RVA: 0x0007FCD4 File Offset: 0x0007DED4
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FB4 RID: 4020 RVA: 0x0007FCF8 File Offset: 0x0007DEF8
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
			this.material.SetFloat("_Value", this.Switch);
			this.material.SetFloat("_Value2", this.Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000FB5 RID: 4021 RVA: 0x0007FDC4 File Offset: 0x0007DFC4
	private void Update()
	{
	}

	// Token: 0x06000FB6 RID: 4022 RVA: 0x0007FDC6 File Offset: 0x0007DFC6
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001430 RID: 5168
	public Shader SCShader;

	// Token: 0x04001431 RID: 5169
	private string ShaderName = "CameraFilterPack/Gradients_Hue";

	// Token: 0x04001432 RID: 5170
	private float TimeX = 1f;

	// Token: 0x04001433 RID: 5171
	private Material SCMaterial;

	// Token: 0x04001434 RID: 5172
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x04001435 RID: 5173
	[Range(0f, 1f)]
	public float Fade = 1f;
}
