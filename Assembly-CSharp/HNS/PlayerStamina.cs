using UnityEngine;

namespace HNS
{
	public class PlayerStamina : MonoBehaviour
	{
		public static PlayerStamina instance;

		public UITexture fill;

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
			PlayerProfile profile = Player.instance.Profile;
			fill.fillAmount = Player.instance.Stamina / 100f;
			Player.instance.Stamina += Time.deltaTime * profile.StaminaRegenRate;
			if (Player.instance.StaminaPause > 0f)
			{
				Player.instance.StaminaPause -= Time.deltaTime;
			}
		}
	}
}
