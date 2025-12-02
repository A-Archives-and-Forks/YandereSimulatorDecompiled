using UnityEngine;

namespace HNS
{
	public struct AudioConfiguration
	{
		public AudioType Type;

		[Range(0f, 1f)]
		public float Volume;
	}
}
