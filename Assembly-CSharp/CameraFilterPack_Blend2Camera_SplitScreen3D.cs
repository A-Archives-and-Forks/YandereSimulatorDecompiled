﻿using System;
using UnityEngine;

// Token: 0x02000142 RID: 322
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Split Screen/Split 3D")]
public class CameraFilterPack_Blend2Camera_SplitScreen3D : MonoBehaviour
{
	// Token: 0x17000247 RID: 583
	// (get) Token: 0x06000C45 RID: 3141 RVA: 0x00070CEC File Offset: 0x0006EEEC
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

	// Token: 0x06000C46 RID: 3142 RVA: 0x00070D20 File Offset: 0x0006EF20
	private void OnValidate()
	{
		this.ScreenSize.x = (float)Screen.width;
		this.ScreenSize.y = (float)Screen.height;
	}

	// Token: 0x06000C47 RID: 3143 RVA: 0x00070D44 File Offset: 0x0006EF44
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

	// Token: 0x06000C48 RID: 3144 RVA: 0x00070DB8 File Offset: 0x0006EFB8
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
			this.material.SetFloat("_Near", this._Distance);
			this.material.SetFloat("_Far", this._Size);
			this.material.SetFloat("_FixDistance", this._FixDistance);
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_Value", this.BlendFX);
			this.material.SetFloat("_Value2", this.SwitchCameraToCamera2);
			this.material.SetFloat("_Value3", this.SplitX);
			this.material.SetFloat("_Value6", this.SplitY);
			this.material.SetFloat("_Value4", this.Smooth);
			this.material.SetFloat("_Value5", this.Rotation);
			this.material.SetInt("_ForceYSwap", this.ForceYSwap ? 0 : 1);
			base.GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000C49 RID: 3145 RVA: 0x00070F3D File Offset: 0x0006F13D
	private void Update()
	{
		this.ScreenSize.x = (float)Screen.width;
		this.ScreenSize.y = (float)Screen.height;
	}

	// Token: 0x06000C4A RID: 3146 RVA: 0x00070F61 File Offset: 0x0006F161
	private void OnEnable()
	{
		this.Start();
	}

	// Token: 0x06000C4B RID: 3147 RVA: 0x00070F69 File Offset: 0x0006F169
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

	// Token: 0x0400107F RID: 4223
	private string ShaderName = "CameraFilterPack/Blend2Camera_SplitScreen3D";

	// Token: 0x04001080 RID: 4224
	public Shader SCShader;

	// Token: 0x04001081 RID: 4225
	public Camera Camera2;

	// Token: 0x04001082 RID: 4226
	private float TimeX = 1f;

	// Token: 0x04001083 RID: 4227
	private Material SCMaterial;

	// Token: 0x04001084 RID: 4228
	[Range(0f, 100f)]
	public float _FixDistance = 1f;

	// Token: 0x04001085 RID: 4229
	[Range(-0.99f, 0.99f)]
	public float _Distance = 0.5f;

	// Token: 0x04001086 RID: 4230
	[Range(0f, 0.5f)]
	public float _Size = 0.1f;

	// Token: 0x04001087 RID: 4231
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04001088 RID: 4232
	[Range(0f, 1f)]
	public float BlendFX = 1f;

	// Token: 0x04001089 RID: 4233
	[Range(-3f, 3f)]
	public float SplitX = 0.5f;

	// Token: 0x0400108A RID: 4234
	[Range(-3f, 3f)]
	public float SplitY = 0.5f;

	// Token: 0x0400108B RID: 4235
	[Range(0f, 2f)]
	public float Smooth = 0.1f;

	// Token: 0x0400108C RID: 4236
	[Range(-3.14f, 3.14f)]
	public float Rotation = 3.14f;

	// Token: 0x0400108D RID: 4237
	private bool ForceYSwap;

	// Token: 0x0400108E RID: 4238
	private RenderTexture Camera2tex;

	// Token: 0x0400108F RID: 4239
	private Vector2 ScreenSize;
}
