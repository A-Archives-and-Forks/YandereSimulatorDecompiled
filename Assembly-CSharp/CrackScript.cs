﻿// Decompiled with JetBrains decompiler
// Type: CrackScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CrackScript : MonoBehaviour
{
  public UITexture Texture;

  private void Update() => this.Texture.fillAmount += Time.deltaTime * 10f;
}
