﻿// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.Vehicles.Car.Mudguard
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
  public class Mudguard : MonoBehaviour
  {
    public CarController carController;
    private Quaternion m_OriginalRotation;

    private void Start() => this.m_OriginalRotation = this.transform.localRotation;

    private void Update() => this.transform.localRotation = this.m_OriginalRotation * Quaternion.Euler(0.0f, this.carController.CurrentSteerAngle, 0.0f);
  }
}
