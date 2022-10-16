﻿// Decompiled with JetBrains decompiler
// Type: WaterBob
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteAlways]
public class WaterBob : MonoBehaviour
{
  [SerializeField]
  private float height = 0.1f;
  [SerializeField]
  private float period = 1f;
  private Vector3 initialPosition;
  private float offset;

  private void Awake()
  {
    this.initialPosition = this.transform.position;
    this.offset = (float) (1.0 - (double) Random.value * 2.0);
  }

  private void Update() => this.transform.position = this.initialPosition - Vector3.up * Mathf.Sin((Time.time + this.offset) * this.period) * this.height;
}
