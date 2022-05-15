﻿using System;
using UnityEngine;

// Token: 0x02000364 RID: 868
public class MatchboxScript : MonoBehaviour
{
	// Token: 0x060019B8 RID: 6584 RVA: 0x001070AC File Offset: 0x001052AC
	private void Update()
	{
		if (!this.Prompt.PauseScreen.Show)
		{
			if (this.Prompt.Yandere.PickUp == this.PickUp)
			{
				if (this.Prompt.HideButton[0])
				{
					this.Prompt.Yandere.Arc.SetActive(true);
					this.Prompt.HideButton[0] = false;
					this.Prompt.HideButton[3] = true;
				}
				if (this.Prompt.Circle[0].fillAmount < 1f && this.Prompt.Circle[0].fillAmount > 0f)
				{
					this.Prompt.Circle[0].fillAmount = 0f;
					this.MyAudio.Play();
					Rigidbody component = UnityEngine.Object.Instantiate<GameObject>(this.Match, this.Prompt.Yandere.ItemParent.position, this.Prompt.Yandere.transform.rotation).GetComponent<Rigidbody>();
					component.isKinematic = false;
					component.useGravity = true;
					component.AddRelativeForce(Vector3.up * 250f);
					component.AddRelativeForce(Vector3.forward * 250f);
					this.Prompt.Yandere.SuspiciousActionTimer = 1f;
					this.Ammo--;
					if (this.Ammo < 1)
					{
						this.Prompt.Yandere.Arc.SetActive(false);
						this.Prompt.Yandere.PickUp.Drop();
						UnityEngine.Object.Destroy(base.gameObject);
						return;
					}
				}
			}
			else if (this.Prompt.Yandere.Arc.activeInHierarchy && !this.Prompt.HideButton[0])
			{
				this.Prompt.Yandere.Arc.SetActive(false);
				this.Prompt.HideButton[0] = true;
				this.Prompt.HideButton[3] = false;
			}
		}
	}

	// Token: 0x04002951 RID: 10577
	public YandereScript Yandere;

	// Token: 0x04002952 RID: 10578
	public PromptScript Prompt;

	// Token: 0x04002953 RID: 10579
	public PickUpScript PickUp;

	// Token: 0x04002954 RID: 10580
	public GameObject Match;

	// Token: 0x04002955 RID: 10581
	public AudioSource MyAudio;

	// Token: 0x04002956 RID: 10582
	public int Ammo;
}
