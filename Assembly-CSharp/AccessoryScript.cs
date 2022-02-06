﻿using System;
using UnityEngine;

// Token: 0x020000C2 RID: 194
public class AccessoryScript : MonoBehaviour
{
	// Token: 0x0600099D RID: 2461 RVA: 0x0004CF08 File Offset: 0x0004B108
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.Prompt.MyCollider.enabled = false;
			base.transform.parent = this.Target;
			base.transform.localPosition = new Vector3(this.X, this.Y, this.Z);
			base.transform.localEulerAngles = Vector3.zero;
			base.enabled = false;
		}
	}

	// Token: 0x04000855 RID: 2133
	public PromptScript Prompt;

	// Token: 0x04000856 RID: 2134
	public Transform Target;

	// Token: 0x04000857 RID: 2135
	public float X;

	// Token: 0x04000858 RID: 2136
	public float Y;

	// Token: 0x04000859 RID: 2137
	public float Z;
}
