﻿using System;
using UnityEngine;

// Token: 0x020002C1 RID: 705
public class ExpressionMaskScript : MonoBehaviour
{
	// Token: 0x06001488 RID: 5256 RVA: 0x000C891C File Offset: 0x000C6B1C
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftAlt))
		{
			if (this.ID < 3)
			{
				this.ID++;
			}
			else
			{
				this.ID = 0;
			}
			switch (this.ID)
			{
			case 0:
				this.Mask.material.mainTextureOffset = Vector2.zero;
				return;
			case 1:
				this.Mask.material.mainTextureOffset = new Vector2(0f, 0.5f);
				return;
			case 2:
				this.Mask.material.mainTextureOffset = new Vector2(0.5f, 0f);
				return;
			case 3:
				this.Mask.material.mainTextureOffset = new Vector2(0.5f, 0.5f);
				break;
			default:
				return;
			}
		}
	}

	// Token: 0x04001FC7 RID: 8135
	public Renderer Mask;

	// Token: 0x04001FC8 RID: 8136
	public int ID;
}
