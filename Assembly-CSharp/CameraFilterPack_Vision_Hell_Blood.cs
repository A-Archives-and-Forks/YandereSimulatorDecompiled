﻿using System;
using UnityEngine;

// Token: 0x0200022B RID: 555
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Hell_Blood")]
public class CameraFilterPack_Vision_Hell_Blood : MonoBehaviour
{
	// Token: 0x1700032F RID: 815
	// (get) Token: 0x060011E5 RID: 4581 RVA: 0x00089E27 File Offset: 0x00088027
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

	// Token: 0x060011E6 RID: 4582 RVA: 0x00089E5B File Offset: 0x0008805B
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Hell_Blood");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011E7 RID: 4583 RVA: 0x00089E7C File Offset: 0x0008807C
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
			this.material.SetFloat("_Value", this.Hole_Size);
			this.material.SetFloat("_Value2", this.Hole_Smooth);
			this.material.SetFloat("_Value3", this.Hole_Speed * 15f);
			this.material.SetColor("ColorBlood", this.ColorBlood);
			this.material.SetFloat("_Value4", this.Intensity);
			this.material.SetFloat("BloodAlternative1", this.BloodAlternative1);
			this.material.SetFloat("BloodAlternative2", this.BloodAlternative2);
			this.material.SetFloat("BloodAlternative3", this.BloodAlternative3);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060011E8 RID: 4584 RVA: 0x00089FD2 File Offset: 0x000881D2
	private void Update()
	{
	}

	// Token: 0x060011E9 RID: 4585 RVA: 0x00089FD4 File Offset: 0x000881D4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001682 RID: 5762
	public Shader SCShader;

	// Token: 0x04001683 RID: 5763
	private float TimeX = 1f;

	// Token: 0x04001684 RID: 5764
	private Material SCMaterial;

	// Token: 0x04001685 RID: 5765
	[Range(0f, 1f)]
	public float Hole_Size = 0.57f;

	// Token: 0x04001686 RID: 5766
	[Range(0f, 0.5f)]
	public float Hole_Smooth = 0.362f;

	// Token: 0x04001687 RID: 5767
	[Range(-2f, 2f)]
	public float Hole_Speed = 0.85f;

	// Token: 0x04001688 RID: 5768
	[Range(-10f, 10f)]
	public float Intensity = 0.24f;

	// Token: 0x04001689 RID: 5769
	public Color ColorBlood = new Color(1f, 0f, 0f, 1f);

	// Token: 0x0400168A RID: 5770
	[Range(-1f, 1f)]
	public float BloodAlternative1;

	// Token: 0x0400168B RID: 5771
	[Range(-1f, 1f)]
	public float BloodAlternative2;

	// Token: 0x0400168C RID: 5772
	[Range(-1f, 1f)]
	public float BloodAlternative3 = -1f;
}
