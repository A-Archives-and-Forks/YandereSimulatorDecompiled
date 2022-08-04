﻿// Decompiled with JetBrains decompiler
// Type: YanvaniaBlackHoleAttackScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class YanvaniaBlackHoleAttackScript : MonoBehaviour
{
  public YanvaniaYanmontScript Yanmont;
  public GameObject BlackExplosion;

  private void Start() => this.Yanmont = GameObject.Find("YanmontChan").GetComponent<YanvaniaYanmontScript>();

  private void Update()
  {
    this.transform.position = Vector3.MoveTowards(this.transform.position, this.Yanmont.transform.position + Vector3.up, Time.deltaTime);
    if ((double) Vector3.Distance(this.transform.position, this.Yanmont.transform.position) <= 10.0 && !this.Yanmont.EnterCutscene)
      return;
    Object.Destroy((Object) this.gameObject);
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.tag == "Player")
    {
      Object.Instantiate<GameObject>(this.BlackExplosion, this.transform.position, Quaternion.identity);
      this.Yanmont.TakeDamage(20);
    }
    if (!(other.gameObject.name == "Heart"))
      return;
    Object.Instantiate<GameObject>(this.BlackExplosion, this.transform.position, Quaternion.identity);
    Object.Destroy((Object) this.gameObject);
  }
}
