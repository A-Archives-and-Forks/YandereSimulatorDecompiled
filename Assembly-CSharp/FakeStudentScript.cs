﻿using System;
using UnityEngine;

// Token: 0x020002C0 RID: 704
public class FakeStudentScript : MonoBehaviour
{
	// Token: 0x06001477 RID: 5239 RVA: 0x000C7A35 File Offset: 0x000C5C35
	private void Start()
	{
		this.targetRotation = base.transform.rotation;
		this.Student.Club = this.Club;
	}

	// Token: 0x06001478 RID: 5240 RVA: 0x000C7A5C File Offset: 0x000C5C5C
	private void Update()
	{
		if (!this.Student.Talking)
		{
			if (this.LeaderAnim != "")
			{
				base.GetComponent<Animation>().CrossFade(this.LeaderAnim);
			}
			if (this.Rotate)
			{
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, 10f * Time.deltaTime);
				this.RotationTimer += Time.deltaTime;
				if (this.RotationTimer > 1f)
				{
					this.RotationTimer = 0f;
					this.Rotate = false;
				}
			}
		}
		if (this.Prompt.Circle[0].fillAmount == 0f && !this.Yandere.Chased && this.Yandere.Chasers == 0)
		{
			this.Yandere.TargetStudent = this.Student;
			this.Subtitle.UpdateLabel(SubtitleType.ClubGreeting, (int)this.Student.Club, 4f);
			this.DialogueWheel.ClubLeader = true;
			this.StudentManager.DisablePrompts();
			this.DialogueWheel.HideShadows();
			this.DialogueWheel.Show = true;
			this.DialogueWheel.Panel.enabled = true;
			this.Student.Talking = true;
			this.Student.TalkTimer = 0f;
			this.Yandere.ShoulderCamera.OverShoulder = true;
			this.Yandere.WeaponMenu.KeyboardShow = false;
			this.Yandere.WeaponMenu.Show = false;
			this.Yandere.YandereVision = false;
			this.Yandere.CanMove = false;
			this.Yandere.Talking = true;
			this.RotationTimer = 0f;
			this.Rotate = true;
		}
	}

	// Token: 0x04001FA4 RID: 8100
	public StudentManagerScript StudentManager;

	// Token: 0x04001FA5 RID: 8101
	public DialogueWheelScript DialogueWheel;

	// Token: 0x04001FA6 RID: 8102
	public SubtitleScript Subtitle;

	// Token: 0x04001FA7 RID: 8103
	public YandereScript Yandere;

	// Token: 0x04001FA8 RID: 8104
	public StudentScript Student;

	// Token: 0x04001FA9 RID: 8105
	public PromptScript Prompt;

	// Token: 0x04001FAA RID: 8106
	public Quaternion targetRotation;

	// Token: 0x04001FAB RID: 8107
	public float RotationTimer;

	// Token: 0x04001FAC RID: 8108
	public bool Rotate;

	// Token: 0x04001FAD RID: 8109
	public ClubType Club;

	// Token: 0x04001FAE RID: 8110
	public string LeaderAnim;
}
