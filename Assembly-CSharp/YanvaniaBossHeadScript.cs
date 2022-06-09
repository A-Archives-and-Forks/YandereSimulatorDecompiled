﻿// Decompiled with JetBrains decompiler
// Type: YanvaniaBossHeadScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class YanvaniaBossHeadScript : MonoBehaviour
{
  public YanvaniaDraculaScript Dracula;
  public GameObject HitEffect;
  public float Timer;

  private void Update() => this.Timer -= Time.deltaTime;

  private void OnTriggerEnter(Collider other)
  {
    if ((double) this.Timer > 0.0 || !((Object) this.Dracula.NewTeleportEffect == (Object) null) || !(other.gameObject.name == "Heart"))
      return;
    Object.Instantiate<GameObject>(this.HitEffect, this.transform.position, Quaternion.identity);
    this.Timer = 1f;
    this.Dracula.TakeDamage();
  }
}
