﻿// Decompiled with JetBrains decompiler
// Type: SentenceScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SentenceScript : MonoBehaviour
{
  public UILabel Sentence;
  public string[] Words;
  public int ID;

  private void Update()
  {
    if (!Input.GetButtonDown("A"))
      return;
    this.Sentence.text = this.Words[this.ID];
    ++this.ID;
  }
}
