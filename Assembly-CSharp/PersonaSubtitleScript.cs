﻿using System;
using UnityEngine;

// Token: 0x02000397 RID: 919
public class PersonaSubtitleScript : MonoBehaviour
{
	// Token: 0x06001A5A RID: 6746 RVA: 0x00119900 File Offset: 0x00117B00
	public void UpdateLabel(PersonaType Persona, float Reputation, float Duration)
	{
		switch (Persona)
		{
		case PersonaType.None:
			this.SubtitleArray = this.IndifferentReactions;
			break;
		case PersonaType.Loner:
			this.SubtitleArray = this.LonerReactions;
			break;
		case PersonaType.TeachersPet:
			this.SubtitleArray = this.TeachersPetReactions;
			break;
		case PersonaType.Heroic:
			this.SubtitleArray = this.HeroicReactions;
			break;
		case PersonaType.Coward:
			this.SubtitleArray = this.CowardReactions;
			break;
		case PersonaType.Evil:
			this.SubtitleArray = this.EvilReactions;
			break;
		case PersonaType.SocialButterfly:
			this.SubtitleArray = this.SocialButterflyReactions;
			break;
		case PersonaType.Lovestruck:
			this.SubtitleArray = this.LovestruckReactions;
			break;
		case PersonaType.Dangerous:
			this.SubtitleArray = this.DangerousReactions;
			break;
		case PersonaType.Strict:
			this.SubtitleArray = this.StrictReactions;
			break;
		case PersonaType.PhoneAddict:
			this.SubtitleArray = this.PhoneAddictReactions;
			break;
		case PersonaType.Fragile:
			this.SubtitleArray = this.FragileReactions;
			break;
		case PersonaType.Spiteful:
			this.SubtitleArray = this.SpitefulReactions;
			break;
		case PersonaType.Sleuth:
			this.SubtitleArray = this.SleuthReactions;
			break;
		case PersonaType.Vengeful:
			this.SubtitleArray = this.VengefulReactions;
			break;
		case PersonaType.Protective:
			this.SubtitleArray = this.ProtectiveReactions;
			break;
		case PersonaType.Violent:
			this.SubtitleArray = this.ViolentReactions;
			break;
		default:
			if (Persona == PersonaType.Nemesis)
			{
				this.SubtitleArray = this.NemesisReactions;
			}
			break;
		}
		if (Reputation < -0.33333334f)
		{
			this.Subtitle.Label.text = this.SubtitleArray[1];
		}
		else if (Reputation > 0.33333334f)
		{
			this.Subtitle.Label.text = this.SubtitleArray[3];
		}
		else
		{
			this.Subtitle.Label.text = this.SubtitleArray[2];
		}
		this.Subtitle.Timer = Duration;
	}

	// Token: 0x04002B50 RID: 11088
	public SubtitleScript Subtitle;

	// Token: 0x04002B51 RID: 11089
	public string[] LonerReactions;

	// Token: 0x04002B52 RID: 11090
	public string[] TeachersPetReactions;

	// Token: 0x04002B53 RID: 11091
	public string[] HeroicReactions;

	// Token: 0x04002B54 RID: 11092
	public string[] CowardReactions;

	// Token: 0x04002B55 RID: 11093
	public string[] EvilReactions;

	// Token: 0x04002B56 RID: 11094
	public string[] SocialButterflyReactions;

	// Token: 0x04002B57 RID: 11095
	public string[] LovestruckReactions;

	// Token: 0x04002B58 RID: 11096
	public string[] DangerousReactions;

	// Token: 0x04002B59 RID: 11097
	public string[] StrictReactions;

	// Token: 0x04002B5A RID: 11098
	public string[] PhoneAddictReactions;

	// Token: 0x04002B5B RID: 11099
	public string[] FragileReactions;

	// Token: 0x04002B5C RID: 11100
	public string[] SpitefulReactions;

	// Token: 0x04002B5D RID: 11101
	public string[] SleuthReactions;

	// Token: 0x04002B5E RID: 11102
	public string[] VengefulReactions;

	// Token: 0x04002B5F RID: 11103
	public string[] ProtectiveReactions;

	// Token: 0x04002B60 RID: 11104
	public string[] ViolentReactions;

	// Token: 0x04002B61 RID: 11105
	public string[] NemesisReactions;

	// Token: 0x04002B62 RID: 11106
	public string[] IndifferentReactions;

	// Token: 0x04002B63 RID: 11107
	public string[] SubtitleArray;
}
