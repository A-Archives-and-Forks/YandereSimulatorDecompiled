﻿// Decompiled with JetBrains decompiler
// Type: StandPunchScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class StandPunchScript : MonoBehaviour
{
  public Collider MyCollider;

  private void OnTriggerEnter(Collider other)
  {
    StudentScript component = other.gameObject.GetComponent<StudentScript>();
    if (!((Object) component != (Object) null) || component.StudentID <= 1)
      return;
    component.JojoReact();
  }
}
