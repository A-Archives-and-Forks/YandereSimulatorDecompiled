﻿using System;
using UnityEngine;

// Token: 0x02000125 RID: 293
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Blend")]
public class CameraFilterPack_Blend2Camera_Blend : MonoBehaviour
{
	// Token: 0x1700022A RID: 554
	// (get) Token: 0x06000B5E RID: 2910 RVA: 0x0006C55C File Offset: 0x0006A75C
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

	// Token: 0x06000B5F RID: 2911 RVA: 0x0006C590 File Offset: 0x0006A790
	private void Start()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B60 RID: 2912 RVA: 0x0006C5F4 File Offset: 0x0006A7F4
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetTexture("_MainTex2", this.Camera2tex);
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_Value", this.BlendFX);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000B61 RID: 2913 RVA: 0x0006C6C0 File Offset: 0x0006A8C0
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B62 RID: 2914 RVA: 0x0006C6F8 File Offset: 0x0006A8F8
	private void Update()
	{
	}

	// Token: 0x06000B63 RID: 2915 RVA: 0x0006C6FA File Offset: 0x0006A8FA
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B64 RID: 2916 RVA: 0x0006C732 File Offset: 0x0006A932
	private void OnDisable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2.targetTexture = null;
		}
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F7D RID: 3965
	private string ShaderName = "CameraFilterPack/Blend2Camera_Blend";

	// Token: 0x04000F7E RID: 3966
	public Shader SCShader;

	// Token: 0x04000F7F RID: 3967
	public Camera Camera2;

	// Token: 0x04000F80 RID: 3968
	private float TimeX = 1f;

	// Token: 0x04000F81 RID: 3969
	private Material SCMaterial;

	// Token: 0x04000F82 RID: 3970
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000F83 RID: 3971
	private RenderTexture Camera2tex;
}
