using UnityEngine;

namespace HNS
{
	public static class Audio
	{
		public static AudioConfiguration[] Configuration = new AudioConfiguration[3]
		{
			new AudioConfiguration
			{
				Type = AudioType.UI,
				Volume = 1f
			},
			new AudioConfiguration
			{
				Type = AudioType.SFX,
				Volume = 1f
			},
			new AudioConfiguration
			{
				Type = AudioType.Music,
				Volume = 1f
			}
		};

		private static AudioSource CreateSource(string name, Transform parent, Vector3 position)
		{
			GameObject gameObject = new GameObject(name);
			gameObject.transform.parent = parent;
			gameObject.transform.position = position;
			return gameObject.AddComponent<AudioSource>();
		}

		private static void SetVolume(AudioSource source, AudioType type, float volume)
		{
			if (type >= AudioType.UI && (int)type < Configuration.Length)
			{
				float volume2 = Configuration[(int)type].Volume;
				source.volume = volume * volume2;
			}
		}

		private static AudioSource Play(AudioClip clip, AudioType type, float volume, Transform parent, Vector3 position, float spatialBlend, float minDistance, float maxDistance)
		{
			if (!clip)
			{
				return null;
			}
			AudioSource audioSource = CreateSource(clip.name, parent, position);
			audioSource.transform.parent = parent;
			audioSource.transform.position = position;
			audioSource.clip = clip;
			audioSource.rolloffMode = AudioRolloffMode.Linear;
			audioSource.spatialBlend = spatialBlend;
			audioSource.minDistance = minDistance;
			audioSource.maxDistance = maxDistance;
			SetVolume(audioSource, type, volume);
			audioSource.Play();
			Object.Destroy(audioSource.gameObject, clip.length + 0.1f);
			return audioSource;
		}

		public static AudioSource Play(AudioClip clip, AudioType type)
		{
			return Play(clip, type, 1f, null, Vector3.zero, 0f, 0f, 0f);
		}

		public static AudioSource Play(AudioClip clip, AudioType type, float volume)
		{
			return Play(clip, type, volume, null, Vector3.zero, 0f, 0f, 0f);
		}

		public static AudioSource Play(AudioClip clip, AudioType type, float volume, Vector3 position, float minDistance, float maxDistance)
		{
			return Play(clip, type, volume, null, position, 1f, minDistance, maxDistance);
		}

		public static AudioSource Play(AudioClip clip, AudioType type, float volume, Transform parent, float minDistance, float maxDistance)
		{
			return Play(clip, type, volume, parent, parent.position, 1f, minDistance, maxDistance);
		}

		public static AudioSource Play(AudioClip clip, AudioType type, float volume, Transform parent, Vector3 position, float minDistance, float maxDistance)
		{
			return Play(clip, type, volume, parent, position, 1f, minDistance, maxDistance);
		}

		public static AudioSource Play(AudioClip[] clip, AudioType type)
		{
			return Play(clip[Random.Range(0, clip.Length)], type, 1f, null, Vector3.zero, 0f, 0f, 0f);
		}

		public static AudioSource Play(AudioClip[] clip, AudioType type, float volume)
		{
			return Play(clip[Random.Range(0, clip.Length)], type, volume, null, Vector3.zero, 0f, 0f, 0f);
		}

		public static AudioSource Play(AudioClip[] clip, AudioType type, float volume, Vector3 position, float minDistance, float maxDistance)
		{
			return Play(clip[Random.Range(0, clip.Length)], type, volume, null, position, 1f, minDistance, maxDistance);
		}

		public static AudioSource Play(AudioClip[] clip, AudioType type, float volume, Transform parent, float minDistance, float maxDistance)
		{
			return Play(clip[Random.Range(0, clip.Length)], type, volume, parent, parent.position, 1f, minDistance, maxDistance);
		}

		public static AudioSource Play(AudioClip[] clip, AudioType type, float volume, Transform parent, Vector3 position, float minDistance, float maxDistance)
		{
			return Play(clip[Random.Range(0, clip.Length)], type, volume, parent, position, 1f, minDistance, maxDistance);
		}
	}
}
