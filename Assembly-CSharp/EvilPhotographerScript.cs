﻿using System;
using UnityEngine;

// Token: 0x020002C1 RID: 705
public class EvilPhotographerScript : MonoBehaviour
{
	// Token: 0x0600148B RID: 5259 RVA: 0x000C8707 File Offset: 0x000C6907
	private void Start()
	{
		this.Subtitle.transform.localScale = new Vector3(0f, 0f, 0f);
	}

	// Token: 0x0600148C RID: 5260 RVA: 0x000C8730 File Offset: 0x000C6930
	private void Update()
	{
		if (!this.GameOver)
		{
			if (this.Yandere.transform.position.y > base.transform.position.y - 1f && this.Yandere.transform.position.y < base.transform.position.y + 1f)
			{
				if (this.Distracted)
				{
					Quaternion b = Quaternion.LookRotation(new Vector3(this.DistractionPoint.x, base.transform.position.y, this.DistractionPoint.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * 10f);
					this.DistractionTimer -= Time.deltaTime;
					if (this.DistractionTimer < 0f)
					{
						this.Distracted = false;
					}
				}
				else
				{
					this.Distance = Vector3.Distance(this.Yandere.transform.position, base.transform.position);
					if (this.Distance < this.MinimumDistance)
					{
						if (!this.Started)
						{
							this.Subtitle.text = this.SpeechText[0];
							this.MyAudio.Play();
							this.Started = true;
						}
						else
						{
							this.MyAudio.pitch = Time.timeScale;
							if (this.SpeechPhase < this.SpeechTime.Length)
							{
								this.SpeechTimer += Time.deltaTime;
								if (this.SpeechTimer > this.SpeechTime[this.SpeechPhase])
								{
									this.Subtitle.text = this.SpeechText[this.SpeechPhase];
									this.MyAudio.clip = this.SpeechClip[this.SpeechPhase];
									this.MyAudio.Play();
									this.SpeechPhase++;
									if (this.Shocked && this.SpeechPhase > 3)
									{
										this.WaitAnim = "guardCorpse_00";
										this.Node = this.PanicNode;
										this.Searching = true;
										this.Shocked = false;
									}
								}
							}
							this.Scale = Mathf.Abs(1f - (this.Distance - 5f) / this.MinimumDistance);
							if (this.Scale < 0f)
							{
								this.Scale = 0f;
							}
							if (this.Scale > 1f)
							{
								this.Scale = 1f;
							}
							this.Jukebox.volume = 1f - 0.9f * this.Scale;
							this.Subtitle.transform.localScale = new Vector3(this.Scale, this.Scale, this.Scale);
							this.MyAudio.volume = this.Scale;
						}
						if (this.Distance < 0.5f)
						{
							Debug.Log("Got a ''proximity'' game over from " + base.gameObject.name);
							AudioSource.PlayClipAtPoint(this.SpottedSound, Camera.main.transform.position);
							this.TransitionToGameOver();
						}
					}
					else if (this.Distance < this.MinimumDistance + 1f)
					{
						this.Jukebox.volume = 1f;
						this.MyAudio.volume = 0f;
						this.Subtitle.transform.localScale = new Vector3(0f, 0f, 0f);
						this.Subtitle.text = "";
					}
				}
				this.LookForYandere();
			}
			else if (this.Alpha > 0f)
			{
				this.Alpha -= Time.deltaTime;
				this.Marker.Tex.transform.localScale = new Vector3(1f, this.Alpha, 1f);
				this.Marker.Tex.color = new Color(1f, 0f, 0f, this.Alpha);
			}
			if (this.Distracted)
			{
				this.MyAnimation.CrossFade(this.WaitAnim);
				return;
			}
			if (Vector3.Distance(base.transform.position, this.Node[this.CurrentNode].position) >= 0.1f)
			{
				if (this.ShockTimer == 0f)
				{
					if (this.Fire != null && this.Fire.activeInHierarchy)
					{
						base.transform.position = Vector3.MoveTowards(base.transform.position, this.Node[this.CurrentNode].position, Time.deltaTime * 4f);
						this.MyAnimation.CrossFade(this.RunAnim);
					}
					else
					{
						base.transform.position = Vector3.MoveTowards(base.transform.position, this.Node[this.CurrentNode].position, Time.deltaTime);
						this.MyAnimation.CrossFade(this.WalkAnim);
					}
				}
				else
				{
					this.MyAnimation.CrossFade(this.WaitAnim);
					this.ShockTimer = Mathf.MoveTowards(this.ShockTimer, 0f, Time.deltaTime);
				}
				Quaternion b2 = Quaternion.LookRotation(this.Node[this.CurrentNode].position - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b2, Time.deltaTime * 10f);
				return;
			}
			base.transform.rotation = Quaternion.Slerp(base.transform.rotation, this.Node[this.CurrentNode].rotation, Time.deltaTime * 10f);
			this.MyAnimation.CrossFade(this.WaitAnim);
			this.WaitTimer += Time.deltaTime;
			if (this.WaitTimer > 10f && !this.Shocked)
			{
				this.WaitTimer = 0f;
				this.CurrentNode++;
				if (this.CurrentNode >= this.Node.Length)
				{
					this.CurrentNode = 1;
				}
				if (!this.Searching && this.Fire != null && this.Fire.activeInHierarchy)
				{
					this.SpeechClip = this.ShockClip;
					this.SpeechText = this.ShockText;
					this.SpeechTime = this.ShockTime;
					this.SpeechPhase = 0;
					this.SpeechTimer = 0f;
					this.Subtitle.text = this.SpeechText[0];
					this.MyAudio.clip = this.SpeechClip[0];
					this.MyAudio.Play();
					this.WaitAnim = "scaredIdle_01";
					this.CurrentNode = 1;
					this.ShockTimer = 1f;
					this.Shocked = true;
					return;
				}
			}
		}
		else if (this.GameOverPhase == 0)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 1f && !this.MyAudio.isPlaying)
			{
				Debug.Log("Should be updating the subtitle with the Game Over text.");
				this.Subtitle.transform.localScale = new Vector3(1f, 1f, 1f);
				if (this.Shocked)
				{
					this.Subtitle.text = this.ShockedGameOverText;
					this.MyAudio.clip = this.ShockedGameOverLine;
				}
				else
				{
					this.Subtitle.text = this.GameOverText;
					this.MyAudio.clip = this.GameOverLine;
				}
				this.MyAudio.Play();
				this.GameOverPhase++;
				return;
			}
		}
		else if (!this.MyAudio.isPlaying || Input.GetButton("A"))
		{
			this.Heartbroken.SetActive(true);
			this.Subtitle.text = "";
			base.enabled = false;
			this.MyAudio.Stop();
		}
	}

	// Token: 0x0600148D RID: 5261 RVA: 0x000C8F4C File Offset: 0x000C714C
	private bool YandereIsInFOV()
	{
		Vector3 to = this.Yandere.transform.position - this.Head.position;
		float num = 90f;
		return Vector3.Angle(this.Head.forward, to) <= num;
	}

	// Token: 0x0600148E RID: 5262 RVA: 0x000C8F98 File Offset: 0x000C7198
	private bool YandereIsInLOS()
	{
		Debug.DrawLine(this.Head.position, new Vector3(this.Yandere.transform.position.x, this.Yandere.MyController.height - 0.2f, this.Yandere.transform.position.z), Color.red);
		RaycastHit raycastHit;
		return Physics.Linecast(this.Head.position, new Vector3(this.Yandere.transform.position.x, this.Yandere.MyController.height - 0.2f, this.Yandere.transform.position.z), out raycastHit) && raycastHit.collider.gameObject.layer == 13;
	}

	// Token: 0x0600148F RID: 5263 RVA: 0x000C9070 File Offset: 0x000C7270
	private void TransitionToGameOver()
	{
		this.Marker.Tex.transform.localScale = new Vector3(1f, 0f, 1f);
		this.Marker.Tex.color = new Color(1f, 0f, 0f, 0f);
		this.Darkness.material.color = new Color(0f, 0f, 0f, 1f);
		this.Yandere.RPGCamera.enabled = false;
		this.Yandere.CanMove = false;
		this.Subtitle.text = "";
		this.GameOver = true;
		this.Jukebox.Stop();
		this.MyAudio.Stop();
		this.Alpha = 0f;
	}

	// Token: 0x06001490 RID: 5264 RVA: 0x000C9150 File Offset: 0x000C7350
	private void LookForYandere()
	{
		if (!this.Yandere.Invisible)
		{
			this.NoticeSpeed = (this.MinimumDistance - this.Distance) * this.Awareness;
			if (this.YandereIsInFOV())
			{
				if (this.YandereIsInLOS())
				{
					this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime * this.NoticeSpeed);
				}
				else
				{
					this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime);
				}
			}
			else
			{
				this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime);
			}
			if (this.Alpha == 1f)
			{
				Debug.Log("Got a ''witnessed'' game over from " + base.gameObject.name);
				AudioSource.PlayClipAtPoint(this.GameOverSound, Camera.main.transform.position);
				this.TransitionToGameOver();
			}
			if (this.Alpha < 0f)
			{
				this.Alpha = 0f;
			}
			this.Marker.Tex.transform.localScale = new Vector3(1f, this.Alpha, 1f);
			this.Marker.Tex.color = new Color(1f, 0f, 0f, this.Alpha);
		}
	}

	// Token: 0x04001FA8 RID: 8104
	public StalkerYandereScript Yandere;

	// Token: 0x04001FA9 RID: 8105
	public DetectionMarkerScript Marker;

	// Token: 0x04001FAA RID: 8106
	public AudioClip ShockedGameOverLine;

	// Token: 0x04001FAB RID: 8107
	public AudioClip GameOverSound;

	// Token: 0x04001FAC RID: 8108
	public AudioClip GameOverLine;

	// Token: 0x04001FAD RID: 8109
	public AudioClip SpottedSound;

	// Token: 0x04001FAE RID: 8110
	public GameObject Heartbroken;

	// Token: 0x04001FAF RID: 8111
	public GameObject Fire;

	// Token: 0x04001FB0 RID: 8112
	public Animation MyAnimation;

	// Token: 0x04001FB1 RID: 8113
	public Transform YandereHead;

	// Token: 0x04001FB2 RID: 8114
	public Transform Head;

	// Token: 0x04001FB3 RID: 8115
	public AudioSource Jukebox;

	// Token: 0x04001FB4 RID: 8116
	public AudioSource MyAudio;

	// Token: 0x04001FB5 RID: 8117
	public Renderer Darkness;

	// Token: 0x04001FB6 RID: 8118
	public UILabel Subtitle;

	// Token: 0x04001FB7 RID: 8119
	public Transform[] PanicNode;

	// Token: 0x04001FB8 RID: 8120
	public Transform[] Node;

	// Token: 0x04001FB9 RID: 8121
	public AudioClip[] SpeechClip;

	// Token: 0x04001FBA RID: 8122
	public string[] SpeechText;

	// Token: 0x04001FBB RID: 8123
	public float[] SpeechTime;

	// Token: 0x04001FBC RID: 8124
	public AudioClip[] ShockClip;

	// Token: 0x04001FBD RID: 8125
	public string[] ShockText;

	// Token: 0x04001FBE RID: 8126
	public float[] ShockTime;

	// Token: 0x04001FBF RID: 8127
	public string ShockedGameOverText;

	// Token: 0x04001FC0 RID: 8128
	public string GameOverText;

	// Token: 0x04001FC1 RID: 8129
	public string WaitAnim;

	// Token: 0x04001FC2 RID: 8130
	public string WalkAnim;

	// Token: 0x04001FC3 RID: 8131
	public string RunAnim;

	// Token: 0x04001FC4 RID: 8132
	public float MinimumDistance;

	// Token: 0x04001FC5 RID: 8133
	public float SpeechTimer;

	// Token: 0x04001FC6 RID: 8134
	public float NoticeSpeed;

	// Token: 0x04001FC7 RID: 8135
	public float ShockTimer;

	// Token: 0x04001FC8 RID: 8136
	public float Awareness;

	// Token: 0x04001FC9 RID: 8137
	public float WaitTimer;

	// Token: 0x04001FCA RID: 8138
	public float Distance;

	// Token: 0x04001FCB RID: 8139
	public float Alpha;

	// Token: 0x04001FCC RID: 8140
	public float Scale;

	// Token: 0x04001FCD RID: 8141
	public float Timer;

	// Token: 0x04001FCE RID: 8142
	public float TargetRotation;

	// Token: 0x04001FCF RID: 8143
	public float Rotation;

	// Token: 0x04001FD0 RID: 8144
	public int GameOverPhase;

	// Token: 0x04001FD1 RID: 8145
	public int CurrentNode;

	// Token: 0x04001FD2 RID: 8146
	public int SpeechPhase;

	// Token: 0x04001FD3 RID: 8147
	public bool Searching;

	// Token: 0x04001FD4 RID: 8148
	public bool GameOver;

	// Token: 0x04001FD5 RID: 8149
	public bool Started;

	// Token: 0x04001FD6 RID: 8150
	public bool Shocked;

	// Token: 0x04001FD7 RID: 8151
	public Vector3 DistractionPoint;

	// Token: 0x04001FD8 RID: 8152
	public float DistractionTimer;

	// Token: 0x04001FD9 RID: 8153
	public bool Distracted;
}
