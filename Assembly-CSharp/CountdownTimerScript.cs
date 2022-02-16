﻿using System;
using UnityEngine;

// Token: 0x02000262 RID: 610
public class CountdownTimerScript : MonoBehaviour
{
	// Token: 0x060012EB RID: 4843 RVA: 0x000A5EB6 File Offset: 0x000A40B6
	private void Update()
	{
		this.Timer = Mathf.MoveTowards(this.Timer, 0f, Time.deltaTime);
		this.DisplayTime(this.Timer);
	}

	// Token: 0x060012EC RID: 4844 RVA: 0x000A5EE0 File Offset: 0x000A40E0
	private void DisplayTime(float timeToDisplay)
	{
		float num = (float)Mathf.FloorToInt(timeToDisplay / 60f);
		float num2 = (float)Mathf.FloorToInt(timeToDisplay % 60f);
		this.CountdownLabel.text = string.Format("{0:0}:{1:00}", num, num2);
	}

	// Token: 0x04001ABA RID: 6842
	public UILabel CountdownLabel;

	// Token: 0x04001ABB RID: 6843
	public float Timer;
}
