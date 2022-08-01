﻿// Decompiled with JetBrains decompiler
// Type: AnimatedAlpha
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[ExecuteInEditMode]
public class AnimatedAlpha : MonoBehaviour
{
  [Range(0.0f, 1f)]
  public float alpha = 1f;
  private UIWidget mWidget;
  private UIPanel mPanel;

  private void OnEnable()
  {
    this.mWidget = this.GetComponent<UIWidget>();
    this.mPanel = this.GetComponent<UIPanel>();
    this.LateUpdate();
  }

  private void LateUpdate()
  {
    if ((Object) this.mWidget != (Object) null)
      this.mWidget.alpha = this.alpha;
    if (!((Object) this.mPanel != (Object) null))
      return;
    this.mPanel.alpha = this.alpha;
  }
}
