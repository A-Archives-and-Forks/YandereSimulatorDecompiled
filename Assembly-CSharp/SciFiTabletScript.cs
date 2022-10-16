﻿// Decompiled with JetBrains decompiler
// Type: SciFiTabletScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SciFiTabletScript : MonoBehaviour
{
  public StudentScript Student;
  public HologramScript Holograms;
  public Transform Finger;
  public bool Updated;

  private void Start() => this.Holograms = this.Student.StudentManager.Holograms;

  private void Update()
  {
    if ((double) Vector3.Distance(this.Finger.position, this.transform.position) < 0.1)
    {
      if (this.Updated)
        return;
      this.Holograms.UpdateHolograms();
      this.Updated = true;
    }
    else
      this.Updated = false;
  }
}
