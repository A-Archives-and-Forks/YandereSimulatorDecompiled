﻿using System;
using UnityEngine;

// Token: 0x020002A0 RID: 672
public class EmergencyExitScript : MonoBehaviour
{
	// Token: 0x0600140D RID: 5133 RVA: 0x000BF12C File Offset: 0x000BD32C
	private void Update()
	{
		if (Vector3.Distance(this.Yandere.position, base.transform.position) < 2f)
		{
			this.Open = true;
		}
		else if (this.Timer == 0f)
		{
			this.Student = null;
			this.Open = false;
		}
		if (!this.Open)
		{
			this.Pivot.localEulerAngles = new Vector3(this.Pivot.localEulerAngles.x, Mathf.Lerp(this.Pivot.localEulerAngles.y, 0f, Time.deltaTime * 10f), this.Pivot.localEulerAngles.z);
			return;
		}
		this.Pivot.localEulerAngles = new Vector3(this.Pivot.localEulerAngles.x, Mathf.Lerp(this.Pivot.localEulerAngles.y, 90f, Time.deltaTime * 10f), this.Pivot.localEulerAngles.z);
		this.Timer = Mathf.MoveTowards(this.Timer, 0f, Time.deltaTime);
	}

	// Token: 0x0600140E RID: 5134 RVA: 0x000BF24D File Offset: 0x000BD44D
	private void OnTriggerStay(Collider other)
	{
		this.Student = other.gameObject.GetComponent<StudentScript>();
		if (this.Student != null)
		{
			this.Timer = 1f;
			this.Open = true;
		}
	}

	// Token: 0x04001E14 RID: 7700
	public StudentScript Student;

	// Token: 0x04001E15 RID: 7701
	public Transform Yandere;

	// Token: 0x04001E16 RID: 7702
	public Transform Pivot;

	// Token: 0x04001E17 RID: 7703
	public float Timer;

	// Token: 0x04001E18 RID: 7704
	public bool Open;
}
