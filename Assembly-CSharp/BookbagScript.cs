﻿using System;
using UnityEngine;

// Token: 0x020000F4 RID: 244
public class BookbagScript : MonoBehaviour
{
	// Token: 0x06000A5B RID: 2651 RVA: 0x0005C6C4 File Offset: 0x0005A8C4
	private void Start()
	{
		this.MyRigidbody.useGravity = false;
		this.MyRigidbody.isKinematic = true;
		if (GameGlobals.Eighties)
		{
			this.MyRenderer.material.mainTexture = this.EightiesBookBagTexture;
			this.MyMesh.mesh = this.EightiesBookBag;
		}
	}

	// Token: 0x06000A5C RID: 2652 RVA: 0x0005C718 File Offset: 0x0005A918
	private void Update()
	{
		if (this.Prompt.Yandere.PickUp != null || this.ConcealedPickup != null)
		{
			this.Prompt.HideButton[0] = false;
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Circle[0].fillAmount = 1f;
				if (this.ConcealedPickup == null)
				{
					if (this.Prompt.Yandere.PickUp.OpenFlame)
					{
						this.Prompt.Yandere.NotificationManager.CustomText = "That's too dangerous!";
						this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
					else if (this.Prompt.Yandere.PickUp.TrashCan == null && !this.Prompt.Yandere.PickUp.JerryCan && !this.Prompt.Yandere.PickUp.Mop && !this.Prompt.Yandere.PickUp.Bucket && !this.Prompt.Yandere.PickUp.Bleach && !this.Prompt.Yandere.PickUp.TooBig)
					{
						this.ConcealedPickup = this.Prompt.Yandere.PickUp;
						this.ConcealedPickup.InsideBookbag = true;
						this.ConcealedPickup.Drop();
						this.ConcealedPickup.gameObject.SetActive(false);
						if (this.ConcealedPickup.Prompt.Text[3] != "")
						{
							this.Prompt.Label[0].text = "     Retrieve " + this.ConcealedPickup.Prompt.Text[3];
						}
						else
						{
							this.Prompt.Label[0].text = "     Retrieve " + this.ConcealedPickup.name;
						}
					}
					else
					{
						this.Prompt.Yandere.NotificationManager.CustomText = "That wouldn't fit!";
						this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
				}
				else
				{
					this.ConcealedPickup.transform.position = base.transform.position;
					this.ConcealedPickup.gameObject.SetActive(true);
					this.ConcealedPickup.Prompt.Circle[3].fillAmount = -1f;
					this.ConcealedPickup.InsideBookbag = false;
					this.ConcealedPickup = null;
					this.Prompt.Label[0].text = "     Conceal Item";
				}
			}
		}
		else
		{
			this.Prompt.HideButton[0] = true;
		}
		if (this.Prompt.Circle[3].fillAmount == 0f)
		{
			this.Wear();
		}
	}

	// Token: 0x06000A5D RID: 2653 RVA: 0x0005CA2C File Offset: 0x0005AC2C
	public void Drop()
	{
		this.Worn = false;
		this.Prompt.Yandere.Bookbag = null;
		base.transform.parent = null;
		this.Prompt.MyCollider.enabled = true;
		this.MyRigidbody.useGravity = true;
		this.MyRigidbody.isKinematic = false;
		this.Prompt.enabled = true;
		base.enabled = true;
	}

	// Token: 0x06000A5E RID: 2654 RVA: 0x0005CA9C File Offset: 0x0005AC9C
	public void Wear()
	{
		this.Worn = true;
		this.Prompt.Yandere.Bookbag = this;
		base.transform.parent = this.Prompt.Yandere.BookBagParent;
		base.transform.localPosition = new Vector3(0f, 0f, 0f);
		base.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		base.transform.localScale = new Vector3(1f, 1f, 1f);
		this.Prompt.MyCollider.enabled = false;
		this.MyRigidbody.useGravity = false;
		this.MyRigidbody.isKinematic = true;
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		base.enabled = true;
	}

	// Token: 0x04000C0F RID: 3087
	public PickUpScript ConcealedPickup;

	// Token: 0x04000C10 RID: 3088
	public Rigidbody MyRigidbody;

	// Token: 0x04000C11 RID: 3089
	public PromptScript Prompt;

	// Token: 0x04000C12 RID: 3090
	public Texture EightiesBookBagTexture;

	// Token: 0x04000C13 RID: 3091
	public Mesh EightiesBookBag;

	// Token: 0x04000C14 RID: 3092
	public Renderer MyRenderer;

	// Token: 0x04000C15 RID: 3093
	public MeshFilter MyMesh;

	// Token: 0x04000C16 RID: 3094
	public bool Worn;
}
