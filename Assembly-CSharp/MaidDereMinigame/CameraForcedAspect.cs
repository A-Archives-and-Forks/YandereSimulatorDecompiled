﻿using System;
using UnityEngine;

namespace MaidDereMinigame
{
	// Token: 0x020005A6 RID: 1446
	[RequireComponent(typeof(Camera))]
	public class CameraForcedAspect : MonoBehaviour
	{
		// Token: 0x060024A9 RID: 9385 RVA: 0x00203510 File Offset: 0x00201710
		private void Awake()
		{
			this.cam = base.GetComponent<Camera>();
		}

		// Token: 0x060024AA RID: 9386 RVA: 0x00203520 File Offset: 0x00201720
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

		// Token: 0x04004D3E RID: 19774
		public Vector2 targetAspect = new Vector2(16f, 9f);

		// Token: 0x04004D3F RID: 19775
		private Camera cam;
	}
}
