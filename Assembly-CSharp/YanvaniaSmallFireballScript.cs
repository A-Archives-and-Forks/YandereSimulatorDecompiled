﻿// Decompiled with JetBrains decompiler
// Type: YanvaniaSmallFireballScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class YanvaniaSmallFireballScript : MonoBehaviour
{
  public GameObject Explosion;

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.name == "Heart")
    {
      Object.Instantiate<GameObject>(this.Explosion, this.transform.position, Quaternion.identity);
      Object.Destroy((Object) this.gameObject);
    }
    if (!(other.gameObject.name == "YanmontChan"))
      return;
    other.gameObject.GetComponent<YanvaniaYanmontScript>().TakeDamage(10);
    Object.Instantiate<GameObject>(this.Explosion, this.transform.position, Quaternion.identity);
    Object.Destroy((Object) this.gameObject);
  }
}
