﻿using System;
using UnityEngine;

// Token: 0x020004F4 RID: 1268
public class YanvaniaZombieSpawnerScript : MonoBehaviour
{
	// Token: 0x0600211F RID: 8479 RVA: 0x001EBCCC File Offset: 0x001E9ECC
	private void Update()
	{
		if (this.Yanmont.transform.position.y > 0f)
		{
			this.ID = 0;
			this.SpawnTimer += Time.deltaTime;
			if (this.SpawnTimer > 1f)
			{
				while (this.ID < 4)
				{
					if (this.Zombies[this.ID] == null)
					{
						this.SpawnSide = UnityEngine.Random.Range(1, 3);
						if (this.Yanmont.transform.position.x < this.LeftBoundary + 5f)
						{
							this.SpawnSide = 2;
						}
						if (this.Yanmont.transform.position.x > this.RightBoundary - 5f)
						{
							this.SpawnSide = 1;
						}
						if (this.Yanmont.transform.position.x < this.LeftBoundary)
						{
							this.RelativePoint = this.LeftBoundary;
						}
						else if (this.Yanmont.transform.position.x > this.RightBoundary)
						{
							this.RelativePoint = this.RightBoundary;
						}
						else
						{
							this.RelativePoint = this.Yanmont.transform.position.x;
						}
						if (this.SpawnSide == 1)
						{
							this.SpawnPoints[0].x = this.RelativePoint - 2.5f;
							this.SpawnPoints[1].x = this.RelativePoint - 3.5f;
							this.SpawnPoints[2].x = this.RelativePoint - 4.5f;
							this.SpawnPoints[3].x = this.RelativePoint - 5.5f;
						}
						else
						{
							this.SpawnPoints[0].x = this.RelativePoint + 2.5f;
							this.SpawnPoints[1].x = this.RelativePoint + 3.5f;
							this.SpawnPoints[2].x = this.RelativePoint + 4.5f;
							this.SpawnPoints[3].x = this.RelativePoint + 5.5f;
						}
						this.Zombies[this.ID] = UnityEngine.Object.Instantiate<GameObject>(this.Zombie, this.SpawnPoints[this.ID], Quaternion.identity);
						this.NewZombieScript = this.Zombies[this.ID].GetComponent<YanvaniaZombieScript>();
						this.NewZombieScript.LeftBoundary = this.LeftBoundary;
						this.NewZombieScript.RightBoundary = this.RightBoundary;
						this.NewZombieScript.Yanmont = this.Yanmont;
						break;
					}
					this.ID++;
				}
				this.SpawnTimer = 0f;
			}
		}
	}

	// Token: 0x04004949 RID: 18761
	public YanvaniaZombieScript NewZombieScript;

	// Token: 0x0400494A RID: 18762
	public GameObject Zombie;

	// Token: 0x0400494B RID: 18763
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x0400494C RID: 18764
	public float SpawnTimer;

	// Token: 0x0400494D RID: 18765
	public float RelativePoint;

	// Token: 0x0400494E RID: 18766
	public float RightBoundary;

	// Token: 0x0400494F RID: 18767
	public float LeftBoundary;

	// Token: 0x04004950 RID: 18768
	public int SpawnSide;

	// Token: 0x04004951 RID: 18769
	public int ID;

	// Token: 0x04004952 RID: 18770
	public GameObject[] Zombies;

	// Token: 0x04004953 RID: 18771
	public Vector3[] SpawnPoints;
}
