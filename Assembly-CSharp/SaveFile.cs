﻿using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

// Token: 0x02000405 RID: 1029
[Serializable]
public class SaveFile
{
	// Token: 0x06001C14 RID: 7188 RVA: 0x001456B2 File Offset: 0x001438B2
	public SaveFile(int index)
	{
		this.data = new SaveFileData();
		this.index = index;
	}

	// Token: 0x06001C15 RID: 7189 RVA: 0x001456CC File Offset: 0x001438CC
	private SaveFile(SaveFileData data, int index)
	{
		this.data = data;
		this.index = index;
	}

	// Token: 0x1700049D RID: 1181
	// (get) Token: 0x06001C16 RID: 7190 RVA: 0x001456E2 File Offset: 0x001438E2
	public SaveFileData Data
	{
		get
		{
			return this.data;
		}
	}

	// Token: 0x06001C17 RID: 7191 RVA: 0x001456EA File Offset: 0x001438EA
	public static string GetSaveFolderPath(int index)
	{
		return Path.Combine(SaveFile.SavesPath, "Save" + index.ToString());
	}

	// Token: 0x06001C18 RID: 7192 RVA: 0x00145707 File Offset: 0x00143907
	private static string GetFullSaveFileName(int index)
	{
		return Path.Combine(SaveFile.GetSaveFolderPath(index), SaveFile.SaveName);
	}

	// Token: 0x1700049E RID: 1182
	// (get) Token: 0x06001C19 RID: 7193 RVA: 0x00145719 File Offset: 0x00143919
	private static bool SavesFolderExists
	{
		get
		{
			return Directory.Exists(SaveFile.SavesPath);
		}
	}

	// Token: 0x06001C1A RID: 7194 RVA: 0x00145725 File Offset: 0x00143925
	public static bool SaveFolderExists(int index)
	{
		return Directory.Exists(SaveFile.GetSaveFolderPath(index));
	}

	// Token: 0x06001C1B RID: 7195 RVA: 0x00145732 File Offset: 0x00143932
	public static bool Exists(int index)
	{
		return File.Exists(SaveFile.GetFullSaveFileName(index));
	}

