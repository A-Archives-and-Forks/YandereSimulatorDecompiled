﻿// Decompiled with JetBrains decompiler
// Type: JsonData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using JsonFx.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public abstract class JsonData
{
  protected static string FolderPath => Path.Combine(Application.streamingAssetsPath, "JSON");

  protected static Dictionary<string, object>[] Deserialize(string filename) => JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(filename));
}
