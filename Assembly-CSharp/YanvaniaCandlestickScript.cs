﻿// Decompiled with JetBrains decompiler
// Type: YanvaniaCandlestickScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class YanvaniaCandlestickScript : MonoBehaviour
{
  public GameObject DestroyedCandlestick;
  public bool Destroyed;
  public AudioClip Break;

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.layer != 19 || this.Destroyed)
      return;
    Object.Instantiate<GameObject>(this.DestroyedCandlestick, this.transform.position, Quaternion.identity).transform.localScale = this.transform.localScale;
    this.Destroyed = true;
    AudioClipPlayer.Play2D(this.Break, this.transform.position);
    Object.Destroy((Object) this.gameObject);
  }
}
