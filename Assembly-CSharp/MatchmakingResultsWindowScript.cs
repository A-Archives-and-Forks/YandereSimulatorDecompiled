﻿// Decompiled with JetBrains decompiler
// Type: MatchmakingResultsWindowScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MatchmakingResultsWindowScript : MonoBehaviour
{
  public AdviceWindowScript AdviceWindow;

  private void Update()
  {
    if (!Input.GetButtonDown("B"))
      return;
    this.AdviceWindow.HUDElement[1].SetActive(true);
    this.AdviceWindow.HUDElement[2].SetActive(true);
    this.AdviceWindow.HUDElement[3].SetActive(true);
    this.gameObject.SetActive(false);
    Time.timeScale = 1f;
  }
}
