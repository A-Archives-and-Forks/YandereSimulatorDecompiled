﻿using System;
using UnityEngine;

// Token: 0x0200032C RID: 812
public class IDCardScript : MonoBehaviour
{
	// Token: 0x060018B5 RID: 6325 RVA: 0x000F2E00 File Offset: 0x000F1000
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			this.Prompt.Yandere.StolenObject = base.gameObject;
			if (!this.Fake)
			{
				this.Prompt.Yandere.Inventory.IDCard = true;
				this.Prompt.Yandere.TheftTimer = 1f;
			}
			else
			{
				this.Prompt.Yandere.Inventory.FakeID = true;
			}
			this.Prompt.Hide();
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x040025AC RID: 9644
	public PromptScript Prompt;

	// Token: 0x040025AD RID: 9645
	public bool Fake;
}
