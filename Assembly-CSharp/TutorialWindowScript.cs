﻿using System;
using UnityEngine;

// Token: 0x02000491 RID: 1169
public class TutorialWindowScript : MonoBehaviour
{
	// Token: 0x06001F3D RID: 7997 RVA: 0x001BC184 File Offset: 0x001BA384
	private void Start()
	{
		base.transform.localScale = new Vector3(0f, 0f, 0f);
		if (OptionGlobals.TutorialsOff)
		{
			base.enabled = false;
			return;
		}
		this.IgnoreClothing = TutorialGlobals.IgnoreClothing;
		this.IgnoreCouncil = TutorialGlobals.IgnoreCouncil;
		this.IgnoreTeacher = TutorialGlobals.IgnoreTeacher;
		this.IgnoreLocker = TutorialGlobals.IgnoreLocker;
		this.IgnorePolice = TutorialGlobals.IgnorePolice;
		this.IgnoreSanity = TutorialGlobals.IgnoreSanity;
		this.IgnoreSenpai = TutorialGlobals.IgnoreSenpai;
		this.IgnoreVision = TutorialGlobals.IgnoreVision;
		this.IgnoreWeapon = TutorialGlobals.IgnoreWeapon;
		this.IgnoreBlood = TutorialGlobals.IgnoreBlood;
		this.IgnoreClass = TutorialGlobals.IgnoreClass;
		this.IgnoreMoney = TutorialGlobals.IgnoreMoney;
		this.IgnorePhoto = TutorialGlobals.IgnorePhoto;
		this.IgnoreClub = TutorialGlobals.IgnoreClub;
		this.IgnoreInfo = TutorialGlobals.IgnoreInfo;
		this.IgnorePool = TutorialGlobals.IgnorePool;
		this.IgnoreRep = TutorialGlobals.IgnoreRep;
	}

