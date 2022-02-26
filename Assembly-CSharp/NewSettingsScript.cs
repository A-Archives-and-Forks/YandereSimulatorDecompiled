﻿using System;
using UnityEngine;
using UnityEngine.PostProcessing;

// Token: 0x02000378 RID: 888
public class NewSettingsScript : MonoBehaviour
{
	// Token: 0x060019EF RID: 6639 RVA: 0x0010C626 File Offset: 0x0010A826
	private void Start()
	{
		this.UpdateLabels();
	}

	// Token: 0x060019F0 RID: 6640 RVA: 0x0010C630 File Offset: 0x0010A830
	private void Update()
	{
		this.Cursor.transform.parent.Rotate(new Vector3(Time.unscaledDeltaTime * 100f, 0f, 0f), Space.Self);
		this.Cursor.transform.parent.localPosition = Vector3.Lerp(this.Cursor.transform.parent.localPosition, new Vector3(665f, -100f - 100f * (float)this.Selection, this.Cursor.transform.parent.localPosition.z), Time.unscaledDeltaTime * 10f);
		this.Labels[13].text = (Screen.fullScreen ? "No" : "Yes");
		if (this.Cursor.alpha == 1f)
		{
			if (this.NewTitleScreen.InputManager.TappedDown)
			{
				this.Selection++;
				this.UpdateCursor();
			}
			if (this.NewTitleScreen.InputManager.TappedUp)
			{
				this.Selection--;
				this.UpdateCursor();
			}
		}
		if (this.NewTitleScreen.Speed > 2f)
		{
			if (this.Transition)
			{
				this.Cursor.alpha = Mathf.MoveTowards(this.Cursor.alpha, 0f, Time.unscaledDeltaTime * (float)this.Speed);
				for (int i = 0; i < this.Panel.Length; i++)
				{
					this.Panel[i].alpha = Mathf.MoveTowards(this.Panel[i].alpha, 0f, Time.unscaledDeltaTime * (float)this.Speed);
				}
				if (this.Cursor.alpha == 0f)
				{
					this.Transition = false;
					this.Selection = 1;
					return;
				}
			}
			else
			{
				this.Cursor.alpha = Mathf.MoveTowards(this.Cursor.alpha, 1f, Time.unscaledDeltaTime * (float)this.Speed);
				this.UpdatePanels();
				if (this.Panel[this.Menu].alpha == 1f && this.Cursor.alpha == 1f)
				{
					if (this.Menu == 0)
					{
						if (!this.PromptBar.Show)
						{
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[0].text = "Make Selection";
							this.PromptBar.Label[1].text = "Go Back";
							this.PromptBar.Label[4].text = "Change Selection";
							this.PromptBar.Label[5].text = "Change Selection";
							this.PromptBar.UpdateButtons();
							this.PromptBar.Show = true;
						}
						if (Input.GetButtonDown("A"))
						{
							this.Menu = this.Selection;
							this.Transition = true;
							this.PromptBar.Show = false;
							return;
						}
						if (Input.GetButtonDown("B"))
						{
							if (this.SchoolScene)
							{
								this.PauseScreen.MainMenu.SetActive(true);
								base.gameObject.SetActive(false);
								base.enabled = false;
							}
							this.NewTitleScreen.Speed = 0f;
							this.NewTitleScreen.Phase = 2;
							this.PromptBar.Show = false;
							base.enabled = false;
							return;
						}
					}
					else if (this.Menu == 1)
					{
						if (!this.PromptBar.Show)
						{
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[1].text = "Go Back";
							this.PromptBar.Label[2].text = "Set All to Lowest";
							this.PromptBar.Label[3].text = "Reset All to Default";
							this.PromptBar.Label[4].text = "Change Selection";
							this.PromptBar.Label[5].text = "Edit Setting";
							this.PromptBar.UpdateButtons();
							this.PromptBar.Show = true;
						}
						if (this.NewTitleScreen.InputManager.TappedRight || this.NewTitleScreen.InputManager.TappedLeft)
						{
							if (this.Selection == 1)
							{
								this.Profile.antialiasing.enabled = !this.Profile.antialiasing.enabled;
							}
							else if (this.Selection == 2)
							{
								this.Profile.ambientOcclusion.enabled = !this.Profile.ambientOcclusion.enabled;
							}
							else if (this.Selection == 3)
							{
								this.Profile.depthOfField.enabled = !this.Profile.depthOfField.enabled;
							}
							else if (this.Selection == 4)
							{
								this.Profile.motionBlur.enabled = !this.Profile.motionBlur.enabled;
							}
							else if (this.Selection == 5)
							{
								this.Profile.bloom.enabled = !this.Profile.bloom.enabled;
							}
							else if (this.Selection == 6)
							{
								this.Profile.chromaticAberration.enabled = !this.Profile.chromaticAberration.enabled;
							}
							else if (this.Selection == 7)
							{
								this.Profile.vignette.enabled = !this.Profile.vignette.enabled;
							}
							this.UpdateLabels();
							return;
						}
						if (Input.GetButtonDown("X"))
						{
							this.Profile.antialiasing.enabled = false;
							this.Profile.ambientOcclusion.enabled = false;
							this.Profile.depthOfField.enabled = false;
							this.Profile.motionBlur.enabled = false;
							this.Profile.bloom.enabled = false;
							this.Profile.chromaticAberration.enabled = false;
							this.Profile.vignette.enabled = false;
							this.UpdateLabels();
							return;
						}
						if (Input.GetButtonDown("Y"))
						{
							this.Profile.antialiasing.enabled = true;
							this.Profile.ambientOcclusion.enabled = true;
							this.Profile.depthOfField.enabled = true;
							this.Profile.motionBlur.enabled = false;
							this.Profile.bloom.enabled = true;
							this.Profile.chromaticAberration.enabled = true;
							this.Profile.vignette.enabled = true;
							this.UpdateLabels();
							return;
						}
						if (Input.GetButtonDown("B"))
						{
							OptionGlobals.DepthOfField = this.Profile.depthOfField.enabled;
							OptionGlobals.MotionBlur = this.Profile.motionBlur.enabled;
							this.PromptBar.Show = false;
							this.Transition = true;
							this.Menu = 0;
							return;
						}
					}
					else if (this.Menu == 2)
					{
						if (!this.PromptBar.Show)
						{
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[1].text = "Go Back";
							this.PromptBar.Label[2].text = "Set All to Lowest";
							this.PromptBar.Label[3].text = "Reset All to Default";
							this.PromptBar.Label[4].text = "Change Selection";
							this.PromptBar.Label[5].text = "Edit Setting";
							this.PromptBar.UpdateButtons();
							this.PromptBar.Show = true;
						}
						if (this.Selection == 1)
						{
							if (this.NewTitleScreen.InputManager.TappedRight || this.NewTitleScreen.InputManager.TappedLeft)
							{
								OptionGlobals.OpaqueWindows = !OptionGlobals.OpaqueWindows;
								this.QualityManager.UpdateOpaqueWindows();
								if (!this.SchoolScene)
								{
									this.UpdateGraphics();
								}
								this.UpdateLabels();
							}
						}
						else if (this.Selection == 2)
						{
							if (this.NewTitleScreen.InputManager.TappedRight)
							{
								OptionGlobals.DisableFarAnimations++;
								this.QualityManager.UpdateAnims();
								this.UpdateLabels();
							}
							else if (this.NewTitleScreen.InputManager.TappedLeft)
							{
								OptionGlobals.DisableFarAnimations--;
								this.QualityManager.UpdateAnims();
								this.UpdateLabels();
							}
						}
						else if (this.Selection == 3)
						{
							if (this.NewTitleScreen.InputManager.TappedRight || this.NewTitleScreen.InputManager.TappedLeft)
							{
								OptionGlobals.RimLight = !OptionGlobals.RimLight;
								if (OptionGlobals.RimLight)
								{
									OptionGlobals.DisableOutlines = false;
								}
								if (!this.SchoolScene)
								{
									this.UpdateGraphics();
								}
								else
								{
									this.QualityManager.UpdateOutlinesAndRimlight();
								}
								this.UpdateLabels();
							}
						}
						else if (this.Selection == 4)
						{
							if (this.NewTitleScreen.InputManager.TappedRight)
							{
								OptionGlobals.LowDetailStudents++;
								this.QualityManager.UpdateLowDetailStudents();
								this.UpdateLabels();
							}
							else if (this.NewTitleScreen.InputManager.TappedLeft)
							{
								OptionGlobals.LowDetailStudents--;
								this.QualityManager.UpdateLowDetailStudents();
								this.UpdateLabels();
							}
						}
						else if (this.Selection == 5)
						{
							if (this.NewTitleScreen.InputManager.TappedRight || this.NewTitleScreen.InputManager.TappedLeft)
							{
								OptionGlobals.DisableOutlines = !OptionGlobals.DisableOutlines;
								if (OptionGlobals.DisableOutlines)
								{
									OptionGlobals.RimLight = false;
								}
								this.QualityManager.UpdateOutlinesAndRimlight();
								if (!this.SchoolScene)
								{
									this.UpdateGraphics();
								}
								this.UpdateLabels();
							}
						}
						else if (this.Selection == 6)
						{
							if (this.NewTitleScreen.InputManager.TappedRight || this.NewTitleScreen.InputManager.TappedLeft)
							{
								Screen.SetResolution(Screen.width, Screen.height, !Screen.fullScreen);
								this.UpdateLabels();
							}
						}
						else if (this.Selection == 7)
						{
							if (this.NewTitleScreen.InputManager.TappedRight)
							{
								OptionGlobals.DrawDistance += 10;
								this.QualityManager.UpdateDrawDistance();
								this.UpdateLabels();
							}
							else if (this.NewTitleScreen.InputManager.TappedLeft)
							{
								OptionGlobals.DrawDistance -= 10;
								this.QualityManager.UpdateDrawDistance();
								this.UpdateLabels();
							}
							if (!this.SchoolScene)
							{
								this.UpdateGraphics();
							}
						}
						else if (this.Selection == 8)
						{
							if (this.NewTitleScreen.InputManager.TappedRight)
							{
								OptionGlobals.ParticleCount++;
								this.QualityManager.UpdateParticles();
								this.UpdateLabels();
							}
							else if (this.NewTitleScreen.InputManager.TappedLeft)
							{
								OptionGlobals.ParticleCount--;
								this.QualityManager.UpdateParticles();
								this.UpdateLabels();
							}
							if (!this.SchoolScene)
							{
								this.UpdateGraphics();
							}
						}
						else if (this.Selection == 9)
						{
							if (this.NewTitleScreen.InputManager.TappedRight || this.NewTitleScreen.InputManager.TappedLeft)
							{
								OptionGlobals.ColorGrading = !OptionGlobals.ColorGrading;
								this.QualityManager.UpdateColorGrading();
								if (!this.SchoolScene)
								{
									this.UpdateGraphics();
								}
								this.UpdateLabels();
							}
						}
						else if (this.Selection == 10)
						{
							if (this.NewTitleScreen.InputManager.TappedRight || this.NewTitleScreen.InputManager.TappedLeft)
							{
								OptionGlobals.ToggleGrass = !OptionGlobals.ToggleGrass;
								this.QualityManager.UpdateGrass();
								if (!this.SchoolScene)
								{
									this.UpdateGraphics();
								}
								this.UpdateLabels();
							}
						}
						else if (this.Selection == 11)
						{
							if (this.NewTitleScreen.InputManager.TappedRight || this.NewTitleScreen.InputManager.TappedLeft)
							{
								OptionGlobals.HairPhysics = !OptionGlobals.HairPhysics;
								this.QualityManager.UpdateHair();
								if (!this.SchoolScene)
								{
									this.UpdateGraphics();
								}
								this.UpdateLabels();
							}
						}
						else if (this.Selection == 12)
						{
							if (this.NewTitleScreen.InputManager.TappedRight || this.NewTitleScreen.InputManager.TappedLeft)
							{
								OptionGlobals.DisplayFPS = !OptionGlobals.DisplayFPS;
								this.QualityManager.DisplayFPS();
								if (!this.SchoolScene)
								{
									this.UpdateGraphics();
								}
								this.UpdateLabels();
							}
						}
						else if (this.Selection == 13)
						{
							if (this.NewTitleScreen.InputManager.TappedRight || this.NewTitleScreen.InputManager.TappedLeft)
							{
								OptionGlobals.EnableShadows = !OptionGlobals.EnableShadows;
								this.QualityManager.UpdateShadows();
								if (!this.SchoolScene)
								{
									this.UpdateGraphics();
								}
								this.UpdateLabels();
							}
						}
						else if (this.Selection == 14)
						{
							if (this.NewTitleScreen.InputManager.TappedRight)
							{
								OptionGlobals.FPSIndex++;
								this.QualityManager.UpdateFPSIndex();
							}
							else if (this.NewTitleScreen.InputManager.TappedLeft)
							{
								OptionGlobals.FPSIndex--;
								this.QualityManager.UpdateFPSIndex();
							}
							this.UpdateLabels();
						}
						else if (this.Selection == 15)
						{
							if (this.NewTitleScreen.InputManager.TappedRight || this.NewTitleScreen.InputManager.TappedLeft)
							{
								OptionGlobals.Vsync = !OptionGlobals.Vsync;
								this.QualityManager.UpdateVsync();
								this.UpdateLabels();
							}
						}
						else if (this.Selection == 16 && (this.NewTitleScreen.InputManager.TappedRight || this.NewTitleScreen.InputManager.TappedLeft))
						{
							OptionGlobals.Fog = !OptionGlobals.Fog;
							this.QualityManager.UpdateFog();
							if (!this.SchoolScene)
							{
								this.UpdateGraphics();
							}
							this.UpdateLabels();
						}
						if (Input.GetButtonDown("X"))
						{
							OptionGlobals.OpaqueWindows = true;
							OptionGlobals.DisableFarAnimations = 1;
							OptionGlobals.RimLight = false;
							OptionGlobals.LowDetailStudents = 1;
							OptionGlobals.DisableOutlines = true;
							OptionGlobals.DrawDistance = 50;
							OptionGlobals.ParticleCount = 1;
							OptionGlobals.ColorGrading = false;
							OptionGlobals.EnableShadows = false;
							OptionGlobals.ToggleGrass = false;
							OptionGlobals.Fog = false;
							OptionGlobals.HairPhysics = true;
							if (!this.SchoolScene)
							{
								this.UpdateGraphics();
							}
							else
							{
								this.QualityManagerUpdateGraphics();
							}
							this.UpdateLabels();
							return;
						}
						if (Input.GetButtonDown("Y"))
						{
							OptionGlobals.OpaqueWindows = true;
							OptionGlobals.DisableFarAnimations = 10;
							OptionGlobals.RimLight = true;
							OptionGlobals.LowDetailStudents = 0;
							OptionGlobals.DisableOutlines = false;
							OptionGlobals.DrawDistanceLimit = 350;
							OptionGlobals.DrawDistance = 350;
							OptionGlobals.ParticleCount = 3;
							OptionGlobals.ColorGrading = true;
							OptionGlobals.EnableShadows = false;
							OptionGlobals.ToggleGrass = false;
							OptionGlobals.Fog = false;
							OptionGlobals.HairPhysics = false;
							if (!this.SchoolScene)
							{
								this.UpdateGraphics();
							}
							else
							{
								this.QualityManagerUpdateGraphics();
							}
							this.UpdateLabels();
							return;
						}
						if (Input.GetButtonDown("B"))
						{
							this.PromptBar.Show = false;
							this.Transition = true;
							this.Menu = 0;
							return;
						}
					}
					else if (this.Menu == 3)
					{
						if (this.Selection == 1)
						{
							if (this.NewTitleScreen.InputManager.TappedRight || this.NewTitleScreen.InputManager.TappedLeft)
							{
								OptionGlobals.ToggleRun = !OptionGlobals.ToggleRun;
								this.QualityManager.ToggleRun();
								this.UpdateLabels();
							}
						}
						else if (this.Selection == 2)
						{
							if (this.NewTitleScreen.InputManager.TappedRight)
							{
								if (OptionGlobals.Sensitivity < 10)
								{
									OptionGlobals.Sensitivity++;
									this.UpdateLabels();
								}
							}
							else if (this.NewTitleScreen.InputManager.TappedLeft && OptionGlobals.Sensitivity > 1)
							{
								OptionGlobals.Sensitivity--;
								this.UpdateLabels();
							}
							if (this.PauseScreen != null && this.PauseScreen.RPGCamera != null)
							{
								this.PauseScreen.RPGCamera.sensitivity = (float)OptionGlobals.Sensitivity;
							}
						}
						else if (this.Selection == 3)
						{
							if (this.NewTitleScreen.InputManager.TappedRight || this.NewTitleScreen.InputManager.TappedLeft)
							{
								OptionGlobals.TutorialsOff = !OptionGlobals.TutorialsOff;
								if (this.SchoolScene)
								{
									this.StudentManager.TutorialWindow.enabled = !OptionGlobals.TutorialsOff;
								}
								this.UpdateLabels();
							}
						}
						else if (this.Selection == 4)
						{
							if (this.NewTitleScreen.InputManager.TappedRight)
							{
								if (OptionGlobals.CameraPosition < 2)
								{
									OptionGlobals.CameraPosition++;
								}
								else
								{
									OptionGlobals.CameraPosition = 0;
								}
							}
							else if (this.NewTitleScreen.InputManager.TappedLeft)
							{
								if (OptionGlobals.CameraPosition > 0)
								{
									OptionGlobals.CameraPosition--;
								}
								else
								{
									OptionGlobals.CameraPosition = 2;
								}
							}
							if (this.SchoolScene)
							{
								if (OptionGlobals.CameraPosition == 0)
								{
									this.StudentManager.Yandere.Zoom.OverShoulder = false;
								}
								else if (OptionGlobals.CameraPosition == 1)
								{
									this.StudentManager.Yandere.Zoom.OverShoulder = true;
									this.StudentManager.Yandere.Zoom.midOffset = 0.25f;
								}
								else
								{
									this.StudentManager.Yandere.Zoom.OverShoulder = true;
									this.StudentManager.Yandere.Zoom.midOffset = -0.25f;
								}
							}
							this.UpdateLabels();
						}
						else if (this.Selection == 5)
						{
							if (this.NewTitleScreen.InputManager.TappedRight || this.NewTitleScreen.InputManager.TappedLeft)
							{
								OptionGlobals.InvertAxisX = !OptionGlobals.InvertAxisX;
								if (this.PauseScreen != null && this.PauseScreen.RPGCamera != null)
								{
									this.PauseScreen.RPGCamera.invertAxisX = OptionGlobals.InvertAxisX;
								}
								this.UpdateLabels();
							}
						}
						else if (this.Selection == 6)
						{
							if (this.NewTitleScreen.InputManager.TappedRight || this.NewTitleScreen.InputManager.TappedLeft)
							{
								OptionGlobals.InvertAxisY = !OptionGlobals.InvertAxisY;
								if (this.PauseScreen != null && this.PauseScreen.RPGCamera != null)
								{
									this.PauseScreen.RPGCamera.invertAxisY = OptionGlobals.InvertAxisY;
								}
								this.UpdateLabels();
							}
						}
						else if (this.Selection == 7 && (this.NewTitleScreen.InputManager.TappedRight || this.NewTitleScreen.InputManager.TappedLeft))
						{
							OptionGlobals.SubtitleSize = !OptionGlobals.SubtitleSize;
							if (this.PauseScreen != null)
							{
								this.PauseScreen.UpdateSubtitleSize();
							}
							this.UpdateLabels();
						}
						if (!this.PromptBar.Show)
						{
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[1].text = "Go Back";
							this.PromptBar.Label[4].text = "Change Selection";
							this.PromptBar.Label[5].text = "Edit Setting";
							this.PromptBar.UpdateButtons();
							this.PromptBar.Show = true;
						}
						if (Input.GetButtonDown("B"))
						{
							this.PromptBar.Show = false;
							this.Transition = true;
							this.Menu = 0;
							return;
						}
					}
					else if (this.Menu == 4)
					{
						if (this.Selection == 1)
						{
							if (this.NewTitleScreen.InputManager.TappedRight || this.NewTitleScreen.InputManager.TappedLeft)
							{
								GameGlobals.CensorKillingAnims = !GameGlobals.CensorKillingAnims;
								if (this.SchoolScene)
								{
									this.StudentManager.Yandere.AttackManager.Censor = GameGlobals.CensorKillingAnims;
								}
								this.UpdateLabels();
							}
						}
						else if (this.Selection == 2)
						{
							if (this.NewTitleScreen.InputManager.TappedRight || this.NewTitleScreen.InputManager.TappedLeft)
							{
								GameGlobals.CensorPanties = !GameGlobals.CensorPanties;
								if (this.SchoolScene)
								{
									this.StudentManager.CensorStudents();
									this.StudentManager.Yandere.DebugMenu.transform.parent.GetComponent<DebugMenuScript>().Censor();
								}
								this.UpdateLabels();
							}
						}
						else if (this.Selection == 3 && (this.NewTitleScreen.InputManager.TappedRight || this.NewTitleScreen.InputManager.TappedLeft))
						{
							GameGlobals.CensorBlood = !GameGlobals.CensorBlood;
							if (this.SchoolScene)
							{
								this.StudentManager.Yandere.WeaponManager.ChangeBloodTexture();
								this.StudentManager.Yandere.Bloodiness += 0f;
							}
							this.UpdateLabels();
						}
						if (!this.PromptBar.Show)
						{
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[1].text = "Go Back";
							this.PromptBar.Label[4].text = "Change Selection";
							this.PromptBar.Label[5].text = "Edit Setting";
							this.PromptBar.UpdateButtons();
							this.PromptBar.Show = true;
						}
						if (Input.GetButtonDown("B"))
						{
							this.PromptBar.Show = false;
							this.Transition = true;
							this.Menu = 0;
							return;
						}
					}
					else if (this.Menu == 5)
					{
						if (!this.PromptBar.Show)
						{
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[1].text = "Go Back";
							this.PromptBar.Label[2].text = "Set All to Lowest";
							this.PromptBar.Label[3].text = "Reset All to Default";
							this.PromptBar.Label[4].text = "Change Selection";
							this.PromptBar.Label[5].text = "Edit Setting";
							this.PromptBar.UpdateButtons();
							this.PromptBar.Show = true;
						}
						if (this.Selection == 1)
						{
							if (this.NewTitleScreen.InputManager.TappedRight || this.NewTitleScreen.InputManager.TappedLeft)
							{
								OptionGlobals.DisableStatic = !OptionGlobals.DisableStatic;
								this.QualityManager.UpdateEightiesEffects();
								this.UpdateLabels();
							}
						}
						else if (this.Selection == 2)
						{
							if (this.NewTitleScreen.InputManager.TappedRight || this.NewTitleScreen.InputManager.TappedLeft)
							{
								OptionGlobals.DisableDisplacement = !OptionGlobals.DisableDisplacement;
								this.QualityManager.UpdateEightiesEffects();
								this.UpdateLabels();
							}
						}
						else if (this.Selection == 3)
						{
							if (this.NewTitleScreen.InputManager.TappedRight || this.NewTitleScreen.InputManager.TappedLeft)
							{
								OptionGlobals.DisableAbberation = !OptionGlobals.DisableAbberation;
								this.QualityManager.UpdateEightiesEffects();
								this.UpdateLabels();
							}
						}
						else if (this.Selection == 4)
						{
							if (this.NewTitleScreen.InputManager.TappedRight || this.NewTitleScreen.InputManager.TappedLeft)
							{
								OptionGlobals.DisableVignette = !OptionGlobals.DisableVignette;
								this.QualityManager.UpdateEightiesEffects();
								this.UpdateLabels();
							}
						}
						else if (this.Selection == 5)
						{
							if (this.NewTitleScreen.InputManager.TappedRight || this.NewTitleScreen.InputManager.TappedLeft)
							{
								OptionGlobals.DisableDistortion = !OptionGlobals.DisableDistortion;
								this.QualityManager.UpdateEightiesEffects();
								this.UpdateLabels();
							}
						}
						else if (this.Selection == 6)
						{
							if (this.NewTitleScreen.InputManager.TappedRight || this.NewTitleScreen.InputManager.TappedLeft)
							{
								OptionGlobals.DisableScanlines = !OptionGlobals.DisableScanlines;
								this.QualityManager.UpdateEightiesEffects();
								this.UpdateLabels();
							}
						}
						else if (this.Selection == 7)
						{
							if (this.NewTitleScreen.InputManager.TappedRight || this.NewTitleScreen.InputManager.TappedLeft)
							{
								OptionGlobals.DisableNoise = !OptionGlobals.DisableNoise;
								this.QualityManager.UpdateEightiesEffects();
								this.UpdateLabels();
							}
						}
						else if (this.Selection == 8 && (this.NewTitleScreen.InputManager.TappedRight || this.NewTitleScreen.InputManager.TappedLeft))
						{
							OptionGlobals.DisableTint = !OptionGlobals.DisableTint;
							this.QualityManager.UpdateEightiesEffects();
							this.UpdateLabels();
						}
						if (Input.GetButtonDown("X"))
						{
							OptionGlobals.DisableStatic = true;
							OptionGlobals.DisableDisplacement = true;
							OptionGlobals.DisableAbberation = true;
							OptionGlobals.DisableVignette = true;
							OptionGlobals.DisableDistortion = true;
							OptionGlobals.DisableScanlines = true;
							OptionGlobals.DisableNoise = true;
							OptionGlobals.DisableTint = true;
							this.QualityManager.UpdateEightiesEffects();
							this.UpdateLabels();
							return;
						}
						if (Input.GetButtonDown("Y"))
						{
							OptionGlobals.DisableStatic = false;
							OptionGlobals.DisableDisplacement = false;
							OptionGlobals.DisableAbberation = false;
							OptionGlobals.DisableVignette = false;
							OptionGlobals.DisableDistortion = false;
							OptionGlobals.DisableScanlines = false;
							OptionGlobals.DisableNoise = false;
							OptionGlobals.DisableTint = false;
							this.QualityManager.UpdateEightiesEffects();
							this.UpdateLabels();
							return;
						}
						if (Input.GetButtonDown("B"))
						{
							this.PromptBar.ClearButtons();
							this.PromptBar.UpdateButtons();
							this.PromptBar.Show = false;
							this.Transition = true;
							this.Menu = 0;
						}
					}
				}
			}
		}
	}

