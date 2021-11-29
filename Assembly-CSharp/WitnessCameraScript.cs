﻿using System;
using UnityEngine;

// Token: 0x020004B9 RID: 1209
public class WitnessCameraScript : MonoBehaviour
{
	// Token: 0x06001FA1 RID: 8097 RVA: 0x001BDBDF File Offset: 0x001BBDDF
	private void Start()
	{
		this.MyCamera.enabled = false;
		this.MyCamera.rect = new Rect(0f, 0f, 0f, 0f);
	}

	// Token: 0x06001FA2 RID: 8098 RVA: 0x001BDC14 File Offset: 0x001BBE14
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

	// Token: 0x04004239 RID: 16953
	public YandereScript Yandere;

	// Token: 0x0400423A RID: 16954
	public Transform WitnessPOV;

	// Token: 0x0400423B RID: 16955
	public float WitnessTimer;

	// Token: 0x0400423C RID: 16956
	public Camera MyCamera;

	// Token: 0x0400423D RID: 16957
	public bool Show;
}
