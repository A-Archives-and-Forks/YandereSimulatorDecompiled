﻿using System;
using UnityEngine;

// Token: 0x02000282 RID: 642
public class DetectionCameraScript : MonoBehaviour
{
	// Token: 0x06001390 RID: 5008 RVA: 0x000B4158 File Offset: 0x000B2358
	private void Update()
	{
		base.transform.position = this.YandereChan.transform.position + Vector3.up * 100f;
		base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
	}

	// Token: 0x04001CE9 RID: 7401
	public Transform YandereChan;
}
