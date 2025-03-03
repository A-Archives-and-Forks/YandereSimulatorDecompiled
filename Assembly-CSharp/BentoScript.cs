using UnityEngine;

public class BentoScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public YandereScript Yandere;

	public Transform PoisonSpot;

	public PromptScript Prompt;

	public bool BeingPoisoned;

	public int Poison;

	public int ID;

	private void Start()
	{
		if (Prompt.Yandere != null)
		{
			Yandere = Prompt.Yandere;
		}
	}

	private void Update()
	{
		if (Yandere == null)
		{
			if (Prompt.Yandere != null)
			{
				Yandere = Prompt.Yandere;
			}
		}
		else if (Yandere.Inventory.EmeticPoisons > 0 || Yandere.Inventory.LethalPoisons > 0 || Yandere.Inventory.SedativePoisons > 0)
		{
			Prompt.enabled = true;
			if (Yandere.Inventory.EmeticPoisons > 0)
			{
				Prompt.HideButton[0] = false;
			}
			else
			{
				Prompt.HideButton[0] = true;
			}
			if (Prompt.Circle[0].fillAmount == 0f)
			{
				Prompt.Circle[0].fillAmount = 1f;
				Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
				if (!Prompt.Yandere.StudentManager.YandereVisible)
				{
					StudentManager.Students[ID].MyBento.Tampered = true;
					StudentManager.Students[ID].MyBento.Emetic = true;
					StudentManager.Students[ID].Emetic = true;
					Yandere.CharacterAnimation.CrossFade("f02_poisoning_00");
					Yandere.PoisonSpot = PoisonSpot;
					Yandere.Inventory.EmeticPoisons--;
					Yandere.Poisoning = true;
					Yandere.CanMove = false;
					Yandere.PoisonType = 1;
					base.enabled = false;
					Poison = 1;
					if (ID != 1)
					{
						StudentManager.Students[ID].Emetic = true;
					}
					Prompt.Hide();
					Prompt.enabled = false;
					Prompt.Yandere.StudentManager.UpdateAllBentos();
					BeingPoisoned = true;
				}
				else
				{
					Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
			if (ID != 11 && ID != 6)
			{
				return;
			}
			if (Prompt.Yandere.Inventory.LethalPoisons > 0)
			{
				Prompt.HideButton[1] = false;
			}
			else
			{
				Prompt.HideButton[1] = true;
			}
			if (Prompt.Circle[1].fillAmount == 0f)
			{
				Yandere.Sanity -= ((PlayerGlobals.PantiesEquipped == 10) ? 10f : 20f) * Yandere.Numbness;
				StudentManager.Students[ID].MyBento.Tampered = true;
				StudentManager.Students[ID].MyBento.Lethal = true;
				StudentManager.Students[ID].Lethal = true;
				Prompt.Yandere.CharacterAnimation.CrossFade("f02_poisoning_00");
				Prompt.Yandere.PoisonSpot = PoisonSpot;
				Prompt.Yandere.Inventory.LethalPoisons--;
				Prompt.Yandere.Poisoning = true;
				Prompt.Yandere.CanMove = false;
				Prompt.Yandere.PoisonType = 2;
				base.enabled = false;
				Poison = 2;
				Prompt.Hide();
				Prompt.enabled = false;
				Prompt.Yandere.StudentManager.UpdateAllBentos();
				BeingPoisoned = true;
			}
			if (Yandere.Inventory.SedativePoisons > 0)
			{
				Prompt.HideButton[2] = false;
			}
			else
			{
				Prompt.HideButton[2] = true;
			}
			if (Prompt.Circle[2].fillAmount == 0f)
			{
				Prompt.Circle[2].fillAmount = 1f;
				Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
				if (!Prompt.Yandere.StudentManager.YandereVisible)
				{
					StudentManager.Students[ID].MyBento.Tampered = true;
					StudentManager.Students[ID].MyBento.Tranquil = true;
					Yandere.CharacterAnimation.CrossFade("f02_poisoning_00");
					Yandere.PoisonSpot = PoisonSpot;
					Yandere.Inventory.SedativePoisons--;
					Yandere.Poisoning = true;
					Yandere.CanMove = false;
					Yandere.PoisonType = 3;
					base.enabled = false;
					Poison = 3;
					_ = ID;
					_ = 1;
					Prompt.Hide();
					Prompt.enabled = false;
					Prompt.Yandere.StudentManager.UpdateAllBentos();
					BeingPoisoned = true;
				}
				else
				{
					Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
					Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
		}
		else if (Prompt.enabled)
		{
			Prompt.enabled = false;
			Prompt.Hide();
			Prompt.enabled = false;
		}
	}
}
