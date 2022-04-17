﻿using System;
using System.IO;
using UnityEngine;

// Token: 0x0200044B RID: 1099
public class StatsScript : MonoBehaviour
{
	// Token: 0x06001D3D RID: 7485 RVA: 0x0015DFBC File Offset: 0x0015C1BC
	private void Awake()
	{
		this.ClubLabels = new ClubTypeAndStringDictionary
		{
			{
				ClubType.None,
				"None"
			},
			{
				ClubType.Cooking,
				"Cooking"
			},
			{
				ClubType.Drama,
				"Drama"
			},
			{
				ClubType.Occult,
				"Occult"
			},
			{
				ClubType.Art,
				"Art"
			},
			{
				ClubType.LightMusic,
				"Light Music"
			},
			{
				ClubType.MartialArts,
				"Martial Arts"
			},
			{
				ClubType.Photography,
				"Photography"
			},
			{
				ClubType.Science,
				"Science"
			},
			{
				ClubType.Sports,
				"Sports"
			},
			{
				ClubType.Gardening,
				"Gardening"
			},
			{
				ClubType.Gaming,
				"Gaming"
			}
		};
	}

	// Token: 0x06001D3E RID: 7486 RVA: 0x0015E068 File Offset: 0x0015C268
	private void Start()
	{
		if (this.PauseScreen.Eighties)
		{
			this.Portrait.mainTexture = this.RyobaPortrait;
		}
		if (File.Exists(Application.streamingAssetsPath + "/CustomPortrait.txt") && File.ReadAllText(Application.streamingAssetsPath + "/CustomPortrait.txt") == "1")
		{
			WWW www = new WWW("file:///" + Application.streamingAssetsPath + "/CustomPortrait.png");
			this.Portrait.mainTexture = www.texture;
		}
	}

	// Token: 0x06001D3F RID: 7487 RVA: 0x0015E0F4 File Offset: 0x0015C2F4
	private void Update()
	{
		if (Input.GetButtonDown("B"))
		{
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Accept";
			this.PromptBar.Label[1].text = "Exit";
			this.PromptBar.Label[4].text = "Choose";
			this.PromptBar.UpdateButtons();
			this.PauseScreen.MainMenu.SetActive(true);
			this.PauseScreen.Sideways = false;
			this.PauseScreen.PressedB = true;
			base.gameObject.SetActive(false);
		}
	}

