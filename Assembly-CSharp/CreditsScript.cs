﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000266 RID: 614
public class CreditsScript : MonoBehaviour
{
	// Token: 0x17000338 RID: 824
	// (get) Token: 0x060012F7 RID: 4855 RVA: 0x000A7A21 File Offset: 0x000A5C21
	private bool ShouldStopCredits
	{
		get
		{
			return this.ID == this.JSON.Credits.Length;
		}
	}

	// Token: 0x060012F8 RID: 4856 RVA: 0x000A7A38 File Offset: 0x000A5C38
	private GameObject SpawnLabel(int size)
	{
		return UnityEngine.Object.Instantiate<GameObject>((size == 1) ? this.SmallCreditsLabel : this.BigCreditsLabel, this.SpawnPoint.position, Quaternion.identity);
	}

	// Token: 0x060012F9 RID: 4857 RVA: 0x000A7A64 File Offset: 0x000A5C64
	private void Start()
	{
		if (GameGlobals.TransitionToPostCredits || GameGlobals.DarkEnding)
		{
			GameGlobals.DarkEnding = false;
			this.Jukebox.clip = this.DarkCreditsMusic;
			this.Darkness.color = new Color(0f, 0f, 0f, 0f);
			this.Blossoms.startColor = new Color(0.5f, 0f, 0f, 1f);
			this.SkipLabel.color = new Color(0.5f, 0f, 0f, 1f);
			this.Dark = true;
		}
		if (GameGlobals.Eighties)
		{
			Camera.main.backgroundColor = new Color(0.05f, 0.05f, 0.05f, 1f);
			this.Jukebox.clip = this.EightiesCreditsMusic;
			this.Eighties = true;
		}
	}

	// Token: 0x060012FA RID: 4858 RVA: 0x000A7B50 File Offset: 0x000A5D50
	private void Update()
	{
		this.MusicTimer += Time.deltaTime;
		if (!this.Begin)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 1f)
			{
				this.Begin = true;
				this.Jukebox.Play();
				this.Timer = 0f;
				this.SpawnCredit();
			}
		}
		else
		{
			if (!this.ShouldStopCredits)
			{
				this.Timer += Time.deltaTime * this.Speed;
				if (this.Timer >= this.TimerLimit)
				{
					this.SpawnCredit();
					this.Timer -= this.TimerLimit;
				}
			}
			if (Input.GetButtonDown("X") || this.MusicTimer >= this.Jukebox.clip.length)
			{
				this.FadeOut = true;
			}
		}
		if (this.FadeOut)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
			this.Jukebox.volume -= Time.deltaTime;
			if (this.Darkness.color.a == 1f)
			{
				if (GameGlobals.TransitionToPostCredits)
				{
					SceneManager.LoadScene("PostCreditsScene");
				}
				else if (GameGlobals.TrueEnding)
				{
					SceneManager.LoadScene("TrueEndingScene");
				}
				else
				{
					SceneManager.LoadScene("NewTitleScene");
				}
			}
		}
		bool keyDown = Input.GetKeyDown(KeyCode.Minus);
		bool keyDown2 = Input.GetKeyDown(KeyCode.Equals);
		if (keyDown)
		{
			Time.timeScale -= 1f;
		}
		else if (keyDown2)
		{
			Time.timeScale += 1f;
		}
		if (keyDown || keyDown2)
		{
			this.Jukebox.pitch = Time.timeScale;
		}
	}

	// Token: 0x060012FB RID: 4859 RVA: 0x000A7D44 File Offset: 0x000A5F44
	public void SpawnCredit()
	{
		CreditJson creditJson = this.JSON.Credits[this.ID];
		GameObject gameObject = this.SpawnLabel(creditJson.Size);
		this.TimerLimit = (float)creditJson.Size * this.SpeedUpFactor;
		gameObject.transform.parent = this.Panel;
		gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
		gameObject.GetComponent<UILabel>().text = creditJson.Name;
		if (this.Eighties)
		{
			gameObject.GetComponent<UILabel>().color = new Color(0.8235294f, 0.6431373f, 1f, 1f);
		}
		else if (this.Dark)
		{
			gameObject.GetComponent<UILabel>().color = new Color(0.5f, 0f, 0f, 1f);
		}
		this.ID++;
	}

	// Token: 0x04001AE9 RID: 6889
	[SerializeField]
	private JsonScript JSON;

	// Token: 0x04001AEA RID: 6890
	[SerializeField]
	private Transform SpawnPoint;

	// Token: 0x04001AEB RID: 6891
	[SerializeField]
	private Transform Panel;

	// Token: 0x04001AEC RID: 6892
	[SerializeField]
	private GameObject SmallCreditsLabel;

	// Token: 0x04001AED RID: 6893
	[SerializeField]
	private GameObject BigCreditsLabel;

	// Token: 0x04001AEE RID: 6894
	[SerializeField]
	private UILabel SkipLabel;

	// Token: 0x04001AEF RID: 6895
	[SerializeField]
	private UISprite Darkness;

	// Token: 0x04001AF0 RID: 6896
	[SerializeField]
	private int ID;

	// Token: 0x04001AF1 RID: 6897
	public float SpeedUpFactor;

	// Token: 0x04001AF2 RID: 6898
	public float MusicTimer;

	// Token: 0x04001AF3 RID: 6899
	public float TimerLimit;

	// Token: 0x04001AF4 RID: 6900
	public float FadeTimer;

	// Token: 0x04001AF5 RID: 6901
	public float Speed = 1f;

	// Token: 0x04001AF6 RID: 6902
	public float Timer;

	// Token: 0x04001AF7 RID: 6903
	public bool Eighties;

	// Token: 0x04001AF8 RID: 6904
	public bool FadeOut;

	// Token: 0x04001AF9 RID: 6905
	public bool Begin;

	// Token: 0x04001AFA RID: 6906
	public bool Dark;

	// Token: 0x04001AFB RID: 6907
	private const int SmallTextSize = 1;

	// Token: 0x04001AFC RID: 6908
	private const int BigTextSize = 2;

	// Token: 0x04001AFD RID: 6909
	public AudioClip EightiesCreditsMusic;

	// Token: 0x04001AFE RID: 6910
	public AudioClip DarkCreditsMusic;

	// Token: 0x04001AFF RID: 6911
	public AudioSource Jukebox;

	// Token: 0x04001B00 RID: 6912
	public ParticleSystem Blossoms;
}
