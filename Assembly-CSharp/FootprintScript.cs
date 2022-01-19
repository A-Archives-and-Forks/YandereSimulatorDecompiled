﻿using System;
using UnityEngine;

// Token: 0x020002CF RID: 719
public class FootprintScript : MonoBehaviour
{
	// Token: 0x060014A5 RID: 5285 RVA: 0x000CAB68 File Offset: 0x000C8D68
	private void Start()
	{
		if (this.Yandere.Schoolwear == 0 || this.Yandere.Schoolwear == 2 || (this.Yandere.ClubAttire && this.Yandere.Club == ClubType.MartialArts) || this.Yandere.Hungry || this.Yandere.LucyHelmet.activeInHierarchy)
		{
			base.GetComponent<Renderer>().material.mainTexture = this.Footprint;
		}
		if (GameGlobals.CensorBlood)
		{
			base.GetComponent<Renderer>().material.mainTexture = this.Flower;
			base.transform.localScale = new Vector3(0.2f, 0.2f, 1f);
		}
		UnityEngine.Object.Destroy(this);
	}

	// Token: 0x04002048 RID: 8264
	public YandereScript Yandere;

	// Token: 0x04002049 RID: 8265
	public Texture Footprint;

	// Token: 0x0400204A RID: 8266
	public Texture Flower;
}
