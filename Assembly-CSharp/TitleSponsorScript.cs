﻿using System;
using UnityEngine;

// Token: 0x02000478 RID: 1144
public class TitleSponsorScript : MonoBehaviour
{
	// Token: 0x06001EC0 RID: 7872 RVA: 0x001B0C31 File Offset: 0x001AEE31
	private void Start()
	{
		this.UpdateHighlight();
		if (GameGlobals.LoveSick)
		{
			this.TurnLoveSick();
		}
	}

	// Token: 0x06001EC1 RID: 7873 RVA: 0x001B0C46 File Offset: 0x001AEE46
	public int GetSponsorIndex()
	{
		return this.Column + this.Row * this.Columns;
	}

	// Token: 0x06001EC2 RID: 7874 RVA: 0x001B0C5C File Offset: 0x001AEE5C
	public bool SponsorHasWebsite(int index)
	{
		return !string.IsNullOrEmpty(this.SponsorURLs[index]);
	}

	// Token: 0x06001EC3 RID: 7875 RVA: 0x001B0C70 File Offset: 0x001AEE70
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

	// Token: 0x06001EC4 RID: 7876 RVA: 0x001B0E78 File Offset: 0x001AF078
	private void UpdateHighlight()
	{
		this.Highlight.localPosition = new Vector3(-384f + (float)this.Column * 256f, 128f - (float)this.Row * 256f, this.Highlight.localPosition.z);
		this.SponsorName.text = this.Sponsors[this.GetSponsorIndex()];
	}

	// Token: 0x06001EC5 RID: 7877 RVA: 0x001B0EE4 File Offset: 0x001AF0E4
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

	// Token: 0x04003FDA RID: 16346
	public NewTitleScreenScript NewTitleScreen;

	// Token: 0x04003FDB RID: 16347
	public InputManagerScript InputManager;

	// Token: 0x04003FDC RID: 16348
	public PromptBarScript PromptBar;

	// Token: 0x04003FDD RID: 16349
	public string[] SponsorURLs;

	// Token: 0x04003FDE RID: 16350
	public string[] Sponsors;

	// Token: 0x04003FDF RID: 16351
	public UILabel SponsorName;

	// Token: 0x04003FE0 RID: 16352
	public Transform Highlight;

	// Token: 0x04003FE1 RID: 16353
	public bool Show;

	// Token: 0x04003FE2 RID: 16354
	public int Columns;

	// Token: 0x04003FE3 RID: 16355
	public int Rows;

	// Token: 0x04003FE4 RID: 16356
	private int Column;

	// Token: 0x04003FE5 RID: 16357
	private int Row;

	// Token: 0x04003FE6 RID: 16358
	public UISprite BlackSprite;

	// Token: 0x04003FE7 RID: 16359
	public UISprite[] RedSprites;

	// Token: 0x04003FE8 RID: 16360
	public UILabel[] Labels;
}
