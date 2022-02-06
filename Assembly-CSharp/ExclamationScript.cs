﻿using System;
using UnityEngine;

// Token: 0x020002BE RID: 702
public class ExclamationScript : MonoBehaviour
{
	// Token: 0x06001474 RID: 5236 RVA: 0x000C77A4 File Offset: 0x000C59A4
	private void Start()
	{
		base.transform.localScale = Vector3.zero;
		this.Graphic.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, 0f));
		this.MainCamera = Camera.main;
	}

	// Token: 0x06001475 RID: 5237 RVA: 0x000C77FC File Offset: 0x000C59FC
	private void Update()
	{
		this.Timer -= Time.deltaTime;
		if (this.Timer > 0f)
		{
			base.transform.LookAt(this.MainCamera.transform);
			if (this.Timer > 1.5f)
			{
				base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
				this.Alpha = Mathf.Lerp(this.Alpha, 0.5f, Time.deltaTime * 10f);
				this.Graphic.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, this.Alpha));
				return;
			}
			if (base.transform.localScale.x > 0.1f)
			{
				base.transform.localScale = Vector3.Lerp(base.transform.localScale, Vector3.zero, Time.deltaTime * 10f);
			}
			else
			{
				base.transform.localScale = Vector3.zero;
			}
			this.Alpha = Mathf.Lerp(this.Alpha, 0f, Time.deltaTime * 10f);
			this.Graphic.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, this.Alpha));
		}
	}

	// Token: 0x04001F96 RID: 8086
	public Renderer Graphic;

	// Token: 0x04001F97 RID: 8087
	public float Alpha;

	// Token: 0x04001F98 RID: 8088
	public float Timer;

	// Token: 0x04001F99 RID: 8089
	public Camera MainCamera;
}
