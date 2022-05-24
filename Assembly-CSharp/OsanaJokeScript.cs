﻿using System;
using UnityEngine;

// Token: 0x02000389 RID: 905
public class OsanaJokeScript : MonoBehaviour
{
	// Token: 0x06001A56 RID: 6742 RVA: 0x0011789C File Offset: 0x00115A9C
	private void Update()
	{
		if (this.Advance)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 14f)
			{
				Application.Quit();
				return;
			}
			if (this.Timer > 3f)
			{
				this.Label.text = "Congratulations! You have beaten Yandere Simulator!";
				if (!this.Jukebox.isPlaying)
				{
					this.Jukebox.clip = this.VictoryMusic;
					this.Jukebox.Play();
					return;
				}
			}
		}
		else if (Input.GetKeyDown("f"))
		{
			this.Rotation[0].enabled = false;
			this.Rotation[1].enabled = false;
			this.Rotation[2].enabled = false;
			this.Rotation[3].enabled = false;
			this.Rotation[4].enabled = false;
			this.Rotation[5].enabled = false;
			this.Rotation[6].enabled = false;
			this.Rotation[7].enabled = false;
			UnityEngine.Object.Instantiate<GameObject>(this.BloodSplatterEffect, this.Head.position, Quaternion.identity);
			this.Head.localScale = new Vector3(0f, 0f, 0f);
			this.Jukebox.clip = this.BloodSplatterSFX;
			this.Jukebox.Play();
			this.Label.text = "";
			this.Advance = true;
		}
	}

	// Token: 0x04002B32 RID: 11058
	public ConstantRandomRotation[] Rotation;

	// Token: 0x04002B33 RID: 11059
	public GameObject BloodSplatterEffect;

	// Token: 0x04002B34 RID: 11060
	public AudioClip BloodSplatterSFX;

	// Token: 0x04002B35 RID: 11061
	public AudioClip VictoryMusic;

	// Token: 0x04002B36 RID: 11062
	public AudioSource Jukebox;

	// Token: 0x04002B37 RID: 11063
	public Transform Head;

	// Token: 0x04002B38 RID: 11064
	public UILabel Label;

	// Token: 0x04002B39 RID: 11065
	public bool Advance;

	// Token: 0x04002B3A RID: 11066
	public float Timer;

	// Token: 0x04002B3B RID: 11067
	public int ID;
}
