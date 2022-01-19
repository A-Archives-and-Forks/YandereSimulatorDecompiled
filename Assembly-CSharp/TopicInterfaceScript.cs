﻿using System;
using UnityEngine;

// Token: 0x0200047C RID: 1148
public class TopicInterfaceScript : MonoBehaviour
{
	// Token: 0x06001ECE RID: 7886 RVA: 0x001B150C File Offset: 0x001AF70C
	private void Start()
	{
		if (this.Student == null)
		{
			base.gameObject.SetActive(false);
		}
		if (GameGlobals.Eighties)
		{
			this.EmbarassingLabel.text = "(You will also mention the embarassing information you found in her diary.)";
			this.TopicNames[14] = "jokes";
		}
	}

	// Token: 0x06001ECF RID: 7887 RVA: 0x001B1558 File Offset: 0x001AF758
	private void Update()
	{
		if (this.InputManager.TappedUp)
		{
			this.Row--;
			this.UpdateTopicHighlight();
		}
		else if (this.InputManager.TappedDown)
		{
			this.Row++;
			this.UpdateTopicHighlight();
		}
		if (this.InputManager.TappedLeft)
		{
			this.Column--;
			this.UpdateTopicHighlight();
		}
		else if (this.InputManager.TappedRight)
		{
			this.Column++;
			this.UpdateTopicHighlight();
		}
		if (Input.GetButtonDown("A"))
		{
			if (this.Socializing)
			{
				this.Yandere.Interaction = YandereInteractionType.Compliment;
				this.Yandere.TalkTimer = 5f;
			}
			else
			{
				this.Yandere.Interaction = YandereInteractionType.Gossip;
				this.Yandere.TalkTimer = 5f;
			}
			this.Yandere.PromptBar.Show = false;
			base.gameObject.SetActive(false);
			Time.timeScale = 1f;
			return;
		}
		if (Input.GetButtonDown("X"))
		{
			this.Positive = !this.Positive;
			this.UpdateTopicHighlight();
			return;
		}
		if (Input.GetButtonDown("B"))
		{
			this.Yandere.Interaction = YandereInteractionType.Bye;
			this.Yandere.TalkTimer = 2f;
			this.Yandere.PromptBar.Show = false;
			base.gameObject.SetActive(false);
			Time.timeScale = 1f;
		}
	}

	// Token: 0x06001ED0 RID: 7888 RVA: 0x001B16D4 File Offset: 0x001AF8D4
	public void UpdateTopicHighlight()
	{
		if (this.Row < 1)
		{
			this.Row = 5;
		}
		else if (this.Row > 5)
		{
			this.Row = 1;
		}
		if (this.Column < 1)
		{
			this.Column = 5;
		}
		else if (this.Column > 5)
		{
			this.Column = 1;
		}
		this.TopicHighlight.localPosition = new Vector3((float)(-375 + 125 * this.Column), (float)(375 - 125 * this.Row), this.TopicHighlight.localPosition.z);
		this.TopicSelected = (this.Row - 1) * 5 + this.Column;
		this.DetermineOpinion();
		if (this.Socializing)
		{
			this.LoveHate = (this.Positive ? "love" : "hate");
			this.Statement = string.Concat(new string[]
			{
				"Hi, ",
				this.Student.Name,
				"! Gosh, I just really ",
				this.LoveHate,
				" ",
				this.TopicNames[this.TopicSelected],
				". Can you relate to that at all?"
			});
			if ((this.Positive && this.Opinion == 2) || (!this.Positive && this.Opinion == 1))
			{
				this.Success = true;
			}
		}
		else
		{
			this.LoveHate = (this.Positive ? "loves" : "hates");
			this.Statement = string.Concat(new string[]
			{
				"Hey, ",
				this.Student.Name,
				"! Did you know that ",
				this.StudentManager.JSON.Students[this.TargetStudentID].Name,
				" really ",
				this.LoveHate,
				" ",
				this.TopicNames[this.TopicSelected],
				"?"
			});
			if ((this.Positive && this.Opinion == 1) || (!this.Positive && this.Opinion == 2))
			{
				this.Success = true;
			}
		}
		this.Label.text = this.Statement;
		this.EmbarassingSecret.SetActive(false);
		if (!this.Socializing && this.TargetStudentID == this.StudentManager.RivalID && this.StudentManager.EmbarassingSecret)
		{
			this.EmbarassingSecret.SetActive(true);
		}
		if (this.Positive)
		{
			this.NegativeRemark.SetActive(false);
			this.PositiveRemark.SetActive(true);
			return;
		}
		this.PositiveRemark.SetActive(false);
		this.NegativeRemark.SetActive(true);
	}

	// Token: 0x06001ED1 RID: 7889 RVA: 0x001B1980 File Offset: 0x001AFB80
	public void UpdateOpinions()
	{
		for (int i = 1; i <= 25; i++)
		{
			UISprite uisprite = this.OpinionIcons[i];
			if (!ConversationGlobals.GetTopicLearnedByStudent(i, this.StudentID))
			{
				uisprite.spriteName = "Unknown";
			}
			else
			{
				int[] topics = this.JSON.Topics[this.StudentID].Topics;
				uisprite.spriteName = this.OpinionSpriteNames[topics[i]];
			}
		}
	}

	// Token: 0x06001ED2 RID: 7890 RVA: 0x001B19E8 File Offset: 0x001AFBE8
	private void DetermineOpinion()
	{
		int[] topics = this.JSON.Topics[this.StudentID].Topics;
		this.Opinion = topics[this.TopicSelected];
		this.Success = false;
	}

	// Token: 0x04004002 RID: 16386
	public StudentManagerScript StudentManager;

	// Token: 0x04004003 RID: 16387
	public InputManagerScript InputManager;

	// Token: 0x04004004 RID: 16388
	public StudentScript TargetStudent;

	// Token: 0x04004005 RID: 16389
	public StudentScript Student;

	// Token: 0x04004006 RID: 16390
	public YandereScript Yandere;

	// Token: 0x04004007 RID: 16391
	public JsonScript JSON;

	// Token: 0x04004008 RID: 16392
	public GameObject NegativeRemark;

	// Token: 0x04004009 RID: 16393
	public GameObject PositiveRemark;

	// Token: 0x0400400A RID: 16394
	public GameObject EmbarassingSecret;

	// Token: 0x0400400B RID: 16395
	public Transform TopicHighlight;

	// Token: 0x0400400C RID: 16396
	public UISprite[] OpinionIcons;

	// Token: 0x0400400D RID: 16397
	public UILabel EmbarassingLabel;

	// Token: 0x0400400E RID: 16398
	public UILabel Label;

	// Token: 0x0400400F RID: 16399
	public int TopicSelected;

	// Token: 0x04004010 RID: 16400
	public int Opinion;

	// Token: 0x04004011 RID: 16401
	public int Column;

	// Token: 0x04004012 RID: 16402
	public int Row;

	// Token: 0x04004013 RID: 16403
	public bool Socializing;

	// Token: 0x04004014 RID: 16404
	public bool Positive;

	// Token: 0x04004015 RID: 16405
	public bool Success;

	// Token: 0x04004016 RID: 16406
	public string[] OpinionSpriteNames;

	// Token: 0x04004017 RID: 16407
	public string[] TopicNames;

	// Token: 0x04004018 RID: 16408
	public string Statement;

	// Token: 0x04004019 RID: 16409
	public string LoveHate;

	// Token: 0x0400401A RID: 16410
	public int TargetStudentID = 1;

	// Token: 0x0400401B RID: 16411
	public int StudentID = 1;
}
