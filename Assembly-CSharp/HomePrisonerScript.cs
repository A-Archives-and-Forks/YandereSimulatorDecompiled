﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000320 RID: 800
public class HomePrisonerScript : MonoBehaviour
{
	// Token: 0x0600187D RID: 6269 RVA: 0x000EF350 File Offset: 0x000ED550
	private void Start()
	{
		this.Sanity = StudentGlobals.GetStudentSanity(SchoolGlobals.KidnapVictim);
		this.SanityLabel.text = "Sanity: " + this.Sanity.ToString() + "%";
		this.Prisoner.Sanity = this.Sanity;
		this.Subtitle.text = string.Empty;
		if (this.Sanity == 100f)
		{
			this.BanterText = this.FullSanityBanterText;
			this.Banter = this.FullSanityBanter;
		}
		else if (this.Sanity >= 50f)
		{
			this.BanterText = this.HighSanityBanterText;
			this.Banter = this.HighSanityBanter;
		}
		else if (this.Sanity == 0f)
		{
			this.BanterText = this.NoSanityBanterText;
			this.Banter = this.NoSanityBanter;
		}
		else
		{
			this.BanterText = this.LowSanityBanterText;
			this.Banter = this.LowSanityBanter;
		}
		if (this.Sanity < 100f)
		{
			this.Prisoner.Character.GetComponent<Animation>().CrossFade("f02_kidnapIdle_02");
		}
		if (!HomeGlobals.Night)
		{
			UILabel uilabel = this.OptionLabels[2];
			uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0.5f);
			if (HomeGlobals.LateForSchool)
			{
				UILabel uilabel2 = this.OptionLabels[1];
				uilabel2.color = new Color(uilabel2.color.r, uilabel2.color.g, uilabel2.color.b, 0.5f);
			}
			if (DateGlobals.Weekday == DayOfWeek.Friday)
			{
				UILabel uilabel3 = this.OptionLabels[3];
				uilabel3.color = new Color(uilabel3.color.r, uilabel3.color.g, uilabel3.color.b, 0.5f);
				UILabel uilabel4 = this.OptionLabels[4];
				uilabel4.color = new Color(uilabel4.color.r, uilabel4.color.g, uilabel4.color.b, 0.5f);
			}
		}
		else
		{
			UILabel uilabel5 = this.OptionLabels[1];
			uilabel5.color = new Color(uilabel5.color.r, uilabel5.color.g, uilabel5.color.b, 0.5f);
			UILabel uilabel6 = this.OptionLabels[3];
			uilabel6.color = new Color(uilabel6.color.r, uilabel6.color.g, uilabel6.color.b, 0.5f);
			UILabel uilabel7 = this.OptionLabels[4];
			uilabel7.color = new Color(uilabel7.color.r, uilabel7.color.g, uilabel7.color.b, 0.5f);
		}
		if (this.Sanity > 0f)
		{
			this.OptionLabels[5].text = "?????";
			UILabel uilabel8 = this.OptionLabels[5];
			uilabel8.color = new Color(uilabel8.color.r, uilabel8.color.g, uilabel8.color.b, 0.5f);
		}
		else
		{
			this.OptionLabels[5].text = "Bring to School";
			UILabel uilabel9 = this.OptionLabels[1];
			uilabel9.color = new Color(uilabel9.color.r, uilabel9.color.g, uilabel9.color.b, 0.5f);
			UILabel uilabel10 = this.OptionLabels[2];
			uilabel10.color = new Color(uilabel10.color.r, uilabel10.color.g, uilabel10.color.b, 0.5f);
			UILabel uilabel11 = this.OptionLabels[3];
			uilabel11.color = new Color(uilabel11.color.r, uilabel11.color.g, uilabel11.color.b, 0.5f);
			UILabel uilabel12 = this.OptionLabels[4];
			uilabel12.color = new Color(uilabel12.color.r, uilabel12.color.g, uilabel12.color.b, 0.5f);
			UILabel uilabel13 = this.OptionLabels[5];
			uilabel13.color = new Color(uilabel13.color.r, uilabel13.color.g, uilabel13.color.b, 1f);
			if (HomeGlobals.Night)
			{
				uilabel13.color = new Color(uilabel13.color.r, uilabel13.color.g, uilabel13.color.b, 0.5f);
			}
		}
		this.UpdateDesc();
		if (SchoolGlobals.KidnapVictim == 0)
		{
			base.enabled = false;
		}
		if (GameGlobals.Eighties)
		{
			this.Prisoner = this.EightiesPrisoner;
			return;
		}
		this.EightiesPrisoner.gameObject.SetActive(false);
	}

	// Token: 0x0600187E RID: 6270 RVA: 0x000EF854 File Offset: 0x000EDA54
	private void Update()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		if (Vector3.Distance(this.HomeYandere.transform.position, this.Prisoner.transform.position) < 2f && this.HomeYandere.CanMove)
		{
			this.BanterTimer += Time.deltaTime;
			if (this.BanterTimer > 5f && !this.Bantering)
			{
				this.Bantering = true;
				if (this.BanterID < this.Banter.Length - 1)
				{
					this.BanterID++;
					this.Subtitle.text = this.BanterText[this.BanterID];
					component.clip = this.Banter[this.BanterID];
					component.Play();
				}
			}
		}
		if (this.Bantering && !component.isPlaying)
		{
			this.Subtitle.text = string.Empty;
			this.Bantering = false;
			this.BanterTimer = 0f;
		}
		if (!this.HomeYandere.CanMove && (this.HomeCamera.Destination == this.HomeCamera.Destinations[10] || this.HomeCamera.Destination == this.TortureDestination))
		{
			if (this.InputManager.TappedDown)
			{
				this.ID++;
				if (this.ID > 5)
				{
					this.ID = 1;
				}
				this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 465f - (float)this.ID * 40f, this.Highlight.localPosition.z);
				this.UpdateDesc();
			}
			if (this.InputManager.TappedUp)
			{
				this.ID--;
				if (this.ID < 1)
				{
					this.ID = 5;
				}
				this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 465f - (float)this.ID * 40f, this.Highlight.localPosition.z);
				this.UpdateDesc();
			}
			if (Input.GetKeyDown(KeyCode.X))
			{
				this.Sanity -= 10f;
				if (this.Sanity < 0f)
				{
					this.Sanity = 100f;
				}
				StudentGlobals.SetStudentSanity(SchoolGlobals.KidnapVictim, this.Sanity);
				this.SanityLabel.text = "Sanity: " + this.Sanity.ToString("f0") + "%";
				this.Prisoner.UpdateSanity();
			}
			if (!this.ZoomIn)
			{
				if (Input.GetButtonDown("A") && this.OptionLabels[this.ID].color.a == 1f)
				{
					if (this.Sanity > 0f)
					{
						if (this.Sanity == 100f)
						{
							this.Prisoner.Character.GetComponent<Animation>().CrossFade("f02_kidnapTorture_01");
						}
						else if (this.Sanity >= 50f)
						{
							this.Prisoner.Character.GetComponent<Animation>().CrossFade("f02_kidnapTorture_02");
						}
						else
						{
							this.Prisoner.Character.GetComponent<Animation>().CrossFade("f02_kidnapSurrender_00");
							this.TortureDestination.localPosition = new Vector3(this.TortureDestination.localPosition.x, 0f, 1f);
							this.TortureTarget.localPosition = new Vector3(this.TortureTarget.localPosition.x, 1.1f, this.TortureTarget.localPosition.z);
						}
						this.HomeCamera.Destination = this.TortureDestination;
						this.HomeCamera.Target = this.TortureTarget;
						this.HomeCamera.Torturing = true;
						this.Prisoner.Tortured = true;
						this.Prisoner.RightEyeRotOrigin.x = -6f;
						this.Prisoner.LeftEyeRotOrigin.x = 6f;
						this.ZoomIn = true;
						this.HomeCamera.UpdateDOF(0.6f);
					}
					else
					{
						this.Darkness.FadeOut = true;
					}
					this.HomeWindow.Show = false;
					this.HomeCamera.PromptBar.ClearButtons();
					this.HomeCamera.PromptBar.Show = false;
					this.Jukebox.volume -= 0.5f;
				}
				if (Input.GetButtonDown("B"))
				{
					this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
					this.HomeCamera.Target = this.HomeCamera.Targets[0];
					this.HomeCamera.PromptBar.ClearButtons();
					this.HomeCamera.PromptBar.Show = false;
					this.HomeYandere.CanMove = true;
					this.HomeYandere.gameObject.SetActive(true);
					this.HomeWindow.Show = false;
					return;
				}
			}
			else
			{
				this.TortureDestination.Translate(Vector3.forward * (Time.deltaTime * 0.02f));
				this.Jukebox.volume -= Time.deltaTime * 0.05f;
				this.Timer += Time.deltaTime;
				if (this.Sanity >= 50f)
				{
					this.TortureDestination.localPosition = new Vector3(this.TortureDestination.localPosition.x, this.TortureDestination.localPosition.y + Time.deltaTime * 0.05f, this.TortureDestination.localPosition.z);
					if (this.Sanity == 100f)
					{
						if (this.Timer > 2f && !this.PlayedAudio)
						{
							component.clip = this.FirstTorture;
							this.PlayedAudio = true;
							component.Play();
						}
					}
					else if (this.Timer > 1.5f && !this.PlayedAudio)
					{
						component.clip = this.Over50Torture;
						this.PlayedAudio = true;
						component.Play();
					}
				}
				else if (this.Timer > 5f && !this.PlayedAudio)
				{
					component.clip = this.Under50Torture;
					this.PlayedAudio = true;
					component.Play();
				}
				if (this.Timer > 10f && this.Darkness.Sprite.color.a != 1f)
				{
					this.Darkness.enabled = false;
					this.Darkness.Sprite.color = new Color(this.Darkness.Sprite.color.r, this.Darkness.Sprite.color.g, this.Darkness.Sprite.color.b, 1f);
					component.clip = this.TortureHit;
					component.Play();
				}
				if (this.Timer > 15f)
				{
					if (this.ID == 1)
					{
						Time.timeScale = 1f;
						this.NowLoading.SetActive(true);
						HomeGlobals.LateForSchool = true;
						if (DateGlobals.Weekday == DayOfWeek.Saturday)
						{
							DateGlobals.PassDays = 1;
							SceneManager.LoadScene("CalendarScene");
						}
						else
						{
							SceneManager.LoadScene("LoadingScene");
						}
						StudentGlobals.SetStudentSanity(SchoolGlobals.KidnapVictim, this.Sanity - 2f - (float)(ClassGlobals.PsychologyGrade * 10));
					}
					else if (this.ID == 2)
					{
						if (DateGlobals.PassDays < 1)
						{
							DateGlobals.PassDays = 1;
						}
						SceneManager.LoadScene("CalendarScene");
						StudentGlobals.SetStudentSanity(SchoolGlobals.KidnapVictim, this.Sanity - 8f - (float)(ClassGlobals.PsychologyGrade * 10));
					}
					else if (this.ID == 3)
					{
						HomeGlobals.Night = true;
						SceneManager.LoadScene("HomeScene");
						StudentGlobals.SetStudentSanity(SchoolGlobals.KidnapVictim, this.Sanity - 24f - (float)(ClassGlobals.PsychologyGrade * 10));
						PlayerGlobals.Reputation -= 20f;
					}
					else if (this.ID == 4)
					{
						if (DateGlobals.PassDays < 1)
						{
							DateGlobals.PassDays = 1;
						}
						SceneManager.LoadScene("CalendarScene");
						StudentGlobals.SetStudentSanity(SchoolGlobals.KidnapVictim, this.Sanity - 36f);
						PlayerGlobals.Reputation -= 20f;
					}
					if (StudentGlobals.GetStudentSanity(SchoolGlobals.KidnapVictim) < 0f)
					{
						StudentGlobals.SetStudentSanity(SchoolGlobals.KidnapVictim, 0f);
					}
				}
			}
		}
	}

	// Token: 0x0600187F RID: 6271 RVA: 0x000F00D4 File Offset: 0x000EE2D4
	public void UpdateDesc()
	{
		this.HomeCamera.PromptBar.Label[0].text = "Accept";
		this.DescLabel.text = this.Descriptions[this.ID];
		if (!HomeGlobals.Night)
		{
			if (HomeGlobals.LateForSchool && this.ID == 1)
			{
				this.DescLabel.text = "This option is unavailable if you are late for school.";
				this.HomeCamera.PromptBar.Label[0].text = string.Empty;
			}
			if (this.ID == 2)
			{
				this.DescLabel.text = "This option is unavailable in the daytime.";
				this.HomeCamera.PromptBar.Label[0].text = string.Empty;
			}
			if (DateGlobals.Weekday == DayOfWeek.Friday && (this.ID == 3 || this.ID == 4))
			{
				this.DescLabel.text = "This option is unavailable on Friday.";
				this.HomeCamera.PromptBar.Label[0].text = string.Empty;
			}
		}
		else if (this.ID != 2)
		{
			this.DescLabel.text = "This option is unavailable at nighttime.";
			this.HomeCamera.PromptBar.Label[0].text = string.Empty;
		}
		if (this.ID == 5)
		{
			if (this.Sanity > 0f)
			{
				this.DescLabel.text = "This option is unavailable until your prisoner's Sanity has reached zero.";
			}
			if (HomeGlobals.Night)
			{
				this.DescLabel.text = "This option is unavailable at nighttime.";
				this.HomeCamera.PromptBar.Label[0].text = string.Empty;
			}
		}
		this.HomeCamera.PromptBar.UpdateButtons();
	}

	// Token: 0x040024EF RID: 9455
	public HomePrisonerChanScript EightiesPrisoner;

	// Token: 0x040024F0 RID: 9456
	public InputManagerScript InputManager;

	// Token: 0x040024F1 RID: 9457
	public HomePrisonerChanScript Prisoner;

	// Token: 0x040024F2 RID: 9458
	public HomeYandereScript HomeYandere;

	// Token: 0x040024F3 RID: 9459
	public HomeCameraScript HomeCamera;

	// Token: 0x040024F4 RID: 9460
	public HomeWindowScript HomeWindow;

	// Token: 0x040024F5 RID: 9461
	public HomeDarknessScript Darkness;

	// Token: 0x040024F6 RID: 9462
	public UILabel[] OptionLabels;

	// Token: 0x040024F7 RID: 9463
	public string[] Descriptions;

	// Token: 0x040024F8 RID: 9464
	public Transform TortureDestination;

	// Token: 0x040024F9 RID: 9465
	public Transform TortureTarget;

	// Token: 0x040024FA RID: 9466
	public GameObject NowLoading;

	// Token: 0x040024FB RID: 9467
	public Transform Highlight;

	// Token: 0x040024FC RID: 9468
	public AudioSource Jukebox;

	// Token: 0x040024FD RID: 9469
	public UILabel SanityLabel;

	// Token: 0x040024FE RID: 9470
	public UILabel DescLabel;

	// Token: 0x040024FF RID: 9471
	public UILabel Subtitle;

	// Token: 0x04002500 RID: 9472
	public bool PlayedAudio;

	// Token: 0x04002501 RID: 9473
	public bool ZoomIn;

	// Token: 0x04002502 RID: 9474
	public float Sanity = 100f;

	// Token: 0x04002503 RID: 9475
	public float Timer;

	// Token: 0x04002504 RID: 9476
	public int ID = 1;

	// Token: 0x04002505 RID: 9477
	public AudioClip FirstTorture;

	// Token: 0x04002506 RID: 9478
	public AudioClip Under50Torture;

	// Token: 0x04002507 RID: 9479
	public AudioClip Over50Torture;

	// Token: 0x04002508 RID: 9480
	public AudioClip TortureHit;

	// Token: 0x04002509 RID: 9481
	public string[] FullSanityBanterText;

	// Token: 0x0400250A RID: 9482
	public string[] HighSanityBanterText;

	// Token: 0x0400250B RID: 9483
	public string[] LowSanityBanterText;

	// Token: 0x0400250C RID: 9484
	public string[] NoSanityBanterText;

	// Token: 0x0400250D RID: 9485
	public string[] BanterText;

	// Token: 0x0400250E RID: 9486
	public AudioClip[] FullSanityBanter;

	// Token: 0x0400250F RID: 9487
	public AudioClip[] HighSanityBanter;

	// Token: 0x04002510 RID: 9488
	public AudioClip[] LowSanityBanter;

	// Token: 0x04002511 RID: 9489
	public AudioClip[] NoSanityBanter;

	// Token: 0x04002512 RID: 9490
	public AudioClip[] Banter;

	// Token: 0x04002513 RID: 9491
	public float BanterTimer;

	// Token: 0x04002514 RID: 9492
	public bool Bantering;

	// Token: 0x04002515 RID: 9493
	public int BanterID;
}
