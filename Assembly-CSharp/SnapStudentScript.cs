﻿using System;
using UnityEngine;

// Token: 0x02000433 RID: 1075
public class SnapStudentScript : MonoBehaviour
{
	// Token: 0x06001CD9 RID: 7385 RVA: 0x00156A44 File Offset: 0x00154C44
	private void Start()
	{
		this.MyAnim.enabled = false;
		this.MyAnim[this.FearAnim].time = UnityEngine.Random.Range(0f, this.MyAnim[this.FearAnim].length);
		this.MyAnim.enabled = true;
	}

	// Token: 0x06001CDA RID: 7386 RVA: 0x00156AA0 File Offset: 0x00154CA0
	private void Update()
	{
		if (Vector3.Distance(base.transform.position, this.Yandere.transform.position) < 1f)
		{
			if (this.Yandere.CanMove)
			{
				if (this.Student.StudentID == 1)
				{
					if (this.Yandere.Armed && !this.Yandere.KillingSenpai)
					{
						this.Yandere.Knife.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
						this.Yandere.MyAudio.clip = this.Yandere.EndSNAP;
						this.Yandere.MyAudio.loop = false;
						this.Yandere.MyAudio.volume = 1f;
						this.Yandere.MyAudio.pitch = 1f;
						this.Yandere.MyAudio.Play();
						this.Yandere.Speed = 0f;
						this.Yandere.MyAnim.CrossFade("f02_snapKill_00");
						this.MyAnim.CrossFade("snapDie_00");
						this.Yandere.TargetStudent = this;
						this.Yandere.KillingSenpai = true;
						this.Yandere.CanMove = false;
						base.enabled = false;
					}
				}
				else if (!this.Yandere.Attacking)
				{
					this.Yandere.transform.position = base.transform.position + base.transform.forward;
					this.Yandere.transform.LookAt(base.transform.position);
					this.Yandere.TargetStudent = this;
					this.Yandere.Attacking = true;
					this.Yandere.CanMove = false;
					this.Yandere.StaticNoise.volume = 0f;
					this.Yandere.Static.Fade = 0f;
					this.Yandere.HurryTimer = 0f;
					this.Yandere.ChooseAttack();
					this.Student.Pathfinding.enabled = false;
					base.enabled = false;
				}
			}
		}
		else if (Vector3.Distance(base.transform.position, this.Yandere.transform.position) < 5f)
		{
			if (!this.VoicedConcern && this.Yandere.CanMove && !this.Yandere.SnapVoice.isPlaying)
			{
				if (this.Student.StudentID == 1)
				{
					this.Yandere.SnapVoice.clip = this.SenpaiFear;
					this.Yandere.SnapVoice.Play();
					this.Yandere.ListenTimer = 10f;
				}
				else
				{
					int voiceID = this.Yandere.VoiceID;
					while (this.Yandere.VoiceID == voiceID)
					{
						this.Yandere.VoiceID = UnityEngine.Random.Range(0, 5);
					}
					this.Yandere.SnapVoice.clip = this.StudentFear[this.Yandere.VoiceID];
					this.Yandere.SnapVoice.Play();
					this.Yandere.ListenTimer = 1f;
				}
				this.VoicedConcern = true;
			}
			this.MyAnim.Play(this.FearAnim);
		}
		else
		{
			this.MyAnim.Play(this.FearAnim);
		}
		if (!this.Yandere.Attacking)
		{
			base.transform.LookAt(new Vector3(this.Yandere.transform.position.x, base.transform.position.y, this.Yandere.transform.position.z));
		}
	}

	// Token: 0x040033F3 RID: 13299
	public SnappedYandereScript Yandere;

	// Token: 0x040033F4 RID: 13300
	public Quaternion targetRotation;

	// Token: 0x040033F5 RID: 13301
	public StudentScript Student;

	// Token: 0x040033F6 RID: 13302
	public Animation MyAnim;

	// Token: 0x040033F7 RID: 13303
	public string FearAnim;

	// Token: 0x040033F8 RID: 13304
	public string[] AttackAnims;

	// Token: 0x040033F9 RID: 13305
	public bool VoicedConcern;

	// Token: 0x040033FA RID: 13306
	public AudioClip[] StudentFear;

	// Token: 0x040033FB RID: 13307
	public AudioClip SenpaiFear;
}
