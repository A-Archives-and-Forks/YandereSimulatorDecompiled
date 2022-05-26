﻿// Decompiled with JetBrains decompiler
// Type: BodyPartScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class BodyPartScript : MonoBehaviour
{
  public bool Sacrifice;
  public int StudentID;
  public int Type;
  public GameObject GarbageBag;
  public PromptScript Prompt;
  public AudioClip WrapSFX;

  private void Update()
  {
    if (!((Object) this.Prompt != (Object) null))
      return;
    if ((Object) this.Prompt.Yandere.PickUp != (Object) null && this.Prompt.Yandere.PickUp.GarbageBagBox)
    {
      this.Prompt.HideButton[0] = false;
      if ((double) this.Prompt.Circle[0].fillAmount != 0.0)
        return;
      GameObject gameObject = Object.Instantiate<GameObject>(this.GarbageBag, this.transform.position, Quaternion.identity);
      gameObject.GetComponent<BodyPartScript>().StudentID = this.StudentID;
      gameObject.transform.parent = this.Prompt.Yandere.Police.GarbageParent;
      this.Prompt.Yandere.StudentManager.GarbageBagList[this.Prompt.Yandere.StudentManager.GarbageBags] = gameObject;
      ++this.Prompt.Yandere.StudentManager.GarbageBags;
      AudioSource.PlayClipAtPoint(this.WrapSFX, this.transform.position);
      Object.Destroy((Object) this.gameObject);
    }
    else
      this.Prompt.HideButton[0] = true;
  }
}
