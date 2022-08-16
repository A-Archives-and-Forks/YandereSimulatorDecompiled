﻿// Decompiled with JetBrains decompiler
// Type: TimeStopKnifeScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TimeStopKnifeScript : MonoBehaviour
{
  public GameObject FemaleScream;
  public GameObject MaleScream;
  public bool Unfreeze;
  public float Speed = 0.1f;
  private float Timer;

  private void Start() => this.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);

  private void Update()
  {
    if (!this.Unfreeze)
    {
      this.Speed = Mathf.MoveTowards(this.Speed, 0.0f, Time.deltaTime);
      if ((double) this.transform.localScale.x < 0.99000000953674316)
        this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
    }
    else
    {
      this.Speed = 10f;
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 5.0)
        Object.Destroy((Object) this.gameObject);
    }
    this.transform.Translate(Vector3.forward * this.Speed * Time.deltaTime, Space.Self);
  }

  private void OnTriggerEnter(Collider other)
  {
    if (!this.Unfreeze || other.gameObject.layer != 9)
      return;
    StudentScript component = other.gameObject.GetComponent<StudentScript>();
    if (!((Object) component != (Object) null) || component.StudentID <= 1)
      return;
    if (component.Male)
      Object.Instantiate<GameObject>(this.MaleScream, this.transform.position, Quaternion.identity);
    else
      Object.Instantiate<GameObject>(this.FemaleScream, this.transform.position, Quaternion.identity);
    component.DeathType = DeathType.EasterEgg;
    component.BecomeRagdoll();
  }
}