	// Token: 0x06001D40 RID: 7488 RVA: 0x0015E1A0 File Offset: 0x0015C3A0
	public void UpdateStats()
	{
		Debug.Log("The Stats script just checked the Class script for info and updated the bars accordingly.");
		this.Grade = this.Class.BiologyGrade;
		this.BarID = 1;
		while (this.BarID < 6)
		{
			UISprite uisprite = this.Subject1Bars[this.BarID];
			if (this.Grade > 0)
			{
				uisprite.color = new Color(1f, 1f, 1f, 1f);
				this.Grade--;
			}
			else
			{
				uisprite.color = new Color(1f, 1f, 1f, 0.5f);
			}
			this.BarID++;
		}
		if (this.Class.BiologyGrade < 5)
		{
			this.Subject1Bars[this.Class.BiologyGrade + 1].color = ((this.Class.BiologyBonus > 0) ? new Color(1f, 0f, 0f, 1f) : new Color(1f, 1f, 1f, 0.5f));
		}
		this.Grade = this.Class.ChemistryGrade;
		this.BarID = 1;
		while (this.BarID < 6)
		{
			UISprite uisprite2 = this.Subject2Bars[this.BarID];
			if (this.Grade > 0)
			{
				uisprite2.color = new Color(uisprite2.color.r, uisprite2.color.g, uisprite2.color.b, 1f);
				this.Grade--;
			}
			else
			{
				uisprite2.color = new Color(uisprite2.color.r, uisprite2.color.g, uisprite2.color.b, 0.5f);
			}
			this.BarID++;
		}
		if (this.Class.ChemistryGrade < 5)
		{
			this.Subject2Bars[this.Class.ChemistryGrade + 1].color = ((this.Class.ChemistryBonus > 0) ? new Color(1f, 0f, 0f, 1f) : new Color(1f, 1f, 1f, 0.5f));
		}
		this.Grade = this.Class.LanguageGrade;
		this.BarID = 1;
		while (this.BarID < 6)
		{
			UISprite uisprite3 = this.Subject3Bars[this.BarID];
			if (this.Grade > 0)
			{
				uisprite3.color = new Color(uisprite3.color.r, uisprite3.color.g, uisprite3.color.b, 1f);
				this.Grade--;
			}
			else
			{
				uisprite3.color = new Color(uisprite3.color.r, uisprite3.color.g, uisprite3.color.b, 0.5f);
			}
			this.BarID++;
		}
		if (this.Class.LanguageGrade < 5)
		{
			this.Subject3Bars[this.Class.LanguageGrade + 1].color = ((this.Class.LanguageBonus > 0) ? new Color(1f, 0f, 0f, 1f) : new Color(1f, 1f, 1f, 0.5f));
		}
		this.Grade = this.Class.PhysicalGrade;
		this.BarID = 1;
		while (this.BarID < 6)
		{
			UISprite uisprite4 = this.Subject4Bars[this.BarID];
			if (this.Grade > 0)
			{
				uisprite4.color = new Color(uisprite4.color.r, uisprite4.color.g, uisprite4.color.b, 1f);
				this.Grade--;
			}
			else
			{
				uisprite4.color = new Color(uisprite4.color.r, uisprite4.color.g, uisprite4.color.b, 0.5f);
			}
			this.BarID++;
		}
		if (this.Class.PhysicalGrade < 5)
		{
			this.Subject4Bars[this.Class.PhysicalGrade + 1].color = ((this.Class.PhysicalBonus > 0) ? new Color(1f, 0f, 0f, 1f) : new Color(1f, 1f, 1f, 0.5f));
		}
		this.Grade = this.Class.PsychologyGrade;
		this.BarID = 1;
		while (this.BarID < 6)
		{
			UISprite uisprite5 = this.Subject5Bars[this.BarID];
			if (this.Grade > 0)
			{
				uisprite5.color = new Color(uisprite5.color.r, uisprite5.color.g, uisprite5.color.b, 1f);
				this.Grade--;
			}
			else
			{
				uisprite5.color = new Color(uisprite5.color.r, uisprite5.color.g, uisprite5.color.b, 0.5f);
			}
			this.BarID++;
		}
		if (this.Class.PsychologyGrade < 5)
		{
			this.Subject5Bars[this.Class.PsychologyGrade + 1].color = ((this.Class.PsychologyBonus > 0) ? new Color(1f, 0f, 0f, 1f) : new Color(1f, 1f, 1f, 0.5f));
		}
		this.Grade = this.Class.Seduction;
		this.BarID = 1;
		while (this.BarID < 6)
		{
			UISprite uisprite6 = this.Subject6Bars[this.BarID];
			if (this.Grade > 0)
			{
				uisprite6.color = new Color(uisprite6.color.r, uisprite6.color.g, uisprite6.color.b, 1f);
				this.Grade--;
			}
			else
			{
				uisprite6.color = new Color(uisprite6.color.r, uisprite6.color.g, uisprite6.color.b, 0.5f);
			}
			this.BarID++;
		}
		if (this.Class.Seduction < 5)
		{
			this.Subject6Bars[this.Class.Seduction + 1].color = ((this.Class.SeductionBonus > 0) ? new Color(1f, 0f, 0f, 1f) : new Color(1f, 1f, 1f, 0.5f));
		}
		this.Grade = this.Class.Numbness;
		this.BarID = 1;
		while (this.BarID < 6)
		{
			UISprite uisprite7 = this.Subject7Bars[this.BarID];
			if (this.Grade > 0)
			{
				uisprite7.color = new Color(uisprite7.color.r, uisprite7.color.g, uisprite7.color.b, 1f);
				this.Grade--;
			}
			else
			{
				uisprite7.color = new Color(uisprite7.color.r, uisprite7.color.g, uisprite7.color.b, 0.5f);
			}
			this.BarID++;
		}
		if (this.Class.Numbness < 5)
		{
			this.Subject7Bars[this.Class.Numbness + 1].color = ((this.Class.NumbnessBonus > 0) ? new Color(1f, 0f, 0f, 1f) : new Color(1f, 1f, 1f, 0.5f));
		}
		this.Grade = this.Class.Enlightenment;
		this.BarID = 1;
		while (this.BarID < 6)
		{
			UISprite uisprite8 = this.Subject8Bars[this.BarID];
			if (this.Grade > 0)
			{
				uisprite8.color = new Color(uisprite8.color.r, uisprite8.color.g, uisprite8.color.b, 1f);
				this.Grade--;
			}
			else
			{
				uisprite8.color = new Color(uisprite8.color.r, uisprite8.color.g, uisprite8.color.b, 0.5f);
			}
			this.BarID++;
		}
		if (this.Class.Enlightenment < 5)
		{
			this.Subject8Bars[this.Class.Enlightenment + 1].color = ((this.Class.EnlightenmentBonus > 0) ? new Color(1f, 0f, 0f, 1f) : new Color(1f, 1f, 1f, 0.5f));
		}
		this.Ranks[1].text = "Rank: " + this.Class.BiologyGrade.ToString();
		this.Ranks[2].text = "Rank: " + this.Class.ChemistryGrade.ToString();
		this.Ranks[3].text = "Rank: " + this.Class.LanguageGrade.ToString();
		this.Ranks[4].text = "Rank: " + this.Class.PhysicalGrade.ToString();
		this.Ranks[5].text = "Rank: " + this.Class.PsychologyGrade.ToString();
		this.Ranks[6].text = "Rank: " + this.Class.Seduction.ToString();
		this.Ranks[7].text = "Rank: " + this.Class.Numbness.ToString();
		this.Ranks[8].text = "Rank: " + this.Class.Enlightenment.ToString();
		ClubType club = this.PauseScreen.Yandere.Club;
		string str;
		this.ClubLabels.TryGetValue(club, out str);
		this.ClubLabel.text = "Club: " + str;
	}

