﻿using System;
using UnityEngine;

// Token: 0x020001B6 RID: 438
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Grid")]
public class CameraFilterPack_FX_Grid : MonoBehaviour
{
	// Token: 0x170002BA RID: 698
	// (get) Token: 0x06000F03 RID: 3843 RVA: 0x0007C629 File Offset: 0x0007A829
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

	// Token: 0x06000F04 RID: 3844 RVA: 0x0007C65D File Offset: 0x0007A85D
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Grid");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F05 RID: 3845 RVA: 0x0007C680 File Offset: 0x0007A880
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
			this.material.SetFloat("_Distortion", this.Distortion);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F06 RID: 3846 RVA: 0x0007C706 File Offset: 0x0007A906
	private void Update()
	{
	}

	// Token: 0x06000F07 RID: 3847 RVA: 0x0007C708 File Offset: 0x0007A908
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001351 RID: 4945
	public Shader SCShader;

	// Token: 0x04001352 RID: 4946
	private float TimeX = 1f;

	// Token: 0x04001353 RID: 4947
	private Material SCMaterial;

	// Token: 0x04001354 RID: 4948
	[Range(0f, 5f)]
	public float Distortion = 1f;

	// Token: 0x04001355 RID: 4949
	public static float ChangeDistortion;
}
