namespace HNS
{
	public class EnemyAnimator : EnemyComponent
	{
		private int m_state;

		private int waitFrames;

		public void Play(int state, float offset = 0f, int layer = 0)
		{
			if ((bool)Enemy && state != m_state)
			{
				m_state = state;
				Enemy.MyAnimator.CrossFadeInFixedTime(state, 0.3f, layer, offset);
				waitFrames = 2;
			}
		}

		public bool Finished(float offset = 0f, int layer = 0)
		{
			if (Enemy.MyAnimator.Finished(offset, layer))
			{
				return Enemy.MyAnimator.IsPlaying(m_state, layer);
			}
			return false;
		}

		public float NormalizedTime(int layer = 0)
		{
			return Enemy.MyAnimator.NormalizedTime(layer);
		}

		public float FixedTime(int layer = 0)
		{
			return Enemy.MyAnimator.FixedTime(layer);
		}

		private void Update()
		{
			if (waitFrames > 0)
			{
				waitFrames--;
			}
		}
	}
}
