﻿using System;
using UnityEngine;

// Token: 0x020002E0 RID: 736
public class GenericBentoScript : MonoBehaviour
{
	// Token: 0x060014F1 RID: 5361 RVA: 0x000CFB40 File Offset: 0x000CDD40
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f || this.Prompt.Circle[1].fillAmount == 0f || this.Prompt.Circle[2].fillAmount == 0f || this.Prompt.Circle[3].fillAmount == 0f)
		{
			this.Prompt.Yandere.StudentManager.CanAnyoneSeeYandere();
			if (!this.Prompt.Yandere.StudentManager.YandereVisible)
			{
				if (this.Prompt.Circle[0].fillAmount == 0f)
				{
					if (this.Prompt.Yandere.Inventory.EmeticPoison)
					{
						this.Prompt.Yandere.Inventory.EmeticPoison = false;
						this.Prompt.Yandere.PoisonType = 1;
					}
					else
					{
						this.Prompt.Yandere.Inventory.RatPoison = false;
						this.Prompt.Yandere.PoisonType = 3;
					}
					this.Emetic = true;
					this.ShutOff();
					return;
				}
				if (this.Prompt.Circle[1].fillAmount == 0f)
				{
					if (this.Prompt.Yandere.Inventory.Sedative)
					{
						this.Prompt.Yandere.Inventory.Sedative = false;
					}
					else
					{
						this.Prompt.Yandere.Inventory.Tranquilizer = false;
					}
					this.Prompt.Yandere.PoisonType = 4;
					this.Tranquil = true;
					this.ShutOff();
					return;
				}
				if (this.Prompt.Circle[2].fillAmount == 0f)
				{
					if (this.Prompt.Yandere.Inventory.LethalPoison)
					{
						this.Prompt.Yandere.Inventory.LethalPoison = false;
						this.Prompt.Yandere.Inventory.LethalPoisons--;
						this.Prompt.Yandere.PoisonType = 2;
					}
					else
					{
						this.Prompt.Yandere.Inventory.ChemicalPoison = false;
						this.Prompt.Yandere.Inventory.LethalPoisons--;
						this.Prompt.Yandere.PoisonType = 2;
					}
					this.Lethal = true;
					this.ShutOff();
					return;
				}
				if (this.Prompt.Circle[3].fillAmount == 0f)
				{
					this.Prompt.Yandere.Inventory.HeadachePoison = false;
					this.Prompt.Yandere.PoisonType = 5;
					this.Headache = true;
					this.ShutOff();
					return;
				}
			}
			else
			{
				this.Prompt.Circle[0].fillAmount = 1f;
				this.Prompt.Circle[1].fillAmount = 1f;
				this.Prompt.Circle[2].fillAmount = 1f;
				this.Prompt.Circle[3].fillAmount = 1f;
				this.Prompt.Yandere.NotificationManager.CustomText = "No! Someone is watching!";
				this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
		}
	}

	// Token: 0x060014F2 RID: 5362 RVA: 0x000CFE98 File Offset: 0x000CE098
	private void ShutOff()
	{
		Debug.Log("Shutting off a bento. This bento should be inaccessible from now on...");
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.EmptyGameObject, base.transform.position, Quaternion.identity);
		this.PoisonSpot = gameObject.transform;
		this.PoisonSpot.position = new Vector3(this.PoisonSpot.position.x, this.Prompt.Yandere.transform.position.y, this.PoisonSpot.position.z);
		this.PoisonSpot.LookAt(this.Prompt.Yandere.transform.position);
		this.PoisonSpot.Translate(Vector3.forward * 0.25f);
		this.Prompt.Yandere.CharacterAnimation["f02_poisoning_00"].speed = 2f;
		this.Prompt.Yandere.CharacterAnimation.CrossFade("f02_poisoning_00");
		this.Prompt.Yandere.StudentManager.UpdateAllBentos();
		this.Prompt.Yandere.TargetBento = this;
		this.Prompt.Yandere.Poisoning = true;
		this.Prompt.Yandere.CanMove = false;
		this.Tampered = true;
		base.enabled = false;
		this.Prompt.enabled = false;
		this.Prompt.Hide();
	}

	// Token: 0x060014F3 RID: 5363 RVA: 0x000D0008 File Offset: 0x000CE208
	public void UpdatePrompts()
	{
		if (!this.Tampered)
		{
			this.Prompt.HideButton[0] = true;
			this.Prompt.HideButton[1] = true;
			this.Prompt.HideButton[2] = true;
			this.Prompt.HideButton[3] = true;
			if (this.Prompt.Yandere.Inventory.EmeticPoison || this.Prompt.Yandere.Inventory.RatPoison)
			{
				this.Prompt.HideButton[0] = false;
			}
			if (this.Prompt.Yandere.Inventory.Tranquilizer || this.Prompt.Yandere.Inventory.Sedative)
			{
				this.Prompt.HideButton[1] = false;
			}
			if (this.Prompt.Yandere.Inventory.LethalPoison || this.Prompt.Yandere.Inventory.ChemicalPoison)
			{
				this.Prompt.HideButton[2] = false;
			}
			if (this.Prompt.Yandere.Inventory.HeadachePoison)
			{
				this.Prompt.HideButton[3] = false;
			}
			this.Prompt.Yandere.EmptyHands();
		}
	}

	// Token: 0x04002124 RID: 8484
	public GameObject EmptyGameObject;

	// Token: 0x04002125 RID: 8485
	public GameObject Lid;

	// Token: 0x04002126 RID: 8486
	public Transform PoisonSpot;

	// Token: 0x04002127 RID: 8487
	public PromptScript Prompt;

	// Token: 0x04002128 RID: 8488
	public bool Emetic;

	// Token: 0x04002129 RID: 8489
	public bool Tranquil;

	// Token: 0x0400212A RID: 8490
	public bool Headache;

	// Token: 0x0400212B RID: 8491
	public bool Lethal;

	// Token: 0x0400212C RID: 8492
	public bool Tampered;

	// Token: 0x0400212D RID: 8493
	public int StudentID;
}
