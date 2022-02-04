﻿using System;
using UnityEngine;

// Token: 0x020003E9 RID: 1001
public class RooftopCorpseDisposalScript : MonoBehaviour
{
	// Token: 0x06001BC7 RID: 7111 RVA: 0x0014488F File Offset: 0x00142A8F
	private void Start()
	{
		if (SchoolGlobals.RoofFence)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001BC8 RID: 7112 RVA: 0x001448A4 File Offset: 0x00142AA4
	private void Update()
	{
		if (this.MyCollider.bounds.Contains(this.Yandere.transform.position))
		{
			if (!(this.Yandere.Ragdoll != null))
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				return;
			}
			if (!this.Yandere.Dropping)
			{
				this.Prompt.enabled = true;
				this.Prompt.transform.position = new Vector3(this.Yandere.transform.position.x, this.Yandere.transform.position.y + 1.66666f, this.Yandere.transform.position.z);
				if (this.Prompt.Circle[0].fillAmount == 0f)
				{
					this.DropSpot.position = new Vector3(this.DropSpot.position.x, this.DropSpot.position.y, this.Yandere.transform.position.z);
					this.Yandere.CharacterAnimation.CrossFade(this.Yandere.Carrying ? "f02_carryIdleA_00" : "f02_dragIdle_00");
					this.Yandere.DropSpot = this.DropSpot;
					this.Yandere.Dropping = true;
					this.Yandere.CanMove = false;
					this.Prompt.Hide();
					this.Prompt.enabled = false;
					this.Yandere.Ragdoll.GetComponent<RagdollScript>().BloodPoolSpawner.Falling = true;
					return;
				}
			}
		}
		else
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	// Token: 0x040030C4 RID: 12484
	public YandereScript Yandere;

	// Token: 0x040030C5 RID: 12485
	public PromptScript Prompt;

	// Token: 0x040030C6 RID: 12486
	public Collider MyCollider;

	// Token: 0x040030C7 RID: 12487
	public Transform DropSpot;
}
