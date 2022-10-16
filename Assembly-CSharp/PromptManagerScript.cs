﻿// Decompiled with JetBrains decompiler
// Type: PromptManagerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PromptManagerScript : MonoBehaviour
{
  public PromptScript[] Prompts;
  public int ID;
  public Transform Yandere;
  public bool Outside;

  private void Update()
  {
    if ((double) this.Yandere.transform.position.z < -38.0)
    {
      if (this.Outside)
        return;
      this.Outside = true;
      foreach (PromptScript prompt in this.Prompts)
      {
        if ((Object) prompt != (Object) null)
          prompt.enabled = false;
      }
    }
    else
    {
      if (!this.Outside)
        return;
      this.Outside = false;
      foreach (PromptScript prompt in this.Prompts)
      {
        if ((Object) prompt != (Object) null)
          prompt.enabled = true;
      }
    }
  }
}
