﻿// Decompiled with JetBrains decompiler
// Type: StudentPortraitScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class StudentPortraitScript : MonoBehaviour
{
  public GameObject DeathShadow;
  public GameObject PrisonBars;
  public GameObject Panties;
  public GameObject Friend;
  public UITexture Portrait;

  private void Start()
  {
    this.DeathShadow.SetActive(false);
    this.PrisonBars.SetActive(false);
    this.Panties.SetActive(false);
    this.Friend.SetActive(false);
  }
}
