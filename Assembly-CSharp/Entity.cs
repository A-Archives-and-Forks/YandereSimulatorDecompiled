﻿using System;
using UnityEngine;

// Token: 0x020002B1 RID: 689
[Serializable]
public abstract class Entity
{
	// Token: 0x0600145B RID: 5211 RVA: 0x000C725F File Offset: 0x000C545F
	public Entity(GenderType gender)
	{
		this.gender = gender;
		this.deathType = DeathType.None;
	}

	// Token: 0x17000363 RID: 867
	// (get) Token: 0x0600145C RID: 5212 RVA: 0x000C7275 File Offset: 0x000C5475
	public GenderType Gender
	{
		get
		{
			return this.gender;
		}
	}

	// Token: 0x17000364 RID: 868
	// (get) Token: 0x0600145D RID: 5213 RVA: 0x000C727D File Offset: 0x000C547D
	// (set) Token: 0x0600145E RID: 5214 RVA: 0x000C7285 File Offset: 0x000C5485
	public DeathType DeathType
	{
		get
		{
			return this.deathType;
		}
		set
		{
			this.deathType = value;
		}
	}

	// Token: 0x17000365 RID: 869
	// (get) Token: 0x0600145F RID: 5215
	public abstract EntityType EntityType { get; }

	// Token: 0x04001F4C RID: 8012
	[SerializeField]
	private GenderType gender;

	// Token: 0x04001F4D RID: 8013
	[SerializeField]
	private DeathType deathType;
}
