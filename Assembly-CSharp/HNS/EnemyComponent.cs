using UnityEngine;

namespace HNS
{
	[RequireComponent(typeof(Enemy))]
	public abstract class EnemyComponent : MonoBehaviour
	{
		public Enemy Enemy;
	}
}
