﻿// Decompiled with JetBrains decompiler
// Type: LookAtCamera
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
  public Camera cameraToLookAt;

  private void Start()
  {
    if (!((Object) this.cameraToLookAt == (Object) null))
      return;
    this.cameraToLookAt = Camera.main;
  }

  private void Update() => this.transform.LookAt(this.cameraToLookAt.transform.position - new Vector3(0.0f, this.cameraToLookAt.transform.position.y - this.transform.position.y, 0.0f));
}
