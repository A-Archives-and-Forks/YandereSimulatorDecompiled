﻿using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000532 RID: 1330
	[RequireComponent(typeof(ParticleSystem))]
	public class JetParticleEffect : MonoBehaviour
	{
		// Token: 0x060021E6 RID: 8678 RVA: 0x001EC844 File Offset: 0x001EAA44
		private void Start()
		{
			this.m_Jet = this.FindAeroplaneParent();
			this.m_System = base.GetComponent<ParticleSystem>();
			this.m_OriginalLifetime = this.m_System.main.startLifetime.constant;
			this.m_OriginalStartSize = this.m_System.main.startSize.constant;
			this.m_OriginalStartColor = this.m_System.main.startColor.color;
		}

		// Token: 0x060021E7 RID: 8679 RVA: 0x001EC8CC File Offset: 0x001EAACC
		private void Update()
		{
			ParticleSystem.MainModule main = this.m_System.main;
			main.startLifetime = Mathf.Lerp(0f, this.m_OriginalLifetime, this.m_Jet.Throttle);
			main.startSize = Mathf.Lerp(this.m_OriginalStartSize * 0.3f, this.m_OriginalStartSize, this.m_Jet.Throttle);
			main.startColor = Color.Lerp(this.minColour, this.m_OriginalStartColor, this.m_Jet.Throttle);
		}

		// Token: 0x060021E8 RID: 8680 RVA: 0x001EC964 File Offset: 0x001EAB64
		private AeroplaneController FindAeroplaneParent()
		{
			Transform transform = base.transform;
			while (transform != null)
			{
				AeroplaneController component = transform.GetComponent<AeroplaneController>();
				if (!(component == null))
				{
					return component;
				}
				transform = transform.parent;
			}
			throw new Exception(" AeroplaneContoller not found in object hierarchy");
		}

		// Token: 0x04004A06 RID: 18950
		public Color minColour;

		// Token: 0x04004A07 RID: 18951
		private AeroplaneController m_Jet;

		// Token: 0x04004A08 RID: 18952
		private ParticleSystem m_System;

		// Token: 0x04004A09 RID: 18953
		private float m_OriginalStartSize;

		// Token: 0x04004A0A RID: 18954
		private float m_OriginalLifetime;

		// Token: 0x04004A0B RID: 18955
		private Color m_OriginalStartColor;
	}
}
