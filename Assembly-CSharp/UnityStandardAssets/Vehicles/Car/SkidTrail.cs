﻿using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000528 RID: 1320
	public class SkidTrail : MonoBehaviour
	{
		// Token: 0x06002197 RID: 8599 RVA: 0x001EB0EE File Offset: 0x001E92EE
		private IEnumerator Start()
		{
			for (;;)
			{
				yield return null;
				if (base.transform.parent.parent == null)
				{
					UnityEngine.Object.Destroy(base.gameObject, this.m_PersistTime);
				}
			}
			yield break;
		}

		// Token: 0x040049A4 RID: 18852
		[SerializeField]
		private float m_PersistTime;
	}
}
