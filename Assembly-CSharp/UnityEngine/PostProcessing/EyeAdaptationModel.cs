﻿using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000569 RID: 1385
	[Serializable]
	public class EyeAdaptationModel : PostProcessingModel
	{
		// Token: 0x17000509 RID: 1289
		// (get) Token: 0x06002342 RID: 9026 RVA: 0x001F365E File Offset: 0x001F185E
		// (set) Token: 0x06002343 RID: 9027 RVA: 0x001F3666 File Offset: 0x001F1866
		public EyeAdaptationModel.Settings settings
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

		// Token: 0x06002344 RID: 9028 RVA: 0x001F366F File Offset: 0x001F186F
		public override void Reset()
		{
			this.m_Settings = EyeAdaptationModel.Settings.defaultSettings;
		}

		// Token: 0x04004AF6 RID: 19190
		[SerializeField]
		private EyeAdaptationModel.Settings m_Settings = EyeAdaptationModel.Settings.defaultSettings;

		// Token: 0x020006C2 RID: 1730
		public enum EyeAdaptationType
		{
			// Token: 0x04005136 RID: 20790
			Progressive,
			// Token: 0x04005137 RID: 20791
			Fixed
		}

		// Token: 0x020006C3 RID: 1731
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059D RID: 1437
			// (get) Token: 0x06002734 RID: 10036 RVA: 0x00201D68 File Offset: 0x001FFF68
			public static EyeAdaptationModel.Settings defaultSettings
			{
				get
				{
					return new EyeAdaptationModel.Settings
					{
						lowPercent = 45f,
						highPercent = 95f,
						minLuminance = -5f,
						maxLuminance = 1f,
						keyValue = 0.25f,
						dynamicKeyValue = true,
						adaptationType = EyeAdaptationModel.EyeAdaptationType.Progressive,
						speedUp = 2f,
						speedDown = 1f,
						logMin = -8,
						logMax = 4
					};
				}
			}

			// Token: 0x04005138 RID: 20792
			[Range(1f, 99f)]
			[Tooltip("Filters the dark part of the histogram when computing the average luminance to avoid very dark pixels from contributing to the auto exposure. Unit is in percent.")]
			public float lowPercent;

			// Token: 0x04005139 RID: 20793
			[Range(1f, 99f)]
			[Tooltip("Filters the bright part of the histogram when computing the average luminance to avoid very dark pixels from contributing to the auto exposure. Unit is in percent.")]
			public float highPercent;

			// Token: 0x0400513A RID: 20794
			[Tooltip("Minimum average luminance to consider for auto exposure (in EV).")]
			public float minLuminance;

			// Token: 0x0400513B RID: 20795
			[Tooltip("Maximum average luminance to consider for auto exposure (in EV).")]
			public float maxLuminance;

			// Token: 0x0400513C RID: 20796
			[Min(0f)]
			[Tooltip("Exposure bias. Use this to offset the global exposure of the scene.")]
			public float keyValue;

			// Token: 0x0400513D RID: 20797
			[Tooltip("Set this to true to let Unity handle the key value automatically based on average luminance.")]
			public bool dynamicKeyValue;

			// Token: 0x0400513E RID: 20798
			[Tooltip("Use \"Progressive\" if you want the auto exposure to be animated. Use \"Fixed\" otherwise.")]
			public EyeAdaptationModel.EyeAdaptationType adaptationType;

			// Token: 0x0400513F RID: 20799
			[Min(0f)]
			[Tooltip("Adaptation speed from a dark to a light environment.")]
			public float speedUp;

			// Token: 0x04005140 RID: 20800
			[Min(0f)]
			[Tooltip("Adaptation speed from a light to a dark environment.")]
			public float speedDown;

			// Token: 0x04005141 RID: 20801
			[Range(-16f, -1f)]
			[Tooltip("Lower bound for the brightness range of the generated histogram (in EV). The bigger the spread between min & max, the lower the precision will be.")]
			public int logMin;

			// Token: 0x04005142 RID: 20802
			[Range(1f, 16f)]
			[Tooltip("Upper bound for the brightness range of the generated histogram (in EV). The bigger the spread between min & max, the lower the precision will be.")]
			public int logMax;
		}
	}
}
