﻿using System;
using UnityEngine;
using UnityEngine.PostProcessing;

// Token: 0x0200024D RID: 589
public class ClockScript : MonoBehaviour
{
	// Token: 0x06001269 RID: 4713 RVA: 0x0008ECBC File Offset: 0x0008CEBC
	private void Start()
	{
		if (!this.MissionMode)
		{
			this.Profile.bloom.enabled = true;
			this.BloomDisabled = OptionGlobals.DisableBloom;
			OptionGlobals.DisableBloom = false;
		}
		RenderSettings.ambientLight = new Color(0.75f, 0.75f, 0.75f);
		this.PeriodLabel.text = "BEFORE CLASS";
		this.PresentTime = this.StartHour * 60f;
		if (PlayerPrefs.GetInt("LoadingSave") == 1)
		{
			int profile = GameGlobals.Profile;
			int @int = PlayerPrefs.GetInt("SaveSlot");
			this.Weekday = PlayerPrefs.GetInt(string.Concat(new string[]
			{
				"Profile_",
				profile.ToString(),
				"_Slot_",
				@int.ToString(),
				"_Weekday"
			}));
			if (this.Weekday == 1)
			{
				DateGlobals.Weekday = DayOfWeek.Monday;
			}
			else if (this.Weekday == 2)
			{
				DateGlobals.Weekday = DayOfWeek.Tuesday;
			}
			else if (this.Weekday == 3)
			{
				DateGlobals.Weekday = DayOfWeek.Wednesday;
			}
			else if (this.Weekday == 4)
			{
				DateGlobals.Weekday = DayOfWeek.Thursday;
			}
			else if (this.Weekday == 5)
			{
				DateGlobals.Weekday = DayOfWeek.Friday;
			}
		}
		else if (DateGlobals.Weekday == DayOfWeek.Monday)
		{
			this.Weekday = 1;
		}
		else if (DateGlobals.Weekday == DayOfWeek.Tuesday)
		{
			this.Weekday = 2;
		}
		else if (DateGlobals.Weekday == DayOfWeek.Wednesday)
		{
			this.Weekday = 3;
		}
		else if (DateGlobals.Weekday == DayOfWeek.Thursday)
		{
			this.Weekday = 4;
		}
		else if (DateGlobals.Weekday == DayOfWeek.Friday)
		{
			this.Weekday = 5;
		}
		this.Day = this.Weekday + (DateGlobals.Week - 1) * 5;
		if (DateGlobals.Weekday == DayOfWeek.Sunday)
		{
			DateGlobals.Weekday = DayOfWeek.Monday;
		}
		if (!SchoolGlobals.SchoolAtmosphereSet)
		{
			SchoolGlobals.SchoolAtmosphereSet = true;
			SchoolGlobals.PreviousSchoolAtmosphere = 1f;
			SchoolGlobals.SchoolAtmosphere = 1f;
		}
		if (SchoolGlobals.SchoolAtmosphere < 0.5f)
		{
			this.CameraEffects.UpdateBloom(1f);
			this.CameraEffects.UpdateBloomKnee(0.5f);
			this.CameraEffects.UpdateBloomRadius(4f);
			this.Police.Darkness.enabled = true;
			this.Police.Darkness.color = new Color(this.Police.Darkness.color.r, this.Police.Darkness.color.g, this.Police.Darkness.color.b, 1f);
			this.FadeIn = true;
		}
		else
		{
			this.CameraEffects.UpdateBloom(11f);
			this.CameraEffects.UpdateBloomKnee(1f);
			this.CameraEffects.UpdateBloomRadius(7f);
			this.BloomKnee = 1f;
			this.BloomRadius = 7f;
			this.BloomIntensity = 11f;
			this.UpdateBloom = true;
		}
		this.DayLabel.text = this.GetWeekdayText(DateGlobals.Weekday);
		this.MainLight.color = new Color(1f, 1f, 1f, 1f);
		RenderSettings.ambientLight = new Color(0.75f, 0.75f, 0.75f, 1f);
		RenderSettings.skybox.SetColor("_Tint", new Color(0.5f, 0.5f, 0.5f));
		if (ClubGlobals.GetClubClosed(ClubType.Photography) || StudentGlobals.GetStudentGrudge(56) || StudentGlobals.GetStudentGrudge(57) || StudentGlobals.GetStudentGrudge(58) || StudentGlobals.GetStudentGrudge(59) || StudentGlobals.GetStudentGrudge(60))
		{
			this.IgnorePhotographyClub = true;
		}
		this.MissionMode = MissionModeGlobals.MissionMode;
		this.HourTime = this.PresentTime / 60f;
		this.Hour = Mathf.Floor(this.PresentTime / 60f);
		this.Minute = Mathf.Floor((this.PresentTime / 60f - this.Hour) * 60f);
		this.UpdateClock();
		if (GameGlobals.Eighties)
		{
			this.BecomeEighties();
		}
		if (this.StudentManager.RecordingVideo)
		{
			this.CameraEffects.UpdateBloom(1f);
			this.CameraEffects.UpdateBloomRadius(4f);
			this.CameraEffects.UpdateBloomKnee(0.75f);
		}
	}

