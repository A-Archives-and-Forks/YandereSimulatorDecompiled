﻿using System;
using System.Collections;
using System.Collections.Generic;
using MaidDereMinigame.Malee;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MaidDereMinigame
{
	// Token: 0x0200059B RID: 1435
	public class GameController : MonoBehaviour
	{
		// Token: 0x17000527 RID: 1319
		// (get) Token: 0x0600245E RID: 9310 RVA: 0x001FB352 File Offset: 0x001F9552
		public static GameController Instance
		{
			get
			{
				if (GameController.instance == null)
				{
					GameController.instance = UnityEngine.Object.FindObjectOfType<GameController>();
				}
				return GameController.instance;
			}
		}

		// Token: 0x17000528 RID: 1320
		// (get) Token: 0x0600245F RID: 9311 RVA: 0x001FB370 File Offset: 0x001F9570
		public static SceneWrapper Scenes
		{
			get
			{
				return GameController.Instance.scenes;
			}
		}

		// Token: 0x06002460 RID: 9312 RVA: 0x001FB37C File Offset: 0x001F957C
		public static void GoToExitScene(bool fadeOut = true)
		{
			GameController.Instance.StartCoroutine(GameController.Instance.FadeWithAction(delegate
			{
				PlayerGlobals.Money += GameController.Instance.totalPayout;
				if (PlayerGlobals.Money > 1000f)
				{
					PlayerPrefs.SetInt("RichGirl", 1);
				}
				if (SceneManager.GetActiveScene().name == "MaidMenuScene")
				{
					SceneManager.LoadScene("StreetScene");
					return;
				}
				DateGlobals.PassDays = 1;
				SceneManager.LoadScene("CalendarScene");
			}, fadeOut, true));
		}

		// Token: 0x06002461 RID: 9313 RVA: 0x001FB3B4 File Offset: 0x001F95B4
		private void Awake()
		{
			if (GameController.Instance != this)
			{
				UnityEngine.Object.DestroyImmediate(base.gameObject);
				return;
			}
			this.spriteRenderer = base.GetComponent<SpriteRenderer>();
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		}

		// Token: 0x06002462 RID: 9314 RVA: 0x001FB3E6 File Offset: 0x001F95E6
		public static void SetPause(bool toPause)
		{
			if (GameController.PauseGame != null)
			{
				GameController.PauseGame(toPause);
			}
		}

		// Token: 0x06002463 RID: 9315 RVA: 0x001FB3FA File Offset: 0x001F95FA
		public void LoadScene(SceneObject scene)
		{
			base.StartCoroutine(this.FadeWithAction(delegate
			{
				SceneManager.LoadScene("MaidGameScene");
			}, true, false));
		}

		// Token: 0x06002464 RID: 9316 RVA: 0x001FB42A File Offset: 0x001F962A
		private IEnumerator FadeWithAction(Action PostFadeAction, bool doFadeOut = true, bool destroyGameController = false)
		{
			float timeToFade = 0f;
			if (doFadeOut)
			{
				while (timeToFade <= this.activeDifficultyVariables.transitionTime)
				{
					this.spriteRenderer.color = new Color(1f, 1f, 1f, Mathf.Lerp(0f, 1f, timeToFade / this.activeDifficultyVariables.transitionTime));
					timeToFade += Time.deltaTime;
					yield return null;
				}
				this.spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
			}
			else
			{
				timeToFade = this.activeDifficultyVariables.transitionTime;
			}
			PostFadeAction();
			if (destroyGameController)
			{
				if (GameController.Instance.whiteFadeOutPost != null && doFadeOut)
				{
					GameController.Instance.whiteFadeOutPost.color = Color.white;
				}
				UnityEngine.Object.Destroy(GameController.Instance.gameObject);
				Camera.main.farClipPlane = 0f;
				GameController.instance = null;
			}
			else
			{
				while (timeToFade >= 0f)
				{
					this.spriteRenderer.color = new Color(1f, 1f, 1f, Mathf.Lerp(0f, 1f, timeToFade / this.activeDifficultyVariables.transitionTime));
					timeToFade -= Time.deltaTime;
					yield return null;
				}
				this.spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
			}
			yield break;
		}

		// Token: 0x06002465 RID: 9317 RVA: 0x001FB44E File Offset: 0x001F964E
		public static void TimeUp()
		{
			GameController.SetPause(true);
			GameController.Instance.tipPage.Init();
			GameController.Instance.tipPage.DisplayTips(GameController.Instance.tips);
			UnityEngine.Object.FindObjectOfType<GameStarter>().GetComponent<AudioSource>().Stop();
		}

		// Token: 0x06002466 RID: 9318 RVA: 0x001FB490 File Offset: 0x001F9690
		public static void AddTip(float tip)
		{
			if (GameController.Instance.tips == null)
			{
				GameController.Instance.tips = new List<float>();
			}
			tip = Mathf.Floor(tip * 100f) / 100f;
			GameController.Instance.tips.Add(tip);
		}

		// Token: 0x06002467 RID: 9319 RVA: 0x001FB4DC File Offset: 0x001F96DC
		public static float GetTotalDollars()
		{
			float num = 0f;
			foreach (float num2 in GameController.Instance.tips)
			{
				num += Mathf.Floor(num2 * 100f) / 100f;
			}
			return num + GameController.Instance.activeDifficultyVariables.basePay;
		}

		// Token: 0x06002468 RID: 9320 RVA: 0x001FB558 File Offset: 0x001F9758
		public static void AddAngryCustomer()
		{
			GameController.Instance.angryCustomers++;
			if (GameController.Instance.angryCustomers >= GameController.Instance.activeDifficultyVariables.failQuantity)
			{
				FailGame.GameFailed();
				GameController.SetPause(true);
			}
		}

		// Token: 0x04004C33 RID: 19507
		private static GameController instance;

		// Token: 0x04004C34 RID: 19508
		[Reorderable]
		public Sprites numbers;

		// Token: 0x04004C35 RID: 19509
		public SceneWrapper scenes;

		// Token: 0x04004C36 RID: 19510
		[Tooltip("Scene Object Reference to return to when the game ends.")]
		public SceneObject returnScene;

		// Token: 0x04004C37 RID: 19511
		public SetupVariables activeDifficultyVariables;

		// Token: 0x04004C38 RID: 19512
		public SetupVariables easyVariables;

		// Token: 0x04004C39 RID: 19513
		public SetupVariables mediumVariables;

		// Token: 0x04004C3A RID: 19514
		public SetupVariables hardVariables;

		// Token: 0x04004C3B RID: 19515
		private List<float> tips;

		// Token: 0x04004C3C RID: 19516
		private SpriteRenderer spriteRenderer;

		// Token: 0x04004C3D RID: 19517
		private int angryCustomers;

		// Token: 0x04004C3E RID: 19518
		[HideInInspector]
		public TipPage tipPage;

		// Token: 0x04004C3F RID: 19519
		[HideInInspector]
		public float totalPayout;

		// Token: 0x04004C40 RID: 19520
		[HideInInspector]
		public SpriteRenderer whiteFadeOutPost;

		// Token: 0x04004C41 RID: 19521
		public static BoolParameterEvent PauseGame;
	}
}
