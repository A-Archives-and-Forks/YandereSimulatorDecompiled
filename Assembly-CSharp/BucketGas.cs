﻿// Decompiled with JetBrains decompiler
// Type: BucketGas
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

[Serializable]
public class BucketGas : BucketContents
{
  public override BucketContentsType Type => BucketContentsType.Gas;

  public override bool IsCleaningAgent => false;

  public override bool IsFlammable => true;

  public override bool CanBeLifted(int strength) => true;
}
