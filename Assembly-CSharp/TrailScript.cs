﻿// Decompiled with JetBrains decompiler
// Type: TrailScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
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
