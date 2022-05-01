﻿using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000571 RID: 1393
	[Serializable]
	public class BloomModel : PostProcessingModel
	{
		// Token: 0x17000504 RID: 1284
		// (get) Token: 0x0600237C RID: 9084 RVA: 0x001FAD1E File Offset: 0x001F8F1E
		// (set) Token: 0x0600237D RID: 9085 RVA: 0x001FAD26 File Offset: 0x001F8F26
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

		// Token: 0x0600237E RID: 9086 RVA: 0x001FAD2F File Offset: 0x001F8F2F
		public override void Reset()
		{
			this.m_Settings = BloomModel.Settings.defaultSettings;
		}

		// Token: 0x04004BE4 RID: 19428
		[SerializeField]
		private BloomModel.Settings m_Settings = BloomModel.Settings.defaultSettings;

		// Token: 0x020006BD RID: 1725
		[Serializable]
		public struct BloomSettings
		{
			// Token: 0x17000591 RID: 1425
			// (get) Token: 0x06002784 RID: 10116 RVA: 0x0020922C File Offset: 0x0020742C
			// (set) Token: 0x06002783 RID: 10115 RVA: 0x0020921E File Offset: 0x0020741E
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

			// Token: 0x17000592 RID: 1426
			// (get) Token: 0x06002785 RID: 10117 RVA: 0x0020923C File Offset: 0x0020743C
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

			// Token: 0x040051DB RID: 20955
			[Min(0f)]
			[Tooltip("Strength of the bloom filter.")]
			public float intensity;

			// Token: 0x040051DC RID: 20956
			[Min(0f)]
			[Tooltip("Filters out pixels under this level of brightness.")]
			public float threshold;

			// Token: 0x040051DD RID: 20957
			[Range(0f, 1f)]
			[Tooltip("Makes transition between under/over-threshold gradual (0 = hard threshold, 1 = soft threshold).")]
			public float softKnee;

			// Token: 0x040051DE RID: 20958
			[Range(1f, 7f)]
			[Tooltip("Changes extent of veiling effects in a screen resolution-independent fashion.")]
			public float radius;

			// Token: 0x040051DF RID: 20959
			[Tooltip("Reduces flashing noise with an additional filter.")]
			public bool antiFlicker;
		}

		// Token: 0x020006BE RID: 1726
		[Serializable]
		public struct LensDirtSettings
		{
			// Token: 0x17000593 RID: 1427
			// (get) Token: 0x06002786 RID: 10118 RVA: 0x0020928C File Offset: 0x0020748C
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

			// Token: 0x040051E0 RID: 20960
			[Tooltip("Dirtiness texture to add smudges or dust to the lens.")]
			public Texture texture;

			// Token: 0x040051E1 RID: 20961
			[Min(0f)]
			[Tooltip("Amount of lens dirtiness.")]
			public float intensity;
		}

		// Token: 0x020006BF RID: 1727
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000594 RID: 1428
			// (get) Token: 0x06002787 RID: 10119 RVA: 0x002092B8 File Offset: 0x002074B8
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

			// Token: 0x040051E2 RID: 20962
			public BloomModel.BloomSettings bloom;

			// Token: 0x040051E3 RID: 20963
			public BloomModel.LensDirtSettings lensDirt;
		}
	}
}
