using UnityEngine;

public class ChinaDressScript : MonoBehaviour
{
	public SkinnedMeshUpdater Crush;

	public PromptScript Prompt;

	public bool Chinese;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (!Crush.Cosplaying)
			{
				Prompt.Yandere.WearChinaDress();
				Disable();
				Chinese = true;
			}
			else
			{
				Debug.Log("Ahem.");
				Prompt.Yandere.NotificationManager.CustomText = "Can't Wear Dress When Cosplaying";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
		}
	}

	public void Disable()
	{
		Prompt.Hide();
		Prompt.enabled = false;
		base.enabled = false;
	}
}
