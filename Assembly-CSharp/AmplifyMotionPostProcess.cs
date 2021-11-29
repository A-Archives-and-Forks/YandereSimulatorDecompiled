﻿using System;
using UnityEngine;

// Token: 0x020000B7 RID: 183
[AddComponentMenu("")]
[RequireComponent(typeof(Camera))]
public sealed class AmplifyMotionPostProcess : MonoBehaviour
{
	// Token: 0x170001F2 RID: 498
	// (get) Token: 0x0600095F RID: 2399 RVA: 0x0004B2A1 File Offset: 0x000494A1
	// (set) Token: 0x06000960 RID: 2400 RVA: 0x0004B2A9 File Offset: 0x000494A9
	public AmplifyMotionEffectBase Instance
	{
		get
		{
			return this.m_instance;
		}
		set
		{
			this.m_instance = value;
		}
	}

	// Token: 0x06000961 RID: 2401 RVA: 0x0004B2B2 File Offset: 0x000494B2
	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (this.m_instance != null)
		{
			this.m_instance.PostProcess(source, destination);
		}
	}

	// Token: 0x040007FE RID: 2046
	private AmplifyMotionEffectBase m_instance;
}
