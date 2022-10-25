﻿// Decompiled with JetBrains decompiler
// Type: ClubSaveData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

[Serializable]
public class ClubSaveData
{
  public ClubType club;
  public ClubTypeHashSet clubClosed = new ClubTypeHashSet();
  public ClubTypeHashSet clubKicked = new ClubTypeHashSet();
  public ClubTypeHashSet quitClub = new ClubTypeHashSet();

  public static ClubSaveData ReadFromGlobals()
  {
    ClubSaveData clubSaveData = new ClubSaveData();
    clubSaveData.club = ClubGlobals.Club;
    foreach (ClubType clubID in ClubGlobals.KeysOfClubClosed())
    {
      if (ClubGlobals.GetClubClosed(clubID))
        clubSaveData.clubClosed.Add(clubID);
    }
    foreach (ClubType clubID in ClubGlobals.KeysOfClubKicked())
    {
      if (ClubGlobals.GetClubKicked(clubID))
        clubSaveData.clubKicked.Add(clubID);
    }
    foreach (ClubType clubID in ClubGlobals.KeysOfQuitClub())
    {
      if (ClubGlobals.GetQuitClub(clubID))
        clubSaveData.quitClub.Add(clubID);
    }
    return clubSaveData;
  }

  public static void WriteToGlobals(ClubSaveData data)
  {
    ClubGlobals.Club = data.club;
    foreach (ClubType clubID in (HashSet<ClubType>) data.clubClosed)
      ClubGlobals.SetClubClosed(clubID, true);
    foreach (ClubType clubID in (HashSet<ClubType>) data.clubKicked)
      ClubGlobals.SetClubKicked(clubID, true);
    foreach (ClubType clubID in (HashSet<ClubType>) data.quitClub)
      ClubGlobals.SetQuitClub(clubID, true);
  }
}
