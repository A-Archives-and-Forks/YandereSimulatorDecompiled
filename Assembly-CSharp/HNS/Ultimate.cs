using UnityEngine;

namespace HNS
{
	public class Ultimate : IState
	{
		private Enemy m_enemy;

		private Transform m_target;

		private float m_minDistance;

		public EnemyState State => EnemyState.Ultimate;

		public Ultimate(float minDistance, Enemy enemy, Transform target)
		{
			m_minDistance = minDistance;
			m_enemy = enemy;
			m_target = target;
		}

		public void Start()
		{
			m_enemy.transform.localScale = Vector3.one;
		}

		public void Update(float deltaTime)
		{
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
