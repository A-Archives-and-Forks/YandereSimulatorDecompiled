﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000245 RID: 581
public class ChoiceScript : MonoBehaviour
{
	// Token: 0x0600124F RID: 4687 RVA: 0x0008CE98 File Offset: 0x0008B098
	private void Start()
	{
		this.Darkness.color = new Color(1f, 1f, 1f, 1f);
	}

	// Token: 0x06001250 RID: 4688 RVA: 0x0008CEC0 File Offset: 0x0008B0C0
	private void Update()
	{
		this.Highlight.transform.localPosition = Vector3.Lerp(this.Highlight.transform.localPosition, new Vector3((float)(-360 + 720 * this.Selected), this.Highlight.transform.localPosition.y, this.Highlight.transform.localPosition.z), Time.deltaTime * 10f);
		if (this.Phase == 0)
		{
			this.Darkness.color = new Color(1f, 1f, 1f, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime * 2f));
			if (this.Darkness.color.a == 0f)
			{
				this.Phase++;
				return;
			}
		}
		else if (this.Phase == 1)
		{
			if (this.InputManager.TappedLeft)
			{
				this.Darkness.color = new Color(1f, 1f, 1f, 0f);
				this.Selected = 0;
			}
			else if (this.InputManager.TappedRight)
			{
				this.Darkness.color = new Color(0f, 0f, 0f, 0f);
				this.Selected = 1;
			}
			if (Input.GetButtonDown("A"))
			{
				this.Phase++;
				return;
			}
		}
		else if (this.Phase == 2)
		{
			this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime * 2f));
			if (this.Darkness.color.a == 1f)
			{
				GameGlobals.LoveSick = (this.Selected == 1);
				SceneManager.LoadScene("NewTitleScene");
			}
		}
	}

	// Token: 0x04001727 RID: 5927
	public InputManagerScript InputManager;

	// Token: 0x04001728 RID: 5928
	public PromptBarScript PromptBar;

	// Token: 0x04001729 RID: 5929
	public Transform Highlight;

	// Token: 0x0400172A RID: 5930
	public UISprite Darkness;

	// Token: 0x0400172B RID: 5931
	public int Selected;

	// Token: 0x0400172C RID: 5932
	public int Phase;
}
