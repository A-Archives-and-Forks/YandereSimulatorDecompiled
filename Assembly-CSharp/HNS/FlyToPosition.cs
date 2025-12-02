using UnityEngine;

namespace HNS
{
	public class FlyToPosition : IState
	{
		private Enemy m_enemy;

		private Succubus m_succubus;

		private Transform m_target;

		private Vector3 m_destination;

		private bool m_isMelee;

		private EnemyProfile profile;

		public EnemyState State => EnemyState.FlyToPosition;

		public FlyToPosition(Enemy enemy, Succubus succubus, Transform target, float targetDistance)
		{
			m_enemy = enemy;
			m_succubus = succubus;
			m_target = target;
			profile = enemy.Profile;
			m_isMelee = m_succubus.attackCycle == 1 || m_succubus.attackCycle == 3;
			if (!m_isMelee)
			{
				PickRandomDestination();
			}
		}

		private void PickRandomDestination()
		{
			Vector2 vector = Random.insideUnitCircle.normalized * profile.rangedDistance;
			m_destination = m_target.position + new Vector3(vector.x, 0f, vector.y);
		}

		public void Start()
		{
			m_enemy.Animator.Play(AnimationHashes.Movement);
		}

		public void Update(float deltaTime)
		{
			if (!m_target || !m_enemy)
			{
				return;
			}
			Vector3 vector;
			float num;
			if (m_isMelee)
			{
				vector = m_target.position;
				vector.y = 0f;
				num = profile.meleeDistance;
			}
			else
			{
				vector = m_destination;
				vector.y = 0f;
				num = 2f;
			}
			Vector3 position = m_enemy.transform.position;
			position.y = 0f;
			float num2 = Vector3.Distance(position, vector);
			if (m_isMelee && num2 <= profile.meleeDistance)
			{
				m_succubus.currentVelocity = Vector3.zero;
				m_enemy.Behaviour.ChangeState(new Landing(m_enemy, m_succubus, profile.meleeDistance));
				return;
			}
			if (!m_isMelee && num2 < num)
			{
				m_succubus.currentVelocity = Vector3.zero;
				m_enemy.Behaviour.ChangeState(new Landing(m_enemy, m_succubus, profile.rangedDistance));
				return;
			}
			Vector3 normalized = (vector - position).normalized;
			float magnitude = m_succubus.currentVelocity.magnitude;
			float num3 = profile.maxVelocity;
			if (num2 < 3f)
			{
				num3 *= num2 / 3f;
			}
			magnitude = ((!(magnitude < num3)) ? (magnitude - profile.deceleration * deltaTime) : (magnitude + profile.acceleration * deltaTime));
			magnitude = Mathf.Max(0f, magnitude);
			m_succubus.currentVelocity = normalized * magnitude;
			m_enemy.MyController.Move(m_succubus.currentVelocity * deltaTime);
			float value = magnitude / profile.maxVelocity;
			m_enemy.MyAnimator.SetFloat(AnimationHashes.Vertical, value, 0.2f, deltaTime);
			ApplyRotationAndTilt(deltaTime);
		}

		private void ApplyRotationAndTilt(float deltaTime)
		{
			Vector3 forward = m_target.position - m_enemy.transform.position;
			forward.y = 0f;
			if (forward.sqrMagnitude > 0.01f)
			{
				float y = Quaternion.LookRotation(forward).eulerAngles.y;
				float y2 = Mathf.LerpAngle(m_enemy.transform.eulerAngles.y, y, deltaTime * 5f);
				Vector3 vector = m_enemy.transform.InverseTransformDirection(m_succubus.currentVelocity);
				float x = (0f - vector.z) * profile.tiltAngle * 0.1f;
				float z = (0f - vector.x) * profile.tiltAngle * 0.1f;
				m_enemy.transform.rotation = Quaternion.Euler(x, y2, z);
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
			m_succubus.currentVelocity = Vector3.zero;
		}
	}
}
