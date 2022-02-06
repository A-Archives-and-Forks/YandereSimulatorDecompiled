﻿using System;
using UnityEngine;

// Token: 0x02000283 RID: 643
public class DipJukeboxScript : MonoBehaviour
{
	// Token: 0x0600138D RID: 5005 RVA: 0x000B7924 File Offset: 0x000B5B24
	private void Update()
	{
		if (this.MyAudio.isPlaying)
		{
			float num = Vector3.Distance(this.Yandere.position, base.transform.position);
			if (num < 8f)
			{
				this.Jukebox.ClubDip = Mathf.MoveTowards(this.Jukebox.ClubDip, (7f - num) * 0.25f * this.Jukebox.Volume, Time.deltaTime);
				if (this.Jukebox.ClubDip < 0f)
				{
					this.Jukebox.ClubDip = 0f;
				}
				if (this.Jukebox.ClubDip > this.Jukebox.Volume)
				{
					this.Jukebox.ClubDip = this.Jukebox.Volume;
					return;
				}
			}
		}
		else if (this.MyAudio.isPlaying)
		{
			this.Jukebox.ClubDip = 0f;
		}
	}

	// Token: 0x04001CFE RID: 7422
	public JukeboxScript Jukebox;

	// Token: 0x04001CFF RID: 7423
	public AudioSource MyAudio;

	// Token: 0x04001D00 RID: 7424
	public Transform Yandere;
}
