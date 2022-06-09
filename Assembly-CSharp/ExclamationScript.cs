﻿// Decompiled with JetBrains decompiler
// Type: ExclamationScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F9DCDD8C-888A-4877-BE40-0221D34B07CB
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class ExclamationScript : MonoBehaviour
{
  public Renderer Graphic;
  public float Alpha;
  public float Timer;
  public Camera MainCamera;

  private void Start()
  {
    this.transform.localScale = Vector3.zero;
    this.Graphic.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, 0.0f));
    this.MainCamera = Camera.main;
  }

  private void Update()
  {
    this.Timer -= Time.deltaTime;
    if ((double) this.Timer <= 0.0)
      return;
    this.transform.LookAt(this.MainCamera.transform);
    if ((double) this.Timer > 1.5)
    {
      this.transform.localScale = Vector3.Lerp(this.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
      this.Alpha = Mathf.Lerp(this.Alpha, 0.5f, Time.deltaTime * 10f);
      this.Graphic.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, this.Alpha));
    }
    else
    {
      if ((double) this.transform.localScale.x > 0.100000001490116)
        this.transform.localScale = Vector3.Lerp(this.transform.localScale, Vector3.zero, Time.deltaTime * 10f);
      else
        this.transform.localScale = Vector3.zero;
      this.Alpha = Mathf.Lerp(this.Alpha, 0.0f, Time.deltaTime * 10f);
      this.Graphic.material.SetColor("_TintColor", new Color(0.5f, 0.5f, 0.5f, this.Alpha));
    }
  }
}
