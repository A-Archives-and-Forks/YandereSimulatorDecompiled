﻿using System;
using UnityEngine;

// Token: 0x02000313 RID: 787
public class HidingSpotScript : MonoBehaviour
{
	// Token: 0x06001857 RID: 6231 RVA: 0x000EAD00 File Offset: 0x000E8F00
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (!this.Prompt.Yandere.Chased && this.Prompt.Yandere.Chasers == 0 && this.Prompt.Yandere.Pursuer == null)
			{
				if (this.Bench)
				{
					this.Prompt.Yandere.MyController.radius = 0.1f;
				}
				else
				{
					this.Prompt.Yandere.MyController.center = new Vector3(this.Prompt.Yandere.MyController.center.x, 0.3f, this.Prompt.Yandere.MyController.center.z);
					this.Prompt.Yandere.MyController.radius = 0f;
					this.Prompt.Yandere.MyController.height = 0.5f;
				}
				this.Prompt.Yandere.HideAnim = this.AnimName;
				this.Prompt.Yandere.HidingSpot = this.Spot;
				this.Prompt.Yandere.ExitSpot = this.Exit;
				this.Prompt.Yandere.CanMove = false;
				this.Prompt.Yandere.Hiding = true;
				this.Prompt.Yandere.EmptyHands();
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[1].text = "Stop";
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = true;
			}
		}
	}

	// Token: 0x0400240C RID: 9228
	public PromptBarScript PromptBar;

	// Token: 0x0400240D RID: 9229
	public PromptScript Prompt;

	// Token: 0x0400240E RID: 9230
	public Transform Exit;

	// Token: 0x0400240F RID: 9231
	public Transform Spot;

	// Token: 0x04002410 RID: 9232
	public string AnimName;

	// Token: 0x04002411 RID: 9233
	public bool Bench;
}
