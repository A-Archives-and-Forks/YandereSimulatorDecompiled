﻿// Decompiled with JetBrains decompiler
// Type: YandereSimulator.Yancord.Profile
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace YandereSimulator.Yancord
{
  [CreateAssetMenu(fileName = "ChatProfile", menuName = "Yancord/Profile", order = 1)]
  public class Profile : ScriptableObject
  {
    [Header("Personal Information")]
    public string FirstName;
    public string LastName;
    [Space(20f)]
    [Header("Profile Information")]
    public Texture2D ProfilePicture;
    public string Tag = "XXXX";
    [Space(20f)]
    [Header("Profile Settings")]
    public Status CurrentStatus;

    public string GetTag(bool WithHashtag)
    {
      string str = this.Tag;
      if (str.Length > 4)
        str = str.Substring(0, 4);
      return WithHashtag ? "#" + str : str;
    }
  }
}
