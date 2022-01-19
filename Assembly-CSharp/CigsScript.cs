﻿using System;
using UnityEngine;

// Token: 0x02000246 RID: 582
public class CigsScript : MonoBehaviour
{
	// Token: 0x0600124F RID: 4687 RVA: 0x0008C93C File Offset: 0x0008AB3C
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			SchemeGlobals.SetSchemeStage(3, 3);
			this.Prompt.Yandere.Inventory.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.Cigs = true;
			this.Prompt.Yandere.TheftTimer = 0.1f;
			UnityEngine.Object.Destroy(base.gameObject);
			this.Prompt.Yandere.StudentManager.TaskManager.CheckTaskPickups();
			this.Prompt.Yandere.StolenObjectID = 1;
			Debug.Log("Yandere-chan just grabbed a box of cigarettes.");
		}
	}

	// Token: 0x04001719 RID: 5913
	public PromptScript Prompt;
}
