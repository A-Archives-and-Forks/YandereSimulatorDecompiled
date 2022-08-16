﻿// Decompiled with JetBrains decompiler
// Type: RendererListScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RendererListScript : MonoBehaviour
{
  public Renderer[] Renderers;

  private void Start()
  {
    Transform[] componentsInChildren = this.gameObject.GetComponentsInChildren<Transform>();
    int index = 0;
    foreach (Transform transform in componentsInChildren)
    {
      if ((Object) transform.gameObject.GetComponent<Renderer>() != (Object) null)
      {
        this.Renderers[index] = transform.gameObject.GetComponent<Renderer>();
        ++index;
      }
    }
  }

  private void Update()
  {
    if (!Input.GetKeyDown(KeyCode.LeftControl))
      return;
    foreach (Renderer renderer in this.Renderers)
      renderer.enabled = !renderer.enabled;
  }
}
