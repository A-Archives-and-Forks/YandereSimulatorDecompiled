﻿// Decompiled with JetBrains decompiler
// Type: INGUIAtlas
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public interface INGUIAtlas
{
  Material spriteMaterial { get; set; }

  List<UISpriteData> spriteList { get; set; }

  Texture texture { get; }

  float pixelSize { get; set; }

  bool premultipliedAlpha { get; }

  INGUIAtlas replacement { get; set; }

  UISpriteData GetSprite(string name);

  BetterList<string> GetListOfSprites();

  BetterList<string> GetListOfSprites(string match);

  bool References(INGUIAtlas atlas);

  void MarkAsChanged();

  void SortAlphabetically();
}
