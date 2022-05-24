﻿using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000572 RID: 1394
	[Serializable]
	public class BloomModel : PostProcessingModel
	{
		// Token: 0x17000505 RID: 1285
		// (get) Token: 0x06002388 RID: 9096 RVA: 0x001FC9D2 File Offset: 0x001FABD2
		// (set) Token: 0x06002389 RID: 9097 RVA: 0x001FC9DA File Offset: 0x001FABDA
		public BloomModel.Settings settings
		{
			get
			{
				return this.m_Settings;
			}
			set
			{
				this.m_Settings = value;
			}
		}

		// Token: 0x0600238A RID: 9098 RVA: 0x001FC9E3 File Offset: 0x001FABE3
		public override void Reset()
		{
			this.m_Settings = BloomModel.Settings.defaultSettings;
		}

		// Token: 0x04004C14 RID: 19476
		[SerializeField]
		private BloomModel.Settings m_Settings = BloomModel.Settings.defaultSettings;

		// Token: 0x020006BE RID: 1726
		[Serializable]
		public struct BloomSettings
		{
			// Token: 0x17000592 RID: 1426
			// (get) Token: 0x06002790 RID: 10128 RVA: 0x0020AF08 File Offset: 0x00209108
			// (set) Token: 0x0600278F RID: 10127 RVA: 0x0020AEFA File Offset: 0x002090FA
			public float thresholdLinear
			{
				get
				{
					return Mathf.GammaToLinearSpace(this.threshold);
				}
				set
				{
					this.threshold = Mathf.LinearToGammaSpace(value);
				}
			}

			// Token: 0x17000593 RID: 1427
			// (get) Token: 0x06002791 RID: 10129 RVA: 0x0020AF18 File Offset: 0x00209118
			public static BloomModel.BloomSettings defaultSettings
			{
				get
				{
					return new BloomModel.BloomSettings
					{
						intensity = 0.5f,
						threshold = 1.1f,
						softKnee = 0.5f,
						radius = 4f,
						antiFlicker = false
					};
				}
			}

			// Token: 0x0400520B RID: 21003
			[Min(0f)]
			[Tooltip("Strength of the bloom filter.")]
			public float intensity;

			// Token: 0x0400520C RID: 21004
			[Min(0f)]
			[Tooltip("Filters out pixels under this level of brightness.")]
			public float threshold;

			// Token: 0x0400520D RID: 21005
			[Range(0f, 1f)]
			[Tooltip("Makes transition between under/over-threshold gradual (0 = hard threshold, 1 = soft threshold).")]
			public float softKnee;

			// Token: 0x0400520E RID: 21006
			[Range(1f, 7f)]
			[Tooltip("Changes extent of veiling effects in a screen resolution-independent fashion.")]
			public float radius;

			// Token: 0x0400520F RID: 21007
			[Tooltip("Reduces flashing noise with an additional filter.")]
			public bool antiFlicker;
		}

		// Token: 0x020006BF RID: 1727
		[Serializable]
		public struct LensDirtSettings
		{
			// Token: 0x17000594 RID: 1428
			// (get) Token: 0x06002792 RID: 10130 RVA: 0x0020AF68 File Offset: 0x00209168
			public static BloomModel.LensDirtSettings defaultSettings
			{
				get
				{
					return new BloomModel.LensDirtSettings
					{
						texture = null,
						intensity = 3f
					};
				}
			}

			// Token: 0x04005210 RID: 21008
			[Tooltip("Dirtiness texture to add smudges or dust to the lens.")]
			public Texture texture;

			// Token: 0x04005211 RID: 21009
			[Min(0f)]
			[Tooltip("Amount of lens dirtiness.")]
			public float intensity;
		}

		// Token: 0x020006C0 RID: 1728
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000595 RID: 1429
			// (get) Token: 0x06002793 RID: 10131 RVA: 0x0020AF94 File Offset: 0x00209194
			public static BloomModel.Settings defaultSettings
			{
				get
				{
					return new BloomModel.Settings
					{
						bloom = BloomModel.BloomSettings.defaultSettings,
						lensDirt = BloomModel.LensDirtSettings.defaultSettings
					};
				}
			}

			// Token: 0x04005212 RID: 21010
			public BloomModel.BloomSettings bloom;

			// Token: 0x04005213 RID: 21011
			public BloomModel.LensDirtSettings lensDirt;
		}
	}
}
