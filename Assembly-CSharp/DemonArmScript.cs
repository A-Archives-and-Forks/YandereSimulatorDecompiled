﻿using System;
using UnityEngine;

// Token: 0x0200027B RID: 635
public class DemonArmScript : MonoBehaviour
{
	// Token: 0x06001370 RID: 4976 RVA: 0x000B24D0 File Offset: 0x000B06D0
	private void Start()
	{
		this.MyAnimation = base.GetComponent<Animation>();
		if (!this.Rising)
		{
			this.MyAnimation[this.IdleAnim].speed = this.AnimSpeed * 0.5f;
		}
		this.MyAnimation[this.AttackAnim].speed = 1f;
	}

	// Token: 0x06001371 RID: 4977 RVA: 0x000B2530 File Offset: 0x000B0730
	private void Update()
	{
		if (!this.Rising)
		{
			if (!this.Attacking)
			{
				this.MyAnimation.CrossFade(this.IdleAnim);
				return;
			}
			if (!this.Attacked)
			{
				if (this.MyAnimation[this.AttackAnim].time >= this.MyAnimation[this.AttackAnim].length * 0.15f)
				{
					this.ClawCollider.enabled = true;
					this.Attacked = true;
					return;
				}
			}
			else
			{
				if (this.MyAnimation[this.AttackAnim].time >= this.MyAnimation[this.AttackAnim].length * 0.4f)
				{
					this.ClawCollider.enabled = false;
				}
				if (this.MyAnimation[this.AttackAnim].time >= this.MyAnimation[this.AttackAnim].length)
				{
					this.MyAnimation.CrossFade(this.IdleAnim);
					this.ClawCollider.enabled = false;
					this.Attacking = false;
					this.Attacked = false;
					this.AnimTime = 0f;
					return;
				}
			}
		}
		else if (this.MyAnimation["DemonArmRise"].time >= this.MyAnimation["DemonArmRise"].length)
		{
			this.Rising = false;
		}
	}

	// Token: 0x06001372 RID: 4978 RVA: 0x000B2690 File Offset: 0x000B0890
	private void OnTriggerEnter(Collider other)
	{
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (component != null && component.StudentID > 1)
		{
			AudioSource component2 = base.GetComponent<AudioSource>();
			component2.clip = this.Whoosh;
			component2.pitch = UnityEngine.Random.Range(-0.9f, 1.1f);
			component2.Play();
			base.GetComponent<Animation>().CrossFade(this.AttackAnim);
			this.Attacking = true;
		}
	}

	// Token: 0x04001C89 RID: 7305
	public GameObject DismembermentCollider;

	// Token: 0x04001C8A RID: 7306
	public Animation MyAnimation;

	// Token: 0x04001C8B RID: 7307
	public Collider ClawCollider;

	// Token: 0x04001C8C RID: 7308
	public bool Attacking;

	// Token: 0x04001C8D RID: 7309
	public bool Attacked;

	// Token: 0x04001C8E RID: 7310
	public bool Rising = true;

	// Token: 0x04001C8F RID: 7311
	public string IdleAnim = "DemonArmIdle";

	// Token: 0x04001C90 RID: 7312
	public string AttackAnim = "DemonArmAttack";

	// Token: 0x04001C91 RID: 7313
	public AudioClip Whoosh;

	// Token: 0x04001C92 RID: 7314
	public float AnimSpeed = 1f;

	// Token: 0x04001C93 RID: 7315
	public float AnimTime;
}
