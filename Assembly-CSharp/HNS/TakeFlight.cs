using UnityEngine;

namespace HNS
{
	public class TakeFlight : IState
	{
		private Enemy m_enemy;

		private Succubus m_succubus;

		private Transform m_target;

		private float m_targetDistance;

		public EnemyState State => EnemyState.TakeFlight;

		public TakeFlight(Enemy enemy, Succubus succubus, Transform target, float targetDistance)
		{
			m_enemy = enemy;
			m_succubus = succubus;
			m_target = target;
			m_targetDistance = targetDistance;
		}

		public void Start()
		{
			int state = Animator.StringToHash(m_enemy.Profile.takeFlight);
			m_enemy.Animator.Play(state);
		}

		public void Update(float deltaTime)
		{
			m_enemy.MyAnimator.SetFloat(AnimationHashes.Vertical, 0f, 0.2f, deltaTime);
			m_enemy.MyAnimator.SetFloat(AnimationHashes.Horizontal, 0f, 0.2f, deltaTime);
			if (m_enemy.Animator.Finished(0.05f))
			{
				m_enemy.Behaviour.ChangeState(new FlyToPosition(m_enemy, m_succubus, m_target, m_targetDistance));
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
