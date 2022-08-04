﻿// Decompiled with JetBrains decompiler
// Type: CautionScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CautionScript : MonoBehaviour
{
  public YandereScript Yandere;
  public UISprite Sprite;

  private void Start()
  {
    this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0.0f);
    if (!GameGlobals.EightiesTutorial)
      return;
    this.gameObject.SetActive(false);
  }

  private void Update()
  {
    if (this.Yandere.Armed && this.Yandere.EquippedWeapon.Suspicious || (double) this.Yandere.Bloodiness > 0.0 || (double) this.Yandere.Sanity < 33.333332061767578 || this.Yandere.NearBodies > 0)
    {
      this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, this.Sprite.color.a + Time.deltaTime);
      if ((double) this.Sprite.color.a <= 1.0)
        return;
      this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 1f);
    }
    else
    {
      this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, this.Sprite.color.a - Time.deltaTime);
      if ((double) this.Sprite.color.a >= 0.0)
        return;
      this.Sprite.color = new Color(this.Sprite.color.r, this.Sprite.color.g, this.Sprite.color.b, 0.0f);
    }
  }
}
