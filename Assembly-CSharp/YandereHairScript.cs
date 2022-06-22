﻿// Decompiled with JetBrains decompiler
// Type: YandereHairScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 41FC567F-B14D-47B6-963A-CEFC38C7B329
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class YandereHairScript : MonoBehaviour
{
  public YandereScript Yandere;
  public int Frame;
  public int Limit;

  private void Start()
  {
    ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/YandereHair/Hair_" + this.Yandere.Hairstyle.ToString() + ".png");
    this.Limit = this.Yandere.Hairstyles.Length - 1;
  }

  private void Update()
  {
    if (this.Yandere.Hairstyle >= this.Limit)
      return;
    ++this.Frame;
    if (this.Frame == 1)
    {
      ++this.Yandere.Hairstyle;
      this.Yandere.UpdateHair();
    }
    if (this.Frame != 2)
      return;
    ScreenCapture.CaptureScreenshot(Application.streamingAssetsPath + "/YandereHair/Hair_" + this.Yandere.Hairstyle.ToString() + ".png");
    this.Frame = 0;
  }
}
