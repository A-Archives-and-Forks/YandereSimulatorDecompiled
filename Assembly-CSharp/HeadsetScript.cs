﻿using System;
using UnityEngine;

// Token: 0x02000311 RID: 785
public class HeadsetScript : MonoBehaviour
{
	// Token: 0x06001865 RID: 6245 RVA: 0x000E8D3C File Offset: 0x000E6F3C
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.Headset = true;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040023E3 RID: 9187
	public PromptScript Prompt;
}
