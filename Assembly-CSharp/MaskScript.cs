﻿using System;
using UnityEngine;

// Token: 0x02000360 RID: 864
public class MaskScript : MonoBehaviour
{
	// Token: 0x060019AE RID: 6574 RVA: 0x00106E34 File Offset: 0x00105034
	private void Start()
	{
		if (GameGlobals.MasksBanned)
		{
			base.gameObject.SetActive(false);
		}
		else
		{
			this.MyFilter.mesh = this.Meshes[this.ID];
			this.MyRenderer.material.mainTexture = this.Textures[this.ID];
		}
		base.enabled = false;
	}

	// Token: 0x060019AF RID: 6575 RVA: 0x00106E94 File Offset: 0x00105094
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			this.StudentManager.CanAnyoneSeeYandere();
			if (!this.StudentManager.YandereVisible && !this.Yandere.Chased && this.Yandere.Chasers == 0)
			{
				Rigidbody component = base.GetComponent<Rigidbody>();
				component.useGravity = false;
				component.isKinematic = true;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.Prompt.MyCollider.enabled = false;
				base.transform.parent = this.Yandere.Head;
				base.transform.localPosition = new Vector3(0f, 0.033333f, 0.1f);
				base.transform.localEulerAngles = Vector3.zero;
				this.Yandere.Mask = this;
				this.ClubManager.UpdateMasks();
				this.StudentManager.UpdateStudents(0);
				return;
			}
			this.Yandere.NotificationManager.CustomText = "Not now. Too suspicious.";
			this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
	}

	// Token: 0x060019B0 RID: 6576 RVA: 0x00106FDC File Offset: 0x001051DC
	public void Drop()
	{
		this.Prompt.MyCollider.isTrigger = false;
		this.Prompt.MyCollider.enabled = true;
		Rigidbody component = base.GetComponent<Rigidbody>();
		component.useGravity = true;
		component.isKinematic = false;
		this.Prompt.enabled = true;
		base.transform.parent = null;
		this.Yandere.Mask = null;
		this.ClubManager.UpdateMasks();
		this.StudentManager.UpdateStudents(0);
	}

	// Token: 0x04002941 RID: 10561
	public StudentManagerScript StudentManager;

	// Token: 0x04002942 RID: 10562
	public ClubManagerScript ClubManager;

	// Token: 0x04002943 RID: 10563
	public YandereScript Yandere;

	// Token: 0x04002944 RID: 10564
	public PromptScript Prompt;

	// Token: 0x04002945 RID: 10565
	public PickUpScript PickUp;

	// Token: 0x04002946 RID: 10566
	public Projector Blood;

	// Token: 0x04002947 RID: 10567
	public Renderer MyRenderer;

	// Token: 0x04002948 RID: 10568
	public MeshFilter MyFilter;

	// Token: 0x04002949 RID: 10569
	public Texture[] Textures;

	// Token: 0x0400294A RID: 10570
	public Mesh[] Meshes;

	// Token: 0x0400294B RID: 10571
	public int ID;
}
