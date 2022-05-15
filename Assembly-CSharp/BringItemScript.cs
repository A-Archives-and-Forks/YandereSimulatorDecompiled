﻿using System;
using UnityEngine;

// Token: 0x020000F8 RID: 248
public class BringItemScript : MonoBehaviour
{
	// Token: 0x06000A69 RID: 2665 RVA: 0x0005CF54 File Offset: 0x0005B154
	private void Initialize()
	{
		for (int i = 1; i < 8; i++)
		{
			if (PlayerGlobals.GetCannotBringItem(i))
			{
				this.Labels[i].color = new Color(1f, 1f, 1f, 0.5f);
			}
			else
			{
				this.Labels[i].color = new Color(1f, 1f, 1f, 1f);
			}
		}
		if (PlayerGlobals.BringingItem != 0)
		{
			this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 50f - (float)PlayerGlobals.BringingItem * 50f, this.Highlight.localPosition.z);
			this.Checkmark.transform.localPosition = new Vector3(300f, this.Highlight.localPosition.y, 0f);
			this.Checkmark.SetActive(true);
		}
		if (PlayerGlobals.BoughtLockpick)
		{
			this.Labels[8].alpha = 1f;
		}
		if (PlayerGlobals.BoughtSedative)
		{
			this.Labels[9].alpha = 1f;
		}
		if (PlayerGlobals.BoughtNarcotics)
		{
			this.Labels[10].alpha = 1f;
		}
		if (PlayerGlobals.BoughtPoison)
		{
			this.Labels[11].alpha = 1f;
		}
		if (PlayerGlobals.BoughtExplosive)
		{
			this.Labels[12].alpha = 1f;
		}
		this.DescLabel.text = this.Descriptions[this.ID];
	}

	// Token: 0x06000A6A RID: 2666 RVA: 0x0005D0E0 File Offset: 0x0005B2E0
	private void Update()
	{
		if (!this.Initialized)
		{
			this.Initialize();
			this.Initialized = true;
		}
		if (this.HomeWindow.Sprite.color.a > 0.9f)
		{
			if (this.InputManager.TappedDown)
			{
				this.ID++;
				if (this.ID > this.Limit)
				{
					this.ID = 1;
				}
				this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 50f - (float)this.ID * 50f, this.Highlight.localPosition.z);
				this.DescLabel.text = this.Descriptions[this.ID];
			}
			if (this.InputManager.TappedUp)
			{
				this.ID--;
				if (this.ID < 1)
				{
					this.ID = this.Limit;
				}
				this.Highlight.localPosition = new Vector3(this.Highlight.localPosition.x, 50f - (float)this.ID * 50f, this.Highlight.localPosition.z);
				this.DescLabel.text = this.Descriptions[this.ID];
			}
			if (Input.GetButtonDown("A") && this.Labels[this.ID].color.a == 1f)
			{
				if (PlayerGlobals.BringingItem != this.ID)
				{
					this.Checkmark.transform.localPosition = new Vector3(300f, this.Highlight.localPosition.y, 0f);
					this.Checkmark.SetActive(true);
					PlayerGlobals.BringingItem = this.ID;
				}
				else
				{
					this.Checkmark.SetActive(false);
					PlayerGlobals.BringingItem = 0;
				}
			}
			if (Input.GetButtonDown("B"))
			{
				this.HomeExit.HomeWindow.Show = true;
				this.HomeWindow.Show = false;
			}
			if (Input.GetButtonDown("X"))
			{
				this.HomeExit.HomeWindow.Show = true;
				this.HomeWindow.Show = false;
				this.HomeExit.GoToSchool();
			}
		}
	}

	// Token: 0x04000C28 RID: 3112
	public InputManagerScript InputManager;

	// Token: 0x04000C29 RID: 3113
	public HomeWindowScript HomeWindow;

	// Token: 0x04000C2A RID: 3114
	public HomeExitScript HomeExit;

	// Token: 0x04000C2B RID: 3115
	public string[] Descriptions;

	// Token: 0x04000C2C RID: 3116
	public GameObject Checkmark;

	// Token: 0x04000C2D RID: 3117
	public Transform Highlight;

	// Token: 0x04000C2E RID: 3118
	public UILabel DescLabel;

	// Token: 0x04000C2F RID: 3119
	public UILabel[] Labels;

	// Token: 0x04000C30 RID: 3120
	public int Limit = 12;

	// Token: 0x04000C31 RID: 3121
	public int ID = 1;

	// Token: 0x04000C32 RID: 3122
	public bool Initialized;
}
