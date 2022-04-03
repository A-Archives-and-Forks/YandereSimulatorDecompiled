﻿using System;
using UnityEngine;

// Token: 0x0200030E RID: 782
public class HeadmasterScript : MonoBehaviour
{
	// Token: 0x06001849 RID: 6217 RVA: 0x000E6E64 File Offset: 0x000E5064
	private void Start()
	{
		this.MyAnimation["HeadmasterRaiseTazer"].speed = 2f;
		this.Tazer.SetActive(false);
		this.IdleAnim = "HeadmasterType";
		if (GameGlobals.Eighties)
		{
			this.IdleAnim = "HeadmasterDeskWritePingPong";
			this.MyAnimation.CrossFade(this.IdleAnim);
			this.EightiesPaper.SetActive(true);
			this.Trashcan.SetActive(false);
			this.Laptop.SetActive(false);
			this.Pen.SetActive(true);
			this.EightiesAttacher.gameObject.SetActive(true);
			this.OriginalMesh[1].GetComponent<SkinnedMeshRenderer>().material = this.Transparency;
			this.OriginalMesh[2].SetActive(false);
			this.OriginalMesh[3].SetActive(false);
			this.OriginalMesh[4].SetActive(false);
			this.OriginalMesh[5].SetActive(false);
			this.HeadmasterSpeechText = this.EightiesHeadmasterSpeechText;
			this.HeadmasterThreatText = this.EightiesHeadmasterThreatText;
			this.HeadmasterBoxText = this.EightiesHeadmasterBoxText;
			this.HeadmasterWeaponText = this.EightiesHeadmasterWeaponText;
			this.HeadmasterCrypticText = this.EightiesHeadmasterCrypticText;
			this.HeadmasterCorpseText = this.EightiesHeadmasterCorpseText;
			this.Head = this.Head.parent;
			this.MyAudio.volume = 0f;
			this.MidDistance = 1.54f;
			this.MinDistance = 0.0001f;
			this.Eighties = true;
		}
	}

