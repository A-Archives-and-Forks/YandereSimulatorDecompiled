﻿// Decompiled with JetBrains decompiler
// Type: VtuberHairReplacerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
