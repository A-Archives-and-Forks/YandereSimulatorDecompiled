using System.Collections.Generic;
using UnityEngine;

namespace HNS
{
	public static class AnimationHashes
	{
		public static readonly int Horizontal = Animator.StringToHash("Horizontal");

		public static readonly int Vertical = Animator.StringToHash("Vertical");

		public static readonly int Movement = Animator.StringToHash("Movement");

		public static readonly int Dodge = Animator.StringToHash("Dodge");

		public static readonly int Die = Animator.StringToHash("Die");

		public static readonly int Damage = Animator.StringToHash("Hit");

		public static readonly int Ultimate = Animator.StringToHash("Ultimate");

		public static readonly List<List<int>> Combo = new List<List<int>>();

		public static readonly int Equip = Animator.StringToHash("Equip");
	}
}
