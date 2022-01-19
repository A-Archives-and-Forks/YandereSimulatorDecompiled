﻿using System;
using UnityEngine;

// Token: 0x0200032D RID: 813
public class IdeasMenuScript : MonoBehaviour
{
	// Token: 0x060018B7 RID: 6327 RVA: 0x000F2EC0 File Offset: 0x000F10C0
	private void Start()
	{
		for (int i = 1; i < 11; i++)
		{
			if (!CollectibleGlobals.GetAdvicePurchased(i))
			{
				this.IdeaNames[17 + i] = "?????";
				this.Ideas[17 + i] = "To unlock this information, you'll need to find someone who has experience getting away with murder...";
			}
		}
		this.UpdateHighlightPosition();
		this.Description.enabled = false;
		this.List.SetActive(true);
	}

	// Token: 0x060018B8 RID: 6328 RVA: 0x000F2F20 File Offset: 0x000F1120
	private void Update()
	{
		if (this.List.activeInHierarchy)
		{
			if (this.InputManager.TappedDown)
			{
				this.Selected++;
				this.UpdateHighlightPosition();
				return;
			}
			if (this.InputManager.TappedUp)
			{
				this.Selected--;
				this.UpdateHighlightPosition();
				return;
			}
			if (Input.GetButtonDown("A"))
			{
				this.PauseScreen.PromptBar.ClearButtons();
				this.PauseScreen.PromptBar.Label[1].text = "Back";
				this.PauseScreen.PromptBar.UpdateButtons();
				this.PauseScreen.PromptBar.Show = true;
				this.Description.text = this.Ideas[this.Selected + this.Offset];
				this.Description.text = this.Description.text.Replace('@', '\n');
				this.Description.enabled = true;
				this.List.SetActive(false);
				return;
			}
			if (Input.GetButtonDown("B"))
			{
				this.PauseScreen.PromptBar.ClearButtons();
				this.PauseScreen.PromptBar.Label[0].text = "Accept";
				this.PauseScreen.PromptBar.Label[1].text = "Exit";
				this.PauseScreen.PromptBar.Label[4].text = "Choose";
				this.PauseScreen.PromptBar.Label[5].text = "Choose";
				this.PauseScreen.PromptBar.UpdateButtons();
				this.PauseScreen.MainMenu.SetActive(true);
				base.gameObject.SetActive(false);
				return;
			}
		}
		else if (Input.GetButtonDown("B"))
		{
			this.PauseScreen.PromptBar.ClearButtons();
			this.PauseScreen.PromptBar.Label[0].text = "Confirm";
			this.PauseScreen.PromptBar.Label[1].text = "Back";
			this.PauseScreen.PromptBar.Label[4].text = "Choose";
			this.PauseScreen.PromptBar.UpdateButtons();
			this.PauseScreen.PromptBar.Show = true;
			this.Description.enabled = false;
			this.List.SetActive(true);
		}
	}

	// Token: 0x060018B9 RID: 6329 RVA: 0x000F31A0 File Offset: 0x000F13A0
	private void UpdateHighlightPosition()
	{
		if (this.Selected < 1)
		{
			this.Selected = 1;
			this.Offset--;
		}
		else if (this.Selected > this.ListSize)
		{
			this.Selected = this.ListSize;
			this.Offset++;
		}
		if (this.Offset < 0)
		{
			this.Selected = this.ListSize;
			this.Offset = this.Limit - this.ListSize;
		}
		else if (this.Offset > this.Limit - this.ListSize)
		{
			this.Selected = 1;
			this.Offset = 0;
		}
		for (int i = 1; i < this.Labels.Length; i++)
		{
			this.Labels[i].text = this.IdeaNames[i + this.Offset];
		}
		this.Highlight.transform.localPosition = new Vector3(-125f, (float)(550 - this.Selected * 50), 0f);
	}

	// Token: 0x040025AE RID: 9646
	public InputManagerScript InputManager;

	// Token: 0x040025AF RID: 9647
	public PauseScreenScript PauseScreen;

	// Token: 0x040025B0 RID: 9648
	public Transform Highlight;

	// Token: 0x040025B1 RID: 9649
	public UILabel Description;

	// Token: 0x040025B2 RID: 9650
	public string[] IdeaNames;

	// Token: 0x040025B3 RID: 9651
	public string[] Ideas;

	// Token: 0x040025B4 RID: 9652
	public UILabel[] Labels;

	// Token: 0x040025B5 RID: 9653
	public GameObject List;

	// Token: 0x040025B6 RID: 9654
	public int ListSize = 21;

	// Token: 0x040025B7 RID: 9655
	public int Selected = 1;

	// Token: 0x040025B8 RID: 9656
	public int Offset;

	// Token: 0x040025B9 RID: 9657
	public int Limit = 27;
}
