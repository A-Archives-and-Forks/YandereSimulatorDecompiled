﻿using System;
using UnityEngine;

// Token: 0x020002F8 RID: 760
public static class SchoolGlobals
{
	// Token: 0x060016FD RID: 5885 RVA: 0x000DF43C File Offset: 0x000DD63C
	public static bool GetDemonActive(int demonID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_" + demonID.ToString());
	}

	// Token: 0x060016FE RID: 5886 RVA: 0x000DF474 File Offset: 0x000DD674
	public static void SetDemonActive(int demonID, bool value)
	{
		string text = demonID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_" + text, value);
	}

	// Token: 0x060016FF RID: 5887 RVA: 0x000DF4D0 File Offset: 0x000DD6D0
	public static int[] KeysOfDemonActive()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_");
	}

	// Token: 0x06001700 RID: 5888 RVA: 0x000DF500 File Offset: 0x000DD700
	public static bool GetGardenGraveOccupied(int graveID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_" + graveID.ToString());
	}

	// Token: 0x06001701 RID: 5889 RVA: 0x000DF538 File Offset: 0x000DD738
	public static void SetGardenGraveOccupied(int graveID, bool value)
	{
		string text = graveID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_" + text, value);
	}

	// Token: 0x06001702 RID: 5890 RVA: 0x000DF594 File Offset: 0x000DD794
	public static int[] KeysOfGardenGraveOccupied()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_");
	}

	// Token: 0x1700041D RID: 1053
	// (get) Token: 0x06001703 RID: 5891 RVA: 0x000DF5C4 File Offset: 0x000DD7C4
	// (set) Token: 0x06001704 RID: 5892 RVA: 0x000DF5F4 File Offset: 0x000DD7F4
	public static int KidnapVictim
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_KidnapVictim");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_KidnapVictim", value);
		}
	}

	// Token: 0x1700041E RID: 1054
	// (get) Token: 0x06001705 RID: 5893 RVA: 0x000DF624 File Offset: 0x000DD824
	// (set) Token: 0x06001706 RID: 5894 RVA: 0x000DF654 File Offset: 0x000DD854
	public static int Population
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Population");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Population", value);
		}
	}

	// Token: 0x1700041F RID: 1055
	// (get) Token: 0x06001707 RID: 5895 RVA: 0x000DF684 File Offset: 0x000DD884
	// (set) Token: 0x06001708 RID: 5896 RVA: 0x000DF6B4 File Offset: 0x000DD8B4
	public static bool RoofFence
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_RoofFence");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_RoofFence", value);
		}
	}

	// Token: 0x17000420 RID: 1056
	// (get) Token: 0x06001709 RID: 5897 RVA: 0x000DF6E4 File Offset: 0x000DD8E4
	// (set) Token: 0x0600170A RID: 5898 RVA: 0x000DF714 File Offset: 0x000DD914
	public static float PreviousSchoolAtmosphere
	{
		get
		{
			return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_PreviousSchoolAtmosphere");
		}
		set
		{
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_PreviousSchoolAtmosphere", value);
		}
	}

	// Token: 0x17000421 RID: 1057
	// (get) Token: 0x0600170B RID: 5899 RVA: 0x000DF744 File Offset: 0x000DD944
	// (set) Token: 0x0600170C RID: 5900 RVA: 0x000DF774 File Offset: 0x000DD974
	public static float SchoolAtmosphere
	{
		get
		{
			return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_SchoolAtmosphere");
		}
		set
		{
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_SchoolAtmosphere", value);
		}
	}

	// Token: 0x17000422 RID: 1058
	// (get) Token: 0x0600170D RID: 5901 RVA: 0x000DF7A4 File Offset: 0x000DD9A4
	// (set) Token: 0x0600170E RID: 5902 RVA: 0x000DF7D4 File Offset: 0x000DD9D4
	public static bool SchoolAtmosphereSet
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchoolAtmosphereSet");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SchoolAtmosphereSet", value);
		}
	}

	// Token: 0x17000423 RID: 1059
	// (get) Token: 0x0600170F RID: 5903 RVA: 0x000DF804 File Offset: 0x000DDA04
	// (set) Token: 0x06001710 RID: 5904 RVA: 0x000DF834 File Offset: 0x000DDA34
	public static bool ReactedToGameLeader
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReactedToGameLeader");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ReactedToGameLeader", value);
		}
	}

	// Token: 0x17000424 RID: 1060
	// (get) Token: 0x06001711 RID: 5905 RVA: 0x000DF864 File Offset: 0x000DDA64
	// (set) Token: 0x06001712 RID: 5906 RVA: 0x000DF894 File Offset: 0x000DDA94
	public static bool HighSecurity
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_HighSecurity");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_HighSecurity", value);
		}
	}

	// Token: 0x17000425 RID: 1061
	// (get) Token: 0x06001713 RID: 5907 RVA: 0x000DF8C4 File Offset: 0x000DDAC4
	// (set) Token: 0x06001714 RID: 5908 RVA: 0x000DF8F4 File Offset: 0x000DDAF4
	public static bool SCP
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SCP");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SCP", value);
		}
	}

	// Token: 0x06001715 RID: 5909 RVA: 0x000DF924 File Offset: 0x000DDB24
	public static void DeleteAll()
	{
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_DemonActive_", SchoolGlobals.KeysOfDemonActive());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_GardenGraveOccupied_", SchoolGlobals.KeysOfGardenGraveOccupied());
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_KidnapVictim");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Population");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_RoofFence");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SchoolAtmosphere");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SchoolAtmosphereSet");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PreviousSchoolAtmosphere");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ReactedToGameLeader");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_HighSecurity");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SCP");
	}

	// Token: 0x04002263 RID: 8803
	private const string Str_DemonActive = "DemonActive_";

	// Token: 0x04002264 RID: 8804
	private const string Str_GardenGraveOccupied = "GardenGraveOccupied_";

	// Token: 0x04002265 RID: 8805
	private const string Str_KidnapVictim = "KidnapVictim";

	// Token: 0x04002266 RID: 8806
	private const string Str_Population = "Population";

	// Token: 0x04002267 RID: 8807
	private const string Str_RoofFence = "RoofFence";

	// Token: 0x04002268 RID: 8808
	private const string Str_SchoolAtmosphere = "SchoolAtmosphere";

	// Token: 0x04002269 RID: 8809
	private const string Str_SchoolAtmosphereSet = "SchoolAtmosphereSet";

	// Token: 0x0400226A RID: 8810
	private const string Str_PreviousSchoolAtmosphere = "PreviousSchoolAtmosphere";

	// Token: 0x0400226B RID: 8811
	private const string Str_ReactedToGameLeader = "ReactedToGameLeader";

	// Token: 0x0400226C RID: 8812
	private const string Str_SCP = "SCP";

	// Token: 0x0400226D RID: 8813
	private const string Str_HighSecurity = "HighSecurity";
}
