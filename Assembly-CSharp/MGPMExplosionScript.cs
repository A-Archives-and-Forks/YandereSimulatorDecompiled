﻿// Decompiled with JetBrains decompiler
// Type: MGPMExplosionScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MGPMExplosionScript : MonoBehaviour
{
  public Renderer MyRenderer;
  public Texture[] Sprite;
  public float Timer;
  public float FPS;
  public int Frame;

  private void Update()
  {
    this.Timer += Time.deltaTime;
    if ((double) this.Timer <= (double) this.FPS)
      return;
    this.Timer = 0.0f;
    ++this.Frame;
    if (this.Frame == this.Sprite.Length)
      Object.Destroy((Object) this.gameObject);
    else
      this.MyRenderer.material.mainTexture = this.Sprite[this.Frame];
  }
}
