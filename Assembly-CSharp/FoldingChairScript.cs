﻿// Decompiled with JetBrains decompiler
// Type: FoldingChairScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class FoldingChairScript : MonoBehaviour
{
  public GameObject[] Student;

  private void Start() => Object.Instantiate<GameObject>(this.Student[Random.Range(0, this.Student.Length)], this.transform.position - new Vector3(0.0f, 0.4f, 0.0f), this.transform.rotation);
}
