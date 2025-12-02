using System.Collections.Generic;
using UnityEngine;

namespace HNS
{
	public class Weapon : MonoBehaviour
	{
		public static Weapon Instance;

		public Transform[] Segments;

		public MeshRenderer[] CollisionSegments;

		public Material DebugMat;

		public SkinnedMeshRenderer MyRenderer;

		private bool doUpdate = true;

		private void OnEnable()
		{
			Instance = this;
			doUpdate = true;
			List<MeshRenderer> list = new List<MeshRenderer>();
			for (int i = 0; i < Segments.Length; i++)
			{
				GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				obj.GetComponent<SphereCollider>().enabled = false;
				MeshRenderer component = obj.GetComponent<MeshRenderer>();
				component.sharedMaterial = DebugMat;
				obj.transform.parent = Segments[i];
				obj.transform.localPosition = Vector3.zero;
				obj.transform.localRotation = Quaternion.identity;
				list.Add(component);
			}
			CollisionSegments = list.ToArray();
		}

		private void OnDisable()
		{
			Instance = null;
			for (int i = 0; i < CollisionSegments.Length; i++)
			{
				if ((bool)CollisionSegments[i])
				{
					Object.Destroy(CollisionSegments[i].gameObject);
				}
			}
			CollisionSegments = null;
		}

		private void Update()
		{
			if (Player.instance == null)
			{
				return;
			}
			UpdateColor(Player.instance.Profile.Combos[Player.instance.Combo].Color);
			if (DebugMenu.instance.showCollisionRadius)
			{
				MeshRenderer[] collisionSegments = CollisionSegments;
				foreach (MeshRenderer obj in collisionSegments)
				{
					obj.enabled = true;
					obj.gameObject.transform.localScale = Vector3.one * Player.instance.Profile.CollisionRadius * 2f;
				}
			}
			else if (!DebugMenu.instance.showCollisionRadius && CollisionSegments[0].enabled)
			{
				MeshRenderer[] collisionSegments = CollisionSegments;
				for (int i = 0; i < collisionSegments.Length; i++)
				{
					collisionSegments[i].enabled = false;
				}
			}
		}

		public List<HitInfo> UpdateHit()
		{
			List<HitInfo> list = new List<HitInfo>();
			List<Enemy> list2 = new List<Enemy>();
			Transform[] segments = Segments;
			foreach (Transform transform in segments)
			{
				Collider[] array = Physics.OverlapSphere(transform.position, Player.instance.Profile.CollisionRadius);
				foreach (Collider collider in array)
				{
					if (collider.gameObject.layer == 9)
					{
						Enemy enemy = null;
						Vector3 hitPosition = transform.position;
						EnemyBodyPart component = collider.GetComponent<EnemyBodyPart>();
						if ((bool)component && (bool)component.Enemy)
						{
							enemy = component.Enemy;
							hitPosition = collider.ClosestPoint(transform.position);
						}
						if ((bool)enemy && !list2.Contains(enemy) && enemy.Behaviour.State != EnemyState.Die)
						{
							list.Add(new HitInfo
							{
								enemy = enemy,
								hitPosition = hitPosition,
								valid = (enemy.Combo == Player.instance.Combo)
							});
							list2.Add(enemy);
						}
					}
				}
			}
			return list;
		}

		public static void UpdateColor(Color color)
		{
			Color color2 = Instance.MyRenderer.materials[1].GetColor("_EmissionColor");
			Instance.MyRenderer.materials[1].SetColor("_EmissionColor", Color.Lerp(color2, color, Time.deltaTime * 20f));
			Instance.MyRenderer.materials[1].color = Color.Lerp(color2, color, Time.deltaTime * 20f);
		}
	}
}
