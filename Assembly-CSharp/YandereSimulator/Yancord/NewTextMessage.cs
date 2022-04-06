﻿using System;
using UnityEngine;

namespace YandereSimulator.Yancord
{
	// Token: 0x02000528 RID: 1320
	[Serializable]
	public class NewTextMessage
	{
		// Token: 0x040049E8 RID: 18920
		public string Message;

		// Token: 0x040049E9 RID: 18921
		public bool isQuestion;

		// Token: 0x040049EA RID: 18922
		public bool sentByPlayer;

		// Token: 0x040049EB RID: 18923
		public bool isSystemMessage;

		// Token: 0x040049EC RID: 18924
		[Header("== Question Related ==")]
		public string OptionQ;

		// Token: 0x040049ED RID: 18925
		public string OptionR;

		// Token: 0x040049EE RID: 18926
		public string OptionF;

		// Token: 0x040049EF RID: 18927
		[Space(20f)]
		public string ReactionQ;

		// Token: 0x040049F0 RID: 18928
		public string ReactionR;

		// Token: 0x040049F1 RID: 18929
		public string ReactionF;
	}
}
