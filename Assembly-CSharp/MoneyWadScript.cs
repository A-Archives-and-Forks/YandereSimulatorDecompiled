﻿using System;
using UnityEngine;

// Token: 0x0200036A RID: 874
public class MoneyWadScript : MonoBehaviour
{
	// Token: 0x060019AB RID: 6571 RVA: 0x00106798 File Offset: 0x00104998
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.Inventory.Money += 20f;
			this.Prompt.Yandere.Inventory.UpdateMoney();
			if (this.Prompt.Yandere.Inventory.Money > 1000f && !GameGlobals.Debug)
			{
				PlayerPrefs.SetInt("RichGirl", 1);
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0400291F RID: 10527
	public PromptScript Prompt;
}
