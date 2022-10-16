﻿// Decompiled with JetBrains decompiler
// Type: YandereSimulator.Yancord.MessageScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace YandereSimulator.Yancord
{
  public class MessageScript : MonoBehaviour
  {
    [Header("== Partner Informations ==")]
    public Profile MyProfile;
    [Space(20f)]
    public UILabel NameLabel;
    public UILabel MessageLabel;
    public UITexture ProfilPictureTexture;

    public void Awake()
    {
      if (!((Object) this.MyProfile != (Object) null))
        return;
      if ((Object) this.NameLabel != (Object) null)
        this.NameLabel.text = this.MyProfile.FirstName + " " + this.MyProfile.LastName;
      if ((Object) this.ProfilPictureTexture != (Object) null)
        this.ProfilPictureTexture.mainTexture = (Texture) this.MyProfile.ProfilePicture;
      this.gameObject.name = this.MyProfile.FirstName + "_Message";
    }
  }
}
