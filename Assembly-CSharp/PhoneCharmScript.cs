﻿using System;
using UnityEngine;

// Token: 0x0200039C RID: 924
public class PhoneCharmScript : MonoBehaviour
{
	// Token: 0x06001A67 RID: 6759 RVA: 0x0011AC4D File Offset: 0x00118E4D
	private void Update()
	{
		base.transform.eulerAngles = new Vector3(90f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
	}
}
