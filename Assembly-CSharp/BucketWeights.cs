﻿// Decompiled with JetBrains decompiler
// Type: BucketWeights
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[Serializable]
public class BucketWeights : BucketContents
{
  [SerializeField]
  private int count;

  public int Count
  {
    get => this.count;
    set => this.count = value < 0 ? 0 : value;
  }

  public override BucketContentsType Type => BucketContentsType.Weights;

  public override bool IsCleaningAgent => false;

  public override bool IsFlammable => false;

  public override bool CanBeLifted(int strength) => strength > 0;
}
