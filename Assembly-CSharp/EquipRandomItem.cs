﻿// Decompiled with JetBrains decompiler
// Type: EquipRandomItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("NGUI/Examples/Equip Random Item")]
public class EquipRandomItem : MonoBehaviour
{
  public InvEquipment equipment;

  private void OnClick()
  {
    if ((Object) this.equipment == (Object) null)
      return;
    List<InvBaseItem> items = InvDatabase.list[0].items;
    if (items.Count == 0)
      return;
    int maxExclusive = 12;
    int num = Random.Range(0, items.Count);
    InvBaseItem bi = items[num];
    this.equipment.Equip(new InvGameItem(num, bi)
    {
      quality = (InvGameItem.Quality) Random.Range(0, maxExclusive),
      itemLevel = NGUITools.RandomRange(bi.minItemLevel, bi.maxItemLevel)
    });
  }
}
