using UnityEngine;

namespace HNS
{
	public class Pursue : IState
	{
		private Enemy m_enemy;

		private Transform m_target;

		private int direction;

		private Vector3 velocity;

		public EnemyState State => EnemyState.Approach;

		public Pursue(Enemy enemy, Transform target)
		{
			m_enemy = enemy;
			m_target = target;
			direction = ((!(Random.value < 0.5f)) ? 1 : (-1));
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
			if (Player.instance.Stance == PlayerStance.Ultimate)
			{
				HandleUltimateStance(deltaTime);
			}
			else if ((bool)EnemyCoordinator.Instance)
			{
				bool flag = (bool)EnemyCoordinator.Instance && EnemyCoordinator.Instance.IsAttacker(m_enemy);
				float targetDistance = (flag ? EnemyCoordinator.Instance.attackDistance : EnemyCoordinator.Instance.waitDistance);
				float num = Vector3.Distance(m_enemy.transform.position, m_target.position);
				if (flag && num <= EnemyCoordinator.Instance.attackDistance)
				{
					EnemyCoordinator.Instance.RequestAttackPrep(m_enemy);
				}
				else if (flag)
				{
					MoveTowardsPlayer(deltaTime, targetDistance, num);
				}
				else
				{
					CirclePlayer(deltaTime, targetDistance, num);
				}
			}
		}

		private void MoveTowardsPlayer(float deltaTime, float targetDistance, float currentDistance)
		{
			LookAtTarget(deltaTime);
			Vector3 b = ((currentDistance > targetDistance) ? (m_enemy.transform.forward * m_enemy.Profile.Speed) : Vector3.zero);
			Vector3 vector = CalculateAvoidance();
			if (vector.magnitude > 0.01f)
			{
				b += vector * m_enemy.Profile.Speed;
			}
			velocity = Vector3.Lerp(velocity, b, deltaTime * 5f);
			m_enemy.MyController.Move(ApplyHorizontalMultiplier(velocity) * deltaTime);
			UpdateAnimator(velocity);
		}

		private void CirclePlayer(float deltaTime, float targetDistance, float currentDistance)
		{
			LookAtTarget(deltaTime);
			Vector3 vector = m_target.position - m_enemy.transform.position;
			vector.y = 0f;
			if (!(vector.sqrMagnitude < 0.01f))
			{
				float num = Mathf.Clamp((currentDistance - targetDistance) * EnemyCoordinator.Instance.circleRadiusStrength, 0f - m_enemy.Profile.Speed, m_enemy.Profile.Speed);
				Vector3 vector2 = Vector3.Cross(Vector3.up, vector.normalized) * direction * EnemyCoordinator.Instance.circleDirection;
				Vector3 normalized = vector.normalized;
				Vector3 b = vector2 * m_enemy.Profile.Speed * EnemyCoordinator.Instance.circleSpeed + normalized * num;
				Vector3 vector3 = CalculateAvoidance();
				if (vector3.magnitude > 0.01f)
				{
					b += vector3 * EnemyCoordinator.Instance.circleAvoidanceStrength;
				}
				b.y = 0f;
				velocity = Vector3.Lerp(velocity, b, deltaTime * 5f);
				m_enemy.MyController.Move(ApplyHorizontalMultiplier(velocity) * deltaTime);
				UpdateAnimator(velocity);
			}
		}

		private void HandleUltimateStance(float deltaTime)
		{
			LookAtTarget(deltaTime);
			float num = Vector3.Distance(m_enemy.transform.position, m_target.position);
			Vector3 b = ((num < 5f) ? (-m_enemy.transform.forward * m_enemy.Profile.Speed) : Vector3.zero);
			if (num < 5f)
			{
				Vector3 vector = CalculateAvoidance();
				if (vector.magnitude > 0.01f)
				{
					b += vector * m_enemy.Profile.Speed;
				}
			}
			velocity = Vector3.Lerp(velocity, b, deltaTime * 5f);
			m_enemy.MyController.Move(ApplyHorizontalMultiplier(velocity) * deltaTime);
			UpdateAnimator(velocity);
		}

		private Vector3 ApplyHorizontalMultiplier(Vector3 vel)
		{
			Vector3 vector = m_enemy.transform.InverseTransformDirection(vel);
			vector.x *= m_enemy.Profile.horizontalSpeedMultiplier;
			return m_enemy.transform.TransformDirection(vector);
		}

		private void UpdateAnimator(Vector3 currentVelocity)
		{
			Vector3 vector = m_enemy.transform.InverseTransformDirection(currentVelocity);
			Vector2 vector2 = new Vector2(vector.x, vector.z);
			if (vector2.magnitude > m_enemy.Profile.Speed)
			{
				vector2 = vector2.normalized * m_enemy.Profile.Speed;
			}
			float t = Mathf.Clamp01(vector2.magnitude / m_enemy.Profile.Speed);
			float num = Mathf.Lerp(m_enemy.Profile.animatorValueRange.x, m_enemy.Profile.animatorValueRange.y, t);
			Vector2 obj = ((vector2.magnitude > 0.01f) ? vector2.normalized : Vector2.zero);
			float value = obj.y * num;
			float value2 = obj.x * num;
			m_enemy.MyAnimator.SetFloat(AnimationHashes.Vertical, value, 0.05f, Time.deltaTime);
			m_enemy.MyAnimator.SetFloat(AnimationHashes.Horizontal, value2, 0.05f, Time.deltaTime);
		}

		private Vector3 CalculateAvoidance()
		{
			float num = 1.5f;
			Collider[] array = Physics.OverlapSphere(m_enemy.transform.position, num, 512);
			Vector3 zero = Vector3.zero;
			Collider[] array2 = array;
			foreach (Collider collider in array2)
			{
				if (!(collider.gameObject == m_enemy.gameObject) && !collider.GetComponent<Player>() && (bool)collider.GetComponent<Enemy>())
				{
					Vector3 vector = m_enemy.transform.position - collider.transform.position;
					vector.y = 0f;
					float magnitude = vector.magnitude;
					if (magnitude < num && magnitude > 0.01f)
					{
						float num2 = 1f - magnitude / num;
						zero += vector.normalized * num2;
					}
				}
			}
			return zero;
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
