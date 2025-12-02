using UnityEngine;

public class USBStickScript : MonoBehaviour
{
	public StudentManagerScript SM;

	public PromptScript Prompt;

	public AudioClip GemaUSB;

	private void Start()
	{
		if (GameGlobals.WhipGameUnlocked)
		{
			base.gameObject.SetActive(value: false);
			Prompt.Hide();
			Prompt.enabled = false;
		}
	}

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			if (SM.Students[36] != null && Vector3.Distance(Prompt.Yandere.transform.position, SM.Students[36].transform.position) < 5f)
			{
				Prompt.Yandere.Subtitle.CustomText = "Oh - that? It's the prototype for a game I'm workin' on! I managed to get it runnin' on SaikouStation. Hey - you've got one, right? You wanna playtest my game? It's on that USB there - just plug it into your console, and it should start automatically!";
				Prompt.Yandere.Subtitle.UpdateLabel(SubtitleType.Custom, 0, 19f);
				SM.Students[36].SpawnTimeRespectingAudioSource(GemaUSB);
			}
			SM.TookUSB = true;
			base.gameObject.SetActive(value: false);
			Prompt.Hide();
			Prompt.enabled = false;
		}
	}
}
