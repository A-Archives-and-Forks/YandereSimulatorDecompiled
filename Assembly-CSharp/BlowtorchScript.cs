﻿using System;
using UnityEngine;

// Token: 0x020000ED RID: 237
public class BlowtorchScript : MonoBehaviour
{
	// Token: 0x06000A49 RID: 2633 RVA: 0x0005B3CB File Offset: 0x000595CB
	private void Start()
	{
		this.Flame.localScale = Vector3.zero;
		base.enabled = false;
	}

	// Token: 0x06000A4A RID: 2634 RVA: 0x0005B3E4 File Offset: 0x000595E4
	private void Update()
	{
		this.Timer = Mathf.MoveTowards(this.Timer, 5f, Time.deltaTime);
		float num = UnityEngine.Random.Range(0.9f, 1f);
		this.Flame.localScale = new Vector3(num, num, num);
		if (this.Timer == 5f)
		{
			this.Flame.localScale = Vector3.zero;
			this.Yandere.Cauterizing = false;
			this.Yandere.CanMove = true;
			base.enabled = false;
			base.GetComponent<AudioSource>().Stop();
			this.Timer = 0f;
		}
	}

	// Token: 0x04000BB4 RID: 2996
	public YandereScript Yandere;

	// Token: 0x04000BB5 RID: 2997
	public RagdollScript Corpse;

	// Token: 0x04000BB6 RID: 2998
	public PickUpScript PickUp;

	// Token: 0x04000BB7 RID: 2999
	public PromptScript Prompt;

	// Token: 0x04000BB8 RID: 3000
	public Transform Flame;

	// Token: 0x04000BB9 RID: 3001
	public float Timer;
}
