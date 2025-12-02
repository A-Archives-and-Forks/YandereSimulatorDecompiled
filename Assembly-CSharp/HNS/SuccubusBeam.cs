using UnityEngine;

namespace HNS
{
	public class SuccubusBeam : MonoBehaviour
	{
		[Header("Prefabs")]
		[Tooltip("Prefab with LineRenderer component")]
		public GameObject[] beamLineRendererPrefab;

		[Tooltip("Prefab spawned at beam start")]
		public GameObject[] beamStartPrefab;

		[Tooltip("Prefab spawned at beam end")]
		public GameObject[] beamEndPrefab;

		[Header("Beam Settings")]
		[Tooltip("Maximum beam length")]
		public float beamLength = 100f;

		[Tooltip("Beam collision radius")]
		public float beamRadius = 0.5f;

		[Tooltip("Number of sphere checks along beam")]
		public int beamCheckPoints = 10;

		[Header("Sweep Settings")]
		[Tooltip("Starting angle offset on X axis (degrees)")]
		public float sweepStartAngle = -45f;

		[Tooltip("Ending angle offset on X axis (degrees)")]
		public float sweepEndAngle = 45f;

		[Tooltip("Time to complete sweep")]
		public float sweepDuration = 2f;

		[Header("Damage Settings")]
		[Tooltip("Damage per tick")]
		public float damagePerTick = 15f;

		[Tooltip("Time between damage ticks")]
		public float damageInterval = 0.5f;

		[Header("Debug")]
		[Tooltip("Toggle beam on/off in inspector for testing")]
		public bool isActive;

		private GameObject beam;

		private GameObject beamStart;

		private GameObject beamEnd;

		private LineRenderer line;

		private bool wasActive;

		private float sweepTimer;

		private float damageTimer;

		private int layerMask;

		private void Start()
		{
			layerMask = 8193;
			SpawnBeam();
		}

		private void SpawnBeam()
		{
			int combo = GetComponentInParent<Enemy>().Combo;
			if ((bool)beamLineRendererPrefab[combo])
			{
				beam = Object.Instantiate(beamLineRendererPrefab[combo], base.transform.position, base.transform.rotation, base.transform);
				line = beam.GetComponent<LineRenderer>();
				line.useWorldSpace = true;
				line.positionCount = 2;
				line.enabled = false;
				if ((bool)beamStartPrefab[combo])
				{
					beamStart = Object.Instantiate(beamStartPrefab[combo], beam.transform);
				}
				if ((bool)beamEndPrefab[combo])
				{
					beamEnd = Object.Instantiate(beamEndPrefab[combo], beam.transform);
				}
				UpdateBeamVisibility();
			}
		}

		public void SetActive(bool active)
		{
			isActive = active;
			if (active)
			{
				sweepTimer = 0f;
				damageTimer = 0f;
			}
			UpdateBeamVisibility();
		}

		public bool IsActive()
		{
			return isActive;
		}

		private void UpdateBeamVisibility()
		{
			if ((bool)line)
			{
				line.enabled = isActive;
			}
			if ((bool)beamStart)
			{
				beamStart.SetActive(isActive);
			}
			if ((bool)beamEnd)
			{
				beamEnd.SetActive(isActive);
			}
		}

		private void Update()
		{
			if (wasActive != isActive)
			{
				UpdateBeamVisibility();
				wasActive = isActive;
			}
			if (isActive && (bool)line)
			{
				sweepTimer += Time.deltaTime;
				float t = Mathf.Clamp01(sweepTimer / sweepDuration);
				float x = Mathf.Lerp(sweepStartAngle, sweepEndAngle, t);
				base.transform.localRotation = Quaternion.Euler(x, 0f, 0f);
				Vector3 position = base.transform.position;
				Vector3 vector = position + base.transform.forward * beamLength;
				if (Physics.SphereCast(position, beamRadius, base.transform.forward, out var hitInfo, beamLength, layerMask))
				{
					vector = hitInfo.point;
				}
				line.SetPosition(0, position);
				line.SetPosition(1, vector);
				if ((bool)beamStart)
				{
					beamStart.transform.position = position;
					beamStart.transform.LookAt(vector);
				}
				if ((bool)beamEnd)
				{
					beamEnd.transform.position = vector;
					beamEnd.transform.LookAt(position);
				}
				CheckPlayerDamage(position, vector);
			}
		}

		private void CheckPlayerDamage(Vector3 start, Vector3 end)
		{
			if (!Player.instance)
			{
				return;
			}
			damageTimer += Time.deltaTime;
			if (damageTimer < damageInterval)
			{
				return;
			}
			Vector3 normalized = (end - start).normalized;
			float num = Vector3.Distance(start, end);
			for (int i = 0; i < beamCheckPoints; i++)
			{
				float num2 = (float)i / (float)(beamCheckPoints - 1);
				Collider[] array = Physics.OverlapSphere(start + normalized * (num * num2), beamRadius, 8192);
				for (int j = 0; j < array.Length; j++)
				{
					if (array[j].gameObject.layer == 13)
					{
						Player.instance.Health -= damagePerTick;
						damageTimer = 0f;
						return;
					}
				}
			}
		}
	}
}
