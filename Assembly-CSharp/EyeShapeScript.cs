﻿using System;
using UnityEngine;

// Token: 0x020002C2 RID: 706
public class EyeShapeScript : MonoBehaviour
{
	// Token: 0x06001487 RID: 5255 RVA: 0x000C8584 File Offset: 0x000C6784
	private void Start()
	{
		this.PosOffsetX = UnityEngine.Random.Range(-0.002f, 0.002f);
		this.PosOffsetY = UnityEngine.Random.Range(-0.002f, 0.002f);
		this.PosOffsetZ = UnityEngine.Random.Range(-0.002f, 0.002f);
		this.RotOffsetX = UnityEngine.Random.Range(-15f, 15f);
		this.RotOffsetY = UnityEngine.Random.Range(-15f, 15f);
		this.RotOffsetZ = UnityEngine.Random.Range(-15f, 15f);
	}

	// Token: 0x06001488 RID: 5256 RVA: 0x000C8610 File Offset: 0x000C6810
	private void LateUpdate()
	{
		this.eyelid_und1_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
		this.eyelid_und1_Right.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
		this.eyelid_und2_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
		this.eyelid_und2_Right.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
		this.eyelid_und_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
		this.eyelid_und_Right.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
		this.eyerid1_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
		this.eyerid1_Right.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
		this.eyerid2_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
		this.eyerid2_Right.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
		this.eyerid_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
		this.eyerid_Right.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
		this.inner_corner_of_eye_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
		this.inner_corner_of_eye_Reft.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
		this.tail_of_eye_Left.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ);
		this.tail_of_eye_Right.localPosition += new Vector3(this.PosOffsetX, this.PosOffsetY, this.PosOffsetZ * -1f);
		this.eyelid_und1_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
		this.eyelid_und1_Right.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
		this.eyelid_und2_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
		this.eyelid_und2_Right.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
		this.eyelid_und_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
		this.eyelid_und_Right.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
		this.eyerid1_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
		this.eyerid1_Right.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
		this.eyerid2_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
		this.eyerid2_Right.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
		this.eyerid_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
		this.eyerid_Right.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
		this.inner_corner_of_eye_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
		this.inner_corner_of_eye_Reft.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
		this.tail_of_eye_Left.localEulerAngles += new Vector3(this.RotOffsetX, this.RotOffsetY, this.RotOffsetZ);
		this.tail_of_eye_Right.localEulerAngles += new Vector3(this.RotOffsetX * -1f, this.RotOffsetY * -1f, this.RotOffsetZ);
	}

	// Token: 0x04001FB9 RID: 8121
	public Transform eyelid_und1_Left;

	// Token: 0x04001FBA RID: 8122
	public Transform eyelid_und1_Right;

	// Token: 0x04001FBB RID: 8123
	public Transform eyelid_und2_Left;

	// Token: 0x04001FBC RID: 8124
	public Transform eyelid_und2_Right;

	// Token: 0x04001FBD RID: 8125
	public Transform eyelid_und_Left;

	// Token: 0x04001FBE RID: 8126
	public Transform eyelid_und_Right;

	// Token: 0x04001FBF RID: 8127
	public Transform eyerid1_Left;

	// Token: 0x04001FC0 RID: 8128
	public Transform eyerid1_Right;

	// Token: 0x04001FC1 RID: 8129
	public Transform eyerid2_Left;

	// Token: 0x04001FC2 RID: 8130
	public Transform eyerid2_Right;

	// Token: 0x04001FC3 RID: 8131
	public Transform eyerid_Left;

	// Token: 0x04001FC4 RID: 8132
	public Transform eyerid_Right;

	// Token: 0x04001FC5 RID: 8133
	public Transform inner_corner_of_eye_Left;

	// Token: 0x04001FC6 RID: 8134
	public Transform inner_corner_of_eye_Reft;

	// Token: 0x04001FC7 RID: 8135
	public Transform tail_of_eye_Left;

	// Token: 0x04001FC8 RID: 8136
	public Transform tail_of_eye_Right;

	// Token: 0x04001FC9 RID: 8137
	public float PosOffsetX;

	// Token: 0x04001FCA RID: 8138
	public float PosOffsetY;

	// Token: 0x04001FCB RID: 8139
	public float PosOffsetZ;

	// Token: 0x04001FCC RID: 8140
	public float RotOffsetX;

	// Token: 0x04001FCD RID: 8141
	public float RotOffsetY;

	// Token: 0x04001FCE RID: 8142
	public float RotOffsetZ;
}
