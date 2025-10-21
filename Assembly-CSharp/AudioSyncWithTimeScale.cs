using UnityEngine;

public class AudioSyncWithTimeScale : MonoBehaviour
{
	public AudioSource audioSource;

	[Range(0.1f, 3f)]
	public float pitchMultiplier = 1f;

	private void Start()
	{
		if (audioSource == null)
		{
			audioSource = GetComponent<AudioSource>();
		}
	}

	private void Update()
	{
		audioSource.pitch = Time.timeScale * pitchMultiplier;
		if (Time.timeScale == 0f && audioSource.isPlaying)
		{
			audioSource.Pause();
		}
		else if (Time.timeScale > 0f && !audioSource.isPlaying)
		{
			audioSource.UnPause();
		}
	}
}
