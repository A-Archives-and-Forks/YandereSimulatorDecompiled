﻿// Decompiled with JetBrains decompiler
// Type: MGPMPickUpScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MGPMPickUpScript : MonoBehaviour
{
  public float Speed;

  private void Update()
  {
    this.transform.Translate(Vector3.up * Time.deltaTime * this.Speed * -1f);
    if ((double) this.transform.localPosition.y >= -300.0)
      return;
    Object.Destroy((Object) this.gameObject);
  }
}
