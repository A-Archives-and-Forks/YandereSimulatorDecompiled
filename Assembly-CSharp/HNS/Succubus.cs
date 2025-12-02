using UnityEngine;

namespace HNS
{
	public class Succubus : EnemyComponent
	{
		[Header("References")]
		public Transform ProjectileSpawn;

		public SuccubusBeam BeamController;

		public GameObject OrbPrefab;

		[HideInInspector]
		public Vector3 currentVelocity;

		[HideInInspector]
		public int attackCycle;

		[HideInInspector]
		public bool isBeamAttack;

		private EnemyProfile profile;

		public Transform PelvisRoot;

		[Space]
		public AnimationCurve HeightCurve;

		public float Height;

		public float HeightRiseSpeed = 2f;

		public float m_heightBlend;

		private void Start()
		{
			profile = Enemy.Profile;
			ConfigureBeam();
		}

		private void ConfigureBeam()
		{
			if ((bool)BeamController)
			{
				BeamController.sweepStartAngle = profile.beamSweepStartAngle;
				BeamController.sweepEndAngle = profile.beamSweepEndAngle;
				BeamController.sweepDuration = profile.beamDuration;
				BeamController.beamRadius = profile.beamRadius;
				BeamController.damagePerTick = profile.beamDamage;
				BeamController.damageInterval = profile.beamDamageInterval;
			}
		}

		private void Update()
		{
			if (Enemy.Behaviour.State != EnemyState.FlyToPosition)
			{
				Vector3 eulerAngles = Enemy.transform.eulerAngles;
				float x = Mathf.MoveTowardsAngle(eulerAngles.x, 0f, profile.tiltResetSpeed * Time.deltaTime);
				float z = Mathf.MoveTowardsAngle(eulerAngles.z, 0f, profile.tiltResetSpeed * Time.deltaTime);
				Enemy.transform.rotation = Quaternion.Euler(x, eulerAngles.y, z);
			}
		}

		public void FireBeam()
		{
			if ((bool)BeamController)
			{
				BeamController.SetActive(active: true);
			}
		}

		public void StopBeam()
		{
			if ((bool)BeamController)
			{
				BeamController.SetActive(active: false);
			}
		}

		public void FireOrb()
		{
			if ((bool)OrbPrefab && (bool)ProjectileSpawn)
			{
				SuccubusOrb component = Object.Instantiate(OrbPrefab, ProjectileSpawn.position, Enemy.transform.rotation).GetComponent<SuccubusOrb>();
				if ((bool)component)
				{
					component.Initialize(Enemy.transform.forward, profile.orbDamage, Enemy);
				}
			}
		}

		private void LateUpdate()
		{
			bool flag = Enemy.Behaviour.State == EnemyState.FlyToPosition || Enemy.Behaviour.State == EnemyState.TakeFlight;
			m_heightBlend = Mathf.MoveTowards(m_heightBlend, flag ? 1f : 0f, Time.deltaTime * HeightRiseSpeed);
			PelvisRoot.localPosition = new Vector3(0f, HeightCurve.Evaluate(m_heightBlend) * Height, 0f);
		}
	}
}
