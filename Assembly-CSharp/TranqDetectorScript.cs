﻿using System;
using UnityEngine;

// Token: 0x02000483 RID: 1155
public class TranqDetectorScript : MonoBehaviour
{
	// Token: 0x06001EF5 RID: 7925 RVA: 0x001B391A File Offset: 0x001B1B1A
	private void Start()
	{
		this.Checklist.alpha = 0f;
		this.BasementPrisoner = SchoolGlobals.KidnapVictim;
	}

	// Token: 0x06001EF6 RID: 7926 RVA: 0x001B3938 File Offset: 0x001B1B38
	private void Update()
	{
		if (!this.StopChecking)
		{
			if (this.MyCollider.bounds.Contains(this.Yandere.transform.position))
			{
				if (this.BasementPrisoner > 0)
				{
					this.KidnappingLabel.text = "There is no room for another prisoner in your basement.";
					this.CannotKidnap = true;
				}
				else
				{
					if (this.Yandere.Inventory.Tranquilizer || this.Yandere.Inventory.Sedative)
					{
						this.TranquilizerIcon.spriteName = "Yes";
					}
					else
					{
						this.TranquilizerIcon.spriteName = "No";
					}
					if (this.Yandere.Followers != 1)
					{
						this.FollowerIcon.spriteName = "No";
					}
					else if (this.Yandere.Follower.Male)
					{
						this.KidnappingLabel.text = "You cannot kidnap male students at this point in time.";
						this.FollowerIcon.spriteName = "No";
						this.CannotKidnap = true;
					}
					else
					{
						this.KidnappingLabel.text = "Kidnapping Checklist";
						this.FollowerIcon.spriteName = "Yes";
						this.CannotKidnap = false;
					}
					this.BiologyIcon.spriteName = ((this.Yandere.Class.BiologyGrade + this.Yandere.Class.BiologyBonus != 0) ? "Yes" : "No");
					if (!this.Yandere.Armed)
					{
						this.SyringeIcon.spriteName = "No";
					}
					else if (this.Yandere.EquippedWeapon.WeaponID != 3)
					{
						this.SyringeIcon.spriteName = "No";
					}
					else
					{
						this.SyringeIcon.spriteName = "Yes";
					}
					if (this.Door.Open || this.Door.Timer < 1f)
					{
						this.DoorIcon.spriteName = "No";
					}
					else
					{
						this.DoorIcon.spriteName = "Yes";
					}
				}
				this.Checklist.alpha = Mathf.MoveTowards(this.Checklist.alpha, 1f, Time.deltaTime);
				return;
			}
			if (this.Checklist.alpha != 0f)
			{
				this.Checklist.alpha = Mathf.MoveTowards(this.Checklist.alpha, 0f, Time.deltaTime);
				return;
			}
		}
		else
		{
			this.Checklist.alpha = Mathf.MoveTowards(this.Checklist.alpha, 0f, Time.deltaTime);
			if (this.Checklist.alpha == 0f)
			{
				base.enabled = false;
			}
		}
	}

	// Token: 0x06001EF7 RID: 7927 RVA: 0x001B3BD0 File Offset: 0x001B1DD0
	public void TranqCheck()
	{
		if (!this.StopChecking && !this.CannotKidnap && this.TranquilizerIcon.spriteName == "Yes" && this.FollowerIcon.spriteName == "Yes" && this.BiologyIcon.spriteName == "Yes" && this.SyringeIcon.spriteName == "Yes" && this.DoorIcon.spriteName == "Yes")
		{
			AudioSource component = base.GetComponent<AudioSource>();
			component.clip = this.TranqClips[UnityEngine.Random.Range(0, this.TranqClips.Length)];
			component.Play();
			this.Door.Prompt.Hide();
			this.Door.Prompt.enabled = false;
			this.Door.enabled = false;
			if (this.Yandere.Inventory.Tranquilizer)
			{
				this.Yandere.Inventory.Tranquilizer = false;
			}
			else
			{
				this.Yandere.Inventory.Sedative = false;
			}
			if (!this.Yandere.Follower.Male)
			{
				this.Yandere.CanTranq = true;
			}
			this.Yandere.EquippedWeapon.Type = WeaponType.Syringe;
			this.Yandere.AttackManager.Stealth = true;
			this.StopChecking = true;
		}
	}

	// Token: 0x06001EF8 RID: 7928 RVA: 0x001B3D48 File Offset: 0x001B1F48
	public void GarroteAttack()
	{
		AudioSource component = base.GetComponent<AudioSource>();
		component.clip = this.TranqClips[UnityEngine.Random.Range(0, this.TranqClips.Length)];
		component.Play();
		this.Yandere.EquippedWeapon.Type = WeaponType.Syringe;
		this.Yandere.AttackManager.Stealth = true;
		this.StopChecking = true;
	}

	// Token: 0x04004057 RID: 16471
	public YandereScript Yandere;

	// Token: 0x04004058 RID: 16472
	public DoorScript Door;

	// Token: 0x04004059 RID: 16473
	public UIPanel Checklist;

	// Token: 0x0400405A RID: 16474
	public Collider MyCollider;

	// Token: 0x0400405B RID: 16475
	public UILabel KidnappingLabel;

	// Token: 0x0400405C RID: 16476
	public UISprite TranquilizerIcon;

	// Token: 0x0400405D RID: 16477
	public UISprite FollowerIcon;

	// Token: 0x0400405E RID: 16478
	public UISprite BiologyIcon;

	// Token: 0x0400405F RID: 16479
	public UISprite SyringeIcon;

	// Token: 0x04004060 RID: 16480
	public UISprite DoorIcon;

	// Token: 0x04004061 RID: 16481
	public bool StopChecking;

	// Token: 0x04004062 RID: 16482
	public bool CannotKidnap;

	// Token: 0x04004063 RID: 16483
	public int BasementPrisoner;

	// Token: 0x04004064 RID: 16484
	public AudioClip[] TranqClips;
}
