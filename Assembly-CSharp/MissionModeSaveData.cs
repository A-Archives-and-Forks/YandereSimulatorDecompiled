﻿using System;
using System.Collections.Generic;

// Token: 0x02000405 RID: 1029
[Serializable]
public class MissionModeSaveData
{
	// Token: 0x06001C41 RID: 7233 RVA: 0x0014AB38 File Offset: 0x00148D38
	public static MissionModeSaveData ReadFromGlobals()
	{
		MissionModeSaveData missionModeSaveData = new MissionModeSaveData();
		foreach (int num in MissionModeGlobals.KeysOfMissionCondition())
		{
			missionModeSaveData.missionCondition.Add(num, MissionModeGlobals.GetMissionCondition(num));
		}
		missionModeSaveData.missionDifficulty = MissionModeGlobals.MissionDifficulty;
		missionModeSaveData.missionMode = MissionModeGlobals.MissionMode;
		missionModeSaveData.missionRequiredClothing = MissionModeGlobals.MissionRequiredClothing;
		missionModeSaveData.missionRequiredDisposal = MissionModeGlobals.MissionRequiredDisposal;
		missionModeSaveData.missionRequiredWeapon = MissionModeGlobals.MissionRequiredWeapon;
		missionModeSaveData.missionTarget = MissionModeGlobals.MissionTarget;
		missionModeSaveData.missionTargetName = MissionModeGlobals.MissionTargetName;
		missionModeSaveData.nemesisDifficulty = MissionModeGlobals.NemesisDifficulty;
		return missionModeSaveData;
	}

	// Token: 0x06001C42 RID: 7234 RVA: 0x0014ABD0 File Offset: 0x00148DD0
	public static void WriteToGlobals(MissionModeSaveData data)
	{
		foreach (KeyValuePair<int, int> keyValuePair in data.missionCondition)
		{
			MissionModeGlobals.SetMissionCondition(keyValuePair.Key, keyValuePair.Value);
		}
		MissionModeGlobals.MissionDifficulty = data.missionDifficulty;
		MissionModeGlobals.MissionMode = data.missionMode;
		MissionModeGlobals.MissionRequiredClothing = data.missionRequiredClothing;
		MissionModeGlobals.MissionRequiredDisposal = data.missionRequiredDisposal;
		MissionModeGlobals.MissionRequiredWeapon = data.missionRequiredWeapon;
		MissionModeGlobals.MissionTarget = data.missionTarget;
		MissionModeGlobals.MissionTargetName = data.missionTargetName;
		MissionModeGlobals.NemesisDifficulty = data.nemesisDifficulty;
	}

	// Token: 0x040031CD RID: 12749
	public IntAndIntDictionary missionCondition = new IntAndIntDictionary();

	// Token: 0x040031CE RID: 12750
	public int missionDifficulty;

	// Token: 0x040031CF RID: 12751
	public bool missionMode;

	// Token: 0x040031D0 RID: 12752
	public int missionRequiredClothing;

	// Token: 0x040031D1 RID: 12753
	public int missionRequiredDisposal;

	// Token: 0x040031D2 RID: 12754
	public int missionRequiredWeapon;

	// Token: 0x040031D3 RID: 12755
	public int missionTarget;

	// Token: 0x040031D4 RID: 12756
	public string missionTargetName = string.Empty;

	// Token: 0x040031D5 RID: 12757
	public int nemesisDifficulty;
}
