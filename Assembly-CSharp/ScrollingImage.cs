﻿// Decompiled with JetBrains decompiler
// Type: ScrollingImage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.UI;

public class ScrollingImage : MonoBehaviour
{
  [SerializeField]
  private RawImage image;
  [SerializeField]
  private float scrollSpeed;
  private float scroll;

  private void Update()
  {
    this.scroll += Time.deltaTime * this.scrollSpeed;
    if (!((Object) this.image != (Object) null))
      return;
    this.image.uvRect = new Rect(this.scroll, this.scroll, 1f, 1f);
  }
}
