﻿// Decompiled with JetBrains decompiler
// Type: UIShowControlScheme
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class UIShowControlScheme : MonoBehaviour
{
  public GameObject target;
  public bool mouse;
  public bool touch;
  public bool controller = true;

  private void OnEnable()
  {
    UICamera.onSchemeChange += new UICamera.OnSchemeChange(this.OnScheme);
    this.OnScheme();
  }

  private void OnDisable() => UICamera.onSchemeChange -= new UICamera.OnSchemeChange(this.OnScheme);

  private void OnScheme()
  {
    if (!((Object) this.target != (Object) null))
      return;
    switch (UICamera.currentScheme)
    {
      case UICamera.ControlScheme.Mouse:
        this.target.SetActive(this.mouse);
        break;
      case UICamera.ControlScheme.Touch:
        this.target.SetActive(this.touch);
        break;
      case UICamera.ControlScheme.Controller:
        this.target.SetActive(this.controller);
        break;
    }
  }
}
