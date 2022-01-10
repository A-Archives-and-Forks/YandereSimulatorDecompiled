﻿using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200053F RID: 1343
	[ExecuteInEditMode]
	public class AutoCam : PivotBasedCameraRig
	{
		// Token: 0x06002265 RID: 8805 RVA: 0x001EC230 File Offset: 0x001EA430
		protected override void FollowTarget(float deltaTime)
		{
			if (deltaTime <= 0f || this.m_Target == null)
			{
				return;
			}
			Vector3 vector = this.m_Target.forward;
			Vector3 up = this.m_Target.up;
			if (this.m_FollowVelocity && Application.isPlaying)
			{
				if (this.targetRigidbody.velocity.magnitude > this.m_TargetVelocityLowerLimit)
				{
					vector = this.targetRigidbody.velocity.normalized;
					up = Vector3.up;
				}
				else
				{
					up = Vector3.up;
				}
				this.m_CurrentTurnAmount = Mathf.SmoothDamp(this.m_CurrentTurnAmount, 1f, ref this.m_TurnSpeedVelocityChange, this.m_SmoothTurnTime);
			}
			else
			{
				float num = Mathf.Atan2(vector.x, vector.z) * 57.29578f;
				if (this.m_SpinTurnLimit > 0f)
				{
					float value = Mathf.Abs(Mathf.DeltaAngle(this.m_LastFlatAngle, num)) / deltaTime;
					float num2 = Mathf.InverseLerp(this.m_SpinTurnLimit, this.m_SpinTurnLimit * 0.75f, value);
					float smoothTime = (this.m_CurrentTurnAmount > num2) ? 0.1f : 1f;
					if (Application.isPlaying)
					{
						this.m_CurrentTurnAmount = Mathf.SmoothDamp(this.m_CurrentTurnAmount, num2, ref this.m_TurnSpeedVelocityChange, smoothTime);
					}
					else
					{
						this.m_CurrentTurnAmount = num2;
					}
				}
				else
				{
					this.m_CurrentTurnAmount = 1f;
				}
				this.m_LastFlatAngle = num;
			}
			base.transform.position = Vector3.Lerp(base.transform.position, this.m_Target.position, deltaTime * this.m_MoveSpeed);
			if (!this.m_FollowTilt)
			{
				vector.y = 0f;
				if (vector.sqrMagnitude < 1E-45f)
				{
					vector = base.transform.forward;
				}
			}
			Quaternion b = Quaternion.LookRotation(vector, this.m_RollUp);
			this.m_RollUp = ((this.m_RollSpeed > 0f) ? Vector3.Slerp(this.m_RollUp, up, this.m_RollSpeed * deltaTime) : Vector3.up);
			base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, this.m_TurnSpeed * this.m_CurrentTurnAmount * deltaTime);
		}

		// Token: 0x04004A2D RID: 18989
		[SerializeField]
		private float m_MoveSpeed = 3f;

		// Token: 0x04004A2E RID: 18990
		[SerializeField]
		private float m_TurnSpeed = 1f;

		// Token: 0x04004A2F RID: 18991
		[SerializeField]
		private float m_RollSpeed = 0.2f;

		// Token: 0x04004A30 RID: 18992
		[SerializeField]
		private bool m_FollowVelocity;

		// Token: 0x04004A31 RID: 18993
		[SerializeField]
		private bool m_FollowTilt = true;

		// Token: 0x04004A32 RID: 18994
		[SerializeField]
		private float m_SpinTurnLimit = 90f;

		// Token: 0x04004A33 RID: 18995
		[SerializeField]
		private float m_TargetVelocityLowerLimit = 4f;

		// Token: 0x04004A34 RID: 18996
		[SerializeField]
		private float m_SmoothTurnTime = 0.2f;

		// Token: 0x04004A35 RID: 18997
		private float m_LastFlatAngle;

		// Token: 0x04004A36 RID: 18998
		private float m_CurrentTurnAmount;

		// Token: 0x04004A37 RID: 18999
		private float m_TurnSpeedVelocityChange;

		// Token: 0x04004A38 RID: 19000
		private Vector3 m_RollUp = Vector3.up;
	}
}
