﻿using System;

// Token: 0x020000FC RID: 252
[Serializable]
public class BucketGas : BucketContents
{
	// Token: 0x17000206 RID: 518
	// (get) Token: 0x06000A7A RID: 2682 RVA: 0x0005CE57 File Offset: 0x0005B057
	public override BucketContentsType Type
	{
		get
		{
			return BucketContentsType.Gas;
		}
	}

	// Token: 0x17000207 RID: 519
	// (get) Token: 0x06000A7B RID: 2683 RVA: 0x0005CE5A File Offset: 0x0005B05A
	public override bool IsCleaningAgent
	{
		get
		{
			return false;
		}
	}

	// Token: 0x17000208 RID: 520
	// (get) Token: 0x06000A7C RID: 2684 RVA: 0x0005CE5D File Offset: 0x0005B05D
	public override bool IsFlammable
	{
		get
		{
			return true;
		}
	}

	// Token: 0x06000A7D RID: 2685 RVA: 0x0005CE60 File Offset: 0x0005B060
	public override bool CanBeLifted(int strength)
	{
		return true;
	}
}
