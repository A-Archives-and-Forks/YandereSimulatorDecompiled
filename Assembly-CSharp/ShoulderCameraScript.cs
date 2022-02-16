﻿using System;
using UnityEngine;

// Token: 0x02000424 RID: 1060
public class ShoulderCameraScript : MonoBehaviour
{
	// Token: 0x06001C90 RID: 7312 RVA: 0x0014EB7C File Offset: 0x0014CD7C
	private void LateUpdate()
	{
		if (!this.PauseScreen.Show)
		{
			if (this.OverShoulder)
			{
				if (this.RPGCamera.enabled)
				{
					this.ShoulderFocus.position = this.RPGCamera.cameraPivot.position;
					this.LastPosition = base.transform.position;
					this.RPGCamera.enabled = false;
				}
				if (this.Yandere.TargetStudent.Counselor)
				{
					base.transform.position = Vector3.Lerp(base.transform.position, this.ShoulderPOV.position + new Vector3(0f, -0.49f, 0f), Time.deltaTime * 10f);
				}
				else
				{
					base.transform.position = Vector3.Lerp(base.transform.position, this.ShoulderPOV.position, Time.deltaTime * 10f);
				}
				this.ShoulderFocus.position = Vector3.Lerp(this.ShoulderFocus.position, this.Yandere.TargetStudent.transform.position + Vector3.up * this.Height, Time.deltaTime * 10f);
				base.transform.LookAt(this.ShoulderFocus);
				return;
			}
			if (this.AimingCamera)
			{
				if (!this.Yandere.StudentManager.Eighties)
				{
					base.transform.position = this.CameraPOV.position;
					base.transform.LookAt(this.CameraFocus);
					return;
				}
				this.EightiesSpineFollower.localEulerAngles = new Vector3(this.Yandere.Spine[3].localEulerAngles.x, 0f, 0f);
				this.EightiesSpineFollower.transform.position = new Vector3(this.Yandere.transform.position.x, this.Yandere.Spine[3].position.y, this.Yandere.transform.position.z);
				if (this.Yandere.Stance.Current == StanceType.Standing)
				{
					base.transform.position = this.EightiesCameraPOV.position;
					base.transform.LookAt(this.EightiesCameraFocus);
					return;
				}
				if (this.Yandere.Stance.Current == StanceType.Crouching)
				{
					base.transform.position = new Vector3(this.Yandere.transform.position.x, this.Yandere.transform.position.y + 1f, this.Yandere.transform.position.z);
					return;
				}
				if (this.Yandere.Stance.Current == StanceType.Crawling)
				{
					base.transform.position = new Vector3(this.Yandere.transform.position.x, this.Yandere.transform.position.y + 0.5f, this.Yandere.transform.position.z);
					return;
				}
			}
			else if (this.Noticed)
			{
				if (!this.Yandere.Drown)
				{
					if (this.NoticedTimer == 0f)
					{
						this.Yandere.CameraEffects.UpdateDOF(1f);
						base.GetComponent<Camera>().cullingMask &= -8193;
						StudentScript component = this.Yandere.Senpai.GetComponent<StudentScript>();
						if (component.Teacher)
						{
							this.GoingToCounselor = true;
							this.NoticedHeight = 1.6f;
							this.NoticedLimit = 6;
						}
						if (component.Club == ClubType.Council)
						{
							this.GoingToCounselor = true;
							this.NoticedHeight = 1.375f;
							this.NoticedLimit = 6;
						}
						else if (component.Witnessed == StudentWitnessType.Stalking)
						{
							this.NoticedHeight = 1.481275f;
							this.NoticedLimit = 7;
						}
						else
						{
							this.NoticedHeight = 1.375f;
							this.NoticedLimit = 6;
						}
						this.NoticedPOV.position = this.Yandere.Senpai.position + this.Yandere.Senpai.forward + Vector3.up * this.NoticedHeight;
						this.NoticedPOV.LookAt(this.Yandere.Senpai.position + Vector3.up * this.NoticedHeight);
						this.NoticedFocus.position = base.transform.position + base.transform.forward;
						this.NoticedSpeed = 10f;
					}
					this.NoticedTimer += Time.deltaTime;
					if (this.Phase == 1)
					{
						if (Input.GetButtonDown("A") && !this.Yandere.Attacking)
						{
							this.Yandere.transform.rotation = Quaternion.LookRotation(this.Yandere.Senpai.position - this.Yandere.transform.position);
							this.NoticedTimer += 10f;
						}
						this.NoticedFocus.position = Vector3.Lerp(this.NoticedFocus.position, this.Yandere.Senpai.position + Vector3.up * this.NoticedHeight, Time.deltaTime * 10f);
						this.NoticedPOV.Translate(Vector3.forward * Time.deltaTime * -0.075f);
						if (this.NoticedTimer > 1f && !this.Spoken && !this.Yandere.Senpai.GetComponent<StudentScript>().Teacher)
						{
							this.Yandere.Senpai.GetComponent<StudentScript>().DetermineSenpaiReaction();
							this.Spoken = true;
						}
						if (this.NoticedTimer > (float)this.NoticedLimit || this.Skip)
						{
							this.Yandere.Senpai.GetComponent<StudentScript>().Character.SetActive(false);
							base.GetComponent<Camera>().cullingMask |= 8192;
							this.NoticedPOV.position = this.Yandere.transform.position + this.Yandere.transform.forward + Vector3.up * 1.375f;
							this.NoticedPOV.LookAt(this.Yandere.transform.position + Vector3.up * 1.375f);
							this.NoticedFocus.position = this.Yandere.transform.position + Vector3.up * 1.375f;
							base.transform.position = this.NoticedPOV.position;
							this.NoticedTimer = (float)this.NoticedLimit;
							this.Phase = 2;
							if (this.GoingToCounselor)
							{
								this.Yandere.CharacterAnimation.CrossFade("f02_disappointed_00");
							}
							else
							{
								this.Yandere.CharacterAnimation["f02_sadEyebrows_00"].weight = 1f;
								this.Yandere.CharacterAnimation.CrossFade("f02_whimper_00");
								this.Yandere.Subtitle.UpdateLabel(SubtitleType.YandereWhimper, 1, 3.5f);
								Debug.Log("Yandere-chan shoulder be whimpering now.");
								if (this.Yandere.StudentManager.Eighties)
								{
									this.Yandere.LoseGentleEyes();
								}
								this.Yandere.CameraEffects.UpdateDOF(1f);
							}
						}
					}
					else if (this.Phase == 2)
					{
						if (Input.GetButtonDown("A"))
						{
							this.NoticedTimer += 10f;
						}
						if (!this.GoingToCounselor)
						{
							this.Yandere.EyeShrink = Mathf.MoveTowards(this.Yandere.EyeShrink, 0.5f, Time.deltaTime * 0.125f);
						}
						this.NoticedPOV.Translate(Vector3.forward * Time.deltaTime * 0.075f);
						this.Yandere.CameraEffects.UpdateDOF(0.75f);
						if (this.GoingToCounselor)
						{
							this.Yandere.CharacterAnimation.CrossFade("f02_disappointed_00");
						}
						else
						{
							this.Yandere.CharacterAnimation.CrossFade("f02_whimper_00");
							if (this.Yandere.CharacterAnimation["f02_whimper_00"].time > 3.5f)
							{
								this.Yandere.CharacterAnimation["f02_whimper_00"].speed -= Time.deltaTime;
							}
						}
						if (this.NoticedTimer > (float)(this.NoticedLimit + 4))
						{
							if (!this.GoingToCounselor)
							{
								this.NoticedPOV.Translate(Vector3.back * 2f);
								this.NoticedPOV.transform.position = new Vector3(this.NoticedPOV.transform.position.x, this.Yandere.transform.position.y + 1f, this.NoticedPOV.transform.position.z);
								this.NoticedSpeed = 1f;
								this.Yandere.Character.GetComponent<Animation>().CrossFade("f02_down_22");
								this.HeartbrokenCamera.SetActive(true);
								this.Yandere.Police.Invalid = true;
								this.Yandere.Collapse = true;
								this.Phase = 3;
							}
							else
							{
								this.Yandere.Police.Darkness.enabled = true;
								this.Yandere.HUD.enabled = true;
								this.Yandere.HUD.alpha = 1f;
								if (this.Yandere.Police.Timer == 300f && this.Yandere.Police.Corpses - this.Yandere.Police.HiddenCorpses <= 0)
								{
									this.HUD.SetActive(false);
								}
								this.Phase = 4;
							}
						}
					}
					else if (this.Phase == 3)
					{
						this.NoticedFocus.transform.position = new Vector3(this.NoticedFocus.transform.position.x, Mathf.Lerp(this.NoticedFocus.transform.position.y, this.Yandere.transform.position.y + 1f, Time.deltaTime), this.NoticedFocus.transform.position.z);
					}
					else if (this.Phase == 4)
					{
						this.Yandere.Police.Darkness.color += new Color(0f, 0f, 0f, Time.deltaTime);
						this.NoticedPOV.Translate(Vector3.forward * Time.deltaTime * 0.075f);
						if (this.Yandere.Police.Darkness.color.a >= 1f)
						{
							if (this.Yandere.Police.Timer != 300f || this.Yandere.Police.Corpses - this.Yandere.Police.HiddenCorpses > 0)
							{
								Debug.Log("Ending day instead of going to counselor.");
								this.HUD.SetActive(true);
								this.Portal.EndDay();
								base.enabled = false;
							}
							else
							{
								if (this.Yandere.Mask != null)
								{
									this.Yandere.Mask.Drop();
								}
								this.Yandere.StudentManager.PreventAlarm();
								this.Counselor.Crime = this.Yandere.Senpai.GetComponent<StudentScript>().Witnessed;
								this.Counselor.MyAnimation.Play("CounselorArmsCrossed");
								this.Counselor.Laptop.SetActive(false);
								this.Counselor.Interrogating = true;
								this.Counselor.LookAtPlayer = true;
								this.Counselor.Stern = true;
								this.Counselor.Timer = 0f;
								this.Counselor.transform.position = new Vector3(-28.93333f, 0f, 12f);
								this.Counselor.RedPen.SetActive(false);
								base.transform.Translate(Vector3.forward * -1f);
								this.Yandere.Senpai.GetComponent<StudentScript>().Character.SetActive(true);
								this.Yandere.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
								this.Yandere.transform.position = new Vector3(-27.51f, 0f, 12f);
								this.Yandere.Police.Darkness.color = new Color(0f, 0f, 0f, 1f);
								this.Yandere.CharacterAnimation.Play("f02_sit_00");
								this.Yandere.Noticed = false;
								this.Yandere.Sanity = 100f;
								Physics.SyncTransforms();
								this.GoingToCounselor = false;
								base.enabled = false;
								this.NoticedTimer = 0f;
								this.Phase = 1;
							}
						}
					}
					if (this.Phase < 5)
					{
						base.transform.position = Vector3.Lerp(base.transform.position, this.NoticedPOV.position, Time.deltaTime * this.NoticedSpeed);
						base.transform.LookAt(this.NoticedFocus);
						return;
					}
				}
			}
			else if (this.Scolding)
			{
				if (this.Timer == 0f)
				{
					this.NoticedHeight = 1.6f;
					this.NoticedPOV.position = this.Teacher.position + this.Teacher.forward + Vector3.up * this.NoticedHeight;
					this.NoticedPOV.LookAt(this.Teacher.position + Vector3.up * this.NoticedHeight);
					this.NoticedFocus.position = this.Teacher.position + Vector3.up * this.NoticedHeight;
					this.NoticedSpeed = 10f;
				}
				base.transform.position = Vector3.Lerp(base.transform.position, this.NoticedPOV.position, Time.deltaTime * this.NoticedSpeed);
				base.transform.LookAt(this.NoticedFocus);
				this.Timer += Time.deltaTime;
				if (this.Timer > 6f)
				{
					this.Portal.ClassDarkness.enabled = true;
					this.Portal.Transition = true;
					this.Portal.FadeOut = true;
				}
				if (this.Timer > 7f)
				{
					this.Scolding = false;
					this.Timer = 0f;
					return;
				}
			}
			else if (this.Counter)
			{
				if (this.Timer == 0f)
				{
					this.StruggleFocus.position = base.transform.position + base.transform.forward;
					this.StrugglePOV.position = base.transform.position;
				}
				base.transform.position = Vector3.Lerp(base.transform.position, this.StrugglePOV.position, Time.deltaTime * 10f);
				base.transform.LookAt(this.StruggleFocus);
				this.Timer += Time.deltaTime;
				if (this.Timer > 0.5f && this.Phase < 2)
				{
					this.Yandere.CameraEffects.MurderWitnessed();
					this.Yandere.Jukebox.GameOver();
					this.Phase++;
				}
				if (this.Timer > 1.4f && this.Phase < 3)
				{
					this.Yandere.Subtitle.UpdateLabel(SubtitleType.TeacherAttackReaction, 1, 4f);
					this.Phase++;
				}
				if (this.Timer > 6f && this.Yandere.Armed)
				{
					this.Yandere.EquippedWeapon.Drop();
				}
				if (this.Timer > 6.66666f && this.Phase < 4)
				{
					base.GetComponent<AudioSource>().PlayOneShot(this.Slam);
					this.Phase++;
				}
				if (this.Timer > 10f && this.Phase < 5)
				{
					this.HeartbrokenCamera.SetActive(true);
					this.Phase++;
				}
				if (this.Timer < 5f)
				{
					this.StruggleFocus.localPosition = Vector3.Lerp(this.StruggleFocus.localPosition, new Vector3(0f, 1.4f, 0.7f), Time.deltaTime);
					this.StrugglePOV.localPosition = Vector3.Lerp(this.StrugglePOV.localPosition, new Vector3(0.5f, 1.4f, 0.3f), Time.deltaTime);
					return;
				}
				if (this.Timer < 10f)
				{
					if (this.Timer < 6.5f)
					{
						this.PullBackTimer = Mathf.MoveTowards(this.PullBackTimer, 1.5f, Time.deltaTime);
					}
					else
					{
						this.PullBackTimer = Mathf.MoveTowards(this.PullBackTimer, 0f, Time.deltaTime * 0.42857143f);
					}
					base.transform.Translate(Vector3.back * Time.deltaTime * 10f * this.PullBackTimer);
					this.StruggleFocus.localPosition = Vector3.Lerp(this.StruggleFocus.localPosition, new Vector3(0f, 0.3f, -0.766666f), Time.deltaTime);
					this.StrugglePOV.localPosition = Vector3.Lerp(this.StrugglePOV.localPosition, new Vector3(0.75f, 0.3f, -0.966666f), Time.deltaTime);
					return;
				}
				this.StruggleFocus.localPosition = Vector3.Lerp(this.StruggleFocus.localPosition, new Vector3(0f, 0.3f, -0.766666f), Time.deltaTime);
				this.StrugglePOV.localPosition = Vector3.Lerp(this.StrugglePOV.localPosition, new Vector3(0.75f, 0.3f, -0.966666f), Time.deltaTime);
				return;
			}
			else if (this.ObstacleCounter)
			{
				this.StruggleFocus.position += new Vector3(this.Shake * UnityEngine.Random.Range(-1f, 1f), this.Shake * UnityEngine.Random.Range(-0.5f, 0.5f), this.Shake * UnityEngine.Random.Range(-1f, 1f));
				this.Shake = Mathf.Lerp(this.Shake, 0f, Time.deltaTime * 5f);
				if (this.Yandere.Armed)
				{
					this.Yandere.EquippedWeapon.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
				}
				if (this.Timer == 0f)
				{
					this.StruggleFocus.position = base.transform.position + base.transform.forward;
					this.StrugglePOV.position = base.transform.position;
				}
				base.transform.position = Vector3.Lerp(base.transform.position, this.StrugglePOV.position, Time.deltaTime * 10f);
				base.transform.LookAt(this.StruggleFocus);
				this.Timer += Time.deltaTime;
				if (this.Timer > 0.5f && this.Phase < 2)
				{
					this.Yandere.CameraEffects.MurderWitnessed();
					this.Yandere.Jukebox.GameOver();
					this.Phase++;
				}
				if (this.Timer > 7.6f && this.Phase < 3)
				{
					if (this.Yandere.Armed)
					{
						this.Yandere.EquippedWeapon.Drop();
					}
					this.Shake += 0.2f;
					this.Phase++;
				}
				if (this.Timer > 10f && this.Phase < 4)
				{
					this.Shake += 0.2f;
					this.Phase++;
				}
				if (this.Timer > 12f && this.Phase < 5)
				{
					this.HeartbrokenCamera.GetComponent<Camera>().cullingMask |= 512;
					this.HeartbrokenCamera.SetActive(true);
					this.Phase++;
				}
				if (this.Timer < 6f)
				{
					this.StruggleFocus.localPosition = Vector3.Lerp(this.StruggleFocus.localPosition, new Vector3(-0.166666f, 1.2f, 0.82f), Time.deltaTime);
					this.StrugglePOV.localPosition = Vector3.Lerp(this.StrugglePOV.localPosition, new Vector3(0.66666f, 1.2f, 0.82f), Time.deltaTime);
					return;
				}
				if (this.Timer < 8.5f)
				{
					this.StruggleFocus.localPosition = Vector3.Lerp(this.StruggleFocus.localPosition, new Vector3(-0.166666f, 1.2f, 0.82f), Time.deltaTime);
					this.StrugglePOV.localPosition = Vector3.Lerp(this.StrugglePOV.localPosition, new Vector3(2f, 1.2f, 0.82f), Time.deltaTime);
					return;
				}
				if (this.Timer < 12f)
				{
					this.StruggleFocus.localPosition = Vector3.Lerp(this.StruggleFocus.localPosition, new Vector3(-0.85f, 0.5f, 1.75f), Time.deltaTime * 2f);
					this.StrugglePOV.localPosition = Vector3.Lerp(this.StrugglePOV.localPosition, new Vector3(-0.85f, 0.5f, 3f), Time.deltaTime * 2f);
					return;
				}
				this.StruggleFocus.localPosition = Vector3.Lerp(this.StruggleFocus.localPosition, new Vector3(-0.85f, 1.1f, 1.75f), Time.deltaTime * 2f);
				this.StrugglePOV.localPosition = Vector3.Lerp(this.StrugglePOV.localPosition, new Vector3(-0.85f, 1f, 4f), Time.deltaTime * 2f);
				return;
			}
			else if (this.Struggle)
			{
				base.transform.position = Vector3.Lerp(base.transform.position, this.StrugglePOV.position, Time.deltaTime * 10f);
				base.transform.LookAt(this.StruggleFocus);
				if (this.Yandere.Lost)
				{
					this.StruggleFocus.localPosition = Vector3.MoveTowards(this.StruggleFocus.localPosition, this.LossFocus, Time.deltaTime);
					this.StrugglePOV.localPosition = Vector3.MoveTowards(this.StrugglePOV.localPosition, this.LossPOV, Time.deltaTime);
					if (this.Timer == 0f)
					{
						AudioSource component2 = base.GetComponent<AudioSource>();
						component2.clip = this.StruggleLose;
						component2.Play();
					}
					this.Timer += Time.deltaTime;
					if (this.Timer < 3f)
					{
						base.transform.Translate(Vector3.back * (Time.deltaTime * 10f * this.Timer * (3f - this.Timer)));
						return;
					}
					if (!this.HeartbrokenCamera.activeInHierarchy)
					{
						this.HeartbrokenCamera.SetActive(true);
						this.Yandere.Jukebox.GameOver();
						base.enabled = false;
						return;
					}
				}
			}
			else
			{
				if (this.Yandere.Attacked)
				{
					this.Focus.transform.parent = null;
					this.Focus.transform.position = Vector3.Lerp(this.Focus.transform.position, this.Yandere.Hips.position, Time.deltaTime);
					base.transform.LookAt(this.Focus);
					return;
				}
				if (this.LookDown)
				{
					this.Timer += Time.deltaTime;
					if (this.Timer < 5f)
					{
						base.transform.position = Vector3.Lerp(base.transform.position, this.Yandere.Hips.position + Vector3.up * 3f + Vector3.right * 0.1f, Time.deltaTime * this.Timer);
						this.Focus.transform.parent = null;
						this.Focus.transform.position = Vector3.Lerp(this.Focus.transform.position, this.Yandere.Hips.position, Time.deltaTime * this.Timer);
						base.transform.LookAt(this.Focus);
						return;
					}
					if (!this.HeartbrokenCamera.activeInHierarchy)
					{
						this.HeartbrokenCamera.SetActive(true);
						this.Yandere.Jukebox.GameOver();
						base.enabled = false;
						return;
					}
				}
				else
				{
					if (this.Summoning)
					{
						if (this.Phase == 1)
						{
							this.NoticedPOV.position = this.Yandere.transform.position + this.Yandere.transform.forward * 1.7f + this.Yandere.transform.right * 0.15f + Vector3.up * 1.375f;
							this.NoticedFocus.position = base.transform.position + base.transform.forward;
							this.NoticedSpeed = 10f;
							this.Phase++;
						}
						else if (this.Phase == 2)
						{
							this.NoticedPOV.Translate(this.NoticedPOV.forward * (Time.deltaTime * -0.1f));
							this.NoticedFocus.position = Vector3.Lerp(this.NoticedFocus.position, this.Yandere.transform.position + this.Yandere.transform.right * 0.15f + Vector3.up * 1.375f, Time.deltaTime * 10f);
							this.Timer += Time.deltaTime;
							if (this.Timer > 2f)
							{
								this.Yandere.Stand.Spawn();
								this.NoticedPOV.position = this.Yandere.transform.position + this.Yandere.transform.forward * 2f + Vector3.up * 2.4f;
								this.Timer = 0f;
								this.Phase++;
							}
						}
						else if (this.Phase == 3)
						{
							this.NoticedPOV.Translate(this.NoticedPOV.forward * (Time.deltaTime * -0.1f));
							this.NoticedFocus.position = this.Yandere.transform.position + Vector3.up * 2.4f;
							this.Yandere.Stand.Stand.SetActive(true);
							this.Timer += Time.deltaTime;
							if (this.Timer > 5f)
							{
								this.Phase++;
							}
						}
						else if (this.Phase == 4)
						{
							this.Yandere.Stand.transform.localPosition = new Vector3(this.Yandere.Stand.transform.localPosition.x, 0f, this.Yandere.Stand.transform.localPosition.z);
							this.Yandere.Jukebox.PlayJojo();
							this.Yandere.Talking = true;
							this.Summoning = false;
							this.Timer = 0f;
							this.Phase = 1;
						}
						base.transform.position = Vector3.Lerp(base.transform.position, this.NoticedPOV.position, Time.deltaTime * this.NoticedSpeed);
						base.transform.LookAt(this.NoticedFocus);
						return;
					}
					if ((this.Yandere.Talking || this.Yandere.Won) && !this.RPGCamera.enabled)
					{
						this.Timer += Time.deltaTime;
						if (this.Timer < 0.5f)
						{
							base.transform.position = Vector3.Lerp(base.transform.position, this.LastPosition, Time.deltaTime * this.ReturnSpeed);
							if (this.Yandere.Talking)
							{
								this.ShoulderFocus.position = Vector3.Lerp(this.ShoulderFocus.position, this.RPGCamera.cameraPivot.position, Time.deltaTime * this.ReturnSpeed);
								base.transform.LookAt(this.ShoulderFocus);
								return;
							}
							this.StruggleFocus.position = Vector3.Lerp(this.StruggleFocus.position, this.RPGCamera.cameraPivot.position, Time.deltaTime * this.ReturnSpeed);
							base.transform.LookAt(this.StruggleFocus);
							return;
						}
						else
						{
							this.RPGCamera.enabled = true;
							this.Yandere.MyController.enabled = true;
							this.Yandere.Talking = false;
							if (!this.Yandere.Sprayed)
							{
								this.Yandere.CanMove = true;
							}
							this.Yandere.Pursuer = null;
							this.Yandere.Chased = false;
							this.Yandere.Won = false;
							this.Timer = 0f;
						}
					}
				}
			}
		}
	}

