﻿// Decompiled with JetBrains decompiler
// Type: TextureCycleScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TextureCycleScript : MonoBehaviour
{
  public UITexture Sprite;
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
  [SerializeField]
  private Texture[] Textures;
  public int ID;

  private void Awake()
  {
  }

  private float SecondsPerFrame => 1f / this.FramesPerSecond;

  private void Update()
  {
    ++this.ID;
    if (this.ID > 1)
    {
      this.ID = 0;
      ++this.Frame;
      if (this.Frame > this.Limit)
        this.Frame = this.Start;
    }
    this.Sprite.mainTexture = this.Textures[this.Frame];
  }
}
