﻿using System;
using UnityEngine;

// Token: 0x02000468 RID: 1128
public class TapePlayerMenuScript : MonoBehaviour
{
	// Token: 0x06001E9B RID: 7835 RVA: 0x001AD96C File Offset: 0x001ABB6C
	private void Start()
	{
		this.List.transform.localPosition = new Vector3(-955f, this.List.transform.localPosition.y, this.List.transform.localPosition.z);
		this.TimeBar.localPosition = new Vector3(this.TimeBar.localPosition.x, 100f, this.TimeBar.localPosition.z);
		this.Subtitle.text = string.Empty;
		this.TapePlayerCamera.position = new Vector3(-26.15f, this.TapePlayerCamera.position.y, 5.35f);
	}

	// Token: 0x06001E9C RID: 7836 RVA: 0x001ADA2C File Offset: 0x001ABC2C
	private void Update()
	{
		float t = Time.unscaledDeltaTime * 10f;
		if (Input.GetKeyDown("="))
		{
			AudioSource myAudio = this.MyAudio;
			float pitch = myAudio.pitch;
			myAudio.pitch = pitch + 1f;
		}
		if (Input.GetKeyDown("-"))
		{
			AudioSource myAudio2 = this.MyAudio;
			float pitch = myAudio2.pitch;
			myAudio2.pitch = pitch - 1f;
		}
		if (this.Show)
		{
			if (this.Listening)
			{
				this.List.localPosition = new Vector3(Mathf.Lerp(this.List.localPosition.x, -955f, t), this.List.localPosition.y, this.List.localPosition.z);
				this.TimeBar.localPosition = new Vector3(this.TimeBar.localPosition.x, Mathf.Lerp(this.TimeBar.localPosition.y, 0f, t), this.TimeBar.localPosition.z);
				this.TapePlayerCamera.position = new Vector3(Mathf.Lerp(this.TapePlayerCamera.position.x, -26.15f, t), this.TapePlayerCamera.position.y, Mathf.Lerp(this.TapePlayerCamera.position.z, 5.35f, t));
				if (this.Phase == 1)
				{
					this.TapePlayerAnim["InsertTape"].time += Time.unscaledDeltaTime * 3.33333f;
					if (this.TapePlayerAnim["InsertTape"].time >= this.TapePlayerAnim["InsertTape"].length)
					{
						this.TapePlayerAnim.Play("PressPlay");
						this.MyAudio.pitch = 1f;
						this.MyAudio.Play();
						this.PromptBar.Label[0].text = "PAUSE";
						this.PromptBar.Label[1].text = "STOP";
						this.PromptBar.Label[5].text = "REWIND / FAST FORWARD";
						this.PromptBar.UpdateButtons();
						this.Phase++;
					}
				}
				else if (this.Phase == 2)
				{
					this.Timer += Time.unscaledDeltaTime;
					if (this.MyAudio.isPlaying)
					{
						if (this.Timer > 0.1f)
						{
							this.TapePlayerAnim["PressPlay"].time += Time.unscaledDeltaTime;
							if (this.TapePlayerAnim["PressPlay"].time > this.TapePlayerAnim["PressPlay"].length)
							{
								this.TapePlayerAnim["PressPlay"].time = this.TapePlayerAnim["PressPlay"].length;
							}
						}
					}
					else
					{
						this.TapePlayerAnim["PressPlay"].time -= Time.unscaledDeltaTime;
						if (this.TapePlayerAnim["PressPlay"].time < 0f)
						{
							this.TapePlayerAnim["PressPlay"].time = 0f;
						}
						if (Input.GetButtonDown("A"))
						{
							this.PromptBar.Label[0].text = "PAUSE";
							this.TapePlayer.Spin = true;
							this.MyAudio.time = this.ResumeTime;
							this.MyAudio.Play();
						}
					}
					if (this.TapePlayerAnim["PressPlay"].time >= this.TapePlayerAnim["PressPlay"].length)
					{
						this.TapePlayer.Spin = true;
						if (this.MyAudio.time >= this.MyAudio.clip.length - 3f)
						{
							this.MyAudio.pitch = 1f;
							Time.timeScale = 1f;
						}
						if (this.MyAudio.time >= this.MyAudio.clip.length - 1f)
						{
							this.TapePlayerAnim.Play("PressEject");
							this.TapePlayer.Spin = false;
							if (!this.MyAudio.isPlaying)
							{
								this.MyAudio.clip = this.TapeStop;
								this.MyAudio.Play();
							}
							this.Subtitle.text = string.Empty;
							this.Phase++;
						}
						if (Input.GetButtonDown("A") && this.MyAudio.isPlaying)
						{
							this.PromptBar.Label[0].text = "PLAY";
							this.TapePlayer.Spin = false;
							this.ResumeTime = this.MyAudio.time;
							this.MyAudio.Stop();
						}
					}
					if (Input.GetButtonDown("B"))
					{
						this.TapePlayerAnim.Play("PressEject");
						this.TapePlayer.Spin = false;
						this.MyAudio.clip = this.TapeStop;
						this.MyAudio.time = 0f;
						this.MyAudio.Play();
						this.PromptBar.Label[0].text = string.Empty;
						this.PromptBar.Label[1].text = string.Empty;
						this.PromptBar.Label[5].text = string.Empty;
						this.PromptBar.UpdateButtons();
						this.Subtitle.text = string.Empty;
						this.Phase++;
					}
				}
				else if (this.Phase == 3)
				{
					this.TapePlayerAnim["PressEject"].time += Time.unscaledDeltaTime;
					if (this.TapePlayerAnim["PressEject"].time >= this.TapePlayerAnim["PressEject"].length)
					{
						this.TapePlayerAnim.Play("InsertTape");
						this.TapePlayerAnim["InsertTape"].time = this.TapePlayerAnim["InsertTape"].length;
						this.TapePlayer.FastForward = false;
						this.Phase++;
					}
				}
				else if (this.Phase == 4)
				{
					if (this.TapePlayerAnim["InsertTape"].time > this.TapePlayerAnim["InsertTape"].length)
					{
						this.TapePlayerAnim["InsertTape"].time = this.TapePlayerAnim["InsertTape"].length;
					}
					this.TapePlayerAnim["InsertTape"].time -= Time.unscaledDeltaTime * 3.33333f;
					if (this.TapePlayerAnim["InsertTape"].time <= 0f)
					{
						this.TapePlayer.Tape.SetActive(false);
						this.Jukebox.SetActive(true);
						this.Listening = false;
						this.Timer = 0f;
						this.PromptBar.Label[0].text = "PLAY";
						this.PromptBar.Label[1].text = "BACK";
						this.PromptBar.Label[4].text = "CHOOSE";
						this.PromptBar.Label[5].text = "CATEGORY";
						this.PromptBar.UpdateButtons();
					}
				}
				if (this.Phase != 2)
				{
					this.Label.text = "00:00 / 00:00";
					this.Bar.fillAmount = 0f;
					return;
				}
				if (this.InputManager.DPadRight || Input.GetKey(KeyCode.RightArrow))
				{
					this.ResumeTime += 1.6666666f;
					this.MyAudio.time += 1.6666666f;
					this.TapePlayer.FastForward = true;
				}
				else
				{
					this.TapePlayer.FastForward = false;
				}
				if (this.InputManager.DPadLeft || Input.GetKey(KeyCode.LeftArrow))
				{
					this.ResumeTime -= 1.6666666f;
					this.MyAudio.time -= 1.6666666f;
					this.TapePlayer.Rewind = true;
				}
				else
				{
					this.TapePlayer.Rewind = false;
				}
				int num;
				int num2;
				if (this.MyAudio.isPlaying)
				{
					num = Mathf.FloorToInt(this.MyAudio.time / 60f);
					num2 = Mathf.FloorToInt(this.MyAudio.time - (float)num * 60f);
					this.Bar.fillAmount = this.MyAudio.time / this.MyAudio.clip.length;
				}
				else
				{
					num = Mathf.FloorToInt(this.ResumeTime / 60f);
					num2 = Mathf.FloorToInt(this.ResumeTime - (float)num * 60f);
					this.Bar.fillAmount = this.ResumeTime / this.MyAudio.clip.length;
				}
				this.CurrentTime = string.Format("{00:00}:{1:00}", num, num2);
				this.Label.text = this.CurrentTime + " / " + this.ClipLength;
				if (this.Category == 1)
				{
					if (this.Selected == 1)
					{
						for (int i = 0; i < this.Cues1.Length; i++)
						{
							if (this.MyAudio.time > this.Cues1[i])
							{
								this.Subtitle.text = this.Subs1[i];
							}
						}
						return;
					}
					if (this.Selected == 2)
					{
						for (int j = 0; j < this.Cues2.Length; j++)
						{
							if (this.MyAudio.time > this.Cues2[j])
							{
								this.Subtitle.text = this.Subs2[j];
							}
						}
						return;
					}
					if (this.Selected == 3)
					{
						for (int k = 0; k < this.Cues3.Length; k++)
						{
							if (this.MyAudio.time > this.Cues3[k])
							{
								this.Subtitle.text = this.Subs3[k];
							}
						}
						return;
					}
					if (this.Selected == 4)
					{
						for (int l = 0; l < this.Cues4.Length; l++)
						{
							if (this.MyAudio.time > this.Cues4[l])
							{
								this.Subtitle.text = this.Subs4[l];
							}
						}
						return;
					}
					if (this.Selected == 5)
					{
						for (int m = 0; m < this.Cues5.Length; m++)
						{
							if (this.MyAudio.time > this.Cues5[m])
							{
								this.Subtitle.text = this.Subs5[m];
							}
						}
						return;
					}
					if (this.Selected == 6)
					{
						for (int n = 0; n < this.Cues6.Length; n++)
						{
							if (this.MyAudio.time > this.Cues6[n])
							{
								this.Subtitle.text = this.Subs6[n];
							}
						}
						return;
					}
					if (this.Selected == 7)
					{
						for (int num3 = 0; num3 < this.Cues7.Length; num3++)
						{
							if (this.MyAudio.time > this.Cues7[num3])
							{
								this.Subtitle.text = this.Subs7[num3];
							}
						}
						return;
					}
					if (this.Selected == 8)
					{
						for (int num4 = 0; num4 < this.Cues8.Length; num4++)
						{
							if (this.MyAudio.time > this.Cues8[num4])
							{
								this.Subtitle.text = this.Subs8[num4];
							}
						}
						return;
					}
					if (this.Selected == 9)
					{
						for (int num5 = 0; num5 < this.Cues9.Length; num5++)
						{
							if (this.MyAudio.time > this.Cues9[num5])
							{
								this.Subtitle.text = this.Subs9[num5];
							}
						}
						return;
					}
					if (this.Selected == 10)
					{
						for (int num6 = 0; num6 < this.Cues10.Length; num6++)
						{
							if (this.MyAudio.time > this.Cues10[num6])
							{
								this.Subtitle.text = this.Subs10[num6];
							}
						}
						return;
					}
				}
				else if (this.Category == 2)
				{
					if (this.Selected == 1)
					{
						for (int num7 = 0; num7 < this.BasementCues1.Length; num7++)
						{
							if (this.MyAudio.time > this.BasementCues1[num7])
							{
								this.Subtitle.text = this.BasementSubs1[num7];
							}
						}
					}
					if (this.Selected == 10)
					{
						for (int num8 = 0; num8 < this.BasementCues10.Length; num8++)
						{
							if (this.MyAudio.time > this.BasementCues10[num8])
							{
								this.Subtitle.text = this.BasementSubs10[num8];
							}
						}
						return;
					}
				}
				else if (this.Category == 3)
				{
					if (this.Selected == 1)
					{
						for (int num9 = 0; num9 < this.HeadmasterCues1.Length; num9++)
						{
							if (this.MyAudio.time > this.HeadmasterCues1[num9])
							{
								this.Subtitle.text = this.HeadmasterSubs1[num9];
							}
						}
						return;
					}
					if (this.Selected == 2)
					{
						for (int num10 = 0; num10 < this.HeadmasterCues2.Length; num10++)
						{
							if (this.MyAudio.time > this.HeadmasterCues2[num10])
							{
								this.Subtitle.text = this.HeadmasterSubs2[num10];
							}
						}
						return;
					}
					if (this.Selected == 3)
					{
						for (int num11 = 0; num11 < this.HeadmasterCues3.Length; num11++)
						{
							if (this.MyAudio.time > this.HeadmasterCues3[num11])
							{
								this.Subtitle.text = this.HeadmasterSubs3[num11];
							}
						}
						return;
					}
					if (this.Selected == 4)
					{
						for (int num12 = 0; num12 < this.HeadmasterCues4.Length; num12++)
						{
							if (this.MyAudio.time > this.HeadmasterCues4[num12])
							{
								this.Subtitle.text = this.HeadmasterSubs4[num12];
							}
						}
						return;
					}
					if (this.Selected == 5)
					{
						for (int num13 = 0; num13 < this.HeadmasterCues5.Length; num13++)
						{
							if (this.MyAudio.time > this.HeadmasterCues5[num13])
							{
								this.Subtitle.text = this.HeadmasterSubs5[num13];
							}
						}
						return;
					}
					if (this.Selected == 6)
					{
						for (int num14 = 0; num14 < this.HeadmasterCues6.Length; num14++)
						{
							if (this.MyAudio.time > this.HeadmasterCues6[num14])
							{
								this.Subtitle.text = this.HeadmasterSubs6[num14];
							}
						}
						return;
					}
					if (this.Selected == 7)
					{
						for (int num15 = 0; num15 < this.HeadmasterCues7.Length; num15++)
						{
							if (this.MyAudio.time > this.HeadmasterCues7[num15])
							{
								this.Subtitle.text = this.HeadmasterSubs7[num15];
							}
						}
						return;
					}
					if (this.Selected == 8)
					{
						for (int num16 = 0; num16 < this.HeadmasterCues8.Length; num16++)
						{
							if (this.MyAudio.time > this.HeadmasterCues8[num16])
							{
								this.Subtitle.text = this.HeadmasterSubs8[num16];
							}
						}
						return;
					}
					if (this.Selected == 9)
					{
						for (int num17 = 0; num17 < this.HeadmasterCues9.Length; num17++)
						{
							if (this.MyAudio.time > this.HeadmasterCues9[num17])
							{
								this.Subtitle.text = this.HeadmasterSubs9[num17];
							}
						}
						return;
					}
					if (this.Selected == 10)
					{
						for (int num18 = 0; num18 < this.HeadmasterCues10.Length; num18++)
						{
							if (this.MyAudio.time > this.HeadmasterCues10[num18])
							{
								this.Subtitle.text = this.HeadmasterSubs10[num18];
							}
						}
						return;
					}
				}
			}
			else
			{
				this.TapePlayerAnim.Stop();
				this.TapePlayerCamera.position = new Vector3(Mathf.Lerp(this.TapePlayerCamera.position.x, -26.2125f, t), this.TapePlayerCamera.position.y, Mathf.Lerp(this.TapePlayerCamera.position.z, 5.4125f, t));
				this.List.transform.localPosition = new Vector3(Mathf.Lerp(this.List.transform.localPosition.x, 0f, t), this.List.transform.localPosition.y, this.List.transform.localPosition.z);
				this.TimeBar.localPosition = new Vector3(this.TimeBar.localPosition.x, Mathf.Lerp(this.TimeBar.localPosition.y, 100f, t), this.TimeBar.localPosition.z);
				if (this.InputManager.TappedRight)
				{
					this.Category++;
					if (this.Category > 3)
					{
						this.Category = 1;
					}
					this.UpdateLabels();
				}
				else if (this.InputManager.TappedLeft)
				{
					this.Category--;
					if (this.Category < 1)
					{
						this.Category = 3;
					}
					this.UpdateLabels();
				}
				if (this.InputManager.TappedUp)
				{
					this.Selected--;
					if (this.Selected < 1)
					{
						this.Selected = 10;
					}
					this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 440f - 80f * (float)this.Selected, this.Highlight.localPosition.z);
					this.CheckSelection();
					return;
				}
				if (this.InputManager.TappedDown)
				{
					this.Selected++;
					if (this.Selected > 10)
					{
						this.Selected = 1;
					}
					this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 440f - 80f * (float)this.Selected, this.Highlight.localPosition.z);
					this.CheckSelection();
					return;
				}
				if (Input.GetButtonDown("A"))
				{
					bool flag = false;
					if (this.Category == 1)
					{
						if (this.StudentManager.TapesCollected[this.Selected])
						{
							CollectibleGlobals.SetTapeListened(this.Selected, true);
							flag = true;
						}
					}
					else if (this.Category == 2)
					{
						if (CollectibleGlobals.GetBasementTapeCollected(this.Selected))
						{
							CollectibleGlobals.SetBasementTapeListened(this.Selected, true);
							flag = true;
						}
					}
					else if (this.Category == 3 && this.StudentManager.HeadmasterTapesCollected[this.Selected])
					{
						CollectibleGlobals.SetHeadmasterTapeListened(this.Selected, true);
						flag = true;
					}
					if (flag)
					{
						this.NewIcons[this.Selected].SetActive(false);
						this.Jukebox.SetActive(false);
						this.Listening = true;
						this.Phase = 1;
						this.PromptBar.Label[0].text = string.Empty;
						this.PromptBar.Label[1].text = string.Empty;
						this.PromptBar.Label[4].text = string.Empty;
						this.PromptBar.UpdateButtons();
						this.TapePlayerAnim["InsertTape"].time = 0f;
						this.TapePlayerAnim.Play("InsertTape");
						this.TapePlayer.Tape.SetActive(true);
						if (this.Category == 1)
						{
							this.MyAudio.clip = this.Recordings[this.Selected];
						}
						else if (this.Category == 2)
						{
							this.MyAudio.clip = this.BasementRecordings[this.Selected];
						}
						else
						{
							this.MyAudio.clip = this.HeadmasterRecordings[this.Selected];
						}
						this.MyAudio.time = 0f;
						this.RoundedTime = (float)Mathf.CeilToInt(this.MyAudio.clip.length);
						int num19 = (int)(this.RoundedTime / 60f);
						int num20 = (int)(this.RoundedTime % 60f);
						this.ClipLength = string.Format("{0:00}:{1:00}", num19, num20);
						return;
					}
				}
				else if (Input.GetButtonDown("B"))
				{
					this.TapePlayer.Yandere.HeartCamera.enabled = true;
					this.TapePlayer.Yandere.RPGCamera.enabled = true;
					this.TapePlayer.TapePlayerCamera.enabled = false;
					this.TapePlayer.NoteWindow.SetActive(true);
					this.TapePlayer.PromptBar.ClearButtons();
					this.TapePlayer.Yandere.CanMove = true;
					this.TapePlayer.PromptBar.Show = false;
					this.TapePlayer.Prompt.enabled = true;
					this.TapePlayer.Yandere.HUD.alpha = 1f;
					Time.timeScale = 1f;
					this.Show = false;
				}
			}
			return;
		}
		if (this.List.localPosition.x > -955f)
		{
			this.List.localPosition = new Vector3(Mathf.Lerp(this.List.localPosition.x, -956f, t), this.List.localPosition.y, this.List.localPosition.z);
			this.TimeBar.localPosition = new Vector3(this.TimeBar.localPosition.x, Mathf.Lerp(this.TimeBar.localPosition.y, 100f, t), this.TimeBar.localPosition.z);
			return;
		}
		this.TimeBar.gameObject.SetActive(false);
		this.List.gameObject.SetActive(false);
	}

	// Token: 0x06001E9D RID: 7837 RVA: 0x001AF084 File Offset: 0x001AD284
	public void UpdateLabels()
	{
		int i = 0;
		while (i < this.TotalTapes)
		{
			i++;
			if (this.Category == 1)
			{
				this.HeaderLabel.text = "Mysterious Tapes";
				if (this.StudentManager.TapesCollected[i])
				{
					this.TapeLabels[i].text = "Mysterious Tape " + i.ToString();
					this.NewIcons[i].SetActive(!CollectibleGlobals.GetTapeListened(i));
				}
				else
				{
					this.TapeLabels[i].text = "?????";
					this.NewIcons[i].SetActive(false);
				}
			}
			else if (this.Category == 2)
			{
				this.HeaderLabel.text = "Basement Tapes";
				if (CollectibleGlobals.GetBasementTapeCollected(i))
				{
					this.TapeLabels[i].text = "Basement Tape " + i.ToString();
					this.NewIcons[i].SetActive(!CollectibleGlobals.GetBasementTapeListened(i));
				}
				else
				{
					this.TapeLabels[i].text = "?????";
					this.NewIcons[i].SetActive(false);
				}
			}
			else
			{
				this.HeaderLabel.text = "Headmaster Tapes";
				if (this.StudentManager.HeadmasterTapesCollected[i])
				{
					this.TapeLabels[i].text = "Headmaster Tape " + i.ToString();
					this.NewIcons[i].SetActive(!CollectibleGlobals.GetHeadmasterTapeListened(i));
				}
				else
				{
					this.TapeLabels[i].text = "?????";
					this.NewIcons[i].SetActive(false);
				}
			}
		}
	}

	// Token: 0x06001E9E RID: 7838 RVA: 0x001AF220 File Offset: 0x001AD420
	public void CheckSelection()
	{
		if (this.Category == 1)
		{
			this.TapePlayer.PromptBar.Label[0].text = (this.StudentManager.TapesCollected[this.Selected] ? "PLAY" : string.Empty);
			this.TapePlayer.PromptBar.UpdateButtons();
			return;
		}
		if (this.Category == 2)
		{
			this.TapePlayer.PromptBar.Label[0].text = (CollectibleGlobals.GetBasementTapeCollected(this.Selected) ? "PLAY" : string.Empty);
			this.TapePlayer.PromptBar.UpdateButtons();
			return;
		}
		this.TapePlayer.PromptBar.Label[0].text = (this.StudentManager.HeadmasterTapesCollected[this.Selected] ? "PLAY" : string.Empty);
		this.TapePlayer.PromptBar.UpdateButtons();
	}

	// Token: 0x04003F13 RID: 16147
	public StudentManagerScript StudentManager;

	// Token: 0x04003F14 RID: 16148
	public InputManagerScript InputManager;

	// Token: 0x04003F15 RID: 16149
	public TapePlayerScript TapePlayer;

	// Token: 0x04003F16 RID: 16150
	public PromptBarScript PromptBar;

	// Token: 0x04003F17 RID: 16151
	public Animation TapePlayerAnim;

	// Token: 0x04003F18 RID: 16152
	public AudioSource MyAudio;

	// Token: 0x04003F19 RID: 16153
	public GameObject Jukebox;

	// Token: 0x04003F1A RID: 16154
	public Transform TapePlayerCamera;

	// Token: 0x04003F1B RID: 16155
	public Transform Highlight;

	// Token: 0x04003F1C RID: 16156
	public Transform TimeBar;

	// Token: 0x04003F1D RID: 16157
	public Transform List;

	// Token: 0x04003F1E RID: 16158
	public AudioClip[] Recordings;

	// Token: 0x04003F1F RID: 16159
	public AudioClip[] BasementRecordings;

	// Token: 0x04003F20 RID: 16160
	public AudioClip[] HeadmasterRecordings;

	// Token: 0x04003F21 RID: 16161
	public UILabel[] TapeLabels;

	// Token: 0x04003F22 RID: 16162
	public GameObject[] NewIcons;

	// Token: 0x04003F23 RID: 16163
	public AudioClip TapeStop;

	// Token: 0x04003F24 RID: 16164
	public string CurrentTime;

	// Token: 0x04003F25 RID: 16165
	public string ClipLength;

	// Token: 0x04003F26 RID: 16166
	public bool Listening;

	// Token: 0x04003F27 RID: 16167
	public bool Show;

	// Token: 0x04003F28 RID: 16168
	public UILabel HeaderLabel;

	// Token: 0x04003F29 RID: 16169
	public UILabel Subtitle;

	// Token: 0x04003F2A RID: 16170
	public UILabel Label;

	// Token: 0x04003F2B RID: 16171
	public UISprite Bar;

	// Token: 0x04003F2C RID: 16172
	public int TotalTapes = 10;

	// Token: 0x04003F2D RID: 16173
	public int Category = 1;

	// Token: 0x04003F2E RID: 16174
	public int Selected = 1;

	// Token: 0x04003F2F RID: 16175
	public int Phase = 1;

	// Token: 0x04003F30 RID: 16176
	public float RoundedTime;

	// Token: 0x04003F31 RID: 16177
	public float ResumeTime;

	// Token: 0x04003F32 RID: 16178
	public float Timer;

	// Token: 0x04003F33 RID: 16179
	public float[] Cues1;

	// Token: 0x04003F34 RID: 16180
	public float[] Cues2;

	// Token: 0x04003F35 RID: 16181
	public float[] Cues3;

	// Token: 0x04003F36 RID: 16182
	public float[] Cues4;

	// Token: 0x04003F37 RID: 16183
	public float[] Cues5;

	// Token: 0x04003F38 RID: 16184
	public float[] Cues6;

	// Token: 0x04003F39 RID: 16185
	public float[] Cues7;

	// Token: 0x04003F3A RID: 16186
	public float[] Cues8;

	// Token: 0x04003F3B RID: 16187
	public float[] Cues9;

	// Token: 0x04003F3C RID: 16188
	public float[] Cues10;

	// Token: 0x04003F3D RID: 16189
	public string[] Subs1;

	// Token: 0x04003F3E RID: 16190
	public string[] Subs2;

	// Token: 0x04003F3F RID: 16191
	public string[] Subs3;

	// Token: 0x04003F40 RID: 16192
	public string[] Subs4;

	// Token: 0x04003F41 RID: 16193
	public string[] Subs5;

	// Token: 0x04003F42 RID: 16194
	public string[] Subs6;

	// Token: 0x04003F43 RID: 16195
	public string[] Subs7;

	// Token: 0x04003F44 RID: 16196
	public string[] Subs8;

	// Token: 0x04003F45 RID: 16197
	public string[] Subs9;

	// Token: 0x04003F46 RID: 16198
	public string[] Subs10;

	// Token: 0x04003F47 RID: 16199
	public float[] BasementCues1;

	// Token: 0x04003F48 RID: 16200
	public float[] BasementCues10;

	// Token: 0x04003F49 RID: 16201
	public string[] BasementSubs1;

	// Token: 0x04003F4A RID: 16202
	public string[] BasementSubs10;

	// Token: 0x04003F4B RID: 16203
	public float[] HeadmasterCues1;

	// Token: 0x04003F4C RID: 16204
	public float[] HeadmasterCues2;

	// Token: 0x04003F4D RID: 16205
	public float[] HeadmasterCues3;

	// Token: 0x04003F4E RID: 16206
	public float[] HeadmasterCues4;

	// Token: 0x04003F4F RID: 16207
	public float[] HeadmasterCues5;

	// Token: 0x04003F50 RID: 16208
	public float[] HeadmasterCues6;

	// Token: 0x04003F51 RID: 16209
	public float[] HeadmasterCues7;

	// Token: 0x04003F52 RID: 16210
	public float[] HeadmasterCues8;

	// Token: 0x04003F53 RID: 16211
	public float[] HeadmasterCues9;

	// Token: 0x04003F54 RID: 16212
	public float[] HeadmasterCues10;

	// Token: 0x04003F55 RID: 16213
	public string[] HeadmasterSubs1;

	// Token: 0x04003F56 RID: 16214
	public string[] HeadmasterSubs2;

	// Token: 0x04003F57 RID: 16215
	public string[] HeadmasterSubs3;

	// Token: 0x04003F58 RID: 16216
	public string[] HeadmasterSubs4;

	// Token: 0x04003F59 RID: 16217
	public string[] HeadmasterSubs5;

	// Token: 0x04003F5A RID: 16218
	public string[] HeadmasterSubs6;

	// Token: 0x04003F5B RID: 16219
	public string[] HeadmasterSubs7;

	// Token: 0x04003F5C RID: 16220
	public string[] HeadmasterSubs8;

	// Token: 0x04003F5D RID: 16221
	public string[] HeadmasterSubs9;

	// Token: 0x04003F5E RID: 16222
	public string[] HeadmasterSubs10;
}
