﻿using System;
using UnityEngine;

// Token: 0x020003AC RID: 940
public class PoliceWalk : MonoBehaviour
{
	// Token: 0x06001ABB RID: 6843 RVA: 0x00123CA8 File Offset: 0x00121EA8
	private void Update()
	{
		Vector3 position = base.transform.position;
		position.z += Time.deltaTime;
		base.transform.position = position;
	}
}
