﻿// Decompiled with JetBrains decompiler
// Type: CircleFillScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CircleFillScript : MonoBehaviour
{
  public UISprite OsanaFill;
  public UITexture OtherFill;
  public UITexture Fill;
  public float Speed;
  public int Phase;

  private void Update()
  {
    this.Speed += Time.deltaTime;
    this.Fill.transform.localPosition = Vector3.Lerp(this.Fill.transform.localPosition, new Vector3(-1024f, 0.0f, 0.0f), Time.deltaTime * this.Speed);
    if ((double) this.Fill.transform.localPosition.x >= -1023.0)
      return;
    if (this.Phase == 0)
    {
      ++this.Phase;
      this.Speed = 0.0f;
    }
    this.Fill.fillAmount = Mathf.Lerp(this.Fill.fillAmount, 1f, Time.deltaTime * this.Speed);
  }
}
