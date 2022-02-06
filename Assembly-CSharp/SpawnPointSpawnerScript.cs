﻿using System;
using UnityEngine;

// Token: 0x02000434 RID: 1076
public class SpawnPointSpawnerScript : MonoBehaviour
{
	// Token: 0x06001CC9 RID: 7369 RVA: 0x00156C0C File Offset: 0x00154E0C
	private void Start()
	{
		while (this.ID < this.Limit)
		{
			if (this.Iterations == 0)
			{
				GameObject gameObject;
				if (this.SpawnGirl)
				{
					gameObject = UnityEngine.Object.Instantiate<GameObject>(this.SimpleGirl, new Vector3((float)this.Column, 0f, (float)this.Row), Quaternion.identity);
				}
				else
				{
					gameObject = UnityEngine.Object.Instantiate<GameObject>(this.SpawnPoint, new Vector3((float)this.Column, 0f, (float)this.Row), Quaternion.identity);
				}
				gameObject.transform.parent = this.SpawnPointParent;
				this.Iterations += this.IterationsToWait;
				this.Row--;
				this.ID++;
				gameObject.name = "SpawnPoint_" + this.ID.ToString();
			}
			this.Column += this.Direction;
			if (this.Column > 4 || this.Column < -4)
			{
				this.Direction *= -1;
			}
			if (this.Column > 4)
			{
				this.Column -= 2;
			}
			if (this.Column < -4)
			{
				this.Column += 2;
			}
			if (this.Column == 0)
			{
				this.Column += this.Direction;
			}
			this.Iterations--;
		}
	}

	// Token: 0x040033EC RID: 13292
	public Transform SpawnPointParent;

	// Token: 0x040033ED RID: 13293
	public GameObject SimpleGirl;

	// Token: 0x040033EE RID: 13294
	public GameObject SpawnPoint;

	// Token: 0x040033EF RID: 13295
	public int IterationsToWait = 3;

	// Token: 0x040033F0 RID: 13296
	public int Direction = 1;

	// Token: 0x040033F1 RID: 13297
	public int Column = -4;

	// Token: 0x040033F2 RID: 13298
	public int Iterations;

	// Token: 0x040033F3 RID: 13299
	public int Limit;

	// Token: 0x040033F4 RID: 13300
	public int Row;

	// Token: 0x040033F5 RID: 13301
	public int ID;

	// Token: 0x040033F6 RID: 13302
	public bool SpawnGirl;
}
