using UnityEngine;

namespace HNS
{
	public class Die : IState
	{
		private Enemy m_enemy;

		private int state = -1;

		private int flashes = 3;

		private float timer;

		private bool countedKill;

		public EnemyState State => EnemyState.Die;

		public Die(Enemy enemy)
		{
			m_enemy = enemy;
		}

		public void Start()
		{
			m_enemy.Animator.Play(AnimationHashes.Die);
			m_enemy.MyController.enabled = false;
			if ((bool)EnemyCoordinator.Instance)
			{
				EnemyCoordinator.Instance.OnEnemyDied(m_enemy);
			}
			if ((bool)PlayerHealth.instance && !countedKill)
			{
				PlayerHealth.instance.AddEnemyKill();
				countedKill = true;
			}
		}

		public void Update(float deltaTime)
		{
			if (state == -1)
			{
				if (m_enemy.Animator.Finished(0.05f))
				{
					state++;
				}
			}
			else if (state <= flashes)
			{
				timer += deltaTime * 3f;
				SkinnedMeshRenderer[] myRenderer = m_enemy.MyRenderer;
				for (int i = 0; i < myRenderer.Length; i++)
				{
					myRenderer[i].enabled = timer < 0.5f;
				}
				if (timer > 1f)
				{
					state++;
					timer = 0f;
				}
			}
			else
			{
				Object.Destroy(m_enemy.gameObject);
			}
		}

		public void FixedUpdate(float fixedDeltaTime)
		{
		}

		public void LateUpdate(float deltaTime)
		{
		}

		public void Exit()
		{
		}
	}
}
