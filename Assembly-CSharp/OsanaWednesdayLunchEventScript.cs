﻿using System;
using UnityEngine;

// Token: 0x020003E0 RID: 992
public class OsanaWednesdayLunchEventScript : MonoBehaviour
{
	// Token: 0x06001BA5 RID: 7077 RVA: 0x0013F208 File Offset: 0x0013D408
	private void Start()
	{
		this.EventSubtitle.transform.localScale = Vector3.zero;
		if (DateGlobals.Weekday != this.EventDay || GameGlobals.RivalEliminationID > 0)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001BA6 RID: 7078 RVA: 0x0013F23C File Offset: 0x0013D43C
	private void Update()
	{
		if (this.Phase == 0)
		{
			if (this.Frame > 0 && this.StudentManager.Students[this.RivalID] != null)
			{
				if (this.Rival == null)
				{
					this.Rival = this.StudentManager.Students[this.RivalID];
				}
				if (this.Rival.Bullied)
				{
					base.enabled = false;
				}
				else if ((this.Clock.Period == 3 || this.Clock.Period == 6) && this.Rival.enabled && !this.Rival.InEvent && !this.Rival.Phoneless)
				{
					Debug.Log("Osana's Wednesday lunchtime event has begun.");
					this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					this.Rival.CharacterAnimation.Play(this.Rival.WalkAnim);
					this.Rival.Pathfinding.target = this.Location;
					this.Rival.CurrentDestination = this.Location;
					this.Rival.Pathfinding.canSearch = true;
					this.Rival.Pathfinding.canMove = true;
					this.Rival.Routine = false;
					this.Rival.InEvent = true;
					this.Rival.EmptyHands();
					this.StartPeriod = this.Clock.Period;
					this.Yandere.PauseScreen.Hint.Show = true;
					this.Yandere.PauseScreen.Hint.QuickID = 17;
					this.Phase++;
				}
			}
			this.Frame++;
			return;
		}
		if (this.Phase == 1)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				this.Yandere.transform.position = this.Location.position + new Vector3(2f, 0f, 2f);
				this.Rival.transform.position = this.Location.position + new Vector3(1f, 0f, 1f);
			}
			if (this.Rival.DistanceToDestination < 0.5f)
			{
				AudioClipPlayer.Play(this.SpeechClip, this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
				this.EventSubtitle.text = this.SpeechText;
				this.Rival.CharacterAnimation.CrossFade("f02_" + this.EventAnim);
				this.Rival.Pathfinding.canSearch = false;
				this.Rival.Pathfinding.canMove = false;
				this.Rival.Obstacle.enabled = true;
				this.Phase++;
			}
		}
		else if (this.Phase == 2)
		{
			if ((double)this.Rival.CharacterAnimation["f02_" + this.EventAnim].time >= 1.33333)
			{
				this.Rival.SmartPhone.SetActive(true);
				this.Phase++;
			}
		}
		else if (this.Phase == 3)
		{
			if ((double)this.Rival.CharacterAnimation["f02_" + this.EventAnim].time >= 6.833333)
			{
				this.Rival.SmartPhone.SetActive(false);
				this.Phase++;
			}
		}
		else if (this.Phase == 4 && this.Rival.CharacterAnimation["f02_" + this.EventAnim].time >= this.Rival.CharacterAnimation["f02_" + this.EventAnim].length)
		{
			this.EndEvent();
		}
		if (this.Clock.Period > this.StartPeriod || this.Rival.Alarmed || this.Rival.Splashed)
		{
			this.EndEvent();
		}
		this.Distance = Vector3.Distance(this.Yandere.transform.position, this.Rival.transform.position);
		if (this.Distance - 4f < 15f)
		{
			this.Scale = Mathf.Abs(1f - (this.Distance - 4f) / 15f);
			if (this.Scale < 0f)
			{
				this.Scale = 0f;
			}
			if (this.Scale > 1f)
			{
				this.Scale = 1f;
			}
			this.Jukebox.Dip = 1f - 0.5f * this.Scale;
			this.EventSubtitle.transform.localScale = new Vector3(this.Scale, this.Scale, this.Scale);
			if (this.VoiceClip != null)
			{
				this.VoiceClip.GetComponent<AudioSource>().volume = this.Scale;
			}
		}
		else
		{
			this.EventSubtitle.transform.localScale = Vector3.zero;
			if (this.VoiceClip != null)
			{
				this.VoiceClip.GetComponent<AudioSource>().volume = 0f;
			}
		}
		if (this.VoiceClip == null)
		{
			this.EventSubtitle.text = string.Empty;
		}
	}

	// Token: 0x06001BA7 RID: 7079 RVA: 0x0013F804 File Offset: 0x0013DA04
	private void EndEvent()
	{
		Debug.Log("Osana's Wednesday lunchtime event has ended.");
		if (this.VoiceClip != null)
		{
			UnityEngine.Object.Destroy(this.VoiceClip);
		}
		if (!this.Rival.Alarmed)
		{
			this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
			this.Rival.DistanceToDestination = 100f;
			this.Rival.Pathfinding.canSearch = true;
			this.Rival.Pathfinding.canMove = true;
			this.Rival.Routine = true;
		}
		this.Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
		this.Rival.Obstacle.enabled = false;
		this.Rival.Prompt.enabled = true;
		this.Rival.InEvent = false;
		this.Rival.Private = false;
		if (!this.StudentManager.Stop)
		{
			this.StudentManager.UpdateStudents(0);
		}
		this.Jukebox.Dip = 1f;
		this.EventSubtitle.text = string.Empty;
		base.enabled = false;
	}

	// Token: 0x0400302C RID: 12332
	public StudentManagerScript StudentManager;

	// Token: 0x0400302D RID: 12333
	public JukeboxScript Jukebox;

	// Token: 0x0400302E RID: 12334
	public UILabel EventSubtitle;

	// Token: 0x0400302F RID: 12335
	public YandereScript Yandere;

	// Token: 0x04003030 RID: 12336
	public ClockScript Clock;

	// Token: 0x04003031 RID: 12337
	public StudentScript Rival;

	// Token: 0x04003032 RID: 12338
	public Transform Location;

	// Token: 0x04003033 RID: 12339
	public AudioClip SpeechClip;

	// Token: 0x04003034 RID: 12340
	public string SpeechText;

	// Token: 0x04003035 RID: 12341
	public string EventAnim;

	// Token: 0x04003036 RID: 12342
	public GameObject AlarmDisc;

	// Token: 0x04003037 RID: 12343
	public GameObject VoiceClip;

	// Token: 0x04003038 RID: 12344
	public float Distance;

	// Token: 0x04003039 RID: 12345
	public float Scale;

	// Token: 0x0400303A RID: 12346
	public DayOfWeek EventDay;

	// Token: 0x0400303B RID: 12347
	public int StartPeriod;

	// Token: 0x0400303C RID: 12348
	public int RivalID = 11;

	// Token: 0x0400303D RID: 12349
	public int Phase;

	// Token: 0x0400303E RID: 12350
	public int Frame;
}
