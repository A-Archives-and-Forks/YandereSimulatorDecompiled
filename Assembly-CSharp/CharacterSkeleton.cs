﻿using System;
using UnityEngine;

// Token: 0x020002A9 RID: 681
[Serializable]
public class CharacterSkeleton
{
	// Token: 0x1700034B RID: 843
	// (get) Token: 0x06001432 RID: 5170 RVA: 0x000C6492 File Offset: 0x000C4692
	public Transform Head
	{
		get
		{
			return this.head;
		}
	}

	// Token: 0x1700034C RID: 844
	// (get) Token: 0x06001433 RID: 5171 RVA: 0x000C649A File Offset: 0x000C469A
	public Transform Neck
	{
		get
		{
			return this.neck;
		}
	}

	// Token: 0x1700034D RID: 845
	// (get) Token: 0x06001434 RID: 5172 RVA: 0x000C64A2 File Offset: 0x000C46A2
	public Transform Chest
	{
		get
		{
			return this.chest;
		}
	}

	// Token: 0x1700034E RID: 846
	// (get) Token: 0x06001435 RID: 5173 RVA: 0x000C64AA File Offset: 0x000C46AA
	public Transform Stomach
	{
		get
		{
			return this.stomach;
		}
	}

	// Token: 0x1700034F RID: 847
	// (get) Token: 0x06001436 RID: 5174 RVA: 0x000C64B2 File Offset: 0x000C46B2
	public Transform Pelvis
	{
		get
		{
			return this.pelvis;
		}
	}

	// Token: 0x17000350 RID: 848
	// (get) Token: 0x06001437 RID: 5175 RVA: 0x000C64BA File Offset: 0x000C46BA
	public Transform RightShoulder
	{
		get
		{
			return this.rightShoulder;
		}
	}

	// Token: 0x17000351 RID: 849
	// (get) Token: 0x06001438 RID: 5176 RVA: 0x000C64C2 File Offset: 0x000C46C2
	public Transform LeftShoulder
	{
		get
		{
			return this.leftShoulder;
		}
	}

	// Token: 0x17000352 RID: 850
	// (get) Token: 0x06001439 RID: 5177 RVA: 0x000C64CA File Offset: 0x000C46CA
	public Transform RightUpperArm
	{
		get
		{
			return this.rightUpperArm;
		}
	}

	// Token: 0x17000353 RID: 851
	// (get) Token: 0x0600143A RID: 5178 RVA: 0x000C64D2 File Offset: 0x000C46D2
	public Transform LeftUpperArm
	{
		get
		{
			return this.leftUpperArm;
		}
	}

	// Token: 0x17000354 RID: 852
	// (get) Token: 0x0600143B RID: 5179 RVA: 0x000C64DA File Offset: 0x000C46DA
	public Transform RightElbow
	{
		get
		{
			return this.rightElbow;
		}
	}

	// Token: 0x17000355 RID: 853
	// (get) Token: 0x0600143C RID: 5180 RVA: 0x000C64E2 File Offset: 0x000C46E2
	public Transform LeftElbow
	{
		get
		{
			return this.leftElbow;
		}
	}

	// Token: 0x17000356 RID: 854
	// (get) Token: 0x0600143D RID: 5181 RVA: 0x000C64EA File Offset: 0x000C46EA
	public Transform RightLowerArm
	{
		get
		{
			return this.rightLowerArm;
		}
	}

	// Token: 0x17000357 RID: 855
	// (get) Token: 0x0600143E RID: 5182 RVA: 0x000C64F2 File Offset: 0x000C46F2
	public Transform LeftLowerArm
	{
		get
		{
			return this.leftLowerArm;
		}
	}

	// Token: 0x17000358 RID: 856
	// (get) Token: 0x0600143F RID: 5183 RVA: 0x000C64FA File Offset: 0x000C46FA
	public Transform RightPalm
	{
		get
		{
			return this.rightPalm;
		}
	}

	// Token: 0x17000359 RID: 857
	// (get) Token: 0x06001440 RID: 5184 RVA: 0x000C6502 File Offset: 0x000C4702
	public Transform LeftPalm
	{
		get
		{
			return this.leftPalm;
		}
	}

	// Token: 0x1700035A RID: 858
	// (get) Token: 0x06001441 RID: 5185 RVA: 0x000C650A File Offset: 0x000C470A
	public Transform RightUpperLeg
	{
		get
		{
			return this.rightUpperLeg;
		}
	}