	// Token: 0x0600126A RID: 4714 RVA: 0x0008F0EC File Offset: 0x0008D2EC
	public void Update()
	{
		if (this.FadeIn && Time.deltaTime < 1f)
		{
			this.Police.Darkness.color = new Color(this.Police.Darkness.color.r, this.Police.Darkness.color.g, this.Police.Darkness.color.b, Mathf.MoveTowards(this.Police.Darkness.color.a, 0f, Time.deltaTime));
			if (this.Police.Darkness.color.a == 0f)
			{
				this.Police.Darkness.enabled = false;
				this.FadeIn = false;
			}
		}
		if (!this.MissionMode && this.CameraTimer < 1f)
		{
			this.CameraTimer += Time.deltaTime;
			if (this.CameraTimer > 1f && !this.StudentManager.MemorialScene.enabled)
			{
				Debug.Log("This is the exact moment that the player gains control of the character.");
				if (this.BloomDisabled)
				{
					OptionGlobals.DisableBloom = true;
					this.Profile.bloom.enabled = false;
				}
				this.Yandere.RPGCamera.enabled = true;
				this.Yandere.CanMove = true;
				int bringingItem = PlayerGlobals.BringingItem;
				if (bringingItem > 0 && bringingItem < this.Police.EndOfDay.WeaponManager.BroughtWeapons.Length)
				{
					this.Police.EndOfDay.WeaponManager.BroughtWeapons[bringingItem].Prompt.Circle[3].fillAmount = 0f;
					this.Police.EndOfDay.WeaponManager.BroughtWeapons[bringingItem].UnequipImmediately = true;
				}
			}
		}
		if (this.PresentTime < 1080f)
		{
			if (this.UpdateBloom)
			{
				if (this.BloomWait == 0f)
				{
					if (!this.ReduceKnee)
					{
						if (this.Lerp)
						{
							this.BloomIntensity = Mathf.Lerp(this.BloomIntensity, 1f, Time.deltaTime);
							this.BloomRadius = Mathf.Lerp(this.BloomRadius, 4f, Time.deltaTime);
							if (this.BloomIntensity < 1.1f)
							{
								this.BloomIntensity = 1f;
								this.BloomRadius = 4f;
							}
						}
						else
						{
							this.BloomIntensity = Mathf.MoveTowards(this.BloomIntensity, 1f, Time.deltaTime * this.BloomFadeSpeed);
							this.BloomRadius = Mathf.MoveTowards(this.BloomRadius, 4f, Time.deltaTime * this.BloomFadeSpeed);
						}
						this.CameraEffects.UpdateBloom(this.BloomIntensity);
						this.CameraEffects.UpdateBloomRadius(this.BloomRadius);
						if (this.BloomIntensity == 1f && this.BloomRadius == 4f)
						{
							this.ReduceKnee = true;
						}
					}
					else
					{
						this.BloomKnee = Mathf.MoveTowards(this.BloomKnee, 0.75f, Time.deltaTime * (this.BloomFadeSpeed * 0.1f));
						this.CameraEffects.UpdateBloomKnee(this.BloomKnee);
						if (this.BloomKnee == 0.75f)
						{
							this.UpdateBloom = false;
						}
					}
				}
				else
				{
					this.BloomWait = Mathf.MoveTowards(this.BloomWait, 0f, Time.deltaTime);
				}
			}
		}
		else if (this.LoveManager.WaitingToConfess)
		{
			if (!this.StopTime)
			{
				this.LoveManager.BeginConfession();
			}
		}
		else if (!this.Police.FadeOut && !this.Yandere.Attacking && !this.Yandere.Struggling && !this.Yandere.DelinquentFighting && !this.Yandere.Pickpocketing && !this.Yandere.Noticed)
		{
			this.StudentManager.Reputation.UpdateRep();
			this.Police.DayOver = true;
			this.Yandere.StudentManager.StopMoving();
			this.Police.Darkness.enabled = true;
			this.Police.FadeOut = true;
			this.StopTime = true;
		}
		if (!this.StopTime)
		{
			if (this.Period == 3)
			{
				this.PresentTime += Time.deltaTime * 0.016666668f * this.TimeSpeed * 0.5f;
			}
			else
			{
				this.PresentTime += Time.deltaTime * 0.016666668f * this.TimeSpeed;
			}
		}
		this.HourTime = this.PresentTime / 60f;
		this.Hour = Mathf.Floor(this.PresentTime / 60f);
		this.Minute = Mathf.Floor((this.PresentTime / 60f - this.Hour) * 60f);
		if (this.Minute != this.LastMinute)
		{
			this.UpdateClock();
		}
		this.MinuteHand.localEulerAngles = new Vector3(this.MinuteHand.localEulerAngles.x, this.MinuteHand.localEulerAngles.y, this.Minute * 6f);
		this.HourHand.localEulerAngles = new Vector3(this.HourHand.localEulerAngles.x, this.HourHand.localEulerAngles.y, this.Hour * 30f);
		if (this.LateStudent && this.HourTime > 7.9f)
		{
			this.ActivateLateStudent();
		}
		if (this.HourTime < 8.5f)
		{
			if (this.Period < 1)
			{
				this.PeriodLabel.text = "BEFORE CLASS";
				this.DeactivateTrespassZones();
				this.Period++;
			}
		}
		else if (this.HourTime < 13f)
		{
			if (this.Period < 2)
			{
				this.PeriodLabel.text = "CLASS TIME";
				this.ActivateTrespassZones();
				this.Period++;
			}
		}
		else if (this.HourTime < 13.5f)
		{
			if (this.Period < 3)
			{
				this.PeriodLabel.text = "LUNCH TIME";
				this.StudentManager.DramaPhase = 0;
				this.StudentManager.UpdateDrama();
				this.DeactivateTrespassZones();
				this.Period++;
				this.StudentManager.WednesdayGiftBox.SetActive(false);
				this.StudentManager.FridayTestNotes.SetActive(false);
				this.StudentManager.MondayBento.SetActive(false);
				this.StudentManager.RivalBookBag.NoBento = true;
				this.StudentManager.Unstop();
				if (!this.StudentManager.Eighties && DateGlobals.Week == 1 && !this.StudentManager.MissionMode)
				{
					this.StudentManager.UpdateLunchtimeStudents();
				}
				this.UpdateClock();
			}
		}
		else if (this.HourTime < 15.5f)
		{
			if (this.Period < 4)
			{
				this.PeriodLabel.text = "CLASS TIME";
				this.ActivateTrespassZones();
				this.Period++;
			}
		}
		else if (this.HourTime < 16f)
		{
			if (this.Period < 5)
			{
				if (this.StudentManager.Bully && this.StudentManager.Bullies > 0)
				{
					this.StudentManager.UpdateGraffiti();
				}
				this.PeriodLabel.text = "CLEANING TIME";
				this.DeactivateTrespassZones();
				if (this.Weekday == 5)
				{
					this.MeetingRoomTrespassZone.enabled = true;
				}
				this.StudentManager.Unstop();
				this.Period++;
				this.UpdateClock();
			}
		}
		else if (this.Period < 6)
		{
			this.PeriodLabel.text = "AFTER SCHOOL";
			this.StudentManager.DramaPhase = 0;
			this.StudentManager.UpdateDrama();
			this.Period++;
		}
		if (!this.IgnorePhotographyClub && this.HourTime > 16.75f && this.StudentManager.SleuthPhase < 4)
		{
			this.StudentManager.SleuthPhase = 3;
			this.StudentManager.UpdateSleuths();
		}
		this.Sun.eulerAngles = new Vector3(this.Sun.eulerAngles.x, this.Sun.eulerAngles.y, -45f + 90f * (this.PresentTime - 420f) / 660f);
		if (!this.Horror)
		{
			if (this.StudentManager.WestBathroomArea.bounds.Contains(this.Yandere.transform.position) || this.StudentManager.EastBathroomArea.bounds.Contains(this.Yandere.transform.position))
			{
				for (int i = 1; i < this.Bathroom.Length; i++)
				{
					if (this.Bathroom[i].bounds.Contains(this.Yandere.transform.position))
					{
						if (!this.BathroomLight[i].enabled)
						{
							this.BathroomDim = 0.5f;
						}
						else
						{
							this.BathroomDim = 0f;
						}
					}
				}
			}
			else
			{
				this.BathroomDim = 0f;
			}
			if (this.BathroomDimSprite.alpha != this.BathroomDim)
			{
				this.BathroomDimSprite.alpha = Mathf.MoveTowards(this.BathroomDimSprite.alpha, this.BathroomDim, Time.deltaTime * 10f);
			}
			this.AmbientLightDim = 0.75f;
			if (this.PresentTime > 930f)
			{
				this.DayProgress = (this.PresentTime - 930f) / 150f;
				this.MainLight.color = new Color(1f - 0.1490196f * this.DayProgress, 1f - 0.40392154f * this.DayProgress, 1f - 0.70980394f * this.DayProgress);
				RenderSettings.ambientLight = new Color(1f - 0.1490196f * this.DayProgress - (1f - this.AmbientLightDim) * (1f - this.DayProgress), 1f - 0.40392154f * this.DayProgress - (1f - this.AmbientLightDim) * (1f - this.DayProgress), 1f - 0.70980394f * this.DayProgress - (1f - this.AmbientLightDim) * (1f - this.DayProgress));
				this.SkyboxColor = new Color(1f - 0.1490196f * this.DayProgress - 0.5f * (1f - this.DayProgress), 1f - 0.40392154f * this.DayProgress - 0.5f * (1f - this.DayProgress), 1f - 0.70980394f * this.DayProgress - 0.5f * (1f - this.DayProgress));
				RenderSettings.skybox.SetColor("_Tint", new Color(this.SkyboxColor.r, this.SkyboxColor.g, this.SkyboxColor.b));
			}
			else
			{
				RenderSettings.ambientLight = new Color(this.AmbientLightDim, this.AmbientLightDim, this.AmbientLightDim);
			}
		}
		if (this.TimeSkip)
		{
			if (this.HalfwayTime == 0f)
			{
				this.HalfwayTime = this.PresentTime + (this.TargetTime - this.PresentTime) * 0.5f;
				this.OriginalPosition = this.Yandere.transform.position;
				if (!this.StudentManager.Eighties)
				{
					this.Yandere.Phone.transform.localPosition = new Vector3(0.02f, -0.005f, 0.03f);
					this.Yandere.Phone.transform.localEulerAngles = new Vector3(0f, -165f, -165f);
				}
				else
				{
					this.Yandere.Phone.transform.localPosition = new Vector3(0.02f, -0.0066666f, 0.03f);
					this.Yandere.Phone.transform.localEulerAngles = new Vector3(-75f, 120f, 75f);
				}
				this.Yandere.TimeSkipping = true;
				this.Yandere.CanMove = false;
				if (this.Yandere.Armed)
				{
					this.Yandere.Unequip();
				}
			}
			this.TimeSkipSpeed += Time.deltaTime;
			if (Time.timeScale < 10f)
			{
				Time.timeScale = Mathf.MoveTowards(Time.timeScale, 10f, this.TimeSkipSpeed * Time.unscaledDeltaTime);
			}
			this.Yandere.CharacterAnimation["f02_timeSkip_00"].speed = 1f / Time.timeScale;
			if (this.PresentTime > this.TargetTime)
			{
				this.EndTimeSkip();
			}
			if (this.Yandere.CameraEffects.Streaks.color.a > 0f || this.Yandere.CameraEffects.MurderStreaks.color.a > 0f || this.Yandere.NearSenpai || Input.GetButtonDown("B"))
			{
				this.EndTimeSkip();
			}
		}
	}

