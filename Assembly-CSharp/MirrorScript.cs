﻿using System;
using UnityEngine;

// Token: 0x0200036B RID: 875
public class MirrorScript : MonoBehaviour
{
	// Token: 0x060019D3 RID: 6611 RVA: 0x0010925C File Offset: 0x0010745C
	private void Start()
	{
		this.Started = true;
		this.Limit = this.Idles.Length - 1;
		if (this.Prompt.Yandere.Club == ClubType.Delinquent)
		{
			this.Prompt.Yandere.PersonaID = 10;
			if (this.Prompt.Yandere.Persona != YanderePersonaType.Tough)
			{
				this.UpdatePersona();
			}
		}
		if (GameGlobals.Eighties)
		{
			this.Idles[0] = "f02_ryobaIdle_00";
			this.Walks[0] = "f02_ryobaWalk_00";
		}
	}

	// Token: 0x060019D4 RID: 6612 RVA: 0x001092E4 File Offset: 0x001074E4
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			if (this.Prompt.Yandere.Health > 0)
			{
				this.Prompt.Circle[0].fillAmount = 1f;
				this.Prompt.Yandere.PersonaID++;
				if (this.Prompt.Yandere.PersonaID == this.Limit)
				{
					this.Prompt.Yandere.PersonaID = 0;
				}
				this.UpdatePersona();
				return;
			}
		}
		else if (this.Prompt.Circle[1].fillAmount == 0f && this.Prompt.Yandere.Health > 0)
		{
			this.Prompt.Circle[1].fillAmount = 1f;
			this.Prompt.Yandere.PersonaID--;
			if (this.Prompt.Yandere.PersonaID < 0)
			{
				this.Prompt.Yandere.PersonaID = this.Limit - 1;
			}
			this.UpdatePersona();
		}
	}

	// Token: 0x060019D5 RID: 6613 RVA: 0x0010940C File Offset: 0x0010760C
	public void UpdatePersona()
	{
		if (!this.Started)
		{
			this.Start();
		}
		int personaID = this.Prompt.Yandere.PersonaID;
		if (!this.Prompt.Yandere.Carrying)
		{
			if (!this.Prompt.Yandere.Resting)
			{
				this.Prompt.Yandere.NotificationManager.PersonaName = this.Personas[personaID];
				this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Persona);
			}
			this.Prompt.Yandere.IdleAnim = this.Idles[personaID];
			this.Prompt.Yandere.WalkAnim = this.Walks[personaID];
			this.Prompt.Yandere.UpdatePersona(personaID);
		}
		this.Prompt.Yandere.OriginalIdleAnim = this.Idles[personaID];
		this.Prompt.Yandere.OriginalWalkAnim = this.Walks[personaID];
		this.Prompt.Yandere.StudentManager.UpdatePerception();
	}

	// Token: 0x04002995 RID: 10645
	public PromptScript Prompt;

	// Token: 0x04002996 RID: 10646
	public string[] Personas;

	// Token: 0x04002997 RID: 10647
	public string[] Idles;

	// Token: 0x04002998 RID: 10648
	public string[] Walks;

	// Token: 0x04002999 RID: 10649
	public bool Started;

	// Token: 0x0400299A RID: 10650
	public int Limit;
}
