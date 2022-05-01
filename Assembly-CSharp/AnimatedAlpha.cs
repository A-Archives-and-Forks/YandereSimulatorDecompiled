﻿using System;
using UnityEngine;

// Token: 0x02000085 RID: 133
[ExecuteInEditMode]
public class AnimatedAlpha : MonoBehaviour
{
	// Token: 0x0600054C RID: 1356 RVA: 0x00033D0F File Offset: 0x00031F0F
	private void OnEnable()
	{
		this.mWidget = base.GetComponent<UIWidget>();
		this.mPanel = base.GetComponent<UIPanel>();
		this.LateUpdate();
	}

	// Token: 0x0600054D RID: 1357 RVA: 0x00033D2F File Offset: 0x00031F2F
	private void LateUpdate()
	{
		if (this.mWidget != null)
		{
			this.mWidget.alpha = this.alpha;
		}
		if (this.mPanel != null)
		{
			this.mPanel.alpha = this.alpha;
		}
	}

	// Token: 0x04000598 RID: 1432
	[Range(0f, 1f)]
	public float alpha = 1f;

	// Token: 0x04000599 RID: 1433
	private UIWidget mWidget;

	// Token: 0x0400059A RID: 1434
	private UIPanel mPanel;
}
