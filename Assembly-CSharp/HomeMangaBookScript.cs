﻿// Decompiled with JetBrains decompiler
// Type: HomeMangaBookScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class HomeMangaBookScript : MonoBehaviour
{
  public HomeMangaScript Manga;
  public float RotationSpeed;
  public int ID;
  public Renderer MyRenderer;
  public Texture EightiesCover;
  public Texture EightiesBack;
  public Texture EightiesSpine;

  private void Start()
  {
    this.transform.eulerAngles = new Vector3(90f, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
    if (!((Object) this.MyRenderer != (Object) null) || this.ID >= 10 || !GameGlobals.Eighties)
      return;
    this.MyRenderer.materials[0].mainTexture = this.EightiesCover;
    this.MyRenderer.materials[1].mainTexture = this.EightiesBack;
    this.MyRenderer.materials[2].mainTexture = this.EightiesSpine;
  }

  private void Update() => this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.Manga.Selected == this.ID ? this.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed : 0.0f, this.transform.eulerAngles.z);
}
