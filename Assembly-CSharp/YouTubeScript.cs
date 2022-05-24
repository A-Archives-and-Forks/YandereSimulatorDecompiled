﻿using System;
using RetroAesthetics;
using UnityEngine;

// Token: 0x020004F6 RID: 1270
public class YouTubeScript : MonoBehaviour
{
	// Token: 0x06002128 RID: 8488 RVA: 0x001EC5F0 File Offset: 0x001EA7F0
	private void Start()
	{
		if (this.Girl != null)
		{
			this.Girl["OkaTurn1"].time = 15f;
		}
	}

	// Token: 0x06002129 RID: 8489 RVA: 0x001EC61C File Offset: 0x001EA81C
	private void Update()
	{
		if (this.Type == 6)
		{
			this.MyCamera.orthographicSize -= Time.deltaTime * 0.033333335f;
		}
		if (Input.GetKeyDown("z"))
		{
			this.Phase++;
			if (this.Type == 5)
			{
				this.Label[this.Phase].SetActive(true);
			}
		}
		if (this.Phase > 0)
		{
			if (this.Type == 1)
			{
				base.transform.position += new Vector3(0f, 0f, Time.deltaTime * -0.1f);
			}
			else if (this.Type == 2)
			{
				base.transform.Translate(Vector3.forward * Time.deltaTime * -1f * this.Speed);
			}
			else if (this.Type == 3)
			{
				base.transform.Translate(Vector3.forward * Time.deltaTime * -1f);
				this.Begin = true;
			}
			else if (this.Type == 4)
			{
				this.Begin = true;
			}
		}
		if (this.Begin)
		{
			if (this.Type != 4)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 1f)
				{
					if (this.Phase == 1)
					{
						this.VaporwaveVisuals.ApplyNormalView();
						RenderSettings.skybox = this.Yandere.VaporwaveSkybox;
						this.Phase++;
						this.Bloom = 5f;
						this.Threshold = 0f;
						this.Knee = 1f;
						this.Radius = 7f;
						this.CameraEffects.UpdateBloom(this.Bloom);
						this.CameraEffects.UpdateThreshold(this.Threshold);
						this.CameraEffects.UpdateBloomKnee(this.Knee);
						this.CameraEffects.UpdateBloomRadius(this.Radius);
						for (int i = 1; i < this.Trees.Length; i++)
						{
							Debug.Log("Deactivating trees...or trying to.");
							this.Trees[i].SetActive(false);
						}
						this.EightiesEffects.enabled = true;
						return;
					}
					this.Bloom = Mathf.Lerp(this.Bloom, 1f, Time.deltaTime);
					this.Threshold = Mathf.Lerp(this.Bloom, 1.1f, Time.deltaTime);
					this.Knee = Mathf.Lerp(this.Bloom, 0.5f, Time.deltaTime);
					this.Radius = Mathf.Lerp(this.Bloom, 4f, Time.deltaTime);
					this.CameraEffects.UpdateBloom(this.Bloom);
					this.CameraEffects.UpdateThreshold(this.Threshold);
					this.CameraEffects.UpdateBloomKnee(this.Knee);
					this.CameraEffects.UpdateBloomRadius(this.Radius);
					return;
				}
			}
			else
			{
				this.Speed += Time.deltaTime;
				base.transform.position = Vector3.Lerp(base.transform.position, new Vector3(-1.3f, 0f, 0.4f), Time.deltaTime * this.Speed);
			}
		}
	}

	// Token: 0x0400495D RID: 18781
	public RetroCameraEffect EightiesEffects;

	// Token: 0x0400495E RID: 18782
	public CameraEffectsScript CameraEffects;

	// Token: 0x0400495F RID: 18783
	public NormalBufferView VaporwaveVisuals;

	// Token: 0x04004960 RID: 18784
	public Camera MyCamera;

	// Token: 0x04004961 RID: 18785
	public YandereScript Yandere;

	// Token: 0x04004962 RID: 18786
	public GameObject[] Label;

	// Token: 0x04004963 RID: 18787
	public GameObject[] Trees;

	// Token: 0x04004964 RID: 18788
	public Animation Girl;

	// Token: 0x04004965 RID: 18789
	public float Strength;

	// Token: 0x04004966 RID: 18790
	public float Focus = 1f;

	// Token: 0x04004967 RID: 18791
	public float Bloom = 60f;

	// Token: 0x04004968 RID: 18792
	public float Knee = 1f;

	// Token: 0x04004969 RID: 18793
	public float Radius = 7f;

	// Token: 0x0400496A RID: 18794
	public float Threshold;

	// Token: 0x0400496B RID: 18795
	public float Speed;

	// Token: 0x0400496C RID: 18796
	public float Timer;

	// Token: 0x0400496D RID: 18797
	public bool Begin;

	// Token: 0x0400496E RID: 18798
	public int Phase;

	// Token: 0x0400496F RID: 18799
	public int Type;
}
