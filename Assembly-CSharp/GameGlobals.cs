﻿using System;
using UnityEngine;

// Token: 0x020002F4 RID: 756
public static class GameGlobals
{
	// Token: 0x17000397 RID: 919
	// (get) Token: 0x060015D6 RID: 5590 RVA: 0x000DC60B File Offset: 0x000DA80B
	// (set) Token: 0x060015D7 RID: 5591 RVA: 0x000DC617 File Offset: 0x000DA817
	public static int Profile
	{
		get
		{
			return PlayerPrefs.GetInt("Profile");
		}
		set
		{
			PlayerPrefs.SetInt("Profile", value);
		}
	}

	// Token: 0x17000398 RID: 920
	// (get) Token: 0x060015D8 RID: 5592 RVA: 0x000DC624 File Offset: 0x000DA824
	// (set) Token: 0x060015D9 RID: 5593 RVA: 0x000DC630 File Offset: 0x000DA830
	public static int MostRecentSlot
	{
		get
		{
			return PlayerPrefs.GetInt("MostRecentSlot");
		}
		set
		{
			PlayerPrefs.SetInt("MostRecentSlot", value);
		}
	}

	// Token: 0x17000399 RID: 921
	// (get) Token: 0x060015DA RID: 5594 RVA: 0x000DC640 File Offset: 0x000DA840
	// (set) Token: 0x060015DB RID: 5595 RVA: 0x000DC670 File Offset: 0x000DA870
	public static bool LoveSick
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_LoveSick");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_LoveSick", value);
		}
	}

	// Token: 0x1700039A RID: 922
	// (get) Token: 0x060015DC RID: 5596 RVA: 0x000DC6A0 File Offset: 0x000DA8A0
	// (set) Token: 0x060015DD RID: 5597 RVA: 0x000DC6D0 File Offset: 0x000DA8D0
	public static bool MasksBanned
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_MasksBanned");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_MasksBanned", value);
		}
	}

	// Token: 0x1700039B RID: 923
	// (get) Token: 0x060015DE RID: 5598 RVA: 0x000DC700 File Offset: 0x000DA900
	// (set) Token: 0x060015DF RID: 5599 RVA: 0x000DC730 File Offset: 0x000DA930
	public static bool Paranormal
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_Paranormal");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_Paranormal", value);
		}
	}

	// Token: 0x1700039C RID: 924
	// (get) Token: 0x060015E0 RID: 5600 RVA: 0x000DC760 File Offset: 0x000DA960
	// (set) Token: 0x060015E1 RID: 5601 RVA: 0x000DC790 File Offset: 0x000DA990
	public static bool EasyMode
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_EasyMode");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_EasyMode", value);
		}
	}

	// Token: 0x1700039D RID: 925
	// (get) Token: 0x060015E2 RID: 5602 RVA: 0x000DC7C0 File Offset: 0x000DA9C0
	// (set) Token: 0x060015E3 RID: 5603 RVA: 0x000DC7F0 File Offset: 0x000DA9F0
	public static bool HardMode
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_HardMode");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_HardMode", value);
		}
	}

	// Token: 0x1700039E RID: 926
	// (get) Token: 0x060015E4 RID: 5604 RVA: 0x000DC820 File Offset: 0x000DAA20
	// (set) Token: 0x060015E5 RID: 5605 RVA: 0x000DC850 File Offset: 0x000DAA50
	public static bool EmptyDemon
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_EmptyDemon");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_EmptyDemon", value);
		}
	}

	// Token: 0x1700039F RID: 927
	// (get) Token: 0x060015E6 RID: 5606 RVA: 0x000DC87F File Offset: 0x000DAA7F
	// (set) Token: 0x060015E7 RID: 5607 RVA: 0x000DC88B File Offset: 0x000DAA8B
	public static bool CensorBlood
	{
		get
		{
			return GlobalsHelper.GetBool("Profile__CensorBlood");
		}
		set
		{
			GlobalsHelper.SetBool("Profile__CensorBlood", value);
		}
	}

	// Token: 0x170003A0 RID: 928
	// (get) Token: 0x060015E8 RID: 5608 RVA: 0x000DC898 File Offset: 0x000DAA98
	// (set) Token: 0x060015E9 RID: 5609 RVA: 0x000DC8A4 File Offset: 0x000DAAA4
	public static bool CensorPanties
	{
		get
		{
			return GlobalsHelper.GetBool("Profile__CensorPanties");
		}
		set
		{
			GlobalsHelper.SetBool("Profile__CensorPanties", value);
		}
	}

	// Token: 0x170003A1 RID: 929
	// (get) Token: 0x060015EA RID: 5610 RVA: 0x000DC8B1 File Offset: 0x000DAAB1
	// (set) Token: 0x060015EB RID: 5611 RVA: 0x000DC8BD File Offset: 0x000DAABD
	public static bool CensorKillingAnims
	{
		get
		{
			return GlobalsHelper.GetBool("Profile__CensorKillingAnims");
		}
		set
		{
			GlobalsHelper.SetBool("Profile__CensorKillingAnims", value);
		}
	}

	// Token: 0x170003A2 RID: 930
	// (get) Token: 0x060015EC RID: 5612 RVA: 0x000DC8CC File Offset: 0x000DAACC
	// (set) Token: 0x060015ED RID: 5613 RVA: 0x000DC8FC File Offset: 0x000DAAFC
	public static bool SpareUniform
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SpareUniform");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SpareUniform", value);
		}
	}

	// Token: 0x170003A3 RID: 931
	// (get) Token: 0x060015EE RID: 5614 RVA: 0x000DC92C File Offset: 0x000DAB2C
	// (set) Token: 0x060015EF RID: 5615 RVA: 0x000DC95C File Offset: 0x000DAB5C
	public static bool BlondeHair
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BlondeHair");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BlondeHair", value);
		}
	}

	// Token: 0x170003A4 RID: 932
	// (get) Token: 0x060015F0 RID: 5616 RVA: 0x000DC98C File Offset: 0x000DAB8C
	// (set) Token: 0x060015F1 RID: 5617 RVA: 0x000DC9BC File Offset: 0x000DABBC
	public static bool SenpaiMourning
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiMourning");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiMourning", value);
		}
	}

	// Token: 0x170003A5 RID: 933
	// (get) Token: 0x060015F2 RID: 5618 RVA: 0x000DC9EC File Offset: 0x000DABEC
	// (set) Token: 0x060015F3 RID: 5619 RVA: 0x000DCA1C File Offset: 0x000DAC1C
	public static int RivalEliminationID
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminationID");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminationID", value);
		}
	}

	// Token: 0x170003A6 RID: 934
	// (get) Token: 0x060015F4 RID: 5620 RVA: 0x000DCA4C File Offset: 0x000DAC4C
	// (set) Token: 0x060015F5 RID: 5621 RVA: 0x000DCA7C File Offset: 0x000DAC7C
	public static int SpecificEliminationID
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminationID");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminationID", value);
		}
	}

	// Token: 0x170003A7 RID: 935
	// (get) Token: 0x060015F6 RID: 5622 RVA: 0x000DCAAB File Offset: 0x000DACAB
	// (set) Token: 0x060015F7 RID: 5623 RVA: 0x000DCAB7 File Offset: 0x000DACB7
	public static bool NonlethalElimination
	{
		get
		{
			return GlobalsHelper.GetBool("NonlethalElimination");
		}
		set
		{
			GlobalsHelper.SetBool("NonlethalElimination", value);
		}
	}

	// Token: 0x170003A8 RID: 936
	// (get) Token: 0x060015F8 RID: 5624 RVA: 0x000DCAC4 File Offset: 0x000DACC4
	// (set) Token: 0x060015F9 RID: 5625 RVA: 0x000DCAF4 File Offset: 0x000DACF4
	public static bool ReputationsInitialized
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReputationsInitialized");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReputationsInitialized", value);
		}
	}

	// Token: 0x170003A9 RID: 937
	// (get) Token: 0x060015FA RID: 5626 RVA: 0x000DCB24 File Offset: 0x000DAD24
	// (set) Token: 0x060015FB RID: 5627 RVA: 0x000DCB54 File Offset: 0x000DAD54
	public static bool AnswerSheetUnavailable
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_AnswerSheetUnavailable");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_AnswerSheetUnavailable", value);
		}
	}

	// Token: 0x170003AA RID: 938
	// (get) Token: 0x060015FC RID: 5628 RVA: 0x000DCB84 File Offset: 0x000DAD84
	// (set) Token: 0x060015FD RID: 5629 RVA: 0x000DCBB4 File Offset: 0x000DADB4
	public static bool AlphabetMode
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_AlphabetMode");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_AlphabetMode", value);
		}
	}

	// Token: 0x170003AB RID: 939
	// (get) Token: 0x060015FE RID: 5630 RVA: 0x000DCBE4 File Offset: 0x000DADE4
	// (set) Token: 0x060015FF RID: 5631 RVA: 0x000DCC14 File Offset: 0x000DAE14
	public static bool PoliceYesterday
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_PoliceYesterday");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_PoliceYesterday", value);
		}
	}

	// Token: 0x170003AC RID: 940
	// (get) Token: 0x06001600 RID: 5632 RVA: 0x000DCC44 File Offset: 0x000DAE44
	// (set) Token: 0x06001601 RID: 5633 RVA: 0x000DCC74 File Offset: 0x000DAE74
	public static bool DarkEnding
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_DarkEnding");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_DarkEnding", value);
		}
	}

	// Token: 0x170003AD RID: 941
	// (get) Token: 0x06001602 RID: 5634 RVA: 0x000DCCA4 File Offset: 0x000DAEA4
	// (set) Token: 0x06001603 RID: 5635 RVA: 0x000DCCD4 File Offset: 0x000DAED4
	public static bool SenpaiSawOsanaCorpse
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiSawOsanaCorpse");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiSawOsanaCorpse", value);
		}
	}

	// Token: 0x170003AE RID: 942
	// (get) Token: 0x06001604 RID: 5636 RVA: 0x000DCD04 File Offset: 0x000DAF04
	// (set) Token: 0x06001605 RID: 5637 RVA: 0x000DCD34 File Offset: 0x000DAF34
	public static bool TransitionToPostCredits
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TransitionToPostCredits");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TransitionToPostCredits", value);
		}
	}

	// Token: 0x170003AF RID: 943
	// (get) Token: 0x06001606 RID: 5638 RVA: 0x000DCD64 File Offset: 0x000DAF64
	// (set) Token: 0x06001607 RID: 5639 RVA: 0x000DCD94 File Offset: 0x000DAF94
	public static bool PlayerHasBeatenDemo
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_PlayerHasBeatenDemo");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_PlayerHasBeatenDemo", value);
		}
	}

	// Token: 0x170003B0 RID: 944
	// (get) Token: 0x06001608 RID: 5640 RVA: 0x000DCDC4 File Offset: 0x000DAFC4
	// (set) Token: 0x06001609 RID: 5641 RVA: 0x000DCDF4 File Offset: 0x000DAFF4
	public static bool InformedAboutSkipping
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_InformedAboutSkipping");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_InformedAboutSkipping", value);
		}
	}

	// Token: 0x170003B1 RID: 945
	// (get) Token: 0x0600160A RID: 5642 RVA: 0x000DCE24 File Offset: 0x000DB024
	// (set) Token: 0x0600160B RID: 5643 RVA: 0x000DCE54 File Offset: 0x000DB054
	public static bool RingStolen
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_RingStolen");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_RingStolen", value);
		}
	}

	// Token: 0x170003B2 RID: 946
	// (get) Token: 0x0600160C RID: 5644 RVA: 0x000DCE84 File Offset: 0x000DB084
	// (set) Token: 0x0600160D RID: 5645 RVA: 0x000DCEB4 File Offset: 0x000DB0B4
	public static int BeatEmUpDifficulty
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BeatEmUpDifficulty");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BeatEmUpDifficulty", value);
		}
	}

	// Token: 0x170003B3 RID: 947
	// (get) Token: 0x0600160E RID: 5646 RVA: 0x000DCEE4 File Offset: 0x000DB0E4
	// (set) Token: 0x0600160F RID: 5647 RVA: 0x000DCF14 File Offset: 0x000DB114
	public static bool BeatEmUpSuccess
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BeatEmUpSuccess");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BeatEmUpSuccess", value);
		}
	}

	// Token: 0x170003B4 RID: 948
	// (get) Token: 0x06001610 RID: 5648 RVA: 0x000DCF44 File Offset: 0x000DB144
	// (set) Token: 0x06001611 RID: 5649 RVA: 0x000DCF74 File Offset: 0x000DB174
	public static int EightiesCutsceneID
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_EightiesCutsceneID");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_EightiesCutsceneID", value);
		}
	}

	// Token: 0x170003B5 RID: 949
	// (get) Token: 0x06001612 RID: 5650 RVA: 0x000DCFA4 File Offset: 0x000DB1A4
	// (set) Token: 0x06001613 RID: 5651 RVA: 0x000DCFD4 File Offset: 0x000DB1D4
	public static bool EightiesTutorial
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_EightiesTutorial");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_EightiesTutorial", value);
		}
	}

	// Token: 0x170003B6 RID: 950
	// (get) Token: 0x06001614 RID: 5652 RVA: 0x000DD003 File Offset: 0x000DB203
	// (set) Token: 0x06001615 RID: 5653 RVA: 0x000DD00F File Offset: 0x000DB20F
	public static bool Eighties
	{
		get
		{
			return GlobalsHelper.GetBool("Eighties");
		}
		set
		{
			GlobalsHelper.SetBool("Eighties", value);
		}
	}

	// Token: 0x170003B7 RID: 951
	// (get) Token: 0x06001616 RID: 5654 RVA: 0x000DD01C File Offset: 0x000DB21C
	// (set) Token: 0x06001617 RID: 5655 RVA: 0x000DD04C File Offset: 0x000DB24C
	public static int YakuzaPhase
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_YakuzaPhase");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_YakuzaPhase", value);
		}
	}

	// Token: 0x170003B8 RID: 952
	// (get) Token: 0x06001618 RID: 5656 RVA: 0x000DD07C File Offset: 0x000DB27C
	// (set) Token: 0x06001619 RID: 5657 RVA: 0x000DD0AC File Offset: 0x000DB2AC
	public static bool MetBarber
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_MetBarber");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_MetBarber", value);
		}
	}

	// Token: 0x170003B9 RID: 953
	// (get) Token: 0x0600161A RID: 5658 RVA: 0x000DD0DC File Offset: 0x000DB2DC
	// (set) Token: 0x0600161B RID: 5659 RVA: 0x000DD10C File Offset: 0x000DB30C
	public static bool IntroducedAbduction
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IntroducedAbduction");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IntroducedAbduction", value);
		}
	}

	// Token: 0x170003BA RID: 954
	// (get) Token: 0x0600161C RID: 5660 RVA: 0x000DD13C File Offset: 0x000DB33C
	// (set) Token: 0x0600161D RID: 5661 RVA: 0x000DD16C File Offset: 0x000DB36C
	public static bool IntroducedRansom
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_IntroducedRansom");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_IntroducedRansom", value);
		}
	}

	// Token: 0x170003BB RID: 955
	// (get) Token: 0x0600161E RID: 5662 RVA: 0x000DD19C File Offset: 0x000DB39C
	// (set) Token: 0x0600161F RID: 5663 RVA: 0x000DD1CC File Offset: 0x000DB3CC
	public static bool Debug
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_Debug");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_Debug", value);
		}
	}

	// Token: 0x06001620 RID: 5664 RVA: 0x000DD1FC File Offset: 0x000DB3FC
	public static int GetRivalEliminations(int elimID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations" + elimID.ToString());
	}

	// Token: 0x06001621 RID: 5665 RVA: 0x000DD234 File Offset: 0x000DB434
	public static void SetRivalEliminations(int elimID, int value)
	{
		string text = elimID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations" + text, value);
	}

	// Token: 0x06001622 RID: 5666 RVA: 0x000DD290 File Offset: 0x000DB490
	public static int[] KeysOfRivalEliminations()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations");
	}

	// Token: 0x06001623 RID: 5667 RVA: 0x000DD2C0 File Offset: 0x000DB4C0
	public static int GetSpecificEliminations(int elimID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations" + elimID.ToString());
	}

	// Token: 0x06001624 RID: 5668 RVA: 0x000DD2F8 File Offset: 0x000DB4F8
	public static void SetSpecificEliminations(int elimID, int value)
	{
		string text = elimID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations" + text, value);
	}

	// Token: 0x06001625 RID: 5669 RVA: 0x000DD354 File Offset: 0x000DB554
	public static int[] KeysOfSpecificEliminations()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations");
	}

	// Token: 0x170003BC RID: 956
	// (get) Token: 0x06001626 RID: 5670 RVA: 0x000DD384 File Offset: 0x000DB584
	// (set) Token: 0x06001627 RID: 5671 RVA: 0x000DD3B4 File Offset: 0x000DB5B4
	public static bool TrueEnding
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_TrueEnding");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_TrueEnding", value);
		}
	}

	// Token: 0x170003BD RID: 957
	// (get) Token: 0x06001628 RID: 5672 RVA: 0x000DD3E4 File Offset: 0x000DB5E4
	// (set) Token: 0x06001629 RID: 5673 RVA: 0x000DD414 File Offset: 0x000DB614
	public static bool JustKidnapped
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_JustKidnapped");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_JustKidnapped", value);
		}
	}

	// Token: 0x170003BE RID: 958
	// (get) Token: 0x0600162A RID: 5674 RVA: 0x000DD444 File Offset: 0x000DB644
	// (set) Token: 0x0600162B RID: 5675 RVA: 0x000DD474 File Offset: 0x000DB674
	public static bool ShowAbduction
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ShowAbduction");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ShowAbduction", value);
		}
	}

	// Token: 0x170003BF RID: 959
	// (get) Token: 0x0600162C RID: 5676 RVA: 0x000DD4A4 File Offset: 0x000DB6A4
	// (set) Token: 0x0600162D RID: 5677 RVA: 0x000DD4D4 File Offset: 0x000DB6D4
	public static int AbductionTarget
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_AbductionTarget");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_AbductionTarget", value);
		}
	}

	// Token: 0x170003C0 RID: 960
	// (get) Token: 0x0600162E RID: 5678 RVA: 0x000DD503 File Offset: 0x000DB703
	// (set) Token: 0x0600162F RID: 5679 RVA: 0x000DD50F File Offset: 0x000DB70F
	public static bool CameFromTitleScreen
	{
		get
		{
			return GlobalsHelper.GetBool("CameFromTitleScreen");
		}
		set
		{
			GlobalsHelper.SetBool("CameFromTitleScreen", value);
		}
	}

	// Token: 0x170003C1 RID: 961
	// (get) Token: 0x06001630 RID: 5680 RVA: 0x000DD51C File Offset: 0x000DB71C
	// (set) Token: 0x06001631 RID: 5681 RVA: 0x000DD528 File Offset: 0x000DB728
	public static int VtuberID
	{
		get
		{
			return PlayerPrefs.GetInt("VtuberID");
		}
		set
		{
			PlayerPrefs.SetInt("VtuberID", value);
		}
	}

	// Token: 0x06001632 RID: 5682 RVA: 0x000DD538 File Offset: 0x000DB738
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LoveSick");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MasksBanned");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Paranormal");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_EasyMode");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_HardMode");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_EmptyDemon");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CensorBlood");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CensorPanties");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CensorKillingAnims");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SpareUniform");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BlondeHair");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiMourning");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminationID");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminationID");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_NonlethalElimination");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ReputationsInitialized");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_AnswerSheetUnavailable");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_AlphabetMode");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PoliceYesterday");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DarkEnding");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MostRecentSlot");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiSawOsanaCorpse");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_TransitionToPostCredits");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PlayerHasBeatenDemo");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_InformedAboutSkipping");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_RingStolen");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BeatEmUpDifficulty");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BeatEmUpSuccess");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_YakuzaPhase");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MetBarber");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Debug");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IntroducedAbduction");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_IntroducedRansom");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_EightiesCutsceneID");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_EightiesTutorial");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Eighties");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_TrueEnding");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_JustKidnapped");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ShowAbduction");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_AbductionTarget");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CameFromTitleScreen");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_VtuberID");
		for (int i = 1; i < 11; i++)
		{
			GameGlobals.SetSpecificEliminations(i, 0);
		}
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_RivalEliminations", GameGlobals.KeysOfRivalEliminations());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_SpecificEliminations", GameGlobals.KeysOfSpecificEliminations());
	}

	// Token: 0x04002220 RID: 8736
	private const string Str_Profile = "Profile";

	// Token: 0x04002221 RID: 8737
	private const string Str_MostRecentSlot = "MostRecentSlot";

	// Token: 0x04002222 RID: 8738
	private const string Str_LoveSick = "LoveSick";

	// Token: 0x04002223 RID: 8739
	private const string Str_MasksBanned = "MasksBanned";

	// Token: 0x04002224 RID: 8740
	private const string Str_Paranormal = "Paranormal";

	// Token: 0x04002225 RID: 8741
	private const string Str_EasyMode = "EasyMode";

	// Token: 0x04002226 RID: 8742
	private const string Str_HardMode = "HardMode";

	// Token: 0x04002227 RID: 8743
	private const string Str_EmptyDemon = "EmptyDemon";

	// Token: 0x04002228 RID: 8744
	private const string Str_CensorBlood = "CensorBlood";

	// Token: 0x04002229 RID: 8745
	private const string Str_CensorPanties = "CensorPanties";

	// Token: 0x0400222A RID: 8746
	private const string Str_CensorKillingAnims = "CensorKillingAnims";

	// Token: 0x0400222B RID: 8747
	private const string Str_SpareUniform = "SpareUniform";

	// Token: 0x0400222C RID: 8748
	private const string Str_BlondeHair = "BlondeHair";

	// Token: 0x0400222D RID: 8749
	private const string Str_SenpaiMourning = "SenpaiMourning";

	// Token: 0x0400222E RID: 8750
	private const string Str_RivalEliminationID = "RivalEliminationID";

	// Token: 0x0400222F RID: 8751
	private const string Str_SpecificEliminationID = "SpecificEliminationID";

	// Token: 0x04002230 RID: 8752
	private const string Str_NonlethalElimination = "NonlethalElimination";

	// Token: 0x04002231 RID: 8753
	private const string Str_ReputationsInitialized = "ReputationsInitialized";

	// Token: 0x04002232 RID: 8754
	private const string Str_AnswerSheetUnavailable = "AnswerSheetUnavailable";

	// Token: 0x04002233 RID: 8755
	private const string Str_AlphabetMode = "AlphabetMode";

	// Token: 0x04002234 RID: 8756
	private const string Str_PoliceYesterday = "PoliceYesterday";

	// Token: 0x04002235 RID: 8757
	private const string Str_DarkEnding = "DarkEnding";

	// Token: 0x04002236 RID: 8758
	private const string Str_SenpaiSawOsanaCorpse = "SenpaiSawOsanaCorpse";

	// Token: 0x04002237 RID: 8759
	private const string Str_TransitionToPostCredits = "TransitionToPostCredits";

	// Token: 0x04002238 RID: 8760
	private const string Str_PlayerHasBeatenDemo = "PlayerHasBeatenDemo";

	// Token: 0x04002239 RID: 8761
	private const string Str_InformedAboutSkipping = "InformedAboutSkipping";

	// Token: 0x0400223A RID: 8762
	private const string Str_RingStolen = "RingStolen";

	// Token: 0x0400223B RID: 8763
	private const string Str_BeatEmUpDifficulty = "BeatEmUpDifficulty";

	// Token: 0x0400223C RID: 8764
	private const string Str_BeatEmUpSuccess = "BeatEmUpSuccess";

	// Token: 0x0400223D RID: 8765
	private const string Str_EightiesCutsceneID = "EightiesCutsceneID";

	// Token: 0x0400223E RID: 8766
	private const string Str_EightiesTutorial = "EightiesTutorial";

	// Token: 0x0400223F RID: 8767
	private const string Str_Eighties = "Eighties";

	// Token: 0x04002240 RID: 8768
	private const string Str_YakuzaPhase = "YakuzaPhase";

	// Token: 0x04002241 RID: 8769
	private const string Str_MetBarber = "MetBarber";

	// Token: 0x04002242 RID: 8770
	private const string Str_Debug = "Debug";

	// Token: 0x04002243 RID: 8771
	private const string Str_RivalEliminations = "RivalEliminations";

	// Token: 0x04002244 RID: 8772
	private const string Str_SpecificEliminations = "SpecificEliminations";

	// Token: 0x04002245 RID: 8773
	private const string Str_IntroducedAbduction = "IntroducedAbduction";

	// Token: 0x04002246 RID: 8774
	private const string Str_IntroducedRansom = "IntroducedRansom";

	// Token: 0x04002247 RID: 8775
	private const string Str_TrueEnding = "TrueEnding";

	// Token: 0x04002248 RID: 8776
	private const string Str_JustKidnapped = "JustKidnapped";

	// Token: 0x04002249 RID: 8777
	private const string Str_ShowAbduction = "ShowAbduction";

	// Token: 0x0400224A RID: 8778
	private const string Str_AbductionTarget = "AbductionTarget";

	// Token: 0x0400224B RID: 8779
	private const string Str_CameFromTitleScreen = "CameFromTitleScreen";

	// Token: 0x0400224C RID: 8780
	private const string Str_VtuberID = "VtuberID";
}
