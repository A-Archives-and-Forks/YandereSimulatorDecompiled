﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020004BE RID: 1214
public class WalkToSchoolManagerScript : MonoBehaviour
{
	// Token: 0x06001FC9 RID: 8137 RVA: 0x001BFFA8 File Offset: 0x001BE1A8
	private void Start()
	{
		Application.targetFrameRate = 60;
		if (SchoolGlobals.SchoolAtmosphere < 0.5f || GameGlobals.LoveSick)
		{
			this.Darkness.color = new Color(0f, 0f, 0f, 1f);
		}
		else
		{
			this.Darkness.color = new Color(1f, 1f, 1f, 1f);
		}
		this.Window.localScale = new Vector3(0f, 0f, 0f);
		this.Yandere.Character.GetComponent<Animation>()["f02_newWalk_00"].time = UnityEngine.Random.Range(0f, this.Yandere.Character.GetComponent<Animation>()["f02_newWalk_00"].length);
		this.Yandere.WearOutdoorShoes();
		this.Senpai.WearOutdoorShoes();
		this.Rival.WearOutdoorShoes();
		if (GameGlobals.BlondeHair)
		{
			this.PonytailRenderer.material.mainTexture = this.BlondePony;
		}
	}

	// Token: 0x06001FCA RID: 8138 RVA: 0x001C00C0 File Offset: 0x001BE2C0
	private void Update()
	{
		for (int i = 1; i < 3; i++)
		{
			Transform transform = this.Neighborhood[i];
			transform.position = new Vector3(transform.position.x - Time.deltaTime * this.ScrollSpeed, transform.position.y, transform.position.z);
			if (transform.position.x < -160f)
			{
				transform.position = new Vector3(transform.position.x + 320f, transform.position.y, transform.position.z);
			}
		}
		if (!this.FadeOut)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
			if (this.Darkness.color.a == 0f)
			{
				if (!this.ShowWindow)
				{
					if (!this.Ending)
					{
						if (Input.GetButtonDown("A"))
						{
							this.Timer = 1f;
						}
						this.Timer += Time.deltaTime;
						if (this.Timer > 1f)
						{
							this.RivalEyeRTarget = this.RivalEyeR.localEulerAngles.y;
							this.RivalEyeLTarget = this.RivalEyeL.localEulerAngles.y;
							this.SenpaiEyeRTarget = this.SenpaiEyeR.localEulerAngles.y;
							this.SenpaiEyeLTarget = this.SenpaiEyeL.localEulerAngles.y;
							this.ShowWindow = true;
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[0].text = "Continue";
							this.PromptBar.Label[2].text = "Skip";
							this.PromptBar.UpdateButtons();
							this.PromptBar.Show = true;
						}
					}
					else
					{
						this.Window.localScale = Vector3.Lerp(this.Window.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime * 10f);
						if ((double)this.Window.localScale.x < 0.01)
						{
							this.Timer += Time.deltaTime;
							if (this.Timer > 1f)
							{
								this.FadeOut = true;
							}
						}
					}
				}
				else
				{
					this.Window.localScale = Vector3.Lerp(this.Window.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
					if ((double)this.Window.localScale.x > 0.99)
					{
						if (this.Frame > 3)
						{
							this.Typewriter.mLabel.color = new Color(1f, 1f, 1f, 1f);
						}
						this.Frame++;
					}
					if (!this.Talk)
					{
						if ((double)this.Window.localScale.x > 0.99)
						{
							this.Talk = true;
							this.UpdateNameLabel();
							this.Typewriter.enabled = true;
							this.Typewriter.ResetToBeginning();
							this.Typewriter.mFullText = this.Lines[this.ID];
							this.Typewriter.mLabel.text = this.Lines[this.ID];
							this.Typewriter.mLabel.color = new Color(1f, 1f, 1f, 0f);
							this.MyAudio.clip = this.Speech[this.ID];
							this.MyAudio.Play();
						}
					}
					else
					{
						if (this.Auto && !this.MyAudio.isPlaying)
						{
							this.AutoTimer += Time.deltaTime;
						}
						if (Input.GetButtonDown("A") || this.AutoTimer > 1f)
						{
							Debug.Log("Detected button press.");
							this.AutoTimer = 0f;
							if (this.ID < this.Lines.Length - 1)
							{
								if (this.Typewriter.mCurrentOffset < this.Typewriter.mFullText.Length)
								{
									Debug.Log("Line not finished yet.");
									this.Typewriter.Finish();
									this.Typewriter.mCurrentOffset = this.Typewriter.mFullText.Length;
								}
								else
								{
									Debug.Log("Line finished.");
									this.ID++;
									this.Frame = 0;
									this.Typewriter.ResetToBeginning();
									this.Typewriter.mFullText = this.Lines[this.ID];
									this.Typewriter.mLabel.text = this.Lines[this.ID];
									this.Typewriter.mLabel.color = new Color(1f, 1f, 1f, 0f);
									this.MyAudio.clip = this.Speech[this.ID];
									this.MyAudio.Play();
									this.UpdateNameLabel();
								}
							}
							else if (this.Typewriter.mCurrentOffset < this.Typewriter.mFullText.Length)
							{
								this.Typewriter.Finish();
							}
							else
							{
								this.End();
							}
						}
						if (Input.GetButtonDown("X"))
						{
							this.End();
						}
					}
				}
			}
		}
		else
		{
			this.MyAudio.volume -= Time.deltaTime;
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
			if (this.Darkness.color.a == 1f && !this.Debugging)
			{
				SceneManager.LoadScene("LoadingScene");
			}
		}
		if (Input.GetKeyDown(KeyCode.Equals))
		{
			Time.timeScale += 10f;
		}
		if (Input.GetKeyDown(KeyCode.Minus))
		{
			Time.timeScale -= 10f;
		}
	}

