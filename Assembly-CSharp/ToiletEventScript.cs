﻿using System;
using UnityEngine;

// Token: 0x0200047C RID: 1148
public class ToiletEventScript : MonoBehaviour
{
	// Token: 0x06001EE1 RID: 7905 RVA: 0x001B2B9D File Offset: 0x001B0D9D
	private void Start()
	{
		this.EventSubtitle.transform.localScale = Vector3.zero;
		if (DateGlobals.Weekday == this.EventDay)
		{
			this.EventCheck = true;
		}
	}

	// Token: 0x06001EE2 RID: 7906 RVA: 0x001B2BC8 File Offset: 0x001B0DC8
	private void Update()
	{
		if (!this.Clock.StopTime && this.EventCheck && this.Clock.HourTime > this.EventTime)
		{
			this.EventStudent = this.StudentManager.Students[30];
			if (this.EventStudent != null && this.EventStudent.Routine && !this.EventStudent.Distracted && !this.EventStudent.Talking && !this.EventStudent.Alarmed && !this.EventStudent.Meeting)
			{
				if (!this.EventStudent.WitnessedMurder)
				{
					this.EventStudent.CharacterAnimation.CrossFade(this.EventStudent.WalkAnim);
					this.EventStudent.CurrentDestination = this.EventLocation[1];
					this.EventStudent.Pathfinding.target = this.EventLocation[1];
					this.EventStudent.Pathfinding.canSearch = true;
					this.EventStudent.Pathfinding.canMove = true;
					this.EventStudent.LightSwitch = this.LightSwitch;
					this.EventStudent.Obstacle.checkTime = 99f;
					this.EventStudent.SpeechLines.Stop();
					this.EventStudent.ToiletEvent = this;
					this.EventStudent.InEvent = true;
					this.EventStudent.Prompt.Hide();
					this.Prompt.enabled = true;
					this.EventCheck = false;
					this.EventActive = true;
					if (this.EventStudent.Following)
					{
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
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Yandere.EmptyHands();
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.EventPhase = 5;
				this.Timer = 0f;
				AudioClipPlayer.Play(this.EventClip[1], this.EventStudent.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip);
				this.EventSubtitle.text = this.EventSpeech[1];
				this.EventStudent.MyController.enabled = false;
				this.EventStudent.Distracted = true;
				this.EventStudent.Routine = false;
				this.EventStudent.Drowned = true;
				this.Yandere.TargetStudent = this.EventStudent;
				this.Yandere.Attacking = true;
				this.Yandere.CanMove = false;
				this.Yandere.Drown = true;
				this.Yandere.DrownAnim = "f02_toiletDrownA_00";
				this.EventStudent.DrownAnim = "f02_toiletDrownB_00";
				this.EventStudent.CharacterAnimation.CrossFade(this.EventStudent.DrownAnim);
			}
			if (this.Clock.HourTime > this.EventTime + 0.5f || this.EventStudent.WitnessedMurder || this.EventStudent.Splashed || this.EventStudent.Dying || this.EventStudent.Alarmed)
			{
				this.EndEvent();
			}
			else if (!this.EventStudent.Pathfinding.canMove)
			{
				if (this.EventPhase == 1)
				{
					if (this.Timer == 0f)
					{
						this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventStudent.IdleAnim);
						this.Prompt.HideButton[0] = false;
						this.EventStudent.Prompt.Hide();
						this.EventStudent.Prompt.enabled = false;
						this.StallDoor.Prompt.enabled = false;
						this.StallDoor.Prompt.Hide();
					}
					this.Timer += Time.deltaTime;
					if (this.Timer > 3f)
					{
						this.StallDoor.Locked = true;
						this.StallDoor.CloseDoor();
						this.Toilet.enabled = false;
						this.Prompt.Hide();
						this.Prompt.enabled = false;
						this.EventStudent.CurrentDestination = this.EventLocation[2];
						this.EventStudent.Pathfinding.target = this.EventLocation[2];
						this.EventStudent.TargetDistance = 2f;
						this.EventPhase++;
						this.Timer = 0f;
					}
				}
				else if (this.EventPhase == 2)
				{
					if (this.Timer == 0f)
					{
						this.EventStudent.Character.GetComponent<Animation>().CrossFade(this.EventAnim[1]);
						this.BucketPour.enabled = true;
					}
					this.Timer += Time.deltaTime;
					if (this.Timer > 10f)
					{
						AudioClipPlayer.Play(this.EventClip[2], this.Toilet.transform.position, 5f, 10f, out this.VoiceClip);
						this.EventPhase++;
						this.Timer = 0f;
					}
				}
				else if (this.EventPhase == 3)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > 4f)
					{
						this.EventStudent.CurrentDestination = this.EventLocation[3];
						this.EventStudent.Pathfinding.target = this.EventLocation[3];
						this.EventStudent.TargetDistance = 2f;
						this.StallDoor.gameObject.SetActive(true);
						this.StallDoor.Prompt.enabled = true;
						this.StallDoor.Locked = false;
						this.EventPhase++;
						this.Timer = 0f;
					}
				}
				else if (this.EventPhase == 4)
				{
					this.EventStudent.Character.GetComponent<Animation>().CrossFade("f02_washHands_00");
					this.Timer += Time.deltaTime;
					if (this.Timer > 5f)
					{
						this.EndEvent();
					}
				}
				else if (this.EventPhase == 5)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer > 9f)
					{
						this.Splashes.Stop();
						this.EventOver = true;
						this.EndEvent();
					}
					else if (this.Timer > 3f)
					{
						this.EventSubtitle.text = string.Empty;
						this.Splashes.Play();
					}
				}
				this.Distance = Vector3.Distance(this.Yandere.transform.position, this.EventStudent.transform.position);
				if (this.Distance < 10f)
				{
					float num = Mathf.Abs((this.Distance - 10f) * 0.2f);
					if (num < 0f)
					{
						num = 0f;
					}
					if (num > 1f)
					{
						num = 1f;
					}
					this.EventSubtitle.transform.localScale = new Vector3(num, num, num);
				}
				else
				{
					this.EventSubtitle.transform.localScale = Vector3.zero;
				}
			}
		}
		if (this.ToiletCountdown > 0f)
		{
			this.ToiletCountdown -= Time.deltaTime;
			if (this.ToiletCountdown < 0f)
			{
				this.Toilet.enabled = true;
			}
		}
	}

	// Token: 0x06001EE3 RID: 7907 RVA: 0x001B33F4 File Offset: 0x001B15F4
	public void EndEvent()
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
			}
			this.EventStudent.TargetDistance = 1f;
			this.EventStudent.ToiletEvent = null;
			this.EventStudent.InEvent = false;
			this.EventStudent.Private = false;
			this.EventSubtitle.text = string.Empty;
			this.StudentManager.UpdateStudents(0);
		}
		this.StallDoor.gameObject.SetActive(true);
		this.StallDoor.Prompt.enabled = true;
		this.StallDoor.Locked = false;
		this.BucketPour.enabled = false;
		this.BucketPour.Prompt.Hide();
		this.BucketPour.Prompt.enabled = false;
		this.EventActive = false;
		this.EventCheck = false;
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.ToiletCountdown = 1f;
	}

	// Token: 0x04004026 RID: 16422
	public StudentManagerScript StudentManager;

	// Token: 0x04004027 RID: 16423
	public LightSwitchScript LightSwitch;

	// Token: 0x04004028 RID: 16424
	public BucketPourScript BucketPour;

	// Token: 0x04004029 RID: 16425
	public ParticleSystem Splashes;

	// Token: 0x0400402A RID: 16426
	public UILabel EventSubtitle;

	// Token: 0x0400402B RID: 16427
	public YandereScript Yandere;

	// Token: 0x0400402C RID: 16428
	public DoorScript StallDoor;

	// Token: 0x0400402D RID: 16429
	public PromptScript Prompt;

	// Token: 0x0400402E RID: 16430
	public ClockScript Clock;

	// Token: 0x0400402F RID: 16431
	public Collider Toilet;

	// Token: 0x04004030 RID: 16432
	public StudentScript EventStudent;

	// Token: 0x04004031 RID: 16433
	public Transform[] EventLocation;

	// Token: 0x04004032 RID: 16434
	public AudioClip[] EventClip;

	// Token: 0x04004033 RID: 16435
	public string[] EventSpeech;

	// Token: 0x04004034 RID: 16436
	public string[] EventAnim;

	// Token: 0x04004035 RID: 16437
	public GameObject VoiceClip;

	// Token: 0x04004036 RID: 16438
	public bool EventActive;

	// Token: 0x04004037 RID: 16439
	public bool EventCheck;

	// Token: 0x04004038 RID: 16440
	public bool EventOver;

	// Token: 0x04004039 RID: 16441
	public float EventTime = 7f;

	// Token: 0x0400403A RID: 16442
	public int EventPhase = 1;

	// Token: 0x0400403B RID: 16443
	public DayOfWeek EventDay = DayOfWeek.Thursday;

	// Token: 0x0400403C RID: 16444
	public float ToiletCountdown;

	// Token: 0x0400403D RID: 16445
	public float Distance;

	// Token: 0x0400403E RID: 16446
	public float Timer;
}
