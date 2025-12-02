using UnityEngine;

namespace HNS
{
	public class Damage : IState
	{
		private Enemy m_enemy;

		private Transform m_target;

		private float m_minDistance;

		private float m_timer;

		public EnemyState State => EnemyState.Damage;

		public Damage(float minDistance, Enemy enemy, Transform target)
		{
			m_minDistance = minDistance;
			m_enemy = enemy;
			m_target = target;
		}

		public void Start()
		{
			m_timer = 0f;
			m_enemy.Animator.Play(AnimationHashes.Damage);
		}

		public void Update(float deltaTime)
		{
			m_timer += deltaTime;
			m_enemy.MyAnimator.SetFloat(AnimationHashes.Vertical, 0f, 0.2f, deltaTime);
			m_enemy.MyAnimator.SetFloat(AnimationHashes.Horizontal, 0f, 0.2f, deltaTime);
			if (m_enemy.Animator.Finished(0.05f))
			{
				m_enemy.Behaviour.ChangeState(new Pursue(m_enemy, m_target));
			}
		}

		private void LookAtTarget(float deltaTime)
		{
			Vector3 forward = m_target.position - m_enemy.transform.position;
			forward.y = 0f;
			if (!(forward.sqrMagnitude < 0.01f))
			{
				Quaternion b = Quaternion.LookRotation(forward);
				m_enemy.transform.rotation = Quaternion.Slerp(m_enemy.transform.rotation, b, deltaTime * 5f);
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
