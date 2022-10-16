﻿// Decompiled with JetBrains decompiler
// Type: BlendShapeRemover
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
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
