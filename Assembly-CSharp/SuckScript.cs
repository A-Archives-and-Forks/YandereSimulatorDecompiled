﻿// Decompiled with JetBrains decompiler
// Type: SuckScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SuckScript : MonoBehaviour
{
  public StudentScript Student;
  public float Strength;

  private void Update()
  {
    this.Strength += Time.deltaTime;
    this.transform.position = Vector3.MoveTowards(this.transform.position, this.Student.Yandere.Hips.position + this.transform.up * 0.25f, Time.deltaTime * this.Strength);
    if ((double) Vector3.Distance(this.transform.position, this.Student.Yandere.Hips.position + this.transform.up * 0.25f) >= 1.0)
      return;
    this.transform.localScale = Vector3.MoveTowards(this.transform.localScale, Vector3.zero, Time.deltaTime);
    if (!(this.transform.localScale == Vector3.zero))
      return;
    this.transform.parent.parent.parent.gameObject.SetActive(false);
  }
}
