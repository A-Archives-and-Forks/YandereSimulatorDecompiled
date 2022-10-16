﻿// Decompiled with JetBrains decompiler
// Type: RetroAesthetics.UVScroller
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace RetroAesthetics
{
  public class UVScroller : MonoBehaviour
  {
    public Vector2 scrollSpeed = new Vector2(-1f, 0.0f);
    public string textureName = "_GridTex";
    private Material target;
    private Vector2 offset = Vector2.zero;

    private void Start()
    {
      Renderer component = this.GetComponent<Renderer>();
      if ((Object) component == (Object) null || (Object) component.material == (Object) null)
      {
        this.enabled = false;
      }
      else
      {
        this.target = component.material;
        if (this.target.HasProperty(this.textureName))
          return;
        Debug.LogWarning((object) ("Texture name '" + this.textureName + "' not found in material."));
        this.enabled = false;
      }
    }

    private void Update()
    {
      this.offset += this.scrollSpeed * Time.deltaTime * (float) Application.targetFrameRate;
      this.target.SetTextureOffset(this.textureName, this.offset);
    }
  }
}
