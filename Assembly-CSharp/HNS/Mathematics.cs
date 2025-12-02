using UnityEngine;

namespace HNS
{
	public static class Mathematics
	{
		public static float Remap(float inMin, float inMax, float outMin, float outMax, float value)
		{
			return (value - inMin) / (inMax - inMin) * (outMax - outMin) + outMin;
		}

		public static Vector2 Remap(Vector2 inMin, Vector2 inMax, Vector2 outMin, Vector2 outMax, Vector2 value)
		{
			return new Vector2(Remap(inMin.x, inMax.x, outMin.x, outMax.x, value.x), Remap(inMin.y, inMax.y, outMin.y, outMax.y, value.y));
		}

		public static Vector3 Remap(Vector3 inMin, Vector3 inMax, Vector3 outMin, Vector3 outMax, Vector3 value)
		{
			return new Vector3(Remap(inMin.x, inMax.x, outMin.x, outMax.x, value.x), Remap(inMin.y, inMax.y, outMin.y, outMax.y, value.y), Remap(inMin.z, inMax.z, outMin.z, outMax.z, value.z));
		}

		public static Vector4 Remap(Vector4 inMin, Vector4 inMax, Vector4 outMin, Vector4 outMax, Vector4 value)
		{
			return new Vector4(Remap(inMin.x, inMax.x, outMin.x, outMax.x, value.x), Remap(inMin.y, inMax.y, outMin.y, outMax.y, value.y), Remap(inMin.z, inMax.z, outMin.z, outMax.z, value.z), Remap(inMin.w, inMax.w, outMin.w, outMax.w, value.w));
		}

		public static Color Remap(Color inMin, Color inMax, Color outMin, Color outMax, Color value)
		{
			return new Color(Remap(inMin.r, inMax.r, outMin.r, outMax.r, value.r), Remap(inMin.g, inMax.g, outMin.g, outMax.g, value.g), Remap(inMin.b, inMax.b, outMin.b, outMax.b, value.b), Remap(inMin.a, inMax.a, outMin.a, outMax.a, value.a));
		}

		public static int Wrap(int min, int max, int value)
		{
			int num = max - min;
			if (num <= 0)
			{
				return min;
			}
			return value - num * (int)Mathf.Floor((value - min) / num);
		}

		public static float Wrap(float min, float max, float value)
		{
			float num = max - min;
			if (num <= 0f)
			{
				return min;
			}
			return value - num * Mathf.Floor((value - min) / num);
		}

		public static Vector2 Wrap(Vector2 min, Vector2 max, Vector2 value)
		{
			return new Vector2(Wrap(min.x, max.x, value.x), Wrap(min.y, max.y, value.y));
		}

		public static Vector3 Wrap(Vector3 min, Vector3 max, Vector3 value)
		{
			return new Vector3(Wrap(min.x, max.x, value.x), Wrap(min.y, max.y, value.y), Wrap(min.z, max.z, value.z));
		}

		public static Vector4 Wrap(Vector4 min, Vector4 max, Vector4 value)
		{
			return new Vector4(Wrap(min.x, max.x, value.x), Wrap(min.y, max.y, value.y), Wrap(min.z, max.z, value.z), Wrap(min.w, max.w, value.w));
		}

		public static Color Wrap(Color min, Color max, Color value)
		{
			return new Color(Wrap(min.r, max.r, value.r), Wrap(min.g, max.g, value.g), Wrap(min.b, max.b, value.b), Wrap(min.a, max.a, value.a));
		}

		public static Vector3 XZ(Vector2 input)
		{
			return new Vector3(input.x, 0f, input.y);
		}

		public static Vector3 XY(Vector2 input)
		{
			return new Vector3(input.x, input.y, 0f);
		}

		public static Vector3 YZ(Vector2 input)
		{
			return new Vector3(0f, input.x, input.y);
		}

		public static Vector3 ZY(Vector2 input)
		{
			return new Vector3(0f, input.y, input.x);
		}

		public static Vector3 ZX(Vector2 input)
		{
			return new Vector3(input.y, 0f, input.x);
		}

		public static Vector3 YX(Vector2 input)
		{
			return new Vector3(input.y, input.x, 0f);
		}

		public static Vector2 XZ(Vector3 input)
		{
			return new Vector2(input.x, input.z);
		}

		public static Vector2 XY(Vector3 input)
		{
			return new Vector2(input.x, input.y);
		}

		public static Vector2 YZ(Vector3 input)
		{
			return new Vector2(input.y, input.z);
		}

		public static Vector2 ZY(Vector3 input)
		{
			return new Vector2(input.z, input.y);
		}

		public static Vector2 ZX(Vector3 input)
		{
			return new Vector2(input.z, input.x);
		}

		public static Vector2 YX(Vector3 input)
		{
			return new Vector2(input.y, input.x);
		}
	}
}
