﻿// Decompiled with JetBrains decompiler
// Type: SerializedComponent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

[Serializable]
public struct SerializedComponent
{
  public string OwnerID;
  public string TypePath;
  public ValueDict PropertyValues;
  public ReferenceDict PropertyReferences;
  public ValueDict FieldValues;
  public ReferenceDict FieldReferences;
  public ReferenceArrayDict PropertyReferenceArrays;
  public ReferenceArrayDict FieldReferenceArrays;
  public bool IsEnabled;
  public bool IsMonoBehaviour;
}
