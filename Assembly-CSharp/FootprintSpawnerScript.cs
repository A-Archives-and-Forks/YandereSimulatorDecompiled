﻿using System;
using UnityEngine;

// Token: 0x020002CF RID: 719
public class FootprintSpawnerScript : MonoBehaviour
{
	// Token: 0x060014A3 RID: 5283 RVA: 0x000CA618 File Offset: 0x000C8818
	private void Start()
	{
		if (this.MyAudio == null)
		{
			this.MyAudio = base.GetComponent<AudioSource>();
		}
		this.GardenArea = this.Yandere.StudentManager.GardenArea;
		this.PoolStairs = this.Yandere.StudentManager.PoolStairs;
		this.TreeArea = this.Yandere.StudentManager.TreeArea;
		this.NEStairs = this.Yandere.StudentManager.NEStairs;
		this.NWStairs = this.Yandere.StudentManager.NWStairs;
		this.SEStairs = this.Yandere.StudentManager.SEStairs;
		this.SWStairs = this.Yandere.StudentManager.SWStairs;
	}

	// Token: 0x060014A4 RID: 5284 RVA: 0x000CA6DC File Offset: 0x000C88DC
	private void Update()
	{
		if (!this.FootUp)
		{
			if (base.transform.position.y > this.Yandere.transform.position.y + this.UpThreshold)
			{
				this.FootUp = true;
				return;
			}
		}
		else if (base.transform.position.y < this.Yandere.transform.position.y + this.DownThreshold)
		{
			if (this.Yandere.Stance.Current != StanceType.Crouching && this.Yandere.Stance.Current != StanceType.Crawling && this.Yandere.CanMove && !this.Yandere.NearSenpai && this.FootUp)
			{
				if (this.Yandere.Schoolwear == 0 || this.Yandere.Schoolwear == 2)
				{
					if (this.Yandere.Running)
					{
						this.MyAudio.clip = this.RunBareFootsteps[UnityEngine.Random.Range(0, this.RunBareFootsteps.Length)];
						this.MyAudio.volume = 0.3f;
					}
					else
					{
						this.MyAudio.clip = this.WalkBareFootsteps[UnityEngine.Random.Range(0, this.WalkBareFootsteps.Length)];
						this.MyAudio.volume = 0.2f;
					}
				}
				else if (this.Yandere.Running)
				{
					this.MyAudio.clip = this.RunFootsteps[UnityEngine.Random.Range(0, this.RunFootsteps.Length)];
					this.MyAudio.volume = 0.15f;
				}
				else
				{
					this.MyAudio.clip = this.WalkFootsteps[UnityEngine.Random.Range(0, this.WalkFootsteps.Length)];
					this.MyAudio.volume = 0.1f;
				}
				this.MyAudio.Play();
			}
			this.FootUp = false;
			if (this.Bloodiness > 0)
			{
				this.CanSpawn = (!this.GardenArea.bounds.Contains(base.transform.position) && !this.PoolStairs.bounds.Contains(base.transform.position) && !this.TreeArea.bounds.Contains(base.transform.position) && !this.NEStairs.bounds.Contains(base.transform.position) && !this.NWStairs.bounds.Contains(base.transform.position) && !this.SEStairs.bounds.Contains(base.transform.position) && !this.SWStairs.bounds.Contains(base.transform.position));
				if (this.CanSpawn)
				{
					if (base.transform.position.y > -1f && base.transform.position.y < 1f)
					{
						this.Height = 0f;
					}
					else if (base.transform.position.y > 3f && base.transform.position.y < 5f)
					{
						this.Height = 4f;
					}
					else if (base.transform.position.y > 7f && base.transform.position.y < 9f)
					{
						this.Height = 8f;
					}
					else if (base.transform.position.y > 11f && base.transform.position.y < 13f)
					{
						this.Height = 12f;
					}
					GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BloodyFootprint, new Vector3(base.transform.position.x, this.Height + 0.012f, base.transform.position.z), Quaternion.identity);
					gameObject.transform.eulerAngles = new Vector3(gameObject.transform.eulerAngles.x, base.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
					gameObject.transform.GetChild(0).GetComponent<FootprintScript>().Yandere = this.Yandere;
					gameObject.transform.parent = this.BloodParent;
					this.Bloodiness--;
				}
			}
		}
	}

	// Token: 0x04002041 RID: 8257
	public YandereScript Yandere;

	// Token: 0x04002042 RID: 8258
	public GameObject BloodyFootprint;

	// Token: 0x04002043 RID: 8259
	public AudioClip[] WalkFootsteps;

	// Token: 0x04002044 RID: 8260
	public AudioClip[] RunFootsteps;

	// Token: 0x04002045 RID: 8261
	public AudioClip[] WalkBareFootsteps;

	// Token: 0x04002046 RID: 8262
	public AudioClip[] RunBareFootsteps;

	// Token: 0x04002047 RID: 8263
	public AudioSource MyAudio;

	// Token: 0x04002048 RID: 8264
	public Transform BloodParent;

	// Token: 0x04002049 RID: 8265
	public Collider MyCollider;

	// Token: 0x0400204A RID: 8266
	public Collider GardenArea;

	// Token: 0x0400204B RID: 8267
	public Collider PoolStairs;

	// Token: 0x0400204C RID: 8268
	public Collider TreeArea;

	// Token: 0x0400204D RID: 8269
	public Collider NEStairs;

	// Token: 0x0400204E RID: 8270
	public Collider NWStairs;

	// Token: 0x0400204F RID: 8271
	public Collider SEStairs;

	// Token: 0x04002050 RID: 8272
	public Collider SWStairs;

	// Token: 0x04002051 RID: 8273
	public bool Debugging;

	// Token: 0x04002052 RID: 8274
	public bool CanSpawn;

	// Token: 0x04002053 RID: 8275
	public bool FootUp;

	// Token: 0x04002054 RID: 8276
	public float DownThreshold;

	// Token: 0x04002055 RID: 8277
	public float UpThreshold;

	// Token: 0x04002056 RID: 8278
	public float Height;

	// Token: 0x04002057 RID: 8279
	public int Bloodiness;

	// Token: 0x04002058 RID: 8280
	public int Collisions;
}
