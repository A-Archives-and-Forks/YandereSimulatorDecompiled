﻿// Decompiled with JetBrains decompiler
// Type: BlendShapeRemover
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
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
