﻿using System;
using UnityEngine;

// Token: 0x0200038D RID: 909
public class PaintBucketScript : MonoBehaviour
{
	// Token: 0x06001A37 RID: 6711 RVA: 0x00115CFC File Offset: 0x00113EFC
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (this.Prompt.Yandere.StudentManager.OriginalUniforms + this.Prompt.Yandere.StudentManager.NewUniforms > 1)
			{
				if (this.Prompt.Yandere.Bloodiness == 0f)
				{
					this.Prompt.Yandere.Police.RedPaintClothing++;
					this.Prompt.Yandere.Bloodiness += 100f;
					this.Prompt.Yandere.RedPaint = true;
					return;
				}
			}
			else if (!this.Prompt.Yandere.ClothingWarning)
			{
				this.Prompt.Yandere.NotificationManager.CustomText = "Can't do that; no spare clothing";
				this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
				this.Prompt.Yandere.StudentManager.TutorialWindow.ShowClothingMessage = true;
				this.Prompt.Yandere.ClothingWarning = true;
			}
		}
	}

	// Token: 0x04002ADE RID: 10974
	public PromptScript Prompt;
}
