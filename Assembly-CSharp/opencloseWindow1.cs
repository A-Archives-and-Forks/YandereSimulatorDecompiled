﻿// Decompiled with JetBrains decompiler
// Type: opencloseWindow1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class opencloseWindow1 : MonoBehaviour
{
  public Animator openandclosewindow1;
  public bool open;
  public Transform Player;

  private void Start() => this.open = false;

  private void OnMouseOver()
  {
    if (!(bool) (Object) this.Player || (double) Vector3.Distance(this.Player.position, this.transform.position) >= 15.0)
      return;
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
    MonoBehaviour.print((object) "you are opening the Window");
    this.openandclosewindow1.Play("Openingwindow 1");
    this.open = true;
    yield return (object) new WaitForSeconds(0.5f);
  }

  private IEnumerator closing()
  {
    MonoBehaviour.print((object) "you are closing the Window");
    this.openandclosewindow1.Play("Closingwindow 1");
    this.open = false;
    yield return (object) new WaitForSeconds(0.5f);
  }
}
