﻿// Decompiled with JetBrains decompiler
// Type: DiscordVerificationScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class DiscordVerificationScript : MonoBehaviour
{
  private void Update()
  {
    if (!Input.GetKeyDown("q"))
      return;
    SceneManager.LoadScene("MissionModeScene");
  }
}