	// Token: 0x0600126B RID: 4715 RVA: 0x0008FE60 File Offset: 0x0008E060
	public void EndTimeSkip()
	{
		if (GameGlobals.AlphabetMode)
		{
			this.StopTime = true;
		}
		this.Yandere.PauseScreen.PromptBar.ClearButtons();
		this.Yandere.PauseScreen.PromptBar.Show = false;
		this.PromptParent.localScale = new Vector3(1f, 1f, 1f);
		this.Yandere.transform.position = this.OriginalPosition;
		this.Yandere.Phone.SetActive(false);
		this.Yandere.TimeSkipping = false;
		Time.timeScale = 1f;
		this.TimeSkip = false;
		this.HalfwayTime = 0f;
		this.TimeSkipSpeed = 1f;
		if (!this.Yandere.Noticed && !this.Police.FadeOut)
		{
			this.Yandere.CharacterAnimation.CrossFade(this.Yandere.IdleAnim);
			this.Yandere.CanMoveTimer = 0.5f;
		}
	}

	// Token: 0x0600126C RID: 4716 RVA: 0x0008FF64 File Offset: 0x0008E164
	public string GetWeekdayText(DayOfWeek weekday)
	{
		if (weekday == DayOfWeek.Sunday)
		{
			this.Weekday = 0;
			return "SUNDAY";
		}
		if (weekday == DayOfWeek.Monday)
		{
			this.Weekday = 1;
			return "MONDAY";
		}
		if (weekday == DayOfWeek.Tuesday)
		{
			this.Weekday = 2;
			return "TUESDAY";
		}
		if (weekday == DayOfWeek.Wednesday)
		{
			this.Weekday = 3;
			return "WEDNESDAY";
		}
		if (weekday == DayOfWeek.Thursday)
		{
			this.Weekday = 4;
			return "THURSDAY";
		}
		if (weekday == DayOfWeek.Friday)
		{
			this.Weekday = 5;
			return "FRIDAY";
		}
		this.Weekday = 6;
		return "SATURDAY";
	}

