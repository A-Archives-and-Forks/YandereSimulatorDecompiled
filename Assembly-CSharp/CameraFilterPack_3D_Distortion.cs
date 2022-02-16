﻿using System;
using UnityEngine;

// Token: 0x0200010D RID: 269
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/3D/Distortion")]
public class CameraFilterPack_3D_Distortion : MonoBehaviour
{
	// Token: 0x17000211 RID: 529
	// (get) Token: 0x06000ACC RID: 2764 RVA: 0x00068C44 File Offset: 0x00066E44
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

	// Token: 0x06000ACD RID: 2765 RVA: 0x00068C78 File Offset: 0x00066E78
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/3D_Distortion");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000ACE RID: 2766 RVA: 0x00068C9C File Offset: 0x00066E9C
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
			if (this.AutoAnimatedNear)
			{
				this._Distance += Time.deltaTime * this.AutoAnimatedNearSpeed;
				if (this._Distance > 1f)
				{
					this._Distance = -1f;
				}
				if (this._Distance < -1f)
				{
					this._Distance = 1f;
				}
				this.material.SetFloat("_Near", this._Distance);
			}
			else
			{
				this.material.SetFloat("_Near", this._Distance);
			}
			this.material.SetFloat("_Far", this._Size);
			this.material.SetFloat("_FixDistance", this._FixDistance);
			this.material.SetFloat("_DistortionLevel", this.DistortionLevel * 28f);
			this.material.SetFloat("_DistortionSize", this.DistortionSize * 16f);
			this.material.SetFloat("_LightIntensity", this.LightIntensity * 64f);
			this.material.SetFloat("_Visualize", (float)(this._Visualize ? 1 : 0));
			float farClipPlane = base.GetComponent<Camera>().farClipPlane;
			this.material.SetFloat("_FarCamera", 1000f / farClipPlane);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			base.GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000ACF RID: 2767 RVA: 0x00068E87 File Offset: 0x00067087
	private void Update()
	{
	}

	// Token: 0x06000AD0 RID: 2768 RVA: 0x00068E89 File Offset: 0x00067089
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000E60 RID: 3680
	public Shader SCShader;

	// Token: 0x04000E61 RID: 3681
	private float TimeX = 1f;

	// Token: 0x04000E62 RID: 3682
	public bool _Visualize;

	// Token: 0x04000E63 RID: 3683
	private Material SCMaterial;

	// Token: 0x04000E64 RID: 3684
	[Range(0f, 100f)]
	public float _FixDistance = 1f;

	// Token: 0x04000E65 RID: 3685
	[Range(-0.99f, 0.99f)]
	public float _Distance = 0.5f;

	// Token: 0x04000E66 RID: 3686
	[Range(0f, 0.5f)]
	public float _Size = 0.1f;

	// Token: 0x04000E67 RID: 3687
	[Range(0f, 10f)]
	public float DistortionLevel = 1.2f;

	// Token: 0x04000E68 RID: 3688
	[Range(0.1f, 10f)]
	public float DistortionSize = 1.4f;

	// Token: 0x04000E69 RID: 3689
	[Range(-2f, 4f)]
	public float LightIntensity = 0.08f;

	// Token: 0x04000E6A RID: 3690
	public bool AutoAnimatedNear;

	// Token: 0x04000E6B RID: 3691
	[Range(-5f, 5f)]
	public float AutoAnimatedNearSpeed = 0.5f;

	// Token: 0x04000E6C RID: 3692
	public static Color ChangeColorRGB;
}
