﻿// Decompiled with JetBrains decompiler
// Type: CreepyArmScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CreepyArmScript : MonoBehaviour
{
  private void Update() => this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + Time.deltaTime * 0.1f, this.transform.position.z);
}
