﻿using System;
using UnityEngine;

// Token: 0x02000301 RID: 769
public static class CorkboardGlobals
{
	// Token: 0x06001812 RID: 6162 RVA: 0x000E3D3C File Offset: 0x000E1F3C
	public static void DeleteAll()
	{
		for (int i = 0; i < 100; i++)
		{
			PlayerPrefs.SetInt(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardPhoto_",
				i.ToString(),
				"_Exists"
			}), 0);
			PlayerPrefs.SetInt(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardPhoto_",
				i.ToString(),
				"_PhotoID"
			}), 0);
			PlayerPrefs.SetFloat(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardPhoto_",
				i.ToString(),
				"_PositionX"
			}), 0f);
			PlayerPrefs.SetFloat(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardPhoto_",
				i.ToString(),
				"_PositionY"
			}), 0f);
			PlayerPrefs.SetFloat(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardPhoto_",
				i.ToString(),
				"_PositionZ"
			}), 0f);
			PlayerPrefs.SetFloat(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardPhoto_",
				i.ToString(),
				"_RotationX"
			}), 0f);
			PlayerPrefs.SetFloat(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardPhoto_",
				i.ToString(),
				"_RotationY"
			}), 0f);
			PlayerPrefs.SetFloat(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardPhoto_",
				i.ToString(),
				"_RotationZ"
			}), 0f);
			PlayerPrefs.SetFloat(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardPhoto_",
				i.ToString(),
				"_ScaleX"
			}), 0f);
			PlayerPrefs.SetFloat(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardPhoto_",
				i.ToString(),
				"_ScaleY"
			}), 0f);
			PlayerPrefs.SetFloat(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardPhoto_",
				i.ToString(),
				"_ScaleZ"
			}), 0f);
			PlayerPrefs.SetInt(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardString_",
				i.ToString(),
				"_Exists"
			}), 0);
			PlayerPrefs.SetFloat(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardString_",
				i.ToString(),
				"_PositionX"
			}), 0f);
			PlayerPrefs.SetFloat(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardString_",
				i.ToString(),
				"_PositionY"
			}), 0f);
			PlayerPrefs.SetFloat(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardString_",
				i.ToString(),
				"_PositionZ"
			}), 0f);
			PlayerPrefs.SetFloat(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardString2_",
				i.ToString(),
				"_PositionX"
			}), 0f);
			PlayerPrefs.SetFloat(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardString2_",
				i.ToString(),
				"_PositionY"
			}), 0f);
			PlayerPrefs.SetFloat(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardString2_",
				i.ToString(),
				"_PositionZ"
			}), 0f);
		}
	}
}
