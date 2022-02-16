﻿using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x02000598 RID: 1432
	[RequireComponent(typeof(Camera))]
	public class CameraForcedAspect : MonoBehaviour
	{
		// Token: 0x0600244E RID: 9294 RVA: 0x001FA664 File Offset: 0x001F8864
		private void Awake()
		{
			this.cam = base.GetComponent<Camera>();
		}

		// Token: 0x0600244F RID: 9295 RVA: 0x001FA674 File Offset: 0x001F8874
		private void Start()
		{
			float num = this.targetAspect.x / this.targetAspect.y;
			float num2 = (float)Screen.width / (float)Screen.height / num;
			if (num2 < 1f)
			{
				Rect rect = this.cam.rect;
				rect.width = 1f;
				rect.height = num2;
				rect.x = 0f;
				rect.y = (1f - num2) / 2f;
				this.cam.rect = rect;
				return;
			}
			Rect rect2 = this.cam.rect;
			float num3 = 1f / num2;
			rect2.width = num3;
			rect2.height = 1f;
			rect2.x = (1f - num3) / 2f;
			rect2.y = 0f;
			this.cam.rect = rect2;
		}

		// Token: 0x04004C21 RID: 19489
		public Vector2 targetAspect = new Vector2(16f, 9f);

		// Token: 0x04004C22 RID: 19490
		private Camera cam;
	}
}
