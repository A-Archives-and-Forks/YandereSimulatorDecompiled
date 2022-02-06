﻿using System;
using UnityEngine;

// Token: 0x020003CF RID: 975
public class ReputationScript : MonoBehaviour
{
	// Token: 0x06001B58 RID: 7000 RVA: 0x00133803 File Offset: 0x00131A03
	private void Start()
	{
		if (MissionModeGlobals.MissionMode)
		{
			this.MissionMode = true;
		}
		if (GameGlobals.Eighties)
		{
			this.BecomeEighties();
		}
		this.Reputation = PlayerGlobals.Reputation;
		this.RepUpdateLabel.enabled = true;
	}

	// Token: 0x06001B59 RID: 7001 RVA: 0x00133838 File Offset: 0x00131A38
	private void Update()
	{
		switch (this.Phase)
		{
		case 1:
			if (this.Clock.PresentTime / 60f > 8.5f)
			{
				this.Phase++;
			}
			break;
		case 2:
			if (this.Clock.PresentTime / 60f > 13.5f)
			{
				this.Phase++;
			}
			break;
		case 3:
			if (this.Clock.PresentTime / 60f > 18f)
			{
				this.RepUpdateLabel.text = "REP WILL UPDATE AFTER SCHOOL";
				this.Phase++;
			}
			break;
		}
		if (this.CheckedRep < this.Phase && !this.StudentManager.Yandere.Struggling && !this.StudentManager.Yandere.DelinquentFighting && !this.StudentManager.Yandere.Pickpocketing && !this.StudentManager.Yandere.Noticed && !this.ArmDetector.SummonDemon)
		{
			this.UpdateRep();
			if (this.Reputation <= -100f)
			{
				this.Portal.EndDay();
			}
		}
		if (!this.MissionMode)
		{
			if (this.LerpTimer < 1f)
			{
				this.CurrentRepMarker.localPosition = new Vector3(Mathf.Lerp(this.CurrentRepMarker.localPosition.x, -830f + this.Reputation * 1.5f, Time.deltaTime * 10f), this.CurrentRepMarker.localPosition.y, this.CurrentRepMarker.localPosition.z);
				this.PendingRepMarker.localPosition = new Vector3(Mathf.Lerp(this.PendingRepMarker.localPosition.x, this.CurrentRepMarker.transform.localPosition.x + this.PendingRep * 1.5f, Time.deltaTime * 10f), this.PendingRepMarker.localPosition.y, this.PendingRepMarker.localPosition.z);
				this.LerpTimer += Time.deltaTime;
			}
			if (this.PendingRep != this.PreviousRep)
			{
				this.PreviousRep = this.PendingRep;
				this.LerpTimer = 0f;
				if (this.PendingRep > 0f)
				{
					this.PendingRepLabel.text = "+" + this.PendingRep.ToString("F1");
					this.RepUpdateLabel.enabled = true;
				}
				else if (this.PendingRep < 0f)
				{
					this.StudentManager.TutorialWindow.ShowRepMessage = true;
					this.PendingRepLabel.text = this.PendingRep.ToString("F1");
					this.RepUpdateLabel.enabled = true;
				}
				else
				{
					this.RepUpdateLabel.enabled = false;
					this.PendingRepLabel.text = string.Empty;
				}
			}
		}
		else
		{
			this.PendingRepMarker.localPosition = new Vector3(Mathf.Lerp(this.PendingRepMarker.localPosition.x, -980f + this.PendingRep * -3f, Time.deltaTime * 10f), this.PendingRepMarker.localPosition.y, this.PendingRepMarker.localPosition.z);
			if (this.PendingRep < 0f)
			{
				this.PendingRepLabel.text = (-this.PendingRep).ToString("F1");
			}
			else
			{
				this.PendingRepLabel.text = string.Empty;
			}
		}
		if (this.CurrentRepMarker.localPosition.x < -980f)
		{
			this.CurrentRepMarker.localPosition = new Vector3(-980f, this.CurrentRepMarker.localPosition.y, this.CurrentRepMarker.localPosition.z);
		}
		if (this.PendingRepMarker.localPosition.x < -980f)
		{
			this.PendingRepMarker.localPosition = new Vector3(-980f, this.PendingRepMarker.localPosition.y, this.PendingRepMarker.localPosition.z);
		}
		if (this.CurrentRepMarker.localPosition.x > -680f)
		{
			this.CurrentRepMarker.localPosition = new Vector3(-680f, this.CurrentRepMarker.localPosition.y, this.CurrentRepMarker.localPosition.z);
		}
		if (this.PendingRepMarker.localPosition.x > -680f)
		{
			this.PendingRepMarker.localPosition = new Vector3(-680f, this.PendingRepMarker.localPosition.y, this.PendingRepMarker.localPosition.z);
		}
	}

	// Token: 0x06001B5A RID: 7002 RVA: 0x00133D14 File Offset: 0x00131F14
	public void UpdateRep()
	{
		this.Reputation += this.PendingRep;
		this.PendingRep = 0f;
		this.CheckedRep++;
		if (this.StudentManager.Yandere.Club == ClubType.Delinquent)
		{
			if (this.Reputation > -33.33333f)
			{
				this.Reputation = -33.33333f;
			}
		}
		else if (this.Reputation > 100f)
		{
			this.Reputation = 100f;
		}
		this.StudentManager.WipePendingRep();
	}

	// Token: 0x06001B5B RID: 7003 RVA: 0x00133D9E File Offset: 0x00131F9E
	public void BecomeEighties()
	{
		this.StudentManager.EightiesifyLabel(this.PendingRepLabel);
		this.StudentManager.EightiesifyLabel(this.RepUpdateLabel);
		this.StudentManager.EightiesifyLabel(this.RepLabel);
	}

	// Token: 0x04002EB6 RID: 11958
	public StudentManagerScript StudentManager;

	// Token: 0x04002EB7 RID: 11959
	public ArmDetectorScript ArmDetector;

	// Token: 0x04002EB8 RID: 11960
	public PortalScript Portal;

	// Token: 0x04002EB9 RID: 11961
	public Transform CurrentRepMarker;

	// Token: 0x04002EBA RID: 11962
	public Transform PendingRepMarker;

	// Token: 0x04002EBB RID: 11963
	public UILabel PendingRepLabel;

	// Token: 0x04002EBC RID: 11964
	public UILabel RepUpdateLabel;

	// Token: 0x04002EBD RID: 11965
	public UILabel RepLabel;

	// Token: 0x04002EBE RID: 11966
	public ClockScript Clock;

	// Token: 0x04002EBF RID: 11967
	public float Reputation;

	// Token: 0x04002EC0 RID: 11968
	public float LerpTimer;

	// Token: 0x04002EC1 RID: 11969
	public float PreviousRep;

	// Token: 0x04002EC2 RID: 11970
	public float PendingRep;

	// Token: 0x04002EC3 RID: 11971
	public int CheckedRep = 1;

	// Token: 0x04002EC4 RID: 11972
	public int Phase;

	// Token: 0x04002EC5 RID: 11973
	public bool MissionMode;
}
