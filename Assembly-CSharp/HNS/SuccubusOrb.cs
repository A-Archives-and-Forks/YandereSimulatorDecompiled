using UnityEngine;

namespace HNS
{
	public class SuccubusOrb : MonoBehaviour
	{
		public GameObject[] coloredParticles;

		public GameObject[] explosionPrefab;

		[Header("Settings")]
		public float speed = 15f;

		public float lifetime = 5f;

		public float hitRadius = 1f;

		private Vector3 m_direction;

		private float m_damage;

		private bool m_hasHit;

		private Enemy m_enemy;

		public void Initialize(Vector3 direction, float damage, Enemy enemy)
		{
			m_direction = direction.normalized;
			m_damage = damage;
			m_enemy = enemy;
			coloredParticles[enemy.Combo].SetActive(value: true);
			Object.Destroy(base.gameObject, lifetime);
		}

		private void Update()
		{
			if (m_hasHit)
			{
				return;
			}
			base.transform.position += m_direction * speed * Time.deltaTime;
			Collider[] array = Physics.OverlapSphere(base.transform.position, hitRadius);
			foreach (Collider collider in array)
			{
				if (collider.gameObject.layer == 13)
				{
					Player component = collider.GetComponent<Player>();
					if ((bool)component)
					{
						component.Health -= m_damage;
						m_hasHit = true;
						Object.Instantiate(explosionPrefab[m_enemy.Combo], base.transform.position, Quaternion.identity);
						Object.Destroy(base.gameObject);
						break;
					}
				}
			}
		}
	}
}