	// Token: 0x0600184A RID: 6218 RVA: 0x000E6FE0 File Offset: 0x000E51E0
	private void Update()
	{
		if (this.Yandere.transform.position.y > base.transform.position.y - 1f && this.Yandere.transform.position.y < base.transform.position.y + 1f && this.Yandere.transform.position.x < 6f && this.Yandere.transform.position.x > -6f)
		{
			this.Distance = Vector3.Distance(base.transform.position, this.Yandere.transform.position);
			if (this.Shooting)
			{
				this.targetRotation = Quaternion.LookRotation(base.transform.position - this.Yandere.transform.position);
				this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				this.AimWeaponAtYandere();
				this.AimBodyAtYandere();
				this.Yandere.CanMove = false;
			}
			else if (this.Distance < this.MinDistance)
			{
				this.AimBodyAtYandere();
				if (this.Yandere.CanMove && !this.Yandere.Egg && !this.Shooting)
				{
					this.Shoot();
				}
			}
			else if (this.Distance < this.MidDistance)
			{
				this.PlayedSitSound = false;
				if (!this.StudentManager.Eighties)
				{
					if (!this.StudentManager.Clock.StopTime)
					{
						this.PatienceTimer -= Time.deltaTime;
					}
					if (this.PatienceTimer < 0f && !this.Yandere.Egg)
					{
						this.LostPatience = true;
						this.PatienceTimer = 60f;
						this.Patience = 0;
						this.Shoot();
					}
					if (!this.LostPatience)
					{
						this.LostPatience = true;
						this.Patience--;
						if (this.Patience < 1 && !this.Yandere.Egg && !this.Shooting)
						{
							this.Shoot();
						}
					}
					this.AimBodyAtYandere();
					this.Threatened = true;
					this.AimWeaponAtYandere();
				}
				this.ThreatTimer = Mathf.MoveTowards(this.ThreatTimer, 0f, Time.deltaTime);
				if (this.ThreatTimer == 0f)
				{
					this.ThreatID++;
					if (this.ThreatID < 5)
					{
						this.HeadmasterSubtitle.text = this.HeadmasterThreatText[this.ThreatID];
						this.MyAudio.clip = this.HeadmasterThreatClips[this.ThreatID];
						this.MyAudio.Play();
						this.ThreatTimer = this.HeadmasterThreatClips[this.ThreatID].length + 1f;
					}
				}
				this.CheckBehavior();
			}
			else if (this.Distance < this.MaxDistance)
			{
				this.PlayedStandSound = false;
				this.LostPatience = false;
				this.targetRotation = Quaternion.LookRotation(new Vector3(0f, 8f, 0f) - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 10f);
				this.Chair.localPosition = Vector3.Lerp(this.Chair.localPosition, new Vector3(this.Chair.localPosition.x, this.Chair.localPosition.y, -4.66666f), Time.deltaTime * 1f);
				this.LookAtPlayer = true;
				if (!this.Threatened)
				{
					if (this.StudentManager.Eighties && this.Yandere.transform.position.z < -32.63333f)
					{
						this.MyAnimation.CrossFade(this.IdleAnim, 1f);
						this.LookAtPlayer = false;
					}
					else
					{
						this.MyAnimation.CrossFade("HeadmasterAttention", 1f);
					}
					this.ScratchTimer = 0f;
					this.SpeechTimer = Mathf.MoveTowards(this.SpeechTimer, 0f, Time.deltaTime);
					if (this.SpeechTimer == 0f)
					{
						if (this.CardboardBox.parent != this.Yandere.Hips && this.Yandere.Mask == null)
						{
							this.VoiceID++;
							if (this.VoiceID < 6)
							{
								this.HeadmasterSubtitle.text = this.HeadmasterSpeechText[this.VoiceID];
								this.MyAudio.clip = this.HeadmasterSpeechClips[this.VoiceID];
								this.MyAudio.Play();
								this.SpeechTimer = this.HeadmasterSpeechClips[this.VoiceID].length + 1f;
							}
						}
						else
						{
							this.BoxID++;
							if (this.BoxID < 6)
							{
								this.HeadmasterSubtitle.text = this.HeadmasterBoxText[this.BoxID];
								this.MyAudio.clip = this.HeadmasterBoxClips[this.BoxID];
								this.MyAudio.Play();
								this.SpeechTimer = this.HeadmasterBoxClips[this.BoxID].length + 1f;
							}
						}
					}
				}
				else if (!this.Relaxing)
				{
					this.HeadmasterSubtitle.text = this.HeadmasterRelaxText;
					this.MyAudio.clip = this.HeadmasterRelaxClip;
					this.MyAudio.Play();
					this.Relaxing = true;
				}
				else
				{
					if (!this.PlayedSitSound)
					{
						AudioSource.PlayClipAtPoint(this.SitDown, base.transform.position);
						this.PlayedSitSound = true;
					}
					this.MyAnimation.CrossFade("HeadmasterLowerTazer");
					this.Aiming = false;
					if ((double)this.MyAnimation["HeadmasterLowerTazer"].time > 1.33333)
					{
						this.Tazer.SetActive(false);
					}
					if (this.MyAnimation["HeadmasterLowerTazer"].time > this.MyAnimation["HeadmasterLowerTazer"].length)
					{
						this.Threatened = false;
						this.Relaxing = false;
					}
				}
				this.CheckBehavior();
			}
			else
			{
				if (this.LookAtPlayer)
				{
					this.MyAnimation.CrossFade(this.IdleAnim);
					this.LookAtPlayer = false;
					this.Threatened = false;
					this.Relaxing = false;
					this.Aiming = false;
				}
				this.ScratchTimer += Time.deltaTime;
				if (this.ScratchTimer > 10f)
				{
					this.MyAnimation.CrossFade("HeadmasterScratch");
					if (this.MyAnimation["HeadmasterScratch"].time > this.MyAnimation["HeadmasterScratch"].length)
					{
						this.MyAnimation.CrossFade(this.IdleAnim);
						this.ScratchTimer = 0f;
					}
				}
			}
			if (!this.MyAudio.isPlaying)
			{
				this.HeadmasterSubtitle.text = string.Empty;
				if (this.Shooting)
				{
					this.Taze();
				}
			}
			if (this.Yandere.Attacked && this.Yandere.CharacterAnimation["f02_swingB_00"].time >= this.Yandere.CharacterAnimation["f02_swingB_00"].length * 0.85f)
			{
				this.MyAudio.clip = this.Crumple;
				this.MyAudio.Play();
				base.enabled = false;
				return;
			}
		}
		else
		{
			this.HeadmasterSubtitle.text = string.Empty;
		}
	}

