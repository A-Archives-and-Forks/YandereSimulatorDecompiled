﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020003DA RID: 986
public class RichPresenceHelper : MonoBehaviour
{
	// Token: 0x06001B9B RID: 7067 RVA: 0x00138DB0 File Offset: 0x00136FB0
	private void Start()
	{
		this.CompileDictionaries();
		this._discordController = base.GetComponent<DiscordController>();
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		this._discordController.enabled = false;
		this._discordController.presence.state = this.GetSceneDescription();
		this._discordController.presence.details = "Senpai... will... be... mine...";
		this._discordController.presence.largeImageKey = "boxart";
		this._discordController.presence.largeImageText = "This might be the game's box art one day!";
		this._discordController.enabled = true;
		DiscordRpc.UpdatePresence(this._discordController.presence);
		base.InvokeRepeating("UpdatePresence", 0f, 10f);
	}

	// Token: 0x06001B9C RID: 7068 RVA: 0x00138E6C File Offset: 0x0013706C
	private void OnLevelWasLoaded(int level)
	{
		if (level == 12)
		{
			this._clockScript = UnityEngine.Object.FindObjectOfType<ClockScript>();
		}
		this.UpdatePresence();
	}

	// Token: 0x06001B9D RID: 7069 RVA: 0x00138E84 File Offset: 0x00137084
	private void UpdatePresence()
	{
		this._discordController.presence.state = this.GetSceneDescription();
		DiscordRpc.UpdatePresence(this._discordController.presence);
	}

	// Token: 0x06001B9E RID: 7070 RVA: 0x00138EAC File Offset: 0x001370AC
	private void CompileDictionaries()
	{
		this._weekdays.Add(1, "Monday");
		this._weekdays.Add(2, "Tuesday");
		this._weekdays.Add(3, "Wednesday");
		this._weekdays.Add(4, "Thursday");
		this._weekdays.Add(5, "Friday");
		this._periods.Add(1, "Before Class");
		this._periods.Add(2, "Class Time");
		this._periods.Add(3, "Lunch Time");
		this._periods.Add(4, "Class Time");
		this._periods.Add(5, "Cleaning Time");
		this._periods.Add(6, "After School");
		this._sceneDescriptions.Add("ResolutionScene", "Setting the resolution!");
		this._sceneDescriptions.Add("WelcomeScene", "Launching the game!");
		this._sceneDescriptions.Add("SponsorScene", "Checking out the sponsors!");
		this._sceneDescriptions.Add("NewTitleScene", "At the title screen!");
		this._sceneDescriptions.Add("SenpaiScene", "Customizing Senpai!");
		this._sceneDescriptions.Add("IntroScene", "Watching the Intro!");
		this._sceneDescriptions.Add("NewIntroScene", "Watching the Intro!");
		this._sceneDescriptions.Add("PhoneScene", "Texting with Info-Chan!");
		this._sceneDescriptions.Add("CalendarScene", "Checking out the Calendar!");
		this._sceneDescriptions.Add("HomeScene", "Chilling at home!");
		this._sceneDescriptions.Add("LoadingScene", "Now Loading!");
		this._sceneDescriptions.Add("SchoolScene", "At School");
		this._sceneDescriptions.Add("YanvaniaTitleScene", "Beginning Yanvania: Senpai of the Night!");
		this._sceneDescriptions.Add("YanvaniaScene", "Playing Yanvania: Senpai of the Night!");
		this._sceneDescriptions.Add("LivingRoomScene", "Preparing to befriend or betray  Osana!");
		this._sceneDescriptions.Add("MissionModeScene", "Accepting a mission!");
		this._sceneDescriptions.Add("VeryFunScene", "??????????");
		this._sceneDescriptions.Add("CreditsScene", "Viewing the credits!");
		this._sceneDescriptions.Add("MiyukiTitleScene", "Beginning Magical Girl Pretty Miyuki!");
		this._sceneDescriptions.Add("MiyukiGameplayScene", "Playing Magical Girl Pretty Miyuki!");
		this._sceneDescriptions.Add("MiyukiThanksScene", "Finishing Magical Girl Pretty Miyuki!");
		this._sceneDescriptions.Add("RhythmMinigameScene", "Jamming out with the Light Music Club!");
		this._sceneDescriptions.Add("LifeNoteScene", "Watching an episode of Life Note!");
		this._sceneDescriptions.Add("YancordScene", "Chatting over Yancord!");
		this._sceneDescriptions.Add("MaidMenuScene", "Getting ready to be cute at a maid cafe!");
		this._sceneDescriptions.Add("MaidGameScene", "Being a cute maid! MOE MOE KYUN!");
		this._sceneDescriptions.Add("StreetScene", "Chilling in town!");
		this._sceneDescriptions.Add("BusStopScene", "Watching Senpai meet Amai!");
		this._sceneDescriptions.Add("PostCreditsScene", "Eavesdropping on the headmaster!");
		this._sceneDescriptions.Add("DiscordScene", "Awaiting Verification");
		this._sceneDescriptions.Add("OsanaJoke", "Killing Osana at long last!");
	}

	// Token: 0x06001B9F RID: 7071 RVA: 0x00139200 File Offset: 0x00137400
	private string GetSceneDescription()
	{
		string name = SceneManager.GetActiveScene().name;
		if (name != null && name == "SchoolScene")
		{
			string text = MissionModeGlobals.MissionMode ? ", Mission Mode" : string.Empty;
			return string.Format("{0}, {1}, {2}, {3}{4}", new object[]
			{
				this._sceneDescriptions["SchoolScene"],
				this._clockScript.TimeLabel.text,
				this._periods[this._clockScript.Period],
				this._weekdays[this._clockScript.Weekday],
				text
			});
		}
		if (this._sceneDescriptions.ContainsKey(name))
		{
			return this._sceneDescriptions[name];
		}
		return "No description available yet.";
	}

	// Token: 0x04002F60 RID: 12128
	private DiscordController _discordController;

	// Token: 0x04002F61 RID: 12129
	private ClockScript _clockScript;

	// Token: 0x04002F62 RID: 12130
	private Dictionary<int, string> _weekdays = new Dictionary<int, string>();

	// Token: 0x04002F63 RID: 12131
	private Dictionary<int, string> _periods = new Dictionary<int, string>();

	// Token: 0x04002F64 RID: 12132
	private Dictionary<string, string> _sceneDescriptions = new Dictionary<string, string>();
}
