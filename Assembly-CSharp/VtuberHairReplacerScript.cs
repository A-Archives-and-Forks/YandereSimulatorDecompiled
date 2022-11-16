﻿// Decompiled with JetBrains decompiler
// Type: VtuberHairReplacerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class VtuberHairReplacerScript : MonoBehaviour
{
  public GameObject YandereHair;
  public GameObject[] VtuberHair;

  private void Start()
  {
    if (GameGlobals.VtuberID > 0)
    {
      this.YandereHair.SetActive(false);
      this.VtuberHair[GameGlobals.VtuberID].SetActive(true);
    }
    else
      this.VtuberHair[1].SetActive(false);
  }
}
