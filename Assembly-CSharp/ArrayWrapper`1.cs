﻿// Decompiled with JetBrains decompiler
// Type: ArrayWrapper`1
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 12831466-57D6-4F5A-B867-CD140BE439C0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections;
using UnityEngine;

public class ArrayWrapper<T> : IEnumerable
{
  [SerializeField]
  private T[] elements;

  public ArrayWrapper(int size) => this.elements = new T[size];

  public ArrayWrapper(T[] elements) => this.elements = elements;

  public T this[int i]
  {
    get => this.elements[i];
    set => this.elements[i] = value;
  }

  public int Length => this.elements.Length;

  public T[] Get() => this.elements;

  public IEnumerator GetEnumerator() => this.elements.GetEnumerator();
}
