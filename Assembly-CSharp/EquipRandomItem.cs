﻿using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000021 RID: 33
[AddComponentMenu("NGUI/Examples/Equip Random Item")]
public class EquipRandomItem : MonoBehaviour
{
	// Token: 0x06000083 RID: 131 RVA: 0x00010EA8 File Offset: 0x0000F0A8
	private void OnClick()
	{
		if (this.equipment == null)
		{
			return;
		}
		List<InvBaseItem> items = InvDatabase.list[0].items;
		if (items.Count == 0)
		{
			return;
		}
		int maxExclusive = 12;
		int num = UnityEngine.Random.Range(0, items.Count);
		InvBaseItem invBaseItem = items[num];
		InvGameItem invGameItem = new InvGameItem(num, invBaseItem);
		invGameItem.quality = (InvGameItem.Quality)UnityEngine.Random.Range(0, maxExclusive);
		invGameItem.itemLevel = NGUITools.RandomRange(invBaseItem.minItemLevel, invBaseItem.maxItemLevel);
		this.equipment.Equip(invGameItem);
	}

	// Token: 0x04000254 RID: 596
	public InvEquipment equipment;
}
