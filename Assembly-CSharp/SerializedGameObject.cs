﻿// Decompiled with JetBrains decompiler
// Type: SerializedGameObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
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
