﻿// Decompiled with JetBrains decompiler
// Type: PhoneJammerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PhoneJammerScript : MonoBehaviour
{
  public GameObject JammingLines;
  public PromptScript Prompt;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    ++this.Prompt.Yandere.Alphabet.Cheats;
    this.Prompt.Yandere.Alphabet.UpdateDifficultyLabel();
    this.Prompt.Yandere.StudentManager.Jammed = true;
    this.JammingLines.SetActive(true);
    this.Prompt.enabled = false;
    this.Prompt.Hide();
    this.enabled = false;
  }
}
