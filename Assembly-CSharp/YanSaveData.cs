﻿// Decompiled with JetBrains decompiler
// Type: YanSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

[Serializable]
public struct YanSaveData
{
  public string LoadedLevelName;
  public SerializedGameObject[] SerializedGameObjects;
  public SerializedStaticClass[] SerializedStaticClasses;
  public ValueDict SerializedPlayerPrefs;
}
