﻿using System;
using UnityEngine;

// Token: 0x02000496 RID: 1174
[Serializable]
public class DateAndTime
{
	// Token: 0x06001F3B RID: 7995 RVA: 0x001B8B97 File Offset: 0x001B6D97
	public DateAndTime(int week, DayOfWeek weekday, Clock clock)
	{
		this.week = week;
		this.weekday = weekday;
		this.clock = clock;
	}

	// Token: 0x170004B9 RID: 1209
	// (get) Token: 0x06001F3C RID: 7996 RVA: 0x001B8BB4 File Offset: 0x001B6DB4
	public int Week
	{
		get
		{
			return this.week;
		}
	}

	// Token: 0x170004BA RID: 1210
	// (get) Token: 0x06001F3D RID: 7997 RVA: 0x001B8BBC File Offset: 0x001B6DBC
	public DayOfWeek Weekday
	{
		get
		{
			return this.weekday;
		}
	}

	// Token: 0x170004BB RID: 1211
	// (get) Token: 0x06001F3E RID: 7998 RVA: 0x001B8BC4 File Offset: 0x001B6DC4
	public Clock Clock
	{
		get
		{
			return this.clock;
		}
	}

	// Token: 0x170004BC RID: 1212
	// (get) Token: 0x06001F3F RID: 7999 RVA: 0x001B8BCC File Offset: 0x001B6DCC
	public int TotalSeconds
	{
		get
		{
			int num = this.week * 604800;
			int num2 = (int)(this.weekday * (DayOfWeek)86400);
			int totalSeconds = this.clock.TotalSeconds;
			return num + num2 + totalSeconds;
		}
	}

	// Token: 0x06001F40 RID: 8000 RVA: 0x001B8C02 File Offset: 0x001B6E02
	public void IncrementWeek()
	{
		this.week++;
	}

	// Token: 0x06001F41 RID: 8001 RVA: 0x001B8C14 File Offset: 0x001B6E14
	public void IncrementWeekday()
	{
		int num = (int)this.weekday;
		num++;
		if (num == 7)
		{
			this.IncrementWeek();
			num = 0;
		}
		this.weekday = (DayOfWeek)num;
	}

	// Token: 0x06001F42 RID: 8002 RVA: 0x001B8C40 File Offset: 0x001B6E40
	public void Tick(float dt)
	{
		int hours = this.clock.Hours24;
		this.clock.Tick(dt);
		if (this.clock.Hours24 < hours)
		{
			this.IncrementWeekday();
		}
	}

	// Token: 0x04004164 RID: 16740
	[SerializeField]
	private int week;

	// Token: 0x04004165 RID: 16741
	[SerializeField]
	private DayOfWeek weekday;

	// Token: 0x04004166 RID: 16742
	[SerializeField]
	private Clock clock;
}
