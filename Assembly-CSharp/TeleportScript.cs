﻿// Decompiled with JetBrains decompiler
// Type: TeleportScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class TeleportScript : MonoBehaviour
{
  public PromptScript Prompt;
  public Transform Destination;

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    this.Prompt.Yandere.transform.position = this.Destination.position;
    Physics.SyncTransforms();
  }
}
