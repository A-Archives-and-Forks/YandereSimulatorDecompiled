﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020000CC RID: 204
public class AntiCheatScript : MonoBehaviour
{
	// Token: 0x060009C5 RID: 2501 RVA: 0x00051766 File Offset: 0x0004F966
	private void Start()
	{
		this.MyAudio = base.GetComponent<AudioSource>();
	}

	// Token: 0x060009C6 RID: 2502 RVA: 0x00051774 File Offset: 0x0004F974
	private void Update()
	{
		if (this.Check && !this.MyAudio.isPlaying)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

	// Token: 0x060009C7 RID: 2503 RVA: 0x000517A8 File Offset: 0x0004F9A8
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YandereChan")
		{
			this.Jukebox.SetActive(false);
			this.Check = true;
			this.MyAudio.Play();
		}
	}

	// Token: 0x04000A31 RID: 2609
	public AudioSource MyAudio;

	// Token: 0x04000A32 RID: 2610
	public GameObject Jukebox;

	// Token: 0x04000A33 RID: 2611
	public bool Check;
}
