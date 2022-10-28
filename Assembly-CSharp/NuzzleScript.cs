﻿// Decompiled with JetBrains decompiler
// Type: NuzzleScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class NuzzleScript : MonoBehaviour
{
  public Vector3 OriginalRotation;
  public float Rotate;
  public float Limit;
  public float Speed;
  private bool Down;

  private void Start() => this.OriginalRotation = this.transform.localEulerAngles;

  private void Update()
  {
    if (!this.Down)
    {
      this.Rotate += Time.deltaTime * this.Speed;
      if ((double) this.Rotate > (double) this.Limit)
        this.Down = true;
    }
    else
    {
      this.Rotate -= Time.deltaTime * this.Speed;
      if ((double) this.Rotate < -1.0 * (double) this.Limit)
        this.Down = false;
    }
    this.transform.localEulerAngles = this.OriginalRotation + new Vector3(this.Rotate, 0.0f, 0.0f);
  }
}
