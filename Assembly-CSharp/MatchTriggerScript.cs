﻿using System;
using UnityEngine;

// Token: 0x0200035E RID: 862
public class MatchTriggerScript : MonoBehaviour
{
	// Token: 0x06001981 RID: 6529 RVA: 0x001039B4 File Offset: 0x00101BB4
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			this.Student = other.gameObject.transform.root.gameObject.GetComponent<StudentScript>();
			if (this.Student != null && this.Student.StudentID > 1 && (this.Student.Gas || this.Fireball))
			{
				this.Student.Combust();
				if (!this.Candle)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
		}
	}

	// Token: 0x040028BC RID: 10428
	public StudentScript Student;

	// Token: 0x040028BD RID: 10429
	public bool Fireball;

	// Token: 0x040028BE RID: 10430
	public bool Candle;
}
