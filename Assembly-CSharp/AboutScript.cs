﻿using System;
using UnityEngine;

// Token: 0x020000C0 RID: 192
public class AboutScript : MonoBehaviour
{
	// Token: 0x06000998 RID: 2456 RVA: 0x0004CBCC File Offset: 0x0004ADCC
	private void Start()
	{
		foreach (Transform transform in this.Labels)
		{
			Vector3 localPosition = transform.localPosition;
			localPosition.x = 2000f;
			transform.localPosition = localPosition;
		}
	}

	// Token: 0x06000999 RID: 2457 RVA: 0x0004CC0C File Offset: 0x0004AE0C
	private void Update()
	{
		if (Input.GetButtonDown("A"))
		{
			if (this.SlideID < this.Labels.Length)
			{
				this.SlideIn[this.SlideID] = true;
			}
			this.SlideID++;
		}
		if (this.SlideID < this.Labels.Length + 1)
		{
			this.ID = 0;
			while (this.ID < this.Labels.Length)
			{
				if (this.SlideIn[this.ID])
				{
					Transform transform = this.Labels[this.ID];
					Vector3 localPosition = transform.localPosition;
					localPosition.x = Mathf.Lerp(localPosition.x, 0f, Time.deltaTime);
					transform.localPosition = localPosition;
				}
				this.ID++;
			}
			return;
		}
		this.Timer += Time.deltaTime * 10f;
		this.ID = 0;
		while (this.ID < this.Labels.Length)
		{
			if (this.Timer > (float)this.ID)
			{
				this.SlideOut[this.ID] = true;
				Transform transform2 = this.Labels[this.ID];
				Vector3 localPosition2 = transform2.localPosition;
				if (localPosition2.x > 0f)
				{
					localPosition2.x = -0.1f;
					transform2.localPosition = localPosition2;
				}
			}
			this.ID++;
		}
		this.ID = 0;
		while (this.ID < this.Labels.Length)
		{
			if (this.SlideOut[this.ID])
			{
				Transform transform3 = this.Labels[this.ID];
				Vector3 localPosition3 = transform3.localPosition;
				localPosition3.x += localPosition3.x * 0.01f;
				transform3.localPosition = localPosition3;
			}
			this.ID++;
		}
		if (this.SlideID > this.Labels.Length + 1)
		{
			Color color = this.LinkLabel.color;
			color.a += Time.deltaTime;
			this.LinkLabel.color = color;
		}
		if (this.SlideID > this.Labels.Length + 2)
		{
			Color color2 = this.Yuno1.color;
			color2.a += Time.deltaTime;
			this.Yuno1.color = color2;
		}
		if (this.SlideID > this.Labels.Length + 3)
		{
			Color color3 = this.Yuno2.color;
			color3.a += Time.deltaTime;
			this.Yuno2.color = color3;
			Vector3 localScale = this.Yuno2.transform.localScale;
			localScale.x += Time.deltaTime * 0.1f;
			localScale.y += Time.deltaTime * 0.1f;
			this.Yuno2.transform.localScale = localScale;
		}
	}

	// Token: 0x0400084A RID: 2122
	public Transform[] Labels;

	// Token: 0x0400084B RID: 2123
	public bool[] SlideOut;

	// Token: 0x0400084C RID: 2124
	public bool[] SlideIn;

	// Token: 0x0400084D RID: 2125
	public UILabel LinkLabel;

	// Token: 0x0400084E RID: 2126
	public UITexture Yuno1;

	// Token: 0x0400084F RID: 2127
	public UITexture Yuno2;

	// Token: 0x04000850 RID: 2128
	public int SlideID;

	// Token: 0x04000851 RID: 2129
	public int ID;

	// Token: 0x04000852 RID: 2130
	public float Timer;
}
