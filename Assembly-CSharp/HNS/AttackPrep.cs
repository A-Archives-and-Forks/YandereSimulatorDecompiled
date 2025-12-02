using System;
using UnityEngine;

namespace HNS
{
	public class AttackPrep : IState
	{
		private Enemy m_enemy;

		private Transform m_target;

		private GameObject m_attackPrep;

		private float m_attackDistance;

		private Func<IState> m_nextState;

		private float m_minDelay;

		private float m_timer;

		private int m_rangeIndex;

		public EnemyState State => EnemyState.AttackPrep;

		public AttackPrep(Enemy enemy, Transform target, float attackDistance, int rangeIndex, Func<IState> nextState = null, float minDelay = 1f)
		{
			m_enemy = enemy;
			m_target = target;
			m_attackDistance = attackDistance;
			m_nextState = nextState ?? ((Func<IState>)(() => new Attack(m_attackDistance, m_enemy, m_target)));
			m_minDelay = minDelay;
			m_rangeIndex = rangeIndex;
		}

		public void Start()
		{
			m_enemy.Animator.Play(m_enemy.AttackPrepAnimation);
			Quaternion rotation = m_enemy.transform.rotation;
			rotation.x = 0f;
			rotation.z = 0f;
			m_attackPrep = UnityEngine.Object.Instantiate(m_enemy.RangeEffect[m_rangeIndex], m_enemy.transform.position, rotation);
			UnityEngine.Object.Instantiate(m_enemy.EyeEffect, m_enemy.EyeTarget.position, m_enemy.EyeTarget.rotation, m_enemy.EyeTarget);
			m_enemy.IsAttackLocked = true;
			m_timer = 0f;
		}

		public void Update(float deltaTime)
		{
			m_enemy.MyAnimator.SetFloat(AnimationHashes.Vertical, 0f, 0.2f, Time.deltaTime);
			m_enemy.MyAnimator.SetFloat(AnimationHashes.Horizontal, 0f, 0.2f, deltaTime);
			m_timer += deltaTime;
			if (m_timer >= m_minDelay)
			{
				m_enemy.Behaviour.ChangeState(m_nextState());
			}
			if ((bool)m_attackPrep)
			{
				Quaternion rotation = m_enemy.transform.rotation;
				rotation.x = 0f;
				rotation.z = 0f;
				m_attackPrep.transform.rotation = rotation;
			}
			LookAtTarget(deltaTime);
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
			if ((bool)m_attackPrep)
			{
				UnityEngine.Object.Destroy(m_attackPrep);
			}
		}
	}
}
