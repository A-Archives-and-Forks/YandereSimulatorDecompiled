﻿// Decompiled with JetBrains decompiler
// Type: Drawer_Pull_Z
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class Drawer_Pull_Z : MonoBehaviour
{
  public Animator pull;
  public bool open;
  public Transform Player;

  private void Start() => this.open = false;

  private void OnMouseOver()
  {
    if (!(bool) (Object) this.Player || (double) Vector3.Distance(this.Player.position, this.transform.position) >= 10.0)
      return;
    MonoBehaviour.print((object) "object name");
    if (!this.open)
    {
      if (!Input.GetMouseButtonDown(0))
        return;
      this.StartCoroutine(this.opening());
    }
    else
    {
      if (!this.open || !Input.GetMouseButtonDown(0))
        return;
      this.StartCoroutine(this.closing());
    }
  }

  private IEnumerator opening()
  {
    MonoBehaviour.print((object) "you are opening the door");
    this.pull.Play("openpull");
    this.open = true;
    yield return (object) new WaitForSeconds(0.5f);
  }

  private IEnumerator closing()
  {
    MonoBehaviour.print((object) "you are closing the door");
    this.pull.Play("closepush");
    this.open = false;
    yield return (object) new WaitForSeconds(0.5f);
  }
}
