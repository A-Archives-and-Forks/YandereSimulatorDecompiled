﻿using System;
using UnityEngine;

// Token: 0x02000358 RID: 856
public class LoveManagerScript : MonoBehaviour
{
	// Token: 0x06001980 RID: 6528 RVA: 0x00102914 File Offset: 0x00100B14
	private void Start()
	{
		int week = DateGlobals.Week;
		if (week > 10)
		{
			base.gameObject.SetActive(false);
			return;
		}
		this.SuitorProgress = DatingGlobals.SuitorProgress;
		this.CustomSuitorAccessory = StudentGlobals.CustomSuitorAccessory;
		this.CustomSuitorEyewear = StudentGlobals.CustomSuitorEyewear;
		this.CustomSuitorJewelry = StudentGlobals.CustomSuitorJewelry;
		this.CustomSuitorBlack = StudentGlobals.CustomSuitorBlack;
		this.CustomSuitorHair = StudentGlobals.CustomSuitorHair;
		this.CustomSuitorTan = StudentGlobals.CustomSuitorTan;
		this.CustomSuitor = StudentGlobals.CustomSuitor;
		if (GameGlobals.Eighties)
		{
			this.SuitorID = this.StudentManager.SuitorIDs[week];
			this.RivalID = 10 + week;
			if (DatingGlobals.Affection >= (float)(week * 10))
			{
				this.ConfessToSuitor = true;
				return;
			}
		}
		else
		{
			this.SuitorID = 6;
			this.RivalID = 11;
			if (DatingGlobals.Affection == 100f)
			{
				this.ConfessToSuitor = true;
			}
		}
	}

	// Token: 0x06001981 RID: 6529 RVA: 0x001029EC File Offset: 0x00100BEC
	private void LateUpdate()
	{
		if (this.Yandere.Follower != null && this.Yandere.Follower.StudentID == this.StudentManager.RivalID)
		{
			this.Follower = this.Yandere.Follower;
			this.ID = 0;
			while (this.ID < this.TotalTargets)
			{
				Transform transform = this.Targets[this.ID];
				if (transform != null && this.Follower.transform.position.y > transform.position.y - 2f && this.Follower.transform.position.y < transform.position.y + 2f && Vector3.Distance(this.Follower.transform.position, new Vector3(transform.position.x, this.Follower.transform.position.y, transform.position.z)) < 2.5f)
				{
					if (Mathf.Abs(Vector3.Angle(this.Follower.transform.forward, this.Follower.transform.position - new Vector3(transform.position.x, this.Follower.transform.position.y, transform.position.z))) > this.AngleLimit)
					{
						if (!this.Follower.Gush)
						{
							this.Follower.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
							this.Follower.GushTarget = transform;
							ParticleSystem.EmissionModule emission = this.Follower.Hearts.emission;
							emission.enabled = true;
							emission.rateOverTime = 5f;
							this.Follower.Hearts.Play();
							this.Follower.Gush = true;
						}
					}
					else
					{
						this.Follower.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
						this.Follower.Hearts.emission.enabled = false;
						this.Follower.Gush = false;
					}
				}
				this.ID++;
			}
		}
		if (this.LeftNote)
		{
			if (this.Rival == null)
			{
				this.Rival = this.StudentManager.Students[this.RivalID];
			}
			if (this.Suitor == null)
			{
				if (this.ConfessToSuitor)
				{
					this.Suitor = this.StudentManager.Students[this.SuitorID];
				}
				else
				{
					this.Suitor = this.StudentManager.Students[1];
				}
			}
			if (this.Rival != null && this.Suitor != null && this.Rival.Alive && this.Suitor.Alive && !this.Rival.Dying && !this.Suitor.Dying && this.Rival.ConfessPhase == 5 && this.Suitor.ConfessPhase == 3)
			{
				this.WaitingToConfess = true;
				float num = Vector3.Distance(this.Yandere.transform.position, this.MythHill.position);
				if (this.WaitingToConfess && !this.Yandere.Chased && this.Yandere.Chasers == 0 && num > 10f && num < 25f)
				{
					this.BeginConfession();
				}
			}
		}
		if (this.HoldingHands)
		{
			if (this.Rival == null)
			{
				this.Rival = this.StudentManager.Students[this.RivalID];
			}
			if (this.Suitor == null)
			{
				this.Suitor = this.StudentManager.Students[this.SuitorID];
			}
			this.Rival.MyController.Move(base.transform.forward * Time.deltaTime);
			this.Suitor.transform.position = new Vector3(this.Rival.transform.position.x - 0.5f, this.Rival.transform.position.y, this.Rival.transform.position.z);
			if (this.Rival.transform.position.z > -50f)
			{
				this.Suitor.MyController.radius = 0.12f;
				this.Suitor.enabled = true;
				this.Suitor.Cosmetic.MyRenderer.materials[this.Suitor.Cosmetic.FaceID].SetFloat("_BlendAmount", 0f);
				this.Suitor.Hearts.emission.enabled = false;
				this.Rival.MyController.radius = 0.12f;
				this.Rival.enabled = true;
				this.Rival.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
				this.Rival.Hearts.emission.enabled = false;
				this.Suitor.HoldingHands = false;
				this.Rival.HoldingHands = false;
				this.HoldingHands = false;
			}
		}
	}

