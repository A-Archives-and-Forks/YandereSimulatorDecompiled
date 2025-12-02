using UnityEngine;

namespace HNS
{
	public class Landing : IState
	{
		private Enemy m_enemy;

		private Succubus m_succubus;

		private float m_targetDistance;

		public EnemyState State => EnemyState.Landing;

		public Landing(Enemy enemy, Succubus succubus, float targetDistance)
		{
			m_enemy = enemy;
			m_succubus = succubus;
			m_targetDistance = targetDistance;
		}

		public void Start()
		{
			int state = Animator.StringToHash(m_enemy.Profile.landing);
			m_enemy.Animator.Play(state);
		}

		public void Update(float deltaTime)
		{
			m_enemy.MyAnimator.SetFloat(AnimationHashes.Vertical, 0f, 0.2f, deltaTime);
			m_enemy.MyAnimator.SetFloat(AnimationHashes.Horizontal, 0f, 0.2f, deltaTime);
			if (!m_enemy.Animator.Finished(0.05f))
			{
				return;
			}
			if (m_targetDistance >= m_enemy.Profile.rangedDistance)
			{
				m_enemy.Behaviour.ChangeState(new AttackPrep(m_enemy, Player.instance.transform, m_enemy.Profile.rangedDistance, 1, () => new RangedAttack(m_enemy, m_succubus, Player.instance.transform)));
				return;
			}
			m_enemy.Behaviour.ChangeState(new AttackPrep(m_enemy, Player.instance.transform, m_enemy.Profile.meleeDistance, 0, () => new Attack(m_enemy.Profile.meleeDistance, m_enemy, Player.instance.transform, m_enemy.Profile.meleeDamage, () => new TakeFlight(m_enemy, m_succubus, Player.instance.transform, m_enemy.Profile.rangedDistance))));
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
