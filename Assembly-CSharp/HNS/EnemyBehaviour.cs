using UnityEngine;

namespace HNS
{
	public class EnemyBehaviour : EnemyComponent
	{
		private IState m_state;

		public EnemyState State
		{
			get
			{
				if (m_state == null)
				{
					return EnemyState.None;
				}
				return m_state.State;
			}
		}

		public void ChangeState(IState newState)
		{
			m_state?.Exit();
			m_state = newState;
			m_state?.Start();
		}

		private void Update()
		{
			m_state?.Update(Time.deltaTime);
		}

		private void FixedUpdate()
		{
			m_state?.FixedUpdate(Time.fixedDeltaTime);
		}

		private void LateUpdate()
		{
			m_state?.LateUpdate(Time.deltaTime);
		}
	}
}
