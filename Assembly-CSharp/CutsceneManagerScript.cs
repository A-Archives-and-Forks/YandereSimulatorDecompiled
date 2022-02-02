﻿using System;
using UnityEngine;

// Token: 0x0200026C RID: 620
public class CutsceneManagerScript : MonoBehaviour
{
	// Token: 0x06001327 RID: 4903 RVA: 0x000AAA38 File Offset: 0x000A8C38
	private void Update()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		if (this.Phase == 1)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
			if (this.Darkness.color.a == 1f)
			{
				if (this.Scheme == 5)
				{
					this.Phase++;
					return;
				}
				this.Phase = 4;
				return;
			}
		}
		else
		{
			if (this.Phase == 2)
			{
				this.Subtitle.text = this.Text[this.Line];
				component.clip = this.Voice[this.Line];
				component.Play();
				this.Phase++;
				return;
			}
			if (this.Phase == 3)
			{
				if (!component.isPlaying || Input.GetButtonDown("A"))
				{
					if (this.Line < 2)
					{
						this.Phase--;
						this.Line++;
						return;
					}
					this.Subtitle.text = string.Empty;
					this.Phase++;
					return;
				}
			}
			else
			{
				if (this.Phase == 4)
				{
					Debug.Log("We're activating EndOfDay from CutsceneManager.");
					this.EndOfDay.gameObject.SetActive(true);
					this.EndOfDay.Phase = 14;
					if (this.Scheme == 5)
					{
						this.Counselor.LecturePhase = 5;
					}
					else
					{
						this.Counselor.LecturePhase = 1;
					}
					this.Phase++;
					return;
				}
				if (this.Phase == 6)
				{
					this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
					if (this.Darkness.color.a == 0f)
					{
						this.Phase++;
						return;
					}
				}
				else if (this.Phase == 7)
				{
					if (this.Scheme == 5)
					{
						this.StudentManager.Students[this.StudentManager.RivalID] != null;
					}
					this.PromptBar.ClearButtons();
					this.PromptBar.Show = false;
					this.Portal.Proceed = true;
					base.gameObject.SetActive(false);
					this.Scheme = 0;
				}
			}
		}
	}

	// Token: 0x04001B55 RID: 6997
	public StudentManagerScript StudentManager;

	// Token: 0x04001B56 RID: 6998
	public CounselorScript Counselor;

	// Token: 0x04001B57 RID: 6999
	public PromptBarScript PromptBar;

	// Token: 0x04001B58 RID: 7000
	public EndOfDayScript EndOfDay;

	// Token: 0x04001B59 RID: 7001
	public PortalScript Portal;

	// Token: 0x04001B5A RID: 7002
	public UISprite Darkness;

	// Token: 0x04001B5B RID: 7003
	public UILabel Subtitle;

	// Token: 0x04001B5C RID: 7004
	public AudioClip[] Voice;

	// Token: 0x04001B5D RID: 7005
	public string[] Text;

	// Token: 0x04001B5E RID: 7006
	public int Scheme;

	// Token: 0x04001B5F RID: 7007
	public int Phase = 1;

	// Token: 0x04001B60 RID: 7008
	public int Line = 1;
}
