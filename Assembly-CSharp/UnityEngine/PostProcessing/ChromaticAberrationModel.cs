﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.ChromaticAberrationModel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

namespace UnityEngine.PostProcessing
{
  [Serializable]
  public class ChromaticAberrationModel : PostProcessingModel
  {
    [SerializeField]
    private ChromaticAberrationModel.Settings m_Settings = ChromaticAberrationModel.Settings.defaultSettings;

    public ChromaticAberrationModel.Settings settings
    {
      get => this.m_Settings;
      set => this.m_Settings = value;
    }

    public override void Reset() => this.m_Settings = ChromaticAberrationModel.Settings.defaultSettings;

    [Serializable]
    public struct Settings
    {
      [Tooltip("Shift the hue of chromatic aberrations.")]
      public Texture2D spectralTexture;
      [Range(0.0f, 1f)]
      [Tooltip("Amount of tangential distortion.")]
      public float intensity;

      public static ChromaticAberrationModel.Settings defaultSettings => new ChromaticAberrationModel.Settings()
      {
        spectralTexture = (Texture2D) null,
        intensity = 0.1f
      };
    }
  }
}
