﻿using System;
using UnityEngine;

// Token: 0x02000291 RID: 657
public class DumpScript : MonoBehaviour
{
	// Token: 0x060013BC RID: 5052 RVA: 0x000BACD0 File Offset: 0x000B8ED0
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 5f)
		{
			this.Incinerator.Corpses++;
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04001D66 RID: 7526
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x04001D67 RID: 7527
	public IncineratorScript Incinerator;

	// Token: 0x04001D68 RID: 7528
	public float Timer;
}
