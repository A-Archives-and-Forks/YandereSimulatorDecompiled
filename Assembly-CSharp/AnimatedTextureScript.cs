﻿// Decompiled with JetBrains decompiler
// Type: AnimatedTextureScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class AnimatedTextureScript : MonoBehaviour
{
  [SerializeField]
  private Renderer MyRenderer;
  [SerializeField]
  private int Start;
  [SerializeField]
  private int Frame;
  [SerializeField]
  private int Limit;
  [SerializeField]
  private float FramesPerSecond;
  [SerializeField]
  private float CurrentSeconds;
  public Texture[] Image;

  private void Awake()
  {
  }

  private float SecondsPerFrame => 1f / this.FramesPerSecond;

  private void Update()
  {
    this.CurrentSeconds += Time.unscaledDeltaTime;
    while ((double) this.CurrentSeconds >= (double) this.SecondsPerFrame)
    {
      this.CurrentSeconds -= this.SecondsPerFrame;
      ++this.Frame;
      if (this.Frame > this.Limit)
        this.Frame = this.Start;
    }
    this.MyRenderer.material.mainTexture = this.Image[this.Frame];
  }
}
