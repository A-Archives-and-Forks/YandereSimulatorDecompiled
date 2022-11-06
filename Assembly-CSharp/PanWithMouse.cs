﻿// Decompiled with JetBrains decompiler
// Type: PanWithMouse
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6DC2A12D-6390-4505-844F-2E3192236485
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("NGUI/Examples/Pan With Mouse")]
public class PanWithMouse : MonoBehaviour
{
  public Vector2 degrees = new Vector2(5f, 3f);
  public float range = 1f;
  private Transform mTrans;
  private Quaternion mStart;
  private Vector2 mRot = Vector2.zero;

  private void Start()
  {
    this.mTrans = this.transform;
    this.mStart = this.mTrans.localRotation;
  }

  private void Update()
  {
    float deltaTime = RealTime.deltaTime;
    Vector3 lastEventPosition = (Vector3) UICamera.lastEventPosition;
    float num1 = (float) Screen.width * 0.5f;
    float num2 = (float) Screen.height * 0.5f;
    if ((double) this.range < 0.10000000149011612)
      this.range = 0.1f;
    this.mRot = Vector2.Lerp(this.mRot, new Vector2(Mathf.Clamp((lastEventPosition.x - num1) / num1 / this.range, -1f, 1f), Mathf.Clamp((lastEventPosition.y - num2) / num2 / this.range, -1f, 1f)), deltaTime * 5f);
    this.mTrans.localRotation = this.mStart * Quaternion.Euler(-this.mRot.y * this.degrees.y, this.mRot.x * this.degrees.x, 0.0f);
  }
}
