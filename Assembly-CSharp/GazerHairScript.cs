﻿using System;
using UnityEngine;

// Token: 0x020002DB RID: 731
public class GazerHairScript : MonoBehaviour
{
	// Token: 0x060014D3 RID: 5331 RVA: 0x000CE4F0 File Offset: 0x000CC6F0
	private void Update()
	{
		this.ID = 0;
		while (this.ID < this.Weight.Length)
		{
			this.Weight[this.ID] = Mathf.MoveTowards(this.Weight[this.ID], this.TargetWeight[this.ID], Time.deltaTime * this.Strength);
			if (this.Weight[this.ID] == this.TargetWeight[this.ID])
			{
				this.TargetWeight[this.ID] = UnityEngine.Random.Range(0f, 100f);
			}
			this.MyMesh.SetBlendShapeWeight(this.ID, this.Weight[this.ID]);
			this.ID++;
		}
	}

	// Token: 0x040020E6 RID: 8422
	public SkinnedMeshRenderer MyMesh;

	// Token: 0x040020E7 RID: 8423
	public float[] TargetWeight;

	// Token: 0x040020E8 RID: 8424
	public float[] Weight;

	// Token: 0x040020E9 RID: 8425
	public float Strength = 100f;

	// Token: 0x040020EA RID: 8426
	public int ID;
}
