﻿// Decompiled with JetBrains decompiler
// Type: ApplicationSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

[Serializable]
public class ApplicationSaveData
{
  public float versionNumber;

  public static ApplicationSaveData ReadFromGlobals() => new ApplicationSaveData()
  {
    versionNumber = ApplicationGlobals.VersionNumber
  };

  public static void WriteToGlobals(ApplicationSaveData data) => ApplicationGlobals.VersionNumber = data.versionNumber;
}
