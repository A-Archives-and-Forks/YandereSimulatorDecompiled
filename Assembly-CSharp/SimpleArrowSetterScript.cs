using UnityEngine;

public class SimpleArrowSetterScript : MonoBehaviour
{
	public AudioSource MyAudio;

	public float[] LeftArrowTimes;

	public float[] DownArrowTimes;

	public float[] UpArrowTimes;

	public float[] RightArrowTimes;

	public int LeftArrows;

	public int DownArrows;

	public int UpArrows;

	public int RightArrows;

	public float Timer;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (!MyAudio.isPlaying)
			{
				MyAudio.Play();
			}
			else if (MyAudio.time < 30f)
			{
				MyAudio.time = 30f;
				Timer = 30f;
				LeftArrows = 23;
				DownArrows = 22;
				UpArrows = 18;
				RightArrows = 19;
			}
		}
		if (MyAudio.isPlaying)
		{
			if (Input.GetKeyDown(KeyCode.UpArrow))
			{
				UpArrowTimes[UpArrows] = MyAudio.time;
				UpArrows++;
			}
			if (Input.GetKeyDown(KeyCode.RightArrow))
			{
				RightArrowTimes[RightArrows] = MyAudio.time;
				RightArrows++;
			}
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				DownArrowTimes[DownArrows] = MyAudio.time;
				DownArrows++;
			}
			if (Input.GetKeyDown(KeyCode.LeftArrow))
			{
				LeftArrowTimes[LeftArrows] = MyAudio.time;
				LeftArrows++;
			}
			Timer += Time.deltaTime;
			Debug.Log("Song time is: " + MyAudio.time);
		}
	}
}