	// Token: 0x06001982 RID: 6530 RVA: 0x00102FA0 File Offset: 0x001011A0
	public void CoupleCheck()
	{
		if (this.SuitorProgress == 2)
		{
			this.Rival = this.StudentManager.Students[this.RivalID];
			this.Suitor = this.StudentManager.Students[this.SuitorID];
			if (this.Rival != null && this.Suitor != null)
			{
				this.Suitor.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				this.Suitor.CharacterAnimation.enabled = true;
				this.Rival.CharacterAnimation.enabled = true;
				this.Suitor.CharacterAnimation.Play("walkHands_00");
				this.Suitor.transform.eulerAngles = Vector3.zero;
				this.Suitor.transform.position = new Vector3(-0.25f, 0f, -90f);
				this.Suitor.Pathfinding.canSearch = false;
				this.Suitor.Pathfinding.canMove = false;
				this.Suitor.MyController.radius = 0f;
				this.Suitor.enabled = false;
				this.Rival.CharacterAnimation.Play("f02_walkHands_00");
				this.Rival.transform.eulerAngles = Vector3.zero;
				this.Rival.transform.position = new Vector3(0.25f, 0f, -90f);
				this.Rival.Pathfinding.canSearch = false;
				this.Rival.Pathfinding.canMove = false;
				this.Rival.MyController.radius = 0f;
				this.Rival.enabled = false;
				Physics.SyncTransforms();
				this.Suitor.Cosmetic.MyRenderer.materials[this.Suitor.Cosmetic.FaceID].SetFloat("_BlendAmount", 1f);
				ParticleSystem.EmissionModule emission = this.Suitor.Hearts.emission;
				emission.enabled = true;
				emission.rateOverTime = 5f;
				this.Suitor.Hearts.Play();
				this.Rival.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 1f);
				ParticleSystem.EmissionModule emission2 = this.Rival.Hearts.emission;
				emission2.enabled = true;
				emission2.rateOverTime = 5f;
				this.Rival.Hearts.Play();
				this.Suitor.HoldingHands = true;
				this.Rival.HoldingHands = true;
				this.Suitor.CoupleID = this.SuitorID;
				this.Rival.CoupleID = this.RivalID;
				this.HoldingHands = true;
				Debug.Log("Students are now holding hands.");
			}
		}
	}

	// Token: 0x06001983 RID: 6531 RVA: 0x00103294 File Offset: 0x00101494
	public void BeginConfession()
	{
		Debug.Log("Confession is being told to begin.");
		Time.timeScale = 1f;
		this.Suitor.EmptyHands();
		this.Rival.EmptyHands();
		if (this.Yandere.Aiming)
		{
			this.Yandere.StopAiming();
		}
		if (this.Yandere.YandereVision)
		{
			this.Yandere.ResetYandereEffects();
			this.Yandere.YandereVision = false;
		}
		this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
		this.Yandere.RPGCamera.enabled = false;
		this.Yandere.CanMove = false;
		this.StudentManager.DisableEveryone();
		this.Suitor.gameObject.SetActive(true);
		this.Rival.gameObject.SetActive(true);
		this.Suitor.enabled = false;
		this.Rival.enabled = false;
		if (!this.ConfessToSuitor)
		{
			this.ConfessionManager.Senpai = this.StudentManager.Students[1].CharacterAnimation;
			this.ConfessionManager.gameObject.SetActive(true);
		}
		else
		{
			this.ConfessionScene.enabled = true;
		}
		this.Clock.Police.gameObject.SetActive(false);
		this.WaitingToConfess = false;
		this.Clock.StopTime = true;
		this.LeftNote = false;
	}

	// Token: 0x06001984 RID: 6532 RVA: 0x001033F8 File Offset: 0x001015F8
	public void SaveSuitorInstructions()
	{
		StudentGlobals.CustomSuitorAccessory = this.CustomSuitorAccessory;
		StudentGlobals.CustomSuitorEyewear = this.CustomSuitorEyewear;
		StudentGlobals.CustomSuitorJewelry = this.CustomSuitorJewelry;
		StudentGlobals.CustomSuitorBlack = this.CustomSuitorBlack;
		StudentGlobals.CustomSuitorHair = this.CustomSuitorHair;
		StudentGlobals.CustomSuitorTan = this.CustomSuitorTan;
		StudentGlobals.CustomSuitor = this.CustomSuitor;
		DatingGlobals.SetSuitorCheck(1, this.AppearanceWindow.Checks[1].enabled);
		DatingGlobals.SetSuitorCheck(2, this.AppearanceWindow.Checks[2].enabled);
		DatingGlobals.SetSuitorCheck(3, this.AppearanceWindow.Checks[3].enabled);
		DatingGlobals.SetSuitorCheck(4, this.AppearanceWindow.Checks[4].enabled);
		DatingGlobals.SetSuitorCheck(5, this.AppearanceWindow.Checks[5].enabled);
		DatingGlobals.SetSuitorCheck(6, this.AppearanceWindow.Checks[6].enabled);
		DatingGlobals.SetSuitorCheck(7, this.AppearanceWindow.Checks[7].enabled);
		DatingGlobals.SetSuitorCheck(8, this.AppearanceWindow.Checks[8].enabled);
		DatingGlobals.SetSuitorCheck(9, this.AppearanceWindow.Checks[9].enabled);
	}

	// Token: 0x040028B4 RID: 10420
	public ConfessionManagerScript ConfessionManager;

	// Token: 0x040028B5 RID: 10421
	public AppearanceWindowScript AppearanceWindow;

	// Token: 0x040028B6 RID: 10422
	public ConfessionSceneScript ConfessionScene;

	// Token: 0x040028B7 RID: 10423
	public StudentManagerScript StudentManager;

	// Token: 0x040028B8 RID: 10424
	public YandereScript Yandere;

	// Token: 0x040028B9 RID: 10425
	public ClockScript Clock;

	// Token: 0x040028BA RID: 10426
	public StudentScript Follower;

	// Token: 0x040028BB RID: 10427
	public StudentScript Suitor;

	// Token: 0x040028BC RID: 10428
	public StudentScript Rival;

	// Token: 0x040028BD RID: 10429
	public Transform FriendWaitSpot;

	// Token: 0x040028BE RID: 10430
	public Transform[] Targets;

	// Token: 0x040028BF RID: 10431
	public Transform MythHill;

	// Token: 0x040028C0 RID: 10432
	public int SuitorProgress;

	// Token: 0x040028C1 RID: 10433
	public int TotalTargets;

	// Token: 0x040028C2 RID: 10434
	public int Phase = 1;

	// Token: 0x040028C3 RID: 10435
	public int ID;

	// Token: 0x040028C4 RID: 10436
	public int SuitorID = 28;

	// Token: 0x040028C5 RID: 10437
	public int RivalID = 30;

	// Token: 0x040028C6 RID: 10438
	public float AngleLimit;

	// Token: 0x040028C7 RID: 10439
	public bool WaitingToConfess;

	// Token: 0x040028C8 RID: 10440
	public bool ConfessToSuitor;

	// Token: 0x040028C9 RID: 10441
	public bool HoldingHands;

	// Token: 0x040028CA RID: 10442
	public bool RivalWaiting;

	// Token: 0x040028CB RID: 10443
	public bool LeftNote;

	// Token: 0x040028CC RID: 10444
	public bool Courted;

	// Token: 0x040028CD RID: 10445
	public bool CustomSuitorBlack;

	// Token: 0x040028CE RID: 10446
	public bool CustomSuitorTan;

	// Token: 0x040028CF RID: 10447
	public bool CustomSuitor;

	// Token: 0x040028D0 RID: 10448
	public int CustomSuitorAccessory;

	// Token: 0x040028D1 RID: 10449
	public int CustomSuitorEyewear;

	// Token: 0x040028D2 RID: 10450
	public int CustomSuitorJewelry;

	// Token: 0x040028D3 RID: 10451
	public int CustomSuitorHair;
}
