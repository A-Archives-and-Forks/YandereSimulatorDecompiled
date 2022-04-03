﻿using System;
using UnityEngine;

// Token: 0x020002F7 RID: 759
public static class PlayerGlobals
{
	// Token: 0x170003F6 RID: 1014
	// (get) Token: 0x06001695 RID: 5781 RVA: 0x000DE964 File Offset: 0x000DCB64
	// (set) Token: 0x06001696 RID: 5782 RVA: 0x000DE994 File Offset: 0x000DCB94
	public static float Money
	{
		get
		{
			return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_Money");
		}
		set
		{
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_Money", value);
		}
	}

	// Token: 0x170003F7 RID: 1015
	// (get) Token: 0x06001697 RID: 5783 RVA: 0x000DE9C4 File Offset: 0x000DCBC4
	// (set) Token: 0x06001698 RID: 5784 RVA: 0x000DE9F4 File Offset: 0x000DCBF4
	public static int Alerts
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Alerts");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Alerts", value);
		}
	}

	// Token: 0x170003F8 RID: 1016
	// (get) Token: 0x06001699 RID: 5785 RVA: 0x000DEA24 File Offset: 0x000DCC24
	// (set) Token: 0x0600169A RID: 5786 RVA: 0x000DEA54 File Offset: 0x000DCC54
	public static int Enlightenment
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Enlightenment");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Enlightenment", value);
		}
	}

	// Token: 0x170003F9 RID: 1017
	// (get) Token: 0x0600169B RID: 5787 RVA: 0x000DEA84 File Offset: 0x000DCC84
	// (set) Token: 0x0600169C RID: 5788 RVA: 0x000DEAB4 File Offset: 0x000DCCB4
	public static int EnlightenmentBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_EnlightenmentBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_EnlightenmentBonus", value);
		}
	}

	// Token: 0x170003FA RID: 1018
	// (get) Token: 0x0600169D RID: 5789 RVA: 0x000DEAE4 File Offset: 0x000DCCE4
	// (set) Token: 0x0600169E RID: 5790 RVA: 0x000DEB14 File Offset: 0x000DCD14
	public static int Friends
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Friends");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Friends", value);
		}
	}

	// Token: 0x170003FB RID: 1019
	// (get) Token: 0x0600169F RID: 5791 RVA: 0x000DEB44 File Offset: 0x000DCD44
	// (set) Token: 0x060016A0 RID: 5792 RVA: 0x000DEB74 File Offset: 0x000DCD74
	public static bool Headset
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_Headset");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_Headset", value);
		}
	}

	// Token: 0x170003FC RID: 1020
	// (get) Token: 0x060016A1 RID: 5793 RVA: 0x000DEBA4 File Offset: 0x000DCDA4
	// (set) Token: 0x060016A2 RID: 5794 RVA: 0x000DEBD4 File Offset: 0x000DCDD4
	public static bool DirectionalMic
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_DirectionalMic");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_DirectionalMic", value);
		}
	}

	// Token: 0x170003FD RID: 1021
	// (get) Token: 0x060016A3 RID: 5795 RVA: 0x000DEC04 File Offset: 0x000DCE04
	// (set) Token: 0x060016A4 RID: 5796 RVA: 0x000DEC34 File Offset: 0x000DCE34
	public static bool FakeID
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_FakeID");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_FakeID", value);
		}
	}

	// Token: 0x170003FE RID: 1022
	// (get) Token: 0x060016A5 RID: 5797 RVA: 0x000DEC64 File Offset: 0x000DCE64
	// (set) Token: 0x060016A6 RID: 5798 RVA: 0x000DEC94 File Offset: 0x000DCE94
	public static bool RaibaruLoner
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_RaibaruLoner");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_RaibaruLoner", value);
		}
	}

	// Token: 0x170003FF RID: 1023
	// (get) Token: 0x060016A7 RID: 5799 RVA: 0x000DECC4 File Offset: 0x000DCEC4
	// (set) Token: 0x060016A8 RID: 5800 RVA: 0x000DECF4 File Offset: 0x000DCEF4
	public static int Kills
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Kills");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Kills", value);
		}
	}

	// Token: 0x17000400 RID: 1024
	// (get) Token: 0x060016A9 RID: 5801 RVA: 0x000DED24 File Offset: 0x000DCF24
	// (set) Token: 0x060016AA RID: 5802 RVA: 0x000DED54 File Offset: 0x000DCF54
	public static int CorpsesDiscovered
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_CorpsesDiscovered");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_CorpsesDiscovered", value);
		}
	}

	// Token: 0x17000401 RID: 1025
	// (get) Token: 0x060016AB RID: 5803 RVA: 0x000DED84 File Offset: 0x000DCF84
	// (set) Token: 0x060016AC RID: 5804 RVA: 0x000DEDB4 File Offset: 0x000DCFB4
	public static int Numbness
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Numbness");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Numbness", value);
		}
	}

	// Token: 0x17000402 RID: 1026
	// (get) Token: 0x060016AD RID: 5805 RVA: 0x000DEDE4 File Offset: 0x000DCFE4
	// (set) Token: 0x060016AE RID: 5806 RVA: 0x000DEE14 File Offset: 0x000DD014
	public static int NumbnessBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_NumbnessBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_NumbnessBonus", value);
		}
	}

	// Token: 0x17000403 RID: 1027
	// (get) Token: 0x060016AF RID: 5807 RVA: 0x000DEE44 File Offset: 0x000DD044
	// (set) Token: 0x060016B0 RID: 5808 RVA: 0x000DEE74 File Offset: 0x000DD074
	public static int PantiesEquipped
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_PantiesEquipped");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_PantiesEquipped", value);
		}
	}

	// Token: 0x17000404 RID: 1028
	// (get) Token: 0x060016B1 RID: 5809 RVA: 0x000DEEA4 File Offset: 0x000DD0A4
	// (set) Token: 0x060016B2 RID: 5810 RVA: 0x000DEED4 File Offset: 0x000DD0D4
	public static int PantyShots
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_PantyShots");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_PantyShots", value);
		}
	}

	// Token: 0x060016B3 RID: 5811 RVA: 0x000DEF04 File Offset: 0x000DD104
	public static bool GetPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_Photo_" + photoID.ToString());
	}

	// Token: 0x060016B4 RID: 5812 RVA: 0x000DEF3C File Offset: 0x000DD13C
	public static void SetPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_Photo_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_Photo_" + text, value);
	}

	// Token: 0x060016B5 RID: 5813 RVA: 0x000DEF98 File Offset: 0x000DD198
	public static int[] KeysOfPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_Photo_");
	}

	// Token: 0x060016B6 RID: 5814 RVA: 0x000DEFC8 File Offset: 0x000DD1C8
	public static bool GetPhotoOnCorkboard(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_" + photoID.ToString());
	}

	// Token: 0x060016B7 RID: 5815 RVA: 0x000DF000 File Offset: 0x000DD200
	public static void SetPhotoOnCorkboard(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_" + text, value);
	}

	// Token: 0x060016B8 RID: 5816 RVA: 0x000DF05C File Offset: 0x000DD25C
	public static int[] KeysOfPhotoOnCorkboard()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_");
	}

	// Token: 0x060016B9 RID: 5817 RVA: 0x000DF08C File Offset: 0x000DD28C
	public static Vector2 GetPhotoPosition(int photoID)
	{
		return GlobalsHelper.GetVector2("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_" + photoID.ToString());
	}

	// Token: 0x060016BA RID: 5818 RVA: 0x000DF0C4 File Offset: 0x000DD2C4
	public static void SetPhotoPosition(int photoID, Vector2 value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_", text);
		GlobalsHelper.SetVector2("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_" + text, value);
	}

	// Token: 0x060016BB RID: 5819 RVA: 0x000DF120 File Offset: 0x000DD320
	public static int[] KeysOfPhotoPosition()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_");
	}

	// Token: 0x060016BC RID: 5820 RVA: 0x000DF150 File Offset: 0x000DD350
	public static float GetPhotoRotation(int photoID)
	{
		return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_" + photoID.ToString());
	}

	// Token: 0x060016BD RID: 5821 RVA: 0x000DF188 File Offset: 0x000DD388
	public static void SetPhotoRotation(int photoID, float value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_", text);
		PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_" + text, value);
	}

	// Token: 0x060016BE RID: 5822 RVA: 0x000DF1E4 File Offset: 0x000DD3E4
	public static int[] KeysOfPhotoRotation()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_");
	}

	// Token: 0x17000405 RID: 1029
	// (get) Token: 0x060016BF RID: 5823 RVA: 0x000DF214 File Offset: 0x000DD414
	// (set) Token: 0x060016C0 RID: 5824 RVA: 0x000DF244 File Offset: 0x000DD444
	public static float Reputation
	{
		get
		{
			return PlayerPrefs.GetFloat("Profile_" + GameGlobals.Profile.ToString() + "_Reputation");
		}
		set
		{
			PlayerPrefs.SetFloat("Profile_" + GameGlobals.Profile.ToString() + "_Reputation", value);
		}
	}

	// Token: 0x17000406 RID: 1030
	// (get) Token: 0x060016C1 RID: 5825 RVA: 0x000DF274 File Offset: 0x000DD474
	// (set) Token: 0x060016C2 RID: 5826 RVA: 0x000DF2A4 File Offset: 0x000DD4A4
	public static int Seduction
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_Seduction");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_Seduction", value);
		}
	}

	// Token: 0x17000407 RID: 1031
	// (get) Token: 0x060016C3 RID: 5827 RVA: 0x000DF2D4 File Offset: 0x000DD4D4
	// (set) Token: 0x060016C4 RID: 5828 RVA: 0x000DF304 File Offset: 0x000DD504
	public static int SeductionBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SeductionBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SeductionBonus", value);
		}
	}

	// Token: 0x060016C5 RID: 5829 RVA: 0x000DF334 File Offset: 0x000DD534
	public static bool GetSenpaiPhoto(int photoID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_" + photoID.ToString());
	}

	// Token: 0x060016C6 RID: 5830 RVA: 0x000DF36C File Offset: 0x000DD56C
	public static void SetSenpaiPhoto(int photoID, bool value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_" + text, value);
	}

	// Token: 0x060016C7 RID: 5831 RVA: 0x000DF3C8 File Offset: 0x000DD5C8
	public static int GetBullyPhoto(int photoID)
	{
		return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_" + photoID.ToString());
	}

	// Token: 0x060016C8 RID: 5832 RVA: 0x000DF400 File Offset: 0x000DD600
	public static void SetBullyPhoto(int photoID, int value)
	{
		string text = photoID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_", text);
		PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_" + text, value);
	}

	// Token: 0x060016C9 RID: 5833 RVA: 0x000DF45C File Offset: 0x000DD65C
	public static int[] KeysOfBullyPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_");
	}

	// Token: 0x060016CA RID: 5834 RVA: 0x000DF48C File Offset: 0x000DD68C
	public static int[] KeysOfSenpaiPhoto()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_");
	}

	// Token: 0x17000408 RID: 1032
	// (get) Token: 0x060016CB RID: 5835 RVA: 0x000DF4BC File Offset: 0x000DD6BC
	// (set) Token: 0x060016CC RID: 5836 RVA: 0x000DF4EC File Offset: 0x000DD6EC
	public static int SenpaiShots
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiShots");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiShots", value);
		}
	}

	// Token: 0x17000409 RID: 1033
	// (get) Token: 0x060016CD RID: 5837 RVA: 0x000DF51C File Offset: 0x000DD71C
	// (set) Token: 0x060016CE RID: 5838 RVA: 0x000DF54C File Offset: 0x000DD74C
	public static int SenpaiShotsTexted
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiShotsTexted");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiShotsTexted", value);
		}
	}

	// Token: 0x1700040A RID: 1034
	// (get) Token: 0x060016CF RID: 5839 RVA: 0x000DF57C File Offset: 0x000DD77C
	// (set) Token: 0x060016D0 RID: 5840 RVA: 0x000DF5AC File Offset: 0x000DD7AC
	public static int SocialBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SocialBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SocialBonus", value);
		}
	}

	// Token: 0x1700040B RID: 1035
	// (get) Token: 0x060016D1 RID: 5841 RVA: 0x000DF5DC File Offset: 0x000DD7DC
	// (set) Token: 0x060016D2 RID: 5842 RVA: 0x000DF60C File Offset: 0x000DD80C
	public static int SpeedBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_SpeedBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_SpeedBonus", value);
		}
	}

	// Token: 0x1700040C RID: 1036
	// (get) Token: 0x060016D3 RID: 5843 RVA: 0x000DF63C File Offset: 0x000DD83C
	// (set) Token: 0x060016D4 RID: 5844 RVA: 0x000DF66C File Offset: 0x000DD86C
	public static int StealthBonus
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_StealthBonus");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_StealthBonus", value);
		}
	}

	// Token: 0x060016D5 RID: 5845 RVA: 0x000DF69C File Offset: 0x000DD89C
	public static bool GetStudentFriend(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_" + studentID.ToString());
	}

	// Token: 0x060016D6 RID: 5846 RVA: 0x000DF6D4 File Offset: 0x000DD8D4
	public static void SetStudentFriend(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_" + text, value);
	}

	// Token: 0x060016D7 RID: 5847 RVA: 0x000DF730 File Offset: 0x000DD930
	public static int[] KeysOfStudentFriend()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_");
	}

	// Token: 0x060016D8 RID: 5848 RVA: 0x000DF760 File Offset: 0x000DD960
	public static bool GetStudentPantyShot(int studentID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_" + studentID.ToString());
	}

	// Token: 0x060016D9 RID: 5849 RVA: 0x000DF798 File Offset: 0x000DD998
	public static void SetStudentPantyShot(int studentID, bool value)
	{
		string text = studentID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_" + text, value);
	}

	// Token: 0x060016DA RID: 5850 RVA: 0x000DF7F4 File Offset: 0x000DD9F4
	public static int[] KeysOfStudentPantyShot()
	{
		return KeysHelper.GetIntegerKeys("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_");
	}

	// Token: 0x060016DB RID: 5851 RVA: 0x000DF824 File Offset: 0x000DDA24
	public static string[] KeysOfShrineCollectible()
	{
		return KeysHelper.GetStringKeys("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_");
	}

	// Token: 0x060016DC RID: 5852 RVA: 0x000DF854 File Offset: 0x000DDA54
	public static bool GetShrineCollectible(int ID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_" + ID.ToString());
	}

	// Token: 0x060016DD RID: 5853 RVA: 0x000DF88C File Offset: 0x000DDA8C
	public static void SetShrineCollectible(int ID, bool value)
	{
		string text = ID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_" + text, value);
	}

	// Token: 0x1700040D RID: 1037
	// (get) Token: 0x060016DE RID: 5854 RVA: 0x000DF8E8 File Offset: 0x000DDAE8
	// (set) Token: 0x060016DF RID: 5855 RVA: 0x000DF918 File Offset: 0x000DDB18
	public static bool UsingGamepad
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_UsingGamepad");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_UsingGamepad", value);
		}
	}

	// Token: 0x1700040E RID: 1038
	// (get) Token: 0x060016E0 RID: 5856 RVA: 0x000DF948 File Offset: 0x000DDB48
	// (set) Token: 0x060016E1 RID: 5857 RVA: 0x000DF978 File Offset: 0x000DDB78
	public static int PersonaID
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_PersonaID");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_PersonaID", value);
		}
	}

	// Token: 0x1700040F RID: 1039
	// (get) Token: 0x060016E2 RID: 5858 RVA: 0x000DF9A8 File Offset: 0x000DDBA8
	// (set) Token: 0x060016E3 RID: 5859 RVA: 0x000DF9D8 File Offset: 0x000DDBD8
	public static int ShrineItems
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_ShrineItems");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_ShrineItems", value);
		}
	}

	// Token: 0x17000410 RID: 1040
	// (get) Token: 0x060016E4 RID: 5860 RVA: 0x000DFA08 File Offset: 0x000DDC08
	// (set) Token: 0x060016E5 RID: 5861 RVA: 0x000DFA38 File Offset: 0x000DDC38
	public static int BringingItem
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BringingItem");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BringingItem", value);
		}
	}

	// Token: 0x060016E6 RID: 5862 RVA: 0x000DFA68 File Offset: 0x000DDC68
	public static string[] KeysOfCannotBringItem()
	{
		return KeysHelper.GetStringKeys("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem");
	}

	// Token: 0x060016E7 RID: 5863 RVA: 0x000DFA98 File Offset: 0x000DDC98
	public static bool GetCannotBringItem(int ID)
	{
		return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem" + ID.ToString());
	}

	// Token: 0x060016E8 RID: 5864 RVA: 0x000DFAD0 File Offset: 0x000DDCD0
	public static void SetCannotBringItem(int ID, bool value)
	{
		string text = ID.ToString();
		KeysHelper.AddIfMissing("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem", text);
		GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem" + text, value);
	}

	// Token: 0x17000411 RID: 1041
	// (get) Token: 0x060016E9 RID: 5865 RVA: 0x000DFB2C File Offset: 0x000DDD2C
	// (set) Token: 0x060016EA RID: 5866 RVA: 0x000DFB5C File Offset: 0x000DDD5C
	public static bool BoughtLockpick
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BoughtLockpick");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BoughtLockpick", value);
		}
	}

	// Token: 0x17000412 RID: 1042
	// (get) Token: 0x060016EB RID: 5867 RVA: 0x000DFB8C File Offset: 0x000DDD8C
	// (set) Token: 0x060016EC RID: 5868 RVA: 0x000DFBBC File Offset: 0x000DDDBC
	public static bool BoughtSedative
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BoughtSedative");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BoughtSedative", value);
		}
	}

	// Token: 0x17000413 RID: 1043
	// (get) Token: 0x060016ED RID: 5869 RVA: 0x000DFBEC File Offset: 0x000DDDEC
	// (set) Token: 0x060016EE RID: 5870 RVA: 0x000DFC1C File Offset: 0x000DDE1C
	public static bool BoughtNarcotics
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BoughtNarcotics");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BoughtNarcotics", value);
		}
	}

	// Token: 0x17000414 RID: 1044
	// (get) Token: 0x060016EF RID: 5871 RVA: 0x000DFC4C File Offset: 0x000DDE4C
	// (set) Token: 0x060016F0 RID: 5872 RVA: 0x000DFC7C File Offset: 0x000DDE7C
	public static bool BoughtPoison
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BoughtPoison");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BoughtPoison", value);
		}
	}

	// Token: 0x17000415 RID: 1045
	// (get) Token: 0x060016F1 RID: 5873 RVA: 0x000DFCAC File Offset: 0x000DDEAC
	// (set) Token: 0x060016F2 RID: 5874 RVA: 0x000DFCDC File Offset: 0x000DDEDC
	public static bool BoughtExplosive
	{
		get
		{
			return GlobalsHelper.GetBool("Profile_" + GameGlobals.Profile.ToString() + "_BoughtExplosive");
		}
		set
		{
			GlobalsHelper.SetBool("Profile_" + GameGlobals.Profile.ToString() + "_BoughtExplosive", value);
		}
	}

	// Token: 0x17000416 RID: 1046
	// (get) Token: 0x060016F3 RID: 5875 RVA: 0x000DFD0C File Offset: 0x000DDF0C
	// (set) Token: 0x060016F4 RID: 5876 RVA: 0x000DFD3C File Offset: 0x000DDF3C
	public static int PoliceVisits
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_PoliceVisits");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_PoliceVisits", value);
		}
	}

	// Token: 0x17000417 RID: 1047
	// (get) Token: 0x060016F5 RID: 5877 RVA: 0x000DFD6C File Offset: 0x000DDF6C
	// (set) Token: 0x060016F6 RID: 5878 RVA: 0x000DFD9C File Offset: 0x000DDF9C
	public static int BloodWitnessed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_BloodWitnessed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_BloodWitnessed", value);
		}
	}

	// Token: 0x17000418 RID: 1048
	// (get) Token: 0x060016F7 RID: 5879 RVA: 0x000DFDCC File Offset: 0x000DDFCC
	// (set) Token: 0x060016F8 RID: 5880 RVA: 0x000DFDFC File Offset: 0x000DDFFC
	public static int WeaponWitnessed
	{
		get
		{
			return PlayerPrefs.GetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponWitnessed");
		}
		set
		{
			PlayerPrefs.SetInt("Profile_" + GameGlobals.Profile.ToString() + "_WeaponWitnessed", value);
		}
	}

	// Token: 0x060016F9 RID: 5881 RVA: 0x000DFE2C File Offset: 0x000DE02C
	public static void DeleteAll()
	{
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Money");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Alerts");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Enlightenment");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_EnlightenmentBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Friends");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Headset");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_DirectionalMic");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_FakeID");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_RaibaruLoner");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Kills");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_CorpsesDiscovered");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Numbness");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_NumbnessBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PantiesEquipped");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PantyShots");
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_Photo_", PlayerGlobals.KeysOfPhoto());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_PhotoOnCorkboard_", PlayerGlobals.KeysOfPhotoOnCorkboard());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_PhotoPosition_", PlayerGlobals.KeysOfPhotoPosition());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_PhotoRotation_", PlayerGlobals.KeysOfPhotoRotation());
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Reputation");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_Seduction");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SeductionBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiShots");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiShotsTexted");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SocialBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_SpeedBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_StealthBonus");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PersonaID");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_ShrineItems");
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_BullyPhoto_", PlayerGlobals.KeysOfBullyPhoto());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_SenpaiPhoto_", PlayerGlobals.KeysOfSenpaiPhoto());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentFriend_", PlayerGlobals.KeysOfStudentFriend());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_StudentPantyShot_", PlayerGlobals.KeysOfStudentPantyShot());
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_ShrineCollectible_", PlayerGlobals.KeysOfShrineCollectible());
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BringingItem");
		Globals.DeleteCollection("Profile_" + GameGlobals.Profile.ToString() + "_CannotBringItem", PlayerGlobals.KeysOfCannotBringItem());
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BoughtLockpick");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BoughtSedative");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BoughtNarcotics");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BoughtPoison");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BoughtExplosive");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_PoliceVisits");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_BloodWitnessed");
		Globals.Delete("Profile_" + GameGlobals.Profile.ToString() + "_WeaponWitnessed");
	}

	// Token: 0x04002275 RID: 8821
	private const string Str_Money = "Money";

	// Token: 0x04002276 RID: 8822
	private const string Str_Alerts = "Alerts";

	// Token: 0x04002277 RID: 8823
	private const string Str_BullyPhoto = "BullyPhoto_";

	// Token: 0x04002278 RID: 8824
	private const string Str_Enlightenment = "Enlightenment";

	// Token: 0x04002279 RID: 8825
	private const string Str_EnlightenmentBonus = "EnlightenmentBonus";

	// Token: 0x0400227A RID: 8826
	private const string Str_Friends = "Friends";

	// Token: 0x0400227B RID: 8827
	private const string Str_Headset = "Headset";

	// Token: 0x0400227C RID: 8828
	private const string Str_DirectionalMic = "DirectionalMic";

	// Token: 0x0400227D RID: 8829
	private const string Str_FakeID = "FakeID";

	// Token: 0x0400227E RID: 8830
	private const string Str_RaibaruLoner = "RaibaruLoner";

	// Token: 0x0400227F RID: 8831
	private const string Str_Kills = "Kills";

	// Token: 0x04002280 RID: 8832
	private const string Str_CorpsesDiscovered = "CorpsesDiscovered";

	// Token: 0x04002281 RID: 8833
	private const string Str_Numbness = "Numbness";

	// Token: 0x04002282 RID: 8834
	private const string Str_NumbnessBonus = "NumbnessBonus";

	// Token: 0x04002283 RID: 8835
	private const string Str_PantiesEquipped = "PantiesEquipped";

	// Token: 0x04002284 RID: 8836
	private const string Str_PantyShots = "PantyShots";

	// Token: 0x04002285 RID: 8837
	private const string Str_Photo = "Photo_";

	// Token: 0x04002286 RID: 8838
	private const string Str_PhotoOnCorkboard = "PhotoOnCorkboard_";

	// Token: 0x04002287 RID: 8839
	private const string Str_PhotoPosition = "PhotoPosition_";

	// Token: 0x04002288 RID: 8840
	private const string Str_PhotoRotation = "PhotoRotation_";

	// Token: 0x04002289 RID: 8841
	private const string Str_Reputation = "Reputation";

	// Token: 0x0400228A RID: 8842
	private const string Str_Seduction = "Seduction";

	// Token: 0x0400228B RID: 8843
	private const string Str_SeductionBonus = "SeductionBonus";

	// Token: 0x0400228C RID: 8844
	private const string Str_SenpaiPhoto = "SenpaiPhoto_";

	// Token: 0x0400228D RID: 8845
	private const string Str_SenpaiShots = "SenpaiShots";

	// Token: 0x0400228E RID: 8846
	private const string Str_SenpaiShotsTexted = "SenpaiShotsTexted";

	// Token: 0x0400228F RID: 8847
	private const string Str_SocialBonus = "SocialBonus";

	// Token: 0x04002290 RID: 8848
	private const string Str_SpeedBonus = "SpeedBonus";

	// Token: 0x04002291 RID: 8849
	private const string Str_StealthBonus = "StealthBonus";

	// Token: 0x04002292 RID: 8850
	private const string Str_StudentFriend = "StudentFriend_";

	// Token: 0x04002293 RID: 8851
	private const string Str_StudentPantyShot = "StudentPantyShot_";

	// Token: 0x04002294 RID: 8852
	private const string Str_ShrineCollectible = "ShrineCollectible_";

	// Token: 0x04002295 RID: 8853
	private const string Str_UsingGamepad = "UsingGamepad";

	// Token: 0x04002296 RID: 8854
	private const string Str_PersonaID = "PersonaID";

	// Token: 0x04002297 RID: 8855
	private const string Str_ShrineItems = "ShrineItems";

	// Token: 0x04002298 RID: 8856
	private const string Str_BringingItem = "BringingItem";

	// Token: 0x04002299 RID: 8857
	private const string Str_CannotBringItem = "CannotBringItem";

	// Token: 0x0400229A RID: 8858
	private const string Str_BoughtLockpick = "BoughtLockpick";

	// Token: 0x0400229B RID: 8859
	private const string Str_BoughtSedative = "BoughtSedative";

	// Token: 0x0400229C RID: 8860
	private const string Str_BoughtNarcotics = "BoughtNarcotics";

	// Token: 0x0400229D RID: 8861
	private const string Str_BoughtPoison = "BoughtPoison";

	// Token: 0x0400229E RID: 8862
	private const string Str_BoughtExplosive = "BoughtExplosive";

	// Token: 0x0400229F RID: 8863
	private const string Str_PoliceVisits = "PoliceVisits";

	// Token: 0x040022A0 RID: 8864
	private const string Str_BloodWitnessed = "BloodWitnessed";

	// Token: 0x040022A1 RID: 8865
	private const string Str_WeaponWitnessed = "WeaponWitnessed";
}
