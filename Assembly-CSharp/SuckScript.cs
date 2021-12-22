﻿using System;
using UnityEngine;

// Token: 0x0200045A RID: 1114
public class SuckScript : MonoBehaviour
{
	// Token: 0x06001E4A RID: 7754 RVA: 0x001A0148 File Offset: 0x0019E348
	private void Update()
	{
		this.Strength += Time.deltaTime;
		base.transform.position = Vector3.MoveTowards(base.transform.position, this.Student.Yandere.Hips.position + base.transform.up * 0.25f, Time.deltaTime * this.Strength);
		if (Vector3.Distance(base.transform.position, this.Student.Yandere.Hips.position + base.transform.up * 0.25f) < 1f)
		{
			base.transform.localScale = Vector3.MoveTowards(base.transform.localScale, Vector3.zero, Time.deltaTime);
			if (base.transform.localScale == Vector3.zero)
			{
				base.transform.parent.parent.parent.gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x04003E03 RID: 15875
	public StudentScript Student;

	// Token: 0x04003E04 RID: 15876
	public float Strength;
}
