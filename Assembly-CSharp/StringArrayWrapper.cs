﻿// Decompiled with JetBrains decompiler
// Type: StringArrayWrapper
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

[Serializable]
public class StringArrayWrapper : ArrayWrapper<string>
{
  public StringArrayWrapper(int size)
    : base(size)
  {
  }

  public StringArrayWrapper(string[] elements)
    : base(elements)
  {
  }
}
