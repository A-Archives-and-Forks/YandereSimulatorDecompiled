using UnityEngine;

namespace HNS
{
	public class RandomAudioClip : MonoBehaviour
	{
		public AudioClip[] audioClips;

		private AudioSource audioSource;

		private void Start()
		{
			audioSource = GetComponent<AudioSource>();
			PlayRandomClip();
		}

		private void PlayRandomClip()
		{
			if (audioClips.Length != 0)
			{
				int num = Random.Range(0, audioClips.Length);
				audioSource.clip = audioClips[num];
				audioSource.Play();
			}
		}
	}
}
