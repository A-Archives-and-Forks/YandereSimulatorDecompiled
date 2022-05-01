﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000245 RID: 581
public class ChoiceScript : MonoBehaviour
{
	// Token: 0x0600124F RID: 4687 RVA: 0x0008D1A4 File Offset: 0x0008B3A4
	private void Start()
	{
		this.Darkness.color = new Color(1f, 1f, 1f, 1f);
	}

	// Token: 0x06001250 RID: 4688 RVA: 0x0008D1CC File Offset: 0x0008B3CC
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

	// Token: 0x0400172B RID: 5931
	public InputManagerScript InputManager;

	// Token: 0x0400172C RID: 5932
	public PromptBarScript PromptBar;

	// Token: 0x0400172D RID: 5933
	public Transform Highlight;

	// Token: 0x0400172E RID: 5934
	public UISprite Darkness;

	// Token: 0x0400172F RID: 5935
	public int Selected;

	// Token: 0x04001730 RID: 5936
	public int Phase;
}
