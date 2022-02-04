﻿using System;
using UnityEngine;

// Token: 0x0200018F RID: 399
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Lines")]
public class CameraFilterPack_Drawing_Lines : MonoBehaviour
{
	// Token: 0x17000293 RID: 659
	// (get) Token: 0x06000E18 RID: 3608 RVA: 0x00078AAA File Offset: 0x00076CAA
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

	// Token: 0x06000E19 RID: 3609 RVA: 0x00078ADE File Offset: 0x00076CDE
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Lines");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E1A RID: 3610 RVA: 0x00078B00 File Offset: 0x00076D00
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
			this.material.SetFloat("_Value", this.Number);
			this.material.SetFloat("_Value2", this.Random);
			this.material.SetFloat("_Value3", this.PositionY);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E1B RID: 3611 RVA: 0x00078BF8 File Offset: 0x00076DF8
	private void Update()
	{
	}

	// Token: 0x06000E1C RID: 3612 RVA: 0x00078BFA File Offset: 0x00076DFA
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400125A RID: 4698
	public Shader SCShader;

	// Token: 0x0400125B RID: 4699
	private float TimeX = 1f;

	// Token: 0x0400125C RID: 4700
	private Material SCMaterial;

	// Token: 0x0400125D RID: 4701
	[Range(0.1f, 10f)]
	public float Number = 1f;

	// Token: 0x0400125E RID: 4702
	[Range(0f, 1f)]
	public float Random = 0.5f;

	// Token: 0x0400125F RID: 4703
	[Range(0f, 10f)]
	private float PositionY = 1f;

	// Token: 0x04001260 RID: 4704
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
