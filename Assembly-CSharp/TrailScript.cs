﻿// Decompiled with JetBrains decompiler
// Type: TrailScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TrailScript : MonoBehaviour
{
  private void Start()
  {
    Physics.IgnoreCollision(GameObject.Find("YandereChan").GetComponent<Collider>(), this.GetComponent<Collider>());
    Physics.IgnoreLayerCollision(20, 8, false);
    Physics.IgnoreLayerCollision(8, 20, false);
    Physics.IgnoreLayerCollision(20, 15, true);
    Physics.IgnoreLayerCollision(15, 20, true);
    Object.Destroy((Object) this);
  }
}
