﻿// Decompiled with JetBrains decompiler
// Type: BefriendBetrayPauseScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BefriendBetrayPauseScript : MonoBehaviour
{
  public StalkerYandereScript Yandere;
  public UIPanel Panel;

  private void Start() => this.Panel.enabled = false;

  private void Update()
  {
    if (!this.Yandere.CanMove || !Input.GetButtonDown("Start"))
      return;
    if (!this.Panel.enabled)
    {
      this.Panel.enabled = true;
      Time.timeScale = 0.0f;
    }
    else
    {
      this.Panel.enabled = false;
      Time.timeScale = 1f;
    }
  }
}
