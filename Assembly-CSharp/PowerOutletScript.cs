﻿using System;
using UnityEngine;

// Token: 0x020003BC RID: 956
public class PowerOutletScript : MonoBehaviour
{
	// Token: 0x06001B0B RID: 6923 RVA: 0x0012C000 File Offset: 0x0012A200
	private void Update()
	{
		if (this.PowerStrip == null)
		{
			if (this.Prompt.Yandere.PickUp != null)
			{
				if (this.Prompt.Yandere.PickUp.Electronic)
				{
					this.Prompt.enabled = true;
				}
				else if (this.Prompt.enabled)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
				}
				if (this.Prompt.Circle[0].fillAmount == 0f)
				{
					this.Prompt.Circle[0].fillAmount = 1f;
					this.PowerStrip = this.Prompt.Yandere.PickUp.gameObject;
					this.Prompt.Yandere.EmptyHands();
					this.PowerStrip.transform.parent = base.transform;
					this.PowerStrip.transform.localPosition = new Vector3(0f, 0f, 0f);
					this.PowerStrip.SetActive(false);
					this.PluggedOutlet.SetActive(true);
					this.Prompt.HideButton[0] = true;
					return;
				}
			}
			else if (this.Prompt.enabled)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				return;
			}
		}
		else if (this.Prompt.Yandere.EquippedWeapon != null)
		{
			if (this.Prompt.Yandere.EquippedWeapon.WeaponID == 6)
			{
				this.Prompt.HideButton[1] = false;
				this.Prompt.enabled = true;
			}
			else if (this.Prompt.enabled)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
			if (this.Prompt.Circle[1].fillAmount == 0f)
			{
				this.Prompt.Circle[1].fillAmount = 1f;
				this.SabotagedOutlet.SetActive(true);
				this.PluggedOutlet.SetActive(false);
				this.PowerSwitch.CheckPuddle();
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				base.enabled = false;
				return;
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	// Token: 0x04002DD3 RID: 11731
	public PromptScript Prompt;

	// Token: 0x04002DD4 RID: 11732
	public PowerSwitchScript PowerSwitch;

	// Token: 0x04002DD5 RID: 11733
	public GameObject PowerStrip;

	// Token: 0x04002DD6 RID: 11734
	public GameObject PluggedOutlet;

	// Token: 0x04002DD7 RID: 11735
	public GameObject SabotagedOutlet;

	// Token: 0x04002DD8 RID: 11736
	public bool Sabotaged;
}
