﻿using System;
using UnityEngine;

// Token: 0x020003B0 RID: 944
public class PoisonBottleScript : MonoBehaviour
{
	// Token: 0x06001AEA RID: 6890 RVA: 0x001253EC File Offset: 0x001235EC
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (this.Theft)
			{
				this.Prompt.Yandere.TheftTimer = 0.1f;
			}
			if (this.ID == 1)
			{
				this.Prompt.Yandere.Inventory.EmeticPoison = true;
			}
			else if (this.ID == 2)
			{
				this.Prompt.Yandere.Inventory.LethalPoison = true;
				this.Prompt.Yandere.Inventory.LethalPoisons++;
			}
			else if (this.ID == 3)
			{
				if (!this.Prompt.Yandere.Inventory.RatPoison)
				{
					this.Prompt.Yandere.Inventory.RatPoison = true;
				}
				else
				{
					this.Prompt.Yandere.NotificationManager.CustomText = "You're already carrying some of that";
					this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
			else if (this.ID == 4)
			{
				this.Prompt.Yandere.Inventory.HeadachePoison = true;
			}
			else if (this.ID == 5)
			{
				this.Prompt.Yandere.Inventory.Tranquilizer = true;
			}
			else if (this.ID == 6)
			{
				this.Prompt.Yandere.Inventory.Sedative = true;
			}
			this.Prompt.Yandere.StudentManager.UpdateAllBentos();
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04002D1A RID: 11546
	public PromptScript Prompt;

	// Token: 0x04002D1B RID: 11547
	public bool Theft;

	// Token: 0x04002D1C RID: 11548
	public int ID;
}
