﻿using System;
using UnityEngine;

// Token: 0x020003B8 RID: 952
public class PowerSwitchScript : MonoBehaviour
{
	// Token: 0x06001AE6 RID: 6886 RVA: 0x001296AA File Offset: 0x001278AA
	private void Start()
	{
		if (this.BathroomLight != null)
		{
			this.Prompt.Label[0].text = "     Turn Off";
		}
		if (!GameGlobals.Eighties && this.Haunted)
		{
			this.BathroomLight = null;
		}
	}

	// Token: 0x06001AE7 RID: 6887 RVA: 0x001296E8 File Offset: 0x001278E8
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			this.On = !this.On;
			if (this.BathroomLight == null)
			{
				if (this.On)
				{
					this.Prompt.Label[0].text = "     Turn Off";
					this.MyAudio.clip = this.Flick[1];
				}
				else
				{
					this.Prompt.Label[0].text = "     Turn On";
					this.MyAudio.clip = this.Flick[0];
				}
			}
			else
			{
				if (this.On)
				{
					this.Prompt.Label[0].text = "     Turn On";
					this.MyAudio.clip = this.Flick[1];
				}
				else
				{
					this.Prompt.Label[0].text = "     Turn Off";
					this.MyAudio.clip = this.Flick[0];
				}
				this.BathroomLight.enabled = !this.BathroomLight.enabled;
			}
			this.CheckPuddle();
			this.MyAudio.Play();
		}
	}

	// Token: 0x06001AE8 RID: 6888 RVA: 0x00129830 File Offset: 0x00127A30
	public void CheckPuddle()
	{
		if (this.On)
		{
			if (this.DrinkingFountain.Puddle != null && this.DrinkingFountain.Puddle.gameObject.activeInHierarchy && this.PowerOutlet.SabotagedOutlet.activeInHierarchy)
			{
				this.Electricity.SetActive(true);
				return;
			}
		}
		else
		{
			this.Electricity.SetActive(false);
		}
	}

	// Token: 0x04002D5E RID: 11614
	public DrinkingFountainScript DrinkingFountain;

	// Token: 0x04002D5F RID: 11615
	public PowerOutletScript PowerOutlet;

	// Token: 0x04002D60 RID: 11616
	public GameObject Electricity;

	// Token: 0x04002D61 RID: 11617
	public Light BathroomLight;

	// Token: 0x04002D62 RID: 11618
	public PromptScript Prompt;

	// Token: 0x04002D63 RID: 11619
	public AudioSource MyAudio;

	// Token: 0x04002D64 RID: 11620
	public AudioClip[] Flick;

	// Token: 0x04002D65 RID: 11621
	public bool Haunted;

	// Token: 0x04002D66 RID: 11622
	public bool On;
}
