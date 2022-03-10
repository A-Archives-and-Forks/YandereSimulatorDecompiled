﻿using System;
using UnityEngine;

// Token: 0x020002A2 RID: 674
public class EmergencyExitScript : MonoBehaviour
{
	// Token: 0x0600141B RID: 5147 RVA: 0x000BFE44 File Offset: 0x000BE044
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

	// Token: 0x0600141C RID: 5148 RVA: 0x000BFF65 File Offset: 0x000BE165
	private void OnTriggerStay(Collider other)
	{
		this.Student = other.gameObject.GetComponent<StudentScript>();
		if (this.Student != null)
		{
			this.Timer = 1f;
			this.Open = true;
		}
	}

	// Token: 0x04001E38 RID: 7736
	public StudentScript Student;

	// Token: 0x04001E39 RID: 7737
	public Transform Yandere;

	// Token: 0x04001E3A RID: 7738
	public Transform Pivot;

	// Token: 0x04001E3B RID: 7739
	public float Timer;

	// Token: 0x04001E3C RID: 7740
	public bool Open;
}
