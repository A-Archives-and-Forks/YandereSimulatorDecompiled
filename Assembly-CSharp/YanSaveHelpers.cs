﻿// Decompiled with JetBrains decompiler
// Type: YanSaveHelpers
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Reflection;

public static class YanSaveHelpers
{
  public static System.Type GrabType(string type)
  {
    if (string.IsNullOrEmpty(type))
      return (System.Type) null;
    foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
    {
      System.Type type1 = assembly.GetType(type);
      if (type1 != (System.Type) null)
        return type1;
    }
    return (System.Type) null;
  }
}
