﻿using System;
using UnityEngine;

// Token: 0x02000330 RID: 816
public class IdeasMenuScript : MonoBehaviour
{
	// Token: 0x060018D6 RID: 6358 RVA: 0x000F4F44 File Offset: 0x000F3144
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

	// Token: 0x060018D7 RID: 6359 RVA: 0x000F4FA4 File Offset: 0x000F31A4
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

	// Token: 0x060018D8 RID: 6360 RVA: 0x000F5224 File Offset: 0x000F3424
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

	// Token: 0x0400260A RID: 9738
	public InputManagerScript InputManager;

	// Token: 0x0400260B RID: 9739
	public PauseScreenScript PauseScreen;

	// Token: 0x0400260C RID: 9740
	public Transform Highlight;

	// Token: 0x0400260D RID: 9741
	public UILabel Description;

	// Token: 0x0400260E RID: 9742
	public string[] IdeaNames;

	// Token: 0x0400260F RID: 9743
	public string[] Ideas;

	// Token: 0x04002610 RID: 9744
	public UILabel[] Labels;

	// Token: 0x04002611 RID: 9745
	public GameObject List;

	// Token: 0x04002612 RID: 9746
	public int ListSize = 21;

	// Token: 0x04002613 RID: 9747
	public int Selected = 1;

	// Token: 0x04002614 RID: 9748
	public int Offset;

	// Token: 0x04002615 RID: 9749
	public int Limit = 27;
}
