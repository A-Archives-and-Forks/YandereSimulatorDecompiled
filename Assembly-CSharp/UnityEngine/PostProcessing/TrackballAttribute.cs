﻿// Decompiled with JetBrains decompiler
// Type: UnityEngine.PostProcessing.TrackballAttribute
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

namespace UnityEngine.PostProcessing
{
  public sealed class TrackballAttribute : PropertyAttribute
  {
    public readonly string method;

    public TrackballAttribute(string method) => this.method = method;
  }
}
