﻿using System;
using UnityEngine;

// Token: 0x020004CF RID: 1231
public class YandereShoverScript : MonoBehaviour
{
	// Token: 0x0600207B RID: 8315 RVA: 0x001DDB2C File Offset: 0x001DBD2C
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.layer == 13)
		{
			bool flag = false;
			if (this.PreventNudity)
			{
				if (this.Yandere.Schoolwear == 0)
				{
					flag = true;
					if (this.Yandere.NotificationManager.NotificationParent.childCount == 0)
					{
						this.Yandere.NotificationManager.CustomText = "Get dressed first!";
						this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
					}
				}
			}
			else
			{
				flag = true;
				if (this.Yandere.NotificationManager.NotificationParent.childCount == 0)
				{
					this.Yandere.NotificationManager.CustomText = "That's the boys' locker room!";
					this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				}
			}
			if (flag)
			{
				if (this.Yandere.Aiming)
				{
					this.Yandere.StopAiming();
				}
				if (this.Yandere.Laughing)
				{
					this.Yandere.StopLaughing();
				}
				this.Yandere.transform.rotation = Quaternion.LookRotation(new Vector3(base.transform.position.x, this.Yandere.transform.position.y, base.transform.position.z) - this.Yandere.transform.position);
				this.Yandere.CharacterAnimation["f02_shoveA_01"].time = 0f;
				this.Yandere.CharacterAnimation.CrossFade("f02_shoveA_01");
				this.Yandere.YandereVision = false;
				this.Yandere.NearSenpai = false;
				this.Yandere.Degloving = false;
				this.Yandere.Flicking = false;
				this.Yandere.Punching = false;
				this.Yandere.CanMove = false;
				this.Yandere.Shoved = true;
				this.Yandere.EmptyHands();
				this.Yandere.GloveTimer = 0f;
				this.Yandere.h = 0f;
				this.Yandere.v = 0f;
				this.Yandere.ShoveSpeed = 2f;
			}
			if (this.Yandere.Talking)
			{
				this.Yandere.transform.position = new Vector3(14f, 0f, -12f);
			}
		}
	}

	// Token: 0x04004723 RID: 18211
	public YandereScript Yandere;

	// Token: 0x04004724 RID: 18212
	public bool PreventNudity;
}
