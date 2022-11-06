﻿// Decompiled with JetBrains decompiler
// Type: YanvaniaBigFireballScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class YanvaniaBigFireballScript : MonoBehaviour
{
  public GameObject Explosion;

  private void OnTriggerEnter(Collider other)
  {
    if (!(other.gameObject.name == "YanmontChan"))
      return;
    other.gameObject.GetComponent<YanvaniaYanmontScript>().TakeDamage(15);
    Object.Instantiate<GameObject>(this.Explosion, this.transform.position, Quaternion.identity);
    Object.Destroy((Object) this.gameObject);
  }
}
