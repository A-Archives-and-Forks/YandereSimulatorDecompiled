﻿using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000273 RID: 627
public class DebugConsole : MonoBehaviour
{
	// Token: 0x06001350 RID: 4944 RVA: 0x000AE506 File Offset: 0x000AC706
	private void OnEnable()
	{
		Application.logMessageReceived += this.captureLog;
	}

	// Token: 0x06001351 RID: 4945 RVA: 0x000AE519 File Offset: 0x000AC719
	private void OnDisable()
	{
		Application.logMessageReceived += this.captureLog;
	}

	// Token: 0x06001352 RID: 4946 RVA: 0x000AE52C File Offset: 0x000AC72C
	private void Start()
	{
		this.BackgroundTex = Texture2D.blackTexture;
		Texture2D backgroundTex = this.BackgroundTex;
		for (int i = 0; i < backgroundTex.width; i++)
		{
			for (int j = 0; j < backgroundTex.height; j++)
			{
				Color pixel = backgroundTex.GetPixel(i, j);
				pixel.a = 0.5f;
				backgroundTex.SetPixel(i, j, pixel);
			}
		}
		backgroundTex.Apply();
		this.BackgroundTex = backgroundTex;
	}

	// Token: 0x06001353 RID: 4947 RVA: 0x000AE598 File Offset: 0x000AC798
	private void captureLog(string condition, string stackTrace, LogType type)
	{
		this.logs.Add(new DebugMessage
		{
			messageType = type,
			content = condition
		});
		if (this.logs.Count > 30)
		{
			this.logs.RemoveAt(0);
		}
	}

	// Token: 0x06001354 RID: 4948 RVA: 0x000AE5E4 File Offset: 0x000AC7E4
	private void OnGUI()
	{
		GUIStyle guistyle = new GUIStyle();
		guistyle.normal.background = this.BackgroundTex;
		GUI.Label(new Rect(10f, 0f, (float)(Screen.width / 3), (float)(15 * this.logs.Count)), string.Empty, guistyle);
		int i = 0;
		while (i < this.logs.Count)
		{
			GUIStyle guistyle2 = new GUIStyle();
			switch (this.logs[i].messageType)
			{
			case LogType.Error:
				guistyle2.normal.textColor = Color.red;
				break;
			case LogType.Assert:
			case LogType.Log:
				goto IL_B9;
			case LogType.Warning:
				guistyle2.normal.textColor = Color.yellow;
				break;
			case LogType.Exception:
				guistyle2.normal.textColor = Color.red;
				break;
			default:
				goto IL_B9;
			}
			IL_C9:
			GUI.Label(new Rect(10f, (float)(15 * i), (float)(Screen.width / 3), 25f), this.logs[i].content, guistyle2);
			i++;
			continue;
			IL_B9:
			guistyle2.normal.textColor = Color.white;
			goto IL_C9;
		}
	}

	// Token: 0x04001BFE RID: 7166
	private List<DebugMessage> logs = new List<DebugMessage>();

	// Token: 0x04001BFF RID: 7167
	private Texture2D BackgroundTex;
}
