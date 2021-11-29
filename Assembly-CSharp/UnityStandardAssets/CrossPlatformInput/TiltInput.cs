﻿using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000535 RID: 1333
	public class TiltInput : MonoBehaviour
	{
		// Token: 0x060021FE RID: 8702 RVA: 0x001E919C File Offset: 0x001E739C
		private void OnEnable()
		{
			if (this.mapping.type == TiltInput.AxisMapping.MappingType.NamedAxis)
			{
				this.m_SteerAxis = new CrossPlatformInputManager.VirtualAxis(this.mapping.axisName);
				CrossPlatformInputManager.RegisterVirtualAxis(this.m_SteerAxis);
			}
		}

		// Token: 0x060021FF RID: 8703 RVA: 0x001E91CC File Offset: 0x001E73CC
		private void Update()
		{
			float value = 0f;
			if (Input.acceleration != Vector3.zero)
			{
				TiltInput.AxisOptions axisOptions = this.tiltAroundAxis;
				if (axisOptions != TiltInput.AxisOptions.ForwardAxis)
				{
					if (axisOptions == TiltInput.AxisOptions.SidewaysAxis)
					{
						value = Mathf.Atan2(Input.acceleration.z, -Input.acceleration.y) * 57.29578f + this.centreAngleOffset;
					}
				}
				else
				{
					value = Mathf.Atan2(Input.acceleration.x, -Input.acceleration.y) * 57.29578f + this.centreAngleOffset;
				}
			}
			float num = Mathf.InverseLerp(-this.fullTiltAngle, this.fullTiltAngle, value) * 2f - 1f;
			switch (this.mapping.type)
			{
			case TiltInput.AxisMapping.MappingType.NamedAxis:
				this.m_SteerAxis.Update(num);
				return;
			case TiltInput.AxisMapping.MappingType.MousePositionX:
				CrossPlatformInputManager.SetVirtualMousePositionX(num * (float)Screen.width);
				return;
			case TiltInput.AxisMapping.MappingType.MousePositionY:
				CrossPlatformInputManager.SetVirtualMousePositionY(num * (float)Screen.width);
				return;
			case TiltInput.AxisMapping.MappingType.MousePositionZ:
				CrossPlatformInputManager.SetVirtualMousePositionZ(num * (float)Screen.width);
				return;
			default:
				return;
			}
		}

		// Token: 0x06002200 RID: 8704 RVA: 0x001E92CB File Offset: 0x001E74CB
		private void OnDisable()
		{
			this.m_SteerAxis.Remove();
		}

		// Token: 0x040049B2 RID: 18866
		public TiltInput.AxisMapping mapping;

		// Token: 0x040049B3 RID: 18867
		public TiltInput.AxisOptions tiltAroundAxis;

		// Token: 0x040049B4 RID: 18868
		public float fullTiltAngle = 25f;

		// Token: 0x040049B5 RID: 18869
		public float centreAngleOffset;

		// Token: 0x040049B6 RID: 18870
		private CrossPlatformInputManager.VirtualAxis m_SteerAxis;

		// Token: 0x02000686 RID: 1670
		public enum AxisOptions
		{
			// Token: 0x04004F8C RID: 20364
			ForwardAxis,
			// Token: 0x04004F8D RID: 20365
			SidewaysAxis
		}

		// Token: 0x02000687 RID: 1671
		[Serializable]
		public class AxisMapping
		{
			// Token: 0x04004F8E RID: 20366
			public TiltInput.AxisMapping.MappingType type;

			// Token: 0x04004F8F RID: 20367
			public string axisName;

			// Token: 0x020006EA RID: 1770
			public enum MappingType
			{
				// Token: 0x0400518B RID: 20875
				NamedAxis,
				// Token: 0x0400518C RID: 20876
				MousePositionX,
				// Token: 0x0400518D RID: 20877
				MousePositionY,
				// Token: 0x0400518E RID: 20878
				MousePositionZ
			}
		}
	}
}
