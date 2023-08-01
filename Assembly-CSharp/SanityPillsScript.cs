using UnityEngine;

public class SanityPillsScript : MonoBehaviour
{
	public PromptScript Prompt;

	public bool Cheated;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			if (!Cheated)
			{
				Prompt.Yandere.Alphabet.Cheats++;
				Cheated = true;
			}
			Prompt.Yandere.Alphabet.UpdateDifficultyLabel();
			Prompt.Yandere.SanityPills = true;
			Prompt.enabled = false;
			Prompt.Hide();
			base.gameObject.SetActive(value: false);
		}
	}
}
