﻿// Decompiled with JetBrains decompiler
// Type: SaveFileData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Xml.Serialization;

[XmlRoot]
[Serializable]
public class SaveFileData
{
  public ApplicationSaveData applicationData = new ApplicationSaveData();
  public ClassSaveData classData = new ClassSaveData();
  public ClubSaveData clubData = new ClubSaveData();
  public CollectibleSaveData collectibleData = new CollectibleSaveData();
  public ConversationSaveData conversationData = new ConversationSaveData();
  public DateSaveData dateData = new DateSaveData();
  public DatingSaveData datingData = new DatingSaveData();
  public EventSaveData eventData = new EventSaveData();
  public GameSaveData gameData = new GameSaveData();
  public HomeSaveData homeData = new HomeSaveData();
  public MissionModeSaveData missionModeData = new MissionModeSaveData();
  public OptionSaveData optionData = new OptionSaveData();
  public PlayerSaveData playerData = new PlayerSaveData();
  public PoseModeSaveData poseModeData = new PoseModeSaveData();
  public SaveFileSaveData saveFileData = new SaveFileSaveData();
  public SchemeSaveData schemeData = new SchemeSaveData();
  public SchoolSaveData schoolData = new SchoolSaveData();
  public SenpaiSaveData senpaiData = new SenpaiSaveData();
  public StudentSaveData studentData = new StudentSaveData();
  public TaskSaveData taskData = new TaskSaveData();
  public YanvaniaSaveData yanvaniaData = new YanvaniaSaveData();
}
