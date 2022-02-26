﻿using System;
using UnityEngine;

// Token: 0x02000284 RID: 644
public class DipJukeboxScript : MonoBehaviour
{
	// Token: 0x06001391 RID: 5009 RVA: 0x000B7A74 File Offset: 0x000B5C74
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

	// Token: 0x04001D02 RID: 7426
	public JukeboxScript Jukebox;

	// Token: 0x04001D03 RID: 7427
	public AudioSource MyAudio;

	// Token: 0x04001D04 RID: 7428
	public Transform Yandere;
}
