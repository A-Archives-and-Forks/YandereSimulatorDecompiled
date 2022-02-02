﻿using System;
using UnityEngine;

// Token: 0x0200042A RID: 1066
public class SlowMoScript : MonoBehaviour
{
	// Token: 0x06001CA8 RID: 7336 RVA: 0x00153C50 File Offset: 0x00151E50
	private void Update()
	{
		if (Input.GetKeyDown("s"))
		{
			this.Spinning = !this.Spinning;
		}
		if (Input.GetKeyDown("a"))
		{
			Time.timeScale = 0.1f;
		}
		if (Input.GetKeyDown("-"))
		{
			Time.timeScale -= 1f;
		}
		if (Input.GetKeyDown("="))
		{
			Time.timeScale += 1f;
		}
		if (Input.GetKeyDown("z"))
		{
			this.Speed += Time.deltaTime;
		}
		if (this.Speed > 0f)
		{
			base.transform.position += new Vector3(Time.deltaTime * 0.1f, 0f, Time.deltaTime * 0.1f);
		}
		if (this.Spinning)
		{
			base.transform.parent.transform.localEulerAngles += new Vector3(0f, Time.deltaTime * 36f, 0f);
		}
	}

	// Token: 0x04003372 RID: 13170
	public bool Spinning;

	// Token: 0x04003373 RID: 13171
	public float Speed;
}