	// Token: 0x0400355D RID: 13661
	public PauseScreenScript PauseScreen;

	// Token: 0x0400355E RID: 13662
	public PromptBarScript PromptBar;

	// Token: 0x0400355F RID: 13663
	public ClassScript Class;

	// Token: 0x04003560 RID: 13664
	public UISprite[] Subject1Bars;

	// Token: 0x04003561 RID: 13665
	public UISprite[] Subject2Bars;

	// Token: 0x04003562 RID: 13666
	public UISprite[] Subject3Bars;

	// Token: 0x04003563 RID: 13667
	public UISprite[] Subject4Bars;

	// Token: 0x04003564 RID: 13668
	public UISprite[] Subject5Bars;

	// Token: 0x04003565 RID: 13669
	public UISprite[] Subject6Bars;

	// Token: 0x04003566 RID: 13670
	public UISprite[] Subject7Bars;

	// Token: 0x04003567 RID: 13671
	public UISprite[] Subject8Bars;

	// Token: 0x04003568 RID: 13672
	public UILabel[] Ranks;

	// Token: 0x04003569 RID: 13673
	public UILabel ClubLabel;

	// Token: 0x0400356A RID: 13674
	public int Grade;

	// Token: 0x0400356B RID: 13675
	public int BarID;

	// Token: 0x0400356C RID: 13676
	public UITexture Portrait;

	// Token: 0x0400356D RID: 13677
	public Texture RyobaPortrait;

	// Token: 0x0400356E RID: 13678
	private ClubTypeAndStringDictionary ClubLabels;
}
