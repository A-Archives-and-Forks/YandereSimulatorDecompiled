﻿using System;

// Token: 0x02000402 RID: 1026
[Serializable]
public class SchoolSaveData
{
	// Token: 0x06001C12 RID: 7186 RVA: 0x00146BC8 File Offset: 0x00144DC8
	public static SchoolSaveData ReadFromGlobals()
	{
		SchoolSaveData schoolSaveData = new SchoolSaveData();
		foreach (int num in SchoolGlobals.KeysOfDemonActive())
		{
			if (SchoolGlobals.GetDemonActive(num))
			{
				schoolSaveData.demonActive.Add(num);
			}
		}
		foreach (int num2 in SchoolGlobals.KeysOfGardenGraveOccupied())
		{
			if (SchoolGlobals.GetGardenGraveOccupied(num2))
			{
				schoolSaveData.gardenGraveOccupied.Add(num2);
			}
		}
		schoolSaveData.kidnapVictim = SchoolGlobals.KidnapVictim;
		schoolSaveData.population = SchoolGlobals.Population;
		schoolSaveData.roofFence = SchoolGlobals.RoofFence;
		schoolSaveData.schoolAtmosphere = SchoolGlobals.SchoolAtmosphere;
		schoolSaveData.schoolAtmosphereSet = SchoolGlobals.SchoolAtmosphereSet;
		schoolSaveData.scp = SchoolGlobals.SCP;
		return schoolSaveData;
	}

	// Token: 0x06001C13 RID: 7187 RVA: 0x00146C7C File Offset: 0x00144E7C
	public static void WriteToGlobals(SchoolSaveData data)
	{
		foreach (int demonID in data.demonActive)
		{
			SchoolGlobals.SetDemonActive(demonID, true);
		}
		foreach (int graveID in data.gardenGraveOccupied)
		{
			SchoolGlobals.SetGardenGraveOccupied(graveID, true);
		}
		SchoolGlobals.KidnapVictim = data.kidnapVictim;
		SchoolGlobals.Population = data.population;
		SchoolGlobals.RoofFence = data.roofFence;
		SchoolGlobals.SchoolAtmosphere = data.schoolAtmosphere;
		SchoolGlobals.SchoolAtmosphereSet = data.schoolAtmosphereSet;
		SchoolGlobals.SCP = data.scp;
	}

	// Token: 0x04003151 RID: 12625
	public IntHashSet demonActive = new IntHashSet();

	// Token: 0x04003152 RID: 12626
	public IntHashSet gardenGraveOccupied = new IntHashSet();

	// Token: 0x04003153 RID: 12627
	public int kidnapVictim;

	// Token: 0x04003154 RID: 12628
	public int population;

	// Token: 0x04003155 RID: 12629
	public bool roofFence;

	// Token: 0x04003156 RID: 12630
	public float schoolAtmosphere;

	// Token: 0x04003157 RID: 12631
	public bool schoolAtmosphereSet;

	// Token: 0x04003158 RID: 12632
	public bool scp;
}
