﻿// Decompiled with JetBrains decompiler
// Type: SpinScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SpinScript : MonoBehaviour
{
  public float X;
  public float Y;
  public float Z;
  private float RotationX;
  private float RotationY;
  private float RotationZ;

  private void Update()
  {
    this.RotationX += this.X * Time.deltaTime;
    this.RotationY += this.Y * Time.deltaTime;
    this.RotationZ += this.Z * Time.deltaTime;
    this.transform.localEulerAngles = new Vector3(this.RotationX, this.RotationY, this.RotationZ);
  }
}
