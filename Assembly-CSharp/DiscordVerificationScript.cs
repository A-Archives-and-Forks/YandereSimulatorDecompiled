﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000288 RID: 648
public class DiscordVerificationScript : MonoBehaviour
{
	// Token: 0x060013A8 RID: 5032 RVA: 0x000B8A36 File Offset: 0x000B6C36
	private void Update()
	{
		if (Input.GetKeyDown("q"))
		{
			SceneManager.LoadScene("MissionModeScene");
		}
	}
}