	// Token: 0x0600126D RID: 4717 RVA: 0x0008FFE4 File Offset: 0x0008E1E4
	private void ActivateTrespassZones()
	{
		if (!this.SchoolBell.isPlaying || this.SchoolBell.time > 1f)
		{
			this.SchoolBell.Play();
		}
		Collider[] trespassZones = this.TrespassZones;
		for (int i = 0; i < trespassZones.Length; i++)
		{
			trespassZones[i].enabled = true;
		}
	}

	// Token: 0x0600126E RID: 4718 RVA: 0x0009003C File Offset: 0x0008E23C
	public void DeactivateTrespassZones()
	{
		this.Yandere.Trespassing = false;
		if ((!this.SchoolBell.isPlaying || this.SchoolBell.time > 1f) && !this.StudentManager.SpawnNobody)
		{
			this.SchoolBell.Play();
		}
		foreach (Collider collider in this.TrespassZones)
		{
			if (!collider.GetComponent<TrespassScript>().OffLimits)
			{
				collider.enabled = false;
			}
		}
	}

	// Token: 0x0600126F RID: 4719 RVA: 0x000900BC File Offset: 0x0008E2BC
	public void ActivateLateStudent()
	{
		if (!this.StudentManager.MissionMode && this.StudentManager.Students[7] != null)
		{
			this.StudentManager.Students[7].gameObject.SetActive(true);
			this.StudentManager.Students[7].Pathfinding.speed = 4f;
			this.StudentManager.Students[7].Spawned = true;
			this.StudentManager.Students[7].Hurry = true;
		}
		this.LateStudent = false;
	}

