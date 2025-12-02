using System;
using UnityEngine;

namespace HNS
{
	[Serializable]
	public struct Combo
	{
		public string Name;

		public Color Color;

		public int Steps;

		[Space]
		public int Damage;

		public float Force;
	}
}
