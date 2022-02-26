﻿using System;
using System.Globalization;
using UnityEngine;

// Token: 0x02000317 RID: 791
public class HomeClockScript : MonoBehaviour
{
	// Token: 0x06001869 RID: 6249 RVA: 0x000EC588 File Offset: 0x000EA788
	private void Start()
	{
		this.DayLabel.text = this.GetWeekdayText(DateGlobals.Weekday);
		if (HomeGlobals.Night)
		{
			this.HourLabel.text = "8:00 PM";
		}
		else
		{
			this.HourLabel.text = (HomeGlobals.LateForSchool ? "7:30 AM" : "6:30 AM");
		}
		this.UpdateMoneyLabel();
	}

	// Token: 0x0600186A RID: 6250 RVA: 0x000EC5E8 File Offset: 0x000EA7E8
	private void Update()
	{
		if (this.ShakeMoney)
		{
			this.Shake = Mathf.MoveTowards(this.Shake, 0f, Time.deltaTime * 10f);
			this.MoneyLabel.transform.localPosition = new Vector3(this.Origin.x + UnityEngine.Random.Range(this.Shake * -1f, this.Shake * 1f), this.Origin.y + UnityEngine.Random.Range(this.Shake * -1f, this.Shake * 1f), 0f);
			this.G = Mathf.MoveTowards(this.G, 0.75f, Time.deltaTime);
			this.B = Mathf.MoveTowards(this.B, 1f, Time.deltaTime);
			this.MoneyLabel.color = new Color(1f, this.G, this.B, 1f);
			if (this.Shake == 0f)
			{
				this.ShakeMoney = false;
			}
		}
	}

	// Token: 0x0600186B RID: 6251 RVA: 0x000EC700 File Offset: 0x000EA900
	private string GetWeekdayText(DayOfWeek weekday)
	{
		if (weekday == DayOfWeek.Sunday)
		{
			return "SUNDAY";
		}
		if (weekday == DayOfWeek.Monday)
		{
			return "MONDAY";
		}
		if (weekday == DayOfWeek.Tuesday)
		{
			return "TUESDAY";
		}
		if (weekday == DayOfWeek.Wednesday)
		{
			return "WEDNESDAY";
		}
		if (weekday == DayOfWeek.Thursday)
		{
			return "THURSDAY";
		}
		if (weekday == DayOfWeek.Friday)
		{
			return "FRIDAY";
		}
		return "SATURDAY";
	}

	// Token: 0x0600186C RID: 6252 RVA: 0x000EC750 File Offset: 0x000EA950
	public void UpdateMoneyLabel()
	{
		this.MoneyLabel.text = "$" + PlayerGlobals.Money.ToString("F2", NumberFormatInfo.InvariantInfo);
	}

	// Token: 0x0600186D RID: 6253 RVA: 0x000EC78C File Offset: 0x000EA98C
	public void MoneyFail()
	{
		if (this.Origin != Vector3.zero)
		{
			this.MoneyLabel.transform.localPosition = this.Origin;
		}
		this.Origin = this.MoneyLabel.transform.localPosition;
		this.ShakeMoney = true;
		this.Shake = 10f;
		this.G = 0f;
		this.B = 0f;
		this.MyAudio.Play();
	}

	// Token: 0x04002461 RID: 9313
	public UILabel MoneyLabel;

	// Token: 0x04002462 RID: 9314
	public UILabel HourLabel;

	// Token: 0x04002463 RID: 9315
	public UILabel DayLabel;

	// Token: 0x04002464 RID: 9316
	public AudioSource MyAudio;

	// Token: 0x04002465 RID: 9317
	public bool ShakeMoney;

	// Token: 0x04002466 RID: 9318
	public Vector3 Origin;

	// Token: 0x04002467 RID: 9319
	public float Shake;

	// Token: 0x04002468 RID: 9320
	public float G;

	// Token: 0x04002469 RID: 9321
	public float B;
}
