using UnityEngine;

namespace HNS
{
	public class PlayerAnimator : MonoBehaviour
	{
		public static PlayerAnimator instance;

		private int m_state;

		private void OnEnable()
		{
			instance = this;
		}

		private void OnDisable()
		{
			instance = null;
		}

		public static void Play(int state, float offset = 0f, int layer = 0, float crossFade = -1f)
		{
			if ((bool)instance)
			{
				instance.m_state = state;
				if (crossFade < 0f)
				{
					crossFade = Player.instance.Profile.DefaultCrossFade;
				}
				if (crossFade == 0f)
				{
					Player.instance.MyAnimator.Play(state, layer, offset);
				}
				else
				{
					Player.instance.MyAnimator.CrossFadeInFixedTime(state, crossFade, layer, offset);
				}
			}
		}

		public static bool Finished(float offset = 0f, int layer = 0)
		{
			if (Player.instance.MyAnimator.Finished(offset, layer))
			{
				return Player.instance.MyAnimator.IsPlaying(instance.m_state, layer);
			}
			return false;
		}

		public static float NormalizedTime(int layer = 0)
		{
			return Player.instance.MyAnimator.NormalizedTime(layer);
		}

		public static float FixedTime(int layer = 0)
		{
			return Player.instance.MyAnimator.FixedTime(layer);
		}
	}
}
