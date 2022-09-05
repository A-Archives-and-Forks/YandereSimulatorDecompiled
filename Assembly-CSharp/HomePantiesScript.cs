﻿// Decompiled with JetBrains decompiler
// Type: HomePantiesScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A8EFE0B-B8E4-42A1-A228-F35734F77857
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class HomePantiesScript : MonoBehaviour
{
  public HomePantyChangerScript PantyChanger;
  public float RotationSpeed;
  public Material Unselectable;
  public Renderer MyRenderer;
  public int ID;

  private void Start()
  {
    if (this.ID <= 0 || CollectibleGlobals.GetPantyPurchased(this.ID))
      return;
    this.MyRenderer.material = this.Unselectable;
    this.MyRenderer.material.color = new Color(0.0f, 0.0f, 0.0f, 0.5f);
  }

  private void Update() => this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.PantyChanger.Selected == this.ID ? this.transform.eulerAngles.y + Time.deltaTime * this.RotationSpeed : 0.0f, this.transform.eulerAngles.z);
}
