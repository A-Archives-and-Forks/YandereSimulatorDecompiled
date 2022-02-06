﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020002E0 RID: 736
public class GenocideEndingScript : MonoBehaviour
{
	// Token: 0x060014E7 RID: 5351 RVA: 0x000D64D0 File Offset: 0x000D46D0
	private void Start()
	{
		Time.timeScale = 1f;
		if (GameGlobals.EightiesCutsceneID == 12)
		{
			Debug.Log("We're here for the end of 1980s Mode.");
			this.SpeechText = this.EightiesText;
			this.Subtitle.text = this.SpeechText[1];
			this.SpeechClip = this.EightiesSpeechClip;
			this.MyAudio.clip = this.SpeechClip[1];
			this.MyAudio.Play();
			this.SpeechPhase = 1;
			this.YellowifyLabel(this.Subtitle);
			this.Senpai["kidnapTorture_01"].speed = 0.1f;
			this.Senpai.Play();
			this.SenpaiRopes.SetActive(true);
			this.OsanaRopes.SetActive(false);
			this.Senpai.transform.parent.gameObject.SetActive(true);
			this.Osana.SetActive(false);
			this.EightiesEnding = true;
			this.FadeSpeed = 0.1f;
			return;
		}
		if (EventGlobals.OsanaConversation)
		{
			Debug.Log("We're here for a Betray cutscene.");
			this.Osana.GetComponent<StudentScript>().CharacterAnimation["f02_kidnapTorture_01"].speed = 0.8f;
			this.Osana.GetComponent<CosmeticScript>().SetFemaleUniform();
			this.SenpaiRopes.SetActive(false);
			this.OsanaRopes.SetActive(true);
			this.Senpai.transform.parent.gameObject.SetActive(false);
			this.Osana.SetActive(true);
			this.SpeechText[10] = "...huh? ...what is this? ...why am I tied to a...chair?! Why are you doing this?! This isn't funny! Lemme go! Lemme go right now!";
			this.Subtitle.text = this.SpeechText[10];
			this.MyAudio.clip = this.OsanaClip;
			this.MyAudio.Play();
			this.SpeechPhase = 10;
			this.TimeLimit = 9f;
			this.Delay = 10f;
			if (GameGlobals.Eighties)
			{
				this.RivalHair[0].SetActive(false);
				this.RivalHair[DateGlobals.Week].SetActive(true);
				this.YellowifyLabel(this.Subtitle);
				return;
			}
		}
		else
		{
			Debug.Log("We're here for the Genocide Ending.");
			this.Senpai["kidnapTorture_01"].speed = 0.9f;
			this.SenpaiRopes.SetActive(true);
			this.OsanaRopes.SetActive(false);
			this.Senpai.transform.parent.gameObject.SetActive(true);
			this.Osana.SetActive(false);
			GameGlobals.DarkEnding = true;
		}
	}

