﻿using System;
using UnityEngine;

// Token: 0x020002A6 RID: 678
[Serializable]
public class CharacterSkeleton
{
	// Token: 0x1700034B RID: 843
	// (get) Token: 0x0600141C RID: 5148 RVA: 0x000C4C62 File Offset: 0x000C2E62
	public Transform Head
	{
		get
		{
			return this.head;
		}
	}

	// Token: 0x1700034C RID: 844
	// (get) Token: 0x0600141D RID: 5149 RVA: 0x000C4C6A File Offset: 0x000C2E6A
	public Transform Neck
	{
		get
		{
			return this.neck;
		}
	}

	// Token: 0x1700034D RID: 845
	// (get) Token: 0x0600141E RID: 5150 RVA: 0x000C4C72 File Offset: 0x000C2E72
	public Transform Chest
	{
		get
		{
			return this.chest;
		}
	}

	// Token: 0x1700034E RID: 846
	// (get) Token: 0x0600141F RID: 5151 RVA: 0x000C4C7A File Offset: 0x000C2E7A
	public Transform Stomach
	{
		get
		{
			return this.stomach;
		}
	}

	// Token: 0x1700034F RID: 847
	// (get) Token: 0x06001420 RID: 5152 RVA: 0x000C4C82 File Offset: 0x000C2E82
	public Transform Pelvis
	{
		get
		{
			return this.pelvis;
		}
	}

	// Token: 0x17000350 RID: 848
	// (get) Token: 0x06001421 RID: 5153 RVA: 0x000C4C8A File Offset: 0x000C2E8A
	public Transform RightShoulder
	{
		get
		{
			return this.rightShoulder;
		}
	}

	// Token: 0x17000351 RID: 849
	// (get) Token: 0x06001422 RID: 5154 RVA: 0x000C4C92 File Offset: 0x000C2E92
	public Transform LeftShoulder
	{
		get
		{
			return this.leftShoulder;
		}
	}

	// Token: 0x17000352 RID: 850
	// (get) Token: 0x06001423 RID: 5155 RVA: 0x000C4C9A File Offset: 0x000C2E9A
	public Transform RightUpperArm
	{
		get
		{
			return this.rightUpperArm;
		}
	}

	// Token: 0x17000353 RID: 851
	// (get) Token: 0x06001424 RID: 5156 RVA: 0x000C4CA2 File Offset: 0x000C2EA2
	public Transform LeftUpperArm
	{
		get
		{
			return this.leftUpperArm;
		}
	}

	// Token: 0x17000354 RID: 852
	// (get) Token: 0x06001425 RID: 5157 RVA: 0x000C4CAA File Offset: 0x000C2EAA
	public Transform RightElbow
	{
		get
		{
			return this.rightElbow;
		}
	}

	// Token: 0x17000355 RID: 853
	// (get) Token: 0x06001426 RID: 5158 RVA: 0x000C4CB2 File Offset: 0x000C2EB2
	public Transform LeftElbow
	{
		get
		{
			return this.leftElbow;
		}
	}

	// Token: 0x17000356 RID: 854
	// (get) Token: 0x06001427 RID: 5159 RVA: 0x000C4CBA File Offset: 0x000C2EBA
	public Transform RightLowerArm
	{
		get
		{
			return this.rightLowerArm;
		}
	}

	// Token: 0x17000357 RID: 855
	// (get) Token: 0x06001428 RID: 5160 RVA: 0x000C4CC2 File Offset: 0x000C2EC2
	public Transform LeftLowerArm
	{
		get
		{
			return this.leftLowerArm;
		}
	}

	// Token: 0x17000358 RID: 856
	// (get) Token: 0x06001429 RID: 5161 RVA: 0x000C4CCA File Offset: 0x000C2ECA
	public Transform RightPalm
	{
		get
		{
			return this.rightPalm;
		}
	}

	// Token: 0x17000359 RID: 857
	// (get) Token: 0x0600142A RID: 5162 RVA: 0x000C4CD2 File Offset: 0x000C2ED2
	public Transform LeftPalm
	{
		get
		{
			return this.leftPalm;
		}
	}

	// Token: 0x1700035A RID: 858
	// (get) Token: 0x0600142B RID: 5163 RVA: 0x000C4CDA File Offset: 0x000C2EDA
	public Transform RightUpperLeg
	{
		get
		{
			return this.rightUpperLeg;
		}
	}

