using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HNS
{
	public class GameOverScreen : MonoBehaviour
	{
		[Header("References")]
		public UIPanel GameOverPanel;

		public UILabel GameOverLabel;

		public UILabel EnemiesLabel;

		public UILabel WavesLabel;

		public UILabel PromptLabel;

		[Header("Audio")]
		public AudioSource ImpactSound;

		public AudioClip Confirm;

		[Header("Timing")]
		public float DelayAfterImpact = 0.5f;

		public float DelayAfterEnemies = 0.5f;

		public float DelayAfterWaves = 0.5f;

		[Header("Prompt")]
		public float PromptBlinkSpeed = 0.8f;

		public float PromptMinAlpha;

		private bool isGameOver;

		private bool isTransitioning;

		private bool statsShown;

		private int enemiesDefeated;

		private int wavesCompleted;

		public static GameOverScreen Instance { get; private set; }

		public bool IsGameOver => isGameOver;

		private void Awake()
		{
			if (Instance != null && Instance != this)
			{
				Object.Destroy(base.gameObject);
			}
			else
			{
				Instance = this;
			}
		}

		private void OnEnable()
		{
			isGameOver = false;
			isTransitioning = false;
			statsShown = false;
			if ((bool)GameOverPanel)
			{
				GameOverPanel.alpha = 0f;
			}
			if ((bool)GameOverLabel)
			{
				GameOverLabel.alpha = 0f;
			}
			if ((bool)EnemiesLabel)
			{
				EnemiesLabel.alpha = 0f;
			}
			if ((bool)WavesLabel)
			{
				WavesLabel.alpha = 0f;
			}
			if ((bool)PromptLabel)
			{
				PromptLabel.alpha = 0f;
			}
		}

		private void Start()
		{
			if ((bool)FadeManager.instance)
			{
				FadeManager.instance.SetAlphaImmediate(1f);
				FadeManager.instance.FadeOut();
			}
		}

		private void Update()
		{
			if (isGameOver && !isTransitioning && statsShown && (Input.anyKeyDown || InputQuery.ButtonDown(ButtonInput.A) || InputQuery.ButtonDown(ButtonInput.Start)))
			{
				StartCoroutine(TransitionToTitle());
			}
		}

		public void TriggerGameOver(int enemies, int waves)
		{
			if (!isGameOver)
			{
				enemiesDefeated = enemies;
				wavesCompleted = waves;
				PlayerHealth.instance.fill.fillAmount = 0f;
				StartCoroutine(GameOverSequence());
			}
		}

		private IEnumerator GameOverSequence()
		{
			isGameOver = true;
			if ((bool)Player.instance && (bool)Player.instance.MyAnimator)
			{
				PlayerAnimator.Play(AnimationHashes.Die, 0f, 0, 0f);
				yield return new WaitForSeconds(0.1f);
				while (!PlayerAnimator.Finished(0.05f))
				{
					yield return null;
				}
			}
			Time.timeScale = 0f;
			if ((bool)MusicManager.instance)
			{
				MusicManager.instance.enabled = false;
				if ((bool)MusicManager.instance.GetComponent<AudioSource>())
				{
					MusicManager.instance.GetComponent<AudioSource>().Stop();
				}
			}
			if ((bool)PauseMenu.Instance)
			{
				PauseMenu.Instance.enabled = false;
			}
			if ((bool)ImpactSound)
			{
				ImpactSound.Play();
			}
			if ((bool)Rumble.Instance)
			{
				Rumble.Instance.PlayFade(1f, 1f, 1.5f);
			}
			if ((bool)GameOverPanel)
			{
				GameOverPanel.alpha = 1f;
			}
			if ((bool)GameOverLabel)
			{
				GameOverLabel.alpha = 1f;
			}
			if ((bool)EnemiesLabel)
			{
				EnemiesLabel.text = $"Enemies Killed: {enemiesDefeated}";
				EnemiesLabel.alpha = 1f;
			}
			if ((bool)WavesLabel)
			{
				WavesLabel.text = $"Waves Survived: {wavesCompleted}";
				WavesLabel.alpha = 1f;
			}
			statsShown = true;
			if ((bool)PromptLabel)
			{
				PromptLabel.alpha = 1f;
				StartCoroutine(BlinkPrompt());
			}
		}

		private IEnumerator BlinkPrompt()
		{
			if (!PromptLabel)
			{
				yield break;
			}
			bool fadingOut = true;
			while (!isTransitioning)
			{
				float elapsed = 0f;
				float startAlpha = (fadingOut ? 1f : PromptMinAlpha);
				float endAlpha = (fadingOut ? PromptMinAlpha : 1f);
				while (elapsed < PromptBlinkSpeed && !isTransitioning)
				{
					elapsed += Time.unscaledDeltaTime;
					float t = elapsed / PromptBlinkSpeed;
					PromptLabel.alpha = Mathf.Lerp(startAlpha, endAlpha, t);
					yield return null;
				}
				if (!isTransitioning)
				{
					PromptLabel.alpha = endAlpha;
				}
				fadingOut = !fadingOut;
			}
		}

		private IEnumerator TransitionToTitle()
		{
			isTransitioning = true;
			Audio.Play(Confirm, AudioType.UI, 0.5f);
			if ((bool)FadeManager.instance)
			{
				FadeManager.instance.enabled = true;
				FadeManager.instance.FadeIn();
				while (FadeManager.instance.IsFading)
				{
					yield return null;
				}
			}
			Time.timeScale = 1f;
			SceneManager.LoadScene("HNSTitleScreen");
		}
	}
}
