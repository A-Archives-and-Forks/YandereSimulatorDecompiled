﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.TrackballAttribute
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

namespace UnityEngine.PostProcessing
{
  public sealed class TrackballAttribute : PropertyAttribute
  {
    public readonly string method;

    public TrackballAttribute(string method) => this.method = method;
  }
}
