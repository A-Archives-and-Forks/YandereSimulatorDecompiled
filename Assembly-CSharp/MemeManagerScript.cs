﻿// Decompiled with JetBrains decompiler
// Type: MemeManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MemeManagerScript : MonoBehaviour
{
  [SerializeField]
  private GameObject[] Memes;

  private void Start()
  {
    if (!GameGlobals.LoveSick)
      return;
    foreach (GameObject meme in this.Memes)
      meme.SetActive(false);
  }
}
