using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HNS
{
	public class EnemyCoordinator : MonoBehaviour
	{
		public static EnemyCoordinator Instance;

		[Header("Attack Settings")]
		[Tooltip("Maximum regular attackers (provoked enemies are additional)")]
		public int maxAttackers = 3;

		[Tooltip("Distance for attack approach")]
		public float attackDistance = 1.25f;

		[Tooltip("Minimum delay before attack after prep animation")]
		public float prepDelay = 1f;

		[Header("Wait Circle Settings")]
		[Tooltip("Radius of the waiting circle")]
		public float waitDistance = 5f;

		[Tooltip("Speed multiplier for circle movement")]
		[Range(0f, 2f)]
		public float circleSpeed = 0.5f;

		[Tooltip("Strength of radius correction")]
		[Range(0f, 5f)]
		public float circleRadiusStrength = 2f;

		[Tooltip("Strength of avoidance between enemies")]
		[Range(0f, 10f)]
		public float circleAvoidanceStrength = 3f;

		[Tooltip("Circle direction: 1 = clockwise, -1 = counter-clockwise")]
		public float circleDirection = 1f;

		private List<Enemy> allEnemies = new List<Enemy>();

		private List<Enemy> regularAttackers = new List<Enemy>();

		private void OnEnable()
		{
			Instance = this;
		}

		private void OnDisable()
		{
			Instance = null;
		}

		public void RegisterEnemy(Enemy enemy)
		{
			if (!allEnemies.Contains(enemy))
			{
				allEnemies.Add(enemy);
				EvaluateAttackerAssignment();
			}
		}

		public void OnEnemyDamaged(Enemy enemy)
		{
			if (!enemy.IsProvoked && !regularAttackers.Contains(enemy))
			{
				enemy.IsProvoked = true;
			}
		}

		public void OnEnemyDied(Enemy enemy)
		{
			allEnemies.Remove(enemy);
			regularAttackers.Remove(enemy);
			EvaluateAttackerAssignment();
		}

		public bool IsAttacker(Enemy enemy)
		{
			if (!regularAttackers.Contains(enemy))
			{
				return enemy.IsProvoked;
			}
			return true;
		}

		public void RequestAttackPrep(Enemy enemy)
		{
			if (IsAttacker(enemy))
			{
				enemy.Behaviour.ChangeState(new AttackPrep(enemy, Player.instance.transform, attackDistance, 0, null, prepDelay));
			}
		}

		private void EvaluateAttackerAssignment()
		{
			allEnemies.RemoveAll((Enemy e) => !e || e.Behaviour.State == EnemyState.Die);
			regularAttackers.RemoveAll((Enemy e) => !e || e.Behaviour.State == EnemyState.Die);
			int count = regularAttackers.Count;
			int num = maxAttackers - count;
			if (num > 0)
			{
				List<Enemy> source = allEnemies.Where((Enemy e) => !regularAttackers.Contains(e) && !e.IsProvoked && e.Behaviour.State != EnemyState.Die).ToList();
				source = source.OrderBy((Enemy e) => Vector3.Distance(e.transform.position, Player.instance.transform.position)).ToList();
				for (int num2 = 0; num2 < num && num2 < source.Count; num2++)
				{
					PromoteToAttacker(source[num2]);
				}
			}
		}

		private void PromoteToAttacker(Enemy enemy)
		{
			if (!regularAttackers.Contains(enemy))
			{
				regularAttackers.Add(enemy);
			}
		}

		private void Update()
		{
			if (Time.frameCount % 30 == 0)
			{
				EvaluateAttackerAssignment();
			}
		}
	}
}
