﻿using System;
using UnityEngine;

// Token: 0x020003EE RID: 1006
public class RummageSpotScript : MonoBehaviour
{
	// Token: 0x06001BE0 RID: 7136 RVA: 0x00145A4C File Offset: 0x00143C4C
	private void Start()
	{
		if (this.ID == 1)
		{
			if (GameGlobals.AnswerSheetUnavailable)
			{
				Debug.Log("The answer sheet is no longer available, due to events on a previous day.");
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				base.gameObject.SetActive(false);
				return;
			}
			if (DateGlobals.Weekday == DayOfWeek.Friday && this.Clock.HourTime > 13.5f)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				base.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x06001BE1 RID: 7137 RVA: 0x00145AD4 File Offset: 0x00143CD4
	private void Update()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
			{
				this.Yandere.EmptyHands();
				this.Yandere.CharacterAnimation.CrossFade("f02_rummage_00");
				this.Yandere.ProgressBar.transform.parent.gameObject.SetActive(true);
				this.Yandere.RummageSpot = this;
				this.Yandere.Rummaging = true;
				this.Yandere.CanMove = false;
				component.Play();
			}
		}
		if (this.Yandere.Rummaging)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.AlarmDisc, base.transform.position, Quaternion.identity);
			gameObject.GetComponent<AlarmDiscScript>().NoScream = true;
			gameObject.transform.localScale = new Vector3(750f, gameObject.transform.localScale.y, 750f);
		}
		if (this.Yandere.Noticed)
		{
			component.Stop();
		}
	}

	// Token: 0x06001BE2 RID: 7138 RVA: 0x00145C14 File Offset: 0x00143E14
	public void GetReward()
	{
		if (this.ID == 1)
		{
			if (this.Phase == 1)
			{
				SchemeGlobals.SetSchemeStage(5, 5);
				this.Schemes.UpdateInstructions();
				this.Yandere.Inventory.AnswerSheet = true;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.DoorGap.Prompt.enabled = true;
				this.Phase++;
				return;
			}
			if (this.Phase == 2)
			{
				SchemeGlobals.SetSchemeStage(5, 8);
				this.Schemes.UpdateInstructions();
				this.Prompt.Yandere.Inventory.AnswerSheet = false;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				base.gameObject.SetActive(false);
				this.Phase++;
			}
		}
	}

	// Token: 0x040030E5 RID: 12517
	public GameObject AlarmDisc;

	// Token: 0x040030E6 RID: 12518
	public DoorGapScript DoorGap;

	// Token: 0x040030E7 RID: 12519
	public SchemesScript Schemes;

	// Token: 0x040030E8 RID: 12520
	public YandereScript Yandere;

	// Token: 0x040030E9 RID: 12521
	public PromptScript Prompt;

	// Token: 0x040030EA RID: 12522
	public ClockScript Clock;

	// Token: 0x040030EB RID: 12523
	public Transform Target;

	// Token: 0x040030EC RID: 12524
	public int Phase;

	// Token: 0x040030ED RID: 12525
	public int ID;
}
