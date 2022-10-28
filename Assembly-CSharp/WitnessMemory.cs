﻿// Decompiled with JetBrains decompiler
// Type: WitnessMemory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[Serializable]
public class WitnessMemory
{
  [SerializeField]
  private float[] memories;
  [SerializeField]
  private float memorySpan;
  private const float LongMemorySpan = 28800f;
  private const float MediumMemorySpan = 7200f;
  private const float ShortMemorySpan = 1800f;
  private const float VeryShortMemorySpan = 120f;

  public WitnessMemory()
  {
    this.memories = new float[Enum.GetValues(typeof (WitnessMemoryType)).Length];
    for (int index = 0; index < this.memories.Length; ++index)
      this.memories[index] = float.PositiveInfinity;
    this.memorySpan = 1800f;
  }

  public bool Remembers(WitnessMemoryType type) => (double) this.memories[(int) type] < (double) this.memorySpan;

  public void Refresh(WitnessMemoryType type) => this.memories[(int) type] = 0.0f;

  public void Tick(float dt)
  {
    for (int index = 0; index < this.memories.Length; ++index)
      this.memories[index] += dt;
  }
}