	// Token: 0x060014E8 RID: 5352 RVA: 0x000D6754 File Offset: 0x000D4954
	private void Update()
	{
		if (!this.EightiesEnding)
		{
			if (this.SpeechPhase > 9)
			{
				base.transform.Translate(Vector3.forward * -0.1f * Time.deltaTime);
				if (this.MyAudio.isPlaying)
				{
					this.Senpai.Play();
					if (this.MyAudio.time < this.TimeLimit)
					{
						this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime * 0.25f);
					}
					else
					{
						this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * 0.25f);
					}
				}
				this.Darkness.color = new Color(0f, 0f, 0f, this.Alpha);
				if (this.Darkness.color.a == 1f)
				{
					this.Subtitle.text = "";
				}
			}
			if (!this.MyAudio.isPlaying)
			{
				this.Timer += Time.deltaTime;
				if (this.Delay == 10f && this.Timer > 1f)
				{
					if (this.Timer < 3f)
					{
						this.RIVAL.SetActive(true);
						this.ELIMINATED.SetActive(true);
					}
					else if (this.Timer < 5f)
					{
						if (this.ELIMINATED.activeInHierarchy)
						{
							this.ELIMINATED.SetActive(false);
							AudioSource.PlayClipAtPoint(this.Slam, base.transform.position);
						}
					}
					else
					{
						this.SecondAlpha = Mathf.MoveTowards(this.SecondAlpha, 1f, Time.deltaTime * 0.25f);
						this.SecondDarkness.color = new Color(0f, 0f, 0f, this.SecondAlpha);
					}
				}
				if (this.Timer > this.Delay)
				{
					this.SpeechPhase++;
					this.Timer = 0f;
					if (this.SpeechPhase < this.SpeechClip.Length)
					{
						this.Subtitle.text = this.SpeechText[this.SpeechPhase];
						this.MyAudio.clip = this.SpeechClip[this.SpeechPhase];
						this.Delay = this.SpeechDelay[this.SpeechPhase];
						this.MyAudio.Play();
						return;
					}
					if (!EventGlobals.OsanaConversation)
					{
						SceneManager.LoadScene("CreditsScene");
						return;
					}
					DateGlobals.PassDays = 1;
					SceneManager.LoadScene("CalendarScene");
					EventGlobals.OsanaConversation = false;
					return;
				}
			}
		}
		else
		{
			base.transform.Translate(Vector3.forward * -0.01f * Time.deltaTime);
			if (!this.FadeOut)
			{
				this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 0f, Time.deltaTime * this.FadeSpeed);
			}
			else
			{
				this.SecondDarkness.alpha = Mathf.MoveTowards(this.SecondDarkness.alpha, 1f, Time.deltaTime * this.FadeSpeed);
				if (this.SecondDarkness.alpha == 1f)
				{
					GameGlobals.DarkEnding = false;
					SceneManager.LoadScene("CreditsScene");
				}
			}
			if (Input.GetButtonDown("A"))
			{
				this.MyAudio.Stop();
			}
			if (!this.MyAudio.isPlaying && this.SpeechPhase < this.SpeechClip.Length - 1)
			{
				this.SpeechPhase++;
				this.Subtitle.text = this.SpeechText[this.SpeechPhase];
				this.MyAudio.clip = this.SpeechClip[this.SpeechPhase];
				this.MyAudio.Play();
				if (this.SpeechPhase == this.SpeechClip.Length - 1)
				{
					this.FadeOut = true;
				}
			}
		}
	}

	// Token: 0x060014E9 RID: 5353 RVA: 0x000D6B3C File Offset: 0x000D4D3C
	private void LateUpdate()
	{
		this.Neck.transform.localEulerAngles = new Vector3(0f, this.Neck.transform.localEulerAngles.y, this.Neck.transform.localEulerAngles.z);
	}

	// Token: 0x060014EA RID: 5354 RVA: 0x000D6B90 File Offset: 0x000D4D90
	public void YellowifyLabel(UILabel Label)
	{
		Label.trueTypeFont = this.Arial;
		Label.applyGradient = false;
		Label.color = new Color(1f, 1f, 0f, 1f);
		Label.fontStyle = FontStyle.Bold;
		Label.effectDistance = new Vector2(4f, 4f);
	}

	// Token: 0x0400215E RID: 8542
	public AudioSource MyAudio;

	// Token: 0x0400215F RID: 8543
	public UISprite SecondDarkness;

	// Token: 0x04002160 RID: 8544
	public UISprite Darkness;

	// Token: 0x04002161 RID: 8545
	public UILabel Subtitle;

	// Token: 0x04002162 RID: 8546
	public Animation Senpai;

	// Token: 0x04002163 RID: 8547
	public Transform Neck;

	// Token: 0x04002164 RID: 8548
	public AudioClip[] EightiesSpeechClip;

	// Token: 0x04002165 RID: 8549
	public AudioClip[] SpeechClip;

	// Token: 0x04002166 RID: 8550
	public AudioClip OsanaClip;

	// Token: 0x04002167 RID: 8551
	public AudioClip Slam;

	// Token: 0x04002168 RID: 8552
	public string[] EightiesText;

	// Token: 0x04002169 RID: 8553
	public string[] SpeechText;

	// Token: 0x0400216A RID: 8554
	public float[] SpeechDelay;

	// Token: 0x0400216B RID: 8555
	public float[] SpeechTime;

	// Token: 0x0400216C RID: 8556
	public GameObject RIVAL;

	// Token: 0x0400216D RID: 8557
	public GameObject ELIMINATED;

	// Token: 0x0400216E RID: 8558
	public GameObject SenpaiRopes;

	// Token: 0x0400216F RID: 8559
	public GameObject OsanaRopes;

	// Token: 0x04002170 RID: 8560
	public GameObject Osana;

	// Token: 0x04002171 RID: 8561
	public int SpeechPhase;

	// Token: 0x04002172 RID: 8562
	public float SecondAlpha;

	// Token: 0x04002173 RID: 8563
	public float FadeSpeed = 0.2f;

	// Token: 0x04002174 RID: 8564
	public float TimeLimit;

	// Token: 0x04002175 RID: 8565
	public float Alpha;

	// Token: 0x04002176 RID: 8566
	public float Delay;

	// Token: 0x04002177 RID: 8567
	public float Timer;

	// Token: 0x04002178 RID: 8568
	public bool EightiesEnding;

	// Token: 0x04002179 RID: 8569
	public bool FadeOut;

	// Token: 0x0400217A RID: 8570
	public GameObject[] RivalHair;

	// Token: 0x0400217B RID: 8571
	public Font Arial;
}
