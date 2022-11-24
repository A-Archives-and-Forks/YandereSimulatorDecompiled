﻿// Decompiled with JetBrains decompiler
// Type: BakeSaleScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.SceneManagement;

public class BakeSaleScript : MonoBehaviour
{
  public StudentManagerScript StudentManager;
  public GameObject AmaiSuccess;
  public GameObject AmaiFail;
  public Transform MeetSpot;
  public float Timer;
  public int ID = 46;

  private void Update()
  {
    float hourTime = this.StudentManager.Clock.HourTime;
    if ((double) hourTime < 8.0 || (double) hourTime > 13.0 && (double) hourTime < 13.5 || (double) hourTime > 16.0 && (double) hourTime < 17.0)
    {
      this.Timer += Time.deltaTime;
      if ((double) this.Timer > 60.0 && (Object) this.StudentManager.Students[this.ID] != (Object) null)
      {
        if (this.ID < 86 && this.StudentManager.Students[this.ID].Routine && this.StudentManager.Students[this.ID].Indoors)
        {
          Debug.Log((object) (this.StudentManager.Students[this.ID].Name + " has decided to go to the bake sale."));
          this.Timer = 0.0f;
          this.StudentManager.Students[this.ID].Meeting = true;
          this.StudentManager.Students[this.ID].BakeSale = true;
          this.StudentManager.Students[this.ID].MeetTime = 0.0001f;
          this.StudentManager.Students[this.ID].MeetSpot = this.MeetSpot;
          this.IncreaseID();
        }
        else
          this.IncreaseID();
      }
    }
    if (this.StudentManager.Yandere.Alerts > 0 || this.StudentManager.Yandere.Police.StudentFoundCorpse)
    {
      this.AmaiFail.SetActive(true);
      if (!Input.GetKeyDown("`"))
        return;
      SceneManager.LoadScene("LoadingScene");
    }
    else
    {
      if (!((Object) this.StudentManager.Students[12] != (Object) null) || !this.StudentManager.Students[12].Ragdoll.Disposed)
        return;
      if (!this.AmaiSuccess.activeInHierarchy && !GameGlobals.Debug)
      {
        PlayerPrefs.SetInt("Amai", 1);
        PlayerPrefs.SetInt("a", 1);
      }
      this.AmaiSuccess.SetActive(true);
    }
  }

  private void IncreaseID()
  {
    ++this.ID;
    if (this.ID <= 89)
      return;
    this.ID = 46;
  }
}
