﻿using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000527 RID: 1319
	public class Mudguard : MonoBehaviour
	{
		// Token: 0x06002196 RID: 8598 RVA: 0x001EB3B9 File Offset: 0x001E95B9
		private void Start()
		{
			this.m_OriginalRotation = base.transform.localRotation;
		}

		// Token: 0x06002197 RID: 8599 RVA: 0x001EB3CC File Offset: 0x001E95CC
		private void Update()
		{
			base.transform.localRotation = this.m_OriginalRotation * Quaternion.Euler(0f, this.carController.CurrentSteerAngle, 0f);
		}

		// Token: 0x040049A8 RID: 18856
		public CarController carController;

		// Token: 0x040049A9 RID: 18857
		private Quaternion m_OriginalRotation;
	}
}
