﻿using System;
using UnityEngine;

// Token: 0x0200039C RID: 924
public class PersonaSubtitleScript : MonoBehaviour
{
	// Token: 0x06001A89 RID: 6793 RVA: 0x0011C68C File Offset: 0x0011A88C
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

	// Token: 0x04002BCF RID: 11215
	public SubtitleScript Subtitle;

	// Token: 0x04002BD0 RID: 11216
	public string[] LonerReactions;

	// Token: 0x04002BD1 RID: 11217
	public string[] TeachersPetReactions;

	// Token: 0x04002BD2 RID: 11218
	public string[] HeroicReactions;

	// Token: 0x04002BD3 RID: 11219
	public string[] CowardReactions;

	// Token: 0x04002BD4 RID: 11220
	public string[] EvilReactions;

	// Token: 0x04002BD5 RID: 11221
	public string[] SocialButterflyReactions;

	// Token: 0x04002BD6 RID: 11222
	public string[] LovestruckReactions;

	// Token: 0x04002BD7 RID: 11223
	public string[] DangerousReactions;

	// Token: 0x04002BD8 RID: 11224
	public string[] StrictReactions;

	// Token: 0x04002BD9 RID: 11225
	public string[] PhoneAddictReactions;

	// Token: 0x04002BDA RID: 11226
	public string[] FragileReactions;

	// Token: 0x04002BDB RID: 11227
	public string[] SpitefulReactions;

	// Token: 0x04002BDC RID: 11228
	public string[] SleuthReactions;

	// Token: 0x04002BDD RID: 11229
	public string[] VengefulReactions;

	// Token: 0x04002BDE RID: 11230
	public string[] ProtectiveReactions;

	// Token: 0x04002BDF RID: 11231
	public string[] ViolentReactions;

	// Token: 0x04002BE0 RID: 11232
	public string[] NemesisReactions;

	// Token: 0x04002BE1 RID: 11233
	public string[] IndifferentReactions;

	// Token: 0x04002BE2 RID: 11234
	public string[] SubtitleArray;
}
