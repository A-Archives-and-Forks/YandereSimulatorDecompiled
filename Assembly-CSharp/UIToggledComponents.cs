﻿// Decompiled with JetBrains decompiler
// Type: UIToggledComponents
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof (UIToggle))]
[AddComponentMenu("NGUI/Interaction/Toggled Components")]
public class UIToggledComponents : MonoBehaviour
{
  public List<MonoBehaviour> activate;
  public List<MonoBehaviour> deactivate;
  [HideInInspector]
  [SerializeField]
  private MonoBehaviour target;
  [HideInInspector]
  [SerializeField]
  private bool inverse;

  private void Awake()
  {
    if ((Object) this.target != (Object) null)
    {
      if (this.activate.Count == 0 && this.deactivate.Count == 0)
      {
        if (this.inverse)
          this.deactivate.Add(this.target);
        else
          this.activate.Add(this.target);
      }
      else
        this.target = (MonoBehaviour) null;
    }
    EventDelegate.Add(this.GetComponent<UIToggle>().onChange, new EventDelegate.Callback(this.Toggle));
  }

  public void Toggle()
  {
    if (!this.enabled)
      return;
    for (int index = 0; index < this.activate.Count; ++index)
      this.activate[index].enabled = UIToggle.current.value;
    for (int index = 0; index < this.deactivate.Count; ++index)
      this.deactivate[index].enabled = !UIToggle.current.value;
  }
}
