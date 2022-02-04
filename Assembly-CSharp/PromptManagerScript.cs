﻿using System;
using UnityEngine;

// Token: 0x020003BD RID: 957
public class PromptManagerScript : MonoBehaviour
{
	// Token: 0x06001B01 RID: 6913 RVA: 0x0012C1B4 File Offset: 0x0012A3B4
	private void Update()
	{
		if (this.Yandere.transform.position.z < -38f)
		{
			if (!this.Outside)
			{
				this.Outside = true;
				foreach (PromptScript promptScript in this.Prompts)
				{
					if (promptScript != null)
					{
						promptScript.enabled = false;
					}
				}
				return;
			}
		}
		else if (this.Outside)
		{
			this.Outside = false;
			foreach (PromptScript promptScript2 in this.Prompts)
			{
				if (promptScript2 != null)
				{
					promptScript2.enabled = true;
				}
			}
		}
	}

	// Token: 0x04002DB5 RID: 11701
	public PromptScript[] Prompts;

	// Token: 0x04002DB6 RID: 11702
	public int ID;

	// Token: 0x04002DB7 RID: 11703
	public Transform Yandere;

	// Token: 0x04002DB8 RID: 11704
	public bool Outside;
}
