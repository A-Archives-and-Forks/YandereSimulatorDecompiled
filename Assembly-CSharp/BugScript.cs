﻿// Decompiled with JetBrains decompiler
// Type: BugScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BugScript : MonoBehaviour
{
  public PromptScript Prompt;
  public Renderer MyRenderer;
  public AudioSource MyAudio;
  public AudioClip[] Praise;
  public bool Placed;

  private void Start()
  {
    if (GameGlobals.Eighties)
    {
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.gameObject.SetActive(false);
    }
    this.MyRenderer.enabled = false;
  }

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    this.MyAudio.clip = this.Praise[Random.Range(0, this.Praise.Length)];
    this.MyAudio.Play();
    this.MyRenderer.enabled = true;
    this.Prompt.Yandere.Inventory.PantyShots += 5;
    this.Prompt.Yandere.NotificationManager.CustomText = "+5 Info Points! You have " + this.Prompt.Yandere.Inventory.PantyShots.ToString() + " in total";
    this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
    this.Placed = true;
    this.enabled = false;
    this.Prompt.enabled = false;
    this.Prompt.Hide();
  }

  public void CheckStatus()
  {
    if (!this.Placed)
      return;
    this.MyRenderer.enabled = true;
    this.enabled = false;
    this.Prompt.enabled = false;
    this.Prompt.Hide();
  }
}
