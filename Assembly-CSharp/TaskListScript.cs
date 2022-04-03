﻿using System;
using System.Collections;
using UnityEngine;

// Token: 0x0200046E RID: 1134
public class TaskListScript : MonoBehaviour
{
	// Token: 0x06001EB0 RID: 7856 RVA: 0x001B0B4C File Offset: 0x001AED4C
	private void Update()
	{
		if (this.InputManager.TappedUp)
		{
			if (this.ID == 1)
			{
				this.ListPosition--;
				if (this.ListPosition < 0)
				{
					this.ListPosition = this.Limit - 16;
					this.ID = 16;
				}
			}
			else
			{
				this.ID--;
			}
			this.UpdateTaskList();
			base.StartCoroutine(this.UpdateTaskInfo());
		}
		if (this.InputManager.TappedDown)
		{
			if (this.ID == 16)
			{
				this.ListPosition++;
				if (this.ID + this.ListPosition > this.Limit)
				{
					this.ListPosition = 0;
					this.ID = 1;
				}
			}
			else
			{
				this.ID++;
			}
			this.UpdateTaskList();
			base.StartCoroutine(this.UpdateTaskInfo());
		}
		if (this.Tutorials)
		{
			if (!this.TutorialWindow.Hide && !this.TutorialWindow.Show)
			{
				if (Input.GetButtonDown("A"))
				{
					OptionGlobals.TutorialsOff = false;
					this.TutorialWindow.ForceID = this.ListPosition + this.ID;
					this.TutorialWindow.ShowTutorial();
					this.TutorialWindow.enabled = true;
					this.TutorialWindow.SummonWindow();
					return;
				}
				if (Input.GetButtonDown("B"))
				{
					this.Exit();
					return;
				}
			}
		}
		else if (Input.GetButtonDown("B"))
		{
			this.Exit();
		}
	}

	// Token: 0x06001EB1 RID: 7857 RVA: 0x001B0CC0 File Offset: 0x001AEEC0
	public void UpdateTaskList()
	{
		if (!this.TaskWindow.TaskManager.Initialized)
		{
			this.TaskWindow.TaskManager.Start();
		}
		if (this.Tutorials)
		{
			for (int i = 1; i < this.TaskNameLabels.Length; i++)
			{
				this.TaskNameLabels[i].text = this.TutorialNames[i + this.ListPosition];
			}
			return;
		}
		for (int j = 1; j < this.TaskNameLabels.Length; j++)
		{
			if (this.TaskWindow.TaskManager.TaskStatus[j + this.ListPosition] == 0)
			{
				this.TaskNameLabels[j].text = "Undiscovered Task #" + (j + this.ListPosition).ToString();
			}
			else
			{
				this.TaskNameLabels[j].text = this.JSON.Students[j + this.ListPosition].Name + "'s Task";
			}
			this.Checkmarks[j].enabled = (this.TaskWindow.TaskManager.TaskStatus[j + this.ListPosition] == 3);
		}
	}

	// Token: 0x06001EB2 RID: 7858 RVA: 0x001B0DDD File Offset: 0x001AEFDD
	public IEnumerator UpdateTaskInfo()
	{
		this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 200f - 25f * (float)this.ID, this.Highlight.localPosition.z);
		if (this.Tutorials)
		{
			this.TaskIcon.mainTexture = this.TutorialTextures[this.ID + this.ListPosition];
			this.TaskDesc.text = "This tutorial will teach you about " + this.TutorialNames[this.ID + this.ListPosition];
		}
		else
		{
			string text = "";
			if (GameGlobals.Eighties)
			{
				text = "1989";
			}
			if (this.TaskWindow.TaskManager.TaskStatus[this.ID + this.ListPosition] == 0)
			{
				this.StudentIcon.mainTexture = this.Silhouette;
				this.TaskIcon.mainTexture = this.QuestionMark;
				this.TaskDesc.text = "This task has not been discovered yet.";
			}
			else
			{
				string url = string.Concat(new string[]
				{
					"file:///",
					Application.streamingAssetsPath,
					"/Portraits",
					text,
					"/Student_",
					(this.ID + this.ListPosition).ToString(),
					".png"
				});
				WWW www = new WWW(url);
				yield return www;
				this.StudentIcon.mainTexture = www.texture;
				this.TaskWindow.AltGenericCheck(this.ID + this.ListPosition);
				if (this.TaskWindow.Generic)
				{
					this.TaskIcon.mainTexture = this.TaskWindow.Icons[0];
					this.TaskDesc.text = this.TaskWindow.Descriptions[0];
				}
				else
				{
					this.TaskIcon.mainTexture = this.TaskWindow.Icons[this.ID + this.ListPosition];
					this.TaskDesc.text = this.TaskWindow.Descriptions[this.ID + this.ListPosition];
				}
				www = null;
			}
		}
		yield break;
	}

	// Token: 0x06001EB3 RID: 7859 RVA: 0x001B0DEC File Offset: 0x001AEFEC
	public void Exit()
	{
		this.PauseScreen.PromptBar.ClearButtons();
		this.PauseScreen.PromptBar.Label[0].text = "Accept";
		this.PauseScreen.PromptBar.Label[1].text = "Back";
		this.PauseScreen.PromptBar.Label[4].text = "Choose";
		this.PauseScreen.PromptBar.Label[5].text = "Choose";
		this.PauseScreen.PromptBar.UpdateButtons();
		this.PauseScreen.Sideways = false;
		this.PauseScreen.PressedB = true;
		this.MainMenu.SetActive(true);
		base.gameObject.SetActive(false);
	}

	// Token: 0x04003F9E RID: 16286
	public TutorialWindowScript TutorialWindow;

	// Token: 0x04003F9F RID: 16287
	public InputManagerScript InputManager;

	// Token: 0x04003FA0 RID: 16288
	public PauseScreenScript PauseScreen;

	// Token: 0x04003FA1 RID: 16289
	public TaskWindowScript TaskWindow;

	// Token: 0x04003FA2 RID: 16290
	public JsonScript JSON;

	// Token: 0x04003FA3 RID: 16291
	public GameObject MainMenu;

	// Token: 0x04003FA4 RID: 16292
	public UITexture StudentIcon;

	// Token: 0x04003FA5 RID: 16293
	public UITexture TaskIcon;

	// Token: 0x04003FA6 RID: 16294
	public UILabel TaskDesc;

	// Token: 0x04003FA7 RID: 16295
	public Texture QuestionMark;

	// Token: 0x04003FA8 RID: 16296
	public Transform Highlight;

	// Token: 0x04003FA9 RID: 16297
	public Texture Silhouette;

	// Token: 0x04003FAA RID: 16298
	public UILabel[] TaskNameLabels;

	// Token: 0x04003FAB RID: 16299
	public UISprite[] Checkmarks;

	// Token: 0x04003FAC RID: 16300
	public Texture[] TutorialTextures;

	// Token: 0x04003FAD RID: 16301
	public string[] TutorialDescs;

	// Token: 0x04003FAE RID: 16302
	public string[] TutorialNames;

	// Token: 0x04003FAF RID: 16303
	public int ListPosition;

	// Token: 0x04003FB0 RID: 16304
	public int Limit = 84;

	// Token: 0x04003FB1 RID: 16305
	public int ID = 1;

	// Token: 0x04003FB2 RID: 16306
	public bool Tutorials;
}
