using System.Collections;
using UnityEngine;

namespace HNS
{
	public class HitStop : MonoBehaviour
	{
		public static HitStop instance;

		[SerializeField]
		private bool disabled;

		[SerializeField]
		private float multiplier = 1f;

		[SerializeField]
		private bool active;

		private void OnEnable()
		{
			instance = this;
			active = false;
		}

		private void OnDisable()
		{
			instance = null;
		}

		public static void Init(float intensity, float duration)
		{
			instance?.StartCoroutine(instance?.Perform(intensity, duration));
		}

		private IEnumerator Perform(float intensity, float duration)
		{
			if (!disabled && !active)
			{
				active = true;
				float defaultScale = 1f;
				Time.timeScale = Mathf.Clamp(1f - intensity * multiplier, 0f, 1f);
				float timer = 0f;
				while (timer < duration / 3f)
				{
					timer += Time.unscaledDeltaTime;
					yield return null;
				}
				Time.timeScale = defaultScale;
				active = false;
				yield return null;
			}
		}
	}
}
