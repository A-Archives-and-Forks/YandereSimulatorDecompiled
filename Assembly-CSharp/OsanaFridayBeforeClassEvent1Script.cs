﻿using System;
using UnityEngine;

// Token: 0x020003DB RID: 987
public class OsanaFridayBeforeClassEvent1Script : MonoBehaviour
{
	// Token: 0x06001B89 RID: 7049 RVA: 0x0013839C File Offset: 0x0013659C
	private void Start()
	{
		this.EventSubtitle.transform.localScale = Vector3.zero;
		if (DateGlobals.Weekday != this.EventDay || StudentGlobals.StudentSlave == this.RivalID || this.StudentManager.RivalEliminated || GameGlobals.Eighties)
		{
			base.enabled = false;
		}
		this.Yoogle.SetActive(false);
	}

	// Token: 0x06001B8A RID: 7050 RVA: 0x00138400 File Offset: 0x00136600
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
				if (this.Rival.enabled && !this.Rival.InEvent && !this.Rival.Phoneless && this.Rival.Indoors && !this.OtherEvent.enabled)
				{
					Debug.Log("Osana's ''make playlist'' event has begun.");
					this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
					this.Rival.CharacterAnimation.Play(this.Rival.WalkAnim);
					this.Rival.Pathfinding.target = this.Location;
					this.Rival.CurrentDestination = this.Location;
					this.Rival.Pathfinding.canSearch = true;
					this.Rival.Pathfinding.canMove = true;
					this.Rival.Routine = false;
					this.Rival.InEvent = true;
					this.Yandere.PauseScreen.Hint.Show = true;
					this.Yandere.PauseScreen.Hint.QuickID = 15;
					this.Phase++;
				}
			}
			this.Frame++;
			return;
		}
		if (this.Phase == 1)
		{
			if (this.Rival.DistanceToDestination < 0.5f)
			{
				AudioClipPlayer.Play(this.SpeechClip[1], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
				this.EventSubtitle.text = this.SpeechText[1];
				this.Rival.CharacterAnimation.CrossFade(this.EventAnim);
				this.Rival.Pathfinding.canSearch = false;
				this.Rival.Pathfinding.canMove = false;
				this.Rival.Obstacle.enabled = true;
				this.Rival.Distracted = true;
				this.Yoogle.SetActive(true);
				this.Phase++;
			}
		}
		else if (this.Phase == 2)
		{
			this.Rival.MoveTowardsTarget(this.Location.position);
			if (Quaternion.Angle(this.Rival.transform.rotation, this.Location.rotation) > 1f)
			{
				this.Rival.transform.rotation = Quaternion.Slerp(this.Rival.transform.rotation, this.Location.rotation, 10f * Time.deltaTime);
			}
			this.Timer += Time.deltaTime;
			if (Input.GetKeyDown("space"))
			{
				this.Timer += 60f;
			}
			if (this.Timer > 60f)
			{
				this.EndEvent();
			}
		}
		if (this.Rival.Alarmed || this.Clock.HourTime > 8f || this.Rival.Splashed || this.Rival.Dodging)
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

	// Token: 0x06001B8B RID: 7051 RVA: 0x001388F4 File Offset: 0x00136AF4
	public void EndEvent()
	{
		Debug.Log("Osana's Friday before class event has ended.");
		if (this.VoiceClip != null)
		{
			UnityEngine.Object.Destroy(this.VoiceClip);
		}
		if (this.Rival != null)
		{
			if (this.Rival.enabled && !this.Rival.Alarmed && !this.Rival.Splashed)
			{
				this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
				this.Rival.DistanceToDestination = 100f;
				this.Rival.CurrentDestination = this.Rival.Destinations[this.Rival.Phase];
				this.Rival.Pathfinding.target = this.Rival.Destinations[this.Rival.Phase];
				this.Rival.Pathfinding.canSearch = true;
				this.Rival.Pathfinding.canMove = true;
				this.Rival.Routine = true;
			}
			this.Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
			this.Rival.SmartPhoneScreen.enabled = false;
			this.Rival.Ragdoll.Zs.SetActive(false);
			this.Rival.Obstacle.enabled = false;
			this.Rival.Prompt.enabled = true;
			this.Rival.Distracted = false;
			this.Rival.InEvent = false;
			this.Rival.Private = false;
			this.Yoogle.SetActive(false);
			this.Rival.SmartPhone.transform.parent = this.Rival.ItemParent;
			this.Rival.SmartPhone.transform.localPosition = this.OriginalPosition;
			this.Rival.SmartPhone.transform.localEulerAngles = this.OriginalRotation;
		}
		if (!this.StudentManager.Stop)
		{
			this.StudentManager.UpdateStudents(0);
		}
		this.Jukebox.Dip = 1f;
		this.EventSubtitle.text = string.Empty;
		base.enabled = false;
	}

	// Token: 0x04002F26 RID: 12070
	public OsanaFridayBeforeClassEvent2Script OtherEvent;

	// Token: 0x04002F27 RID: 12071
	public StudentManagerScript StudentManager;

	// Token: 0x04002F28 RID: 12072
	public JukeboxScript Jukebox;

	// Token: 0x04002F29 RID: 12073
	public UILabel EventSubtitle;

	// Token: 0x04002F2A RID: 12074
	public YandereScript Yandere;

	// Token: 0x04002F2B RID: 12075
	public ClockScript Clock;

	// Token: 0x04002F2C RID: 12076
	public StudentScript Rival;

	// Token: 0x04002F2D RID: 12077
	public Transform Location;

	// Token: 0x04002F2E RID: 12078
	public AudioClip[] SpeechClip;

	// Token: 0x04002F2F RID: 12079
	public string[] SpeechText;

	// Token: 0x04002F30 RID: 12080
	public string EventAnim;

	// Token: 0x04002F31 RID: 12081
	public GameObject AlarmDisc;

	// Token: 0x04002F32 RID: 12082
	public GameObject VoiceClip;

	// Token: 0x04002F33 RID: 12083
	public GameObject Yoogle;

	// Token: 0x04002F34 RID: 12084
	public float Distance;

	// Token: 0x04002F35 RID: 12085
	public float Scale;

	// Token: 0x04002F36 RID: 12086
	public float Timer;

	// Token: 0x04002F37 RID: 12087
	public DayOfWeek EventDay;

	// Token: 0x04002F38 RID: 12088
	public int RivalID = 11;

	// Token: 0x04002F39 RID: 12089
	public int Phase;

	// Token: 0x04002F3A RID: 12090
	public int Frame;

	// Token: 0x04002F3B RID: 12091
	public Vector3 OriginalPosition;

	// Token: 0x04002F3C RID: 12092
	public Vector3 OriginalRotation;
}
