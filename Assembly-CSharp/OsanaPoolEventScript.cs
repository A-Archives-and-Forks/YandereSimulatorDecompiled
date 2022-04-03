﻿using System;
using UnityEngine;

// Token: 0x02000389 RID: 905
public class OsanaPoolEventScript : MonoBehaviour
{
	// Token: 0x06001A45 RID: 6725 RVA: 0x00116655 File Offset: 0x00114855
	private void Start()
	{
		if (GameGlobals.Eighties || DateGlobals.Weekday != this.EventDay)
		{
			base.enabled = false;
		}
	}

	// Token: 0x06001A46 RID: 6726 RVA: 0x00116674 File Offset: 0x00114874
	private void Update()
	{
		if (this.Phase == 0)
		{
			if (this.Frame > 0 && this.StudentManager.Students[this.RivalID] != null && this.StudentManager.Students[this.RivalID].enabled && this.Clock.Period == 3)
			{
				Debug.Log("Osana's pool event has begun.");
				if (this.StudentManager.Students[this.FriendID] != null && this.StudentManager.Students[this.FriendID].FollowTarget != null)
				{
					this.Friend = this.StudentManager.Students[this.FriendID];
					if (this.Friend != null)
					{
						this.Friend.CanTalk = false;
					}
				}
				this.Rival = this.StudentManager.Students[this.RivalID];
				this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				this.Rival.MyRenderer.updateWhenOffscreen = true;
				this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
				this.Rival.Pathfinding.target = this.StudentManager.FemaleStripSpot;
				this.Rival.CurrentDestination = this.StudentManager.FemaleStripSpot;
				this.Rival.Pathfinding.canSearch = true;
				this.Rival.Pathfinding.canMove = true;
				this.Rival.Pen.SetActive(false);
				this.Rival.Routine = false;
				this.Rival.InEvent = true;
				this.Rival.SmartPhone.SetActive(false);
				this.Yandere.PauseScreen.Hint.Show = true;
				this.Yandere.PauseScreen.Hint.QuickID = 17;
				this.Phase++;
			}
			this.Frame++;
			return;
		}
		if (this.Phase == 1)
		{
			if (this.Rival.DistanceToDestination < 0.5f)
			{
				if (this.StudentManager.CommunalLocker.Student == null)
				{
					this.Rival.StudentManager.CommunalLocker.Open = true;
					this.Rival.StudentManager.CommunalLocker.Student = this.Rival;
					this.Rival.StudentManager.CommunalLocker.SpawnSteam();
					this.Rival.Schoolwear = 2;
					this.Phase++;
				}
				else
				{
					this.Rival.CharacterAnimation.CrossFade(this.Rival.IdleAnim);
				}
			}
		}
		else if (this.Phase == 2)
		{
			if (!this.Rival.StudentManager.CommunalLocker.SteamCountdown)
			{
				this.StudentManager.CommunalLocker.Student = null;
				if (this.Friend != null)
				{
					ScheduleBlock scheduleBlock = this.Friend.ScheduleBlocks[this.Friend.Phase];
					scheduleBlock.destination = "Sunbathe";
					scheduleBlock.action = "Sunbathe";
					this.Friend.Actions[this.Friend.Phase] = StudentActionType.Sunbathe;
					this.Friend.CurrentAction = StudentActionType.Sunbathe;
					this.Friend.GetDestinations();
					this.Friend.CurrentDestination = this.StudentManager.FemaleStripSpot;
					this.Friend.Pathfinding.target = this.StudentManager.FemaleStripSpot;
					this.Friend.Pathfinding.canSearch = true;
					this.Friend.Pathfinding.canMove = true;
				}
				this.Rival.Pathfinding.target = this.Location[1];
				this.Rival.CurrentDestination = this.Location[1];
				this.Phase++;
			}
		}
		else if (this.Phase == 3)
		{
			if (this.Rival.DistanceToDestination < 0.5f)
			{
				AudioClipPlayer.Play(this.SpeechClip[1], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
				this.EventSubtitle.text = this.SpeechText[1];
				this.Rival.CharacterAnimation["f02_" + this.EventAnim[1]].time = 0f;
				this.Rival.CharacterAnimation.Play("f02_" + this.EventAnim[1]);
				this.Rival.OsanaHair.GetComponent<Animation>().Play("Hair_" + this.EventAnim[1]);
				this.Rival.OsanaHair.transform.parent = this.Rival.transform;
				this.Rival.OsanaHair.transform.localEulerAngles = Vector3.zero;
				this.Rival.OsanaHair.transform.localPosition = Vector3.zero;
				this.Rival.OsanaHair.transform.localScale = new Vector3(1f, 1f, 1f);
				this.Rival.OsanaHairL.enabled = false;
				this.Rival.OsanaHairR.enabled = false;
				this.Rival.Pathfinding.canSearch = false;
				this.Rival.Pathfinding.canMove = false;
				this.Rival.Pathfinding.speed = 0f;
				this.Phase++;
			}
			else
			{
				this.Rival.Pathfinding.canSearch = true;
				this.Rival.Pathfinding.canMove = true;
				this.Rival.Pathfinding.speed = 1f;
				this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
			}
		}
		else if (this.Phase == 4)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 5.53333f)
			{
				this.Rival.CharacterAnimation.CrossFade("f02_" + this.EventAnim[2]);
				this.Rival.OsanaHair.GetComponent<Animation>().CrossFade("Hair_" + this.EventAnim[2]);
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 5)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 10f)
			{
				AudioClipPlayer.Play(this.SpeechClip[2], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
				this.EventSubtitle.text = this.SpeechText[2];
				this.Rival.CharacterAnimation.CrossFade("f02_" + this.EventAnim[3]);
				this.Rival.OsanaHair.GetComponent<Animation>().CrossFade("Hair_" + this.EventAnim[3]);
				this.Rival.Ragdoll.Zs.SetActive(true);
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 6)
		{
			if (this.MurderPhase < 2)
			{
				this.Timer += Time.deltaTime;
				if (this.Clock.HourTime > 13.375f)
				{
					AudioClipPlayer.Play(this.SpeechClip[3], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
					this.EventSubtitle.text = this.SpeechText[3];
					this.Rival.CharacterAnimation.CrossFade("f02_" + this.EventAnim[2]);
					this.Rival.OsanaHair.GetComponent<Animation>().CrossFade("Hair_" + this.EventAnim[2]);
					this.Prompt.Hide();
					this.Prompt.gameObject.SetActive(false);
					this.Rival.Ragdoll.Zs.SetActive(false);
					this.Timer = 0f;
					this.Phase++;
				}
			}
		}
		else if (this.Phase == 7)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 5f)
			{
				AudioClipPlayer.Play(this.SpeechClip[4], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
				this.EventSubtitle.text = this.SpeechText[4];
				this.Rival.CharacterAnimation.CrossFade("f02_" + this.EventAnim[4]);
				this.Rival.OsanaHair.GetComponent<Animation>().CrossFade("Hair_" + this.EventAnim[4]);
				this.Timer = 0f;
				this.Phase++;
			}
		}
		else if (this.Phase == 8)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 4.33333f)
			{
				this.Rival.OsanaHair.GetComponent<Animation>().Stop();
				this.Rival.OsanaHair.transform.parent = this.Rival.Head;
				this.Rival.OsanaHair.transform.localEulerAngles = Vector3.zero;
				this.Rival.OsanaHair.transform.localPosition = new Vector3(0f, -1.442789f, 0.01900469f);
				this.Rival.OsanaHair.transform.localScale = new Vector3(1f, 1f, 1f);
				this.Rival.OsanaHairL.enabled = true;
				this.Rival.OsanaHairR.enabled = true;
				this.Rival.Pathfinding.target = this.StudentManager.FemaleStripSpot;
				this.Rival.CurrentDestination = this.StudentManager.FemaleStripSpot;
				this.Rival.CharacterAnimation.CrossFade(this.Rival.WalkAnim);
				if (this.Friend != null)
				{
					ScheduleBlock scheduleBlock2 = this.Friend.ScheduleBlocks[this.Friend.Phase];
					scheduleBlock2.destination = "Follow";
					scheduleBlock2.action = "Follow";
					this.Friend.GetDestinations();
					this.Friend.CurrentDestination = this.Friend.FollowTarget.transform;
					this.Friend.Pathfinding.target = this.Friend.FollowTarget.transform;
					this.Friend.Pathfinding.canSearch = true;
					this.Friend.Pathfinding.canMove = true;
				}
				this.Phase++;
			}
		}
		else if (this.Phase == 9)
		{
			if (this.Rival.DistanceToDestination < 0.5f)
			{
				if (this.StudentManager.CommunalLocker.Student == null)
				{
					this.Rival.StudentManager.CommunalLocker.Open = true;
					this.Rival.StudentManager.CommunalLocker.Student = this.Rival;
					this.Rival.StudentManager.CommunalLocker.SpawnSteam();
					this.Rival.Schoolwear = 1;
					if (this.Friend != null)
					{
						this.StudentManager.CommunalLocker.SpawnSteamNoSideEffects(this.Friend);
					}
					this.Phase++;
				}
				else
				{
					this.Rival.CharacterAnimation.CrossFade(this.Rival.IdleAnim);
				}
			}
		}
		else if (this.Phase == 10 && !this.Rival.StudentManager.CommunalLocker.SteamCountdown)
		{
			this.Rival.StudentManager.CommunalLocker.Student = null;
			this.EndEvent();
		}
		if (this.Phase == 6)
		{
			if (this.Yandere.PickUp != null)
			{
				this.Prompt.enabled = this.Yandere.PickUp.Weight;
			}
			else
			{
				this.Prompt.enabled = false;
			}
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Hide();
			this.Prompt.gameObject.SetActive(false);
			this.Murdering = true;
			this.Rival.Blind = true;
			this.Yandere.CanMove = false;
			this.Rival.Ragdoll.Zs.SetActive(false);
			this.Yandere.MurderousActionTimer = 999f;
			this.Yandere.CharacterAnimation.CrossFade("f02_" + this.EventAnim[5]);
			this.Rival.CharacterAnimation.CrossFade("f02_" + this.EventAnim[6]);
			this.Rival.OsanaHair.GetComponent<Animation>().CrossFade("Hair_" + this.EventAnim[6]);
		}
		if (this.Murdering)
		{
			this.Yandere.MoveTowardsTarget(this.Location[2].position);
			this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.Location[2].rotation, Time.deltaTime * 10f);
			if (this.Yandere.CharacterAnimation["f02_" + this.EventAnim[5]].time > 1f && this.Weight.transform.parent != this.Location[3])
			{
				this.Yandere.EmptyHands();
				this.Weight.transform.parent = this.Location[3];
				this.Weight.transform.localPosition = Vector3.zero;
				this.Weight.transform.localEulerAngles = Vector3.zero;
				this.Weight.GetComponent<Animation>().Play("Weight_" + this.EventAnim[5]);
				this.Weight.GetComponent<Animation>()["Weight_" + this.EventAnim[5]].time = this.Yandere.CharacterAnimation["f02_" + this.EventAnim[5]].time;
			}
			if (this.MurderPhase == 1)
			{
				if (this.Yandere.CharacterAnimation["f02_" + this.EventAnim[5]].time > 10f)
				{
					this.Rival.SpawnAlarmDisc();
					AudioClipPlayer.Play(this.SpeechClip[5], this.Rival.transform.position + Vector3.up * 1.5f, 5f, 10f, out this.VoiceClip, this.Yandere.transform.position.y);
					this.EventSubtitle.text = this.SpeechText[5];
					this.MurderPhase++;
				}
			}
			else if (this.MurderPhase == 2)
			{
				if (this.Yandere.CharacterAnimation["f02_" + this.EventAnim[5]].time > 14.5f)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BigSplash, this.Location[4].position, Quaternion.identity);
					gameObject.transform.eulerAngles = new Vector3(-90f, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
					this.MurderPhase++;
				}
			}
			else if (this.MurderPhase == 3 && this.Yandere.CharacterAnimation["f02_" + this.EventAnim[5]].time > 14.833333f)
			{
				GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.BigSplash, this.Location[4].position, Quaternion.identity);
				gameObject2.transform.eulerAngles = new Vector3(-90f, gameObject2.transform.eulerAngles.y, gameObject2.transform.eulerAngles.z);
				this.MurderPhase++;
			}
			if (this.Yandere.CharacterAnimation["f02_" + this.EventAnim[5]].time > this.Yandere.CharacterAnimation["f02_" + this.EventAnim[5]].length)
			{
				this.Yandere.MurderousActionTimer = 0f;
				this.Yandere.CanMove = true;
				this.Murdering = false;
				this.Rival.NoRagdoll = true;
				this.Rival.BecomeRagdoll();
				this.Rival.DeathType = DeathType.Drowning;
				this.Yandere.Police.EndOfDay.PoolEvent = true;
			}
		}
		if (this.Clock.HourTime > 13.5f || this.Rival.Alarmed || this.Rival.Splashed)
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

	// Token: 0x06001A47 RID: 6727 RVA: 0x00117A84 File Offset: 0x00115C84
	public void EndEvent()
	{
		Debug.Log("Osana's pool event has ended.");
		if (this.VoiceClip != null)
		{
			UnityEngine.Object.Destroy(this.VoiceClip);
		}
		if (!this.Rival.Alarmed)
		{
			this.Rival.Pathfinding.canSearch = true;
			this.Rival.Pathfinding.canMove = true;
			this.Rival.Routine = true;
		}
		this.Rival.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
		this.Rival.MyRenderer.updateWhenOffscreen = false;
		this.Rival.Ragdoll.Zs.SetActive(false);
		this.Rival.Obstacle.enabled = false;
		this.Rival.Prompt.enabled = true;
		this.Rival.InEvent = false;
		this.Rival.Private = false;
		if (!this.StudentManager.Stop)
		{
			this.StudentManager.UpdateStudents(0);
		}
		this.Rival.OsanaHair.GetComponent<Animation>().Stop();
		this.Rival.OsanaHair.transform.parent = this.Rival.Head;
		this.Rival.OsanaHair.transform.localEulerAngles = Vector3.zero;
		this.Rival.OsanaHair.transform.localPosition = new Vector3(0f, -1.442789f, 0.01900469f);
		this.Rival.OsanaHair.transform.localScale = new Vector3(1f, 1f, 1f);
		this.Rival.OsanaHairL.enabled = true;
		this.Rival.OsanaHairR.enabled = true;
		this.Rival.Schoolwear = 1;
		this.Rival.ChangeSchoolwear();
		if (this.Friend != null)
		{
			ScheduleBlock scheduleBlock = this.Friend.ScheduleBlocks[this.Friend.Phase];
			scheduleBlock.destination = "Follow";
			scheduleBlock.action = "Follow";
			this.Friend.GetDestinations();
			if (this.Friend.FollowTarget != null)
			{
				this.Friend.CurrentDestination = this.Friend.FollowTarget.transform;
				this.Friend.Pathfinding.target = this.Friend.FollowTarget.transform;
			}
			this.Friend.Pathfinding.canSearch = true;
			this.Friend.Pathfinding.canMove = true;
			this.Friend.CanTalk = true;
		}
		this.EventSubtitle.text = string.Empty;
		base.enabled = false;
		this.Jukebox.Dip = 1f;
	}

	// Token: 0x06001A48 RID: 6728 RVA: 0x00117D40 File Offset: 0x00115F40
	public void ReturnFromSave()
	{
		this.Rival = this.StudentManager.Students[this.RivalID];
		this.Friend = this.StudentManager.Students[this.FriendID];
		if (this.Friend != null)
		{
			ScheduleBlock scheduleBlock = this.Friend.ScheduleBlocks[this.Friend.Phase];
			scheduleBlock.destination = "Sunbathe";
			scheduleBlock.action = "Sunbathe";
			this.Friend.Actions[this.Friend.Phase] = StudentActionType.Sunbathe;
			this.Friend.CurrentAction = StudentActionType.Sunbathe;
			this.Friend.GetDestinations();
			this.Friend.CurrentDestination = this.StudentManager.FemaleStripSpot;
			this.Friend.Pathfinding.target = this.StudentManager.FemaleStripSpot;
			this.Friend.Pathfinding.canSearch = true;
			this.Friend.Pathfinding.canMove = true;
		}
		this.Rival.Pathfinding.target = this.Location[1];
		this.Rival.CurrentDestination = this.Location[1];
		this.Phase = 3;
	}

	// Token: 0x04002B12 RID: 11026
	public StudentManagerScript StudentManager;

	// Token: 0x04002B13 RID: 11027
	public JukeboxScript Jukebox;

	// Token: 0x04002B14 RID: 11028
	public UILabel EventSubtitle;

	// Token: 0x04002B15 RID: 11029
	public YandereScript Yandere;

	// Token: 0x04002B16 RID: 11030
	public PromptScript Prompt;

	// Token: 0x04002B17 RID: 11031
	public ClockScript Clock;

	// Token: 0x04002B18 RID: 11032
	public StudentScript Friend;

	// Token: 0x04002B19 RID: 11033
	public StudentScript Rival;

	// Token: 0x04002B1A RID: 11034
	public Transform[] Location;

	// Token: 0x04002B1B RID: 11035
	public AudioClip[] SpeechClip;

	// Token: 0x04002B1C RID: 11036
	public string[] SpeechText;

	// Token: 0x04002B1D RID: 11037
	public string[] EventAnim;

	// Token: 0x04002B1E RID: 11038
	public GameObject AlarmDisc;

	// Token: 0x04002B1F RID: 11039
	public GameObject BigSplash;

	// Token: 0x04002B20 RID: 11040
	public GameObject VoiceClip;

	// Token: 0x04002B21 RID: 11041
	public GameObject Weight;

	// Token: 0x04002B22 RID: 11042
	public bool Murdering;

	// Token: 0x04002B23 RID: 11043
	public float Distance;

	// Token: 0x04002B24 RID: 11044
	public float Scale;

	// Token: 0x04002B25 RID: 11045
	public float Timer;

	// Token: 0x04002B26 RID: 11046
	public DayOfWeek EventDay;

	// Token: 0x04002B27 RID: 11047
	public int MurderPhase = 1;

	// Token: 0x04002B28 RID: 11048
	public int FriendID = 10;

	// Token: 0x04002B29 RID: 11049
	public int RivalID = 11;

	// Token: 0x04002B2A RID: 11050
	public int Phase;

	// Token: 0x04002B2B RID: 11051
	public int Frame;
}
