﻿using System;
using UnityEngine;

// Token: 0x0200023A RID: 570
public class CensorBloodScript : MonoBehaviour
{
	// Token: 0x06001232 RID: 4658 RVA: 0x0008B7A0 File Offset: 0x000899A0
	private void Start()
	{
		if (GameGlobals.CensorBlood)
		{
			this.MyParticles.main.startColor = new Color(1f, 1f, 1f, 1f);
			this.MyParticles.colorOverLifetime.enabled = false;
			this.MyParticles.GetComponent<Renderer>().material.mainTexture = this.Flower;
		}
	}

	// Token: 0x040016D6 RID: 5846
	public ParticleSystem MyParticles;

	// Token: 0x040016D7 RID: 5847
	public Texture Flower;
}
