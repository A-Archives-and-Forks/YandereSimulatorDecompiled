﻿// Decompiled with JetBrains decompiler
// Type: RPG_Animation_CharacterFadeOnly
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class RPG_Animation_CharacterFadeOnly : MonoBehaviour
{
  public static RPG_Animation_CharacterFadeOnly instance;

  private void Awake() => RPG_Animation_CharacterFadeOnly.instance = this;
}
