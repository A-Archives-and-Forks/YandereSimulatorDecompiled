﻿using System;
using UnityEngine;

// Token: 0x020003AC RID: 940
public class PoliceWalk : MonoBehaviour
{
	// Token: 0x06001ABC RID: 6844 RVA: 0x001241F0 File Offset: 0x001223F0
	private void Update()
	{
		Vector3 position = base.transform.position;
		position.z += Time.deltaTime;
		base.transform.position = position;
	}
}
