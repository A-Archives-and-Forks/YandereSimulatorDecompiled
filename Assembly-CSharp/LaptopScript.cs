﻿using System;
using UnityEngine;

// Token: 0x0200034D RID: 845
public class LaptopScript : MonoBehaviour
{
	// Token: 0x06001953 RID: 6483 RVA: 0x000FDC20 File Offset: 0x000FBE20
	private void Start()
	{
		if (SchoolGlobals.SCP || GameGlobals.AlphabetMode)
		{
			this.LaptopScreen.localScale = Vector3.zero;
			this.LaptopCamera.enabled = false;
			this.SCP.SetActive(false);
			base.enabled = false;
			return;
		}
		this.SCPRenderer.sharedMesh = this.Uniforms[StudentGlobals.FemaleUniform];
		Animation component = this.SCP.GetComponent<Animation>();
		component["f02_scp_00"].speed = 0f;
		component["f02_scp_00"].time = 0f;
		this.MyAudio = base.GetComponent<AudioSource>();
	}

	// Token: 0x06001954 RID: 6484 RVA: 0x000FDCC4 File Offset: 0x000FBEC4
	private void Update()
	{
		if (this.FirstFrame == 2)
		{
			this.LaptopCamera.enabled = false;
		}
		this.FirstFrame++;
		if (!this.Off)
		{
			Animation component = this.SCP.GetComponent<Animation>();
			if (!this.React)
			{
				if (this.Yandere.transform.position.x > base.transform.position.x + 1f && Vector3.Distance(this.Yandere.transform.position, new Vector3(base.transform.position.x, 4f, base.transform.position.z)) < 2f && this.Yandere.Followers == 0)
				{
					this.EventSubtitle.transform.localScale = new Vector3(1f, 1f, 1f);
					component["f02_scp_00"].time = 0f;
					this.LaptopCamera.enabled = true;
					component.Play();
					this.Hair.enabled = true;
					this.Jukebox.Dip = 0.5f;
					this.MyAudio.Play();
					this.React = true;
				}
			}
			else
			{
				this.MyAudio.pitch = Time.timeScale;
				this.MyAudio.volume = 1f;
				if (this.Yandere.transform.position.y > base.transform.position.y + 3f || this.Yandere.transform.position.y < base.transform.position.y - 3f)
				{
					this.MyAudio.volume = 0f;
				}
				for (int i = 0; i < this.Cues.Length; i++)
				{
					if (this.MyAudio.time > this.Cues[i])
					{
						this.EventSubtitle.text = this.Subs[i];
					}
				}
				if (this.MyAudio.time >= this.MyAudio.clip.length - 1f || this.MyAudio.time == 0f)
				{
					component["f02_scp_00"].speed = 1f;
					this.Timer += Time.deltaTime;
				}
				else
				{
					component["f02_scp_00"].time = this.MyAudio.time;
				}
				if (this.Timer > 1f || Vector3.Distance(this.Yandere.transform.position, new Vector3(base.transform.position.x, 4f, base.transform.position.z)) > 5f)
				{
					this.TurnOff();
				}
			}
			if (this.Yandere.StudentManager.Clock.HourTime > 16f || this.Yandere.Police.FadeOut)
			{
				this.TurnOff();
				return;
			}
		}
		else
		{
			if (this.LaptopScreen.localScale.x > 0.1f)
			{
				this.LaptopScreen.localScale = Vector3.Lerp(this.LaptopScreen.localScale, Vector3.zero, Time.deltaTime * 10f);
				return;
			}
			if (base.enabled)
			{
				this.LaptopScreen.localScale = Vector3.zero;
				this.Hair.enabled = false;
				base.enabled = false;
			}
		}
	}

	// Token: 0x06001955 RID: 6485 RVA: 0x000FE058 File Offset: 0x000FC258
	private void TurnOff()
	{
		this.MyAudio.clip = this.ShutDown;
		this.MyAudio.Play();
		this.EventSubtitle.text = string.Empty;
		SchoolGlobals.SCP = true;
		this.LaptopCamera.enabled = false;
		this.Jukebox.Dip = 1f;
		this.React = false;
		this.Off = true;
	}

	// Token: 0x040027E5 RID: 10213
	public SkinnedMeshRenderer SCPRenderer;

	// Token: 0x040027E6 RID: 10214
	public Camera LaptopCamera;

	// Token: 0x040027E7 RID: 10215
	public JukeboxScript Jukebox;

	// Token: 0x040027E8 RID: 10216
	public YandereScript Yandere;

	// Token: 0x040027E9 RID: 10217
	public AudioSource MyAudio;

	// Token: 0x040027EA RID: 10218
	public DynamicBone Hair;

	// Token: 0x040027EB RID: 10219
	public Transform LaptopScreen;

	// Token: 0x040027EC RID: 10220
	public AudioClip ShutDown;

	// Token: 0x040027ED RID: 10221
	public GameObject SCP;

	// Token: 0x040027EE RID: 10222
	public bool React;

	// Token: 0x040027EF RID: 10223
	public bool Off;

	// Token: 0x040027F0 RID: 10224
	public float[] Cues;

	// Token: 0x040027F1 RID: 10225
	public string[] Subs;

	// Token: 0x040027F2 RID: 10226
	public Mesh[] Uniforms;

	// Token: 0x040027F3 RID: 10227
	public int FirstFrame;

	// Token: 0x040027F4 RID: 10228
	public float Timer;

	// Token: 0x040027F5 RID: 10229
	public UILabel EventSubtitle;
}
