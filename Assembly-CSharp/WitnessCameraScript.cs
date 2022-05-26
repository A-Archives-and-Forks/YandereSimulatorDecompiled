﻿// Decompiled with JetBrains decompiler
// Type: WitnessCameraScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class WitnessCameraScript : MonoBehaviour
{
  public YandereScript Yandere;
  public Transform WitnessPOV;
  public float WitnessTimer;
  public Camera MyCamera;
  public bool Show;

  private void Start()
  {
    this.MyCamera.enabled = false;
    this.MyCamera.rect = new Rect(0.0f, 0.0f, 0.0f, 0.0f);
  }

  private void Update()
  {
    if (this.Show)
    {
      this.MyCamera.rect = new Rect(this.MyCamera.rect.x, this.MyCamera.rect.y, Mathf.Lerp(this.MyCamera.rect.width, 0.25f, Time.deltaTime * 10f), Mathf.Lerp(this.MyCamera.rect.height, 0.4444444f, Time.deltaTime * 10f));
      this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y, this.transform.localPosition.z + Time.deltaTime * 0.09f);
      this.WitnessTimer += Time.deltaTime;
      if ((double) this.WitnessTimer > 5.0)
      {
        this.WitnessTimer = 0.0f;
        this.Show = false;
      }
      if (!this.Yandere.Struggling)
        return;
      this.WitnessTimer = 0.0f;
      this.Show = false;
    }
    else
    {
      this.MyCamera.rect = new Rect(this.MyCamera.rect.x, this.MyCamera.rect.y, Mathf.Lerp(this.MyCamera.rect.width, 0.0f, Time.deltaTime * 10f), Mathf.Lerp(this.MyCamera.rect.height, 0.0f, Time.deltaTime * 10f));
      if (!this.MyCamera.enabled || (double) this.MyCamera.rect.width >= 0.100000001490116)
        return;
      this.MyCamera.enabled = false;
      this.transform.parent = (Transform) null;
    }
  }
}
