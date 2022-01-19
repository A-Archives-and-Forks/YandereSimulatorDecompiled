﻿using System;
using UnityEngine;

// Token: 0x02000089 RID: 137
[AddComponentMenu("NGUI/Tween/Tween Alpha")]
public class TweenAlpha : UITweener
{
	// Token: 0x170000B6 RID: 182
	// (get) Token: 0x0600055A RID: 1370 RVA: 0x00033DBF File Offset: 0x00031FBF
	// (set) Token: 0x0600055B RID: 1371 RVA: 0x00033DC7 File Offset: 0x00031FC7
	[Obsolete("Use 'value' instead")]
	public float alpha
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

	// Token: 0x0600055C RID: 1372 RVA: 0x00033DD0 File Offset: 0x00031FD0
	private void OnDestroy()
	{
		if (this.autoCleanup && this.mMat != null && this.mShared != this.mMat)
		{
			UnityEngine.Object.Destroy(this.mMat);
			this.mMat = null;
		}
	}

	// Token: 0x0600055D RID: 1373 RVA: 0x00033E10 File Offset: 0x00032010
	private void Cache()
	{
		this.mCached = true;
		this.mRect = base.GetComponent<UIRect>();
		this.mSr = base.GetComponent<SpriteRenderer>();
		if (this.mRect == null && this.mSr == null)
		{
			this.mLight = base.GetComponent<Light>();
			if (this.mLight == null)
			{
				Renderer component = base.GetComponent<Renderer>();
				if (component != null)
				{
					this.mShared = component.sharedMaterial;
					this.mMat = component.material;
				}
				if (this.mMat == null)
				{
					this.mRect = base.GetComponentInChildren<UIRect>();
					return;
				}
			}
			else
			{
				this.mBaseIntensity = this.mLight.intensity;
			}
		}
	}

	// Token: 0x170000B7 RID: 183
	// (get) Token: 0x0600055E RID: 1374 RVA: 0x00033EC8 File Offset: 0x000320C8
	// (set) Token: 0x0600055F RID: 1375 RVA: 0x00033F64 File Offset: 0x00032164
	public float value
	{
		get
		{
			if (!this.mCached)
			{
				this.Cache();
			}
			if (this.mRect != null)
			{
				return this.mRect.alpha;
			}
			if (this.mSr != null)
			{
				return this.mSr.color.a;
			}
			if (this.mMat == null)
			{
				return 1f;
			}
			if (string.IsNullOrEmpty(this.colorProperty))
			{
				return this.mMat.color.a;
			}
			return this.mMat.GetColor(this.colorProperty).a;
		}
		set
		{
			if (!this.mCached)
			{
				this.Cache();
			}
			if (this.mRect != null)
			{
				this.mRect.alpha = value;
				return;
			}
			if (this.mSr != null)
			{
				Color color = this.mSr.color;
				color.a = value;
				this.mSr.color = color;
				return;
			}
			if (!(this.mMat != null))
			{
				if (this.mLight != null)
				{
					this.mLight.intensity = this.mBaseIntensity * value;
				}
				return;
			}
			if (string.IsNullOrEmpty(this.colorProperty))
			{
				Color color2 = this.mMat.color;
				color2.a = value;
				this.mMat.color = color2;
				return;
			}
			Color color3 = this.mMat.GetColor(this.colorProperty);
			color3.a = value;
			this.mMat.SetColor(this.colorProperty, color3);
		}
	}

	// Token: 0x06000560 RID: 1376 RVA: 0x00034053 File Offset: 0x00032253
	protected override void OnUpdate(float factor, bool isFinished)
	{
		this.value = Mathf.Lerp(this.from, this.to, factor);
	}

	// Token: 0x06000561 RID: 1377 RVA: 0x00034070 File Offset: 0x00032270
	public static TweenAlpha Begin(GameObject go, float duration, float alpha, float delay = 0f)
	{
		TweenAlpha tweenAlpha = UITweener.Begin<TweenAlpha>(go, duration, delay);
		tweenAlpha.from = tweenAlpha.value;
		tweenAlpha.to = alpha;
		if (duration <= 0f)
		{
			tweenAlpha.Sample(1f, true);
			tweenAlpha.enabled = false;
		}
		return tweenAlpha;
	}

	// Token: 0x06000562 RID: 1378 RVA: 0x000340B5 File Offset: 0x000322B5
	public override void SetStartToCurrentValue()
	{
		this.from = this.value;
	}

	// Token: 0x06000563 RID: 1379 RVA: 0x000340C3 File Offset: 0x000322C3
	public override void SetEndToCurrentValue()
	{
		this.to = this.value;
	}

	// Token: 0x040005A0 RID: 1440
	[Range(0f, 1f)]
	public float from = 1f;

	// Token: 0x040005A1 RID: 1441
	[Range(0f, 1f)]
	public float to = 1f;

	// Token: 0x040005A2 RID: 1442
	[Tooltip("If used on a renderer, the material should probably be cleaned up after this script gets destroyed...")]
	public bool autoCleanup;

	// Token: 0x040005A3 RID: 1443
	[Tooltip("Color to adjust")]
	public string colorProperty;

	// Token: 0x040005A4 RID: 1444
	[NonSerialized]
	private bool mCached;

	// Token: 0x040005A5 RID: 1445
	[NonSerialized]
	private UIRect mRect;

	// Token: 0x040005A6 RID: 1446
	[NonSerialized]
	private Material mShared;

	// Token: 0x040005A7 RID: 1447
	[NonSerialized]
	private Material mMat;

	// Token: 0x040005A8 RID: 1448
	[NonSerialized]
	private Light mLight;

	// Token: 0x040005A9 RID: 1449
	[NonSerialized]
	private SpriteRenderer mSr;

	// Token: 0x040005AA RID: 1450
	[NonSerialized]
	private float mBaseIntensity = 1f;
}
