﻿// Decompiled with JetBrains decompiler
// Type: SerializedGameObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

[Serializable]
public struct SerializedGameObject
{
  public bool ActiveInHierarchy;
  public bool ActiveSelf;
  public bool IsStatic;
  public int Layer;
  public string Tag;
  public string Name;
  public string ObjectID;
  public SerializedComponent[] SerializedComponents;
}
