﻿// Decompiled with JetBrains decompiler
// Type: NurseScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
