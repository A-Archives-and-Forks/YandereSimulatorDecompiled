﻿using System;
using UnityEngine;

// Token: 0x020002D4 RID: 724
public class FunGirlScript : MonoBehaviour
{
	// Token: 0x060014B3 RID: 5299 RVA: 0x000CB475 File Offset: 0x000C9675
	private void Start()
	{
		this.ChaseYandereChan();
	}

	// Token: 0x060014B4 RID: 5300 RVA: 0x000CB480 File Offset: 0x000C9680
	private void Update()
	{
		if (this.Speed < 5f)
		{
			this.Speed += Time.deltaTime * 0.1f;
		}
		else
		{
			this.Speed = 5f;
		}
		base.transform.position = Vector3.MoveTowards(base.transform.position, this.Yandere.position, Time.deltaTime * this.Speed);
		base.transform.LookAt(this.Yandere.position);
		if (Vector3.Distance(base.transform.position, this.Yandere.position) < 0.5f)
		{
			Application.Quit();
		}
	}

	// Token: 0x060014B5 RID: 5301 RVA: 0x000CB530 File Offset: 0x000C9730
	private void ChaseYandereChan()
	{
		SchoolGlobals.SchoolAtmosphereSet = true;
		SchoolGlobals.SchoolAtmosphere = 0f;
		this.StudentManager.SetAtmosphere();
		foreach (StudentScript studentScript in this.StudentManager.Students)
		{
			if (studentScript != null)
			{
				studentScript.gameObject.SetActive(false);
			}
		}
		this.StudentManager.Yandere.NoDebug = true;
		base.gameObject.SetActive(true);
		this.Jukebox.SetActive(false);
		this.HUD.enabled = false;
	}

	// Token: 0x04002076 RID: 8310
	public StudentManagerScript StudentManager;

	// Token: 0x04002077 RID: 8311
	public GameObject Jukebox;

	// Token: 0x04002078 RID: 8312
	public Transform Yandere;

	// Token: 0x04002079 RID: 8313
	public UIPanel HUD;

	// Token: 0x0400207A RID: 8314
	public float Speed;
}
