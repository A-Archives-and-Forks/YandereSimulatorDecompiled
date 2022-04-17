﻿using System;
using UnityEngine;

// Token: 0x02000447 RID: 1095
public class StalkerIntroCameraScript : MonoBehaviour
{
	// Token: 0x06001D31 RID: 7473 RVA: 0x0015D734 File Offset: 0x0015B934
	private void Update()
	{
		if (this.YandereAnim["f02_wallJump_00"].time > this.YandereAnim["f02_wallJump_00"].length)
		{
			this.Speed += Time.deltaTime;
			this.Yandere.position = Vector3.Lerp(this.Yandere.position, new Vector3(14.33333f, 0f, 15f), Time.deltaTime * this.Speed);
			base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(13.75f, 1.4f, 14.5f), Time.deltaTime * this.Speed);
			base.transform.eulerAngles = Vector3.Lerp(base.transform.eulerAngles, new Vector3(15f, 180f, 0f), Time.deltaTime * this.Speed);
		}
	}

	// Token: 0x04003546 RID: 13638
	public Animation YandereAnim;

	// Token: 0x04003547 RID: 13639
	public Transform Yandere;

	// Token: 0x04003548 RID: 13640
	public float Speed;
}
