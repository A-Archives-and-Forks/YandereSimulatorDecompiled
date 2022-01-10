﻿using System;
using UnityEngine;

// Token: 0x02000396 RID: 918
public class PeekScript : MonoBehaviour
{
	// Token: 0x06001A57 RID: 6743 RVA: 0x00119553 File Offset: 0x00117753
	private void Start()
	{
		this.Prompt.Door = true;
	}

	// Token: 0x06001A58 RID: 6744 RVA: 0x00119564 File Offset: 0x00117764
	private void Update()
	{
		if (Vector3.Distance(base.transform.position, this.Prompt.Yandere.transform.position) < 2f)
		{
			this.Prompt.Yandere.StudentManager.TutorialWindow.ShowInfoMessage = true;
		}
		if (this.InfoChanWindow.Drop)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (!this.Prompt.Yandere.Chased && this.Prompt.Yandere.Chasers == 0)
			{
				this.Prompt.Yandere.CanMove = false;
				this.PeekCamera.SetActive(true);
				this.BlueLight.SetActive(true);
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[1].text = "Stop";
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = true;
			}
		}
		if (this.PeekCamera.activeInHierarchy)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 5f && !this.Spoke)
			{
				this.Subtitle.UpdateLabel(SubtitleType.InfoNotice, 0, 6.5f);
				this.Spoke = true;
				base.GetComponent<AudioSource>().Play();
			}
			if (Input.GetButtonDown("B") || this.Prompt.Yandere.Noticed || this.Prompt.Yandere.Sprayed)
			{
				if (!this.Prompt.Yandere.Noticed && !this.Prompt.Yandere.Sprayed)
				{
					this.Prompt.Yandere.CanMove = true;
				}
				this.PeekCamera.SetActive(false);
				this.BlueLight.SetActive(false);
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
				this.Timer = 0f;
			}
		}
	}

	// Token: 0x04002B44 RID: 11076
	public InfoChanWindowScript InfoChanWindow;

	// Token: 0x04002B45 RID: 11077
	public PromptBarScript PromptBar;

	// Token: 0x04002B46 RID: 11078
	public SubtitleScript Subtitle;

	// Token: 0x04002B47 RID: 11079
	public JukeboxScript Jukebox;

	// Token: 0x04002B48 RID: 11080
	public PromptScript Prompt;

	// Token: 0x04002B49 RID: 11081
	public GameObject BlueLight;

	// Token: 0x04002B4A RID: 11082
	public GameObject PeekCamera;

	// Token: 0x04002B4B RID: 11083
	public bool Spoke;

	// Token: 0x04002B4C RID: 11084
	public float Timer;
}
