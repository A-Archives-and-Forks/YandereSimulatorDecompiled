﻿using System;
using Pathfinding;
using UnityEngine;

// Token: 0x02000386 RID: 902
public class NyanDroidScript : MonoBehaviour
{
	// Token: 0x06001A4B RID: 6731 RVA: 0x00115EA4 File Offset: 0x001140A4
	private void Start()
	{
		this.OriginalPosition = base.transform.position;
	}

	// Token: 0x06001A4C RID: 6732 RVA: 0x00115EB8 File Offset: 0x001140B8
	private void Update()
	{
		if (!this.Pathfinding.canSearch)
		{
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Label[0].text = "     Stop";
				this.Prompt.Circle[0].fillAmount = 1f;
				this.Pathfinding.canSearch = true;
				this.Pathfinding.canMove = true;
				return;
			}
		}
		else
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 1f)
			{
				this.Timer = 0f;
				base.transform.position += new Vector3(0f, 0.0001f, 0f);
				if (base.transform.position.y < 0f)
				{
					base.transform.position = new Vector3(base.transform.position.x, 0.001f, base.transform.position.z);
				}
				Physics.SyncTransforms();
			}
			if (Input.GetButtonDown("RB"))
			{
				base.transform.position = this.OriginalPosition;
			}
			if (Vector3.Distance(base.transform.position, this.Pathfinding.target.position) <= 1f)
			{
				this.Character.CrossFade(this.Prefix + "_Idle");
				this.Pathfinding.speed = 0f;
			}
			else if (Vector3.Distance(base.transform.position, this.Pathfinding.target.position) <= 2f)
			{
				this.Character.CrossFade(this.Prefix + "_Walk");
				this.Pathfinding.speed = 0.5f;
			}
			else
			{
				this.Character.CrossFade(this.Prefix + "_Run");
				this.Pathfinding.speed = 5f;
			}
			if (this.Prompt.Circle[0].fillAmount == 0f)
			{
				this.Prompt.Label[0].text = "     Follow";
				this.Prompt.Circle[0].fillAmount = 1f;
				this.Character.CrossFade(this.Prefix + "_Idle");
				this.Pathfinding.canSearch = false;
				this.Pathfinding.canMove = false;
			}
		}
	}

	// Token: 0x04002B0F RID: 11023
	public Animation Character;

	// Token: 0x04002B10 RID: 11024
	public PromptScript Prompt;

	// Token: 0x04002B11 RID: 11025
	public AIPath Pathfinding;

	// Token: 0x04002B12 RID: 11026
	public Vector3 OriginalPosition;

	// Token: 0x04002B13 RID: 11027
	public string Prefix;

	// Token: 0x04002B14 RID: 11028
	public float Timer;
}
