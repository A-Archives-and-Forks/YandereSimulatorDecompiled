﻿using System;
using UnityEngine;

// Token: 0x02000244 RID: 580
public class ChinaDressScript : MonoBehaviour
{
	// Token: 0x0600124D RID: 4685 RVA: 0x0008CED8 File Offset: 0x0008B0D8
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Yandere.WearChinaDress();
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
		}
	}

	// Token: 0x04001727 RID: 5927
	public PromptScript Prompt;
}
