﻿using System;
using UnityEngine;

// Token: 0x020000F7 RID: 247
public class BringItemScript : MonoBehaviour
{
	// Token: 0x06000A67 RID: 2663 RVA: 0x0005C9C0 File Offset: 0x0005ABC0
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

	// Token: 0x06000A68 RID: 2664 RVA: 0x0005CB4C File Offset: 0x0005AD4C
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

	// Token: 0x04000C21 RID: 3105
	public InputManagerScript InputManager;

	// Token: 0x04000C22 RID: 3106
	public HomeWindowScript HomeWindow;

	// Token: 0x04000C23 RID: 3107
	public HomeExitScript HomeExit;

	// Token: 0x04000C24 RID: 3108
	public string[] Descriptions;

	// Token: 0x04000C25 RID: 3109
	public GameObject Checkmark;

	// Token: 0x04000C26 RID: 3110
	public Transform Highlight;

	// Token: 0x04000C27 RID: 3111
	public UILabel DescLabel;

	// Token: 0x04000C28 RID: 3112
	public UILabel[] Labels;

	// Token: 0x04000C29 RID: 3113
	public int Limit = 12;

	// Token: 0x04000C2A RID: 3114
	public int ID = 1;

	// Token: 0x04000C2B RID: 3115
	public bool Initialized;
}
