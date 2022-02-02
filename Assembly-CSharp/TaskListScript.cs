﻿using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000467 RID: 1127
public class TaskListScript : MonoBehaviour
{
	// Token: 0x06001E7E RID: 7806 RVA: 0x001AC4DC File Offset: 0x001AA6DC
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

	// Token: 0x06001E7F RID: 7807 RVA: 0x001AC650 File Offset: 0x001AA850
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

	// Token: 0x06001E80 RID: 7808 RVA: 0x001AC76D File Offset: 0x001AA96D
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

	// Token: 0x06001E81 RID: 7809 RVA: 0x001AC77C File Offset: 0x001AA97C
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

	// Token: 0x04003EF0 RID: 16112
	public TutorialWindowScript TutorialWindow;

	// Token: 0x04003EF1 RID: 16113
	public InputManagerScript InputManager;

	// Token: 0x04003EF2 RID: 16114
	public PauseScreenScript PauseScreen;

	// Token: 0x04003EF3 RID: 16115
	public TaskWindowScript TaskWindow;

	// Token: 0x04003EF4 RID: 16116
	public JsonScript JSON;

	// Token: 0x04003EF5 RID: 16117
	public GameObject MainMenu;

	// Token: 0x04003EF6 RID: 16118
	public UITexture StudentIcon;

	// Token: 0x04003EF7 RID: 16119
	public UITexture TaskIcon;

	// Token: 0x04003EF8 RID: 16120
	public UILabel TaskDesc;

	// Token: 0x04003EF9 RID: 16121
	public Texture QuestionMark;

	// Token: 0x04003EFA RID: 16122
	public Transform Highlight;

	// Token: 0x04003EFB RID: 16123
	public Texture Silhouette;

	// Token: 0x04003EFC RID: 16124
	public UILabel[] TaskNameLabels;

	// Token: 0x04003EFD RID: 16125
	public UISprite[] Checkmarks;

	// Token: 0x04003EFE RID: 16126
	public Texture[] TutorialTextures;

	// Token: 0x04003EFF RID: 16127
	public string[] TutorialDescs;

	// Token: 0x04003F00 RID: 16128
	public string[] TutorialNames;

	// Token: 0x04003F01 RID: 16129
	public int ListPosition;

	// Token: 0x04003F02 RID: 16130
	public int Limit = 84;

	// Token: 0x04003F03 RID: 16131
	public int ID = 1;

	// Token: 0x04003F04 RID: 16132
	public bool Tutorials;
}
