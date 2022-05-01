﻿using System;
using UnityEngine;

// Token: 0x0200024F RID: 591
public class ClubAmbienceScript : MonoBehaviour
{
	// Token: 0x0600127B RID: 4731 RVA: 0x00091000 File Offset: 0x0008F200
	private void Update()
	{
		if (this.Yandere.position.y > base.transform.position.y - 0.1f && this.Yandere.position.y < base.transform.position.y + 0.1f)
		{
			if (Vector3.Distance(base.transform.position, this.Yandere.position) < 4f)
			{
				this.CreateAmbience = true;
				this.EffectJukebox = true;
			}
			else
			{
				this.CreateAmbience = false;
			}
		}
		if (this.EffectJukebox)
		{
			AudioSource component = base.GetComponent<AudioSource>();
			if (this.CreateAmbience)
			{
				component.volume = Mathf.MoveTowards(component.volume, this.MaxVolume, Time.deltaTime * 0.1f);
				this.Jukebox.ClubDip = Mathf.MoveTowards(this.Jukebox.ClubDip, this.ClubDip, Time.deltaTime * 0.1f);
				return;
			}
			component.volume = Mathf.MoveTowards(component.volume, 0f, Time.deltaTime * 0.1f);
			this.Jukebox.ClubDip = Mathf.MoveTowards(this.Jukebox.ClubDip, 0f, Time.deltaTime * 0.1f);
			if (this.Jukebox.ClubDip == 0f)
			{
				this.EffectJukebox = false;
			}
		}
	}

	// Token: 0x040017CE RID: 6094
	public JukeboxScript Jukebox;

	// Token: 0x040017CF RID: 6095
	public Transform Yandere;

	// Token: 0x040017D0 RID: 6096
	public bool CreateAmbience;

	// Token: 0x040017D1 RID: 6097
	public bool EffectJukebox;

	// Token: 0x040017D2 RID: 6098
	public float ClubDip;

	// Token: 0x040017D3 RID: 6099
	public float MaxVolume;
}
