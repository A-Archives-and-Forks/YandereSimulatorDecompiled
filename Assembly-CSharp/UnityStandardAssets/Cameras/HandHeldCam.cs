﻿using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000542 RID: 1346
	public class HandHeldCam : LookatTarget
	{
		// Token: 0x06002275 RID: 8821 RVA: 0x001EDFF4 File Offset: 0x001EC1F4
		protected override void FollowTarget(float deltaTime)
		{
			base.FollowTarget(deltaTime);
			float num = Mathf.PerlinNoise(0f, Time.time * this.m_SwaySpeed) - 0.5f;
			float num2 = Mathf.PerlinNoise(0f, Time.time * this.m_SwaySpeed + 100f) - 0.5f;
			num *= this.m_BaseSwayAmount;
			num2 *= this.m_BaseSwayAmount;
			float num3 = Mathf.PerlinNoise(0f, Time.time * this.m_SwaySpeed) - 0.5f + this.m_TrackingBias;
			float num4 = Mathf.PerlinNoise(0f, Time.time * this.m_SwaySpeed + 100f) - 0.5f + this.m_TrackingBias;
			num3 *= -this.m_TrackingSwayAmount * this.m_FollowVelocity.x;
			num4 *= this.m_TrackingSwayAmount * this.m_FollowVelocity.y;
			base.transform.Rotate(num + num3, num2 + num4, 0f);
		}

		// Token: 0x04004A5E RID: 19038
		[SerializeField]
		private float m_SwaySpeed = 0.5f;

		// Token: 0x04004A5F RID: 19039
		[SerializeField]
		private float m_BaseSwayAmount = 0.5f;

		// Token: 0x04004A60 RID: 19040
		[SerializeField]
		private float m_TrackingSwayAmount = 0.5f;

		// Token: 0x04004A61 RID: 19041
		[Range(-1f, 1f)]
		[SerializeField]
		private float m_TrackingBias;
	}
}
