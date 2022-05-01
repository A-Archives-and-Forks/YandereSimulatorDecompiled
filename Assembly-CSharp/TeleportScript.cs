﻿using System;
using UnityEngine;

// Token: 0x02000474 RID: 1140
public class TeleportScript : MonoBehaviour
{
	// Token: 0x06001EDC RID: 7900 RVA: 0x001B4449 File Offset: 0x001B2649
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.transform.position = this.Destination.position;
			Physics.SyncTransforms();
		}
	}

	// Token: 0x04003FFF RID: 16383
	public PromptScript Prompt;

	// Token: 0x04004000 RID: 16384
	public Transform Destination;
}