	// Token: 0x06001C91 RID: 7313 RVA: 0x00150AC3 File Offset: 0x0014ECC3
	public void YandereNo()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.StruggleLose;
		component.Play();
	}

	// Token: 0x06001C92 RID: 7314 RVA: 0x00150ADC File Offset: 0x0014ECDC
	public void GameOver()
	{
		this.NoticedPOV.parent = this.Yandere.transform;
		this.NoticedFocus.parent = this.Yandere.transform;
		this.NoticedFocus.localPosition = new Vector3(0f, 1f, 0f);
		this.NoticedPOV.localPosition = new Vector3(0f, 1f, 2f);
		this.NoticedPOV.LookAt(this.NoticedFocus.position);
		this.Yandere.CharacterAnimation.CrossFade("f02_down_22");
		this.Yandere.HeartCamera.gameObject.SetActive(false);
		this.HeartbrokenCamera.SetActive(true);
		this.Yandere.RPGCamera.enabled = false;
		this.Yandere.Collapse = true;
		this.Yandere.HUD.alpha = 0f;
		this.Yandere.StudentManager.Students[1].Pathfinding.canSearch = false;
		this.Yandere.StudentManager.Students[1].Pathfinding.canMove = false;
		this.Yandere.StudentManager.Students[1].Fleeing = false;
	}

	// Token: 0x040032D5 RID: 13013
	public PauseScreenScript PauseScreen;

	// Token: 0x040032D6 RID: 13014
	public CounselorScript Counselor;

	// Token: 0x040032D7 RID: 13015
	public YandereScript Yandere;

	// Token: 0x040032D8 RID: 13016
	public RPG_Camera RPGCamera;

	// Token: 0x040032D9 RID: 13017
	public PortalScript Portal;

	// Token: 0x040032DA RID: 13018
	public GameObject HeartbrokenCamera;

	// Token: 0x040032DB RID: 13019
	public GameObject HUD;

	// Token: 0x040032DC RID: 13020
	public Transform Smartphone;

	// Token: 0x040032DD RID: 13021
	public Transform Teacher;

	// Token: 0x040032DE RID: 13022
	public Transform ShoulderFocus;

	// Token: 0x040032DF RID: 13023
	public Transform ShoulderPOV;

	// Token: 0x040032E0 RID: 13024
	public Transform EightiesSpineFollower;

	// Token: 0x040032E1 RID: 13025
	public Transform EightiesCameraFocus;

	// Token: 0x040032E2 RID: 13026
	public Transform EightiesCameraPOV;

	// Token: 0x040032E3 RID: 13027
	public Transform CameraFocus;

	// Token: 0x040032E4 RID: 13028
	public Transform CameraPOV;

	// Token: 0x040032E5 RID: 13029
	public Transform NoticedFocus;

	// Token: 0x040032E6 RID: 13030
	public Transform NoticedPOV;

	// Token: 0x040032E7 RID: 13031
	public Transform StruggleFocus;

	// Token: 0x040032E8 RID: 13032
	public Transform StrugglePOV;

	// Token: 0x040032E9 RID: 13033
	public Transform Focus;

	// Token: 0x040032EA RID: 13034
	public Vector3 LastPosition;

	// Token: 0x040032EB RID: 13035
	public Vector3 TeacherLossFocus;

	// Token: 0x040032EC RID: 13036
	public Vector3 TeacherLossPOV;

	// Token: 0x040032ED RID: 13037
	public Vector3 LossFocus;

	// Token: 0x040032EE RID: 13038
	public Vector3 LossPOV;

	// Token: 0x040032EF RID: 13039
	public bool GoingToCounselor;

	// Token: 0x040032F0 RID: 13040
	public bool ObstacleCounter;

	// Token: 0x040032F1 RID: 13041
	public bool AimingCamera;

	// Token: 0x040032F2 RID: 13042
	public bool OverShoulder;

	// Token: 0x040032F3 RID: 13043
	public bool Summoning;

	// Token: 0x040032F4 RID: 13044
	public bool LookDown;

	// Token: 0x040032F5 RID: 13045
	public bool Scolding;

	// Token: 0x040032F6 RID: 13046
	public bool Struggle;

	// Token: 0x040032F7 RID: 13047
	public bool Counter;

	// Token: 0x040032F8 RID: 13048
	public bool Noticed;

	// Token: 0x040032F9 RID: 13049
	public bool Spoken;

	// Token: 0x040032FA RID: 13050
	public bool Skip;

	// Token: 0x040032FB RID: 13051
	public AudioClip StruggleLose;

	// Token: 0x040032FC RID: 13052
	public AudioClip Slam;

	// Token: 0x040032FD RID: 13053
	public float NoticedHeight;

	// Token: 0x040032FE RID: 13054
	public float NoticedTimer;

	// Token: 0x040032FF RID: 13055
	public float NoticedSpeed;

	// Token: 0x04003300 RID: 13056
	public float ReturnSpeed = 10f;

	// Token: 0x04003301 RID: 13057
	public float Height;

	// Token: 0x04003302 RID: 13058
	public float Shake;

	// Token: 0x04003303 RID: 13059
	public float PullBackTimer;

	// Token: 0x04003304 RID: 13060
	public float Timer;

	// Token: 0x04003305 RID: 13061
	public int NoticedLimit;

	// Token: 0x04003306 RID: 13062
	public int Phase;
}
