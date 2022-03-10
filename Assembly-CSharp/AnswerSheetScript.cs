﻿using System;
using UnityEngine;

// Token: 0x020000CB RID: 203
public class AnswerSheetScript : MonoBehaviour
{
	// Token: 0x060009C2 RID: 2498 RVA: 0x0005135F File Offset: 0x0004F55F
	private void Start()
	{
		this.OriginalMesh = this.MyMesh.mesh;
		if (DateGlobals.Weekday != DayOfWeek.Friday)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	// Token: 0x060009C3 RID: 2499 RVA: 0x00051394 File Offset: 0x0004F594
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			if (this.Phase == 1)
			{
				SchemeGlobals.SetSchemeStage(5, 5);
				this.Schemes.UpdateInstructions();
				this.Prompt.Yandere.Inventory.AnswerSheet = true;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.DoorGap.Prompt.enabled = true;
				this.MyMesh.mesh = null;
				this.Phase++;
				return;
			}
			SchemeGlobals.SetSchemeStage(5, 8);
			this.Schemes.UpdateInstructions();
			this.Prompt.Yandere.Inventory.AnswerSheet = false;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.MyMesh.mesh = this.OriginalMesh;
			this.Phase++;
		}
	}

	// Token: 0x04000A27 RID: 2599
	public SchemesScript Schemes;

	// Token: 0x04000A28 RID: 2600
	public DoorGapScript DoorGap;

	// Token: 0x04000A29 RID: 2601
	public PromptScript Prompt;

	// Token: 0x04000A2A RID: 2602
	public ClockScript Clock;

	// Token: 0x04000A2B RID: 2603
	public Mesh OriginalMesh;

	// Token: 0x04000A2C RID: 2604
	public MeshFilter MyMesh;

	// Token: 0x04000A2D RID: 2605
	public int Phase = 1;
}
