﻿// Decompiled with JetBrains decompiler
// Type: MoneyWadScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MoneyWadScript : MonoBehaviour
{
  public PromptScript Prompt;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    this.Prompt.Yandere.Inventory.Money += 20f;
    this.Prompt.Yandere.Inventory.UpdateMoney();
    if ((double) this.Prompt.Yandere.Inventory.Money > 1000.0 && !GameGlobals.Debug)
      PlayerPrefs.SetInt("RichGirl", 1);
    Object.Destroy((Object) this.gameObject);
  }
}
