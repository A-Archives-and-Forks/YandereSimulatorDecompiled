﻿using System;
using UnityEngine;

// Token: 0x0200032F RID: 815
public class IdolStageScript : MonoBehaviour
{
	// Token: 0x060018C5 RID: 6341 RVA: 0x000F3A54 File Offset: 0x000F1C54
	private void Update()
	{
		for (int i = 1; i < 5; i++)
		{
			if (this.StudentManager.Students[51 + i] != null)
			{
				if (Vector3.Distance(this.StudentManager.Students[51 + i].transform.position, this.Spot[i].position) < 1f && this.StudentManager.Students[51 + i].Routine && !this.StudentManager.Students[51 + i].Alarmed)
				{
					Debug.Log("LMC Member #" + i.ToString() + " is at their spot on the stage.");
					this.Music[i].volume = Mathf.MoveTowards(this.Music[i].volume, 1f, Time.deltaTime);
				}
				else
				{
					this.Music[i].volume = Mathf.MoveTowards(this.Music[i].volume, 0f, Time.deltaTime);
				}
			}
		}
		if (this.StudentManager.Students[16] != null)
		{
			if (Vector3.Distance(this.StudentManager.Students[16].transform.position, this.Spot[5].position) < 1f && this.StudentManager.Students[16].Routine && !this.StudentManager.Students[16].Alarmed)
			{
				this.Music[5].volume = Mathf.MoveTowards(this.Music[5].volume, 1f, Time.deltaTime);
			}
			else
			{
				this.Music[5].volume = Mathf.MoveTowards(this.Music[5].volume, 0f, Time.deltaTime);
			}
		}
		if (Vector3.Distance(this.Yandere.position, base.transform.position) < 10f)
		{
			this.Jukebox.Dip = Mathf.MoveTowards(this.Jukebox.Dip, 0f, Time.deltaTime);
			this.RestoreVolume = true;
			return;
		}
		if (this.RestoreVolume)
		{
			this.Jukebox.Dip = Mathf.MoveTowards(this.Jukebox.Dip, 1f, Time.deltaTime);
			if (this.Jukebox.Dip == 0f)
			{
				this.RestoreVolume = false;
			}
		}
	}

	// Token: 0x040025CA RID: 9674
	public StudentManagerScript StudentManager;

	// Token: 0x040025CB RID: 9675
	public JukeboxScript Jukebox;

	// Token: 0x040025CC RID: 9676
	public AudioSource[] Music;

	// Token: 0x040025CD RID: 9677
	public Transform[] Spot;

	// Token: 0x040025CE RID: 9678
	public Transform Yandere;

	// Token: 0x040025CF RID: 9679
	public bool RestoreVolume;
}
