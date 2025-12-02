using UnityEngine;

namespace HNS
{
	[RequireComponent(typeof(UIPanel))]
	public class FadeManager : MonoBehaviour
	{
		public static FadeManager instance;

		[Header("Settings")]
		[Range(0f, 1f)]
		public float MaxAlpha = 1f;

		public float FadeInSpeed = 1f;

		public float FadeOutSpeed = 1f;

		public bool FadeInOnStart;

		private UIPanel panel;

		private float targetAlpha;

		private bool isFading;

		public bool IsFading => isFading;

		public bool IsFadingOut
		{
			get
			{
				if (isFading)
				{
					return targetAlpha <= panel.alpha;
				}
				return false;
			}
		}

		public bool IsFadingIn
		{
			get
			{
				if (isFading)
				{
					return targetAlpha > panel.alpha;
				}
				return false;
			}
		}

		private void OnEnable()
		{
			instance = this;
			if (!panel)
			{
				panel = GetComponent<UIPanel>();
			}
			if (FadeInOnStart)
			{
				panel.alpha = MaxAlpha;
				targetAlpha = 0f;
				isFading = true;
			}
			else
			{
				panel.alpha = 0f;
				targetAlpha = 0f;
			}
		}

		private void Update()
		{
			if (isFading)
			{
				float num = ((targetAlpha > panel.alpha) ? FadeInSpeed : FadeOutSpeed);
				panel.alpha = Mathf.MoveTowards(panel.alpha, targetAlpha, Time.unscaledDeltaTime * num);
				if (Mathf.Approximately(panel.alpha, targetAlpha))
				{
					isFading = false;
				}
			}
		}

		public void FadeIn()
		{
			targetAlpha = MaxAlpha;
			isFading = true;
		}

		public void FadeOut()
		{
			targetAlpha = 0f;
			isFading = true;
		}

		public void SetAlpha(float alpha)
		{
			MaxAlpha = Mathf.Clamp01(alpha);
			if (!isFading)
			{
				panel.alpha = MaxAlpha;
			}
		}

		public void SetAlphaImmediate(float alpha)
		{
			MaxAlpha = Mathf.Clamp01(alpha);
			panel.alpha = MaxAlpha;
			targetAlpha = MaxAlpha;
			isFading = false;
		}
	}
}
