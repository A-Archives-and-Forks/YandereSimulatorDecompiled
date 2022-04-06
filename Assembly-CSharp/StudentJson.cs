﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

// Token: 0x02000346 RID: 838
[Serializable]
public class StudentJson : JsonData
{
	// Token: 0x1700047B RID: 1147
	// (get) Token: 0x06001921 RID: 6433 RVA: 0x000FCC4F File Offset: 0x000FAE4F
	public static string FilePath
	{
		get
		{
			if (!GameGlobals.Eighties)
			{
				return Path.Combine(JsonData.FolderPath, "Students.json");
			}
			return Path.Combine(JsonData.FolderPath, "Eighties.json");
		}
	}

	// Token: 0x06001922 RID: 6434 RVA: 0x000FCC78 File Offset: 0x000FAE78
	public static StudentJson[] LoadFromJson(string path)
	{
		StudentJson[] array = new StudentJson[101];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new StudentJson();
		}
		foreach (Dictionary<string, object> dictionary in JsonData.Deserialize(path))
		{
			int num = TFUtils.LoadInt(dictionary, "ID");
			if (num == 0)
			{
				break;
			}
			StudentJson studentJson = array[num];
			studentJson.name = TFUtils.LoadString(dictionary, "Name");
			studentJson.realname = TFUtils.LoadString(dictionary, "RealName");
			studentJson.gender = TFUtils.LoadInt(dictionary, "Gender");
			studentJson.classID = TFUtils.LoadInt(dictionary, "Class");
			studentJson.seat = TFUtils.LoadInt(dictionary, "Seat");
			studentJson.club = (ClubType)TFUtils.LoadInt(dictionary, "Club");
			studentJson.persona = (PersonaType)TFUtils.LoadInt(dictionary, "Persona");
			studentJson.crush = TFUtils.LoadInt(dictionary, "Crush");
			studentJson.breastSize = TFUtils.LoadFloat(dictionary, "BreastSize");
			studentJson.strength = TFUtils.LoadInt(dictionary, "Strength");
			studentJson.hairstyle = TFUtils.LoadString(dictionary, "Hairstyle");
			studentJson.color = TFUtils.LoadString(dictionary, "Color");
			studentJson.eyes = TFUtils.LoadString(dictionary, "Eyes");
			studentJson.eyeType = TFUtils.LoadString(dictionary, "EyeType");
			studentJson.stockings = TFUtils.LoadString(dictionary, "Stockings");
			studentJson.accessory = TFUtils.LoadString(dictionary, "Accessory");
			studentJson.info = TFUtils.LoadString(dictionary, "Info");
			if (GameGlobals.LoveSick)
			{
				studentJson.name = studentJson.realname;
				studentJson.realname = "";
			}
			if (OptionGlobals.HighPopulation && studentJson.name == "Unknown")
			{
				studentJson.name = "Random";
			}
			float[] array3 = StudentJson.ConstructTempFloatArray(TFUtils.LoadString(dictionary, "ScheduleTime"));
			string[] array4 = StudentJson.ConstructTempStringArray(TFUtils.LoadString(dictionary, "ScheduleDestination"));
			string[] array5 = StudentJson.ConstructTempStringArray(TFUtils.LoadString(dictionary, "ScheduleAction"));
			studentJson.scheduleBlocks = new ScheduleBlock[array3.Length];
			for (int k = 0; k < studentJson.scheduleBlocks.Length; k++)
			{
				studentJson.scheduleBlocks[k] = new ScheduleBlock(array3[k], array4[k], array5[k]);
			}
			studentJson.success = true;
		}
		return array;
	}

	// Token: 0x1700047C RID: 1148
	// (get) Token: 0x06001923 RID: 6435 RVA: 0x000FCEF0 File Offset: 0x000FB0F0
	// (set) Token: 0x06001924 RID: 6436 RVA: 0x000FCEF8 File Offset: 0x000FB0F8
	public string Name
	{
		get
		{
			return this.name;
		}
		set
		{
			this.name = value;
		}
	}

	// Token: 0x1700047D RID: 1149
	// (get) Token: 0x06001925 RID: 6437 RVA: 0x000FCF01 File Offset: 0x000FB101
	// (set) Token: 0x06001926 RID: 6438 RVA: 0x000FCF09 File Offset: 0x000FB109
	public string RealName
	{
		get
		{
			return this.realname;
		}
		set
		{
			this.realname = value;
		}
	}

	// Token: 0x1700047E RID: 1150
	// (get) Token: 0x06001927 RID: 6439 RVA: 0x000FCF12 File Offset: 0x000FB112
	public int Gender
	{
		get
		{
			return this.gender;
		}
	}

	// Token: 0x1700047F RID: 1151
	// (get) Token: 0x06001928 RID: 6440 RVA: 0x000FCF1A File Offset: 0x000FB11A
	// (set) Token: 0x06001929 RID: 6441 RVA: 0x000FCF22 File Offset: 0x000FB122
	public int Class
	{
		get
		{
			return this.classID;
		}
		set
		{
			this.classID = value;
		}
	}

	// Token: 0x17000480 RID: 1152
	// (get) Token: 0x0600192A RID: 6442 RVA: 0x000FCF2B File Offset: 0x000FB12B
	// (set) Token: 0x0600192B RID: 6443 RVA: 0x000FCF33 File Offset: 0x000FB133
	public int Seat
	{
		get
		{
			return this.seat;
		}
		set
		{
			this.seat = value;
		}
	}

	// Token: 0x17000481 RID: 1153
	// (get) Token: 0x0600192C RID: 6444 RVA: 0x000FCF3C File Offset: 0x000FB13C
	public ClubType Club
	{
		get
		{
			return this.club;
		}
	}

	// Token: 0x17000482 RID: 1154
	// (get) Token: 0x0600192D RID: 6445 RVA: 0x000FCF44 File Offset: 0x000FB144
	// (set) Token: 0x0600192E RID: 6446 RVA: 0x000FCF4C File Offset: 0x000FB14C
	public PersonaType Persona
	{
		get
		{
			return this.persona;
		}
		set
		{
			this.persona = value;
		}
	}

	// Token: 0x17000483 RID: 1155
	// (get) Token: 0x0600192F RID: 6447 RVA: 0x000FCF55 File Offset: 0x000FB155
	public int Crush
	{
		get
		{
			return this.crush;
		}
	}

	// Token: 0x17000484 RID: 1156
	// (get) Token: 0x06001930 RID: 6448 RVA: 0x000FCF5D File Offset: 0x000FB15D
	// (set) Token: 0x06001931 RID: 6449 RVA: 0x000FCF65 File Offset: 0x000FB165
	public float BreastSize
	{
		get
		{
			return this.breastSize;
		}
		set
		{
			this.breastSize = value;
		}
	}

	// Token: 0x17000485 RID: 1157
	// (get) Token: 0x06001932 RID: 6450 RVA: 0x000FCF6E File Offset: 0x000FB16E
	// (set) Token: 0x06001933 RID: 6451 RVA: 0x000FCF76 File Offset: 0x000FB176
	public int Strength
	{
		get
		{
			return this.strength;
		}
		set
		{
			this.strength = value;
		}
	}

	// Token: 0x17000486 RID: 1158
	// (get) Token: 0x06001934 RID: 6452 RVA: 0x000FCF7F File Offset: 0x000FB17F
	// (set) Token: 0x06001935 RID: 6453 RVA: 0x000FCF87 File Offset: 0x000FB187
	public string Hairstyle
	{
		get
		{
			return this.hairstyle;
		}
		set
		{
			this.hairstyle = value;
		}
	}

	// Token: 0x17000487 RID: 1159
	// (get) Token: 0x06001936 RID: 6454 RVA: 0x000FCF90 File Offset: 0x000FB190
	public string Color
	{
		get
		{
			return this.color;
		}
	}

	// Token: 0x17000488 RID: 1160
	// (get) Token: 0x06001937 RID: 6455 RVA: 0x000FCF98 File Offset: 0x000FB198
	public string Eyes
	{
		get
		{
			return this.eyes;
		}
	}

	// Token: 0x17000489 RID: 1161
	// (get) Token: 0x06001938 RID: 6456 RVA: 0x000FCFA0 File Offset: 0x000FB1A0
	public string EyeType
	{
		get
		{
			return this.eyeType;
		}
	}

	// Token: 0x1700048A RID: 1162
	// (get) Token: 0x06001939 RID: 6457 RVA: 0x000FCFA8 File Offset: 0x000FB1A8
	public string Stockings
	{
		get
		{
			return this.stockings;
		}
	}

	// Token: 0x1700048B RID: 1163
	// (get) Token: 0x0600193A RID: 6458 RVA: 0x000FCFB0 File Offset: 0x000FB1B0
	// (set) Token: 0x0600193B RID: 6459 RVA: 0x000FCFB8 File Offset: 0x000FB1B8
	public string Accessory
	{
		get
		{
			return this.accessory;
		}
		set
		{
			this.accessory = value;
		}
	}

	// Token: 0x1700048C RID: 1164
	// (get) Token: 0x0600193C RID: 6460 RVA: 0x000FCFC1 File Offset: 0x000FB1C1
	public string Info
	{
		get
		{
			return this.info;
		}
	}

	// Token: 0x1700048D RID: 1165
	// (get) Token: 0x0600193D RID: 6461 RVA: 0x000FCFC9 File Offset: 0x000FB1C9
	public ScheduleBlock[] ScheduleBlocks
	{
		get
		{
			return this.scheduleBlocks;
		}
	}

	// Token: 0x1700048E RID: 1166
	// (get) Token: 0x0600193E RID: 6462 RVA: 0x000FCFD1 File Offset: 0x000FB1D1
	public bool Success
	{
		get
		{
			return this.success;
		}
	}

	// Token: 0x0600193F RID: 6463 RVA: 0x000FCFDC File Offset: 0x000FB1DC
	private static float[] ConstructTempFloatArray(string str)
	{
		string[] array = str.Split(new char[]
		{
			'_'
		});
		float[] array2 = new float[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			float num;
			if (float.TryParse(array[i], NumberStyles.Float, NumberFormatInfo.InvariantInfo, out num))
			{
				array2[i] = num;
			}
		}
		return array2;
	}

	// Token: 0x06001940 RID: 6464 RVA: 0x000FD02D File Offset: 0x000FB22D
	private static string[] ConstructTempStringArray(string str)
	{
		return str.Split(new char[]
		{
			'_'
		});
	}

	// Token: 0x04002792 RID: 10130
	[SerializeField]
	private string name;

	// Token: 0x04002793 RID: 10131
	[SerializeField]
	private string realname;

	// Token: 0x04002794 RID: 10132
	[SerializeField]
	private int gender;

	// Token: 0x04002795 RID: 10133
	[SerializeField]
	private int classID;

	// Token: 0x04002796 RID: 10134
	[SerializeField]
	private int seat;

	// Token: 0x04002797 RID: 10135
	[SerializeField]
	private ClubType club;

	// Token: 0x04002798 RID: 10136
	[SerializeField]
	private PersonaType persona;

	// Token: 0x04002799 RID: 10137
	[SerializeField]
	private int crush;

	// Token: 0x0400279A RID: 10138
	[SerializeField]
	private float breastSize;

	// Token: 0x0400279B RID: 10139
	[SerializeField]
	private int strength;

	// Token: 0x0400279C RID: 10140
	[SerializeField]
	private string hairstyle;

	// Token: 0x0400279D RID: 10141
	[SerializeField]
	private string color;

	// Token: 0x0400279E RID: 10142
	[SerializeField]
	private string eyes;

	// Token: 0x0400279F RID: 10143
	[SerializeField]
	private string eyeType;

	// Token: 0x040027A0 RID: 10144
	[SerializeField]
	private string stockings;

	// Token: 0x040027A1 RID: 10145
	[SerializeField]
	private string accessory;

	// Token: 0x040027A2 RID: 10146
	[SerializeField]
	private string info;

	// Token: 0x040027A3 RID: 10147
	[SerializeField]
	private ScheduleBlock[] scheduleBlocks;

	// Token: 0x040027A4 RID: 10148
	[SerializeField]
	private bool success;
}
