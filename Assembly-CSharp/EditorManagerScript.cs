﻿using System;
using System.Collections.Generic;
using System.IO;
using JsonFx.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000296 RID: 662
public class EditorManagerScript : MonoBehaviour
{
	// Token: 0x060013E4 RID: 5092 RVA: 0x000BCC12 File Offset: 0x000BAE12
	private void Awake()
	{
		this.buttonIndex = 0;
		this.inputManager = UnityEngine.Object.FindObjectOfType<InputManagerScript>();
	}

	// Token: 0x060013E5 RID: 5093 RVA: 0x000BCC28 File Offset: 0x000BAE28
	private void Start()
	{
		this.promptBar.Label[0].text = "Select";
		this.promptBar.Label[1].text = "Exit";
		this.promptBar.Label[4].text = "Choose";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013E6 RID: 5094 RVA: 0x000BCC88 File Offset: 0x000BAE88
	private void OnEnable()
	{
		this.promptBar.Label[0].text = "Select";
		this.promptBar.Label[1].text = "Exit";
		this.promptBar.Label[4].text = "Choose";
		this.promptBar.UpdateButtons();
	}

	// Token: 0x060013E7 RID: 5095 RVA: 0x000BCCE5 File Offset: 0x000BAEE5
	public static Dictionary<string, object>[] DeserializeJson(string filename)
	{
		return JsonReader.Deserialize<Dictionary<string, object>[]>(File.ReadAllText(Path.Combine(Application.streamingAssetsPath, Path.Combine("JSON", filename))));
	}

	// Token: 0x060013E8 RID: 5096 RVA: 0x000BCD08 File Offset: 0x000BAF08
	private void HandleInput()
	{
		if (Input.GetButtonDown("B"))
		{
			SceneManager.LoadScene("NewTitleScene");
		}
		bool tappedUp = this.inputManager.TappedUp;
		bool tappedDown = this.inputManager.TappedDown;
		if (tappedUp)
		{
			this.buttonIndex = ((this.buttonIndex > 0) ? (this.buttonIndex - 1) : 2);
		}
		else if (tappedDown)
		{
			this.buttonIndex = ((this.buttonIndex < 2) ? (this.buttonIndex + 1) : 0);
		}
		if (tappedUp || tappedDown)
		{
			Transform transform = this.cursorLabel.transform;
			transform.localPosition = new Vector3(transform.localPosition.x, 100f - (float)this.buttonIndex * 100f, transform.localPosition.z);
		}
		if (Input.GetButtonDown("A"))
		{
			this.editorPanels[this.buttonIndex].gameObject.SetActive(true);
			this.mainPanel.gameObject.SetActive(false);
		}
	}

	// Token: 0x060013E9 RID: 5097 RVA: 0x000BCDF7 File Offset: 0x000BAFF7
	private void Update()
	{
		this.HandleInput();
	}

	// Token: 0x04001D9E RID: 7582
	[SerializeField]
	private UIPanel mainPanel;

	// Token: 0x04001D9F RID: 7583
	[SerializeField]
	private UIPanel[] editorPanels;

	// Token: 0x04001DA0 RID: 7584
	[SerializeField]
	private UILabel cursorLabel;

	// Token: 0x04001DA1 RID: 7585
	[SerializeField]
	private PromptBarScript promptBar;

	// Token: 0x04001DA2 RID: 7586
	private int buttonIndex;

	// Token: 0x04001DA3 RID: 7587
	private const int ButtonCount = 3;

	// Token: 0x04001DA4 RID: 7588
	private InputManagerScript inputManager;
}
