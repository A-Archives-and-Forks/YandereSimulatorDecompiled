﻿using System;
using UnityEngine;

// Token: 0x020002F7 RID: 759
public static class PoseModeGlobals
{
	// Token: 0x17000418 RID: 1048
	// (get) Token: 0x060016EF RID: 5871 RVA: 0x000DF73C File Offset: 0x000DD93C
	// (set) Token: 0x060016F0 RID: 5872 RVA: 0x000DF76C File Offset: 0x000DD96C
	public static Vector3 PosePosition
	{
		get
		{
			return GlobalsHelper.GetVector3("Profile_" + GameGlobals.Profile.ToString() + "_PosePosition");
		}
		set
		{
			GlobalsHelper.SetVector3("Profile_" + GameGlobals.Profile.ToString() + "_PosePosition", value);
		}
	}

	// Token: 0x17000419 RID: 1049
	// (get) Token: 0x060016F1 RID: 5873 RVA: 0x000DF79C File Offset: 0x000DD99C
	// (set) Token: 0x060016F2 RID: 5874 RVA: 0x000DF7CC File Offset: 0x000DD9CC
	public static Vector3 PoseRotation
	{
		get
		{
			return GlobalsHelper.GetVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseRotation");
		}
		set
		{
			GlobalsHelper.SetVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseRotation", value);
		}
	}

	// Token: 0x1700041A RID: 1050
	// (get) Token: 0x060016F3 RID: 5875 RVA: 0x000DF7FC File Offset: 0x000DD9FC
	// (set) Token: 0x060016F4 RID: 5876 RVA: 0x000DF82C File Offset: 0x000DDA2C
	public static Vector3 PoseScale
	{
		get
		{
			return GlobalsHelper.GetVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseScale");
		}
		set
		{
			GlobalsHelper.SetVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseScale", value);
		}
	}

	// Token: 0x060016F5 RID: 5877 RVA: 0x000DF85C File Offset: 0x000DDA5C
	public static void DeleteAll()
	{
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PosePosition");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseRotation");
		GlobalsHelper.DeleteVector3("Profile_" + GameGlobals.Profile.ToString() + "_PoseScale");
	}

	// Token: 0x0400226F RID: 8815
	private const string Str_PosePosition = "PosePosition";

	// Token: 0x04002270 RID: 8816
	private const string Str_PoseRotation = "PoseRotation";

	// Token: 0x04002271 RID: 8817
	private const string Str_PoseScale = "PoseScale";
}
