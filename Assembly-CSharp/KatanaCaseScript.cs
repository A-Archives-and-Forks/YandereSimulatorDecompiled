﻿using System;
using UnityEngine;

// Token: 0x0200034B RID: 843
public class KatanaCaseScript : MonoBehaviour
{
	// Token: 0x0600195F RID: 6495 RVA: 0x000FE981 File Offset: 0x000FCB81
	private void Start()
	{
		this.CasePrompt.enabled = false;
	}

	// Token: 0x06001960 RID: 6496 RVA: 0x000FE990 File Offset: 0x000FCB90
	private void Update()
	{
		if (this.Key.activeInHierarchy && this.KeyPrompt.Circle[0].fillAmount == 0f)
		{
			this.KeyPrompt.Yandere.Inventory.CaseKey = true;
			this.CasePrompt.HideButton[0] = false;
			this.CasePrompt.enabled = true;
			this.Key.SetActive(false);
		}
		if (this.CasePrompt.Circle[0].fillAmount == 0f)
		{
			this.KeyPrompt.Yandere.Inventory.CaseKey = false;
			this.Open = true;
			this.CasePrompt.Hide();
			this.CasePrompt.enabled = false;
		}
		if (this.CasePrompt.Yandere.Inventory.LockPick)
		{
			this.CasePrompt.HideButton[2] = false;
			this.CasePrompt.enabled = true;
			if (this.CasePrompt.Circle[2].fillAmount == 0f)
			{
				this.KeyPrompt.Hide();
				this.KeyPrompt.enabled = false;
				this.CasePrompt.Yandere.Inventory.LockPick = false;
				this.CasePrompt.Label[0].text = "     Open";
				this.CasePrompt.HideButton[2] = true;
				this.CasePrompt.HideButton[0] = true;
				this.Open = true;
			}
		}
		else if (!this.CasePrompt.HideButton[2])
		{
			this.CasePrompt.HideButton[2] = true;
		}
		if (this.Open)
		{
			this.Rotation = Mathf.Lerp(this.Rotation, -180f, Time.deltaTime * 10f);
			this.Door.eulerAngles = new Vector3(this.Door.eulerAngles.x, this.Door.eulerAngles.y, this.Rotation);
			if (this.Rotation < -179.9f)
			{
				base.enabled = false;
			}
		}
	}

	// Token: 0x0400281B RID: 10267
	public PromptScript CasePrompt;

	// Token: 0x0400281C RID: 10268
	public PromptScript KeyPrompt;

	// Token: 0x0400281D RID: 10269
	public Transform Door;

	// Token: 0x0400281E RID: 10270
	public GameObject Key;

	// Token: 0x0400281F RID: 10271
	public float Rotation;

	// Token: 0x04002820 RID: 10272
	public bool Open;
}
