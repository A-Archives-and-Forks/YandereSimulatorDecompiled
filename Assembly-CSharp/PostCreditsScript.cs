﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020003BD RID: 957
public class PostCreditsScript : MonoBehaviour
{
	// Token: 0x06001B1D RID: 6941 RVA: 0x0012D3FC File Offset: 0x0012B5FC
	private void Start()
	{
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
		this.Subtitle.text = "";
		Time.timeScale = 1f;
		this.Logo.gameObject.SetActive(false);
		this.LovesickLogo.SetActive(false);
	}

	// Token: 0x06001B1E RID: 6942 RVA: 0x0012D464 File Offset: 0x0012B664
	private void Update()
	{
		this.SkipTimer += Time.deltaTime;
		if (this.SkipTimer > 5f)
		{
			this.SkipPanel.alpha -= Time.deltaTime;
		}
		if (this.EndEarly)
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * 0.5f);
			this.Darkness.color = new Color(0f, 0f, 0f, this.Alpha);
			this.SkipPanel.alpha -= Time.deltaTime;
			this.Headmaster.volume -= Time.deltaTime;
			this.Jukebox.volume -= Time.deltaTime;
			this.Buzzing.volume -= Time.deltaTime;
			this.Darkness.material.color = new Color(0f, 0f, 0f, this.Alpha);
			this.Subtitle.text = "";
			if (this.Alpha == 1f)
			{
				SceneManager.LoadScene("ThanksForPlayingScene");
			}
		}
		else if (Input.GetButton("X"))
		{
			this.SkipPanel.alpha = 1f;
			this.SkipTimer = 0f;
			this.SkipCircle.fillAmount -= Time.deltaTime;
			if (this.SkipCircle.fillAmount == 0f)
			{
				this.EndEarly = true;
			}
		}
		else
		{
			this.SkipCircle.fillAmount = 1f;
		}
		if (Input.GetKeyDown("="))
		{
			Time.timeScale += 1f;
		}
		if (Input.GetKeyDown("-"))
		{
			Time.timeScale -= 1f;
		}
		this.Speed += Time.deltaTime * 0.001f;
		base.transform.position = Vector3.Lerp(base.transform.position, this.Destination.position, Time.deltaTime * this.Speed);
		this.Rotation = Mathf.Lerp(this.Rotation, -45f, Time.deltaTime * this.Speed);
		base.transform.eulerAngles = new Vector3(0f, this.Rotation, 0f);
		if (this.Headmaster.time > 69f)
		{
			this.Jukebox.volume -= Time.deltaTime * 0.2f;
		}
		if (this.Phase == 0)
		{
			if (Input.GetKeyDown("space"))
			{
				this.Alpha = 0f;
			}
			this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime * 0.2f);
			this.Darkness.color = new Color(0f, 0f, 0f, this.Alpha);
			if (this.Alpha == 0f)
			{
				this.Subtitle.text = this.Lines[this.SpeechID];
				this.Headmaster.Play();
				this.SpeechID++;
				this.Phase++;
				return;
			}
		}
		else if (this.Phase == 1)
		{
			if (Input.GetKeyDown("space"))
			{
				this.Headmaster.time = 68f;
			}
			this.Headmaster.pitch = Time.timeScale;
			if (this.Headmaster.time >= this.Times[this.SpeechID])
			{
				this.Subtitle.text = this.Lines[this.SpeechID];
				this.SpeechID++;
				if (this.SpeechID == 16)
				{
					this.Darkness.color = new Color(0f, 0f, 0f, 1f);
					return;
				}
				if (this.SpeechID == 17)
				{
					this.Jukebox.clip = this.CinematicHit;
					this.Jukebox.volume = 1f;
					this.Jukebox.Play();
					this.Logo.gameObject.SetActive(true);
					this.Phase++;
					return;
				}
			}
		}
		else if (this.Phase == 2)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 13f)
			{
				SceneManager.LoadScene("ThanksForPlayingScene");
			}
			else if (this.Timer > 5f)
			{
				this.Logo.alpha -= Time.deltaTime * 0.2f;
			}
			this.Logo.transform.localScale += new Vector3(Time.deltaTime * 0.02f, Time.deltaTime * 0.02f, Time.deltaTime * 0.02f);
			this.LovesickLogo.transform.localScale += new Vector3(Time.deltaTime * 0.02f, Time.deltaTime * 0.02f, Time.deltaTime * 0.02f);
		}
	}

	// Token: 0x04002DF2 RID: 11762
	public GameObject LovesickLogo;

	// Token: 0x04002DF3 RID: 11763
	public UITexture Logo;

	// Token: 0x04002DF4 RID: 11764
	public UIPanel SkipPanel;

	// Token: 0x04002DF5 RID: 11765
	public AudioSource Headmaster;

	// Token: 0x04002DF6 RID: 11766
	public AudioSource Jukebox;

	// Token: 0x04002DF7 RID: 11767
	public AudioSource Buzzing;

	// Token: 0x04002DF8 RID: 11768
	public AudioClip CinematicHit;

	// Token: 0x04002DF9 RID: 11769
	public Transform Destination;

	// Token: 0x04002DFA RID: 11770
	public UISprite SkipCircle;

	// Token: 0x04002DFB RID: 11771
	public UISprite Darkness;

	// Token: 0x04002DFC RID: 11772
	public UILabel Subtitle;

	// Token: 0x04002DFD RID: 11773
	public string[] Lines;

	// Token: 0x04002DFE RID: 11774
	public float[] Times;

	// Token: 0x04002DFF RID: 11775
	public float SkipTimer;

	// Token: 0x04002E00 RID: 11776
	public float Rotation;

	// Token: 0x04002E01 RID: 11777
	public float Alpha;

	// Token: 0x04002E02 RID: 11778
	public float Speed;

	// Token: 0x04002E03 RID: 11779
	public float Timer;

	// Token: 0x04002E04 RID: 11780
	public bool EndEarly;

	// Token: 0x04002E05 RID: 11781
	public int SpeechID;

	// Token: 0x04002E06 RID: 11782
	public int Phase;
}