	// Token: 0x0600184B RID: 6219 RVA: 0x000E77D4 File Offset: 0x000E59D4
	private void LateUpdate()
	{
		if (this.Distance < this.MaxDistance)
		{
			this.LookAtTarget = Vector3.Lerp(this.LookAtTarget, this.LookAtPlayer ? this.Yandere.Head.position : this.Default.position, Time.deltaTime * 10f);
			this.Head.LookAt(this.LookAtTarget);
			if (this.EightiesAttacher.gameObject.activeInHierarchy && !this.Initialized)
			{
				this.EightiesAttacher.newRenderer.SetBlendShapeWeight(11, 100f);
				this.Initialized = true;
			}
			if (this.HeadmasterSubtitle.text != string.Empty)
			{
				this.LipTimer = Mathf.MoveTowards(this.LipTimer, 0f, Time.deltaTime);
				if (this.LipTimer == 0f)
				{
					this.JawRot = UnityEngine.Random.Range(30f, 35f);
					this.LipTimer = 0.1f;
				}
				this.Jaw.transform.localEulerAngles = new Vector3(0f, 0f, this.JawRot);
				return;
			}
			this.Jaw.transform.localEulerAngles = new Vector3(0f, 0f, 30f);
		}
	}

	// Token: 0x0600184C RID: 6220 RVA: 0x000E7928 File Offset: 0x000E5B28
	private void AimBodyAtYandere()
	{
		this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - base.transform.position);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 5f);
		this.Chair.localPosition = Vector3.Lerp(this.Chair.localPosition, new Vector3(this.Chair.localPosition.x, this.Chair.localPosition.y, -5.2f), Time.deltaTime * 1f);
	}

	// Token: 0x0600184D RID: 6221 RVA: 0x000E79DC File Offset: 0x000E5BDC
	private void AimWeaponAtYandere()
	{
		if (!this.Aiming)
		{
			Debug.Log("The headmaster is being told to raise his tazer.");
			this.MyAnimation.CrossFade("HeadmasterRaiseTazer");
			if (!this.PlayedStandSound)
			{
				AudioSource.PlayClipAtPoint(this.StandUp, base.transform.position);
				this.PlayedStandSound = true;
			}
			if ((double)this.MyAnimation["HeadmasterRaiseTazer"].time > 1.166666)
			{
				this.Tazer.SetActive(true);
				this.Aiming = true;
				return;
			}
		}
		else
		{
			Debug.Log("The headmaster is being told to aim his tazer.");
			if (this.MyAnimation["HeadmasterRaiseTazer"].time > this.MyAnimation["HeadmasterRaiseTazer"].length)
			{
				this.MyAnimation.CrossFade("HeadmasterAimTazer");
			}
		}
	}

	// Token: 0x0600184E RID: 6222 RVA: 0x000E7AAC File Offset: 0x000E5CAC
	public void Shoot()
	{
		this.StudentManager.YandereDying = true;
		if (this.StudentManager.Clock.TimeSkip)
		{
			this.StudentManager.Clock.EndTimeSkip();
		}
		this.Yandere.StopAiming();
		this.Yandere.StopLaughing();
		this.Yandere.CharacterAnimation.CrossFade("f02_readyToFight_00");
		if (this.Patience < 1)
		{
			this.HeadmasterSubtitle.text = this.HeadmasterPatienceText;
			this.MyAudio.clip = this.HeadmasterPatienceClip;
		}
		else if (this.Yandere.Armed)
		{
			this.HeadmasterSubtitle.text = this.HeadmasterWeaponText;
			this.MyAudio.clip = this.HeadmasterWeaponClip;
		}
		else if (this.Yandere.Carrying || this.Yandere.Dragging || (this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart))
		{
			this.HeadmasterSubtitle.text = this.HeadmasterCorpseText;
			this.MyAudio.clip = this.HeadmasterCorpseClip;
		}
		else
		{
			this.HeadmasterSubtitle.text = this.HeadmasterAttackText;
			this.MyAudio.clip = this.HeadmasterAttackClip;
		}
		this.StudentManager.StopMoving();
		this.Yandere.EmptyHands();
		this.Yandere.CanMove = false;
		this.Yandere.Stance.Current = StanceType.Standing;
		this.MyAudio.Play();
		this.LookAtPlayer = true;
		this.Shooting = true;
	}

	// Token: 0x0600184F RID: 6223 RVA: 0x000E7C4C File Offset: 0x000E5E4C
	private void CheckBehavior()
	{
		if (this.Yandere.CanMove && !this.Yandere.Egg)
		{
			if (this.Yandere.Chased || this.Yandere.Chasers > 0)
			{
				if (!this.Shooting)
				{
					this.Shoot();
					return;
				}
			}
			else if (this.Yandere.Armed)
			{
				if (!this.Shooting)
				{
					this.Shoot();
					return;
				}
			}
			else if ((this.Yandere.Carrying || this.Yandere.Dragging || (this.Yandere.PickUp != null && this.Yandere.PickUp.BodyPart)) && !this.Shooting)
			{
				this.Shoot();
			}
		}
	}

	// Token: 0x06001850 RID: 6224 RVA: 0x000E7D14 File Offset: 0x000E5F14
	public void Taze()
	{
		if (this.Yandere.CanMove)
		{
			this.StudentManager.YandereDying = true;
			this.Yandere.StopAiming();
			this.Yandere.StopLaughing();
			this.StudentManager.StopMoving();
			this.Yandere.EmptyHands();
			this.Yandere.CanMove = false;
		}
		UnityEngine.Object.Instantiate<GameObject>(this.LightningEffect, this.TazerEffectTarget.position, Quaternion.identity);
		UnityEngine.Object.Instantiate<GameObject>(this.LightningEffect, this.Yandere.Spine[3].position, Quaternion.identity);
		this.MyAudio.clip = this.HeadmasterShockClip;
		this.MyAudio.Play();
		this.Yandere.CharacterAnimation.CrossFade("f02_swingB_00");
		this.Yandere.CharacterAnimation["f02_swingB_00"].time = 0.5f;
		this.Yandere.RPGCamera.enabled = false;
		this.Yandere.FakingReaction = false;
		this.Yandere.Attacked = true;
		this.Heartbroken.Headmaster = true;
		this.Jukebox.Volume = 0f;
		this.Shooting = false;
	}

	// Token: 0x04002376 RID: 9078
	public StudentManagerScript StudentManager;

	// Token: 0x04002377 RID: 9079
	public HeartbrokenScript Heartbroken;

	// Token: 0x04002378 RID: 9080
	public YandereScript Yandere;

	// Token: 0x04002379 RID: 9081
	public JukeboxScript Jukebox;

	// Token: 0x0400237A RID: 9082
	public AudioClip[] HeadmasterSpeechClips;

	// Token: 0x0400237B RID: 9083
	public AudioClip[] HeadmasterThreatClips;

	// Token: 0x0400237C RID: 9084
	public AudioClip[] HeadmasterBoxClips;

	// Token: 0x0400237D RID: 9085
	public AudioClip HeadmasterRelaxClip;

	// Token: 0x0400237E RID: 9086
	public AudioClip HeadmasterAttackClip;

	// Token: 0x0400237F RID: 9087
	public AudioClip HeadmasterCrypticClip;

	// Token: 0x04002380 RID: 9088
	public AudioClip HeadmasterShockClip;

	// Token: 0x04002381 RID: 9089
	public AudioClip HeadmasterPatienceClip;

	// Token: 0x04002382 RID: 9090
	public AudioClip HeadmasterCorpseClip;

	// Token: 0x04002383 RID: 9091
	public AudioClip HeadmasterWeaponClip;

	// Token: 0x04002384 RID: 9092
	public AudioClip Crumple;

	// Token: 0x04002385 RID: 9093
	public AudioClip StandUp;

	// Token: 0x04002386 RID: 9094
	public AudioClip SitDown;

	// Token: 0x04002387 RID: 9095
	public string[] HeadmasterSpeechText = new string[]
	{
		"",
		"Ahh...! It's...it's you!",
		"No, that would be impossible...you must be...her daughter...",
		"I'll tolerate you in my school, but not in my office.",
		"Leave at once.",
		"There is nothing for you to achieve here. Just. Get. Out."
	};

	// Token: 0x04002388 RID: 9096
	public string[] HeadmasterThreatText = new string[]
	{
		"",
		"Not another step!",
		"You're up to no good! I know it!",
		"I'm not going to let you harm me!",
		"I'll use self-defense if I deem it necessary!",
		"This is your final warning. Get out of here...or else."
	};

	// Token: 0x04002389 RID: 9097
	public string[] HeadmasterBoxText = new string[]
	{
		"",
		"What...in...blazes are you doing?",
		"Are you trying to re-enact something you saw in a video game?",
		"Ugh, do you really think such a stupid ploy is going to work?",
		"I know who you are. It's obvious. You're not fooling anyone.",
		"I don't have time for this tomfoolery. Leave at once!"
	};

	// Token: 0x0400238A RID: 9098
	public string[] EightiesHeadmasterSpeechText = new string[]
	{
		"",
		"...oh! Um...hello there, young lady!",
		"Can I, uh...help you with anything?",
		"You don't really...talk much, do you?",
		"Don't you...have a class to run along to?",
		"Well, I suppose there's no harm in letting you spend a bit of time here..."
	};

	// Token: 0x0400238B RID: 9099
	public string[] EightiesHeadmasterThreatText = new string[]
	{
		"",
		"My my, you're quite comfortable here, aren't you?",
		"Care to...introduce yourself?",
		"Most students...don't really do this sort of thing.",
		"You...really seem to have a lot of free time on your hands.",
		"Well, I suppose you're...technically...not breaking any rules..."
	};

	// Token: 0x0400238C RID: 9100
	public string[] EightiesHeadmasterBoxText = new string[]
	{
		"",
		"...uh.",
		"...why are you...doing that?",
		"Is this what the kids like to do these days?",
		"Is this some sort of new fad that nobody told me about?",
		"Well, I suppose that a small amount of tomfoolery is just...part of youth."
	};

	// Token: 0x0400238D RID: 9101
	public string HeadmasterRelaxText = "Hmm...a wise decision.";

	// Token: 0x0400238E RID: 9102
	public string HeadmasterAttackText = "You asked for it!";

	// Token: 0x0400238F RID: 9103
	public string HeadmasterCrypticText = "Mr. Saikou...the deal is off.";

	// Token: 0x04002390 RID: 9104
	public string HeadmasterWeaponText = "How dare you raise a weapon in my office!";

	// Token: 0x04002391 RID: 9105
	public string HeadmasterPatienceText = "Enough of this nonsense!";

	// Token: 0x04002392 RID: 9106
	public string HeadmasterCorpseText = "You...you murderer!";

	// Token: 0x04002393 RID: 9107
	public string EightiesHeadmasterWeaponText = "What are you doing?! Stay back!";

	// Token: 0x04002394 RID: 9108
	public string EightiesHeadmasterCrypticText = "Mr. Saikou, you'll never believe what just happened!";

	// Token: 0x04002395 RID: 9109
	public string EightiesHeadmasterCorpseText = "You...you killed someone!";

	// Token: 0x04002396 RID: 9110
	public UILabel HeadmasterSubtitle;

	// Token: 0x04002397 RID: 9111
	public Animation MyAnimation;

	// Token: 0x04002398 RID: 9112
	public AudioSource MyAudio;

	// Token: 0x04002399 RID: 9113
	public GameObject LightningEffect;

	// Token: 0x0400239A RID: 9114
	public GameObject Tazer;

	// Token: 0x0400239B RID: 9115
	public Transform TazerEffectTarget;

	// Token: 0x0400239C RID: 9116
	public Transform CardboardBox;

	// Token: 0x0400239D RID: 9117
	public Transform Chair;

	// Token: 0x0400239E RID: 9118
	public Quaternion targetRotation;

	// Token: 0x0400239F RID: 9119
	public float PatienceTimer;

	// Token: 0x040023A0 RID: 9120
	public float ScratchTimer;

	// Token: 0x040023A1 RID: 9121
	public float SpeechTimer;

	// Token: 0x040023A2 RID: 9122
	public float ThreatTimer;

	// Token: 0x040023A3 RID: 9123
	public float MaxDistance = 10f;

	// Token: 0x040023A4 RID: 9124
	public float MidDistance = 2.8f;

	// Token: 0x040023A5 RID: 9125
	public float MinDistance = 1.2f;

	// Token: 0x040023A6 RID: 9126
	public float Distance;

	// Token: 0x040023A7 RID: 9127
	public int Patience = 10;

	// Token: 0x040023A8 RID: 9128
	public int ThreatID;

	// Token: 0x040023A9 RID: 9129
	public int VoiceID;

	// Token: 0x040023AA RID: 9130
	public int BoxID;

	// Token: 0x040023AB RID: 9131
	public bool PlayedStandSound;

	// Token: 0x040023AC RID: 9132
	public bool PlayedSitSound;

	// Token: 0x040023AD RID: 9133
	public bool LostPatience;

	// Token: 0x040023AE RID: 9134
	public bool Threatened;

	// Token: 0x040023AF RID: 9135
	public bool Eighties;

	// Token: 0x040023B0 RID: 9136
	public bool Relaxing;

	// Token: 0x040023B1 RID: 9137
	public bool Shooting;

	// Token: 0x040023B2 RID: 9138
	public bool Aiming;

	// Token: 0x040023B3 RID: 9139
	public string IdleAnim;

	// Token: 0x040023B4 RID: 9140
	public RiggedAccessoryAttacher EightiesAttacher;

	// Token: 0x040023B5 RID: 9141
	public GameObject EightiesPaper;

	// Token: 0x040023B6 RID: 9142
	public GameObject Trashcan;

	// Token: 0x040023B7 RID: 9143
	public GameObject Laptop;

	// Token: 0x040023B8 RID: 9144
	public GameObject Pen;

	// Token: 0x040023B9 RID: 9145
	public GameObject[] OriginalMesh;

	// Token: 0x040023BA RID: 9146
	public Material Transparency;

	// Token: 0x040023BB RID: 9147
	public bool LookAtPlayer;

	// Token: 0x040023BC RID: 9148
	public bool Initialized;

	// Token: 0x040023BD RID: 9149
	public Vector3 LookAtTarget;

	// Token: 0x040023BE RID: 9150
	public Transform Default;

	// Token: 0x040023BF RID: 9151
	public Transform Head;

	// Token: 0x040023C0 RID: 9152
	public float LipTimer;

	// Token: 0x040023C1 RID: 9153
	public float JawRot;

	// Token: 0x040023C2 RID: 9154
	public Transform Jaw;
}
