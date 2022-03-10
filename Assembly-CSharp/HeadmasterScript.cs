﻿using System;
using UnityEngine;

// Token: 0x0200030D RID: 781
public class HeadmasterScript : MonoBehaviour
{
	// Token: 0x0600183E RID: 6206 RVA: 0x000E64B8 File Offset: 0x000E46B8
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
		}
	}

	// Token: 0x0600183F RID: 6207 RVA: 0x000E662C File Offset: 0x000E482C
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

	// Token: 0x06001840 RID: 6208 RVA: 0x000E6E20 File Offset: 0x000E5020
	private void LateUpdate()
	{
		this.LookAtTarget = Vector3.Lerp(this.LookAtTarget, this.LookAtPlayer ? this.Yandere.Head.position : this.Default.position, Time.deltaTime * 10f);
		this.Head.LookAt(this.LookAtTarget);
	}

	// Token: 0x06001841 RID: 6209 RVA: 0x000E6E80 File Offset: 0x000E5080
	private void AimBodyAtYandere()
	{
		this.targetRotation = Quaternion.LookRotation(this.Yandere.transform.position - base.transform.position);
		base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.targetRotation, Time.deltaTime * 5f);
		this.Chair.localPosition = Vector3.Lerp(this.Chair.localPosition, new Vector3(this.Chair.localPosition.x, this.Chair.localPosition.y, -5.2f), Time.deltaTime * 1f);
	}

	// Token: 0x06001842 RID: 6210 RVA: 0x000E6F34 File Offset: 0x000E5134
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

	// Token: 0x06001843 RID: 6211 RVA: 0x000E7004 File Offset: 0x000E5204
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

	// Token: 0x06001844 RID: 6212 RVA: 0x000E71A4 File Offset: 0x000E53A4
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

	// Token: 0x06001845 RID: 6213 RVA: 0x000E726C File Offset: 0x000E546C
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

	// Token: 0x04002357 RID: 9047
	public StudentManagerScript StudentManager;

	// Token: 0x04002358 RID: 9048
	public HeartbrokenScript Heartbroken;

	// Token: 0x04002359 RID: 9049
	public YandereScript Yandere;

	// Token: 0x0400235A RID: 9050
	public JukeboxScript Jukebox;

	// Token: 0x0400235B RID: 9051
	public AudioClip[] HeadmasterSpeechClips;

	// Token: 0x0400235C RID: 9052
	public AudioClip[] HeadmasterThreatClips;

	// Token: 0x0400235D RID: 9053
	public AudioClip[] HeadmasterBoxClips;

	// Token: 0x0400235E RID: 9054
	public AudioClip HeadmasterRelaxClip;

	// Token: 0x0400235F RID: 9055
	public AudioClip HeadmasterAttackClip;

	// Token: 0x04002360 RID: 9056
	public AudioClip HeadmasterCrypticClip;

	// Token: 0x04002361 RID: 9057
	public AudioClip HeadmasterShockClip;

	// Token: 0x04002362 RID: 9058
	public AudioClip HeadmasterPatienceClip;

	// Token: 0x04002363 RID: 9059
	public AudioClip HeadmasterCorpseClip;

	// Token: 0x04002364 RID: 9060
	public AudioClip HeadmasterWeaponClip;

	// Token: 0x04002365 RID: 9061
	public AudioClip Crumple;

	// Token: 0x04002366 RID: 9062
	public AudioClip StandUp;

	// Token: 0x04002367 RID: 9063
	public AudioClip SitDown;

	// Token: 0x04002368 RID: 9064
	public string[] HeadmasterSpeechText = new string[]
	{
		"",
		"Ahh...! It's...it's you!",
		"No, that would be impossible...you must be...her daughter...",
		"I'll tolerate you in my school, but not in my office.",
		"Leave at once.",
		"There is nothing for you to achieve here. Just. Get. Out."
	};

	// Token: 0x04002369 RID: 9065
	public string[] HeadmasterThreatText = new string[]
	{
		"",
		"Not another step!",
		"You're up to no good! I know it!",
		"I'm not going to let you harm me!",
		"I'll use self-defense if I deem it necessary!",
		"This is your final warning. Get out of here...or else."
	};

	// Token: 0x0400236A RID: 9066
	public string[] HeadmasterBoxText = new string[]
	{
		"",
		"What...in...blazes are you doing?",
		"Are you trying to re-enact something you saw in a video game?",
		"Ugh, do you really think such a stupid ploy is going to work?",
		"I know who you are. It's obvious. You're not fooling anyone.",
		"I don't have time for this tomfoolery. Leave at once!"
	};

	// Token: 0x0400236B RID: 9067
	public string[] EightiesHeadmasterSpeechText = new string[]
	{
		"",
		"...oh! Um...hello there, young lady!",
		"Can I, uh...help you with anything?",
		"You don't really...talk much, do you?",
		"Don't you...have a class to run along to?",
		"Well, I suppose there's no harm in letting you spend a bit of time here..."
	};

	// Token: 0x0400236C RID: 9068
	public string[] EightiesHeadmasterThreatText = new string[]
	{
		"",
		"My my, you're quite comfortable here, aren't you?",
		"Care to...introduce yourself?",
		"Most students...don't really do this sort of thing.",
		"You...really seem to have a lot of free time on your hands.",
		"Well, I suppose you're...technically...not breaking any rules..."
	};

	// Token: 0x0400236D RID: 9069
	public string[] EightiesHeadmasterBoxText = new string[]
	{
		"",
		"...uh.",
		"...why are you...doing that?",
		"Is this what the kids like to do these days?",
		"Is this some sort of new fad that nobody told me about?",
		"Well, I suppose that a small amount of tomfoolery is just...part of youth."
	};

	// Token: 0x0400236E RID: 9070
	public string HeadmasterRelaxText = "Hmm...a wise decision.";

	// Token: 0x0400236F RID: 9071
	public string HeadmasterAttackText = "You asked for it!";

	// Token: 0x04002370 RID: 9072
	public string HeadmasterCrypticText = "Mr. Saikou...the deal is off.";

	// Token: 0x04002371 RID: 9073
	public string HeadmasterWeaponText = "How dare you raise a weapon in my office!";

	// Token: 0x04002372 RID: 9074
	public string HeadmasterPatienceText = "Enough of this nonsense!";

	// Token: 0x04002373 RID: 9075
	public string HeadmasterCorpseText = "You...you murderer!";

	// Token: 0x04002374 RID: 9076
	public string EightiesHeadmasterWeaponText = "What are you doing?! Stay back!";

	// Token: 0x04002375 RID: 9077
	public string EightiesHeadmasterCrypticText = "Mr. Saikou, you'll never believe what just happened!";

	// Token: 0x04002376 RID: 9078
	public string EightiesHeadmasterCorpseText = "You...you killed someone!";

	// Token: 0x04002377 RID: 9079
	public UILabel HeadmasterSubtitle;

	// Token: 0x04002378 RID: 9080
	public Animation MyAnimation;

	// Token: 0x04002379 RID: 9081
	public AudioSource MyAudio;

	// Token: 0x0400237A RID: 9082
	public GameObject LightningEffect;

	// Token: 0x0400237B RID: 9083
	public GameObject Tazer;

	// Token: 0x0400237C RID: 9084
	public Transform TazerEffectTarget;

	// Token: 0x0400237D RID: 9085
	public Transform CardboardBox;

	// Token: 0x0400237E RID: 9086
	public Transform Chair;

	// Token: 0x0400237F RID: 9087
	public Quaternion targetRotation;

	// Token: 0x04002380 RID: 9088
	public float PatienceTimer;

	// Token: 0x04002381 RID: 9089
	public float ScratchTimer;

	// Token: 0x04002382 RID: 9090
	public float SpeechTimer;

	// Token: 0x04002383 RID: 9091
	public float ThreatTimer;

	// Token: 0x04002384 RID: 9092
	public float MaxDistance = 10f;

	// Token: 0x04002385 RID: 9093
	public float MidDistance = 2.8f;

	// Token: 0x04002386 RID: 9094
	public float MinDistance = 1.2f;

	// Token: 0x04002387 RID: 9095
	public float Distance;

	// Token: 0x04002388 RID: 9096
	public int Patience = 10;

	// Token: 0x04002389 RID: 9097
	public int ThreatID;

	// Token: 0x0400238A RID: 9098
	public int VoiceID;

	// Token: 0x0400238B RID: 9099
	public int BoxID;

	// Token: 0x0400238C RID: 9100
	public bool PlayedStandSound;

	// Token: 0x0400238D RID: 9101
	public bool PlayedSitSound;

	// Token: 0x0400238E RID: 9102
	public bool LostPatience;

	// Token: 0x0400238F RID: 9103
	public bool Threatened;

	// Token: 0x04002390 RID: 9104
	public bool Relaxing;

	// Token: 0x04002391 RID: 9105
	public bool Shooting;

	// Token: 0x04002392 RID: 9106
	public bool Aiming;

	// Token: 0x04002393 RID: 9107
	public string IdleAnim;

	// Token: 0x04002394 RID: 9108
	public RiggedAccessoryAttacher EightiesAttacher;

	// Token: 0x04002395 RID: 9109
	public GameObject EightiesPaper;

	// Token: 0x04002396 RID: 9110
	public GameObject Trashcan;

	// Token: 0x04002397 RID: 9111
	public GameObject Laptop;

	// Token: 0x04002398 RID: 9112
	public GameObject Pen;

	// Token: 0x04002399 RID: 9113
	public GameObject[] OriginalMesh;

	// Token: 0x0400239A RID: 9114
	public Material Transparency;

	// Token: 0x0400239B RID: 9115
	public Vector3 LookAtTarget;

	// Token: 0x0400239C RID: 9116
	public bool LookAtPlayer;

	// Token: 0x0400239D RID: 9117
	public Transform Default;

	// Token: 0x0400239E RID: 9118
	public Transform Head;
}
