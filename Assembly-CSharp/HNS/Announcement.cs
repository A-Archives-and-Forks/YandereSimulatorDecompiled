using System.Collections;
using UnityEngine;

namespace HNS
{
	public class Announcement : MonoBehaviour
	{
		public static Announcement instance;

		[Header("References")]
		[SerializeField]
		private AudioSource Source;

		[SerializeField]
		private UIPanel Panel;

		[SerializeField]
		private UILabel Label;

		[Header("Settings")]
		[SerializeField]
		private float FadeDuration = 0.5f;

		[SerializeField]
		private float VisibilityDuration = 3f;

		private bool m_active;

		public static bool Active
		{
			get
			{
				if (instance != null)
				{
					return instance.m_active;
				}
				return false;
			}
		}

		private void OnEnable()
		{
			instance = this;
			Label.text = string.Empty;
			Panel.alpha = 0f;
		}

		private void OnDisable()
		{
			instance = null;
		}

		private void showAnnouncement(string text)
		{
			if (!m_active)
			{
				StartCoroutine(ShowAnnouncement(text));
			}
		}

		private IEnumerator ShowAnnouncement(string text)
		{
			m_active = true;
			float a = 1f / FadeDuration;
			Label.text = text;
			while (Panel.alpha < 1f)
			{
				Panel.alpha += a * Time.deltaTime;
				yield return null;
			}
			Source.Play();
			Panel.alpha = 1f;
			yield return new WaitForSeconds(VisibilityDuration);
			while (Panel.alpha > 0f)
			{
				Panel.alpha -= a * Time.deltaTime;
				yield return null;
			}
			Label.text = string.Empty;
			Panel.alpha = 0f;
			m_active = false;
		}

		public static void Show(string text)
		{
			if ((bool)instance)
			{
				instance.showAnnouncement(text);
			}
		}
	}
}
