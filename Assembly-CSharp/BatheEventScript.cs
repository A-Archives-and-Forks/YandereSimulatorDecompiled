﻿using System;
using UnityEngine;

// Token: 0x020000DD RID: 221
public class BatheEventScript : MonoBehaviour
{
	// Token: 0x06000A0F RID: 2575 RVA: 0x00056C43 File Offset: 0x00054E43
	private void Start()
	{
		this.RivalPhone.SetActive(false);
		if (DateGlobals.Weekday != this.EventDay)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06000A10 RID: 2576 RVA: 0x00056C68 File Offset: 0x00054E68
	private void Update()
	{
		if (!this.Clock.StopTime && !this.EventActive && this.Clock.HourTime > this.EventTime)
		{
			this.EventStudent = this.StudentManager.Students[30];
			if (this.EventStudent != null && !this.EventStudent.Distracted && !this.EventStudent.Talking && !this.EventStudent.Meeting && this.EventStudent.Indoors)
			{
				if (!this.EventStudent.WitnessedMurder)
				{
					this.OriginalPosition = this.EventStudent.Cosmetic.FemaleAccessories[3].transform.localPosition;
					this.EventStudent.CurrentDestination = this.StudentManager.FemaleStripSpot;
					this.EventStudent.Pathfinding.target = this.StudentManager.FemaleStripSpot;
					this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventStudent.WalkAnim);
					this.EventStudent.Pathfinding.canSearch = true;
					this.EventStudent.Pathfinding.canMove = true;
					this.EventStudent.Pathfinding.speed = 1f;
					this.EventStudent.SpeechLines.Stop();
					this.EventStudent.DistanceToDestination = 100f;
					this.EventStudent.SmartPhone.SetActive(false);
					this.EventStudent.Obstacle.checkTime = 99f;
					this.EventStudent.InEvent = true;
					this.EventStudent.Private = true;
					this.EventStudent.Prompt.Hide();
					this.EventStudent.Hearts.Stop();
					this.EventActive = true;
					if (this.EventStudent.Following)
					{
						this.EventStudent.Pathfinding.canMove = true;
						this.EventStudent.Pathfinding.speed = 1f;
						this.EventStudent.Following = false;
						this.EventStudent.Routine = true;
						this.Yandere.Follower = null;
						this.Yandere.Followers--;
						this.EventStudent.Subtitle.UpdateLabel(SubtitleType.StopFollowApology, 0, 3f);
						this.EventStudent.Prompt.Label[0].text = "     Talk";
					}
				}
				else
				{
					base.enabled = false;
				}
			}
		}
		if (this.EventActive)
		{
			if (this.Clock.HourTime > this.EventTime + 1f || this.EventStudent.WitnessedMurder || this.EventStudent.Splashed || this.EventStudent.Dodging || this.EventStudent.Alarmed || this.EventStudent.Dying || !this.EventStudent.Alive)
			{
				this.EndEvent();
				return;
			}
			if (this.EventStudent.DistanceToDestination < 0.5f)
			{
				if (this.EventPhase == 1)
				{
					this.EventStudent.Routine = false;
					this.EventStudent.BathePhase = 1;
					this.EventStudent.Wet = true;
					this.EventPhase++;
				}
				else if (this.EventPhase == 2)
				{
					if (this.EventStudent.BathePhase == 4)
					{
						this.RivalPhone.SetActive(true);
						this.EventPhase++;
					}
				}
				else if (this.EventPhase == 3 && !this.EventStudent.Wet)
				{
					this.EndEvent();
				}
			}
			if (this.EventPhase == 4)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > this.CurrentClipLength + 1f)
				{
					this.EventStudent.Routine = true;
					this.EndEvent();
				}
			}
			float num = Vector3.Distance(this.Yandere.transform.position, this.EventStudent.transform.position);
			if (num < 11f)
			{
				if (num < 10f)
				{
					float num2 = Mathf.Abs((num - 10f) * 0.2f);
					if (num2 < 0f)
					{
						num2 = 0f;
					}
					if (num2 > 1f)
					{
						num2 = 1f;
					}
					this.EventSubtitle.transform.localScale = new Vector3(num2, num2, num2);
					return;
				}
				this.EventSubtitle.transform.localScale = Vector3.zero;
			}
		}
	}

	// Token: 0x06000A11 RID: 2577 RVA: 0x000570E8 File Offset: 0x000552E8
	private void EndEvent()
	{
		if (!this.EventOver)
		{
			if (this.VoiceClip != null)
			{
				UnityEngine.Object.Destroy(this.VoiceClip);
			}
			this.EventStudent.CurrentDestination = this.EventStudent.Destinations[this.EventStudent.Phase];
			this.EventStudent.Pathfinding.target = this.EventStudent.Destinations[this.EventStudent.Phase];
			this.EventStudent.Obstacle.checkTime = 1f;
			if (!this.EventStudent.Dying)
			{
				this.EventStudent.Prompt.enabled = true;
				this.EventStudent.Pathfinding.canSearch = true;
				this.EventStudent.Pathfinding.canMove = true;
				this.EventStudent.Pathfinding.speed = 1f;
				this.EventStudent.TargetDistance = 1f;
				this.EventStudent.Private = false;
			}
			this.EventStudent.InEvent = false;
			this.EventSubtitle.text = string.Empty;
			this.StudentManager.UpdateStudents(0);
		}
		this.EventActive = false;
		base.enabled = false;
	}

	// Token: 0x04000ACC RID: 2764
	public StudentManagerScript StudentManager;

	// Token: 0x04000ACD RID: 2765
	public YandereScript Yandere;

	// Token: 0x04000ACE RID: 2766
	public ClockScript Clock;

	// Token: 0x04000ACF RID: 2767
	public StudentScript EventStudent;

	// Token: 0x04000AD0 RID: 2768
	public UILabel EventSubtitle;

	// Token: 0x04000AD1 RID: 2769
	public AudioClip[] EventClip;

	// Token: 0x04000AD2 RID: 2770
	public string[] EventSpeech;

	// Token: 0x04000AD3 RID: 2771
	public string[] EventAnim;

	// Token: 0x04000AD4 RID: 2772
	public GameObject RivalPhone;

	// Token: 0x04000AD5 RID: 2773
	public GameObject VoiceClip;

	// Token: 0x04000AD6 RID: 2774
	public bool EventActive;

	// Token: 0x04000AD7 RID: 2775
	public bool EventOver;

	// Token: 0x04000AD8 RID: 2776
	public float EventTime = 15.1f;

	// Token: 0x04000AD9 RID: 2777
	public int EventPhase = 1;

	// Token: 0x04000ADA RID: 2778
	public DayOfWeek EventDay = DayOfWeek.Thursday;

	// Token: 0x04000ADB RID: 2779
	public Vector3 OriginalPosition;

	// Token: 0x04000ADC RID: 2780
	public float CurrentClipLength;

	// Token: 0x04000ADD RID: 2781
	public float Timer;
}
