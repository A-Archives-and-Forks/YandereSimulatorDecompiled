﻿// Decompiled with JetBrains decompiler
// Type: Player
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class Player : MonoBehaviour
{
  public float moveSpeed = 20f;
  public float rotationSpeed = 30f;

  private void Start()
  {
  }

  private void Update()
  {
    this.transform.Translate(Vector3.forward * this.moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
    this.transform.Rotate(Vector3.up * this.rotationSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
  }
}
