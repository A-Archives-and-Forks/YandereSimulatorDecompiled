﻿using System;
using UnityEngine;

// Token: 0x020000FD RID: 253
[Serializable]
public class BucketWeights : BucketContents
{
	// Token: 0x17000209 RID: 521
	// (get) Token: 0x06000A7F RID: 2687 RVA: 0x0005CE6B File Offset: 0x0005B06B
	// (set) Token: 0x06000A80 RID: 2688 RVA: 0x0005CE73 File Offset: 0x0005B073
	public int Count
	{
		get
		{
			return this.count;
		}
		set
		{
			this.count = ((value < 0) ? 0 : value);
		}
	}

	// Token: 0x1700020A RID: 522
	// (get) Token: 0x06000A81 RID: 2689 RVA: 0x0005CE83 File Offset: 0x0005B083
	public override BucketContentsType Type
	{
		get
		{
			return BucketContentsType.Weights;
		}
	}

	// Token: 0x1700020B RID: 523
	// (get) Token: 0x06000A82 RID: 2690 RVA: 0x0005CE86 File Offset: 0x0005B086
	public override bool IsCleaningAgent
	{
		get
		{
			return false;
		}
	}

	// Token: 0x1700020C RID: 524
	// (get) Token: 0x06000A83 RID: 2691 RVA: 0x0005CE89 File Offset: 0x0005B089
	public override bool IsFlammable
	{
		get
		{
			return false;
		}
	}

	// Token: 0x06000A84 RID: 2692 RVA: 0x0005CE8C File Offset: 0x0005B08C
	public override bool CanBeLifted(int strength)
	{
		return strength > 0;
	}

	// Token: 0x04000C37 RID: 3127
	[SerializeField]
	private int count;
}
