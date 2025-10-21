using UnityEngine;

public class AnimeStyleLegacyAnimator : MonoBehaviour
{
	public Animation anim;

	public string clipName = "Idle";

	public float fps = 12f;

	private float frameTime;

	private float timer;

	private float currentTime;

	private void Start()
	{
		if (anim == null)
		{
			anim = GetComponent<Animation>();
		}
		anim[clipName].speed = 0f;
		anim.Play(clipName);
		frameTime = 1f / fps;
		currentTime = 0f;
	}

	private void Update()
	{
		timer += Time.deltaTime;
		if (timer >= frameTime)
		{
			currentTime += frameTime;
			if (currentTime > anim[clipName].length)
			{
				currentTime = 0f;
			}
			anim[clipName].time = currentTime;
			anim.Sample();
			timer -= frameTime;
		}
	}
}
