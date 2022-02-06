﻿using System;
using UnityEngine;

// Token: 0x020002A7 RID: 679
[Serializable]
public class CharacterSkeleton
{
	// Token: 0x1700034B RID: 843
	// (get) Token: 0x06001421 RID: 5153 RVA: 0x000C54FE File Offset: 0x000C36FE
	public Transform Head
	{
		get
		{
			return this.head;
		}
	}

	// Token: 0x1700034C RID: 844
	// (get) Token: 0x06001422 RID: 5154 RVA: 0x000C5506 File Offset: 0x000C3706
	public Transform Neck
	{
		get
		{
			return this.neck;
		}
	}

	// Token: 0x1700034D RID: 845
	// (get) Token: 0x06001423 RID: 5155 RVA: 0x000C550E File Offset: 0x000C370E
	public Transform Chest
	{
		get
		{
			return this.chest;
		}
	}

	// Token: 0x1700034E RID: 846
	// (get) Token: 0x06001424 RID: 5156 RVA: 0x000C5516 File Offset: 0x000C3716
	public Transform Stomach
	{
		get
		{
			return this.stomach;
		}
	}

	// Token: 0x1700034F RID: 847
	// (get) Token: 0x06001425 RID: 5157 RVA: 0x000C551E File Offset: 0x000C371E
	public Transform Pelvis
	{
		get
		{
			return this.pelvis;
		}
	}

	// Token: 0x17000350 RID: 848
	// (get) Token: 0x06001426 RID: 5158 RVA: 0x000C5526 File Offset: 0x000C3726
	public Transform RightShoulder
	{
		get
		{
			return this.rightShoulder;
		}
	}

	// Token: 0x17000351 RID: 849
	// (get) Token: 0x06001427 RID: 5159 RVA: 0x000C552E File Offset: 0x000C372E
	public Transform LeftShoulder
	{
		get
		{
			return this.leftShoulder;
		}
	}

	// Token: 0x17000352 RID: 850
	// (get) Token: 0x06001428 RID: 5160 RVA: 0x000C5536 File Offset: 0x000C3736
	public Transform RightUpperArm
	{
		get
		{
			return this.rightUpperArm;
		}
	}

	// Token: 0x17000353 RID: 851
	// (get) Token: 0x06001429 RID: 5161 RVA: 0x000C553E File Offset: 0x000C373E
	public Transform LeftUpperArm
	{
		get
		{
			return this.leftUpperArm;
		}
	}

	// Token: 0x17000354 RID: 852
	// (get) Token: 0x0600142A RID: 5162 RVA: 0x000C5546 File Offset: 0x000C3746
	public Transform RightElbow
	{
		get
		{
			return this.rightElbow;
		}
	}

	// Token: 0x17000355 RID: 853
	// (get) Token: 0x0600142B RID: 5163 RVA: 0x000C554E File Offset: 0x000C374E
	public Transform LeftElbow
	{
		get
		{
			return this.leftElbow;
		}
	}

	// Token: 0x17000356 RID: 854
	// (get) Token: 0x0600142C RID: 5164 RVA: 0x000C5556 File Offset: 0x000C3756
	public Transform RightLowerArm
	{
		get
		{
			return this.rightLowerArm;
		}
	}

	// Token: 0x17000357 RID: 855
	// (get) Token: 0x0600142D RID: 5165 RVA: 0x000C555E File Offset: 0x000C375E
	public Transform LeftLowerArm
	{
		get
		{
			return this.leftLowerArm;
		}
	}

	// Token: 0x17000358 RID: 856
	// (get) Token: 0x0600142E RID: 5166 RVA: 0x000C5566 File Offset: 0x000C3766
	public Transform RightPalm
	{
		get
		{
			return this.rightPalm;
		}
	}

	// Token: 0x17000359 RID: 857
	// (get) Token: 0x0600142F RID: 5167 RVA: 0x000C556E File Offset: 0x000C376E
	public Transform LeftPalm
	{
		get
		{
			return this.leftPalm;
		}
	}

	// Token: 0x1700035A RID: 858
	// (get) Token: 0x06001430 RID: 5168 RVA: 0x000C5576 File Offset: 0x000C3776
	public Transform RightUpperLeg
	{
		get
		{
			return this.rightUpperLeg;
		}
	}

