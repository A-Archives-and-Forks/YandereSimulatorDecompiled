﻿using System;
using UnityEngine;

// Token: 0x020002EE RID: 750
public static class ClassGlobals
{
	// Token: 0x17000370 RID: 880
	// (get) Token: 0x06001544 RID: 5444 RVA: 0x000DA024 File Offset: 0x000D8224
	// (set) Token: 0x06001545 RID: 5445 RVA: 0x000DA054 File Offset: 0x000D8254
	public static int Biology
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Biology");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Biology", value);
		}
	}

	// Token: 0x17000371 RID: 881
	// (get) Token: 0x06001546 RID: 5446 RVA: 0x000DA084 File Offset: 0x000D8284
	// (set) Token: 0x06001547 RID: 5447 RVA: 0x000DA0B4 File Offset: 0x000D82B4
	public static int BiologyBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BiologyBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BiologyBonus", value);
		}
	}

	// Token: 0x17000372 RID: 882
	// (get) Token: 0x06001548 RID: 5448 RVA: 0x000DA0E4 File Offset: 0x000D82E4
	// (set) Token: 0x06001549 RID: 5449 RVA: 0x000DA114 File Offset: 0x000D8314
	public static int BiologyGrade
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BiologyGrade");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BiologyGrade", value);
		}
	}

	// Token: 0x17000373 RID: 883
	// (get) Token: 0x0600154A RID: 5450 RVA: 0x000DA144 File Offset: 0x000D8344
	// (set) Token: 0x0600154B RID: 5451 RVA: 0x000DA174 File Offset: 0x000D8374
	public static int Chemistry
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Chemistry");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Chemistry", value);
		}
	}

	// Token: 0x17000374 RID: 884
	// (get) Token: 0x0600154C RID: 5452 RVA: 0x000DA1A4 File Offset: 0x000D83A4
	// (set) Token: 0x0600154D RID: 5453 RVA: 0x000DA1D4 File Offset: 0x000D83D4
	public static int ChemistryBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_ChemistryBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_ChemistryBonus", value);
		}
	}

	// Token: 0x17000375 RID: 885
	// (get) Token: 0x0600154E RID: 5454 RVA: 0x000DA204 File Offset: 0x000D8404
	// (set) Token: 0x0600154F RID: 5455 RVA: 0x000DA234 File Offset: 0x000D8434
	public static int ChemistryGrade
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_ChemistryGrade");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_ChemistryGrade", value);
		}
	}

	// Token: 0x17000376 RID: 886
	// (get) Token: 0x06001550 RID: 5456 RVA: 0x000DA264 File Offset: 0x000D8464
	// (set) Token: 0x06001551 RID: 5457 RVA: 0x000DA294 File Offset: 0x000D8494
	public static int Language
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Language");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Language", value);
		}
	}

	// Token: 0x17000377 RID: 887
	// (get) Token: 0x06001552 RID: 5458 RVA: 0x000DA2C4 File Offset: 0x000D84C4
	// (set) Token: 0x06001553 RID: 5459 RVA: 0x000DA2F4 File Offset: 0x000D84F4
	public static int LanguageBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_LanguageBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_LanguageBonus", value);
		}
	}

	// Token: 0x17000378 RID: 888
	// (get) Token: 0x06001554 RID: 5460 RVA: 0x000DA324 File Offset: 0x000D8524
	// (set) Token: 0x06001555 RID: 5461 RVA: 0x000DA354 File Offset: 0x000D8554
	public static int LanguageGrade
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_LanguageGrade");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_LanguageGrade", value);
		}
	}

	// Token: 0x17000379 RID: 889
	// (get) Token: 0x06001556 RID: 5462 RVA: 0x000DA384 File Offset: 0x000D8584
	// (set) Token: 0x06001557 RID: 5463 RVA: 0x000DA3B4 File Offset: 0x000D85B4
	public static int Physical
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Physical");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Physical", value);
		}
	}

	// Token: 0x1700037A RID: 890
	// (get) Token: 0x06001558 RID: 5464 RVA: 0x000DA3E4 File Offset: 0x000D85E4
	// (set) Token: 0x06001559 RID: 5465 RVA: 0x000DA414 File Offset: 0x000D8614
	public static int PhysicalBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_PhysicalBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_PhysicalBonus", value);
		}
	}

	// Token: 0x1700037B RID: 891
	// (get) Token: 0x0600155A RID: 5466 RVA: 0x000DA444 File Offset: 0x000D8644
	// (set) Token: 0x0600155B RID: 5467 RVA: 0x000DA474 File Offset: 0x000D8674
	public static int PhysicalGrade
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_PhysicalGrade");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_PhysicalGrade", value);
		}
	}

	// Token: 0x1700037C RID: 892
	// (get) Token: 0x0600155C RID: 5468 RVA: 0x000DA4A4 File Offset: 0x000D86A4
	// (set) Token: 0x0600155D RID: 5469 RVA: 0x000DA4D4 File Offset: 0x000D86D4
	public static int Psychology
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Psychology");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Psychology", value);
		}
	}

	// Token: 0x1700037D RID: 893
	// (get) Token: 0x0600155E RID: 5470 RVA: 0x000DA504 File Offset: 0x000D8704
	// (set) Token: 0x0600155F RID: 5471 RVA: 0x000DA534 File Offset: 0x000D8734
	public static int PsychologyBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_PsychologyBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_PsychologyBonus", value);
		}
	}

	// Token: 0x1700037E RID: 894
	// (get) Token: 0x06001560 RID: 5472 RVA: 0x000DA564 File Offset: 0x000D8764
	// (set) Token: 0x06001561 RID: 5473 RVA: 0x000DA594 File Offset: 0x000D8794
	public static int PsychologyGrade
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_PsychologyGrade");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_PsychologyGrade", value);
		}
	}

	// Token: 0x1700037F RID: 895
	// (get) Token: 0x06001562 RID: 5474 RVA: 0x000DA5C4 File Offset: 0x000D87C4
	// (set) Token: 0x06001563 RID: 5475 RVA: 0x000DA5F4 File Offset: 0x000D87F4
	public static int BonusStudyPoints
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BonusStudyPoints");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BonusStudyPoints", value);
		}
	}

	// Token: 0x06001564 RID: 5476 RVA: 0x000DA624 File Offset: 0x000D8824
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Biology");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BiologyBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BiologyGrade");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Chemistry");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ChemistryBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ChemistryGrade");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Language");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LanguageBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_LanguageGrade");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Physical");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PhysicalBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PhysicalGrade");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Psychology");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PsychologyBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PsychologyGrade");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BonusStudyPoints");
	}

	// Token: 0x040021ED RID: 8685
	private const string Str_Biology = "Biology";

	// Token: 0x040021EE RID: 8686
	private const string Str_BiologyBonus = "BiologyBonus";

	// Token: 0x040021EF RID: 8687
	private const string Str_BiologyGrade = "BiologyGrade";

	// Token: 0x040021F0 RID: 8688
	private const string Str_Chemistry = "Chemistry";

	// Token: 0x040021F1 RID: 8689
	private const string Str_ChemistryBonus = "ChemistryBonus";

	// Token: 0x040021F2 RID: 8690
	private const string Str_ChemistryGrade = "ChemistryGrade";

	// Token: 0x040021F3 RID: 8691
	private const string Str_Language = "Language";

	// Token: 0x040021F4 RID: 8692
	private const string Str_LanguageBonus = "LanguageBonus";

	// Token: 0x040021F5 RID: 8693
	private const string Str_LanguageGrade = "LanguageGrade";

	// Token: 0x040021F6 RID: 8694
	private const string Str_Physical = "Physical";

	// Token: 0x040021F7 RID: 8695
	private const string Str_PhysicalBonus = "PhysicalBonus";

	// Token: 0x040021F8 RID: 8696
	private const string Str_PhysicalGrade = "PhysicalGrade";

	// Token: 0x040021F9 RID: 8697
	private const string Str_Psychology = "Psychology";

	// Token: 0x040021FA RID: 8698
	private const string Str_PsychologyBonus = "PsychologyBonus";

	// Token: 0x040021FB RID: 8699
	private const string Str_PsychologyGrade = "PsychologyGrade";

	// Token: 0x040021FC RID: 8700
	private const string Str_BonusStudyPoints = "BonusStudyPoints";
}
