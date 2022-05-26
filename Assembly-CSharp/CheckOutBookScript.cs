﻿// Decompiled with JetBrains decompiler
// Type: CheckOutBookScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class CheckOutBookScript : MonoBehaviour
{
  public PromptScript Prompt;
  public int ID;

  private void Start()
  {
    if (!GameGlobals.Eighties)
    {
      if (this.ID != 1)
        return;
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.transform.parent.gameObject.SetActive(false);
    }
    else
    {
      if (this.ID != 0)
        return;
      this.Prompt.Hide();
      this.Prompt.enabled = false;
      this.enabled = false;
    }
  }

  private void Update()
  {
    if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
      return;
    if (this.ID == 0)
    {
      this.Prompt.Yandere.Inventory.Book = true;
    }
    else
    {
      this.Prompt.Yandere.NotificationManager.CustomText = "Finished homework assignment!";
      this.Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
      this.Prompt.Yandere.Inventory.FinishedHomework = true;
    }
    this.UpdatePrompt();
  }

  public void UpdatePrompt()
  {
    if (this.ID == 0 && this.Prompt.Yandere.Inventory.Book || this.ID == 1 && this.Prompt.Yandere.Inventory.FinishedHomework)
    {
      this.Prompt.enabled = false;
      this.Prompt.Hide();
    }
    else
    {
      this.Prompt.enabled = true;
      this.Prompt.Hide();
    }
  }
}
