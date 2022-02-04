﻿using System;
using UnityEngine;

// Token: 0x020002CD RID: 717
public class FollowSkirtScript : MonoBehaviour
{
	// Token: 0x060014A2 RID: 5282 RVA: 0x000CAED0 File Offset: 0x000C90D0
	private void LateUpdate()
	{
		this.SkirtHips.position = this.TargetSkirtHips.position;
		for (int i = 0; i < 3; i++)
		{
			this.SkirtFront[i].position = this.TargetSkirtFront[i].position;
			this.SkirtFront[i].rotation = this.TargetSkirtFront[i].rotation;
			this.SkirtBack[i].position = this.TargetSkirtBack[i].position;
			this.SkirtBack[i].rotation = this.TargetSkirtBack[i].rotation;
			this.SkirtRight[i].position = this.TargetSkirtRight[i].position;
			this.SkirtRight[i].rotation = this.TargetSkirtRight[i].rotation;
			this.SkirtLeft[i].position = this.TargetSkirtLeft[i].position;
			this.SkirtLeft[i].rotation = this.TargetSkirtLeft[i].rotation;
		}
	}

	// Token: 0x04002043 RID: 8259
	public Transform[] TargetSkirtFront;

	// Token: 0x04002044 RID: 8260
	public Transform[] TargetSkirtBack;

	// Token: 0x04002045 RID: 8261
	public Transform[] TargetSkirtRight;

	// Token: 0x04002046 RID: 8262
	public Transform[] TargetSkirtLeft;

	// Token: 0x04002047 RID: 8263
	public Transform[] SkirtFront;

	// Token: 0x04002048 RID: 8264
	public Transform[] SkirtBack;

	// Token: 0x04002049 RID: 8265
	public Transform[] SkirtRight;

	// Token: 0x0400204A RID: 8266
	public Transform[] SkirtLeft;

	// Token: 0x0400204B RID: 8267
	public Transform TargetSkirtHips;

	// Token: 0x0400204C RID: 8268
	public Transform SkirtHips;
}
