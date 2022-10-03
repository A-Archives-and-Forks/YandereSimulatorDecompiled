﻿// Decompiled with JetBrains decompiler
// Type: PhotographyClubScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class PhotographyClubScript : MonoBehaviour
{
  public GameObject CrimeScene;
  public GameObject InvestigationPhotos;
  public GameObject ArtsyPhotos;
  public GameObject StraightTables;
  public GameObject CrookedTables;

  private void Start()
  {
    this.InvestigationPhotos.SetActive(false);
    this.ArtsyPhotos.SetActive(true);
    if ((double) SchoolGlobals.SchoolAtmosphere <= 0.800000011920929)
    {
      if (!GameGlobals.Eighties)
      {
        this.InvestigationPhotos.SetActive(true);
        this.ArtsyPhotos.SetActive(false);
      }
      this.CrimeScene.SetActive(true);
      this.StraightTables.SetActive(true);
      this.CrookedTables.SetActive(false);
    }
    else
    {
      this.CrimeScene.SetActive(false);
      this.StraightTables.SetActive(false);
      this.CrookedTables.SetActive(true);
    }
  }
}