	// Token: 0x060019F1 RID: 6641 RVA: 0x0010DFFC File Offset: 0x0010C1FC
	private void UpdateCursor()
	{
		if (this.Selection > this.Limit[this.Menu])
		{
			this.Selection = 1;
			return;
		}
		if (this.Selection < 1)
		{
			this.Selection = this.Limit[this.Menu];
		}
	}

	// Token: 0x060019F2 RID: 6642 RVA: 0x0010E038 File Offset: 0x0010C238
	private void UpdatePanels()
	{
		for (int i = 0; i < this.Panel.Length; i++)
		{
			if (i == this.Menu)
			{
				this.Panel[i].alpha = Mathf.MoveTowards(this.Panel[i].alpha, 1f, Time.unscaledDeltaTime * (float)this.Speed);
			}
			else
			{
				this.Panel[i].alpha = Mathf.MoveTowards(this.Panel[i].alpha, 0f, Time.unscaledDeltaTime * (float)this.Speed);
			}
		}
	}

	// Token: 0x060019F3 RID: 6643 RVA: 0x0010E0C8 File Offset: 0x0010C2C8
	public void UpdateLabels()
	{
		this.Labels[1].text = (this.Profile.antialiasing.enabled ? "On" : "Off");
		this.Labels[2].text = (this.Profile.ambientOcclusion.enabled ? "On" : "Off");
		this.Labels[3].text = (this.Profile.depthOfField.enabled ? "On" : "Off");
		this.Labels[4].text = (this.Profile.motionBlur.enabled ? "On" : "Off");
		this.Labels[5].text = (this.Profile.bloom.enabled ? "On" : "Off");
		this.Labels[6].text = (this.Profile.chromaticAberration.enabled ? "On" : "Off");
		this.Labels[7].text = (this.Profile.vignette.enabled ? "On" : "Off");
		this.Labels[8].text = (OptionGlobals.OpaqueWindows ? "No" : "Yes");
		this.Labels[9].text = ((OptionGlobals.DisableFarAnimations == 0) ? "Off" : ((OptionGlobals.DisableFarAnimations * 5).ToString() + "m"));
		this.Labels[10].text = (OptionGlobals.RimLight ? "On" : "Off");
		this.Labels[11].text = ((OptionGlobals.LowDetailStudents == 0) ? "Off" : ((OptionGlobals.LowDetailStudents * 10).ToString() + "m"));
		this.Labels[12].text = (OptionGlobals.DisableOutlines ? "Off" : "On");
		this.Labels[13].text = (Screen.fullScreen ? "No" : "Yes");
		this.Labels[14].text = OptionGlobals.DrawDistance.ToString() + "m";
		if (OptionGlobals.ParticleCount == 3)
		{
			this.Labels[15].text = "High";
		}
		else if (OptionGlobals.ParticleCount == 2)
		{
			this.Labels[15].text = "Low";
		}
		else if (OptionGlobals.ParticleCount == 1)
		{
			this.Labels[15].text = "None";
		}
		this.Labels[16].text = (OptionGlobals.ColorGrading ? "Yes" : "No");
		this.Labels[17].text = (OptionGlobals.ToggleGrass ? "On" : "Off");
		this.Labels[18].text = (OptionGlobals.HairPhysics ? "Disabled" : "Enabled");
		this.Labels[19].text = (OptionGlobals.DisplayFPS ? "Yes" : "No");
		this.Labels[20].text = (OptionGlobals.EnableShadows ? "Yes" : "No");
		this.Labels[21].text = QualityManagerScript.FPSStrings[OptionGlobals.FPSIndex];
		this.Labels[22].text = (OptionGlobals.Vsync ? "On" : "Off");
		this.Labels[23].text = (OptionGlobals.Fog ? "On" : "Off");
		this.Labels[24].text = (OptionGlobals.ToggleRun ? "Toggle" : "Hold");
		this.Labels[25].text = (OptionGlobals.Sensitivity.ToString() ?? "");
		this.Labels[26].text = (OptionGlobals.TutorialsOff ? "Yes" : "No");
		if (OptionGlobals.CameraPosition == 0)
		{
			this.Labels[27].text = "Behind";
		}
		else if (OptionGlobals.CameraPosition == 1)
		{
			this.Labels[27].text = "Right";
		}
		else if (OptionGlobals.CameraPosition == 2)
		{
			this.Labels[27].text = "Left";
		}
		this.Labels[28].text = (OptionGlobals.InvertAxisX ? "Yes" : "No");
		this.Labels[29].text = (OptionGlobals.InvertAxisY ? "Yes" : "No");
		this.Labels[30].text = (OptionGlobals.SubtitleSize ? "Large" : "Normal");
		this.Labels[31].text = (GameGlobals.CensorKillingAnims ? "Yes" : "No");
		this.Labels[32].text = (GameGlobals.CensorPanties ? "Yes" : "No");
		this.Labels[33].text = (GameGlobals.CensorBlood ? "Yes" : "No");
		this.Labels[34].text = (OptionGlobals.DisableStatic ? "Yes" : "No");
		this.Labels[35].text = (OptionGlobals.DisableDisplacement ? "Yes" : "No");
		this.Labels[36].text = (OptionGlobals.DisableAbberation ? "Yes" : "No");
		this.Labels[37].text = (OptionGlobals.DisableVignette ? "Yes" : "No");
		this.Labels[38].text = (OptionGlobals.DisableDistortion ? "Yes" : "No");
		this.Labels[39].text = (OptionGlobals.DisableScanlines ? "Yes" : "No");
		this.Labels[40].text = (OptionGlobals.DisableNoise ? "Yes" : "No");
		this.Labels[41].text = (OptionGlobals.DisableTint ? "Yes" : "No");
		if (GameGlobals.Eighties)
		{
			UILabel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UILabel>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				this.EightiesifyLabel(componentsInChildren[i]);
			}
		}
		OptionGlobals.DisableBloom = !this.Profile.bloom.enabled;
	}

	// Token: 0x060019F4 RID: 6644 RVA: 0x0010E734 File Offset: 0x0010C934
	public void SetWindowsOpaque()
	{
		if (!OptionGlobals.OpaqueWindows)
		{
			this.Window.sharedMaterial.color = new Color(1f, 1f, 1f, 0.5f);
			this.Window.sharedMaterial.shader = Shader.Find("Transparent/Diffuse");
			return;
		}
		this.Window.sharedMaterial.color = new Color(1f, 1f, 1f, 1f);
		this.Window.sharedMaterial.shader = Shader.Find("Diffuse");
	}

	// Token: 0x060019F5 RID: 6645 RVA: 0x0010E7D0 File Offset: 0x0010C9D0
	public void UpdateShaders()
	{
		if (OptionGlobals.RimLight)
		{
			if (OptionGlobals.DisableOutlines)
			{
				this.YandereRenderer.materials[0].shader = this.ToonRimLight;
				this.YandereRenderer.materials[1].shader = this.ToonRimLight;
				this.YandereRenderer.materials[2].shader = this.ToonRimLight;
				this.YandereHairRenderer.material.shader = this.ToonRimLight;
				this.AdjustRimLight(this.YandereRenderer.materials[0]);
				this.AdjustRimLight(this.YandereRenderer.materials[1]);
				this.AdjustRimLight(this.YandereRenderer.materials[2]);
				this.AdjustRimLight(this.YandereHairRenderer.material);
				return;
			}
			this.YandereRenderer.materials[0].shader = this.ToonOutlineRimLight;
			this.YandereRenderer.materials[1].shader = this.ToonOutlineRimLight;
			this.YandereRenderer.materials[2].shader = this.ToonOutlineRimLight;
			this.YandereHairRenderer.material.shader = this.ToonOutlineRimLight;
			this.AdjustRimLight(this.YandereRenderer.materials[0]);
			this.AdjustRimLight(this.YandereRenderer.materials[1]);
			this.AdjustRimLight(this.YandereRenderer.materials[2]);
			this.AdjustRimLight(this.YandereHairRenderer.material);
			return;
		}
		else
		{
			if (OptionGlobals.DisableOutlines)
			{
				this.YandereRenderer.materials[0].shader = this.Toon;
				this.YandereRenderer.materials[1].shader = this.Toon;
				this.YandereRenderer.materials[2].shader = this.Toon;
				this.YandereHairRenderer.material.shader = this.Toon;
				return;
			}
			this.YandereRenderer.materials[0].shader = this.ToonOutline;
			this.YandereRenderer.materials[1].shader = this.ToonOutline;
			this.YandereRenderer.materials[2].shader = this.ToonOutline;
			this.YandereHairRenderer.material.shader = this.ToonOutline;
			return;
		}
	}

	// Token: 0x060019F6 RID: 6646 RVA: 0x0010EA07 File Offset: 0x0010CC07
	public void AdjustRimLight(Material mat)
	{
		mat.SetFloat("_RimLightIntencity", 5f);
		mat.SetFloat("_RimCrisp", 0.5f);
		mat.SetFloat("_RimAdditive", 0.5f);
	}

	// Token: 0x060019F7 RID: 6647 RVA: 0x0010EA3C File Offset: 0x0010CC3C
	public void UpdateGraphics()
	{
		this.SetWindowsOpaque();
		this.UpdateShaders();
		this.MainCamera.farClipPlane = (float)OptionGlobals.DrawDistance;
		RenderSettings.fogEndDistance = (float)OptionGlobals.DrawDistance;
		ParticleSystem.EmissionModule emission = this.PlazaBlossoms.emission;
		emission.enabled = true;
		if (OptionGlobals.ParticleCount == 3)
		{
			emission.rateOverTime = 500f;
		}
		else if (OptionGlobals.ParticleCount == 2)
		{
			emission.rateOverTime = 100f;
		}
		else if (OptionGlobals.ParticleCount == 1)
		{
			emission.enabled = false;
		}
		this.ColorGrading.enabled = OptionGlobals.ColorGrading;
		this.Grass.SetActive(OptionGlobals.ToggleGrass);
		this.Sun.shadows = (OptionGlobals.EnableShadows ? LightShadows.Soft : LightShadows.None);
		if (OptionGlobals.EnableShadows)
		{
			this.Sun.intensity = 0.5f;
		}
		else
		{
			this.Sun.intensity = 0.25f;
		}
		if (!OptionGlobals.Fog)
		{
			this.MainCamera.clearFlags = CameraClearFlags.Skybox;
			RenderSettings.fog = false;
		}
		else
		{
			this.MainCamera.clearFlags = CameraClearFlags.Color;
			RenderSettings.fog = true;
			RenderSettings.fogMode = FogMode.Linear;
			RenderSettings.fogColor = this.MainCamera.backgroundColor;
			RenderSettings.fogEndDistance = (float)OptionGlobals.DrawDistance;
		}
		this.QualityManager.UpdateEightiesEffects();
	}

	// Token: 0x060019F8 RID: 6648 RVA: 0x0010EB84 File Offset: 0x0010CD84
	public void QualityManagerUpdateGraphics()
	{
		this.QualityManager.UpdateOpaqueWindows();
		this.QualityManager.UpdateAnims();
		this.QualityManager.UpdateLowDetailStudents();
		this.QualityManager.UpdateOutlinesAndRimlight();
		this.QualityManager.UpdateDrawDistance();
		this.QualityManager.UpdateParticles();
		this.QualityManager.UpdateColorGrading();
		this.QualityManager.UpdateShadows();
		this.QualityManager.UpdateGrass();
		this.QualityManager.UpdateFog();
		this.QualityManager.UpdateEightiesEffects();
	}

	// Token: 0x060019F9 RID: 6649 RVA: 0x0010EC0C File Offset: 0x0010CE0C
	public void EightiesifyLabel(UILabel Label)
	{
		Label.applyGradient = false;
		Label.color = new Color(1f, 1f, 1f, 1f);
		Label.effectStyle = UILabel.Effect.Outline8;
		Label.effectColor = new Color(0f, 0f, 0f, 1f);
		Label.effectDistance = new Vector2(5f, 5f);
	}

	// Token: 0x040029A8 RID: 10664
	public CameraFilterPack_Colors_Adjust_PreFilters ColorGrading;

	// Token: 0x040029A9 RID: 10665
	public StudentManagerScript StudentManager;

	// Token: 0x040029AA RID: 10666
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x040029AB RID: 10667
	public QualityManagerScript QualityManager;

	// Token: 0x040029AC RID: 10668
	public PauseScreenScript PauseScreen;

	// Token: 0x040029AD RID: 10669
	public PromptBarScript PromptBar;

	// Token: 0x040029AE RID: 10670
	public PostProcessingProfile Profile;

	// Token: 0x040029AF RID: 10671
	public ParticleSystem PlazaBlossoms;

	// Token: 0x040029B0 RID: 10672
	public Camera MainCamera;

	// Token: 0x040029B1 RID: 10673
	public Light Sun;

	// Token: 0x040029B2 RID: 10674
	public GameObject OptionList;

	// Token: 0x040029B3 RID: 10675
	public GameObject PostProcessing;

	// Token: 0x040029B4 RID: 10676
	public GameObject Details;

	// Token: 0x040029B5 RID: 10677
	public GameObject Gameplay;

	// Token: 0x040029B6 RID: 10678
	public GameObject Grass;

	// Token: 0x040029B7 RID: 10679
	public UIPanel[] Panel;

	// Token: 0x040029B8 RID: 10680
	public UISprite Cursor;

	// Token: 0x040029B9 RID: 10681
	public UILabel[] Labels;

	// Token: 0x040029BA RID: 10682
	public int[] Limit;

	// Token: 0x040029BB RID: 10683
	public int Selection = 1;

	// Token: 0x040029BC RID: 10684
	public int Speed = 1;

	// Token: 0x040029BD RID: 10685
	public int Menu = 1;

	// Token: 0x040029BE RID: 10686
	public bool SchoolScene;

	// Token: 0x040029BF RID: 10687
	public bool Transition;

	// Token: 0x040029C0 RID: 10688
	public Renderer Window;

	// Token: 0x040029C1 RID: 10689
	public Renderer YandereRenderer;

	// Token: 0x040029C2 RID: 10690
	public Renderer YandereHairRenderer;

	// Token: 0x040029C3 RID: 10691
	public Shader ToonOutlineRimLight;

	// Token: 0x040029C4 RID: 10692
	public Shader ToonRimLight;

	// Token: 0x040029C5 RID: 10693
	public Shader ToonOutline;

	// Token: 0x040029C6 RID: 10694
	public Shader Toon;
}
