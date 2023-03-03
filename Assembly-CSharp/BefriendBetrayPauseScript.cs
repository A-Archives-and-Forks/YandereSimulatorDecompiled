using UnityEngine;

public class BefriendBetrayPauseScript : MonoBehaviour
{
	public StalkerYandereScript Yandere;

	public UIPanel Panel;

	private void Start()
	{
		Panel.enabled = false;
	}

	private void Update()
	{
		if (Yandere.CanMove && !Input.GetButton("RB") && Input.GetButtonDown("Start"))
		{
			if (!Panel.enabled)
			{
				Yandere.ResetYandereEffects();
				Panel.enabled = true;
				Time.timeScale = 0f;
			}
			else
			{
				Panel.enabled = false;
				Time.timeScale = 1f;
			}
		}
	}
}
