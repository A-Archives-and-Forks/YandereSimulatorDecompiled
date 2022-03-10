﻿using System;
using UnityEngine;

// Token: 0x02000094 RID: 148
[RequireComponent(typeof(AudioSource))]
[AddComponentMenu("NGUI/Tween/Tween Volume")]
public class TweenVolume : UITweener
{
	// Token: 0x170000CD RID: 205
	// (get) Token: 0x060005D0 RID: 1488 RVA: 0x00035648 File Offset: 0x00033848
	public AudioSource audioSource
	{
		get
		{
			if (this.mSource == null)
			{
				this.mSource = base.GetComponent<AudioSource>();
				if (this.mSource == null)
				{
					this.mSource = base.GetComponent<AudioSource>();
					if (this.mSource == null)
					{
						Debug.LogError("TweenVolume needs an AudioSource to work with", this);
						base.enabled = false;
					}
				}
			}
			return this.mSource;
		}
	}

	// Token: 0x170000CE RID: 206
	// (get) Token: 0x060005D1 RID: 1489 RVA: 0x000356AF File Offset: 0x000338AF
	// (set) Token: 0x060005D2 RID: 1490 RVA: 0x000356B7 File Offset: 0x000338B7
	[Obsolete("Use 'value' instead")]
	public float volume
	{
		get
		{
			return this.value;
		}
		set
		{
			this.value = value;
		}
	}

	// Token: 0x170000CF RID: 207
	// (get) Token: 0x060005D3 RID: 1491 RVA: 0x000356C0 File Offset: 0x000338C0
	// (set) Token: 0x060005D4 RID: 1492 RVA: 0x000356E1 File Offset: 0x000338E1
	public float value
	{
		get
		{
			if (!(this.audioSource != null))
			{
				return 0f;
			}
			return this.mSource.volume;
		}
		set
		{
			if (this.audioSource != null)
			{
				this.mSource.volume = value;
			}
		}
	}

	// Token: 0x060005D5 RID: 1493 RVA: 0x000356FD File Offset: 0x000338FD
	protected override void OnUpdate(float factor, bool isFinished)
	{
		this.value = this.from * (1f - factor) + this.to * factor;
		this.mSource.enabled = (this.mSource.volume > 0.01f);
	}

	// Token: 0x060005D6 RID: 1494 RVA: 0x0003573C File Offset: 0x0003393C
	public static TweenVolume Begin(GameObject go, float duration, float targetVolume)
	{
		TweenVolume tweenVolume = UITweener.Begin<TweenVolume>(go, duration, 0f);
		tweenVolume.from = tweenVolume.value;
		tweenVolume.to = targetVolume;
		if (targetVolume > 0f)
		{
			AudioSource audioSource = tweenVolume.audioSource;
			audioSource.enabled = true;
			audioSource.Play();
		}
		return tweenVolume;
	}

	// Token: 0x060005D7 RID: 1495 RVA: 0x00035784 File Offset: 0x00033984
	public override void SetStartToCurrentValue()
	{
		this.from = this.value;
	}

	// Token: 0x060005D8 RID: 1496 RVA: 0x00035792 File Offset: 0x00033992
	public override void SetEndToCurrentValue()
	{
		this.to = this.value;
	}

	// Token: 0x040005E9 RID: 1513
	[Range(0f, 1f)]
	public float from = 1f;

	// Token: 0x040005EA RID: 1514
	[Range(0f, 1f)]
	public float to = 1f;

	// Token: 0x040005EB RID: 1515
	private AudioSource mSource;
}
