﻿using System;
using UnityEngine;

// Token: 0x020003EE RID: 1006
public class SafeScript : MonoBehaviour
{
	// Token: 0x06001BD5 RID: 7125 RVA: 0x001433A9 File Offset: 0x001415A9
	private void Start()
	{
		this.ContentsPrompt.MyCollider.enabled = false;
		this.SafePrompt.enabled = false;
	}

	// Token: 0x06001BD6 RID: 7126 RVA: 0x001433C8 File Offset: 0x001415C8
	private void Update()
	{
		if (this.Key.activeInHierarchy && this.KeyPrompt.Circle[0].fillAmount == 0f)
		{
			this.KeyPrompt.Yandere.Inventory.SafeKey = true;
			this.SafePrompt.HideButton[0] = false;
			this.SafePrompt.enabled = true;
			this.Key.SetActive(false);
		}
		if (this.SafePrompt.Circle[0].fillAmount == 0f)
		{
			this.KeyPrompt.Yandere.Inventory.SafeKey = false;
			this.ContentsPrompt.MyCollider.enabled = true;
			this.Open = true;
			this.SafePrompt.Hide();
			this.SafePrompt.enabled = false;
		}
		if (this.ContentsPrompt.Circle[0].fillAmount == 0f)
		{
			this.MissionMode.DocumentsStolen = true;
			base.enabled = false;
			this.ContentsPrompt.Hide();
			this.ContentsPrompt.enabled = false;
			this.ContentsPrompt.gameObject.SetActive(false);
		}
		if (this.Open)
		{
			this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * 10f);
			this.Door.localEulerAngles = new Vector3(this.Door.localEulerAngles.x, this.Rotation, this.Door.localEulerAngles.z);
			if (this.Rotation < 1f)
			{
				this.Open = false;
				return;
			}
		}
		else if (this.SafePrompt.Yandere.Inventory.LockPick)
		{
			this.SafePrompt.HideButton[2] = false;
			this.SafePrompt.enabled = true;
			if (this.SafePrompt.Circle[2].fillAmount == 0f)
			{
				this.KeyPrompt.Hide();
				this.KeyPrompt.enabled = false;
				this.SafePrompt.Yandere.Inventory.LockPick = false;
				this.SafePrompt.HideButton[2] = true;
				this.ContentsPrompt.MyCollider.enabled = true;
				this.Open = true;
				return;
			}
		}
		else if (!this.SafePrompt.HideButton[2])
		{
			this.SafePrompt.HideButton[2] = true;
		}
	}

	// Token: 0x040030D1 RID: 12497
	public MissionModeScript MissionMode;

	// Token: 0x040030D2 RID: 12498
	public PromptScript ContentsPrompt;

	// Token: 0x040030D3 RID: 12499
	public PromptScript SafePrompt;

	// Token: 0x040030D4 RID: 12500
	public PromptScript KeyPrompt;

	// Token: 0x040030D5 RID: 12501
	public Transform Door;

	// Token: 0x040030D6 RID: 12502
	public GameObject Key;

	// Token: 0x040030D7 RID: 12503
	public float Rotation;

	// Token: 0x040030D8 RID: 12504
	public bool Open;
}