	// Token: 0x06001C1C RID: 7196 RVA: 0x00145740 File Offset: 0x00143940
	public static SaveFile Load(int index)
	{
		SaveFile result;
		try
		{
			string s = File.ReadAllText(SaveFile.GetFullSaveFileName(index));
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveFileData));
			MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(s));
			result = new SaveFile((SaveFileData)xmlSerializer.Deserialize(stream), index);
		}
		catch (Exception ex)
		{
			Debug.LogError(string.Concat(new string[]
			{
				"Loading save file ",
				index.ToString(),
				" failed (",
				ex.ToString(),
				")."
			}));
			result = null;
		}
		return result;
	}

	// Token: 0x06001C1D RID: 7197 RVA: 0x001457E0 File Offset: 0x001439E0
	public static void Delete(int index)
	{
		try
		{
			File.Delete(SaveFile.GetFullSaveFileName(index));
		}
		catch (Exception ex)
		{
			Debug.LogError(string.Concat(new string[]
			{
				"Deleting save file ",
				index.ToString(),
				" failed (",
				ex.ToString(),
				")."
			}));
		}
	}

	// Token: 0x06001C1E RID: 7198 RVA: 0x00145848 File Offset: 0x00143A48
	public void Save()
	{
		try
		{
			if (!SaveFile.SavesFolderExists)
			{
				Directory.CreateDirectory(SaveFile.SavesPath);
			}
			if (!SaveFile.SaveFolderExists(this.index))
			{
				Directory.CreateDirectory(SaveFile.GetSaveFolderPath(this.index));
			}
			string fullSaveFileName = SaveFile.GetFullSaveFileName(this.index);
			if (!SaveFile.Exists(this.index))
			{
				File.Create(fullSaveFileName).Dispose();
			}
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveFileData));
			using (XmlWriter xmlWriter = XmlWriter.Create(fullSaveFileName, new XmlWriterSettings
			{
				Indent = true,
				IndentChars = "\t"
			}))
			{
				xmlSerializer.Serialize(xmlWriter, this.data);
			}
		}
		catch (Exception ex)
		{
			Debug.LogError(string.Concat(new string[]
			{
				"Saving save file ",
				this.index.ToString(),
				" failed (",
				ex.ToString(),
				")."
			}));
		}
	}

	// Token: 0x06001C1F RID: 7199 RVA: 0x00145954 File Offset: 0x00143B54
	public void ReadFromGlobals()
	{
		this.data.applicationData = ApplicationSaveData.ReadFromGlobals();
		this.data.classData = ClassSaveData.ReadFromGlobals();
		this.data.clubData = ClubSaveData.ReadFromGlobals();
		this.data.collectibleData = CollectibleSaveData.ReadFromGlobals();
		this.data.conversationData = ConversationSaveData.ReadFromGlobals();
		this.data.dateData = DateSaveData.ReadFromGlobals();
		this.data.datingData = DatingSaveData.ReadFromGlobals();
		this.data.eventData = EventSaveData.ReadFromGlobals();
		this.data.gameData = GameSaveData.ReadFromGlobals();
		this.data.homeData = HomeSaveData.ReadFromGlobals();
		this.data.missionModeData = MissionModeSaveData.ReadFromGlobals();
		this.data.optionData = OptionSaveData.ReadFromGlobals();
		this.data.playerData = PlayerSaveData.ReadFromGlobals();
		this.data.poseModeData = PoseModeSaveData.ReadFromGlobals();
		this.data.saveFileData = SaveFileSaveData.ReadFromGlobals();
		this.data.schemeData = SchemeSaveData.ReadFromGlobals();
		this.data.schoolData = SchoolSaveData.ReadFromGlobals();
		this.data.senpaiData = SenpaiSaveData.ReadFromGlobals();
		this.data.studentData = StudentSaveData.ReadFromGlobals();
		this.data.taskData = TaskSaveData.ReadFromGlobals();
		this.data.yanvaniaData = YanvaniaSaveData.ReadFromGlobals();
	}

	// Token: 0x06001C20 RID: 7200 RVA: 0x00145AB4 File Offset: 0x00143CB4
	public void WriteToGlobals()
	{
		ApplicationSaveData.WriteToGlobals(this.data.applicationData);
		ClassSaveData.WriteToGlobals(this.data.classData);
		ClubSaveData.WriteToGlobals(this.data.clubData);
		CollectibleSaveData.WriteToGlobals(this.data.collectibleData);
		ConversationSaveData.WriteToGlobals(this.data.conversationData);
		DateSaveData.WriteToGlobals(this.data.dateData);
		DatingSaveData.WriteToGlobals(this.data.datingData);
		EventSaveData.WriteToGlobals(this.data.eventData);
		GameSaveData.WriteToGlobals(this.data.gameData);
		HomeSaveData.WriteToGlobals(this.data.homeData);
		MissionModeSaveData.WriteToGlobals(this.data.missionModeData);
		OptionSaveData.WriteToGlobals(this.data.optionData);
		PlayerSaveData.WriteToGlobals(this.data.playerData);
		PoseModeSaveData.WriteToGlobals(this.data.poseModeData);
		SaveFileSaveData.WriteToGlobals(this.data.saveFileData);
		SchemeSaveData.WriteToGlobals(this.data.schemeData);
		SchoolSaveData.WriteToGlobals(this.data.schoolData);
		SenpaiSaveData.WriteToGlobals(this.data.senpaiData);
		StudentSaveData.WriteToGlobals(this.data.studentData);
		TaskSaveData.WriteToGlobals(this.data.taskData);
		YanvaniaSaveData.WriteToGlobals(this.data.yanvaniaData);
	}

	// Token: 0x0400317D RID: 12669
	[SerializeField]
	private SaveFileData data;

	// Token: 0x0400317E RID: 12670
	[SerializeField]
	private int index;

	// Token: 0x0400317F RID: 12671
	private static readonly string SavesPath = Path.Combine(Application.persistentDataPath, "Saves");

	// Token: 0x04003180 RID: 12672
	private static readonly string SaveName = "Save.txt";
}
