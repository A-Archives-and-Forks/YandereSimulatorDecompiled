﻿// Decompiled with JetBrains decompiler
// Type: ExpressionMaskScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ExpressionMaskScript : MonoBehaviour
{
  public Renderer Mask;
  public int ID;

  private void Update()
  {
    if (!Input.GetKeyDown(KeyCode.LeftAlt))
      return;
    if (this.ID < 3)
      ++this.ID;
    else
      this.ID = 0;
    switch (this.ID)
    {
      case 0:
        this.Mask.material.mainTextureOffset = Vector2.zero;
        break;
      case 1:
        this.Mask.material.mainTextureOffset = new Vector2(0.0f, 0.5f);
        break;
      case 2:
        this.Mask.material.mainTextureOffset = new Vector2(0.5f, 0.0f);
        break;
      case 3:
        this.Mask.material.mainTextureOffset = new Vector2(0.5f, 0.5f);
        break;
    }
  }
}
