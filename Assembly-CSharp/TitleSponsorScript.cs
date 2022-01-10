﻿using System;
using UnityEngine;

// Token: 0x02000477 RID: 1143
public class TitleSponsorScript : MonoBehaviour
{
	// Token: 0x06001EBD RID: 7869 RVA: 0x001AFA89 File Offset: 0x001ADC89
	private void Start()
	{
		this.UpdateHighlight();
		if (GameGlobals.LoveSick)
		{
			this.TurnLoveSick();
		}
	}

	// Token: 0x06001EBE RID: 7870 RVA: 0x001AFA9E File Offset: 0x001ADC9E
	public int GetSponsorIndex()
	{
		return this.Column + this.Row * this.Columns;
	}

	// Token: 0x06001EBF RID: 7871 RVA: 0x001AFAB4 File Offset: 0x001ADCB4
	public bool SponsorHasWebsite(int index)
	{
		return !string.IsNullOrEmpty(this.SponsorURLs[index]);
	}

	// Token: 0x06001EC0 RID: 7872 RVA: 0x001AFAC8 File Offset: 0x001ADCC8
	private void Update()
	{
		if (this.InputManager.TappedUp)
		{
			this.Row = ((this.Row > 0) ? (this.Row - 1) : (this.Rows - 1));
		}
		if (this.InputManager.TappedDown)
		{
			this.Row = ((this.Row < this.Rows - 1) ? (this.Row + 1) : 0);
		}
		if (this.InputManager.TappedRight)
		{
			this.Column = ((this.Column < this.Columns - 1) ? (this.Column + 1) : 0);
		}
		if (this.InputManager.TappedLeft)
		{
			this.Column = ((this.Column > 0) ? (this.Column - 1) : (this.Columns - 1));
		}
		if (this.InputManager.TappedUp || this.InputManager.TappedDown || this.InputManager.TappedRight || this.InputManager.TappedLeft)
		{
			this.UpdateHighlight();
		}
		if (this.NewTitleScreen.Speed > 3f)
		{
			if (!this.PromptBar.Show)
			{
				this.PromptBar.ClearButtons();
				this.PromptBar.Label[0].text = "Make Selection";
				this.PromptBar.Label[1].text = "Go Back";
				this.PromptBar.Label[4].text = "Change Selection";
				this.PromptBar.Label[5].text = "Change Selection";
				this.PromptBar.UpdateButtons();
				this.PromptBar.Show = true;
			}
			if (Input.GetButtonDown("A"))
			{
				int sponsorIndex = this.GetSponsorIndex();
				if (this.SponsorHasWebsite(sponsorIndex))
				{
					Application.OpenURL(this.SponsorURLs[sponsorIndex]);
				}
			}
			if (Input.GetButtonDown("B"))
			{
				this.NewTitleScreen.Speed = 0f;
				this.NewTitleScreen.Phase = 2;
				this.PromptBar.Show = false;
				base.enabled = false;
			}
		}
	}

	// Token: 0x06001EC1 RID: 7873 RVA: 0x001AFCD0 File Offset: 0x001ADED0
	private void UpdateHighlight()
	{
		this.Highlight.localPosition = new Vector3(-384f + (float)this.Column * 256f, 128f - (float)this.Row * 256f, this.Highlight.localPosition.z);
		this.SponsorName.text = this.Sponsors[this.GetSponsorIndex()];
	}

	// Token: 0x06001EC2 RID: 7874 RVA: 0x001AFD3C File Offset: 0x001ADF3C
	private void TurnLoveSick()
	{
		this.BlackSprite.color = Color.black;
		foreach (UISprite uisprite in this.RedSprites)
		{
			uisprite.color = new Color(1f, 0f, 0f, uisprite.color.a);
		}
		foreach (UILabel uilabel in this.Labels)
		{
			uilabel.color = new Color(1f, 0f, 0f, uilabel.color.a);
		}
	}

	// Token: 0x04003FCB RID: 16331
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x04003FCC RID: 16332
	public InputManagerScript InputManager;

	// Token: 0x04003FCD RID: 16333
	public PromptBarScript PromptBar;

	// Token: 0x04003FCE RID: 16334
	public string[] SponsorURLs;

	// Token: 0x04003FCF RID: 16335
	public string[] Sponsors;

	// Token: 0x04003FD0 RID: 16336
	public UILabel SponsorName;

	// Token: 0x04003FD1 RID: 16337
	public Transform Highlight;

	// Token: 0x04003FD2 RID: 16338
	public bool Show;

	// Token: 0x04003FD3 RID: 16339
	public int Columns;

	// Token: 0x04003FD4 RID: 16340
	public int Rows;

	// Token: 0x04003FD5 RID: 16341
	private int Column;

	// Token: 0x04003FD6 RID: 16342
	private int Row;

	// Token: 0x04003FD7 RID: 16343
	public UISprite BlackSprite;

	// Token: 0x04003FD8 RID: 16344
	public UISprite[] RedSprites;

	// Token: 0x04003FD9 RID: 16345
	public UILabel[] Labels;
}
