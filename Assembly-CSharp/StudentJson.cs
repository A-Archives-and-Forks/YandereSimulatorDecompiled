using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;

[Serializable]
public class StudentJson : JsonData
{
	[SerializeField]
	private string name;

	[SerializeField]
	private string realname;

	[SerializeField]
	private int gender;

	[SerializeField]
	private int classID;

	[SerializeField]
	private int seat;

	[SerializeField]
	private ClubType club;

	[SerializeField]
	private PersonaType persona;

	[SerializeField]
	private int crush;

	[SerializeField]
	private float breastSize;

	[SerializeField]
	private int strength;

	[SerializeField]
	private string hairstyle;

	[SerializeField]
	private string color;

	[SerializeField]
	private string eyes;

	[SerializeField]
	private string eyeType;

	[SerializeField]
	private string stockings;

	[SerializeField]
	private string accessory;

	[SerializeField]
	private string info;

	[SerializeField]
	private ScheduleBlock[] scheduleBlocks;

	[SerializeField]
	private bool success;

	[SerializeField]
	private int hairR;

	[SerializeField]
	private int hairG;

	[SerializeField]
	private int hairB;

	[SerializeField]
	private int eyeR;

	[SerializeField]
	private int eyeG;

	[SerializeField]
	private int eyeB;

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

	public string Name
	{
		get
		{
			return name;
		}
		set
		{
			name = value;
		}
	}

	public string RealName
	{
		get
		{
			return realname;
		}
		set
		{
			realname = value;
		}
	}

	public int Gender
	{
		get
		{
			return gender;
		}
		set
		{
			gender = value;
		}
	}

	public int Class
	{
		get
		{
			return classID;
		}
		set
		{
			classID = value;
		}
	}

	public int Seat
	{
		get
		{
			return seat;
		}
		set
		{
			seat = value;
		}
	}

	public ClubType Club
	{
		get
		{
			return club;
		}
		set
		{
			club = value;
		}
	}

	public PersonaType Persona
	{
		get
		{
			return persona;
		}
		set
		{
			persona = value;
		}
	}

	public int Crush
	{
		get
		{
			return crush;
		}
		set
		{
			crush = value;
		}
	}

	public float BreastSize
	{
		get
		{
			return breastSize;
		}
		set
		{
			breastSize = value;
		}
	}

	public int Strength
	{
		get
		{
			return strength;
		}
		set
		{
			strength = value;
		}
	}

	public string Hairstyle
	{
		get
		{
			return hairstyle;
		}
		set
		{
			hairstyle = value;
		}
	}

	public string Color
	{
		get
		{
			return color;
		}
		set
		{
			color = value;
		}
	}

	public string Eyes
	{
		get
		{
			return eyes;
		}
		set
		{
			eyes = value;
		}
	}

	public string EyeType
	{
		get
		{
			return eyeType;
		}
		set
		{
			eyeType = value;
		}
	}

	public string Stockings
	{
		get
		{
			return stockings;
		}
		set
		{
			stockings = value;
		}
	}

	public string Accessory
	{
		get
		{
			return accessory;
		}
		set
		{
			accessory = value;
		}
	}

	public string Info
	{
		get
		{
			return info;
		}
		set
		{
			info = value;
		}
	}

	public ScheduleBlock[] ScheduleBlocks
	{
		get
		{
			return scheduleBlocks;
		}
		set
		{
			scheduleBlocks = value;
		}
	}

	public bool Success => success;

	public int HairR
	{
		get
		{
			return hairR;
		}
		set
		{
			hairR = value;
		}
	}

	public int HairG
	{
		get
		{
			return hairG;
		}
		set
		{
			hairG = value;
		}
	}

	public int HairB
	{
		get
		{
			return hairB;
		}
		set
		{
			hairB = value;
		}
	}

	public int EyeR
	{
		get
		{
			return eyeR;
		}
		set
		{
			eyeR = value;
		}
	}

	public int EyeG
	{
		get
		{
			return eyeG;
		}
		set
		{
			eyeG = value;
		}
	}

	public int EyeB
	{
		get
		{
			return eyeB;
		}
		set
		{
			eyeB = value;
		}
	}

	public static StudentJson[] LoadFromJson(string path)
	{
		StudentJson[] array = new StudentJson[101];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new StudentJson();
		}
		array[0].Name = "Ayano Aishi";
		array[0].Gender = 0;
		array[0].Class = 21;
		array[0].Seat = 13;
		array[0].Crush = 1;
		array[0].BreastSize = 1f;
		array[0].Hairstyle = "1";
		array[0].Color = "Default";
		array[0].Eyes = "Default";
		array[0].EyeType = "Ayano";
		array[0].Stockings = "Black";
		array[0].Accessory = "0";
		array[0].Info = "";
		Dictionary<string, object>[] array2 = JsonData.Deserialize(path);
		foreach (Dictionary<string, object> dictionary in array2)
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
			if (GameGlobals.LoveSick && studentJson.realname != "")
			{
				studentJson.name = studentJson.realname;
				studentJson.realname = "";
			}
			if (OptionGlobals.HighPopulation && studentJson.name == "Unknown")
			{
				studentJson.name = "Random";
			}
			float[] array3 = ConstructTempFloatArray(TFUtils.LoadString(dictionary, "ScheduleTime"));
			string[] array4 = ConstructTempStringArray(TFUtils.LoadString(dictionary, "ScheduleDestination"));
			string[] array5 = ConstructTempStringArray(TFUtils.LoadString(dictionary, "ScheduleAction"));
			studentJson.scheduleBlocks = new ScheduleBlock[array3.Length];
			for (int k = 0; k < studentJson.scheduleBlocks.Length; k++)
			{
				studentJson.scheduleBlocks[k] = new ScheduleBlock(array3[k], array4[k], array5[k]);
			}
			studentJson.success = true;
		}
		return array;
	}

	private static float[] ConstructTempFloatArray(string str)
	{
		string[] array = str.Split(new char[1] { '_' });
		float[] array2 = new float[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			if (float.TryParse(array[i], NumberStyles.Float, NumberFormatInfo.InvariantInfo, out var result))
			{
				array2[i] = result;
			}
		}
		return array2;
	}

	private static string[] ConstructTempStringArray(string str)
	{
		return str.Split('_');
	}
}