	// Token: 0x06001270 RID: 4720 RVA: 0x0009014C File Offset: 0x0008E34C
	public void NightLighting()
	{
		this.MainLight.color = new Color(0.25f, 0.25f, 0.5f);
		RenderSettings.ambientLight = new Color(0.25f, 0.25f, 0.5f);
		this.SkyboxColor = new Color(0.1f, 0.1f, 0.2f);
		RenderSettings.skybox.SetColor("_Tint", new Color(0.1f, 0.1f, 0.2f));
	}

	// Token: 0x06001271 RID: 4721 RVA: 0x000901D0 File Offset: 0x0008E3D0
	public void UpdateClock()
	{
		this.LastMinute = this.Minute;
		if (this.Hour == 0f || this.Hour == 12f)
		{
			this.HourNumber = "12";
		}
		else if (this.Hour < 12f)
		{
			this.HourNumber = this.Hour.ToString("f0");
		}
		else
		{
			this.HourNumber = (this.Hour - 12f).ToString("f0");
		}
		if (this.Minute < 10f)
		{
			this.MinuteNumber = "0" + this.Minute.ToString("f0");
		}
		else
		{
			this.MinuteNumber = this.Minute.ToString("f0");
		}
		this.TimeText = this.HourNumber + ":" + this.MinuteNumber + ((this.Hour < 12f) ? " AM" : " PM");
		this.TimeLabel.text = this.TimeText;
	}

