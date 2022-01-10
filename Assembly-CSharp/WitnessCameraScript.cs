﻿using System;
using UnityEngine;

// Token: 0x020004BD RID: 1213
public class WitnessCameraScript : MonoBehaviour
{
	// Token: 0x06001FC0 RID: 8128 RVA: 0x001C02A7 File Offset: 0x001BE4A7
	private void Start()
	{
		this.MyCamera.enabled = false;
		this.MyCamera.rect = new Rect(0f, 0f, 0f, 0f);
	}

	// Token: 0x06001FC1 RID: 8129 RVA: 0x001C02DC File Offset: 0x001BE4DC
	private void Update()
	{
		if (this.Show)
		{
			this.MyCamera.rect = new Rect(this.MyCamera.rect.x, this.MyCamera.rect.y, Mathf.Lerp(this.MyCamera.rect.width, 0.25f, Time.deltaTime * 10f), Mathf.Lerp(this.MyCamera.rect.height, 0.44444445f, Time.deltaTime * 10f));
			base.transform.localPosition = new Vector3(base.transform.localPosition.x, base.transform.localPosition.y, base.transform.localPosition.z + Time.deltaTime * 0.09f);
			this.WitnessTimer += Time.deltaTime;
			if (this.WitnessTimer > 5f)
			{
				this.WitnessTimer = 0f;
				this.Show = false;
			}
			if (this.Yandere.Struggling)
			{
				this.WitnessTimer = 0f;
				this.Show = false;
				return;
			}
		}
		else
		{
			this.MyCamera.rect = new Rect(this.MyCamera.rect.x, this.MyCamera.rect.y, Mathf.Lerp(this.MyCamera.rect.width, 0f, Time.deltaTime * 10f), Mathf.Lerp(this.MyCamera.rect.height, 0f, Time.deltaTime * 10f));
			if (this.MyCamera.enabled && this.MyCamera.rect.width < 0.1f)
			{
				this.MyCamera.enabled = false;
				base.transform.parent = null;
			}
		}
	}

	// Token: 0x04004295 RID: 17045
	public YandereScript Yandere;

	// Token: 0x04004296 RID: 17046
	public Transform WitnessPOV;

	// Token: 0x04004297 RID: 17047
	public float WitnessTimer;

	// Token: 0x04004298 RID: 17048
	public Camera MyCamera;

	// Token: 0x04004299 RID: 17049
	public bool Show;
}
