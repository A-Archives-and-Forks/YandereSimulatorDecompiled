using UnityEngine;

namespace HNS
{
	[CreateAssetMenu(fileName = "EnemyProfile", menuName = "HNS/Enemy Profile")]
	public class EnemyProfile : ScriptableObject
	{
		[Header("References")]
		public GameObject Prefab;

		[Header("Stats")]
		public EnemyType Type;

		public int Health;

		public float Speed;

		public float Damage;

		[Space]
		public string AttackPreparation;

		public string Attack;

		[Header("Animation")]
		public float animatorSpeed = 1f;

		public Vector2 animatorValueRange = new Vector2(0f, 1f);

		[Header("Movement")]
		[Range(0f, 1f)]
		public float horizontalSpeedMultiplier = 0.5f;

		[Header("Wave Scaling")]
		[Tooltip("Health increase per wave (e.g., 1 for humanoids, 10 for succubus)")]
		public int healthPerWave = 1;

		[Tooltip("Damage increase per wave (e.g., 0.5 for humanoids, 1 for succubus)")]
		public float damagePerWave = 0.5f;

		[Tooltip("Wave number to start scaling from (0 = scales from wave 1)")]
		public int startScalingFromWave;

		[Header("Succubus Movement")]
		public float maxVelocity = 10f;

		public float acceleration = 5f;

		public float deceleration = 8f;

		public float rotationSpeed = 360f;

		public float tiltAngle = 5f;

		public float tiltResetSpeed = 5f;

		[Header("Succubus Attack Distances")]
		public float rangedDistance = 8f;

		public float meleeDistance = 1f;

		[Header("Attack Collision Time Frames")]
		public Vector2 MeleeAttack;

		public float OrbSpawn = 0.25f;

		public float BeamSpawn = 0.25f;

		[Header("Succubus Beam Settings")]
		public float beamDuration = 3f;

		public float beamSweepStartAngle = -25f;

		public float beamSweepEndAngle = 25f;

		public float beamRadius = 0.5f;

		public float beamDamageInterval = 0.5f;

		[Header("Succubus Animation Names")]
		public string beamAttack = "BeamAttack";

		public string orbAttack = "OrbAttack";

		public string landing = "Landing";

		public string takeFlight = "TakeFlight";

		[Header("Succubus Damage")]
		public float beamDamage = 15f;

		public float orbDamage = 20f;

		public float meleeDamage = 25f;

		public int CalculateHealth(int waveNumber)
		{
			int num = Mathf.Max(0, waveNumber - startScalingFromWave);
			return Health + healthPerWave * num;
		}

		public float CalculateDamage(int waveNumber)
		{
			int num = Mathf.Max(0, waveNumber - startScalingFromWave);
			return Damage + damagePerWave * (float)num;
		}
	}
}
