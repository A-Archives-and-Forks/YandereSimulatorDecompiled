﻿using System;
using UnityEngine;

// Token: 0x020002F9 RID: 761
public static class StudentGlobals
{
	// Token: 0x1700042C RID: 1068
	// (get) Token: 0x0600171E RID: 5918 RVA: 0x000DF284 File Offset: 0x000DD484
	// (set) Token: 0x0600171F RID: 5919 RVA: 0x000DF2B4 File Offset: 0x000DD4B4
	public static bool CustomSuitor
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitor");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitor", value);
		}
	}

	// Token: 0x1700042D RID: 1069
	// (get) Token: 0x06001720 RID: 5920 RVA: 0x000DF2E4 File Offset: 0x000DD4E4
	// (set) Token: 0x06001721 RID: 5921 RVA: 0x000DF314 File Offset: 0x000DD514
	public static int CustomSuitorAccessory
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorAccessory");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorAccessory", value);
		}
	}

	// Token: 0x1700042E RID: 1070
	// (get) Token: 0x06001722 RID: 5922 RVA: 0x000DF344 File Offset: 0x000DD544
	// (set) Token: 0x06001723 RID: 5923 RVA: 0x000DF374 File Offset: 0x000DD574
	public static bool CustomSuitorBlonde
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorBlonde");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorBlonde", value);
		}
	}

	// Token: 0x1700042F RID: 1071
	// (get) Token: 0x06001724 RID: 5924 RVA: 0x000DF3A4 File Offset: 0x000DD5A4
	// (set) Token: 0x06001725 RID: 5925 RVA: 0x000DF3D4 File Offset: 0x000DD5D4
	public static bool CustomSuitorBlack
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorBlack");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorBlack", value);
		}
	}

	// Token: 0x17000430 RID: 1072
	// (get) Token: 0x06001726 RID: 5926 RVA: 0x000DF404 File Offset: 0x000DD604
	// (set) Token: 0x06001727 RID: 5927 RVA: 0x000DF434 File Offset: 0x000DD634
	public static int CustomSuitorEyewear
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorEyewear");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorEyewear", value);
		}
	}

	// Token: 0x17000431 RID: 1073
	// (get) Token: 0x06001728 RID: 5928 RVA: 0x000DF464 File Offset: 0x000DD664
	// (set) Token: 0x06001729 RID: 5929 RVA: 0x000DF494 File Offset: 0x000DD694
	public static int CustomSuitorHair
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorHair");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorHair", value);
		}
	}

	// Token: 0x17000432 RID: 1074
	// (get) Token: 0x0600172A RID: 5930 RVA: 0x000DF4C4 File Offset: 0x000DD6C4
	// (set) Token: 0x0600172B RID: 5931 RVA: 0x000DF4F4 File Offset: 0x000DD6F4
	public static int CustomSuitorJewelry
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorJewelry");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorJewelry", value);
		}
	}

	// Token: 0x17000433 RID: 1075
	// (get) Token: 0x0600172C RID: 5932 RVA: 0x000DF524 File Offset: 0x000DD724
	// (set) Token: 0x0600172D RID: 5933 RVA: 0x000DF554 File Offset: 0x000DD754
	public static bool CustomSuitorTan
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorTan");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorTan", value);
		}
	}

	// Token: 0x17000434 RID: 1076
	// (get) Token: 0x0600172E RID: 5934 RVA: 0x000DF584 File Offset: 0x000DD784
	// (set) Token: 0x0600172F RID: 5935 RVA: 0x000DF5B4 File Offset: 0x000DD7B4
	public static int ExpelProgress
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_ExpelProgress");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_ExpelProgress", value);
		}
	}

	// Token: 0x17000435 RID: 1077
	// (get) Token: 0x06001730 RID: 5936 RVA: 0x000DF5E4 File Offset: 0x000DD7E4
	// (set) Token: 0x06001731 RID: 5937 RVA: 0x000DF614 File Offset: 0x000DD814
	public static int FemaleUniform
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_FemaleUniform");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_FemaleUniform", value);
		}
	}

	// Token: 0x17000436 RID: 1078
	// (get) Token: 0x06001732 RID: 5938 RVA: 0x000DF644 File Offset: 0x000DD844
	// (set) Token: 0x06001733 RID: 5939 RVA: 0x000DF674 File Offset: 0x000DD874
	public static int MaleUniform
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MaleUniform");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MaleUniform", value);
		}
	}

	// Token: 0x17000437 RID: 1079
	// (get) Token: 0x06001734 RID: 5940 RVA: 0x000DF6A4 File Offset: 0x000DD8A4
	// (set) Token: 0x06001735 RID: 5941 RVA: 0x000DF6D4 File Offset: 0x000DD8D4
	public static int MemorialStudents
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudents");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudents", value);
		}
	}

	// Token: 0x17000438 RID: 1080
	// (get) Token: 0x06001736 RID: 5942 RVA: 0x000DF704 File Offset: 0x000DD904
	// (set) Token: 0x06001737 RID: 5943 RVA: 0x000DF734 File Offset: 0x000DD934
	public static int MemorialStudent1
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent1");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent1", value);
		}
	}

	// Token: 0x17000439 RID: 1081
	// (get) Token: 0x06001738 RID: 5944 RVA: 0x000DF764 File Offset: 0x000DD964
	// (set) Token: 0x06001739 RID: 5945 RVA: 0x000DF794 File Offset: 0x000DD994
	public static int MemorialStudent2
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent2");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent2", value);
		}
	}

	// Token: 0x1700043A RID: 1082
	// (get) Token: 0x0600173A RID: 5946 RVA: 0x000DF7C4 File Offset: 0x000DD9C4
	// (set) Token: 0x0600173B RID: 5947 RVA: 0x000DF7F4 File Offset: 0x000DD9F4
	public static int MemorialStudent3
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent3");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent3", value);
		}
	}

	// Token: 0x1700043B RID: 1083
	// (get) Token: 0x0600173C RID: 5948 RVA: 0x000DF824 File Offset: 0x000DDA24
	// (set) Token: 0x0600173D RID: 5949 RVA: 0x000DF854 File Offset: 0x000DDA54
	public static int MemorialStudent4
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent4");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent4", value);
		}
	}

	// Token: 0x1700043C RID: 1084
	// (get) Token: 0x0600173E RID: 5950 RVA: 0x000DF884 File Offset: 0x000DDA84
	// (set) Token: 0x0600173F RID: 5951 RVA: 0x000DF8B4 File Offset: 0x000DDAB4
	public static int MemorialStudent5
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent5");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent5", value);
		}
	}

	// Token: 0x1700043D RID: 1085
	// (get) Token: 0x06001740 RID: 5952 RVA: 0x000DF8E4 File Offset: 0x000DDAE4
	// (set) Token: 0x06001741 RID: 5953 RVA: 0x000DF914 File Offset: 0x000DDB14
	public static int MemorialStudent6
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent6");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent6", value);
		}
	}

	// Token: 0x1700043E RID: 1086
	// (get) Token: 0x06001742 RID: 5954 RVA: 0x000DF944 File Offset: 0x000DDB44
	// (set) Token: 0x06001743 RID: 5955 RVA: 0x000DF974 File Offset: 0x000DDB74
	public static int MemorialStudent7
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent7");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent7", value);
		}
	}

	// Token: 0x1700043F RID: 1087
	// (get) Token: 0x06001744 RID: 5956 RVA: 0x000DF9A4 File Offset: 0x000DDBA4
	// (set) Token: 0x06001745 RID: 5957 RVA: 0x000DF9D4 File Offset: 0x000DDBD4
	public static int MemorialStudent8
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent8");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent8", value);
		}
	}

	// Token: 0x17000440 RID: 1088
	// (get) Token: 0x06001746 RID: 5958 RVA: 0x000DFA04 File Offset: 0x000DDC04
	// (set) Token: 0x06001747 RID: 5959 RVA: 0x000DFA34 File Offset: 0x000DDC34
	public static int MemorialStudent9
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent9");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent9", value);
		}
	}

	// Token: 0x06001748 RID: 5960 RVA: 0x000DFA64 File Offset: 0x000DDC64
	public static string GetStudentAccessory(int studentID)
	{
		return PlayerPrefs.GetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_" + studentID.ToString());
	}

	// Token: 0x06001749 RID: 5961 RVA: 0x000DFA9C File Offset: 0x000DDC9C
	public static void SetStudentAccessory(int studentID, string value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_", text);
		PlayerPrefs.SetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_" + text, value);
	}

	// Token: 0x0600174A RID: 5962 RVA: 0x000DFAF8 File Offset: 0x000DDCF8
	public static int[] KeysOfStudentAccessory()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_");
	}

	// Token: 0x0600174B RID: 5963 RVA: 0x000DFB28 File Offset: 0x000DDD28
	public static bool GetStudentArrested(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_" + studentID.ToString());
	}

	// Token: 0x0600174C RID: 5964 RVA: 0x000DFB60 File Offset: 0x000DDD60
	public static void SetStudentArrested(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_" + text, value);
	}

	// Token: 0x0600174D RID: 5965 RVA: 0x000DFBBC File Offset: 0x000DDDBC
	public static int[] KeysOfStudentArrested()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_");
	}

	// Token: 0x0600174E RID: 5966 RVA: 0x000DFBEC File Offset: 0x000DDDEC
	public static bool GetStudentBroken(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_" + studentID.ToString());
	}

	// Token: 0x0600174F RID: 5967 RVA: 0x000DFC24 File Offset: 0x000DDE24
	public static void SetStudentBroken(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_" + text, value);
	}

	// Token: 0x06001750 RID: 5968 RVA: 0x000DFC80 File Offset: 0x000DDE80
	public static int[] KeysOfStudentBroken()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_");
	}

	// Token: 0x06001751 RID: 5969 RVA: 0x000DFCB0 File Offset: 0x000DDEB0
	public static float GetStudentBustSize(int studentID)
	{
		return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_" + studentID.ToString());
	}

	// Token: 0x06001752 RID: 5970 RVA: 0x000DFCE8 File Offset: 0x000DDEE8
	public static void SetStudentBustSize(int studentID, float value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_", text);
		PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_" + text, value);
	}

	// Token: 0x06001753 RID: 5971 RVA: 0x000DFD44 File Offset: 0x000DDF44
	public static int[] KeysOfStudentBustSize()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_");
	}

	// Token: 0x06001754 RID: 5972 RVA: 0x000DFD74 File Offset: 0x000DDF74
	public static Color GetStudentColor(int studentID)
	{
		return GlobalsHelper.GetColor("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_" + studentID.ToString());
	}

	// Token: 0x06001755 RID: 5973 RVA: 0x000DFDAC File Offset: 0x000DDFAC
	public static void SetStudentColor(int studentID, Color value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_", text);
		GlobalsHelper.SetColor("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_" + text, value);
	}

	// Token: 0x06001756 RID: 5974 RVA: 0x000DFE08 File Offset: 0x000DE008
	public static int[] KeysOfStudentColor()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_");
	}

	// Token: 0x06001757 RID: 5975 RVA: 0x000DFE38 File Offset: 0x000DE038
	public static bool GetStudentDead(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_" + studentID.ToString());
	}

	// Token: 0x06001758 RID: 5976 RVA: 0x000DFE70 File Offset: 0x000DE070
	public static void SetStudentDead(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_" + text, value);
	}

	// Token: 0x06001759 RID: 5977 RVA: 0x000DFECC File Offset: 0x000DE0CC
	public static int[] KeysOfStudentDead()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_");
	}

	// Token: 0x0600175A RID: 5978 RVA: 0x000DFEFC File Offset: 0x000DE0FC
	public static bool GetStudentDying(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_" + studentID.ToString());
	}

	// Token: 0x0600175B RID: 5979 RVA: 0x000DFF34 File Offset: 0x000DE134
	public static void SetStudentDying(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_" + text, value);
	}

	// Token: 0x0600175C RID: 5980 RVA: 0x000DFF90 File Offset: 0x000DE190
	public static int[] KeysOfStudentDying()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_");
	}

	// Token: 0x0600175D RID: 5981 RVA: 0x000DFFC0 File Offset: 0x000DE1C0
	public static bool GetStudentExpelled(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_" + studentID.ToString());
	}

	// Token: 0x0600175E RID: 5982 RVA: 0x000DFFF8 File Offset: 0x000DE1F8
	public static void SetStudentExpelled(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_" + text, value);
	}

	// Token: 0x0600175F RID: 5983 RVA: 0x000E0054 File Offset: 0x000DE254
	public static int[] KeysOfStudentExpelled()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_");
	}

	// Token: 0x06001760 RID: 5984 RVA: 0x000E0084 File Offset: 0x000DE284
	public static bool GetStudentExposed(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_" + studentID.ToString());
	}

	// Token: 0x06001761 RID: 5985 RVA: 0x000E00BC File Offset: 0x000DE2BC
	public static void SetStudentExposed(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_" + text, value);
	}

	// Token: 0x06001762 RID: 5986 RVA: 0x000E0118 File Offset: 0x000DE318
	public static int[] KeysOfStudentExposed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_");
	}

	// Token: 0x06001763 RID: 5987 RVA: 0x000E0148 File Offset: 0x000DE348
	public static Color GetStudentEyeColor(int studentID)
	{
		return GlobalsHelper.GetColor("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_" + studentID.ToString());
	}

	// Token: 0x06001764 RID: 5988 RVA: 0x000E0180 File Offset: 0x000DE380
	public static void SetStudentEyeColor(int studentID, Color value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_", text);
		GlobalsHelper.SetColor("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_" + text, value);
	}

	// Token: 0x06001765 RID: 5989 RVA: 0x000E01DC File Offset: 0x000DE3DC
	public static int[] KeysOfStudentEyeColor()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_");
	}

	// Token: 0x06001766 RID: 5990 RVA: 0x000E020C File Offset: 0x000DE40C
	public static bool GetStudentGrudge(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_" + studentID.ToString());
	}

	// Token: 0x06001767 RID: 5991 RVA: 0x000E0244 File Offset: 0x000DE444
	public static void SetStudentGrudge(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_" + text, value);
	}

	// Token: 0x06001768 RID: 5992 RVA: 0x000E02A0 File Offset: 0x000DE4A0
	public static int[] KeysOfStudentGrudge()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_");
	}

	// Token: 0x06001769 RID: 5993 RVA: 0x000E02D0 File Offset: 0x000DE4D0
	public static string GetStudentHairstyle(int studentID)
	{
		return PlayerPrefs.GetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_" + studentID.ToString());
	}

	// Token: 0x0600176A RID: 5994 RVA: 0x000E0308 File Offset: 0x000DE508
	public static void SetStudentHairstyle(int studentID, string value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_", text);
		PlayerPrefs.SetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_" + text, value);
	}

	// Token: 0x0600176B RID: 5995 RVA: 0x000E0364 File Offset: 0x000DE564
	public static int[] KeysOfStudentHairstyle()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_");
	}

	// Token: 0x0600176C RID: 5996 RVA: 0x000E0394 File Offset: 0x000DE594
	public static bool GetStudentKidnapped(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_" + studentID.ToString());
	}

	// Token: 0x0600176D RID: 5997 RVA: 0x000E03CC File Offset: 0x000DE5CC
	public static void SetStudentKidnapped(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_" + text, value);
	}

	// Token: 0x0600176E RID: 5998 RVA: 0x000E0428 File Offset: 0x000DE628
	public static int[] KeysOfStudentKidnapped()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_");
	}

	// Token: 0x0600176F RID: 5999 RVA: 0x000E0458 File Offset: 0x000DE658
	public static bool GetStudentMissing(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_" + studentID.ToString());
	}

	// Token: 0x06001770 RID: 6000 RVA: 0x000E0490 File Offset: 0x000DE690
	public static void SetStudentMissing(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_" + text, value);
	}

	// Token: 0x06001771 RID: 6001 RVA: 0x000E04EC File Offset: 0x000DE6EC
	public static int[] KeysOfStudentMissing()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_");
	}

	// Token: 0x06001772 RID: 6002 RVA: 0x000E051C File Offset: 0x000DE71C
	public static string GetStudentName(int studentID)
	{
		return PlayerPrefs.GetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_" + studentID.ToString());
	}

	// Token: 0x06001773 RID: 6003 RVA: 0x000E0554 File Offset: 0x000DE754
	public static void SetStudentName(int studentID, string value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_", text);
		PlayerPrefs.SetString("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_" + text, value);
	}

	// Token: 0x06001774 RID: 6004 RVA: 0x000E05B0 File Offset: 0x000DE7B0
	public static int[] KeysOfStudentName()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_");
	}

	// Token: 0x06001775 RID: 6005 RVA: 0x000E05E0 File Offset: 0x000DE7E0
	public static bool GetStudentPhotographed(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_" + studentID.ToString());
	}

	// Token: 0x06001776 RID: 6006 RVA: 0x000E0618 File Offset: 0x000DE818
	public static void SetStudentPhotographed(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_" + text, value);
	}

	// Token: 0x06001777 RID: 6007 RVA: 0x000E0674 File Offset: 0x000DE874
	public static int[] KeysOfStudentPhotographed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_");
	}

	// Token: 0x06001778 RID: 6008 RVA: 0x000E06A4 File Offset: 0x000DE8A4
	public static bool GetStudentPhoneStolen(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_" + studentID.ToString());
	}

	// Token: 0x06001779 RID: 6009 RVA: 0x000E06DC File Offset: 0x000DE8DC
	public static void SetStudentPhoneStolen(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_" + text, value);
	}

	// Token: 0x0600177A RID: 6010 RVA: 0x000E0738 File Offset: 0x000DE938
	public static int[] KeysOfStudentPhoneStolen()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_");
	}

	// Token: 0x0600177B RID: 6011 RVA: 0x000E0768 File Offset: 0x000DE968
	public static bool GetStudentReplaced(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_" + studentID.ToString());
	}

	// Token: 0x0600177C RID: 6012 RVA: 0x000E07A0 File Offset: 0x000DE9A0
	public static void SetStudentReplaced(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_" + text, value);
	}

	// Token: 0x0600177D RID: 6013 RVA: 0x000E07FC File Offset: 0x000DE9FC
	public static int[] KeysOfStudentReplaced()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_");
	}

	// Token: 0x0600177E RID: 6014 RVA: 0x000E082C File Offset: 0x000DEA2C
	public static int GetStudentReputation(int studentID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_" + studentID.ToString());
	}

	// Token: 0x0600177F RID: 6015 RVA: 0x000E0864 File Offset: 0x000DEA64
	public static void SetStudentReputation(int studentID, int value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_" + text, value);
	}

	// Token: 0x06001780 RID: 6016 RVA: 0x000E08C0 File Offset: 0x000DEAC0
	public static int[] KeysOfStudentReputation()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_");
	}

	// Token: 0x06001781 RID: 6017 RVA: 0x000E08F0 File Offset: 0x000DEAF0
	public static float GetStudentSanity(int studentID)
	{
		return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_" + studentID.ToString());
	}

	// Token: 0x06001782 RID: 6018 RVA: 0x000E0928 File Offset: 0x000DEB28
	public static void SetStudentSanity(int studentID, float value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_", text);
		PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_" + text, value);
	}

	// Token: 0x06001783 RID: 6019 RVA: 0x000E0984 File Offset: 0x000DEB84
	public static int[] KeysOfStudentSanity()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_");
	}

	// Token: 0x17000441 RID: 1089
	// (get) Token: 0x06001784 RID: 6020 RVA: 0x000E09B4 File Offset: 0x000DEBB4
	// (set) Token: 0x06001785 RID: 6021 RVA: 0x000E09E4 File Offset: 0x000DEBE4
	public static int StudentSlave
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_StudentSlave");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_StudentSlave", value);
		}
	}

	// Token: 0x17000442 RID: 1090
	// (get) Token: 0x06001786 RID: 6022 RVA: 0x000E0A14 File Offset: 0x000DEC14
	// (set) Token: 0x06001787 RID: 6023 RVA: 0x000E0A44 File Offset: 0x000DEC44
	public static int FragileSlave
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_FragileSlave");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_FragileSlave", value);
		}
	}

	// Token: 0x17000443 RID: 1091
	// (get) Token: 0x06001788 RID: 6024 RVA: 0x000E0A74 File Offset: 0x000DEC74
	// (set) Token: 0x06001789 RID: 6025 RVA: 0x000E0AA4 File Offset: 0x000DECA4
	public static int FragileTarget
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_FragileTarget");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_FragileTarget", value);
		}
	}

	// Token: 0x0600178A RID: 6026 RVA: 0x000E0AD4 File Offset: 0x000DECD4
	public static Vector3 GetReputationTriangle(int studentID)
	{
		return GlobalsHelper.GetVector3(string.Concat(new string[]
		{
			"Profile_",
			GameGlobals.Profile.ToString(),
			"_Student_",
			studentID.ToString(),
			"_ReputatonTriangle"
		}));
	}

	// Token: 0x0600178B RID: 6027 RVA: 0x000E0B24 File Offset: 0x000DED24
	public static void SetReputationTriangle(int studentID, Vector3 triangle)
	{
		GlobalsHelper.SetVector3(string.Concat(new string[]
		{
			"Profile_",
			GameGlobals.Profile.ToString(),
			"_Student_",
			studentID.ToString(),
			"_ReputatonTriangle"
		}), triangle);
	}

	// Token: 0x0600178C RID: 6028 RVA: 0x000E0B74 File Offset: 0x000DED74
	public static bool GetStudentRansomed(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_" + studentID.ToString());
	}

	// Token: 0x0600178D RID: 6029 RVA: 0x000E0BAC File Offset: 0x000DEDAC
	public static void SetStudentRansomed(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_" + text, value);
	}

	// Token: 0x0600178E RID: 6030 RVA: 0x000E0C08 File Offset: 0x000DEE08
	public static int[] KeysOfStudentRansomed()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_");
	}

	// Token: 0x0600178F RID: 6031 RVA: 0x000E0C38 File Offset: 0x000DEE38
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitor");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorAccessory");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorBlonde");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorBlack");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorEyewear");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorHair");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorJewelry");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CustomSuitorTan");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ExpelProgress");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_FemaleUniform");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MaleUniform");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_StudentSlave");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_FragileSlave");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_FragileTarget");
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentAccessory_", StudentGlobals.KeysOfStudentAccessory());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentArrested_", StudentGlobals.KeysOfStudentArrested());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentBroken_", StudentGlobals.KeysOfStudentBroken());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentBustSize_", StudentGlobals.KeysOfStudentBustSize());
		GlobalsHelper.DeleteColorCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentColor_", StudentGlobals.KeysOfStudentColor());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentDead_", StudentGlobals.KeysOfStudentDead());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentDying_", StudentGlobals.KeysOfStudentDying());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentExpelled_", StudentGlobals.KeysOfStudentExpelled());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentExposed_", StudentGlobals.KeysOfStudentExposed());
		GlobalsHelper.DeleteColorCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentEyeColor_", StudentGlobals.KeysOfStudentEyeColor());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentGrudge_", StudentGlobals.KeysOfStudentGrudge());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentHairstyle_", StudentGlobals.KeysOfStudentHairstyle());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentKidnapped_", StudentGlobals.KeysOfStudentKidnapped());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentMissing_", StudentGlobals.KeysOfStudentMissing());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentName_", StudentGlobals.KeysOfStudentName());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhotographed_", StudentGlobals.KeysOfStudentPhotographed());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentPhoneStolen_", StudentGlobals.KeysOfStudentPhoneStolen());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentReplaced_", StudentGlobals.KeysOfStudentReplaced());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentReputation_", StudentGlobals.KeysOfStudentReputation());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentSanity_", StudentGlobals.KeysOfStudentSanity());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentRansomed_", StudentGlobals.KeysOfStudentRansomed());
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudents");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent1");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent2");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent3");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent4");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent5");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent6");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent7");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent8");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_MemorialStudent9");
	}

	// Token: 0x04002264 RID: 8804
	private const string Str_CustomSuitor = "CustomSuitor";

	// Token: 0x04002265 RID: 8805
	private const string Str_CustomSuitorAccessory = "CustomSuitorAccessory";

	// Token: 0x04002266 RID: 8806
	private const string Str_CustomSuitorBlonde = "CustomSuitorBlonde";

	// Token: 0x04002267 RID: 8807
	private const string Str_CustomSuitorBlack = "CustomSuitorBlack";

	// Token: 0x04002268 RID: 8808
	private const string Str_CustomSuitorEyewear = "CustomSuitorEyewear";

	// Token: 0x04002269 RID: 8809
	private const string Str_CustomSuitorHair = "CustomSuitorHair";

	// Token: 0x0400226A RID: 8810
	private const string Str_CustomSuitorJewelry = "CustomSuitorJewelry";

	// Token: 0x0400226B RID: 8811
	private const string Str_CustomSuitorTan = "CustomSuitorTan";

	// Token: 0x0400226C RID: 8812
	private const string Str_ExpelProgress = "ExpelProgress";

	// Token: 0x0400226D RID: 8813
	private const string Str_FemaleUniform = "FemaleUniform";

	// Token: 0x0400226E RID: 8814
	private const string Str_MaleUniform = "MaleUniform";

	// Token: 0x0400226F RID: 8815
	private const string Str_StudentAccessory = "StudentAccessory_";

	// Token: 0x04002270 RID: 8816
	private const string Str_StudentArrested = "StudentArrested_";

	// Token: 0x04002271 RID: 8817
	private const string Str_StudentBroken = "StudentBroken_";

	// Token: 0x04002272 RID: 8818
	private const string Str_StudentBustSize = "StudentBustSize_";

	// Token: 0x04002273 RID: 8819
	private const string Str_StudentColor = "StudentColor_";

	// Token: 0x04002274 RID: 8820
	private const string Str_StudentDead = "StudentDead_";

	// Token: 0x04002275 RID: 8821
	private const string Str_StudentDying = "StudentDying_";

	// Token: 0x04002276 RID: 8822
	private const string Str_StudentExpelled = "StudentExpelled_";

	// Token: 0x04002277 RID: 8823
	private const string Str_StudentExposed = "StudentExposed_";

	// Token: 0x04002278 RID: 8824
	private const string Str_StudentEyeColor = "StudentEyeColor_";

	// Token: 0x04002279 RID: 8825
	private const string Str_StudentGrudge = "StudentGrudge_";

	// Token: 0x0400227A RID: 8826
	private const string Str_StudentHairstyle = "StudentHairstyle_";

	// Token: 0x0400227B RID: 8827
	private const string Str_StudentKidnapped = "StudentKidnapped_";

	// Token: 0x0400227C RID: 8828
	private const string Str_StudentMissing = "StudentMissing_";

	// Token: 0x0400227D RID: 8829
	private const string Str_StudentName = "StudentName_";

	// Token: 0x0400227E RID: 8830
	private const string Str_StudentPhotographed = "StudentPhotographed_";

	// Token: 0x0400227F RID: 8831
	private const string Str_StudentPhoneStolen = "StudentPhoneStolen_";

	// Token: 0x04002280 RID: 8832
	private const string Str_StudentReplaced = "StudentReplaced_";

	// Token: 0x04002281 RID: 8833
	private const string Str_StudentReputation = "StudentReputation_";

	// Token: 0x04002282 RID: 8834
	private const string Str_StudentSanity = "StudentSanity_";

	// Token: 0x04002283 RID: 8835
	private const string Str_StudentSlave = "StudentSlave";

	// Token: 0x04002284 RID: 8836
	private const string Str_FragileSlave = "FragileSlave";

	// Token: 0x04002285 RID: 8837
	private const string Str_FragileTarget = "FragileTarget";

	// Token: 0x04002286 RID: 8838
	private const string Str_ReputationTriangle = "ReputatonTriangle";

	// Token: 0x04002287 RID: 8839
	private const string Str_StudentRansomed = "StudentRansomed_";

	// Token: 0x04002288 RID: 8840
	private const string Str_MemorialStudents = "MemorialStudents";

	// Token: 0x04002289 RID: 8841
	private const string Str_MemorialStudent1 = "MemorialStudent1";

	// Token: 0x0400228A RID: 8842
	private const string Str_MemorialStudent2 = "MemorialStudent2";

	// Token: 0x0400228B RID: 8843
	private const string Str_MemorialStudent3 = "MemorialStudent3";

	// Token: 0x0400228C RID: 8844
	private const string Str_MemorialStudent4 = "MemorialStudent4";

	// Token: 0x0400228D RID: 8845
	private const string Str_MemorialStudent5 = "MemorialStudent5";

	// Token: 0x0400228E RID: 8846
	private const string Str_MemorialStudent6 = "MemorialStudent6";

	// Token: 0x0400228F RID: 8847
	private const string Str_MemorialStudent7 = "MemorialStudent7";

	// Token: 0x04002290 RID: 8848
	private const string Str_MemorialStudent8 = "MemorialStudent8";

	// Token: 0x04002291 RID: 8849
	private const string Str_MemorialStudent9 = "MemorialStudent9";
}