	// Token: 0x06001FCB RID: 8139 RVA: 0x001C076C File Offset: 0x001BE96C
	private void LateUpdate()
	{
		if (this.Talk)
		{
			if (!this.Ending)
			{
				this.RivalNeckTarget = Mathf.Lerp(this.RivalNeckTarget, 15f, Time.deltaTime * 3.6f);
				this.RivalHeadTarget = Mathf.Lerp(this.RivalHeadTarget, 15f, Time.deltaTime * 3.6f);
				this.RivalEyeRTarget = Mathf.Lerp(this.RivalEyeRTarget, 95f, Time.deltaTime * 3.6f);
				this.RivalEyeLTarget = Mathf.Lerp(this.RivalEyeLTarget, 275f, Time.deltaTime * 3.6f);
				this.SenpaiNeckTarget = Mathf.Lerp(this.SenpaiNeckTarget, -15f, Time.deltaTime * 3.6f);
				this.SenpaiHeadTarget = Mathf.Lerp(this.SenpaiHeadTarget, -15f, Time.deltaTime * 3.6f);
				this.SenpaiEyeRTarget = Mathf.Lerp(this.SenpaiEyeRTarget, 85f, Time.deltaTime * 3.6f);
				this.SenpaiEyeLTarget = Mathf.Lerp(this.SenpaiEyeLTarget, 265f, Time.deltaTime * 3.6f);
				this.YandereNeckTarget = Mathf.Lerp(this.YandereNeckTarget, 7.5f, Time.deltaTime * 3.6f);
				this.YandereHeadTarget = Mathf.Lerp(this.YandereHeadTarget, 7.5f, Time.deltaTime * 3.6f);
			}
			else
			{
				this.RivalNeckTarget = Mathf.Lerp(this.RivalNeckTarget, 0f, Time.deltaTime * 3.6f);
				this.RivalHeadTarget = Mathf.Lerp(this.RivalHeadTarget, 0f, Time.deltaTime * 3.6f);
				this.RivalEyeRTarget = Mathf.Lerp(this.RivalEyeRTarget, 90f, Time.deltaTime * 3.6f);
				this.RivalEyeLTarget = Mathf.Lerp(this.RivalEyeLTarget, 270f, Time.deltaTime * 3.6f);
				this.SenpaiNeckTarget = Mathf.Lerp(this.SenpaiNeckTarget, 0f, Time.deltaTime * 3.6f);
				this.SenpaiHeadTarget = Mathf.Lerp(this.SenpaiHeadTarget, 0f, Time.deltaTime * 3.6f);
				this.SenpaiEyeRTarget = Mathf.Lerp(this.SenpaiEyeRTarget, 90f, Time.deltaTime * 3.6f);
				this.SenpaiEyeLTarget = Mathf.Lerp(this.SenpaiEyeLTarget, 270f, Time.deltaTime * 3.6f);
				this.YandereNeckTarget = Mathf.Lerp(this.YandereNeckTarget, 0f, Time.deltaTime * 3.6f);
				this.YandereHeadTarget = Mathf.Lerp(this.YandereHeadTarget, 0f, Time.deltaTime * 3.6f);
			}
			this.RivalNeck.localEulerAngles = new Vector3(this.RivalNeck.localEulerAngles.x, this.RivalNeckTarget, this.RivalNeck.localEulerAngles.z);
			this.RivalHead.localEulerAngles = new Vector3(this.RivalHead.localEulerAngles.x, this.RivalHeadTarget, this.RivalHead.localEulerAngles.z);
			this.RivalEyeR.localEulerAngles = new Vector3(this.RivalEyeR.localEulerAngles.x, this.RivalEyeRTarget, this.RivalEyeR.localEulerAngles.z);
			this.RivalEyeL.localEulerAngles = new Vector3(this.RivalEyeL.localEulerAngles.x, this.RivalEyeLTarget, this.RivalEyeL.localEulerAngles.z);
			this.SenpaiNeck.localEulerAngles = new Vector3(this.SenpaiNeck.localEulerAngles.x, this.SenpaiNeckTarget, this.SenpaiNeck.localEulerAngles.z);
			this.SenpaiHead.localEulerAngles = new Vector3(this.SenpaiHead.localEulerAngles.x, this.SenpaiHeadTarget, this.SenpaiHead.localEulerAngles.z);
			this.SenpaiEyeR.localEulerAngles = new Vector3(this.SenpaiEyeR.localEulerAngles.x, this.SenpaiEyeRTarget, this.SenpaiEyeR.localEulerAngles.z);
			this.SenpaiEyeL.localEulerAngles = new Vector3(this.SenpaiEyeL.localEulerAngles.x, this.SenpaiEyeLTarget, this.SenpaiEyeL.localEulerAngles.z);
			this.YandereNeck.localEulerAngles = new Vector3(this.YandereNeck.localEulerAngles.x, this.YandereNeckTarget, this.YandereNeck.localEulerAngles.z);
			this.YandereHead.localEulerAngles = new Vector3(this.YandereHead.localEulerAngles.x, this.YandereHeadTarget, this.YandereHead.localEulerAngles.z);
			if (this.MyAudio.isPlaying)
			{
				this.MouthTimer += Time.deltaTime;
				if (this.MouthTimer > this.TimerLimit)
				{
					this.MouthTarget = UnityEngine.Random.Range(40f, 40f + this.MouthExtent);
					this.MouthTimer = 0f;
				}
				if (this.Speakers[this.ID])
				{
					this.RivalJaw.localEulerAngles = new Vector3(this.RivalJaw.localEulerAngles.x, this.RivalJaw.localEulerAngles.y, Mathf.Lerp(this.RivalJaw.localEulerAngles.z, this.MouthTarget, Time.deltaTime * this.TalkSpeed));
					this.RivalLipL.localPosition = new Vector3(this.RivalLipL.localPosition.x, Mathf.Lerp(this.RivalLipL.localPosition.y, 0.02632812f + this.MouthTarget * this.LipStrength, Time.deltaTime * this.TalkSpeed), this.RivalLipL.localPosition.z);
					this.RivalLipR.localPosition = new Vector3(this.RivalLipR.localPosition.x, Mathf.Lerp(this.RivalLipR.localPosition.y, 0.02632812f + this.MouthTarget * this.LipStrength, Time.deltaTime * this.TalkSpeed), this.RivalLipR.localPosition.z);
					return;
				}
				this.SenpaiJaw.localEulerAngles = new Vector3(this.SenpaiJaw.localEulerAngles.x, this.SenpaiJaw.localEulerAngles.y, Mathf.Lerp(this.SenpaiJaw.localEulerAngles.z, this.MouthTarget, Time.deltaTime * this.TalkSpeed));
				this.SenpaiLipL.localPosition = new Vector3(this.SenpaiLipL.localPosition.x, Mathf.Lerp(this.SenpaiLipL.localPosition.y, 0.02632812f + this.MouthTarget * this.LipStrength, Time.deltaTime * this.TalkSpeed), this.SenpaiLipL.localPosition.z);
				this.SenpaiLipR.localPosition = new Vector3(this.SenpaiLipR.localPosition.x, Mathf.Lerp(this.SenpaiLipR.localPosition.y, 0.02632812f + this.MouthTarget * this.LipStrength, Time.deltaTime * this.TalkSpeed), this.SenpaiLipR.localPosition.z);
			}
		}
	}

