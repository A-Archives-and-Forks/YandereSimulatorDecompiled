﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200031B RID: 795
public class HomeDarknessScript : MonoBehaviour
{
	// Token: 0x06001870 RID: 6256 RVA: 0x000EC3DC File Offset: 0x000EA5DC
	private void Start()
	{
		if (GameGlobals.LoveSick)
		{
			this.Sprite.color = new Color(0f, 0f, 0f, 1f);
		}
		this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 1f);
	}

	// Token: 0x06001871 RID: 6257 RVA: 0x000EC45C File Offset: 0x000EA65C
	private void Update()
	{
		if (this.FadeOut)
		{
			this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, this.Sprite.color.a + Time.deltaTime * (this.FadeSlow ? 0.2f : 1f));
			if (this.Sprite.color.a >= 1f)
			{
				this.HomeCamera.Profile.bloom.enabled = this.HomeCamera.RestoreBloom;
				this.HomeCamera.Profile.depthOfField.enabled = this.HomeCamera.RestoreDOF;
				if (this.HomeCamera.ID != 2)
				{
					if (this.HomeCamera.ID == 3)
					{
						if (this.Cyberstalking)
						{
							if (DateGlobals.PassDays < 1)
							{
								DateGlobals.PassDays = 1;
							}
							SceneManager.LoadScene("CalendarScene");
							return;
						}
						SceneManager.LoadScene("YancordScene");
						return;
					}
					else if (this.HomeCamera.ID == 5)
					{
						if (this.HomeVideoGames.ID == 1)
						{
							SceneManager.LoadScene("YanvaniaTitleScene");
							return;
						}
						SceneManager.LoadScene("MiyukiTitleScene");
						return;
					}
					else
					{
						if (this.HomeCamera.ID == 9)
						{
							if (DateGlobals.PassDays < 1)
							{
								DateGlobals.PassDays = 1;
							}
							SceneManager.LoadScene("CalendarScene");
							return;
						}
						if (this.HomeCamera.ID == 10)
						{
							StudentGlobals.SetStudentKidnapped(SchoolGlobals.KidnapVictim, false);
							StudentGlobals.StudentSlave = SchoolGlobals.KidnapVictim;
							this.CheckForOsanaThursday();
							return;
						}
						if (this.HomeCamera.ID == 11)
						{
							EventGlobals.KidnapConversation = true;
							SceneManager.LoadScene("PhoneScene");
							return;
						}
						if (this.HomeCamera.ID == 12)
						{
							SceneManager.LoadScene("LifeNoteScene");
							return;
						}
						if (this.HomeExit.ID == 1)
						{
							this.CheckForOsanaThursday();
							return;
						}
						if (this.HomeExit.ID == 2)
						{
							SceneManager.LoadScene("StreetScene");
							return;
						}
						if (this.HomeExit.ID == 3)
						{
							if (this.HomeYandere.transform.position.y > -5f)
							{
								this.HomeYandere.transform.position = new Vector3(-2f, -10f, -2.75f);
								this.HomeYandere.transform.eulerAngles = new Vector3(0f, 90f, 0f);
								this.HomeYandere.CanMove = true;
								this.FadeOut = false;
								this.HomeCamera.Destinations[0].position = new Vector3(2.425f, -8.5f, 0f);
								this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
								this.HomeCamera.transform.position = this.HomeCamera.Destination.position;
								this.HomeCamera.Target = this.HomeCamera.Targets[0];
								this.HomeCamera.Focus.position = this.HomeCamera.Target.position;
								this.BasementLabel.text = "Upstairs";
								this.HomeCamera.DayLight.SetActive(true);
								this.HomeCamera.DayLight.GetComponent<Light>().intensity = 0.66666f;
								Physics.SyncTransforms();
								return;
							}
							this.HomeYandere.transform.position = new Vector3(-1.6f, 0f, -1.6f);
							this.HomeYandere.transform.eulerAngles = new Vector3(0f, 45f, 0f);
							this.HomeYandere.CanMove = true;
							this.FadeOut = false;
							this.HomeCamera.Destinations[0].position = new Vector3(-2.0615f, 1.5f, 2.418f);
							this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
							this.HomeCamera.transform.position = this.HomeCamera.Destination.position;
							this.HomeCamera.Target = this.HomeCamera.Targets[0];
							this.HomeCamera.Focus.position = this.HomeCamera.Target.position;
							this.BasementLabel.text = "Basement";
							if (HomeGlobals.Night)
							{
								this.HomeCamera.DayLight.SetActive(false);
							}
							this.HomeCamera.DayLight.GetComponent<Light>().intensity = 2f;
							Physics.SyncTransforms();
							return;
						}
						else if (this.HomeExit.ID == 4)
						{
							if (!GameGlobals.Eighties)
							{
								SceneManager.LoadScene("StalkerHouseScene");
								return;
							}
							SceneManager.LoadScene("AsylumScene");
							return;
						}
					}
				}
				else
				{
					if (HomeGlobals.Night)
					{
						if (DateGlobals.Weekday == DayOfWeek.Sunday)
						{
							DateGlobals.ForceSkip = true;
						}
						else if (DateGlobals.PassDays < 1)
						{
							DateGlobals.PassDays = 1;
						}
						SceneManager.LoadScene("CalendarScene");
						return;
					}
					if (DateGlobals.Weekday != DayOfWeek.Sunday)
					{
						PlayerGlobals.Reputation -= 10f;
					}
					HomeGlobals.Night = true;
					SceneManager.LoadScene("HomeScene");
					return;
				}
			}
		}
		else
		{
			this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, this.Sprite.color.a - Time.deltaTime);
			if (this.Sprite.color.a < 0f)
			{
				this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0f);
			}
		}
	}

	// Token: 0x06001872 RID: 6258 RVA: 0x000ECA44 File Offset: 0x000EAC44
	private void CheckForOsanaThursday()
	{
		if (this.InputDevice.Type == InputDeviceType.Gamepad)
		{
			PlayerGlobals.UsingGamepad = true;
		}
		else
		{
			PlayerGlobals.UsingGamepad = false;
		}
		int buildIndexByScenePath = SceneUtility.GetBuildIndexByScenePath("WalkToSchoolScene");
		if (!GameGlobals.Eighties && GameGlobals.RivalEliminationID == 0 && !StudentGlobals.GetStudentKidnapped(11) && StudentGlobals.StudentSlave != 11 && DateGlobals.Weekday == DayOfWeek.Thursday && !HomeGlobals.LateForSchool && StudentGlobals.GetStudentReputation(11) > -100 && buildIndexByScenePath > -1)
		{
			SceneManager.LoadScene("WalkToSchoolScene");
			return;
		}
		if (DateGlobals.Weekday == DayOfWeek.Saturday)
		{
			DateGlobals.PassDays = 1;
			SceneManager.LoadScene("CalendarScene");
			return;
		}
		if (GameGlobals.ShowAbduction)
		{
			SceneManager.LoadScene("AbductionScene");
			GameGlobals.ShowAbduction = false;
			return;
		}
		SceneManager.LoadScene("LoadingScene");
	}

	// Token: 0x04002469 RID: 9321
	public HomeVideoGamesScript HomeVideoGames;

	// Token: 0x0400246A RID: 9322
	public HomeYandereScript HomeYandere;

	// Token: 0x0400246B RID: 9323
	public HomeCameraScript HomeCamera;

	// Token: 0x0400246C RID: 9324
	public HomeExitScript HomeExit;

	// Token: 0x0400246D RID: 9325
	public InputDeviceScript InputDevice;

	// Token: 0x0400246E RID: 9326
	public UILabel BasementLabel;

	// Token: 0x0400246F RID: 9327
	public UISprite Sprite;

	// Token: 0x04002470 RID: 9328
	public bool Cyberstalking;

	// Token: 0x04002471 RID: 9329
	public bool FadeSlow;

	// Token: 0x04002472 RID: 9330
	public bool FadeOut;
}
