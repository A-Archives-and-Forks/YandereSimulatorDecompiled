using UnityEngine;

namespace HNS
{
	public class RangedAttack : IState
	{
		private Enemy m_enemy;

		private Succubus m_succubus;

		private Transform m_target;

		private bool m_attackExecuted;

		public EnemyState State => EnemyState.Attack;

		public RangedAttack(Enemy enemy, Succubus succubus, Transform target)
		{
			m_enemy = enemy;
			m_succubus = succubus;
			m_target = target;
		}

		public void Start()
		{
			m_attackExecuted = false;
			if (m_succubus.attackCycle == 0)
			{
				int state = Animator.StringToHash(m_enemy.Profile.orbAttack);
				m_enemy.Animator.Play(state);
				m_succubus.isBeamAttack = false;
			}
			else
			{
				int state2 = Animator.StringToHash(m_enemy.Profile.beamAttack);
				m_enemy.Animator.Play(state2);
				m_succubus.isBeamAttack = true;
			}
			m_succubus.attackCycle = (m_succubus.attackCycle + 1) % 4;
		}

		public void Update(float deltaTime)
		{
			m_enemy.MyAnimator.SetFloat(AnimationHashes.Vertical, 0f, 0.2f, deltaTime);
			m_enemy.MyAnimator.SetFloat(AnimationHashes.Horizontal, 0f, 0.2f, deltaTime);
			float num = (m_succubus.isBeamAttack ? m_enemy.Profile.BeamSpawn : m_enemy.Profile.OrbSpawn);
			if (!m_attackExecuted && m_enemy.Animator.NormalizedTime() >= num)
			{
				if (m_succubus.isBeamAttack)
				{
					m_succubus.FireBeam();
				}
				else
				{
					m_succubus.FireOrb();
				}
				m_attackExecuted = true;
			}
			if (m_enemy.Animator.Finished(0.05f))
			{
				m_succubus.StopBeam();
				m_enemy.IsAttackLocked = false;
				m_enemy.Behaviour.ChangeState(new TakeFlight(m_enemy, m_succubus, m_target, m_enemy.Profile.rangedDistance));
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
			m_succubus.StopBeam();
		}
	}
}