	// Token: 0x06001272 RID: 4722 RVA: 0x000902E0 File Offset: 0x0008E4E0
	public void BecomeEighties()
	{
		this.StudentManager.EightiesifyLabel(this.TimeLabel);
		this.StudentManager.EightiesifyLabel(this.PeriodLabel);
		this.StudentManager.EightiesifyLabel(this.DayLabel);
		this.StudentManager.EightiesifyLabel(this.Yandere.Inventory.MoneyLabel);
		this.LateStudent = false;
	}

	// Token: 0x04001773 RID: 6003
	private string MinuteNumber = string.Empty;

	// Token: 0x04001774 RID: 6004
	private string HourNumber = string.Empty;

	// Token: 0x04001775 RID: 6005
	public Collider MeetingRoomTrespassZone;

	// Token: 0x04001776 RID: 6006
	public Collider[] TrespassZones;

	// Token: 0x04001777 RID: 6007
	public PostProcessingProfile Profile;

	// Token: 0x04001778 RID: 6008
	public StudentManagerScript StudentManager;

	// Token: 0x04001779 RID: 6009
	public CameraEffectsScript CameraEffects;

	// Token: 0x0400177A RID: 6010
	public LoveManagerScript LoveManager;

	// Token: 0x0400177B RID: 6011
	public YandereScript Yandere;

	// Token: 0x0400177C RID: 6012
	public PoliceScript Police;

	// Token: 0x0400177D RID: 6013
	public ClockScript Clock;

	// Token: 0x0400177E RID: 6014
	public MotionBlur Blur;

	// Token: 0x0400177F RID: 6015
	public Vector3 OriginalPosition;

	// Token: 0x04001780 RID: 6016
	public Transform PromptParent;

