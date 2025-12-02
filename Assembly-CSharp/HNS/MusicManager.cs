using UnityEngine;

namespace HNS
{
	[RequireComponent(typeof(AudioSource))]
	public class MusicManager : MonoBehaviour
	{
		public static MusicManager instance;

		[Header("Settings")]
		[Range(0f, 1f)]
		public float MaxVolume = 1f;

		public float FadeInSpeed = 1f;

		public float FadeOutSpeed = 1f;

		public bool FadeInOnStart = true;

		private AudioSource audioSource;

		private float targetVolume;

		private bool isFading;

		public bool IsFading => isFading;

		public bool IsFadingOut
		{
			get
			{
				if (isFading)
				{
					return targetVolume <= 0f;
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
					return targetVolume > audioSource.volume;
				}
				return false;
			}
		}

		private void OnEnable()
		{
			instance = this;
			if (!audioSource)
			{
				audioSource = GetComponent<AudioSource>();
			}
			if (FadeInOnStart)
			{
				audioSource.volume = 0f;
				targetVolume = MaxVolume;
				isFading = true;
			}
			else
			{
				audioSource.volume = MaxVolume;
				targetVolume = MaxVolume;
			}
		}

		private void Update()
		{
			if (!isFading)
			{
				return;
			}
			float num = ((targetVolume > audioSource.volume) ? FadeInSpeed : FadeOutSpeed);
			audioSource.volume = Mathf.MoveTowards(audioSource.volume, targetVolume, Time.unscaledDeltaTime * num);
			if (Mathf.Approximately(audioSource.volume, targetVolume))
			{
				isFading = false;
				if (targetVolume <= 0f)
				{
					audioSource.Stop();
				}
			}
		}

		public void FadeIn()
		{
			if (!audioSource.isPlaying)
			{
				audioSource.Play();
			}
			targetVolume = MaxVolume;
			isFading = true;
		}

		public void FadeOut()
		{
			targetVolume = 0f;
			isFading = true;
		}

		public void SetVolume(float volume)
		{
			MaxVolume = Mathf.Clamp01(volume);
			if (!isFading)
			{
				audioSource.volume = MaxVolume;
			}
		}

		public void SetVolumeImmediate(float volume)
		{
			MaxVolume = Mathf.Clamp01(volume);
			audioSource.volume = MaxVolume;
			targetVolume = MaxVolume;
			isFading = false;
		}
	}
}