	// Token: 0x1700035B RID: 859
	// (get) Token: 0x06001442 RID: 5186 RVA: 0x000C6512 File Offset: 0x000C4712
	public Transform LeftUpperLeg
	{
		get
		{
			return this.leftUpperLeg;
		}
	}

	// Token: 0x1700035C RID: 860
	// (get) Token: 0x06001443 RID: 5187 RVA: 0x000C651A File Offset: 0x000C471A
	public Transform RightKnee
	{
		get
		{
			return this.rightKnee;
		}
	}

	// Token: 0x1700035D RID: 861
	// (get) Token: 0x06001444 RID: 5188 RVA: 0x000C6522 File Offset: 0x000C4722
	public Transform LeftKnee
	{
		get
		{
			return this.leftKnee;
		}
	}

	// Token: 0x1700035E RID: 862
	// (get) Token: 0x06001445 RID: 5189 RVA: 0x000C652A File Offset: 0x000C472A
	public Transform RightLowerLeg
	{
		get
		{
			return this.rightLowerLeg;
		}
	}

	// Token: 0x1700035F RID: 863
	// (get) Token: 0x06001446 RID: 5190 RVA: 0x000C6532 File Offset: 0x000C4732
	public Transform LeftLowerLeg
	{
		get
		{
			return this.leftLowerLeg;
		}
	}

	// Token: 0x17000360 RID: 864
	// (get) Token: 0x06001447 RID: 5191 RVA: 0x000C653A File Offset: 0x000C473A
	public Transform RightFoot
	{
		get
		{
			return this.rightFoot;
		}
	}

	// Token: 0x17000361 RID: 865
	// (get) Token: 0x06001448 RID: 5192 RVA: 0x000C6542 File Offset: 0x000C4742
	public Transform LeftFoot
	{
		get
		{
			return this.leftFoot;
		}
	}

	// Token: 0x04001EF0 RID: 7920
	[SerializeField]
	private Transform head;

	// Token: 0x04001EF1 RID: 7921
	[SerializeField]
	private Transform neck;

	// Token: 0x04001EF2 RID: 7922
	[SerializeField]
	private Transform chest;

	// Token: 0x04001EF3 RID: 7923
	[SerializeField]
	private Transform stomach;

	// Token: 0x04001EF4 RID: 7924
	[SerializeField]
	private Transform pelvis;

	// Token: 0x04001EF5 RID: 7925
	[SerializeField]
	private Transform rightShoulder;

	// Token: 0x04001EF6 RID: 7926
	[SerializeField]
	private Transform leftShoulder;

	// Token: 0x04001EF7 RID: 7927
	[SerializeField]
	private Transform rightUpperArm;

	// Token: 0x04001EF8 RID: 7928
	[SerializeField]
	private Transform leftUpperArm;

	// Token: 0x04001EF9 RID: 7929
	[SerializeField]
	private Transform rightElbow;

	// Token: 0x04001EFA RID: 7930
	[SerializeField]
	private Transform leftElbow;

	// Token: 0x04001EFB RID: 7931
	[SerializeField]
	private Transform rightLowerArm;

	// Token: 0x04001EFC RID: 7932
	[SerializeField]
	private Transform leftLowerArm;

	// Token: 0x04001EFD RID: 7933
	[SerializeField]
	private Transform rightPalm;

	// Token: 0x04001EFE RID: 7934
	[SerializeField]
	private Transform leftPalm;

	// Token: 0x04001EFF RID: 7935
	[SerializeField]
	private Transform rightUpperLeg;

	// Token: 0x04001F00 RID: 7936
	[SerializeField]
	private Transform leftUpperLeg;

	// Token: 0x04001F01 RID: 7937
	[SerializeField]
	private Transform rightKnee;

	// Token: 0x04001F02 RID: 7938
	[SerializeField]
	private Transform leftKnee;

	// Token: 0x04001F03 RID: 7939
	[SerializeField]
	private Transform rightLowerLeg;

	// Token: 0x04001F04 RID: 7940
	[SerializeField]
	private Transform leftLowerLeg;

	// Token: 0x04001F05 RID: 7941
	[SerializeField]
	private Transform rightFoot;

	// Token: 0x04001F06 RID: 7942
	[SerializeField]
	private Transform leftFoot;
}
