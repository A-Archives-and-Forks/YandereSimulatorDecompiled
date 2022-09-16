﻿// Decompiled with JetBrains decompiler
// Type: DetectionMarkerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[Serializable]
public class DetectionMarkerScript : MonoBehaviour
{
  public Transform Target;
  public UITexture Tex;

  private void Start()
  {
    this.transform.LookAt(new Vector3(this.Target.position.x, this.transform.position.y, this.Target.position.z));
    this.Tex.transform.localScale = new Vector3(1f, 0.0f, 1f);
    this.transform.localScale = new Vector3(1f, 1f, 1f);
    this.Tex.color = new Color(this.Tex.color.r, this.Tex.color.g, this.Tex.color.b, 0.0f);
  }

  private void Update()
  {
    if ((double) this.Tex.color.a <= 0.0 || !((UnityEngine.Object) this.transform != (UnityEngine.Object) null) || !((UnityEngine.Object) this.Target != (UnityEngine.Object) null))
      return;
    this.transform.LookAt(new Vector3(this.Target.position.x, this.transform.position.y, this.Target.position.z));
  }
}
