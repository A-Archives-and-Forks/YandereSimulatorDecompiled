﻿using System;
using UnityEngine;

// Token: 0x02000280 RID: 640
public class DetectionCameraScript : MonoBehaviour
{
	// Token: 0x06001382 RID: 4994 RVA: 0x000B36F0 File Offset: 0x000B18F0
	private void Update()
	{
		base.transform.position = this.YandereChan.transform.position + Vector3.up * 100f;
		base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
	}

	// Token: 0x04001CC5 RID: 7365
	public Transform YandereChan;
}
