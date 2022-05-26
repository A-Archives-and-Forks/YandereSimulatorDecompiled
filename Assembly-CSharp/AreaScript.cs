﻿// Decompiled with JetBrains decompiler
// Type: AreaScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

public class AreaScript : MonoBehaviour
{
  [Header("Do not touch any of these values. They get updated at runtime.")]
  [Tooltip("The amount of students in this area.")]
  public int Population;
  [Tooltip("A list of students in this area.")]
  public List<StudentScript> Students;
  [Tooltip("This area's crowd. Students will go here.")]
  public List<StudentScript> Crowd;
  public int ID;

  private void OnTriggerEnter(Collider other)
  {
    if (!other.CompareTag("Student"))
      return;
    StudentScript component = other.GetComponent<StudentScript>();
    if (component.Teacher)
      return;
    this.Students.Add(component);
    ++this.Population;
  }

  private void OnTriggerExit(Collider other)
  {
    if (!other.CompareTag("Student"))
      return;
    StudentScript component = other.GetComponent<StudentScript>();
    if (component.Teacher)
      return;
    this.Students.Remove(component);
    --this.Population;
  }
}
