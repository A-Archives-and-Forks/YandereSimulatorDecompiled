﻿using System;
using UnityEngine;

// Token: 0x020003EF RID: 1007
public class SabotageVendingMachineScript : MonoBehaviour
{
	// Token: 0x06001BDE RID: 7134 RVA: 0x00145325 File Offset: 0x00143525
	private void Start()
	{
		this.Prompt.enabled = false;
		this.Prompt.Hide();
	}

	// Token: 0x06001BDF RID: 7135 RVA: 0x00145340 File Offset: 0x00143540
	private void Update()
	{
		if (this.Yandere.Armed)
		{
			if (this.Yandere.EquippedWeapon.WeaponID == 6)
			{
				this.Prompt.enabled = true;
				if (this.Prompt.Circle[0].fillAmount == 0f)
				{
					if (SchemeGlobals.GetSchemeStage(4) == 2)
					{
						SchemeGlobals.SetSchemeStage(4, 3);
						this.Yandere.PauseScreen.Schemes.UpdateInstructions();
					}
					if (this.Yandere.StudentManager.Students[11] != null && DateGlobals.Weekday == DayOfWeek.Thursday)
					{
						this.Yandere.StudentManager.Students[11].Hungry = true;
						this.Yandere.StudentManager.Students[11].Fed = false;
					}
					UnityEngine.Object.Instantiate<GameObject>(this.SabotageSparks, new Vector3(-2.5f, 5.3605f, -32.982f), Quaternion.identity);
					this.VendingMachine.Sabotaged = true;
					this.Prompt.enabled = false;
					this.Prompt.Hide();
					base.enabled = false;
					return;
				}
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.enabled = false;
			this.Prompt.Hide();
		}
	}

	// Token: 0x040030E2 RID: 12514
	public VendingMachineScript VendingMachine;

	// Token: 0x040030E3 RID: 12515
	public GameObject SabotageSparks;

	// Token: 0x040030E4 RID: 12516
	public YandereScript Yandere;

	// Token: 0x040030E5 RID: 12517
	public PromptScript Prompt;
}
