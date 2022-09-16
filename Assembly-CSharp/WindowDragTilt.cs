﻿// Decompiled with JetBrains decompiler
// Type: WindowDragTilt
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("NGUI/Examples/Window Drag Tilt")]
public class WindowDragTilt : MonoBehaviour
{
  public int updateOrder;
  public float degrees = 30f;
  private Vector3 mLastPos;
  private Transform mTrans;
  private float mAngle;

  private void OnEnable()
  {
    this.mTrans = this.transform;
    this.mLastPos = this.mTrans.position;
  }

  private void Update()
  {
    Vector3 vector3 = this.mTrans.position - this.mLastPos;
    this.mLastPos = this.mTrans.position;
    this.mAngle += vector3.x * this.degrees;
    this.mAngle = NGUIMath.SpringLerp(this.mAngle, 0.0f, 20f, Time.deltaTime);
    this.mTrans.localRotation = Quaternion.Euler(0.0f, 0.0f, -this.mAngle);
  }
}
