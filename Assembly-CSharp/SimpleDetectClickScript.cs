﻿// Decompiled with JetBrains decompiler
// Type: SimpleDetectClickScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SimpleDetectClickScript : MonoBehaviour
{
  public InventoryItemScript InventoryItem;
  public Collider MyCollider;
  public bool Clicked;

  private void Update()
  {
    RaycastHit hitInfo;
    if (!Input.GetMouseButtonDown(0) || !Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 100f) || !((Object) hitInfo.collider == (Object) this.MyCollider))
      return;
    this.Clicked = true;
  }
}
