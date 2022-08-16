﻿// Decompiled with JetBrains decompiler
// Type: AmplifyMotionPostProcess
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("")]
[RequireComponent(typeof (Camera))]
public sealed class AmplifyMotionPostProcess : MonoBehaviour
{
  private AmplifyMotionEffectBase m_instance;

  public AmplifyMotionEffectBase Instance
  {
    get => this.m_instance;
    set => this.m_instance = value;
  }

  private void OnRenderImage(RenderTexture source, RenderTexture destination)
  {
    if (!((Object) this.m_instance != (Object) null))
      return;
    this.m_instance.PostProcess(source, destination);
  }
}
