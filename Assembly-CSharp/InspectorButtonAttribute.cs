﻿// Decompiled with JetBrains decompiler
// Type: InspectorButtonAttribute
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Field)]
public class InspectorButtonAttribute : PropertyAttribute
{
  public static float kDefaultButtonWidth = 150f;
  public readonly string MethodName;
  private float _buttonWidth = InspectorButtonAttribute.kDefaultButtonWidth;

  public float ButtonWidth
  {
    get => this._buttonWidth;
    set => this._buttonWidth = value;
  }

  public InspectorButtonAttribute(string MethodName) => this.MethodName = MethodName;
}
