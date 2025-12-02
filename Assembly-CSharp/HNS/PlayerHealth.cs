using UnityEngine;

namespace HNS
{
	public class PlayerHealth : MonoBehaviour
	{
		public static PlayerHealth instance;

		public CameraFilterPack_TV_Vignetting effect;

		public UITexture fill;

		[Header("Game Over")]
		public int EnemiesDefeated;

		public int WavesCompleted;

		private bool isDead;

		private void OnEnable()
		{
			instance = this;
		}

		private void OnDisable()
		{
			instance = null;
		}

		private void Update()
		{
			if (isDead)
			{
				return;
			}
			if (Player.instance.Health <= 0f)
			{
				TriggerDeath();
				return;
			}
			PlayerProfile profile = Player.instance.Profile;
			fill.fillAmount = Player.instance.Health / 100f;
			Player.instance.Health += Time.deltaTime * profile.HealthRegenRate;
			effect.Vignetting = Mathf.Lerp(effect.Vignetting, 1f - Player.instance.Health / 100f, Time.unscaledDeltaTime * profile.VignetteLerpSpeed);
			if (Player.instance.HealthPause > 0f)
			{
				Player.instance.HealthPause -= Time.deltaTime;
			}
		}

		private void TriggerDeath()
		{
			isDead = true;
			Player.instance.State = PlayerState.Cutscene;
			if ((bool)GameOverScreen.Instance)
			{
				GameOverScreen.Instance.TriggerGameOver(EnemiesDefeated, WavesCompleted);
			}
		}

		public void AddEnemyKill()
		{
			EnemiesDefeated++;
		}

		public void AddWaveComplete()
		{
			WavesCompleted++;
		}
	}
}
