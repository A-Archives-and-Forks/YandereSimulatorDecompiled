﻿// Decompiled with JetBrains decompiler
// Type: SecurityCameraManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SecurityCameraManagerScript : MonoBehaviour
{
  public GameObject[] Cameras;

  private void Start()
  {
    for (int index = !SchoolGlobals.HighSecurity ? PlayerGlobals.CorpsesDiscovered : this.Cameras.Length; index > 0; --index)
    {
      if (index < this.Cameras.Length)
        this.Cameras[index].SetActive(true);
    }
  }

  public void ActivateAllCameras()
  {
    for (int length = this.Cameras.Length; length > 0; --length)
    {
      if (length < this.Cameras.Length)
        this.Cameras[length].SetActive(true);
    }
  }
}
