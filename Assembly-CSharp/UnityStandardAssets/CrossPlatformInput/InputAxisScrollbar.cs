﻿// Decompiled with JetBrains decompiler
// Type: UnityStandardAssets.CrossPlatformInput.InputAxisScrollbar
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
  public class InputAxisScrollbar : MonoBehaviour
  {
    public string axis;

    private void Update()
    {
    }

    public void HandleInput(float value) => CrossPlatformInputManager.SetAxis(this.axis, (float) ((double) value * 2.0 - 1.0));
  }
}
