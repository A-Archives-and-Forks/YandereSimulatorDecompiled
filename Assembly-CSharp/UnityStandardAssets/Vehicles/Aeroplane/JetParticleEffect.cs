﻿using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052F RID: 1327
	[RequireComponent(typeof(ParticleSystem))]
	public class JetParticleEffect : MonoBehaviour
	{
		// Token: 0x060021D0 RID: 8656 RVA: 0x001EA02C File Offset: 0x001E822C
		private void Start()
		{
			this.m_Jet = this.FindAeroplaneParent();
			this.m_System = base.GetComponent<ParticleSystem>();
			this.m_OriginalLifetime = this.m_System.main.startLifetime.constant;
			this.m_OriginalStartSize = this.m_System.main.startSize.constant;
			this.m_OriginalStartColor = this.m_System.main.startColor.color;
		}

		// Token: 0x060021D1 RID: 8657 RVA: 0x001EA0B4 File Offset: 0x001E82B4
		private void Update()
		{
			ParticleSystem.MainModule main = this.m_System.main;
			main.startLifetime = Mathf.Lerp(0f, this.m_OriginalLifetime, this.m_Jet.Throttle);
			main.startSize = Mathf.Lerp(this.m_OriginalStartSize * 0.3f, this.m_OriginalStartSize, this.m_Jet.Throttle);
			main.startColor = Color.Lerp(this.minColour, this.m_OriginalStartColor, this.m_Jet.Throttle);
		}

		// Token: 0x060021D2 RID: 8658 RVA: 0x001EA14C File Offset: 0x001E834C
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

		// Token: 0x040049D1 RID: 18897
		public Color minColour;

		// Token: 0x040049D2 RID: 18898
		private AeroplaneController m_Jet;

		// Token: 0x040049D3 RID: 18899
		private ParticleSystem m_System;

		// Token: 0x040049D4 RID: 18900
		private float m_OriginalStartSize;

		// Token: 0x040049D5 RID: 18901
		private float m_OriginalLifetime;

		// Token: 0x040049D6 RID: 18902
		private Color m_OriginalStartColor;
	}
}
