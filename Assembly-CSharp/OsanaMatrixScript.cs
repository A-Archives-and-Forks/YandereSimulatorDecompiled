﻿using System;
using UnityEngine;

// Token: 0x02000385 RID: 901
public class OsanaMatrixScript : MonoBehaviour
{
	// Token: 0x06001A20 RID: 6688 RVA: 0x00114160 File Offset: 0x00112360
	private void Update()
	{
		if (Input.GetKeyDown("z"))
		{
			this.Phase++;
		}
		if (this.Phase == 2)
		{
			this.MatrixEffect.Fade = Mathf.MoveTowards(this.MatrixEffect.Fade, 1f, Time.deltaTime);
			return;
		}
		if (this.Phase == 3)
		{
			this.MatrixEffect.Fade = Mathf.MoveTowards(this.MatrixEffect.Fade, 0f, Time.deltaTime);
			return;
		}
		if (this.Phase == 4)
		{
			this.Rivals.SetActive(true);
		}
	}

	// Token: 0x04002AA3 RID: 10915
	public CameraFilterPack_3D_Matrix MatrixEffect;

	// Token: 0x04002AA4 RID: 10916
	public GameObject Rivals;

	// Token: 0x04002AA5 RID: 10917
	public int Phase = 1;
}
