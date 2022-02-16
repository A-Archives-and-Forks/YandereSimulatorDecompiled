﻿using System;
using UnityEngine;

// Token: 0x02000383 RID: 899
public class ObstacleDetectorScript : MonoBehaviour
{
	// Token: 0x06001A1F RID: 6687 RVA: 0x00112DB8 File Offset: 0x00110FB8
	private void Update()
	{
		this.Frame++;
		if (this.Frame == 3)
		{
			this.Frame = 0;
			this.Obstacles = 0;
			base.gameObject.SetActive(false);
			return;
		}
		if (this.Frame != 2)
		{
			int frame = this.Frame;
			return;
		}
		if (this.Obstacles > 0)
		{
			this.Yandere.NotificationManager.CustomText = "Something's in the way.";
			this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			this.Yandere.NotificationManager.CustomText = "You can't set the cello case down here.";
			this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			return;
		}
		this.Frame = 0;
		this.Yandere.Container.Drop();
		this.Yandere.WeaponMenu.UpdateSprites();
		base.gameObject.SetActive(false);
	}

	// Token: 0x06001A20 RID: 6688 RVA: 0x00112E98 File Offset: 0x00111098
	private void OnTriggerEnter(Collider other)
	{
		if (this.Yandere.Container.CelloCase && other.gameObject.layer != 1 && other.gameObject.layer != 2 && other.gameObject.layer != 8 && other.gameObject.layer != 13 && other.gameObject.layer != 14)
		{
			Debug.Log("Obstacle detected: " + other.gameObject.name + ". It's on Layer: " + other.gameObject.layer.ToString());
			this.Obstacles++;
		}
	}

	// Token: 0x04002A86 RID: 10886
	public YandereScript Yandere;

	// Token: 0x04002A87 RID: 10887
	public int Obstacles;

	// Token: 0x04002A88 RID: 10888
	public int Frame;

	// Token: 0x04002A89 RID: 10889
	public int ID;
}
