﻿// Decompiled with JetBrains decompiler
// Type: GentlemanScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class GentlemanScript : MonoBehaviour
{
  public YandereScript Yandere;
  public AudioClip[] Clips;

  private void Update()
  {
    if (!Input.GetButtonDown("RB"))
      return;
    AudioSource component = this.GetComponent<AudioSource>();
    if (component.isPlaying)
      return;
    component.clip = this.Clips[Random.Range(0, this.Clips.Length - 1)];
    component.Play();
    this.Yandere.Sanity += 10f;
  }
}
