﻿// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.FoodInstance
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace MaidDereMinigame
{
  [RequireComponent(typeof (SpriteRenderer))]
  public class FoodInstance : MonoBehaviour
  {
    public Food food;
    public Meter warmthMeter;
    public float timeToCool = 30f;
    [HideInInspector]
    public SpriteRenderer spriteRenderer;
    private float heat;

    private void Start()
    {
      this.spriteRenderer = this.GetComponent<SpriteRenderer>();
      this.spriteRenderer.sprite = this.food.smallSprite;
      this.heat = this.timeToCool;
    }

    private void Update()
    {
      this.heat -= Time.deltaTime;
      this.warmthMeter.SetFill(this.heat / this.timeToCool);
    }

    public void SetHeat(float newHeat) => this.heat = newHeat;
  }
}
