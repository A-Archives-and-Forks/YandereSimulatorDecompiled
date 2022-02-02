﻿using System;
using UnityEngine;

// Token: 0x020003D8 RID: 984
public class RivalDeskScript : MonoBehaviour
{
	// Token: 0x06001B77 RID: 7031 RVA: 0x00136FD9 File Offset: 0x001351D9
	private void Start()
	{
		if (DateGlobals.Weekday != DayOfWeek.Friday)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001B78 RID: 7032 RVA: 0x00136FEC File Offset: 0x001351EC
	private void Update()
	{
		if (!this.Prompt.Yandere.Inventory.AnswerSheet && this.Prompt.Yandere.Inventory.DuplicateSheet)
		{
			this.Prompt.enabled = true;
			if (this.Clock.HourTime > 13f)
			{
				this.Prompt.HideButton[0] = false;
				if (this.Clock.HourTime > 13.5f)
				{
					SchemeGlobals.SetSchemeStage(5, 100);
					this.Schemes.UpdateInstructions();
					this.Prompt.HideButton[0] = true;
				}
			}
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				if (DateGlobals.Weekday == DayOfWeek.Friday)
				{
					SchemeGlobals.SetSchemeStage(5, 9);
				}
				this.Schemes.UpdateInstructions();
				this.Prompt.Yandere.Inventory.DuplicateSheet = false;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.Cheating = true;
				base.enabled = false;
			}
		}
	}

	// Token: 0x04002F01 RID: 12033
	public SchemesScript Schemes;

	// Token: 0x04002F02 RID: 12034
	public ClockScript Clock;

	// Token: 0x04002F03 RID: 12035
	public PromptScript Prompt;

	// Token: 0x04002F04 RID: 12036
	public bool Cheating;
}
