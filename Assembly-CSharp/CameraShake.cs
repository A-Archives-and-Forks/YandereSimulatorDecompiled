﻿// Decompiled with JetBrains decompiler
// Type: CameraShake
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CameraShake : MonoBehaviour
{
  public Transform camTransform;
  public float shake;
  public float shakeAmount = 0.7f;
  public float decreaseFactor = 1f;
  private Vector3 originalPos;

  private void Awake()
  {
    if (!((Object) this.camTransform == (Object) null))
      return;
    this.camTransform = this.GetComponent<Transform>();
  }

  private void OnEnable() => this.originalPos = this.camTransform.localPosition;

  private void Update()
  {
    if ((double) this.shake > 0.0)
    {
      this.camTransform.localPosition = this.originalPos + Random.insideUnitSphere * this.shakeAmount;
      this.shake -= 0.0166666675f * this.decreaseFactor;
    }
    else
    {
      this.shake = 0.0f;
      this.camTransform.localPosition = this.originalPos;
    }
  }
}
