﻿using System;
using UnityEngine;

// Token: 0x02000107 RID: 263
public class ChallengeScript : MonoBehaviour
{
	// Token: 0x06000AAE RID: 2734 RVA: 0x00063910 File Offset: 0x00061B10
	private void Update()
	{
		if (!this.Viewing)
		{
			if (!this.Switch)
			{
				if (this.InputManager.TappedUp || this.InputManager.TappedDown)
				{
					if (this.List == 0)
					{
						this.Arrows.localPosition = new Vector3(this.Arrows.localPosition.x, -300f, this.Arrows.localPosition.z);
						this.ViewButton.SetActive(true);
						this.Panels[0].alpha = 0.5f;
						this.Panels[1].alpha = 1f;
						this.List = 1;
					}
					else
					{
						this.Arrows.localPosition = new Vector3(this.Arrows.localPosition.x, 200f, this.Arrows.localPosition.z);
						this.ViewButton.SetActive(false);
						this.Panels[0].alpha = 1f;
						this.Panels[1].alpha = 0.5f;
						this.List = 0;
					}
				}
				Transform transform = this.ChallengeList[this.List];
				if (this.InputManager.DPadRight || Input.GetKey(KeyCode.RightArrow))
				{
					transform.localPosition = new Vector3(transform.localPosition.x - Time.deltaTime * 1000f, transform.localPosition.y, transform.localPosition.z);
				}
				if (this.InputManager.DPadLeft || Input.GetKey(KeyCode.LeftArrow))
				{
					transform.localPosition = new Vector3(transform.localPosition.x + Time.deltaTime * 1000f, transform.localPosition.y, transform.localPosition.z);
				}
				transform.localPosition = new Vector3(transform.localPosition.x + Input.GetAxis("Horizontal") * -10f, transform.localPosition.y, transform.localPosition.z);
				if (transform.localPosition.x > 500f)
				{
					transform.localPosition = new Vector3(500f, transform.localPosition.y, transform.localPosition.z);
				}
				else if (transform.localPosition.x < -250f * ((float)this.Challenges[this.List] - 3f))
				{
					transform.localPosition = new Vector3(-250f * ((float)this.Challenges[this.List] - 3f), transform.localPosition.y, transform.localPosition.z);
				}
				if (this.LargeIcon.color.a > 0f)
				{
					this.LargeIcon.color = new Color(this.LargeIcon.color.r, this.LargeIcon.color.g, this.LargeIcon.color.b, this.LargeIcon.color.a - Time.deltaTime * 10f);
					if (this.LargeIcon.color.a < 0f)
					{
						this.LargeIcon.color = new Color(this.LargeIcon.color.r, this.LargeIcon.color.g, this.LargeIcon.color.b, 0f);
					}
				}
			}
		}
		else if (this.LargeIcon.color.a < 1f)
		{
			this.LargeIcon.color = new Color(this.LargeIcon.color.r, this.LargeIcon.color.g, this.LargeIcon.color.b, this.LargeIcon.color.a + Time.deltaTime * 10f);
			if (this.LargeIcon.color.a > 1f)
			{
				this.LargeIcon.color = new Color(this.LargeIcon.color.r, this.LargeIcon.color.g, this.LargeIcon.color.b, 1f);
			}
		}
		this.Shadow.color = new Color(this.Shadow.color.r, this.Shadow.color.g, this.Shadow.color.b, this.LargeIcon.color.a * 0.75f);
		if (!this.Switch && Input.GetButtonDown("A") && this.List == 1)
		{
			this.Viewing = true;
		}
		if (Input.GetButtonDown("B"))
		{
			if (this.Viewing)
			{
				this.Viewing = false;
			}
			else
			{
				this.Switch = true;
			}
		}
		if (this.Switch)
		{
			if (this.Phase == 1)
			{
				this.ChallengePanel.alpha -= Time.deltaTime;
				if (this.ChallengePanel.alpha <= 0f)
				{
					this.Phase++;
					return;
				}
			}
			else
			{
				this.CalendarPanel.alpha += Time.deltaTime;
				if (this.CalendarPanel.alpha >= 1f)
				{
					this.Calendar.enabled = true;
					base.enabled = false;
					this.Switch = false;
					this.Phase = 1;
				}
			}
		}
	}

	// Token: 0x04000CF7 RID: 3319
	public InputManagerScript InputManager;

	// Token: 0x04000CF8 RID: 3320
	public CalendarScript Calendar;

	// Token: 0x04000CF9 RID: 3321
	public GameObject ViewButton;

	// Token: 0x04000CFA RID: 3322
	public Transform Arrows;

	// Token: 0x04000CFB RID: 3323
	public Transform[] ChallengeList;

	// Token: 0x04000CFC RID: 3324
	public int[] Challenges;

	// Token: 0x04000CFD RID: 3325
	public UIPanel[] Panels;

	// Token: 0x04000CFE RID: 3326
	public UIPanel ChallengePanel;

	// Token: 0x04000CFF RID: 3327
	public UIPanel CalendarPanel;

	// Token: 0x04000D00 RID: 3328
	public UITexture LargeIcon;

	// Token: 0x04000D01 RID: 3329
	public UISprite Shadow;

	// Token: 0x04000D02 RID: 3330
	public bool Viewing;

	// Token: 0x04000D03 RID: 3331
	public bool Switch;

	// Token: 0x04000D04 RID: 3332
	public int Phase = 1;

	// Token: 0x04000D05 RID: 3333
	public int List;
}
