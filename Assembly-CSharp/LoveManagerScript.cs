﻿using System;
using UnityEngine;

// Token: 0x0200035A RID: 858
public class LoveManagerScript : MonoBehaviour
{
	// Token: 0x06001994 RID: 6548 RVA: 0x00103820 File Offset: 0x00101A20
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

	// Token: 0x06001995 RID: 6549 RVA: 0x001038F8 File Offset: 0x00101AF8
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

	// Token: 0x06001996 RID: 6550 RVA: 0x00103EAC File Offset: 0x001020AC
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

	// Token: 0x06001997 RID: 6551 RVA: 0x001041A0 File Offset: 0x001023A0
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

	// Token: 0x06001998 RID: 6552 RVA: 0x00104304 File Offset: 0x00102504
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

	// Token: 0x040028DB RID: 10459
	public ConfessionManagerScript ConfessionManager;

	// Token: 0x040028DC RID: 10460
	public AppearanceWindowScript AppearanceWindow;

	// Token: 0x040028DD RID: 10461
	public ConfessionSceneScript ConfessionScene;

	// Token: 0x040028DE RID: 10462
	public StudentManagerScript StudentManager;

	// Token: 0x040028DF RID: 10463
	public YandereScript Yandere;

	// Token: 0x040028E0 RID: 10464
	public ClockScript Clock;

	// Token: 0x040028E1 RID: 10465
	public StudentScript Follower;

	// Token: 0x040028E2 RID: 10466
	public StudentScript Suitor;

	// Token: 0x040028E3 RID: 10467
	public StudentScript Rival;

	// Token: 0x040028E4 RID: 10468
	public Transform FriendWaitSpot;

	// Token: 0x040028E5 RID: 10469
	public Transform[] Targets;

	// Token: 0x040028E6 RID: 10470
	public Transform MythHill;

	// Token: 0x040028E7 RID: 10471
	public int SuitorProgress;

	// Token: 0x040028E8 RID: 10472
	public int TotalTargets;

	// Token: 0x040028E9 RID: 10473
	public int Phase = 1;

	// Token: 0x040028EA RID: 10474
	public int ID;

	// Token: 0x040028EB RID: 10475
	public int SuitorID = 28;

	// Token: 0x040028EC RID: 10476
	public int RivalID = 30;

	// Token: 0x040028ED RID: 10477
	public float AngleLimit;

	// Token: 0x040028EE RID: 10478
	public bool WaitingToConfess;

	// Token: 0x040028EF RID: 10479
	public bool ConfessToSuitor;

	// Token: 0x040028F0 RID: 10480
	public bool HoldingHands;

	// Token: 0x040028F1 RID: 10481
	public bool RivalWaiting;

	// Token: 0x040028F2 RID: 10482
	public bool LeftNote;

	// Token: 0x040028F3 RID: 10483
	public bool Courted;

	// Token: 0x040028F4 RID: 10484
	public bool CustomSuitorBlack;

	// Token: 0x040028F5 RID: 10485
	public bool CustomSuitorTan;

	// Token: 0x040028F6 RID: 10486
	public bool CustomSuitor;

	// Token: 0x040028F7 RID: 10487
	public int CustomSuitorAccessory;

	// Token: 0x040028F8 RID: 10488
	public int CustomSuitorEyewear;

	// Token: 0x040028F9 RID: 10489
	public int CustomSuitorJewelry;

	// Token: 0x040028FA RID: 10490
	public int CustomSuitorHair;
}
