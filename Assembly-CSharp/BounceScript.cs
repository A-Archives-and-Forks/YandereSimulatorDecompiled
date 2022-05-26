﻿// Decompiled with JetBrains decompiler
// Type: BounceScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BounceScript : MonoBehaviour
{
  public float StartingMotion;
  public float DecliningSpeed;
  public float Motion;
  public float PositionX;
  public float Speed;
  public Transform MyCamera;
  public bool Go;

  private void Start()
  {
    this.StartingMotion += Random.Range(-1f / 1000f, 1f / 1000f);
    this.DecliningSpeed += Random.Range(-1f / 1000f, 1f / 1000f);
  }

  private void Update()
  {
    this.transform.position += new Vector3(0.0f, this.Motion, 0.0f);
    this.Motion -= Time.deltaTime * this.DecliningSpeed;
    if ((double) this.transform.position.y < 0.5)
      this.Motion = this.StartingMotion;
    if (!((Object) this.MyCamera != (Object) null) || !this.Go)
      return;
    this.Speed += Time.deltaTime;
    this.PositionX = Mathf.Lerp(this.PositionX, -0.999f, Time.deltaTime * this.Speed);
    this.MyCamera.position = new Vector3(this.PositionX, 1f, -10f);
  }
}
