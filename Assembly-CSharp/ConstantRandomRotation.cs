﻿using System;
using UnityEngine;

// Token: 0x02000259 RID: 601
public class ConstantRandomRotation : MonoBehaviour
{
	// Token: 0x060012B1 RID: 4785 RVA: 0x000991AC File Offset: 0x000973AC
	private void Update()
	{
		int num = UnityEngine.Random.Range(0, 360);
		int num2 = UnityEngine.Random.Range(0, 360);
		int num3 = UnityEngine.Random.Range(0, 360);
		base.transform.Rotate((float)num, (float)num2, (float)num3);
	}
}
