﻿// Decompiled with JetBrains decompiler
// Type: BlendShapeRemover
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BlendShapeRemover : MonoBehaviour
{
  public SkinnedMeshRenderer SelectedMesh;

  private void Awake()
  {
    if (SystemInfo.supportsComputeShaders)
      return;
    this.SelectedMesh.sharedMesh.ClearBlendShapes();
  }
}
