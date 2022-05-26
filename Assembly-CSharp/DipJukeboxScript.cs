﻿// Decompiled with JetBrains decompiler
// Type: DipJukeboxScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class DipJukeboxScript : MonoBehaviour
{
  public JukeboxScript Jukebox;
  public AudioSource MyAudio;
  public Transform Yandere;

  private void Update()
  {
    if (this.MyAudio.isPlaying)
    {
      float num = Vector3.Distance(this.Yandere.position, this.transform.position);
      if ((double) num >= 8.0)
        return;
      this.Jukebox.ClubDip = Mathf.MoveTowards(this.Jukebox.ClubDip, (float) ((7.0 - (double) num) * 0.25) * this.Jukebox.Volume, Time.deltaTime);
      if ((double) this.Jukebox.ClubDip < 0.0)
        this.Jukebox.ClubDip = 0.0f;
      if ((double) this.Jukebox.ClubDip <= (double) this.Jukebox.Volume)
        return;
      this.Jukebox.ClubDip = this.Jukebox.Volume;
    }
    else
    {
      if (!this.MyAudio.isPlaying)
        return;
      this.Jukebox.ClubDip = 0.0f;
    }
  }
}
