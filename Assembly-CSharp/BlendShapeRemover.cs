﻿// Decompiled with JetBrains decompiler
// Type: BlendShapeRemover
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
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
