﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.SceneManagement;

// Token: 0x02000412 RID: 1042
public class SceneLoader : MonoBehaviour
{
	// Token: 0x06001C68 RID: 7272 RVA: 0x0014C188 File Offset: 0x0014A388
	private void Start()
	{
		if (OptionGlobals.DrawDistanceLimit == 0)
		{
			OptionGlobals.DrawDistance = 350;
			OptionGlobals.DrawDistanceLimit = 350;
		}
		if (PlayerPrefs.GetInt("LoadingSave") == 1)
		{
			int profile = GameGlobals.Profile;
			int @int = PlayerPrefs.GetInt("SaveSlot");
			YanSave.LoadData("Profile_" + profile.ToString() + "_Slot_" + @int.ToString(), false);
		}
		Application.runInBackground = true;
		Time.timeScale = 1f;
		if (!SchoolGlobals.SchoolAtmosphereSet)
		{
			SchoolGlobals.SchoolAtmosphereSet = true;
			SchoolGlobals.PreviousSchoolAtmosphere = 1f;
			SchoolGlobals.SchoolAtmosphere = 1f;
			PlayerGlobals.SetCannotBringItem(4, true);
			PlayerGlobals.SetCannotBringItem(5, true);
			PlayerGlobals.SetCannotBringItem(6, true);
			PlayerGlobals.SetCannotBringItem(7, true);
			PlayerGlobals.Money = 10f;
		}
		if (GameGlobals.Eighties)
		{
			this.LightAnimation.SetActive(false);
			this.LightAnimation1989.SetActive(true);
		}
		if (SchoolGlobals.SchoolAtmosphere < 0.5f || GameGlobals.LoveSick)
		{
			Camera.main.backgroundColor = new Color(0f, 0f, 0f, 1f);
			this.patienceText.color = new Color(1f, 0f, 0f, 1f);
			this.loadingText.color = new Color(1f, 0f, 0f, 1f);
			this.crashText.color = new Color(1f, 0f, 0f, 1f);
			this.KeyboardGraphic.color = new Color(1f, 0f, 0f, 1f);
			this.ControllerLines.color = new Color(1f, 0f, 0f, 1f);
			if (GameGlobals.Eighties)
			{
				this.LightAnimation1989.SetActive(false);
				this.DarkAnimation1989.SetActive(true);
			}
			else
			{
				this.LightAnimation.SetActive(false);
				this.DarkAnimation.SetActive(true);
			}
			for (int i = 1; i < this.ControllerText.Length; i++)
			{
				this.ControllerText[i].color = new Color(1f, 0f, 0f, 1f);
			}
			for (int i = 1; i < this.KeyboardText.Length; i++)
			{
				this.KeyboardText[i].color = new Color(1f, 0f, 0f, 1f);
			}
		}
		if (PlayerGlobals.UsingGamepad)
		{
			this.Keyboard.SetActive(false);
			this.Gamepad.SetActive(true);
		}
		else
		{
			this.Keyboard.SetActive(true);
			this.Gamepad.SetActive(false);
		}
		this.Debugging = false;
	}

	// Token: 0x06001C69 RID: 7273 RVA: 0x0014C440 File Offset: 0x0014A640
	private void Update()
	{
		if (this.Timer == 1f)
		{
			base.StartCoroutine(this.LoadNewScene());
		}
		this.Timer += 1f;
		if (Input.GetKeyDown("a"))
		{
			if (SchoolGlobals.SchoolAtmosphere > 0f)
			{
				SchoolGlobals.SchoolAtmosphere = 0f;
			}
			else
			{
				SchoolGlobals.SchoolAtmosphere = 1f;
			}
			SceneManager.LoadScene("LoadingScene");
		}
	}

	// Token: 0x06001C6A RID: 7274 RVA: 0x0014C4B1 File Offset: 0x0014A6B1
	private IEnumerator LoadNewScene()
	{
		AsyncOperation async = SceneManager.LoadSceneAsync("SchoolScene");
		while (!async.isDone)
		{
			yield return null;
		}
		yield break;
	}

	// Token: 0x04003232 RID: 12850
	public PostProcessingProfile Profile;

	// Token: 0x04003233 RID: 12851
	[SerializeField]
	private UILabel patienceText;

	// Token: 0x04003234 RID: 12852
	[SerializeField]
	private UILabel loadingText;

	// Token: 0x04003235 RID: 12853
	[SerializeField]
	private UILabel crashText;

	// Token: 0x04003236 RID: 12854
	private float timer;

	// Token: 0x04003237 RID: 12855
	public UILabel[] ControllerText;

	// Token: 0x04003238 RID: 12856
	public UILabel[] KeyboardText;

	// Token: 0x04003239 RID: 12857
	public GameObject LightAnimation;

	// Token: 0x0400323A RID: 12858
	public GameObject DarkAnimation;

	// Token: 0x0400323B RID: 12859
	public GameObject LightAnimation1989;

	// Token: 0x0400323C RID: 12860
	public GameObject DarkAnimation1989;

	// Token: 0x0400323D RID: 12861
	public GameObject Keyboard;

	// Token: 0x0400323E RID: 12862
	public GameObject Gamepad;

	// Token: 0x0400323F RID: 12863
	public UITexture ControllerLines;

	// Token: 0x04003240 RID: 12864
	public UITexture KeyboardGraphic;

	// Token: 0x04003241 RID: 12865
	public bool Debugging;

	// Token: 0x04003242 RID: 12866
	public float Timer;
}
