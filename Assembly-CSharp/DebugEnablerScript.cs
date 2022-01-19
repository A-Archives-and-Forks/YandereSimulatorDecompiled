﻿using System;
using UnityEngine;

// Token: 0x02000275 RID: 629
public class DebugEnablerScript : MonoBehaviour
{
	// Token: 0x06001356 RID: 4950 RVA: 0x000AE718 File Offset: 0x000AC918
	private void Start()
	{
		if (MissionModeGlobals.MissionMode || GameGlobals.AlphabetMode || GameGlobals.LoveSick || (!GameGlobals.Eighties && DateGlobals.Week == 2))
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		if (GameGlobals.Debug || this.Editor)
		{
			this.Editor = true;
			this.EnableDebug();
		}
	}

	// Token: 0x06001357 RID: 4951 RVA: 0x000AE770 File Offset: 0x000AC970
	public void EnableDebug()
	{
		this.Yandere.NotificationManager.CustomText = "Debug Commands Enabled!";
		this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		Debug.Log("Enabling the use of debug commands.");
		this.Yandere.Inventory.PantyShots = 100;
		this.Yandere.NoDebug = false;
		this.Yandere.EggBypass = 10;
		this.Yandere.Egg = false;
		this.StandWeapons.SetActive(true);
		this.VoidGoddess.SetActive(true);
		this.MurderKit.SetActive(true);
		this.Memes.SetActive(true);
		this.Keys.SetActive(true);
		this.DebugMenu.MissionMode = false;
		this.DebugMenu.NoDebug = false;
		this.Yandere.NoDebug = false;
		this.Turtle.enabled = true;
		this.MemeClosetDoor.Locked = false;
		base.gameObject.SetActive(false);
		this.Skull.Prompt.enabled = true;
		this.Skull.enabled = true;
		GameGlobals.Debug = true;
	}

	// Token: 0x04001C02 RID: 7170
	public GameObject StandWeapons;

	// Token: 0x04001C03 RID: 7171
	public GameObject VoidGoddess;

	// Token: 0x04001C04 RID: 7172
	public GameObject MurderKit;

	// Token: 0x04001C05 RID: 7173
	public GameObject Memes;

	// Token: 0x04001C06 RID: 7174
	public GameObject Keys;

	// Token: 0x04001C07 RID: 7175
	public DebugMenuScript DebugMenu;

	// Token: 0x04001C08 RID: 7176
	public YandereScript Yandere;

	// Token: 0x04001C09 RID: 7177
	public SkullScript Skull;

	// Token: 0x04001C0A RID: 7178
	public PrayScript Turtle;

	// Token: 0x04001C0B RID: 7179
	public DoorScript MemeClosetDoor;

	// Token: 0x04001C0C RID: 7180
	public PromptScript Prompt;

	// Token: 0x04001C0D RID: 7181
	public bool Editor;

	// Token: 0x04001C0E RID: 7182
	public int Spaces;
}
