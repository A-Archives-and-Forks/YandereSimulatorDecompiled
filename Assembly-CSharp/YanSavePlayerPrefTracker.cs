﻿// Decompiled with JetBrains decompiler
// Type: YanSavePlayerPrefTracker
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

[Serializable]
public struct YanSavePlayerPrefTracker
{
  public List<string> PrefFormatValues;
  public YanSavePlayerPrefsType PrefType;
  public string PrefFormat;
  public int RangeMax;
}
