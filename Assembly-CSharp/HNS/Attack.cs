using System;
using UnityEngine;

namespace HNS
{
	public class Attack : IState
	{
		private Enemy m_enemy;

		private Transform m_target;

		private float m_minDistance;

		private float m_damage;

		private bool hasDamaged;

		private Func<IState> m_nextState;

		public EnemyState State => EnemyState.Attack;

		public Attack(float minDistance, Enemy enemy, Transform target, float? customDamage = null, Func<IState> nextState = null)
		{
			m_minDistance = minDistance;
			m_enemy = enemy;
			m_target = target;
			m_damage = customDamage ?? enemy.DamageAmount;
			m_nextState = nextState ?? ((Func<IState>)(() => new Pursue(m_enemy, m_target)));
		}

		public void Start()
		{
			m_enemy.Animator.Play(m_enemy.AttackAnimation);
		}

		public void Update(float deltaTime)
		{
			float distance = Vector3.Distance(m_enemy.transform.position, m_target.position);
			m_enemy.MyAnimator.SetFloat(AnimationHashes.Vertical, 0f, 0.2f, deltaTime);
			if (m_enemy.Animator.Finished(0.05f))
			{
				m_enemy.IsAttackLocked = false;
				if (m_enemy.Health <= 0)
				{
					m_enemy.Behaviour.ChangeState(new Die(m_enemy));
				}
				else
				{
					m_enemy.Behaviour.ChangeState(m_nextState());
				}
			}
			else
			{
				UpdateAttack(distance);
			}
		}

		private void UpdateAttack(float distance)
		{
			if (!(distance < m_minDistance + 0.5f))
			{
				return;
			}
			Vector3 normalized = (m_target.position - m_enemy.transform.position).normalized;
			if (!(Vector3.Dot(m_enemy.transform.forward, normalized) < 0f) && m_enemy.MyAnimator.InHitFrame(m_enemy.Profile.MeleeAttack.x, m_enemy.Profile.MeleeAttack.y) && !hasDamaged)
			{
				Player.instance.Health -= m_damage;
				Rumble.Instance.Play(0.3f, 0.3f, 0.15f, m_enemy.transform.position);
				Player.instance.HealthPause = 1f;
				if ((bool)HitStopManager.Instance)
				{
					HitStopManager.Instance.TriggerHitStop(m_enemy.MyAnimator, Player.instance.MyAnimator, m_enemy.transform, Player.instance.transform);
				}
				hasDamaged = true;
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
			Succubus component = m_enemy.GetComponent<Succubus>();
			if ((bool)component)
			{
				component.attackCycle = (component.attackCycle + 1) % 4;
			}
		}
	}
}
