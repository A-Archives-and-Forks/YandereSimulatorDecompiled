﻿using System;
using UnityEngine;

// Token: 0x02000039 RID: 57
[RequireComponent(typeof(UIWidget))]
public class SetColorPickerColor : MonoBehaviour
{
	// Token: 0x060000E8 RID: 232 RVA: 0x00012BAF File Offset: 0x00010DAF
	public void SetToCurrent()
	{
		if (this.mWidget == null)
		{
			this.mWidget = base.GetComponent<UIWidget>();
		}
		if (UIColorPicker.current != null)
		{
			this.mWidget.color = UIColorPicker.current.value;
		}
	}

	// Token: 0x040002AE RID: 686
	[NonSerialized]
	private UIWidget mWidget;
}
