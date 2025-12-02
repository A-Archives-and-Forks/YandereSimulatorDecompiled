using UnityEngine;

namespace HNS
{
	public class AxisProcessor
	{
		public float DeadZone { get; set; }

		public bool Normalize { get; set; }

		public AxisProcessor(float deadZone, bool normalize = true)
		{
			DeadZone = deadZone;
			Normalize = normalize;
		}

		public Vector2 Process(Vector2 raw)
		{
			if (raw.sqrMagnitude < DeadZone * DeadZone)
			{
				return Vector2.zero;
			}
			if (!Normalize || !(raw.sqrMagnitude > 1f))
			{
				return raw;
			}
			return raw.normalized;
		}
	}
}