	// Token: 0x06001F3E RID: 7998 RVA: 0x001BC27C File Offset: 0x001BA47C
	private void Update()
	{
		if (this.Show)
		{
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1.2925f, 1.2925f, 1.2925f), Time.unscaledDeltaTime * 10f);
			if (base.transform.localScale.x > 1f)
			{
				if (Input.GetButtonDown("A"))
				{
					if (this.ForcingTutorial)
					{
						this.ShowTutorial();
					}
					this.Yandere.RPGCamera.enabled = true;
					this.Yandere.Blur.enabled = false;
					Time.timeScale = 1f;
					this.Show = false;
					this.Hide = true;
				}
				else if (Input.GetButtonDown("B"))
				{
					if (this.DisableButton.activeInHierarchy)
					{
						OptionGlobals.TutorialsOff = true;
						this.TutorialLabel.gameObject.SetActive(true);
						this.ShortLabel.gameObject.SetActive(false);
						this.DisableButton.SetActive(false);
						this.TitleLabel.text = "Tutorials Disabled";
						this.TutorialLabel.text = this.DisabledString;
						this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
						this.TutorialImage.mainTexture = this.DisabledTexture;
						this.ShadowLabel.text = this.TutorialLabel.text;
					}
				}
				else if (Input.GetButtonDown("X") && this.ShortLabel.gameObject.activeInHierarchy)
				{
					this.TutorialLabel.gameObject.SetActive(true);
					this.ShortLabel.gameObject.SetActive(false);
				}
			}
		}
		else if (this.Hide)
		{
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(0f, 0f, 0f), Time.unscaledDeltaTime * 10f);
			if (base.transform.localScale.x < 0.1f)
			{
				base.transform.localScale = new Vector3(0f, 0f, 0f);
				this.Hide = false;
				if (OptionGlobals.TutorialsOff)
				{
					base.enabled = false;
				}
			}
		}
		if (this.HintTimer > 0f)
		{
			this.HintTimer = Mathf.MoveTowards(this.HintTimer, 0f, Time.deltaTime);
			return;
		}
		if (this.ForcingTutorial || (this.Yandere.CanMove && !this.Yandere.Egg && !this.Yandere.Aiming && !this.Yandere.PauseScreen.Show && !this.Yandere.CinematicCamera.activeInHierarchy))
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 5f)
			{
				if ((this.ForcingTutorial || !this.IgnoreClothing) && this.ShowClothingMessage && !this.Show)
				{
					if (!this.ForcingTutorial)
					{
						TutorialGlobals.IgnoreClothing = true;
						this.IgnoreClothing = true;
					}
					this.TitleLabel.text = "No Spare Clothing";
					this.TutorialLabel.text = this.ClothingString;
					this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
					this.TutorialImage.mainTexture = this.ClothingTexture;
					this.ShortLabel.text = this.ClothingShortString;
					this.DisplayHint();
				}
				if ((this.ForcingTutorial || !this.IgnoreCouncil) && this.ShowCouncilMessage && !this.Show)
				{
					if (!this.ForcingTutorial)
					{
						TutorialGlobals.IgnoreCouncil = true;
						this.IgnoreCouncil = true;
					}
					this.TitleLabel.text = "Student Council";
					this.TutorialLabel.text = this.CouncilString;
					this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
					this.TutorialImage.mainTexture = this.CouncilTexture;
					this.ShortLabel.text = this.CouncilShortString;
					this.DisplayHint();
				}
				if ((this.ForcingTutorial || !this.IgnoreTeacher) && this.ShowTeacherMessage && !this.Show)
				{
					if (!this.ForcingTutorial)
					{
						TutorialGlobals.IgnoreTeacher = true;
						this.IgnoreTeacher = true;
					}
					this.TitleLabel.text = "Teachers";
					this.TutorialLabel.text = this.TeacherString;
					this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
					this.TutorialImage.mainTexture = this.TeacherTexture;
					this.ShortLabel.text = this.TeacherShortString;
					this.DisplayHint();
				}
				if ((this.ForcingTutorial || !this.IgnoreLocker) && this.ShowLockerMessage && !this.Show)
				{
					if (!this.ForcingTutorial)
					{
						TutorialGlobals.IgnoreLocker = true;
						this.IgnoreLocker = true;
					}
					this.TitleLabel.text = "Notes In Lockers";
					this.TutorialLabel.text = this.LockerString;
					this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
					this.TutorialImage.mainTexture = this.LockerTexture;
					this.ShortLabel.text = this.LockerShortString;
					this.DisplayHint();
				}
				if ((this.ForcingTutorial || !this.IgnorePolice) && this.ShowPoliceMessage && !this.Show)
				{
					if (!this.ForcingTutorial)
					{
						TutorialGlobals.IgnorePolice = true;
						this.IgnorePolice = true;
					}
					this.TitleLabel.text = "Police";
					this.TutorialLabel.text = this.PoliceString;
					this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
					this.TutorialImage.mainTexture = this.PoliceTexture;
					this.ShortLabel.text = this.PoliceShortString;
					this.DisplayHint();
				}
				if ((this.ForcingTutorial || !this.IgnoreSanity) && this.ShowSanityMessage && !this.Show)
				{
					if (!this.ForcingTutorial)
					{
						TutorialGlobals.IgnoreSanity = true;
						this.IgnoreSanity = true;
					}
					this.TitleLabel.text = "Restoring Sanity";
					this.TutorialLabel.text = this.SanityString;
					this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
					this.TutorialImage.mainTexture = this.SanityTexture;
					this.ShortLabel.text = this.SanityShortString;
					this.DisplayHint();
				}
				if ((this.ForcingTutorial || !this.IgnoreSenpai) && this.ShowSenpaiMessage && !this.Show)
				{
					if (!this.ForcingTutorial)
					{
						TutorialGlobals.IgnoreSenpai = true;
						this.IgnoreSenpai = true;
					}
					this.TitleLabel.text = "Your Senpai";
					this.TutorialLabel.text = this.SenpaiString;
					this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
					this.TutorialImage.mainTexture = this.SenpaiTexture;
					this.ShortLabel.text = this.SenpaiShortString;
					this.DisplayHint();
				}
				if (this.ForcingTutorial || !this.IgnoreVision)
				{
					if (this.Yandere.StudentManager.WestBathroomArea.bounds.Contains(this.Yandere.transform.position) || this.Yandere.StudentManager.EastBathroomArea.bounds.Contains(this.Yandere.transform.position))
					{
						this.ShowVisionMessage = true;
					}
					if (this.ShowVisionMessage && !this.Show)
					{
						if (!this.ForcingTutorial)
						{
							TutorialGlobals.IgnoreVision = true;
							this.IgnoreVision = true;
						}
						this.TitleLabel.text = "Yandere Vision";
						this.TutorialLabel.text = this.VisionString;
						this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
						this.TutorialImage.mainTexture = this.VisionTexture;
						this.ShortLabel.text = this.VisionShortString;
						this.DisplayHint();
					}
				}
				if (this.ForcingTutorial || !this.IgnoreWeapon)
				{
					if (this.Yandere.Armed)
					{
						this.ShowWeaponMessage = true;
					}
					if (this.ShowWeaponMessage && !this.Show)
					{
						if (!this.ForcingTutorial)
						{
							TutorialGlobals.IgnoreWeapon = true;
							this.IgnoreWeapon = true;
						}
						this.TitleLabel.text = "Weapons";
						this.TutorialLabel.text = this.WeaponString;
						this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
						this.TutorialImage.mainTexture = this.WeaponTexture;
						this.ShortLabel.text = this.WeaponShortString;
						this.DisplayHint();
					}
				}
				if ((this.ForcingTutorial || !this.IgnoreBlood) && this.ShowBloodMessage && !this.Show)
				{
					if (!this.ForcingTutorial)
					{
						TutorialGlobals.IgnoreBlood = true;
						this.IgnoreBlood = true;
					}
					this.TitleLabel.text = "Bloody Clothing";
					this.TutorialLabel.text = this.BloodString;
					this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
					this.TutorialImage.mainTexture = this.BloodTexture;
					this.ShortLabel.text = this.BloodShortString;
					this.DisplayHint();
				}
				if ((this.ForcingTutorial || !this.IgnoreClass) && this.ShowClassMessage && !this.Show)
				{
					if (!this.ForcingTutorial)
					{
						TutorialGlobals.IgnoreClass = true;
						this.IgnoreClass = true;
					}
					this.TitleLabel.text = "Attending Class";
					this.TutorialLabel.text = this.ClassString;
					this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
					this.TutorialImage.mainTexture = this.ClassTexture;
					this.ShortLabel.text = this.ClassShortString;
					this.DisplayHint();
				}
				if ((this.ForcingTutorial || !this.IgnoreMoney) && this.ShowMoneyMessage && !this.Show)
				{
					if (!this.ForcingTutorial)
					{
						TutorialGlobals.IgnoreMoney = true;
						this.IgnoreMoney = true;
					}
					this.TitleLabel.text = "Getting Money";
					this.TutorialLabel.text = this.MoneyString;
					this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
					this.TutorialImage.mainTexture = this.MoneyTexture;
					this.ShortLabel.text = this.MoneyShortString;
					this.DisplayHint();
				}
				if (this.ForcingTutorial || !this.IgnorePhoto)
				{
					if (!this.ForcingTutorial && this.Yandere.transform.position.z > -50f)
					{
						this.ShowPhotoMessage = true;
					}
					if (this.ShowPhotoMessage && !this.Show)
					{
						if (!this.ForcingTutorial)
						{
							TutorialGlobals.IgnorePhoto = true;
							this.IgnorePhoto = true;
						}
						this.TitleLabel.text = "Taking Photographs";
						this.TutorialLabel.text = this.PhotoString;
						this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
						this.TutorialImage.mainTexture = this.PhotoTexture;
						this.ShortLabel.text = this.PhotoShortString;
						this.DisplayHint();
					}
				}
				if ((this.ForcingTutorial || !this.IgnoreClub) && this.ShowClubMessage && !this.Show)
				{
					if (!this.ForcingTutorial)
					{
						TutorialGlobals.IgnoreClub = true;
						this.IgnoreClub = true;
					}
					this.TitleLabel.text = "Joining Clubs";
					this.TutorialLabel.text = this.ClubString;
					this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
					this.TutorialImage.mainTexture = this.ClubTexture;
					this.ShortLabel.text = this.ClubShortString;
					this.DisplayHint();
				}
				if ((this.ForcingTutorial || !this.IgnoreInfo) && this.ShowInfoMessage && !this.Show)
				{
					if (!this.ForcingTutorial)
					{
						TutorialGlobals.IgnoreInfo = true;
						this.IgnoreInfo = true;
					}
					this.TitleLabel.text = "Info-chan's Services";
					this.TutorialLabel.text = this.InfoString;
					this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
					this.TutorialImage.mainTexture = this.InfoTexture;
					this.ShortLabel.text = this.InfoShortString;
					this.DisplayHint();
				}
				if ((this.ForcingTutorial || !this.IgnorePool) && this.ShowPoolMessage && !this.Show)
				{
					if (!this.ForcingTutorial)
					{
						TutorialGlobals.IgnorePool = true;
						this.IgnorePool = true;
					}
					this.TitleLabel.text = "Cleaning Blood";
					this.TutorialLabel.text = this.PoolString;
					this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
					this.TutorialImage.mainTexture = this.PoolTexture;
					this.ShortLabel.text = this.PoolShortString;
					this.DisplayHint();
				}
				if ((this.ForcingTutorial || !this.IgnoreRep) && this.ShowRepMessage && !this.Show)
				{
					if (!this.ForcingTutorial)
					{
						TutorialGlobals.IgnoreRep = true;
						this.IgnoreRep = true;
					}
					this.TitleLabel.text = "Reputation";
					this.TutorialLabel.text = this.RepString;
					this.TutorialLabel.text = this.TutorialLabel.text.Replace('@', '\n');
					this.TutorialImage.mainTexture = this.RepTexture;
					this.ShortLabel.text = this.RepShortString;
					this.DisplayHint();
				}
			}
		}
	}

	// Token: 0x06001F3F RID: 7999 RVA: 0x001BD100 File Offset: 0x001BB300
	public void DisplayHint()
	{
		if (!this.Yandere.PauseScreen.Show)
		{
			this.Yandere.PauseScreen.Hint.Show = true;
			this.Yandere.PauseScreen.Hint.DisplayTutorial = true;
			this.HintTimer = 10f;
		}
	}

	// Token: 0x06001F40 RID: 8000 RVA: 0x001BD158 File Offset: 0x001BB358
	public void SummonWindow()
	{
		Debug.Log("SummonWindow() has been called.");
		this.ShadowLabel.text = this.TutorialLabel.text;
		this.ShortShadow.text = this.ShortLabel.text;
		this.Yandere.RPGCamera.enabled = false;
		this.Yandere.Blur.enabled = true;
		Time.timeScale = 0f;
		this.HintTimer = 1f;
		this.Show = true;
		this.Timer = 0f;
		if (this.ForcingTutorial)
		{
			this.TutorialLabel.gameObject.SetActive(true);
			this.ShortLabel.gameObject.SetActive(false);
			return;
		}
		this.TutorialLabel.gameObject.SetActive(false);
		this.ShortLabel.gameObject.SetActive(true);
	}

	// Token: 0x06001F41 RID: 8001 RVA: 0x001BD234 File Offset: 0x001BB434
	public void ShowTutorial()
	{
		Debug.Log("ShowTutorial() has been called, and ForceID is: " + this.ForceID.ToString());
		if (!this.ForcingTutorial)
		{
			Debug.Log("ForcingTutorial is being set to true.");
			this.TutorialLabel.gameObject.SetActive(true);
			this.ShortLabel.gameObject.SetActive(false);
			this.DisableButton.SetActive(false);
			this.ContinueLabel.text = "RETURN";
			this.ForcingTutorial = true;
			this.HintTimer = 0f;
			this.Timer = 6f;
		}
		else
		{
			this.TutorialLabel.gameObject.SetActive(false);
			this.ShortLabel.gameObject.SetActive(true);
			this.DisableButton.SetActive(true);
			this.ContinueLabel.text = "EXIT";
			this.ForcingTutorial = false;
			this.Timer = 0f;
		}
		this.ShowClothingMessage = false;
		this.ShowCouncilMessage = false;
		this.ShowTeacherMessage = false;
		this.ShowLockerMessage = false;
		this.ShowPoliceMessage = false;
		this.ShowSanityMessage = false;
		this.ShowSenpaiMessage = false;
		this.ShowVisionMessage = false;
		this.ShowWeaponMessage = false;
		this.ShowBloodMessage = false;
		this.ShowClassMessage = false;
		this.ShowMoneyMessage = false;
		this.ShowPhotoMessage = false;
		this.ShowClubMessage = false;
		this.ShowInfoMessage = false;
		this.ShowPoolMessage = false;
		this.ShowRepMessage = false;
		switch (this.ForceID)
		{
		case 1:
			this.ShowClothingMessage = this.ForcingTutorial;
			this.IgnoreClothing = false;
			break;
		case 2:
			this.ShowCouncilMessage = this.ForcingTutorial;
			this.IgnoreCouncil = false;
			break;
		case 3:
			this.ShowTeacherMessage = this.ForcingTutorial;
			this.IgnoreTeacher = false;
			break;
		case 4:
			this.ShowLockerMessage = this.ForcingTutorial;
			this.IgnoreLocker = false;
			break;
		case 5:
			this.ShowPoliceMessage = this.ForcingTutorial;
			this.IgnorePolice = false;
			break;
		case 6:
			this.ShowSenpaiMessage = this.ForcingTutorial;
			this.IgnoreSenpai = false;
			break;
		case 7:
			this.ShowVisionMessage = this.ForcingTutorial;
			this.IgnoreVision = false;
			break;
		case 8:
			this.ShowWeaponMessage = this.ForcingTutorial;
			this.IgnoreWeapon = false;
			break;
		case 9:
			this.ShowSanityMessage = this.ForcingTutorial;
			this.IgnoreSanity = false;
			break;
		case 10:
			this.ShowBloodMessage = this.ForcingTutorial;
			this.IgnoreBlood = false;
			break;
		case 11:
			this.ShowClassMessage = this.ForcingTutorial;
			this.IgnoreClass = false;
			break;
		case 12:
			this.ShowPhotoMessage = this.ForcingTutorial;
			this.IgnorePhoto = false;
			break;
		case 13:
			this.ShowClubMessage = this.ForcingTutorial;
			this.IgnoreClub = false;
			break;
		case 14:
			this.ShowInfoMessage = this.ForcingTutorial;
			this.IgnoreInfo = false;
			break;
		case 15:
			this.ShowPoolMessage = this.ForcingTutorial;
			this.IgnorePool = false;
			break;
		case 16:
			this.ShowRepMessage = this.ForcingTutorial;
			this.IgnoreRep = false;
			break;
		case 17:
			this.ShowMoneyMessage = this.ForcingTutorial;
			this.IgnoreMoney = false;
			break;
		}
		this.Update();
		switch (this.ForceID)
		{
		case 1:
			this.ShowClothingMessage = this.ForcingTutorial;
			this.IgnoreClothing = true;
			return;
		case 2:
			this.ShowCouncilMessage = this.ForcingTutorial;
			this.IgnoreCouncil = true;
			return;
		case 3:
			this.ShowTeacherMessage = this.ForcingTutorial;
			this.IgnoreTeacher = true;
			return;
		case 4:
			this.ShowLockerMessage = this.ForcingTutorial;
			this.IgnoreLocker = true;
			return;
		case 5:
			this.ShowPoliceMessage = this.ForcingTutorial;
			this.IgnorePolice = true;
			return;
		case 6:
			this.ShowSenpaiMessage = this.ForcingTutorial;
			this.IgnoreSenpai = true;
			return;
		case 7:
			this.ShowVisionMessage = this.ForcingTutorial;
			this.IgnoreVision = true;
			return;
		case 8:
			this.ShowWeaponMessage = this.ForcingTutorial;
			this.IgnoreWeapon = true;
			return;
		case 9:
			this.ShowSanityMessage = this.ForcingTutorial;
			this.IgnoreSanity = true;
			return;
		case 10:
			this.ShowBloodMessage = this.ForcingTutorial;
			this.IgnoreBlood = true;
			return;
		case 11:
			this.ShowClassMessage = this.ForcingTutorial;
			this.IgnoreClass = true;
			return;
		case 12:
			this.ShowPhotoMessage = this.ForcingTutorial;
			this.IgnorePhoto = true;
			return;
		case 13:
			this.ShowClubMessage = this.ForcingTutorial;
			this.IgnoreClub = true;
			return;
		case 14:
			this.ShowInfoMessage = this.ForcingTutorial;
			this.IgnoreInfo = true;
			return;
		case 15:
			this.ShowPoolMessage = this.ForcingTutorial;
			this.IgnorePool = true;
			return;
		case 16:
			this.ShowRepMessage = this.ForcingTutorial;
			this.IgnoreRep = true;
			return;
		case 17:
			this.ShowMoneyMessage = this.ForcingTutorial;
			this.IgnoreMoney = true;
			return;
		default:
			return;
		}
	}

	// Token: 0x04004188 RID: 16776
	public YandereScript Yandere;

	// Token: 0x04004189 RID: 16777
	public bool ShowClothingMessage;

	// Token: 0x0400418A RID: 16778
	public bool ShowCouncilMessage;

	// Token: 0x0400418B RID: 16779
	public bool ShowTeacherMessage;

	// Token: 0x0400418C RID: 16780
	public bool ShowLockerMessage;

	// Token: 0x0400418D RID: 16781
	public bool ShowPoliceMessage;

	// Token: 0x0400418E RID: 16782
	public bool ShowSanityMessage;

	// Token: 0x0400418F RID: 16783
	public bool ShowSenpaiMessage;

	// Token: 0x04004190 RID: 16784
	public bool ShowVisionMessage;

	// Token: 0x04004191 RID: 16785
	public bool ShowWeaponMessage;

	// Token: 0x04004192 RID: 16786
	public bool ShowBloodMessage;

	// Token: 0x04004193 RID: 16787
	public bool ShowClassMessage;

	// Token: 0x04004194 RID: 16788
	public bool ShowMoneyMessage;

	// Token: 0x04004195 RID: 16789
	public bool ShowPhotoMessage;

	// Token: 0x04004196 RID: 16790
	public bool ShowClubMessage;

	// Token: 0x04004197 RID: 16791
	public bool ShowInfoMessage;

	// Token: 0x04004198 RID: 16792
	public bool ShowPoolMessage;

	// Token: 0x04004199 RID: 16793
	public bool ShowRepMessage;

	// Token: 0x0400419A RID: 16794
	public bool IgnoreClothing;

	// Token: 0x0400419B RID: 16795
	public bool IgnoreCouncil;

	// Token: 0x0400419C RID: 16796
	public bool IgnoreTeacher;

	// Token: 0x0400419D RID: 16797
	public bool IgnoreLocker;

	// Token: 0x0400419E RID: 16798
	public bool IgnorePolice;

	// Token: 0x0400419F RID: 16799
	public bool IgnoreSanity;

	// Token: 0x040041A0 RID: 16800
	public bool IgnoreSenpai;

	// Token: 0x040041A1 RID: 16801
	public bool IgnoreVision;

	// Token: 0x040041A2 RID: 16802
	public bool IgnoreWeapon;

	// Token: 0x040041A3 RID: 16803
	public bool IgnoreBlood;

	// Token: 0x040041A4 RID: 16804
	public bool IgnoreClass;

	// Token: 0x040041A5 RID: 16805
	public bool IgnoreMoney;

	// Token: 0x040041A6 RID: 16806
	public bool IgnorePhoto;

	// Token: 0x040041A7 RID: 16807
	public bool IgnoreClub;

	// Token: 0x040041A8 RID: 16808
	public bool IgnoreInfo;

	// Token: 0x040041A9 RID: 16809
	public bool IgnorePool;

	// Token: 0x040041AA RID: 16810
	public bool IgnoreRep;

	// Token: 0x040041AB RID: 16811
	public bool Hide;

	// Token: 0x040041AC RID: 16812
	public bool Show;

	// Token: 0x040041AD RID: 16813
	public UILabel TutorialLabel;

	// Token: 0x040041AE RID: 16814
	public UILabel ShadowLabel;

	// Token: 0x040041AF RID: 16815
	public UILabel TitleLabel;

	// Token: 0x040041B0 RID: 16816
	public UITexture TutorialImage;

	// Token: 0x040041B1 RID: 16817
	public string DisabledShortString;

	// Token: 0x040041B2 RID: 16818
	public string DisabledString;

	// Token: 0x040041B3 RID: 16819
	public Texture DisabledTexture;

	// Token: 0x040041B4 RID: 16820
	public string ClothingShortString;

	// Token: 0x040041B5 RID: 16821
	public string ClothingString;

	// Token: 0x040041B6 RID: 16822
	public Texture ClothingTexture;

	// Token: 0x040041B7 RID: 16823
	public string CouncilShortString;

	// Token: 0x040041B8 RID: 16824
	public string CouncilString;

	// Token: 0x040041B9 RID: 16825
	public Texture CouncilTexture;

	// Token: 0x040041BA RID: 16826
	public string TeacherShortString;

	// Token: 0x040041BB RID: 16827
	public string TeacherString;

	// Token: 0x040041BC RID: 16828
	public Texture TeacherTexture;

	// Token: 0x040041BD RID: 16829
	public string LockerShortString;

	// Token: 0x040041BE RID: 16830
	public string LockerString;

	// Token: 0x040041BF RID: 16831
	public Texture LockerTexture;

	// Token: 0x040041C0 RID: 16832
	public string PoliceShortString;

	// Token: 0x040041C1 RID: 16833
	public string PoliceString;

	// Token: 0x040041C2 RID: 16834
	public Texture PoliceTexture;

	// Token: 0x040041C3 RID: 16835
	public string SanityShortString;

	// Token: 0x040041C4 RID: 16836
	public string SanityString;

	// Token: 0x040041C5 RID: 16837
	public Texture SanityTexture;

	// Token: 0x040041C6 RID: 16838
	public string SenpaiShortString;

	// Token: 0x040041C7 RID: 16839
	public string SenpaiString;

	// Token: 0x040041C8 RID: 16840
	public Texture SenpaiTexture;

	// Token: 0x040041C9 RID: 16841
	public string VisionShortString;

	// Token: 0x040041CA RID: 16842
	public string VisionString;

	// Token: 0x040041CB RID: 16843
	public Texture VisionTexture;

	// Token: 0x040041CC RID: 16844
	public string WeaponShortString;

	// Token: 0x040041CD RID: 16845
	public string WeaponString;

	// Token: 0x040041CE RID: 16846
	public Texture WeaponTexture;

	// Token: 0x040041CF RID: 16847
	public string BloodShortString;

	// Token: 0x040041D0 RID: 16848
	public string BloodString;

	// Token: 0x040041D1 RID: 16849
	public Texture BloodTexture;

	// Token: 0x040041D2 RID: 16850
	public string ClassShortString;

	// Token: 0x040041D3 RID: 16851
	public string ClassString;

	// Token: 0x040041D4 RID: 16852
	public Texture ClassTexture;

	// Token: 0x040041D5 RID: 16853
	public string MoneyShortString;

	// Token: 0x040041D6 RID: 16854
	public string MoneyString;

	// Token: 0x040041D7 RID: 16855
	public Texture MoneyTexture;

	// Token: 0x040041D8 RID: 16856
	public string PhotoShortString;

	// Token: 0x040041D9 RID: 16857
	public string PhotoString;

	// Token: 0x040041DA RID: 16858
	public Texture PhotoTexture;

	// Token: 0x040041DB RID: 16859
	public string ClubShortString;

	// Token: 0x040041DC RID: 16860
	public string ClubString;

	// Token: 0x040041DD RID: 16861
	public Texture ClubTexture;

	// Token: 0x040041DE RID: 16862
	public string InfoShortString;

	// Token: 0x040041DF RID: 16863
	public string InfoString;

	// Token: 0x040041E0 RID: 16864
	public Texture InfoTexture;

	// Token: 0x040041E1 RID: 16865
	public string PoolShortString;

	// Token: 0x040041E2 RID: 16866
	public string PoolString;

	// Token: 0x040041E3 RID: 16867
	public Texture PoolTexture;

	// Token: 0x040041E4 RID: 16868
	public string RepShortString;

	// Token: 0x040041E5 RID: 16869
	public string RepString;

	// Token: 0x040041E6 RID: 16870
	public Texture RepTexture;

	// Token: 0x040041E7 RID: 16871
	public string PointsShortString;

	// Token: 0x040041E8 RID: 16872
	public string PointsString;

	// Token: 0x040041E9 RID: 16873
	public float HintTimer;

	// Token: 0x040041EA RID: 16874
	public float Timer;

	// Token: 0x040041EB RID: 16875
	public bool ForcingTutorial;

	// Token: 0x040041EC RID: 16876
	public int ForceID;

	// Token: 0x040041ED RID: 16877
	public GameObject DisableButton;

	// Token: 0x040041EE RID: 16878
	public UILabel ContinueLabel;

	// Token: 0x040041EF RID: 16879
	public UILabel ShortLabel;

	// Token: 0x040041F0 RID: 16880
	public UILabel ShortShadow;
}
