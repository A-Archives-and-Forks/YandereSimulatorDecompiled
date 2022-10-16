﻿// Decompiled with JetBrains decompiler
// Type: HomeGlobals
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

public static class HomeGlobals
{
  private const string Str_LateForSchool = "LateForSchool";
  private const string Str_Night = "Night";
  private const string Str_StartInBasement = "StartInBasement";
  private const string Str_MiyukiDefeated = "MiyukiDefeated";

  public static bool LateForSchool
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_LateForSchool");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_LateForSchool", value);
  }

  public static bool Night
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_Night");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_Night", value);
  }

  public static bool StartInBasement
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StartInBasement");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StartInBasement", value);
  }

  public static bool MiyukiDefeated
  {
    get => GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_MiyukiDefeated");
    set => GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_MiyukiDefeated", value);
  }

  public static void DeleteAll()
  {
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LateForSchool");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Night");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_StartInBasement");
    Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MiyukiDefeated");
  }
}
