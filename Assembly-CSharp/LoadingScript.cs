﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000355 RID: 853
public class LoadingScript : MonoBehaviour
{
	// Token: 0x06001971 RID: 6513 RVA: 0x00101C76 File Offset: 0x000FFE76
	private void Start()
	{
		SceneManager.LoadScene("SchoolScene");
	}
}
