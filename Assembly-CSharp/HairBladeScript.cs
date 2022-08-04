﻿// Decompiled with JetBrains decompiler
// Type: HairBladeScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class HairBladeScript : MonoBehaviour
{
  public GameObject FemaleBloodyScream;
  public GameObject MaleBloodyScream;
  public Vector3 PreviousPosition;
  public Collider MyCollider;
  public float Timer;
  public StudentScript Student;

  private void Update()
  {
  }

  private void OnTriggerEnter(Collider other)
  {
    GameObject gameObject = other.gameObject.transform.root.gameObject;
    if (!((Object) gameObject.GetComponent<StudentScript>() != (Object) null))
      return;
    this.Student = gameObject.GetComponent<StudentScript>();
    if (this.Student.StudentID == 1 || !this.Student.Alive)
      return;
    this.Student.DeathType = DeathType.EasterEgg;
    Object.Instantiate<GameObject>(this.Student.Male ? this.MaleBloodyScream : this.FemaleBloodyScream, this.Student.transform.position + Vector3.up, Quaternion.identity);
    this.Student.BecomeRagdoll();
    this.Student.Ragdoll.Dismember();
    this.GetComponent<AudioSource>().Play();
  }
}