	// Token: 0x06001FCC RID: 8140 RVA: 0x001C0EEC File Offset: 0x001BF0EC
	public void UpdateNameLabel()
	{
		if (this.Speakers[this.ID])
		{
			this.NameLabel.text = "Osana-chan";
			return;
		}
		this.NameLabel.text = "Senpai-kun";
	}

	// Token: 0x06001FCD RID: 8141 RVA: 0x001C0F1E File Offset: 0x001BF11E
	public void End()
	{
		this.PromptBar.Show = false;
		this.ShowWindow = false;
		this.Ending = true;
		this.Timer = 0f;
	}

	// Token: 0x04004260 RID: 16992
	public PromptBarScript PromptBar;

	// Token: 0x04004261 RID: 16993
	public CosmeticScript Yandere;

	// Token: 0x04004262 RID: 16994
	public CosmeticScript Senpai;

	// Token: 0x04004263 RID: 16995
	public CosmeticScript Rival;

	// Token: 0x04004264 RID: 16996
	public UISprite Darkness;

	// Token: 0x04004265 RID: 16997
	public Transform[] Neighborhood;

	// Token: 0x04004266 RID: 16998
	public Transform Window;

	// Token: 0x04004267 RID: 16999
	public Transform RivalNeck;

	// Token: 0x04004268 RID: 17000
	public Transform RivalHead;

