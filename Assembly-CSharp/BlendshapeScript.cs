﻿using System;
using UnityEngine;

// Token: 0x020000E6 RID: 230
public class BlendshapeScript : MonoBehaviour
{
	// Token: 0x06000A30 RID: 2608 RVA: 0x0005A44C File Offset: 0x0005864C
	private void LateUpdate()
	{
		this.Happiness += Time.deltaTime * 10f;
		this.MyMesh.SetBlendShapeWeight(0, this.Happiness);
		this.Blink += Time.deltaTime * 10f;
		this.MyMesh.SetBlendShapeWeight(8, 100f);
	}

	// Token: 0x04000B82 RID: 2946
	public SkinnedMeshRenderer MyMesh;

	// Token: 0x04000B83 RID: 2947
	public float Happiness;

	// Token: 0x04000B84 RID: 2948
	public float Blink;
}
