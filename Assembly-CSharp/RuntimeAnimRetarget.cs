﻿// Decompiled with JetBrains decompiler
// Type: RuntimeAnimRetarget
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RuntimeAnimRetarget : MonoBehaviour
{
  public GameObject Source;
  public GameObject Target;
  private Component[] SourceSkelNodes;
  private Component[] TargetSkelNodes;

  private void Start()
  {
    Debug.Log((object) this.Source.name);
    this.SourceSkelNodes = this.Source.GetComponentsInChildren<Component>();
    this.TargetSkelNodes = this.Target.GetComponentsInChildren<Component>();
  }

  private void LateUpdate()
  {
    this.TargetSkelNodes[1].transform.localPosition = this.SourceSkelNodes[1].transform.localPosition;
    for (int index = 0; index < 154; ++index)
      this.TargetSkelNodes[index].transform.localRotation = this.SourceSkelNodes[index].transform.localRotation;
  }
}
