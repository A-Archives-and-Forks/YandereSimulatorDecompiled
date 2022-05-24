﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000443 RID: 1091
public class SponsorScript : MonoBehaviour
{
	// Token: 0x06001D1C RID: 7452 RVA: 0x0015BE68 File Offset: 0x0015A068
	private void Start()
	{
		Time.timeScale = 1f;
		this.Set[1].SetActive(true);
		this.Set[2].SetActive(false);
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, 1f);
	}

	// Token: 0x06001D1D RID: 7453 RVA: 0x0015BEE0 File Offset: 0x0015A0E0
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer < 3.2f)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
			return;
		}
		this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
		if (this.Darkness.color.a == 1f)
		{
			SceneManager.LoadScene("NewTitleScene");
		}
	}

	// Token: 0x040034C2 RID: 13506
	public GameObject[] Set;

	// Token: 0x040034C3 RID: 13507
	public UISprite Darkness;

	// Token: 0x040034C4 RID: 13508
	public float Timer;

	// Token: 0x040034C5 RID: 13509
	public int ID;
}