	// Token: 0x1700035B RID: 859
	// (get) Token: 0x06001431 RID: 5169 RVA: 0x000C557E File Offset: 0x000C377E
	public Transform LeftUpperLeg
	{
		get
		{
			return this.leftUpperLeg;
		}
	}

	// Token: 0x1700035C RID: 860
	// (get) Token: 0x06001432 RID: 5170 RVA: 0x000C5586 File Offset: 0x000C3786
	public Transform RightKnee
	{
		get
		{
			return this.rightKnee;
		}
	}

	// Token: 0x1700035D RID: 861
	// (get) Token: 0x06001433 RID: 5171 RVA: 0x000C558E File Offset: 0x000C378E
	public Transform LeftKnee
	{
		get
		{
			return this.leftKnee;
		}
	}

	// Token: 0x1700035E RID: 862
	// (get) Token: 0x06001434 RID: 5172 RVA: 0x000C5596 File Offset: 0x000C3796
	public Transform RightLowerLeg
	{
		get
		{
			return this.rightLowerLeg;
		}
	}

	// Token: 0x1700035F RID: 863
	// (get) Token: 0x06001435 RID: 5173 RVA: 0x000C559E File Offset: 0x000C379E
	public Transform LeftLowerLeg
	{
		get
		{
			return this.leftLowerLeg;
		}
	}

	// Token: 0x17000360 RID: 864
	// (get) Token: 0x06001436 RID: 5174 RVA: 0x000C55A6 File Offset: 0x000C37A6
	public Transform RightFoot
	{
		get
		{
			return this.rightFoot;
		}
	}

	// Token: 0x17000361 RID: 865
	// (get) Token: 0x06001437 RID: 5175 RVA: 0x000C55AE File Offset: 0x000C37AE
	public Transform LeftFoot
	{
		get
		{
			return this.leftFoot;
		}
	}

	// Token: 0x04001EC3 RID: 7875
	[SerializeField]
	private Transform head;

	// Token: 0x04001EC4 RID: 7876
	[SerializeField]
	private Transform neck;

	// Token: 0x04001EC5 RID: 7877
	[SerializeField]
	private Transform chest;

	// Token: 0x04001EC6 RID: 7878
	[SerializeField]
	private Transform stomach;

	// Token: 0x04001EC7 RID: 7879
	[SerializeField]
	private Transform pelvis;

	// Token: 0x04001EC8 RID: 7880
	[SerializeField]
	private Transform rightShoulder;

	// Token: 0x04001EC9 RID: 7881
	[SerializeField]
	private Transform leftShoulder;

	// Token: 0x04001ECA RID: 7882
	[SerializeField]
	private Transform rightUpperArm;

	// Token: 0x04001ECB RID: 7883
	[SerializeField]
	private Transform leftUpperArm;

	// Token: 0x04001ECC RID: 7884
	[SerializeField]
	private Transform rightElbow;

	// Token: 0x04001ECD RID: 7885
	[SerializeField]
	private Transform leftElbow;

	// Token: 0x04001ECE RID: 7886
	[SerializeField]
	private Transform rightLowerArm;

	// Token: 0x04001ECF RID: 7887
	[SerializeField]
	private Transform leftLowerArm;

	// Token: 0x04001ED0 RID: 7888
	[SerializeField]
	private Transform rightPalm;

	// Token: 0x04001ED1 RID: 7889
	[SerializeField]
	private Transform leftPalm;

	// Token: 0x04001ED2 RID: 7890
	[SerializeField]
	private Transform rightUpperLeg;

	// Token: 0x04001ED3 RID: 7891
	[SerializeField]
	private Transform leftUpperLeg;

	// Token: 0x04001ED4 RID: 7892
	[SerializeField]
	private Transform rightKnee;

	// Token: 0x04001ED5 RID: 7893
	[SerializeField]
	private Transform leftKnee;

	// Token: 0x04001ED6 RID: 7894
	[SerializeField]
	private Transform rightLowerLeg;

	// Token: 0x04001ED7 RID: 7895
	[SerializeField]
	private Transform leftLowerLeg;

	// Token: 0x04001ED8 RID: 7896
	[SerializeField]
	private Transform rightFoot;

	// Token: 0x04001ED9 RID: 7897
	[SerializeField]
	private Transform leftFoot;
}