	// Token: 0x04004269 RID: 17001
	public Transform RivalEyeR;

	// Token: 0x0400426A RID: 17002
	public Transform RivalEyeL;

	// Token: 0x0400426B RID: 17003
	public Transform RivalJaw;

	// Token: 0x0400426C RID: 17004
	public Transform RivalLipL;

	// Token: 0x0400426D RID: 17005
	public Transform RivalLipR;

	// Token: 0x0400426E RID: 17006
	public Transform SenpaiNeck;

	// Token: 0x0400426F RID: 17007
	public Transform SenpaiHead;

	// Token: 0x04004270 RID: 17008
	public Transform SenpaiEyeR;

	// Token: 0x04004271 RID: 17009
	public Transform SenpaiEyeL;

	// Token: 0x04004272 RID: 17010
	public Transform SenpaiJaw;

	// Token: 0x04004273 RID: 17011
	public Transform SenpaiLipL;

	// Token: 0x04004274 RID: 17012
	public Transform SenpaiLipR;

	// Token: 0x04004275 RID: 17013
	public Transform YandereNeck;

	// Token: 0x04004276 RID: 17014
	public Transform YandereHead;

	// Token: 0x04004277 RID: 17015
	public Transform YandereEyeR;

	// Token: 0x04004278 RID: 17016
	public Transform YandereEyeL;

	// Token: 0x04004279 RID: 17017
	public AudioSource MyAudio;

	// Token: 0x0400427A RID: 17018
	public float ScrollSpeed = 1f;

	// Token: 0x0400427B RID: 17019
	public float LipStrength = 0.0001f;

	// Token: 0x0400427C RID: 17020
	public float TimerLimit = 0.1f;

	// Token: 0x0400427D RID: 17021
	public float TalkSpeed = 10f;

	// Token: 0x0400427E RID: 17022
	public float AutoTimer;

	// Token: 0x0400427F RID: 17023
	public float Timer;

	// Token: 0x04004280 RID: 17024
	public float MouthExtent = 5f;

	// Token: 0x04004281 RID: 17025
	public float MouthTarget;

	// Token: 0x04004282 RID: 17026
	public float MouthTimer;

	// Token: 0x04004283 RID: 17027
	public float RivalNeckTarget;

	// Token: 0x04004284 RID: 17028
	public float RivalHeadTarget;

	// Token: 0x04004285 RID: 17029
	public float RivalEyeRTarget;

	// Token: 0x04004286 RID: 17030
	public float RivalEyeLTarget;

	// Token: 0x04004287 RID: 17031
	public float SenpaiNeckTarget;

	// Token: 0x04004288 RID: 17032
	public float SenpaiHeadTarget;

	// Token: 0x04004289 RID: 17033
	public float SenpaiEyeRTarget;

	// Token: 0x0400428A RID: 17034
	public float SenpaiEyeLTarget;

	// Token: 0x0400428B RID: 17035
	public float YandereNeckTarget;

	// Token: 0x0400428C RID: 17036
	public float YandereHeadTarget;

	// Token: 0x0400428D RID: 17037
	public bool ShowWindow;

	// Token: 0x0400428E RID: 17038
	public bool Debugging;

	// Token: 0x0400428F RID: 17039
	public bool FadeOut;

	// Token: 0x04004290 RID: 17040
	public bool Ending;

	// Token: 0x04004291 RID: 17041
	public bool Auto;

	// Token: 0x04004292 RID: 17042
	public bool Talk;

	// Token: 0x04004293 RID: 17043
	public TypewriterEffect Typewriter;

	// Token: 0x04004294 RID: 17044
	public UILabel NameLabel;

	// Token: 0x04004295 RID: 17045
	public AudioClip[] Speech;

	// Token: 0x04004296 RID: 17046
	public string[] Lines;

	// Token: 0x04004297 RID: 17047
	public bool[] Speakers;

	// Token: 0x04004298 RID: 17048
	public int Frame;

	// Token: 0x04004299 RID: 17049
	public int ID;

	// Token: 0x0400429A RID: 17050
	public Renderer PonytailRenderer;

	// Token: 0x0400429B RID: 17051
	public Texture BlondePony;
}
