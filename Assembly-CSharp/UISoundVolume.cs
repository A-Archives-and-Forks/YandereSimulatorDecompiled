﻿// Decompiled with JetBrains decompiler
// Type: UISoundVolume
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[RequireComponent(typeof (UISlider))]
[AddComponentMenu("NGUI/Interaction/Sound Volume")]
public class UISoundVolume : MonoBehaviour
{
  private void Awake()
  {
    UISlider component = this.GetComponent<UISlider>();
    component.value = NGUITools.soundVolume;
    EventDelegate.Add(component.onChange, new EventDelegate.Callback(this.OnChange));
  }

  private void OnChange() => NGUITools.soundVolume = UIProgressBar.current.value;
}
