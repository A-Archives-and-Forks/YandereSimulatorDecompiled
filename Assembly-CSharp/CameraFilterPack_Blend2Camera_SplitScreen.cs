﻿using System;
using UnityEngine;

// Token: 0x02000142 RID: 322
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Split Screen/SideBySide")]
public class CameraFilterPack_Blend2Camera_SplitScreen : MonoBehaviour
{
	// Token: 0x17000246 RID: 582
	// (get) Token: 0x06000C40 RID: 3136 RVA: 0x00070C1F File Offset: 0x0006EE1F
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

	// Token: 0x06000C41 RID: 3137 RVA: 0x00070C53 File Offset: 0x0006EE53
	private void OnValidate()
	{
		this.ScreenSize.x = (float)Screen.width;
		this.ScreenSize.y = (float)Screen.height;
	}

	// Token: 0x06000C42 RID: 3138 RVA: 0x00070C78 File Offset: 0x0006EE78
	private void Start()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture((int)this.ScreenSize.x, (int)this.ScreenSize.y, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C43 RID: 3139 RVA: 0x00070CEC File Offset: 0x0006EEEC
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			if (this.Camera2 != null)
			{
				this.material.SetTexture("_MainTex2", this.Camera2tex);
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_Value", this.BlendFX);
			this.material.SetFloat("_Value2", this.SwitchCameraToCamera2);
			this.material.SetFloat("_Value3", this.SplitX);
			this.material.SetFloat("_Value6", this.SplitY);
			this.material.SetFloat("_Value4", this.Smooth);
			this.material.SetFloat("_Value5", this.Rotation);
			this.material.SetInt("_ForceYSwap", this.ForceYSwap ? 0 : 1);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000C44 RID: 3140 RVA: 0x00070E23 File Offset: 0x0006F023
	private void Update()
	{
		this.ScreenSize.x = (float)Screen.width;
		this.ScreenSize.y = (float)Screen.height;
	}

	// Token: 0x06000C45 RID: 3141 RVA: 0x00070E47 File Offset: 0x0006F047
	private void OnEnable()
	{
		this.Start();
	}

	// Token: 0x06000C46 RID: 3142 RVA: 0x00070E4F File Offset: 0x0006F04F
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

	// Token: 0x04001076 RID: 4214
	private string ShaderName = "CameraFilterPack/Blend2Camera_SplitScreen";

	// Token: 0x04001077 RID: 4215
	public Shader SCShader;

	// Token: 0x04001078 RID: 4216
	public Camera Camera2;

	// Token: 0x04001079 RID: 4217
	private float TimeX = 1f;

	// Token: 0x0400107A RID: 4218
	private Material SCMaterial;

	// Token: 0x0400107B RID: 4219
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x0400107C RID: 4220
	[Range(0f, 1f)]
	public float BlendFX = 1f;

	// Token: 0x0400107D RID: 4221
	[Range(-3f, 3f)]
	public float SplitX = 0.5f;

	// Token: 0x0400107E RID: 4222
	[Range(-3f, 3f)]
	public float SplitY = 0.5f;

	// Token: 0x0400107F RID: 4223
	[Range(0f, 2f)]
	public float Smooth = 0.1f;

	// Token: 0x04001080 RID: 4224
	[Range(-3.14f, 3.14f)]
	public float Rotation = 3.14f;

	// Token: 0x04001081 RID: 4225
	private bool ForceYSwap;

	// Token: 0x04001082 RID: 4226
	private RenderTexture Camera2tex;

	// Token: 0x04001083 RID: 4227
	private Vector2 ScreenSize;
}