	// Token: 0x04001781 RID: 6017
	public Transform MinuteHand;

	// Token: 0x04001782 RID: 6018
	public Transform HourHand;

	// Token: 0x04001783 RID: 6019
	public Transform Sun;

	// Token: 0x04001784 RID: 6020
	public GameObject SunFlare;

	// Token: 0x04001785 RID: 6021
	public UILabel PeriodLabel;

	// Token: 0x04001786 RID: 6022
	public UILabel TimeLabel;

	// Token: 0x04001787 RID: 6023
	public UILabel DayLabel;

	// Token: 0x04001788 RID: 6024
	public Light MainLight;

	// Token: 0x04001789 RID: 6025
	public float HalfwayTime;

	// Token: 0x0400178A RID: 6026
	public float PresentTime;

	// Token: 0x0400178B RID: 6027
	public float TargetTime;

	// Token: 0x0400178C RID: 6028
	public float StartTime;

	// Token: 0x0400178D RID: 6029
	public float HourTime;

	// Token: 0x0400178E RID: 6030
	public float AmbientLightDim;

	// Token: 0x0400178F RID: 6031
	public float BloomFadeSpeed = 10f;

	// Token: 0x04001790 RID: 6032
	public float TimeSkipSpeed = 1f;

	// Token: 0x04001791 RID: 6033
	public float BathroomDim;

	// Token: 0x04001792 RID: 6034
	public float CameraTimer;

	// Token: 0x04001793 RID: 6035
	public float DayProgress;

	// Token: 0x04001794 RID: 6036
	public float LastMinute;

	// Token: 0x04001795 RID: 6037
	public float BloomWait;

	// Token: 0x04001796 RID: 6038
	public float StartHour;

	// Token: 0x04001797 RID: 6039
	public float TimeSpeed;

	// Token: 0x04001798 RID: 6040
	public float Minute;

	// Token: 0x04001799 RID: 6041
	public float Timer;

	// Token: 0x0400179A RID: 6042
	public float Hour;

	// Token: 0x0400179B RID: 6043
	public PhaseOfDay Phase;

	// Token: 0x0400179C RID: 6044
	public int Weekday;

	// Token: 0x0400179D RID: 6045
	public int Period;

	// Token: 0x0400179E RID: 6046
	public int Day = 1;

	// Token: 0x0400179F RID: 6047
	public int ID;

	// Token: 0x040017A0 RID: 6048
	public string TimeText = string.Empty;

	// Token: 0x040017A1 RID: 6049
	public bool IgnorePhotographyClub;

	// Token: 0x040017A2 RID: 6050
	public bool BloomDisabled;

	// Token: 0x040017A3 RID: 6051
	public bool LateStudent;

	// Token: 0x040017A4 RID: 6052
	public bool UpdateBloom;

	// Token: 0x040017A5 RID: 6053
	public bool MissionMode;

	// Token: 0x040017A6 RID: 6054
	public bool ReduceKnee;

	// Token: 0x040017A7 RID: 6055
	public bool StopTime;

	// Token: 0x040017A8 RID: 6056
	public bool TimeSkip;

	// Token: 0x040017A9 RID: 6057
	public bool FadeIn;

	// Token: 0x040017AA RID: 6058
	public bool Horror;

	// Token: 0x040017AB RID: 6059
	public bool Lerp;

	// Token: 0x040017AC RID: 6060
	public AudioSource SchoolBell;

	// Token: 0x040017AD RID: 6061
	public Color SkyboxColor;

	// Token: 0x040017AE RID: 6062
	public float BloomIntensity = 11f;

	// Token: 0x040017AF RID: 6063
	public float BloomRadius = 7f;

	// Token: 0x040017B0 RID: 6064
	public float BloomKnee = 1f;

	// Token: 0x040017B1 RID: 6065
	public UISprite BathroomDimSprite;

	// Token: 0x040017B2 RID: 6066
	public Light[] BathroomLight;

	// Token: 0x040017B3 RID: 6067
	public Collider[] Bathroom;
}
