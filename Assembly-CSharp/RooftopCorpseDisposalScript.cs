using UnityEngine;

public class RooftopCorpseDisposalScript : MonoBehaviour
{
	public YandereScript Yandere;

	public PromptScript Prompt;

	public Collider MyCollider;

	public Transform DropSpot;

	public bool EastWest;

	private void Start()
	{
		if (SchoolGlobals.RoofFence)
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void Update()
	{
		if (Yandere.Carrying && Yandere.Ragdoll != null)
		{
			if (MyCollider.bounds.Contains(Yandere.transform.position))
			{
				if (Yandere.Dropping)
				{
					return;
				}
				Prompt.enabled = true;
				Prompt.transform.position = new Vector3(Yandere.transform.position.x + 0.0001f, Yandere.transform.position.y + 1.66666f, Yandere.transform.position.z + 0.0001f);
				if (Prompt.Circle[0].fillAmount == 0f)
				{
					if (EastWest)
					{
						DropSpot.position = new Vector3(DropSpot.position.x, DropSpot.position.y, Yandere.transform.position.z);
					}
					else
					{
						DropSpot.position = new Vector3(Yandere.transform.position.x, DropSpot.position.y, DropSpot.position.z);
					}
					Yandere.CharacterAnimation.CrossFade("f02_carryIdleA_00");
					Yandere.DropSpot = DropSpot;
					Yandere.Dropping = true;
					Yandere.CanMove = false;
					HidePrompt();
					Yandere.Ragdoll.GetComponent<RagdollScript>().BloodPoolSpawner.Falling = true;
					Yandere.Ragdoll.GetComponent<RagdollScript>().DroppedFromRooftop = true;
				}
			}
			else
			{
				HidePrompt();
			}
		}
		else
		{
			HidePrompt();
		}
	}

	private void HidePrompt()
	{
		if (Prompt.enabled)
		{
			Prompt.Hide();
			Prompt.enabled = false;
		}
	}
}
