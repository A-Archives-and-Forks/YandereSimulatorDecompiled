﻿// Decompiled with JetBrains decompiler
// Type: NurseScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class NurseScript : MonoBehaviour
{
  public GameObject Character;
  public Transform SkirtCenter;

  private void Awake()
  {
    Animation component = this.Character.GetComponent<Animation>();
    component["f02_noBlink_00"].layer = 1;
    component.Blend("f02_noBlink_00");
  }

  private void LateUpdate() => this.SkirtCenter.localEulerAngles = new Vector3(-15f, this.SkirtCenter.localEulerAngles.y, this.SkirtCenter.localEulerAngles.z);
}
