﻿using System;
using UnityEngine;

// Token: 0x02000384 RID: 900
public class OsanaJokeScript : MonoBehaviour
{
	// Token: 0x06001A1D RID: 6685 RVA: 0x00113BA0 File Offset: 0x00111DA0
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

	// Token: 0x04002A93 RID: 10899
	public ConstantRandomRotation[] Rotation;

	// Token: 0x04002A94 RID: 10900
	public GameObject BloodSplatterEffect;

	// Token: 0x04002A95 RID: 10901
	public AudioClip BloodSplatterSFX;

	// Token: 0x04002A96 RID: 10902
	public AudioClip VictoryMusic;

	// Token: 0x04002A97 RID: 10903
	public AudioSource Jukebox;

	// Token: 0x04002A98 RID: 10904
	public Transform Head;

	// Token: 0x04002A99 RID: 10905
	public UILabel Label;

	// Token: 0x04002A9A RID: 10906
	public bool Advance;

	// Token: 0x04002A9B RID: 10907
	public float Timer;

	// Token: 0x04002A9C RID: 10908
	public int ID;
}
