﻿using System;
using UnityEngine;

// Token: 0x02000339 RID: 825
public class IntroYandereScript : MonoBehaviour
{
	// Token: 0x060018DB RID: 6363 RVA: 0x000F8210 File Offset: 0x000F6410
	private void LateUpdate()
	{
		this.Hips.localEulerAngles = new Vector3(this.Hips.localEulerAngles.x + this.X, this.Hips.localEulerAngles.y, this.Hips.localEulerAngles.z);
		this.Spine.localEulerAngles = new Vector3(this.Spine.localEulerAngles.x + this.X, this.Spine.localEulerAngles.y, this.Spine.localEulerAngles.z);
		this.Spine1.localEulerAngles = new Vector3(this.Spine1.localEulerAngles.x + this.X, this.Spine1.localEulerAngles.y, this.Spine1.localEulerAngles.z);
		this.Spine2.localEulerAngles = new Vector3(this.Spine2.localEulerAngles.x + this.X, this.Spine2.localEulerAngles.y, this.Spine2.localEulerAngles.z);
		this.Spine3.localEulerAngles = new Vector3(this.Spine3.localEulerAngles.x + this.X, this.Spine3.localEulerAngles.y, this.Spine3.localEulerAngles.z);
		this.Neck.localEulerAngles = new Vector3(this.Neck.localEulerAngles.x + this.X, this.Neck.localEulerAngles.y, this.Neck.localEulerAngles.z);
		this.Head.localEulerAngles = new Vector3(this.Head.localEulerAngles.x + this.X, this.Head.localEulerAngles.y, this.Head.localEulerAngles.z);
		this.RightUpLeg.localEulerAngles = new Vector3(this.RightUpLeg.localEulerAngles.x - this.X, this.RightUpLeg.localEulerAngles.y, this.RightUpLeg.localEulerAngles.z);
		this.RightLeg.localEulerAngles = new Vector3(this.RightLeg.localEulerAngles.x - this.X, this.RightLeg.localEulerAngles.y, this.RightLeg.localEulerAngles.z);
		this.RightFoot.localEulerAngles = new Vector3(this.RightFoot.localEulerAngles.x - this.X, this.RightFoot.localEulerAngles.y, this.RightFoot.localEulerAngles.z);
		this.LeftUpLeg.localEulerAngles = new Vector3(this.LeftUpLeg.localEulerAngles.x - this.X, this.LeftUpLeg.localEulerAngles.y, this.LeftUpLeg.localEulerAngles.z);
		this.LeftLeg.localEulerAngles = new Vector3(this.LeftLeg.localEulerAngles.x - this.X, this.LeftLeg.localEulerAngles.y, this.LeftLeg.localEulerAngles.z);
		this.LeftFoot.localEulerAngles = new Vector3(this.LeftFoot.localEulerAngles.x - this.X, this.LeftFoot.localEulerAngles.y, this.LeftFoot.localEulerAngles.z);
	}

	// Token: 0x04002687 RID: 9863
	public Transform Hips;

	// Token: 0x04002688 RID: 9864
	public Transform Spine;

	// Token: 0x04002689 RID: 9865
	public Transform Spine1;

	// Token: 0x0400268A RID: 9866
	public Transform Spine2;

	// Token: 0x0400268B RID: 9867
	public Transform Spine3;

	// Token: 0x0400268C RID: 9868
	public Transform Neck;

	// Token: 0x0400268D RID: 9869
	public Transform Head;

	// Token: 0x0400268E RID: 9870
	public Transform RightUpLeg;

	// Token: 0x0400268F RID: 9871
	public Transform RightLeg;

	// Token: 0x04002690 RID: 9872
	public Transform RightFoot;

	// Token: 0x04002691 RID: 9873
	public Transform LeftUpLeg;

	// Token: 0x04002692 RID: 9874
	public Transform LeftLeg;

	// Token: 0x04002693 RID: 9875
	public Transform LeftFoot;

	// Token: 0x04002694 RID: 9876
	public float X;
}
