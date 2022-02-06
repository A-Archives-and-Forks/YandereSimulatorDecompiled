﻿using System;
using System.Xml.Serialization;

// Token: 0x02000407 RID: 1031
[XmlRoot]
[Serializable]
public class SaveFileData
{
	// Token: 0x04003184 RID: 12676
	public ApplicationSaveData applicationData = new ApplicationSaveData();

	// Token: 0x04003185 RID: 12677
	public ClassSaveData classData = new ClassSaveData();

	// Token: 0x04003186 RID: 12678
	public ClubSaveData clubData = new ClubSaveData();

	// Token: 0x04003187 RID: 12679
	public CollectibleSaveData collectibleData = new CollectibleSaveData();

	// Token: 0x04003188 RID: 12680
	public ConversationSaveData conversationData = new ConversationSaveData();

	// Token: 0x04003189 RID: 12681
	public DateSaveData dateData = new DateSaveData();

	// Token: 0x0400318A RID: 12682
	public DatingSaveData datingData = new DatingSaveData();

	// Token: 0x0400318B RID: 12683
	public EventSaveData eventData = new EventSaveData();

	// Token: 0x0400318C RID: 12684
	public GameSaveData gameData = new GameSaveData();

	// Token: 0x0400318D RID: 12685
	public HomeSaveData homeData = new HomeSaveData();

	// Token: 0x0400318E RID: 12686
	public MissionModeSaveData missionModeData = new MissionModeSaveData();

	// Token: 0x0400318F RID: 12687
	public OptionSaveData optionData = new OptionSaveData();

	// Token: 0x04003190 RID: 12688
	public PlayerSaveData playerData = new PlayerSaveData();

	// Token: 0x04003191 RID: 12689
	public PoseModeSaveData poseModeData = new PoseModeSaveData();

	// Token: 0x04003192 RID: 12690
	public SaveFileSaveData saveFileData = new SaveFileSaveData();

	// Token: 0x04003193 RID: 12691
	public SchemeSaveData schemeData = new SchemeSaveData();

	// Token: 0x04003194 RID: 12692
	public SchoolSaveData schoolData = new SchoolSaveData();

	// Token: 0x04003195 RID: 12693
	public SenpaiSaveData senpaiData = new SenpaiSaveData();

	// Token: 0x04003196 RID: 12694
	public StudentSaveData studentData = new StudentSaveData();

	// Token: 0x04003197 RID: 12695
	public TaskSaveData taskData = new TaskSaveData();

	// Token: 0x04003198 RID: 12696
	public YanvaniaSaveData yanvaniaData = new YanvaniaSaveData();
}
