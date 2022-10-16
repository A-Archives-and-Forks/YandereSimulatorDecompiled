﻿// Decompiled with JetBrains decompiler
// Type: PerspectivePixelPerfect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

public class PerspectivePixelPerfect : MonoBehaviour
{
  [Tooltip("Bias is a value above 0 that determines how far offset the object will be from the near clip, in percent (near to far clip)")]
  public float bias = 1f / 1000f;

  [ContextMenu("Execute")]
  private void Start()
  {
    Transform transform = this.transform;
    Camera main = Camera.main;
    float z = Mathf.Lerp(main.nearClipPlane, main.farClipPlane, this.bias);
    float num = Mathf.Tan((float) (Math.PI / 180.0 * (double) main.fieldOfView * 0.5)) * z;
    transform.localPosition = new Vector3(0.0f, 0.0f, z);
    transform.localScale = new Vector3(num, num, 1f);
  }
}
