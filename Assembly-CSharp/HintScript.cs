﻿using System;
using UnityEngine;

// Token: 0x02000312 RID: 786
public class HintScript : MonoBehaviour
{
	// Token: 0x06001846 RID: 6214 RVA: 0x000E9ED0 File Offset: 0x000E80D0
	private void Start()
	{
		base.transform.localPosition = new Vector3(0.2043f, 0f, 1f);
		if (DateGlobals.Week > 1 || GameGlobals.Eighties)
		{
			base.gameObject.SetActive(false);
		}
		if (OptionGlobals.HintsOff)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001847 RID: 6215 RVA: 0x000E9F28 File Offset: 0x000E8128
	private void Update()
	{
		if (this.MyPanel.alpha == 1f)
		{
			if (this.Show)
			{
				if (this.Speed == 5f)
				{
					this.MyAudio.Play();
					this.Speed = 0f;
				}
				base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(0f, 0f, 1f), Time.deltaTime * 10f);
				this.Timer += Time.deltaTime;
				if (this.Timer > 5f)
				{
					this.Show = false;
				}
				if (Input.GetButtonDown("Start") && !this.PauseScreen.Yandere.Shutter.Snapping && !this.PauseScreen.Yandere.TimeSkipping && !this.PauseScreen.Yandere.Talking && !this.PauseScreen.Yandere.Noticed && !this.PauseScreen.Yandere.InClass && !this.PauseScreen.Yandere.Struggling && !this.PauseScreen.Yandere.Won && !this.PauseScreen.Yandere.Dismembering && !this.PauseScreen.Yandere.Attacked && this.PauseScreen.Yandere.CanMove && !this.PauseScreen.Yandere.Chased && this.PauseScreen.Yandere.Chasers == 0 && !this.PauseScreen.Yandere.YandereVision && Time.timeScale > 0.0001f && !this.PauseScreen.Schedule.gameObject.activeInHierarchy)
				{
					if (this.DisplayTutorial)
					{
						this.PauseScreen.Yandere.StudentManager.TutorialWindow.SummonWindow();
						this.DisplayTutorial = false;
					}
					else
					{
						this.PauseScreen.ShowScheduleScreen();
						this.PauseScreen.Sideways = true;
						this.PauseScreen.Schedule.JumpToEvent(this.QuickID);
					}
					base.transform.localPosition = new Vector3(0.2043f, 0f, 1f);
					this.Show = false;
					this.Speed = 5f;
					this.Timer = 0f;
					return;
				}
			}
			else if (this.Speed < 5f)
			{
				this.Timer = 0f;
				this.Speed = Mathf.MoveTowards(this.Speed, 5f, Time.deltaTime);
				base.transform.localPosition = Vector3.MoveTowards(base.transform.localPosition, new Vector3(0.2043f, 0f, 1f), this.Speed * Time.deltaTime * 0.0166666f);
				if (this.Speed == 5f)
				{
					base.transform.localPosition = new Vector3(0.2043f, 0f, 1f);
					this.DisplayTutorial = false;
				}
				if (Input.GetButtonDown("Start") && !this.PauseScreen.Yandere.Shutter.Snapping && !this.PauseScreen.Yandere.TimeSkipping && !this.PauseScreen.Yandere.Talking && !this.PauseScreen.Yandere.Noticed && !this.PauseScreen.Yandere.InClass && !this.PauseScreen.Yandere.Struggling && !this.PauseScreen.Yandere.Won && !this.PauseScreen.Yandere.Dismembering && !this.PauseScreen.Yandere.Attacked && this.PauseScreen.Yandere.CanMove && !this.PauseScreen.Yandere.Chased && this.PauseScreen.Yandere.Chasers == 0 && !this.PauseScreen.Yandere.YandereVision && Time.timeScale > 0.0001f && !this.PauseScreen.Schedule.gameObject.activeInHierarchy)
				{
					if (this.DisplayTutorial)
					{
						this.PauseScreen.Yandere.StudentManager.TutorialWindow.SummonWindow();
						this.DisplayTutorial = false;
					}
					else
					{
						this.PauseScreen.ShowScheduleScreen();
						this.PauseScreen.Sideways = true;
						this.PauseScreen.Schedule.JumpToEvent(this.QuickID);
					}
					base.transform.localPosition = new Vector3(0.2043f, 0f, 1f);
					this.Speed = 5f;
				}
			}
		}
	}

	// Token: 0x040023F4 RID: 9204
	public PauseScreenScript PauseScreen;

	// Token: 0x040023F5 RID: 9205
	public AudioSource MyAudio;

	// Token: 0x040023F6 RID: 9206
	public float Speed = 10f;

	// Token: 0x040023F7 RID: 9207
	public float Timer;

	// Token: 0x040023F8 RID: 9208
	public int QuickID;

	// Token: 0x040023F9 RID: 9209
	public bool DisplayTutorial;

	// Token: 0x040023FA RID: 9210
	public bool Show;

	// Token: 0x040023FB RID: 9211
	public UIPanel MyPanel;
}
