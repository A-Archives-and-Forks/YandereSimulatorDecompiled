﻿using System;
using UnityEngine;

// Token: 0x020002C5 RID: 709
public class FallingOsanaScript : MonoBehaviour
{
	// Token: 0x06001488 RID: 5256 RVA: 0x000C8B38 File Offset: 0x000C6D38
	private void Update()
	{
		if (base.transform.position.y > 0f)
		{
			base.transform.position += new Vector3(0f, -1.0001f, 0f);
		}
		if (base.transform.position.y < 0f)
		{
			base.transform.position = new Vector3(base.transform.position.x, 0f, base.transform.position.z);
			UnityEngine.Object.Instantiate<GameObject>(this.GroundImpact, base.transform.position, Quaternion.identity);
		}
	}

	// Token: 0x04001FDE RID: 8158
	public StudentScript Osana;

	// Token: 0x04001FDF RID: 8159
	public GameObject GroundImpact;
}
