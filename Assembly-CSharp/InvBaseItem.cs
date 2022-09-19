﻿// Decompiled with JetBrains decompiler
// Type: InvBaseItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InvBaseItem
{
  public int id16;
  public string name;
  public string description;
  public InvBaseItem.Slot slot;
  public int minItemLevel = 1;
  public int maxItemLevel = 50;
  public List<InvStat> stats = new List<InvStat>();
  public GameObject attachment;
  public Color color = Color.white;
  public UnityEngine.Object iconAtlas;
  public string iconName = "";

  public enum Slot
  {
    None,
    Weapon,
    Shield,
    Body,
    Shoulders,
    Bracers,
    Boots,
    Trinket,
    _LastDoNotUse,
  }
}
