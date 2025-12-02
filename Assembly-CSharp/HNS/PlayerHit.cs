using UnityEngine;

namespace HNS
{
	public class PlayerHit : MonoBehaviour
	{
		public static PlayerHit Instance;

		private void OnEnable()
		{
			Instance = this;
		}

		private void OnDisable()
		{
			Instance = null;
		}

		private void Update()
		{
			if (Player.instance.State == PlayerState.Default && Player.instance.Stance == PlayerStance.Hit && PlayerAnimator.Finished(0.05f))
			{
				Player.instance.Stance = PlayerStance.Default;
			}
		}

		public void Trigger()
		{
			Player.instance.Stance = PlayerStance.Hit;
		}
	}
}