	// Token: 0x1700035B RID: 859
	// (get) Token: 0x0600142C RID: 5164 RVA: 0x000C4CE2 File Offset: 0x000C2EE2
	public Transform LeftUpperLeg
	{
		get
		{
			return this.leftUpperLeg;
		}
	}

	// Token: 0x1700035C RID: 860
	// (get) Token: 0x0600142D RID: 5165 RVA: 0x000C4CEA File Offset: 0x000C2EEA
	public Transform RightKnee
	{
		get
		{
			return this.rightKnee;
		}
	}

	// Token: 0x1700035D RID: 861
	// (get) Token: 0x0600142E RID: 5166 RVA: 0x000C4CF2 File Offset: 0x000C2EF2
	public Transform LeftKnee
	{
		get
		{
			return this.leftKnee;
		}
	}

	// Token: 0x1700035E RID: 862
	// (get) Token: 0x0600142F RID: 5167 RVA: 0x000C4CFA File Offset: 0x000C2EFA
	public Transform RightLowerLeg
	{
		get
		{
			return this.rightLowerLeg;
		}
	}

	// Token: 0x1700035F RID: 863
	// (get) Token: 0x06001430 RID: 5168 RVA: 0x000C4D02 File Offset: 0x000C2F02
	public Transform LeftLowerLeg
	{
		get
		{
			return this.leftLowerLeg;
		}
	}

	// Token: 0x17000360 RID: 864
	// (get) Token: 0x06001431 RID: 5169 RVA: 0x000C4D0A File Offset: 0x000C2F0A
	public Transform RightFoot
	{
		get
		{
			return this.rightFoot;
		}
	}

	// Token: 0x17000361 RID: 865
	// (get) Token: 0x06001432 RID: 5170 RVA: 0x000C4D12 File Offset: 0x000C2F12
	public Transform LeftFoot
	{
		get
		{
			return this.leftFoot;
		}
	}

	// Token: 0x04001EB5 RID: 7861
	[SerializeField]
	private Transform head;

	// Token: 0x04001EB6 RID: 7862
	[SerializeField]
	private Transform neck;

	// Token: 0x04001EB7 RID: 7863
	[SerializeField]
	private Transform chest;

	// Token: 0x04001EB8 RID: 7864
	[SerializeField]
	private Transform stomach;

	// Token: 0x04001EB9 RID: 7865
	[SerializeField]
	private Transform pelvis;

	// Token: 0x04001EBA RID: 7866
	[SerializeField]
	private Transform rightShoulder;

	// Token: 0x04001EBB RID: 7867
	[SerializeField]
	private Transform leftShoulder;

	// Token: 0x04001EBC RID: 7868
	[SerializeField]
	private Transform rightUpperArm;

	// Token: 0x04001EBD RID: 7869
	[SerializeField]
	private Transform leftUpperArm;

	// Token: 0x04001EBE RID: 7870
	[SerializeField]
	private Transform rightElbow;

	// Token: 0x04001EBF RID: 7871
	[SerializeField]
	private Transform leftElbow;

	// Token: 0x04001EC0 RID: 7872
	[SerializeField]
	private Transform rightLowerArm;

	// Token: 0x04001EC1 RID: 7873
	[SerializeField]
	private Transform leftLowerArm;

	// Token: 0x04001EC2 RID: 7874
	[SerializeField]
	private Transform rightPalm;

	// Token: 0x04001EC3 RID: 7875
	[SerializeField]
	private Transform leftPalm;

	// Token: 0x04001EC4 RID: 7876
	[SerializeField]
	private Transform rightUpperLeg;

	// Token: 0x04001EC5 RID: 7877
	[SerializeField]
	private Transform leftUpperLeg;

	// Token: 0x04001EC6 RID: 7878
	[SerializeField]
	private Transform rightKnee;

	// Token: 0x04001EC7 RID: 7879
	[SerializeField]
	private Transform leftKnee;

	// Token: 0x04001EC8 RID: 7880
	[SerializeField]
	private Transform rightLowerLeg;

	// Token: 0x04001EC9 RID: 7881
	[SerializeField]
	private Transform leftLowerLeg;

	// Token: 0x04001ECA RID: 7882
	[SerializeField]
	private Transform rightFoot;

	// Token: 0x04001ECB RID: 7883
	[SerializeField]
	private Transform leftFoot;
}
