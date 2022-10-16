﻿// Decompiled with JetBrains decompiler
// Type: YanvaniaZombieSpawnerScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class YanvaniaZombieSpawnerScript : MonoBehaviour
{
  public YanvaniaZombieScript NewZombieScript;
  public GameObject Zombie;
  public YanvaniaYanmontScript Yanmont;
  public float SpawnTimer;
  public float RelativePoint;
  public float RightBoundary;
  public float LeftBoundary;
  public int SpawnSide;
  public int ID;
  public GameObject[] Zombies;
  public Vector3[] SpawnPoints;

  private void Update()
  {
    if ((double) this.Yanmont.transform.position.y <= 0.0)
      return;
    this.ID = 0;
    this.SpawnTimer += Time.deltaTime;
    if ((double) this.SpawnTimer <= 1.0)
      return;
    for (; this.ID < 4; ++this.ID)
    {
      if ((Object) this.Zombies[this.ID] == (Object) null)
      {
        this.SpawnSide = Random.Range(1, 3);
        if ((double) this.Yanmont.transform.position.x < (double) this.LeftBoundary + 5.0)
          this.SpawnSide = 2;
        if ((double) this.Yanmont.transform.position.x > (double) this.RightBoundary - 5.0)
          this.SpawnSide = 1;
        this.RelativePoint = (double) this.Yanmont.transform.position.x >= (double) this.LeftBoundary ? ((double) this.Yanmont.transform.position.x <= (double) this.RightBoundary ? this.Yanmont.transform.position.x : this.RightBoundary) : this.LeftBoundary;
        if (this.SpawnSide == 1)
        {
          this.SpawnPoints[0].x = this.RelativePoint - 2.5f;
          this.SpawnPoints[1].x = this.RelativePoint - 3.5f;
          this.SpawnPoints[2].x = this.RelativePoint - 4.5f;
          this.SpawnPoints[3].x = this.RelativePoint - 5.5f;
        }
        else
        {
          this.SpawnPoints[0].x = this.RelativePoint + 2.5f;
          this.SpawnPoints[1].x = this.RelativePoint + 3.5f;
          this.SpawnPoints[2].x = this.RelativePoint + 4.5f;
          this.SpawnPoints[3].x = this.RelativePoint + 5.5f;
        }
        this.Zombies[this.ID] = Object.Instantiate<GameObject>(this.Zombie, this.SpawnPoints[this.ID], Quaternion.identity);
        this.NewZombieScript = this.Zombies[this.ID].GetComponent<YanvaniaZombieScript>();
        this.NewZombieScript.LeftBoundary = this.LeftBoundary;
        this.NewZombieScript.RightBoundary = this.RightBoundary;
        this.NewZombieScript.Yanmont = this.Yanmont;
        break;
      }
    }
    this.SpawnTimer = 0.0f;
  }
}
