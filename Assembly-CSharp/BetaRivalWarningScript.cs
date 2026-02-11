using UnityEngine;

public class BetaRivalWarningScript : MonoBehaviour
{
	public AudioSource MyAudio;

	public UISprite Darkness;

	public UISprite[] Box;

	public AudioClip Ding;

	public bool FadeOut;

	public int Presses;

	private void Start()
	{
		Darkness.alpha = 1f;
	}

	private void Update()
	{
		if (!FadeOut)
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 0f, Time.deltaTime);
			if (Darkness.alpha == 0f && Input.GetButtonDown(InputNames.Xbox_A))
			{
				Presses++;
				Box[Presses].alpha = 1f;
				if (Presses == 10)
				{
					MyAudio.clip = Ding;
					MyAudio.pitch = 1f;
					FadeOut = true;
				}
				else
				{
					MyAudio.pitch += 0.05f;
				}
				MyAudio.Play();
			}
		}
		else
		{
			Darkness.alpha = Mathf.MoveTowards(Darkness.alpha, 1f, Time.deltaTime);
		}
	}
}
