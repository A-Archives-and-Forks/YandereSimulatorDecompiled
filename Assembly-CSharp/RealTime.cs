﻿using System;
using UnityEngine;

// Token: 0x0200007C RID: 124
public class RealTime : MonoBehaviour
{
	// Token: 0x1700006C RID: 108
	// (get) Token: 0x06000467 RID: 1127 RVA: 0x0002CABF File Offset: 0x0002ACBF
	public static float time
	{
		get
		{
			return Time.unscaledTime;
		}
	}

	// Token: 0x1700006D RID: 109
	// (get) Token: 0x06000468 RID: 1128 RVA: 0x0002CAC6 File Offset: 0x0002ACC6
	public static float deltaTime
	{
		get
		{
			return Time.unscaledDeltaTime;
		}
	}
}
