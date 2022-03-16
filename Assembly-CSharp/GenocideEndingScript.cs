﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020002E2 RID: 738
public class GenocideEndingScript : MonoBehaviour
{
	// Token: 0x060014F8 RID: 5368 RVA: 0x000D763C File Offset: 0x000D583C
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

	// Token: 0x060014F9 RID: 5369 RVA: 0x000D78C0 File Offset: 0x000D5AC0
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

	// Token: 0x060014FA RID: 5370 RVA: 0x000D7CA8 File Offset: 0x000D5EA8
	private void LateUpdate()
	{
		this.Neck.transform.localEulerAngles = new Vector3(0f, this.Neck.transform.localEulerAngles.y, this.Neck.transform.localEulerAngles.z);
	}

	// Token: 0x060014FB RID: 5371 RVA: 0x000D7CFC File Offset: 0x000D5EFC
	public void YellowifyLabel(UILabel Label)
	{
		Label.trueTypeFont = this.Arial;
		Label.applyGradient = false;
		Label.color = new Color(1f, 1f, 0f, 1f);
		Label.fontStyle = FontStyle.Bold;
		Label.effectDistance = new Vector2(4f, 4f);
	}

	// Token: 0x04002196 RID: 8598
	public AudioSource MyAudio;

	// Token: 0x04002197 RID: 8599
	public UISprite SecondDarkness;

	// Token: 0x04002198 RID: 8600
	public UISprite Darkness;

	// Token: 0x04002199 RID: 8601
	public UILabel Subtitle;

	// Token: 0x0400219A RID: 8602
	public Animation Senpai;

	// Token: 0x0400219B RID: 8603
	public Transform Neck;

	// Token: 0x0400219C RID: 8604
	public AudioClip[] EightiesSpeechClip;

	// Token: 0x0400219D RID: 8605
	public AudioClip[] SpeechClip;

	// Token: 0x0400219E RID: 8606
	public AudioClip OsanaClip;

	// Token: 0x0400219F RID: 8607
	public AudioClip Slam;

	// Token: 0x040021A0 RID: 8608
	public string[] EightiesText;

	// Token: 0x040021A1 RID: 8609
	public string[] SpeechText;

	// Token: 0x040021A2 RID: 8610
	public float[] SpeechDelay;

	// Token: 0x040021A3 RID: 8611
	public float[] SpeechTime;

	// Token: 0x040021A4 RID: 8612
	public GameObject RIVAL;

	// Token: 0x040021A5 RID: 8613
	public GameObject ELIMINATED;

	// Token: 0x040021A6 RID: 8614
	public GameObject SenpaiRopes;

	// Token: 0x040021A7 RID: 8615
	public GameObject OsanaRopes;

	// Token: 0x040021A8 RID: 8616
	public GameObject Osana;

	// Token: 0x040021A9 RID: 8617
	public int SpeechPhase;

	// Token: 0x040021AA RID: 8618
	public float SecondAlpha;

	// Token: 0x040021AB RID: 8619
	public float FadeSpeed = 0.2f;

	// Token: 0x040021AC RID: 8620
	public float TimeLimit;

	// Token: 0x040021AD RID: 8621
	public float Alpha;

	// Token: 0x040021AE RID: 8622
	public float Delay;

	// Token: 0x040021AF RID: 8623
	public float Timer;

	// Token: 0x040021B0 RID: 8624
	public bool EightiesEnding;

	// Token: 0x040021B1 RID: 8625
	public bool FadeOut;

	// Token: 0x040021B2 RID: 8626
	public GameObject[] RivalHair;

	// Token: 0x040021B3 RID: 8627
	public Font Arial;
}
