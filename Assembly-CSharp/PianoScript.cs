﻿// Decompiled with JetBrains decompiler
// Type: PianoScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PianoScript : MonoBehaviour
{
  public PromptScript Prompt;
  public AudioSource[] Notes;
  public int ID;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount >= 1.0 || (double) this.Prompt.Circle[0].fillAmount <= 0.0)
      return;
    this.Prompt.Circle[0].fillAmount = 0.0f;
    this.Notes[this.ID].Play();
    ++this.ID;
    if (this.ID != this.Notes.Length)
      return;
    this.ID = 0;
  }
}
