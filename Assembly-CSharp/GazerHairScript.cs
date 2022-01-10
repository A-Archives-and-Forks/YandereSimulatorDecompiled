﻿using System;
using UnityEngine;

// Token: 0x020002DB RID: 731
public class GazerHairScript : MonoBehaviour
{
	// Token: 0x060014D2 RID: 5330 RVA: 0x000CDF34 File Offset: 0x000CC134
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

	// Token: 0x040020DD RID: 8413
	public SkinnedMeshRenderer MyMesh;

	// Token: 0x040020DE RID: 8414
	public float[] TargetWeight;

	// Token: 0x040020DF RID: 8415
	public float[] Weight;

	// Token: 0x040020E0 RID: 8416
	public float Strength = 100f;

	// Token: 0x040020E1 RID: 8417
	public int ID;
}
