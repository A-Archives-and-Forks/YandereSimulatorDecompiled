﻿using System;
using UnityEngine;

// Token: 0x02000272 RID: 626
public class DatingMinigameScript : MonoBehaviour
{
	// Token: 0x06001343 RID: 4931 RVA: 0x000AC5D8 File Offset: 0x000AA7D8
	public void Start()
	{
		if (!this.Initialized)
		{
			this.MainCamera = Camera.main;
			this.Affection = DatingGlobals.Affection;
			this.AffectionBar.localScale = new Vector3(this.Affection / 100f, this.AffectionBar.localScale.y, this.AffectionBar.localScale.z);
			this.CalculateAffection();
			this.OriginalColor = this.ComplimentBGs[1].color;
			this.ComplimentSet.localScale = Vector3.zero;
			this.GiveGift.localScale = Vector3.zero;
			this.ShowOff.localScale = Vector3.zero;
			this.Topics.localScale = Vector3.zero;
			this.DatingSimHUD.gameObject.SetActive(false);
			this.DatingSimHUD.alpha = 0f;
			for (int i = 1; i < 26; i++)
			{
				if (DatingGlobals.GetTopicDiscussed(i))
				{
					this.TopicsDiscussed[i] = true;
					UISprite uisprite = this.TopicIcons[i];
					uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, 0.5f);
				}
			}
			for (int j = 1; j < 11; j++)
			{
				if (DatingGlobals.GetComplimentGiven(j))
				{
					this.ComplimentsGiven[j] = true;
					UILabel uilabel = this.ComplimentLabels[j];
					uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0.5f);
				}
			}
			this.UpdateComplimentHighlight();
			this.UpdateTraitHighlight();
			this.UpdateGiftHighlight();
			this.Eighties = GameGlobals.Eighties;
			this.CourageTrait = DatingGlobals.GetSuitorTrait(1);
			this.CourageTraitDemonstrated = DatingGlobals.GetTraitDemonstrated(1);
			this.WisdomTrait = DatingGlobals.GetSuitorTrait(2);
			this.WisdomTraitDemonstrated = DatingGlobals.GetTraitDemonstrated(2);
			this.StrengthTrait = DatingGlobals.GetSuitorTrait(3);
			this.StrengthTraitDemonstrated = DatingGlobals.GetTraitDemonstrated(3);
			this.TraitDemonstrated[1] = this.CourageTraitDemonstrated;
			this.TraitDemonstrated[2] = this.WisdomTraitDemonstrated;
			this.TraitDemonstrated[3] = this.StrengthTraitDemonstrated;
			this.Trait[1] = this.CourageTrait;
			this.Trait[2] = this.WisdomTrait;
			this.Trait[3] = this.StrengthTrait;
			this.Initialized = true;
		}
	}

	// Token: 0x06001344 RID: 4932 RVA: 0x000AC82C File Offset: 0x000AAA2C
	private void CalculateAffection()
	{
		if (this.Affection > 100f)
		{
			this.Affection = 100f;
		}
		if (this.Affection == 0f)
		{
			this.AffectionLevel = 0;
			return;
		}
		if (this.Affection < 25f)
		{
			this.AffectionLevel = 1;
			return;
		}
		if (this.Affection < 50f)
		{
			this.AffectionLevel = 2;
			return;
		}
		if (this.Affection < 75f)
		{
			this.AffectionLevel = 3;
			return;
		}
		if (this.Affection < 100f)
		{
			this.AffectionLevel = 4;
			return;
		}
		this.AffectionLevel = 5;
	}

	// Token: 0x06001345 RID: 4933 RVA: 0x000AC8C4 File Offset: 0x000AAAC4
	private void Update()
	{
		if (this.Testing)
		{
			this.Prompt.enabled = true;
		}
		else if (this.LoveManager.RivalWaiting)
		{
			if (this.Rival == null)
			{
				this.Suitor = this.StudentManager.Students[this.LoveManager.SuitorID];
				this.Rival = this.StudentManager.Students[this.LoveManager.RivalID];
			}
			if (this.Rival.MeetTimer > 0f && this.Suitor.MeetTimer > 0f)
			{
				if (!this.Eighties)
				{
					this.Prompt.enabled = true;
				}
				else if (!this.SuitorAndRivalTalking)
				{
					Debug.Log("DatingMinigameScript is now setting SuitorAndRivalTalking to ''true''.");
					this.Suitor.CurrentDestination = this.Rival.transform;
					this.Suitor.Pathfinding.target = this.Rival.transform;
					this.Suitor.DistractionTarget = this.Rival;
					this.Suitor.TargetDistance = 1f;
					this.Suitor.DistractTimer = 10f;
					this.Suitor.Distracting = true;
					this.Suitor.Routine = false;
					this.Suitor.Pathfinding.canSearch = true;
					this.Suitor.Pathfinding.canMove = true;
					this.Rival.Pathfinding.canSearch = false;
					this.Rival.Pathfinding.canMove = false;
					this.Suitor.Meeting = false;
					this.Rival.Meeting = false;
					this.Rival.Routine = false;
					this.Suitor.MeetTimer = 0f;
					this.Rival.MeetTimer = 0f;
					this.SuitorAndRivalTalking = true;
				}
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (!this.Yandere.Chased && this.Yandere.Chasers == 0 && !this.Rival.Hunted)
			{
				this.Yandere.CameraEffects.UpdateDOF(1f);
				this.Suitor.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				this.Rival.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
				this.Suitor.CharacterAnimation.enabled = true;
				this.Rival.CharacterAnimation.enabled = true;
				this.Suitor.enabled = false;
				this.Rival.enabled = false;
				this.Rival.CharacterAnimation["f02_smile_00"].layer = 1;
				this.Rival.CharacterAnimation.Play("f02_smile_00");
				this.Rival.CharacterAnimation["f02_smile_00"].weight = 0f;
				this.StudentManager.Clock.StopTime = true;
				this.Yandere.RPGCamera.enabled = false;
				this.HeartbeatCamera.SetActive(false);
				this.Yandere.Headset.SetActive(true);
				this.Yandere.CanMove = false;
				this.Yandere.EmptyHands();
				if (this.Yandere.YandereVision)
				{
					this.Yandere.ResetYandereEffects();
					this.Yandere.YandereVision = false;
				}
				this.Yandere.transform.position = this.PeekSpot.position;
				this.Yandere.transform.eulerAngles = this.PeekSpot.eulerAngles;
				this.Yandere.CharacterAnimation.Play("f02_treePeeking_00");
				this.MainCamera.transform.position = new Vector3(48f, 3f, -44f);
				this.MainCamera.transform.eulerAngles = new Vector3(15f, 90f, 0f);
				this.WisdomLabel.text = "Wisdom: " + this.WisdomTrait.ToString();
				this.GiftIcons[1].enabled = CollectibleGlobals.GetGiftPurchased(6);
				this.GiftIcons[2].enabled = CollectibleGlobals.GetGiftPurchased(7);
				this.GiftIcons[3].enabled = CollectibleGlobals.GetGiftPurchased(8);
				this.GiftIcons[4].enabled = CollectibleGlobals.GetGiftPurchased(9);
				this.GiftsPurchased[1] = CollectibleGlobals.GetGiftPurchased(6);
				this.GiftsPurchased[2] = CollectibleGlobals.GetGiftPurchased(7);
				this.GiftsPurchased[3] = CollectibleGlobals.GetGiftPurchased(8);
				this.GiftsPurchased[4] = CollectibleGlobals.GetGiftPurchased(9);
				this.GiftsGiven[1] = CollectibleGlobals.GetGiftGiven(1);
				this.GiftsGiven[2] = CollectibleGlobals.GetGiftGiven(2);
				this.GiftsGiven[3] = CollectibleGlobals.GetGiftGiven(3);
				this.GiftsGiven[4] = CollectibleGlobals.GetGiftGiven(4);
				this.Matchmaking = true;
				this.UpdateTopics();
				Time.timeScale = 1f;
			}
		}
		if (this.Matchmaking)
		{
			if (this.CurrentAnim != string.Empty && this.Rival.CharacterAnimation[this.CurrentAnim].time >= this.Rival.CharacterAnimation[this.CurrentAnim].length)
			{
				this.Rival.CharacterAnimation.Play(this.Rival.IdleAnim);
			}
			if (this.Phase == 1)
			{
				this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, 0f, Time.deltaTime);
				this.Timer += Time.deltaTime;
				this.MainCamera.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(54f, 1.25f, -45.25f), this.Timer * 0.02f);
				this.MainCamera.transform.eulerAngles = Vector3.Lerp(this.MainCamera.transform.eulerAngles, new Vector3(0f, 45f, 0f), this.Timer * 0.02f);
				if (this.Timer > 5f)
				{
					this.Yandere.CameraEffects.UpdateDOF(0.6f);
					this.Suitor.CharacterAnimation.Play("insertEarpiece_00");
					this.Suitor.CharacterAnimation["insertEarpiece_00"].time = 0f;
					this.Suitor.CharacterAnimation.Play("insertEarpiece_00");
					this.Suitor.Earpiece.SetActive(true);
					this.MainCamera.transform.position = new Vector3(45.5f, 1.25f, -44.5f);
					this.MainCamera.transform.eulerAngles = new Vector3(0f, -45f, 0f);
					this.Rotation = -45f;
					this.Timer = 0f;
					this.Phase++;
				}
			}
			else if (this.Phase == 2)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 4f)
				{
					this.Suitor.Earpiece.transform.parent = this.Suitor.Head;
					this.Suitor.Earpiece.transform.localPosition = new Vector3(0f, -1.12f, 1.14f);
					this.Suitor.Earpiece.transform.localEulerAngles = new Vector3(45f, -180f, 0f);
					this.MainCamera.transform.position = Vector3.Lerp(this.MainCamera.transform.position, new Vector3(45.11f, 1.375f, -44f), (this.Timer - 4f) * 0.02f);
					this.Rotation = Mathf.Lerp(this.Rotation, 90f, (this.Timer - 4f) * 0.02f);
					this.MainCamera.transform.eulerAngles = new Vector3(this.MainCamera.transform.eulerAngles.x, this.Rotation, this.MainCamera.transform.eulerAngles.z);
					if (this.Rotation > 89.9f)
					{
						this.Yandere.CameraEffects.UpdateDOF(0.75f);
						this.Rival.CharacterAnimation["f02_turnAround_00"].time = 0f;
						this.Rival.CharacterAnimation.CrossFade("f02_turnAround_00");
						this.AffectionBar.localScale = new Vector3(this.Affection / 100f, this.AffectionBar.localScale.y, this.AffectionBar.localScale.z);
						this.DialogueLabel.text = this.Greetings[this.AffectionLevel];
						this.CalculateMultiplier();
						this.DatingSimHUD.gameObject.SetActive(true);
						this.Timer = 0f;
						this.Phase++;
					}
				}
			}
			else if (this.Phase == 3)
			{
				this.DatingSimHUD.alpha = Mathf.MoveTowards(this.DatingSimHUD.alpha, 1f, Time.deltaTime);
				if (this.Rival.CharacterAnimation["f02_turnAround_00"].time >= this.Rival.CharacterAnimation["f02_turnAround_00"].length)
				{
					this.Rival.transform.eulerAngles = new Vector3(this.Rival.transform.eulerAngles.x, -90f, this.Rival.transform.eulerAngles.z);
					this.Rival.CharacterAnimation.Play("f02_turnAround_00");
					this.Rival.CharacterAnimation["f02_turnAround_00"].time = 0f;
					this.Rival.CharacterAnimation["f02_turnAround_00"].speed = 0f;
					this.Rival.CharacterAnimation.Play("f02_turnAround_00");
					this.Rival.CharacterAnimation.CrossFade(this.Rival.IdleAnim);
					Time.timeScale = 1f;
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[0].text = "Confirm";
					this.PromptBar.Label[1].text = "Back";
					this.PromptBar.Label[4].text = "Select";
					this.PromptBar.UpdateButtons();
					this.PromptBar.Show = true;
					this.Phase++;
				}
			}
			else if (this.Phase == 4)
			{
				if (this.AffectionGrow)
				{
					this.Affection = Mathf.MoveTowards(this.Affection, 100f, Time.deltaTime * 10f);
					this.CalculateAffection();
				}
				this.Rival.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", this.Affection * 0.01f);
				this.Rival.CharacterAnimation["f02_smile_00"].weight = this.Affection * 0.01f;
				this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, Mathf.Lerp(this.Highlight.localPosition.y, this.HighlightTarget, Time.deltaTime * 10f), this.Highlight.localPosition.z);
				for (int i = 1; i < this.Options.Length; i++)
				{
					Transform transform = this.Options[i];
					transform.localPosition = new Vector3(Mathf.Lerp(transform.localPosition.x, (i == this.Selected) ? 750f : 800f, Time.deltaTime * 10f), transform.localPosition.y, transform.localPosition.z);
				}
				this.AffectionBar.localScale = new Vector3(Mathf.Lerp(this.AffectionBar.localScale.x, this.Affection / 100f, Time.deltaTime * 10f), this.AffectionBar.localScale.y, this.AffectionBar.localScale.z);
				if (!this.SelectingTopic && !this.Complimenting && !this.ShowingOff && !this.GivingGift)
				{
					this.Topics.localScale = Vector3.Lerp(this.Topics.localScale, Vector3.zero, Time.deltaTime * 10f);
					this.ComplimentSet.localScale = Vector3.Lerp(this.ComplimentSet.localScale, Vector3.zero, Time.deltaTime * 10f);
					this.ShowOff.localScale = Vector3.Lerp(this.ShowOff.localScale, Vector3.zero, Time.deltaTime * 10f);
					this.GiveGift.localScale = Vector3.Lerp(this.GiveGift.localScale, Vector3.zero, Time.deltaTime * 10f);
					if (this.InputManager.TappedUp)
					{
						this.Selected--;
						this.UpdateHighlight();
					}
					if (this.InputManager.TappedDown)
					{
						this.Selected++;
						this.UpdateHighlight();
					}
					if (Input.GetButtonDown("A") && this.Labels[this.Selected].color.a == 1f)
					{
						if (this.Selected == 1)
						{
							this.SelectingTopic = true;
							this.Negative = true;
						}
						else if (this.Selected == 2)
						{
							this.SelectingTopic = true;
							this.Negative = false;
						}
						else if (this.Selected == 3)
						{
							this.Complimenting = true;
						}
						else if (this.Selected == 4)
						{
							this.ShowingOff = true;
						}
						else if (this.Selected == 5)
						{
							this.GivingGift = true;
						}
						else if (this.Selected == 6)
						{
							this.PromptBar.ClearButtons();
							this.PromptBar.Label[0].text = "Confirm";
							this.PromptBar.UpdateButtons();
							this.CalculateAffection();
							this.DialogueLabel.text = this.Farewells[this.AffectionLevel];
							this.Phase++;
						}
					}
				}
				else if (this.SelectingTopic)
				{
					this.Topics.localScale = Vector3.Lerp(this.Topics.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
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
					if (Input.GetButtonDown("A") && this.TopicIcons[this.TopicSelected].color.a == 1f)
					{
						this.SelectingTopic = false;
						UISprite uisprite = this.TopicIcons[this.TopicSelected];
						uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, 0.5f);
						this.TopicsDiscussed[this.TopicSelected] = true;
						this.DetermineOpinion();
						if (!ConversationGlobals.GetTopicLearnedByStudent(this.Opinion, this.LoveManager.RivalID))
						{
							ConversationGlobals.SetTopicLearnedByStudent(this.Opinion, this.LoveManager.RivalID, true);
						}
						if (this.Negative)
						{
							UILabel uilabel = this.Labels[1];
							uilabel.color = new Color(uilabel.color.r, uilabel.color.g, uilabel.color.b, 0.5f);
							if (this.Opinion == 2)
							{
								this.DialogueLabel.text = "Hey! Just so you know, I take offense to that...";
								this.Rival.CharacterAnimation.CrossFade("f02_refuse_00");
								this.CurrentAnim = "f02_refuse_00";
								this.Affection -= 1f;
								this.CalculateAffection();
							}
							else if (this.Opinion == 1)
							{
								this.DialogueLabel.text = this.Negatives[this.AffectionLevel];
								this.Rival.CharacterAnimation.CrossFade("f02_lookdown_00");
								this.CurrentAnim = "f02_lookdown_00";
								this.Affection += (float)this.Multiplier;
								this.CalculateAffection();
							}
							else if (this.Opinion == 0)
							{
								this.DialogueLabel.text = "Um...okay.";
							}
						}
						else
						{
							UILabel uilabel2 = this.Labels[2];
							uilabel2.color = new Color(uilabel2.color.r, uilabel2.color.g, uilabel2.color.b, 0.5f);
							if (this.Opinion == 2)
							{
								this.DialogueLabel.text = this.Positives[this.AffectionLevel];
								this.Rival.CharacterAnimation.CrossFade("f02_lookdown_00");
								this.CurrentAnim = "f02_lookdown_00";
								this.Affection += (float)this.Multiplier;
								this.CalculateAffection();
							}
							else if (this.Opinion == 1)
							{
								this.DialogueLabel.text = "To be honest with you, I strongly disagree...";
								this.Rival.CharacterAnimation.CrossFade("f02_refuse_00");
								this.CurrentAnim = "f02_refuse_00";
								this.Affection -= 1f;
								this.CalculateAffection();
							}
							else if (this.Opinion == 0)
							{
								this.DialogueLabel.text = "Um...all right.";
							}
						}
						if (this.Affection > 100f)
						{
							this.Affection = 100f;
						}
						else if (this.Affection < 0f)
						{
							this.Affection = 0f;
						}
					}
					if (Input.GetButtonDown("B"))
					{
						this.SelectingTopic = false;
					}
				}
				else if (this.Complimenting)
				{
					this.ComplimentSet.localScale = Vector3.Lerp(this.ComplimentSet.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
					if (this.InputManager.TappedUp)
					{
						this.Line--;
						this.UpdateComplimentHighlight();
					}
					else if (this.InputManager.TappedDown)
					{
						this.Line++;
						this.UpdateComplimentHighlight();
					}
					if (this.InputManager.TappedLeft)
					{
						this.Side--;
						this.UpdateComplimentHighlight();
					}
					else if (this.InputManager.TappedRight)
					{
						this.Side++;
						this.UpdateComplimentHighlight();
					}
					if (Input.GetButtonDown("A") && this.ComplimentLabels[this.ComplimentSelected].color.a == 1f)
					{
						UILabel uilabel3 = this.Labels[3];
						uilabel3.color = new Color(uilabel3.color.r, uilabel3.color.g, uilabel3.color.b, 0.5f);
						this.Complimenting = false;
						this.DialogueLabel.text = this.Compliments[this.ComplimentSelected];
						this.ComplimentsGiven[this.ComplimentSelected] = true;
						if (this.ComplimentSelected == 1 || this.ComplimentSelected == 4 || this.ComplimentSelected == 5 || this.ComplimentSelected == 8 || this.ComplimentSelected == 9)
						{
							this.Rival.CharacterAnimation.CrossFade("f02_lookdown_00");
							this.CurrentAnim = "f02_lookdown_00";
							this.Affection += (float)this.Multiplier;
							this.CalculateAffection();
						}
						else
						{
							this.Rival.CharacterAnimation.CrossFade("f02_refuse_00");
							this.CurrentAnim = "f02_refuse_00";
							this.Affection -= 1f;
							this.CalculateAffection();
						}
						if (this.Affection > 100f)
						{
							this.Affection = 100f;
						}
						else if (this.Affection < 0f)
						{
							this.Affection = 0f;
						}
					}
					if (Input.GetButtonDown("B"))
					{
						this.Complimenting = false;
					}
				}
				else if (this.ShowingOff)
				{
					this.ShowOff.localScale = Vector3.Lerp(this.ShowOff.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
					if (this.InputManager.TappedUp)
					{
						this.TraitSelected--;
						this.UpdateTraitHighlight();
					}
					else if (this.InputManager.TappedDown)
					{
						this.TraitSelected++;
						this.UpdateTraitHighlight();
					}
					if (Input.GetButtonDown("A"))
					{
						UILabel uilabel4 = this.Labels[4];
						uilabel4.color = new Color(uilabel4.color.r, uilabel4.color.g, uilabel4.color.b, 0.5f);
						this.ShowingOff = false;
						if (this.TraitSelected == 2)
						{
							Debug.Log(string.Concat(new string[]
							{
								"Wisdom trait is ",
								this.WisdomTrait.ToString(),
								". Wisdom Demonstrated is ",
								this.WisdomTraitDemonstrated.ToString(),
								"."
							}));
							if (this.WisdomTrait > this.WisdomTraitDemonstrated)
							{
								this.WisdomTraitDemonstrated++;
								this.DialogueLabel.text = this.ShowOffs[this.AffectionLevel];
								this.Rival.CharacterAnimation.CrossFade("f02_lookdown_00");
								this.CurrentAnim = "f02_lookdown_00";
								this.Affection += (float)this.Multiplier;
								this.CalculateAffection();
							}
							else if (this.WisdomTrait == 0)
							{
								this.DialogueLabel.text = "Uh...that doesn't sound correct...";
							}
							else if (this.WisdomTrait == this.WisdomTraitDemonstrated)
							{
								this.DialogueLabel.text = "Uh...you already told me about that...";
							}
						}
						else
						{
							this.DialogueLabel.text = "Um...well...that sort of thing doesn't really matter to me...";
						}
						if (this.Affection > 100f)
						{
							this.Affection = 100f;
						}
						else if (this.Affection < 0f)
						{
							this.Affection = 0f;
						}
					}
					if (Input.GetButtonDown("B"))
					{
						this.ShowingOff = false;
					}
				}
				else if (this.GivingGift)
				{
					this.GiveGift.localScale = Vector3.Lerp(this.GiveGift.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
					if (this.InputManager.TappedUp)
					{
						this.GiftRow--;
						this.UpdateGiftHighlight();
					}
					else if (this.InputManager.TappedDown)
					{
						this.GiftRow++;
						this.UpdateGiftHighlight();
					}
					if (this.InputManager.TappedLeft)
					{
						this.GiftColumn--;
						this.UpdateGiftHighlight();
					}
					else if (this.InputManager.TappedRight)
					{
						this.GiftColumn++;
						this.UpdateGiftHighlight();
					}
					if (Input.GetButtonDown("A"))
					{
						if (this.GiftIcons[this.GiftSelected].enabled)
						{
							this.GiftsPurchased[this.GiftSelected] = false;
							this.GiftsGiven[this.GiftSelected] = true;
							this.Rival.Cosmetic.CatGifts[this.GiftSelected].SetActive(true);
							UILabel uilabel5 = this.Labels[5];
							uilabel5.color = new Color(uilabel5.color.r, uilabel5.color.g, uilabel5.color.b, 0.5f);
							this.GivingGift = false;
							this.DialogueLabel.text = this.GiveGifts[this.GiftSelected];
							this.Rival.CharacterAnimation.CrossFade("f02_lookdown_00");
							this.CurrentAnim = "f02_lookdown_00";
							this.Affection += (float)this.Multiplier;
							this.CalculateAffection();
						}
						if (this.Affection > 100f)
						{
							this.Affection = 100f;
						}
						else if (this.Affection < 0f)
						{
							this.Affection = 0f;
						}
					}
					if (Input.GetButtonDown("B"))
					{
						this.GivingGift = false;
					}
				}
			}
			else if (this.Phase == 5)
			{
				this.Speed += Time.deltaTime * 100f;
				this.AffectionSet.localPosition = new Vector3(this.AffectionSet.localPosition.x, this.AffectionSet.localPosition.y + this.Speed, this.AffectionSet.localPosition.z);
				this.OptionSet.localPosition = new Vector3(this.OptionSet.localPosition.x + this.Speed, this.OptionSet.localPosition.y, this.OptionSet.localPosition.z);
				if (this.Speed > 100f && Input.GetButtonDown("A"))
				{
					this.Phase++;
				}
			}
			else if (this.Phase == 6)
			{
				this.DatingSimHUD.alpha = Mathf.MoveTowards(this.DatingSimHUD.alpha, 0f, Time.deltaTime);
				if (this.DatingSimHUD.alpha == 0f)
				{
					this.DatingSimHUD.gameObject.SetActive(false);
					this.Phase++;
				}
			}
			else if (this.Phase == 7)
			{
				if (this.Panel.alpha == 0f)
				{
					Debug.Log("The rival and suitor are now being released from the dating minigame.");
					this.Yandere.CameraEffects.UpdateDOF(2f);
					this.Suitor.CharacterAnimation.cullingType = AnimationCullingType.BasedOnRenderers;
					this.LoveManager.RivalWaiting = false;
					this.LoveManager.Courted = true;
					this.Suitor.enabled = true;
					this.Rival.enabled = true;
					this.Suitor.CurrentDestination = this.Suitor.Destinations[this.Suitor.Phase];
					this.Suitor.Pathfinding.target = this.Suitor.Destinations[this.Suitor.Phase];
					this.Suitor.Prompt.Label[0].text = "     Talk";
					this.Suitor.Pathfinding.canSearch = true;
					this.Suitor.Pathfinding.canMove = true;
					this.Suitor.Pushable = false;
					this.Suitor.Meeting = false;
					this.Suitor.Routine = true;
					this.Suitor.MeetTimer = 0f;
					this.Rival.Cosmetic.MyRenderer.materials[2].SetFloat("_BlendAmount", 0f);
					this.Rival.CurrentDestination = this.Rival.Destinations[this.Rival.Phase];
					this.Rival.Pathfinding.target = this.Rival.Destinations[this.Rival.Phase];
					this.Rival.CharacterAnimation["f02_smile_00"].weight = 0f;
					this.Rival.Prompt.Label[0].text = "     Talk";
					this.Rival.Pathfinding.canSearch = true;
					this.Rival.Pathfinding.canMove = true;
					this.Rival.DistanceToDestination = 100f;
					this.Rival.Pushable = false;
					this.Rival.Meeting = false;
					this.Rival.Routine = true;
					this.Rival.MeetTimer = 0f;
					this.StudentManager.Clock.StopTime = false;
					this.Yandere.RPGCamera.enabled = true;
					this.Suitor.Earpiece.SetActive(false);
					this.HeartbeatCamera.SetActive(true);
					this.Yandere.Headset.SetActive(false);
					if (this.AffectionLevel == 5)
					{
						this.LoveManager.ConfessToSuitor = true;
					}
					this.PromptBar.ClearButtons();
					this.PromptBar.Show = false;
					if (this.StudentManager.Students[10] != null)
					{
						this.StudentManager.Students[10].CurrentDestination = this.StudentManager.Students[10].FollowTarget.transform;
						this.StudentManager.Students[10].Pathfinding.target = this.StudentManager.Students[10].FollowTarget.transform;
					}
					this.DataNeedsSaving = true;
				}
				else if (this.Panel.alpha == 1f)
				{
					this.Matchmaking = false;
					this.Yandere.CanMove = true;
					base.gameObject.SetActive(false);
				}
				this.Panel.alpha = Mathf.MoveTowards(this.Panel.alpha, 1f, Time.deltaTime);
			}
			if (!this.Yandere.NoDebug)
			{
				if (Input.GetKeyDown(KeyCode.Space))
				{
					this.Yandere.CharacterAnimation["f02_treePeeking_00"].time = 0f;
					this.Yandere.CharacterAnimation.Play("f02_treePeeking_00");
					this.MainCamera.transform.position = new Vector3(48f, 3f, -44f);
					this.MainCamera.transform.eulerAngles = new Vector3(15f, 90f, 0f);
					this.Rival.transform.eulerAngles = new Vector3(this.Rival.transform.eulerAngles.x, 90f, this.Rival.transform.eulerAngles.z);
					this.Rival.CharacterAnimation.Play(this.Rival.IdleAnim);
					this.Rival.CharacterAnimation["f02_turnAround_00"].speed = 1f;
					DatingGlobals.SetComplimentGiven(1, false);
					DatingGlobals.SetComplimentGiven(4, false);
					DatingGlobals.SetComplimentGiven(5, false);
					DatingGlobals.SetComplimentGiven(8, false);
					DatingGlobals.SetComplimentGiven(9, false);
					DatingGlobals.SetTraitDemonstrated(2, 0);
					DatingGlobals.AffectionLevel = 0f;
					DatingGlobals.Affection = 0f;
					this.AffectionBar.localScale = new Vector3(0f, this.AffectionBar.localScale.y, this.AffectionBar.localScale.z);
					this.AffectionLevel = 0;
					this.Affection = 0f;
					for (int j = 1; j < 6; j++)
					{
						UILabel uilabel6 = this.Labels[j];
						uilabel6.color = new Color(uilabel6.color.r, uilabel6.color.g, uilabel6.color.b, 1f);
					}
					this.Phase = 1;
					this.Timer = 0f;
					for (int k = 1; k < 26; k++)
					{
						DatingGlobals.SetTopicDiscussed(k, false);
						UISprite uisprite2 = this.TopicIcons[k];
						uisprite2.color = new Color(uisprite2.color.r, uisprite2.color.g, uisprite2.color.b, 1f);
					}
					this.UpdateTopics();
				}
				if (Input.GetKeyDown("="))
				{
					Time.timeScale += 1f;
				}
				if (Input.GetKeyDown(KeyCode.LeftControl))
				{
					this.Affection += 10f;
					this.CalculateAffection();
					this.DialogueLabel.text = this.Greetings[this.AffectionLevel];
				}
			}
		}
	}

	// Token: 0x06001346 RID: 4934 RVA: 0x000AEA15 File Offset: 0x000ACC15
	private void LateUpdate()
	{
		int phase = this.Phase;
	}

	// Token: 0x06001347 RID: 4935 RVA: 0x000AEA20 File Offset: 0x000ACC20
	private void CalculateMultiplier()
	{
		this.Multiplier = 5;
		if (!this.Suitor.Cosmetic.MaleHair[55].activeInHierarchy)
		{
			this.MultiplierIcons[1].mainTexture = this.X;
			this.Multiplier--;
		}
		if (!this.Suitor.Cosmetic.MaleAccessories[17].activeInHierarchy)
		{
			this.MultiplierIcons[2].mainTexture = this.X;
			this.Multiplier--;
		}
		if (!this.Suitor.Cosmetic.Eyewear[6].activeInHierarchy)
		{
			this.MultiplierIcons[3].mainTexture = this.X;
			this.Multiplier--;
		}
		if (this.Suitor.Cosmetic.SkinColor != 6)
		{
			this.MultiplierIcons[4].mainTexture = this.X;
			this.Multiplier--;
		}
		if (PlayerGlobals.PantiesEquipped == 2)
		{
			this.PantyIcon.SetActive(true);
			this.Multiplier++;
		}
		else
		{
			this.PantyIcon.SetActive(false);
		}
		if (this.Yandere.Class.Seduction + this.Yandere.Class.SeductionBonus > 0)
		{
			this.SeductionLabel.text = (this.Yandere.Class.Seduction + this.Yandere.Class.SeductionBonus).ToString();
			this.Multiplier += this.Yandere.Class.Seduction + this.Yandere.Class.SeductionBonus;
			this.SeductionIcon.SetActive(true);
		}
		else
		{
			this.SeductionIcon.SetActive(false);
		}
		this.Multiplier += this.Yandere.Class.PsychologyGrade + this.Yandere.Class.PsychologyBonus;
		this.MultiplierLabel.text = "Multiplier: " + this.Multiplier.ToString() + "x";
	}

	// Token: 0x06001348 RID: 4936 RVA: 0x000AEC3B File Offset: 0x000ACE3B
	private void UpdateHighlight()
	{
		if (this.Selected < 1)
		{
			this.Selected = 6;
		}
		else if (this.Selected > 6)
		{
			this.Selected = 1;
		}
		this.HighlightTarget = 450f - 100f * (float)this.Selected;
	}

	// Token: 0x06001349 RID: 4937 RVA: 0x000AEC78 File Offset: 0x000ACE78
	private void UpdateTopicHighlight()
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
		this.TopicNameLabel.text = (ConversationGlobals.GetTopicDiscovered(this.TopicSelected) ? this.TopicNames[this.TopicSelected] : "??????????");
	}

	// Token: 0x0600134A RID: 4938 RVA: 0x000AED4C File Offset: 0x000ACF4C
	private void DetermineOpinion()
	{
		int[] topics = this.JSON.Topics[this.LoveManager.RivalID].Topics;
		this.Opinion = topics[this.TopicSelected];
	}

	// Token: 0x0600134B RID: 4939 RVA: 0x000AED84 File Offset: 0x000ACF84
	private void UpdateTopics()
	{
		for (int i = 1; i < this.TopicIcons.Length; i++)
		{
			UISprite uisprite = this.TopicIcons[i];
			if (!ConversationGlobals.GetTopicDiscovered(i))
			{
				uisprite.spriteName = 0.ToString();
				uisprite.color = new Color(uisprite.color.r, uisprite.color.g, uisprite.color.b, 0.5f);
			}
			else
			{
				uisprite.spriteName = i.ToString();
			}
		}
		for (int j = 1; j <= 25; j++)
		{
			UISprite uisprite2 = this.OpinionIcons[j];
			if (!ConversationGlobals.GetTopicLearnedByStudent(j, this.LoveManager.RivalID))
			{
				uisprite2.spriteName = "Unknown";
			}
			else
			{
				int[] topics = this.JSON.Topics[this.LoveManager.RivalID].Topics;
				uisprite2.spriteName = this.OpinionSpriteNames[topics[j]];
			}
		}
	}

	// Token: 0x0600134C RID: 4940 RVA: 0x000AEE6C File Offset: 0x000AD06C
	private void UpdateComplimentHighlight()
	{
		for (int i = 1; i < this.TopicIcons.Length; i++)
		{
			this.ComplimentBGs[this.ComplimentSelected].color = this.OriginalColor;
		}
		if (this.Line < 1)
		{
			this.Line = 5;
		}
		else if (this.Line > 5)
		{
			this.Line = 1;
		}
		if (this.Side < 1)
		{
			this.Side = 2;
		}
		else if (this.Side > 2)
		{
			this.Side = 1;
		}
		this.ComplimentSelected = (this.Line - 1) * 2 + this.Side;
		this.ComplimentBGs[this.ComplimentSelected].color = Color.white;
	}

	// Token: 0x0600134D RID: 4941 RVA: 0x000AEF18 File Offset: 0x000AD118
	private void UpdateTraitHighlight()
	{
		if (this.TraitSelected < 1)
		{
			this.TraitSelected = 3;
		}
		else if (this.TraitSelected > 3)
		{
			this.TraitSelected = 1;
		}
		for (int i = 1; i < this.TraitBGs.Length; i++)
		{
			this.TraitBGs[i].color = this.OriginalColor;
		}
		this.TraitBGs[this.TraitSelected].color = Color.white;
	}

	// Token: 0x0600134E RID: 4942 RVA: 0x000AEF84 File Offset: 0x000AD184
	private void UpdateGiftHighlight()
	{
		for (int i = 1; i < this.GiftBGs.Length; i++)
		{
			this.GiftBGs[i].color = this.OriginalColor;
		}
		if (this.GiftRow < 1)
		{
			this.GiftRow = 2;
		}
		else if (this.GiftRow > 2)
		{
			this.GiftRow = 1;
		}
		if (this.GiftColumn < 1)
		{
			this.GiftColumn = 2;
		}
		else if (this.GiftColumn > 2)
		{
			this.GiftColumn = 1;
		}
		this.GiftSelected = (this.GiftRow - 1) * 2 + this.GiftColumn;
		this.GiftBGs[this.GiftSelected].color = Color.white;
	}

	// Token: 0x0600134F RID: 4943 RVA: 0x000AF02C File Offset: 0x000AD22C
	public void SaveTopicsAndCompliments()
	{
		for (int i = 1; i < 26; i++)
		{
			DatingGlobals.SetTopicDiscussed(i, this.TopicsDiscussed[i]);
		}
		for (int j = 1; j < 11; j++)
		{
			DatingGlobals.SetComplimentGiven(j, this.ComplimentsGiven[j]);
		}
		DatingGlobals.SetTraitDemonstrated(1, this.CourageTraitDemonstrated);
		DatingGlobals.SetTraitDemonstrated(2, this.WisdomTraitDemonstrated);
		DatingGlobals.SetTraitDemonstrated(3, this.StrengthTraitDemonstrated);
		DatingGlobals.SetSuitorTrait(1, this.CourageTrait);
		DatingGlobals.SetSuitorTrait(2, this.WisdomTrait);
		DatingGlobals.SetSuitorTrait(3, this.StrengthTrait);
		for (int k = 1; k < 5; k++)
		{
			CollectibleGlobals.SetGiftPurchased(k + 5, this.GiftsPurchased[k]);
			CollectibleGlobals.SetGiftGiven(k, this.GiftsGiven[k]);
		}
		DatingGlobals.Affection = this.Affection;
		Debug.Log("Saving Dating Minigame data.");
	}

	// Token: 0x04001BBA RID: 7098
	public StudentManagerScript StudentManager;

	// Token: 0x04001BBB RID: 7099
	public InputManagerScript InputManager;

	// Token: 0x04001BBC RID: 7100
	public LoveManagerScript LoveManager;

	// Token: 0x04001BBD RID: 7101
	public PromptBarScript PromptBar;

	// Token: 0x04001BBE RID: 7102
	public YandereScript Yandere;

	// Token: 0x04001BBF RID: 7103
	public StudentScript Suitor;

	// Token: 0x04001BC0 RID: 7104
	public StudentScript Rival;

	// Token: 0x04001BC1 RID: 7105
	public PromptScript Prompt;

	// Token: 0x04001BC2 RID: 7106
	public JsonScript JSON;

	// Token: 0x04001BC3 RID: 7107
	public Transform AffectionSet;

	// Token: 0x04001BC4 RID: 7108
	public Transform OptionSet;

	// Token: 0x04001BC5 RID: 7109
	public GameObject HeartbeatCamera;

	// Token: 0x04001BC6 RID: 7110
	public GameObject SeductionIcon;

	// Token: 0x04001BC7 RID: 7111
	public GameObject PantyIcon;

	// Token: 0x04001BC8 RID: 7112
	public Transform TopicHighlight;

	// Token: 0x04001BC9 RID: 7113
	public Transform ComplimentSet;

	// Token: 0x04001BCA RID: 7114
	public Transform AffectionBar;

	// Token: 0x04001BCB RID: 7115
	public Transform Highlight;

	// Token: 0x04001BCC RID: 7116
	public Transform GiveGift;

	// Token: 0x04001BCD RID: 7117
	public Transform PeekSpot;

	// Token: 0x04001BCE RID: 7118
	public Transform[] Options;

	// Token: 0x04001BCF RID: 7119
	public Transform ShowOff;

	// Token: 0x04001BD0 RID: 7120
	public Transform Topics;

	// Token: 0x04001BD1 RID: 7121
	public Texture X;

	// Token: 0x04001BD2 RID: 7122
	public UISprite[] OpinionIcons;

	// Token: 0x04001BD3 RID: 7123
	public UISprite[] TopicIcons;

	// Token: 0x04001BD4 RID: 7124
	public UITexture[] MultiplierIcons;

	// Token: 0x04001BD5 RID: 7125
	public UILabel[] ComplimentLabels;

	// Token: 0x04001BD6 RID: 7126
	public UISprite[] ComplimentBGs;

	// Token: 0x04001BD7 RID: 7127
	public UILabel MultiplierLabel;

	// Token: 0x04001BD8 RID: 7128
	public UILabel SeductionLabel;

	// Token: 0x04001BD9 RID: 7129
	public UILabel TopicNameLabel;

	// Token: 0x04001BDA RID: 7130
	public UILabel DialogueLabel;

	// Token: 0x04001BDB RID: 7131
	public UIPanel DatingSimHUD;

	// Token: 0x04001BDC RID: 7132
	public UILabel WisdomLabel;

	// Token: 0x04001BDD RID: 7133
	public UIPanel Panel;

	// Token: 0x04001BDE RID: 7134
	public UITexture[] GiftIcons;

	// Token: 0x04001BDF RID: 7135
	public UISprite[] TraitBGs;

	// Token: 0x04001BE0 RID: 7136
	public UISprite[] GiftBGs;

	// Token: 0x04001BE1 RID: 7137
	public UILabel[] Labels;

	// Token: 0x04001BE2 RID: 7138
	public string[] OpinionSpriteNames;

	// Token: 0x04001BE3 RID: 7139
	public string[] Compliments;

	// Token: 0x04001BE4 RID: 7140
	public string[] TopicNames;

	// Token: 0x04001BE5 RID: 7141
	public string[] GiveGifts;

	// Token: 0x04001BE6 RID: 7142
	public string[] Greetings;

	// Token: 0x04001BE7 RID: 7143
	public string[] Farewells;

	// Token: 0x04001BE8 RID: 7144
	public string[] Negatives;

	// Token: 0x04001BE9 RID: 7145
	public string[] Positives;

	// Token: 0x04001BEA RID: 7146
	public string[] ShowOffs;

	// Token: 0x04001BEB RID: 7147
	public bool[] ComplimentsGiven;

	// Token: 0x04001BEC RID: 7148
	public bool[] TopicsDiscussed;

	// Token: 0x04001BED RID: 7149
	public bool[] GiftsPurchased;

	// Token: 0x04001BEE RID: 7150
	public bool[] GiftsGiven;

	// Token: 0x04001BEF RID: 7151
	public bool SuitorAndRivalTalking;

	// Token: 0x04001BF0 RID: 7152
	public bool DataNeedsSaving;

	// Token: 0x04001BF1 RID: 7153
	public bool SelectingTopic;

	// Token: 0x04001BF2 RID: 7154
	public bool AffectionGrow;

	// Token: 0x04001BF3 RID: 7155
	public bool Complimenting;

	// Token: 0x04001BF4 RID: 7156
	public bool Initialized;

	// Token: 0x04001BF5 RID: 7157
	public bool Matchmaking;

	// Token: 0x04001BF6 RID: 7158
	public bool GivingGift;

	// Token: 0x04001BF7 RID: 7159
	public bool ShowingOff;

	// Token: 0x04001BF8 RID: 7160
	public bool Eighties;

	// Token: 0x04001BF9 RID: 7161
	public bool Negative;

	// Token: 0x04001BFA RID: 7162
	public bool SlideOut;

	// Token: 0x04001BFB RID: 7163
	public bool Testing;

	// Token: 0x04001BFC RID: 7164
	public float HighlightTarget;

	// Token: 0x04001BFD RID: 7165
	public float Affection;

	// Token: 0x04001BFE RID: 7166
	public float Rotation;

	// Token: 0x04001BFF RID: 7167
	public float Speed;

	// Token: 0x04001C00 RID: 7168
	public float Timer;

	// Token: 0x04001C01 RID: 7169
	public int ComplimentSelected = 1;

	// Token: 0x04001C02 RID: 7170
	public int TraitSelected = 1;

	// Token: 0x04001C03 RID: 7171
	public int TopicSelected = 1;

	// Token: 0x04001C04 RID: 7172
	public int GiftSelected = 1;

	// Token: 0x04001C05 RID: 7173
	public int Selected = 1;

	// Token: 0x04001C06 RID: 7174
	public int AffectionLevel;

	// Token: 0x04001C07 RID: 7175
	public int Multiplier;

	// Token: 0x04001C08 RID: 7176
	public int Opinion;

	// Token: 0x04001C09 RID: 7177
	public int Phase = 1;

	// Token: 0x04001C0A RID: 7178
	public int WisdomTraitDemonstrated;

	// Token: 0x04001C0B RID: 7179
	public int WisdomTrait;

	// Token: 0x04001C0C RID: 7180
	public int CourageTraitDemonstrated;

	// Token: 0x04001C0D RID: 7181
	public int CourageTrait;

	// Token: 0x04001C0E RID: 7182
	public int StrengthTraitDemonstrated;

	// Token: 0x04001C0F RID: 7183
	public int StrengthTrait;

	// Token: 0x04001C10 RID: 7184
	public int[] TraitDemonstrated;

	// Token: 0x04001C11 RID: 7185
	public int[] Trait;

	// Token: 0x04001C12 RID: 7186
	public int GiftColumn = 1;

	// Token: 0x04001C13 RID: 7187
	public int GiftRow = 1;

	// Token: 0x04001C14 RID: 7188
	public int Column = 1;

	// Token: 0x04001C15 RID: 7189
	public int Row = 1;

	// Token: 0x04001C16 RID: 7190
	public int Side = 1;

	// Token: 0x04001C17 RID: 7191
	public int Line = 1;

	// Token: 0x04001C18 RID: 7192
	public string CurrentAnim = string.Empty;

	// Token: 0x04001C19 RID: 7193
	public Color OriginalColor;

	// Token: 0x04001C1A RID: 7194
	public Camera MainCamera;
}
