﻿using System;
using UnityEngine;

// Token: 0x0200010A RID: 266
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/3D/Binary")]
public class CameraFilterPack_3D_Binary : MonoBehaviour
{
	// Token: 0x1700020E RID: 526
	// (get) Token: 0x06000ABA RID: 2746 RVA: 0x000686FA File Offset: 0x000668FA
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

	// Token: 0x06000ABB RID: 2747 RVA: 0x0006872E File Offset: 0x0006692E
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_3D_Binary1") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/3D_Binary");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000ABC RID: 2748 RVA: 0x00068764 File Offset: 0x00066964
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
			this.material.SetFloat("_DepthLevel", this.Fade);
			this.material.SetFloat("_FadeFromBinary", this.FadeFromBinary);
			this.material.SetFloat("_FixDistance", this._FixDistance);
			this.material.SetFloat("_MatrixSize", this.MatrixSize);
			this.material.SetColor("_MatrixColor", this._MatrixColor);
			this.material.SetFloat("_MatrixSpeed", this.MatrixSpeed * 2f);
			this.material.SetFloat("_Visualize", (float)(this._Visualize ? 1 : 0));
			this.material.SetFloat("_LightIntensity", this.LightIntensity);
			this.material.SetTexture("_MainTex2", this.Texture2);
			float farClipPlane = base.GetComponent<Camera>().farClipPlane;
			this.material.SetFloat("_FarCamera", 1000f / farClipPlane);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			base.GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000ABD RID: 2749 RVA: 0x00068906 File Offset: 0x00066B06
	private void Update()
	{
	}

	// Token: 0x06000ABE RID: 2750 RVA: 0x00068908 File Offset: 0x00066B08
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000E44 RID: 3652
	public Shader SCShader;

	// Token: 0x04000E45 RID: 3653
	private float TimeX = 1f;

	// Token: 0x04000E46 RID: 3654
	public bool _Visualize;

	// Token: 0x04000E47 RID: 3655
	private Material SCMaterial;

	// Token: 0x04000E48 RID: 3656
	[Range(0f, 100f)]
	public float _FixDistance = 2f;

	// Token: 0x04000E49 RID: 3657
	[Range(-5f, 5f)]
	public float LightIntensity;

	// Token: 0x04000E4A RID: 3658
	[Range(0f, 8f)]
	public float MatrixSize = 2f;

	// Token: 0x04000E4B RID: 3659
	[Range(-4f, 4f)]
	public float MatrixSpeed = 1f;

	// Token: 0x04000E4C RID: 3660
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04000E4D RID: 3661
	[Range(0f, 1f)]
	public float FadeFromBinary;

	// Token: 0x04000E4E RID: 3662
	public Color _MatrixColor = new Color(1f, 0.3f, 0.3f, 1f);

	// Token: 0x04000E4F RID: 3663
	public static Color ChangeColorRGB;

	// Token: 0x04000E50 RID: 3664
	private Texture2D Texture2;
}
