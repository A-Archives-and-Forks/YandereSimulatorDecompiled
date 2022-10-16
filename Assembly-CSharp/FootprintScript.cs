﻿// Decompiled with JetBrains decompiler
// Type: FootprintScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class FootprintScript : MonoBehaviour
{
  public YandereScript Yandere;
  public Texture Footprint;
  public Texture Flower;
  public int StudentBloodID;

  private void Start()
  {
    if (this.Yandere.Schoolwear == 0 || this.Yandere.Schoolwear == 2 || this.Yandere.ClubAttire && this.Yandere.Club == ClubType.MartialArts || this.Yandere.Hungry || this.Yandere.LucyHelmet.activeInHierarchy)
      this.GetComponent<Renderer>().material.mainTexture = this.Footprint;
    if (!GameGlobals.CensorBlood)
      return;
    this.GetComponent<Renderer>().material.mainTexture = this.Flower;
    this.transform.localScale = new Vector3(0.2f, 0.2f, 1f);
  }
}
