﻿using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200005F RID: 95
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/NGUI Progress Bar")]
public class UIProgressBar : UIWidgetContainer
{
	// Token: 0x1700002A RID: 42
	// (get) Token: 0x06000262 RID: 610 RVA: 0x0001B077 File Offset: 0x00019277
	public Transform cachedTransform
	{
		get
		{
			if (this.mTrans == null)
			{
				this.mTrans = base.transform;
			}
			return this.mTrans;
		}
	}

	// Token: 0x1700002B RID: 43
	// (get) Token: 0x06000263 RID: 611 RVA: 0x0001B099 File Offset: 0x00019299
	public Camera cachedCamera
	{
		get
		{
			if (this.mCam == null)
			{
				this.mCam = NGUITools.FindCameraForLayer(base.gameObject.layer);
			}
			return this.mCam;
		}
	}

	// Token: 0x1700002C RID: 44
	// (get) Token: 0x06000264 RID: 612 RVA: 0x0001B0C5 File Offset: 0x000192C5
	// (set) Token: 0x06000265 RID: 613 RVA: 0x0001B0CD File Offset: 0x000192CD
	public UIWidget foregroundWidget
	{
		get
		{
			return this.mFG;
		}
		set
		{
			if (this.mFG != value)
			{
				this.mFG = value;
				this.mIsDirty = true;
			}
		}
	}

	// Token: 0x1700002D RID: 45
	// (get) Token: 0x06000266 RID: 614 RVA: 0x0001B0EB File Offset: 0x000192EB
	// (set) Token: 0x06000267 RID: 615 RVA: 0x0001B0F3 File Offset: 0x000192F3
	public UIWidget backgroundWidget
	{
		get
		{
			return this.mBG;
		}
		set
		{
			if (this.mBG != value)
			{
				this.mBG = value;
				this.mIsDirty = true;
			}
		}
	}

	// Token: 0x1700002E RID: 46
	// (get) Token: 0x06000268 RID: 616 RVA: 0x0001B111 File Offset: 0x00019311
	// (set) Token: 0x06000269 RID: 617 RVA: 0x0001B119 File Offset: 0x00019319
	public UIProgressBar.FillDirection fillDirection
	{
		get
		{
			return this.mFill;
		}
		set
		{
			if (this.mFill != value)
			{
				this.mFill = value;
				if (this.mStarted)
				{
					this.ForceUpdate();
				}
			}
		}
	}

	// Token: 0x1700002F RID: 47
	// (get) Token: 0x0600026A RID: 618 RVA: 0x0001B139 File Offset: 0x00019339
	// (set) Token: 0x0600026B RID: 619 RVA: 0x0001B16A File Offset: 0x0001936A
	public float value
	{
		get
		{
			if (this.numberOfSteps > 1)
			{
				return Mathf.Round(this.mValue * (float)(this.numberOfSteps - 1)) / (float)(this.numberOfSteps - 1);
			}
			return this.mValue;
		}
		set
		{
			this.Set(value, true);
		}
	}

	// Token: 0x17000030 RID: 48
	// (get) Token: 0x0600026C RID: 620 RVA: 0x0001B174 File Offset: 0x00019374
	// (set) Token: 0x0600026D RID: 621 RVA: 0x0001B1B0 File Offset: 0x000193B0
	public float alpha
	{
		get
		{
			if (this.mFG != null)
			{
				return this.mFG.alpha;
			}
			if (this.mBG != null)
			{
				return this.mBG.alpha;
			}
			return 1f;
		}
		set
		{
			if (this.mFG != null)
			{
				this.mFG.alpha = value;
				if (this.mFG.GetComponent<Collider>() != null)
				{
					this.mFG.GetComponent<Collider>().enabled = (this.mFG.alpha > 0.001f);
				}
				else if (this.mFG.GetComponent<Collider2D>() != null)
				{
					this.mFG.GetComponent<Collider2D>().enabled = (this.mFG.alpha > 0.001f);
				}
			}
			if (this.mBG != null)
			{
				this.mBG.alpha = value;
				if (this.mBG.GetComponent<Collider>() != null)
				{
					this.mBG.GetComponent<Collider>().enabled = (this.mBG.alpha > 0.001f);
				}
				else if (this.mBG.GetComponent<Collider2D>() != null)
				{
					this.mBG.GetComponent<Collider2D>().enabled = (this.mBG.alpha > 0.001f);
				}
			}
			if (this.thumb != null)
			{
				UIWidget component = this.thumb.GetComponent<UIWidget>();
				if (component != null)
				{
					component.alpha = value;
					if (component.GetComponent<Collider>() != null)
					{
						component.GetComponent<Collider>().enabled = (component.alpha > 0.001f);
						return;
					}
					if (component.GetComponent<Collider2D>() != null)
					{
						component.GetComponent<Collider2D>().enabled = (component.alpha > 0.001f);
					}
				}
			}
		}
	}

	// Token: 0x17000031 RID: 49
	// (get) Token: 0x0600026E RID: 622 RVA: 0x0001B340 File Offset: 0x00019540
	protected bool isHorizontal
	{
		get
		{
			return this.mFill == UIProgressBar.FillDirection.LeftToRight || this.mFill == UIProgressBar.FillDirection.RightToLeft;
		}
	}

	// Token: 0x17000032 RID: 50
	// (get) Token: 0x0600026F RID: 623 RVA: 0x0001B355 File Offset: 0x00019555
	protected bool isInverted
	{
		get
		{
			return this.mFill == UIProgressBar.FillDirection.RightToLeft || this.mFill == UIProgressBar.FillDirection.TopToBottom;
		}
	}

	// Token: 0x06000270 RID: 624 RVA: 0x0001B36C File Offset: 0x0001956C
	public void Set(float val, bool notify = true)
	{
		val = Mathf.Clamp01(val);
		if (this.mValue != val)
		{
			float value = this.value;
			this.mValue = val;
			if (this.mStarted && value != this.value)
			{
				if (notify && NGUITools.GetActive(this) && EventDelegate.IsValid(this.onChange))
				{
					UIProgressBar.current = this;
					EventDelegate.Execute(this.onChange);
					UIProgressBar.current = null;
				}
				this.ForceUpdate();
			}
		}
	}

	// Token: 0x06000271 RID: 625 RVA: 0x0001B3E0 File Offset: 0x000195E0
	public void Start()
	{
		if (this.mStarted)
		{
			return;
		}
		this.mStarted = true;
		this.Upgrade();
		if (Application.isPlaying)
		{
			if (this.mBG != null)
			{
				this.mBG.autoResizeBoxCollider = true;
			}
			this.OnStart();
			if (UIProgressBar.current == null && this.onChange != null)
			{
				UIProgressBar.current = this;
				EventDelegate.Execute(this.onChange);
				UIProgressBar.current = null;
			}
		}
		this.ForceUpdate();
	}

	// Token: 0x06000272 RID: 626 RVA: 0x0001B45C File Offset: 0x0001965C
	protected virtual void Upgrade()
	{
	}

	// Token: 0x06000273 RID: 627 RVA: 0x0001B45E File Offset: 0x0001965E
	protected virtual void OnStart()
	{
	}

	// Token: 0x06000274 RID: 628 RVA: 0x0001B460 File Offset: 0x00019660
	protected void Update()
	{
		if (this.mIsDirty)
		{
			this.ForceUpdate();
		}
	}

	// Token: 0x06000275 RID: 629 RVA: 0x0001B470 File Offset: 0x00019670
	protected void OnValidate()
	{
		if (NGUITools.GetActive(this))
		{
			this.Upgrade();
			this.mIsDirty = true;
			float num = Mathf.Clamp01(this.mValue);
			if (this.mValue != num)
			{
				this.mValue = num;
			}
			if (this.numberOfSteps < 0)
			{
				this.numberOfSteps = 0;
			}
			else if (this.numberOfSteps > 21)
			{
				this.numberOfSteps = 21;
			}
			this.ForceUpdate();
			return;
		}
		float num2 = Mathf.Clamp01(this.mValue);
		if (this.mValue != num2)
		{
			this.mValue = num2;
		}
		if (this.numberOfSteps < 0)
		{
			this.numberOfSteps = 0;
			return;
		}
		if (this.numberOfSteps > 21)
		{
			this.numberOfSteps = 21;
		}
	}

	// Token: 0x06000276 RID: 630 RVA: 0x0001B518 File Offset: 0x00019718
	protected float ScreenToValue(Vector2 screenPos)
	{
		Transform cachedTransform = this.cachedTransform;
		Plane plane = new Plane(cachedTransform.rotation * Vector3.back, cachedTransform.position);
		Ray ray = this.cachedCamera.ScreenPointToRay(screenPos);
		float distance;
		if (!plane.Raycast(ray, out distance))
		{
			return this.value;
		}
		return this.LocalToValue(cachedTransform.InverseTransformPoint(ray.GetPoint(distance)));
	}

	// Token: 0x06000277 RID: 631 RVA: 0x0001B588 File Offset: 0x00019788
	protected virtual float LocalToValue(Vector2 localPos)
	{
		if (!(this.mFG != null))
		{
			return this.value;
		}
		Vector3[] localCorners = this.mFG.localCorners;
		Vector3 vector = localCorners[2] - localCorners[0];
		if (this.isHorizontal)
		{
			float num = (localPos.x - localCorners[0].x) / vector.x;
			if (!this.isInverted)
			{
				return num;
			}
			return 1f - num;
		}
		else
		{
			float num2 = (localPos.y - localCorners[0].y) / vector.y;
			if (!this.isInverted)
			{
				return num2;
			}
			return 1f - num2;
		}
	}

	// Token: 0x06000278 RID: 632 RVA: 0x0001B630 File Offset: 0x00019830
	public virtual void ForceUpdate()
	{
		this.mIsDirty = false;
		bool flag = false;
		if (this.mFG != null)
		{
			UIBasicSprite uibasicSprite = this.mFG as UIBasicSprite;
			if (this.isHorizontal)
			{
				if (uibasicSprite != null && uibasicSprite.type == UIBasicSprite.Type.Filled)
				{
					if (uibasicSprite.fillDirection == UIBasicSprite.FillDirection.Horizontal || uibasicSprite.fillDirection == UIBasicSprite.FillDirection.Vertical)
					{
						uibasicSprite.fillDirection = UIBasicSprite.FillDirection.Horizontal;
						uibasicSprite.invert = this.isInverted;
					}
					uibasicSprite.fillAmount = this.value;
				}
				else
				{
					this.mFG.drawRegion = (this.isInverted ? new Vector4(1f - this.value, 0f, 1f, 1f) : new Vector4(0f, 0f, this.value, 1f));
					this.mFG.enabled = true;
					flag = (this.value < 0.001f);
				}
			}
			else if (uibasicSprite != null && uibasicSprite.type == UIBasicSprite.Type.Filled)
			{
				if (uibasicSprite.fillDirection == UIBasicSprite.FillDirection.Horizontal || uibasicSprite.fillDirection == UIBasicSprite.FillDirection.Vertical)
				{
					uibasicSprite.fillDirection = UIBasicSprite.FillDirection.Vertical;
					uibasicSprite.invert = this.isInverted;
				}
				uibasicSprite.fillAmount = this.value;
			}
			else
			{
				this.mFG.drawRegion = (this.isInverted ? new Vector4(0f, 1f - this.value, 1f, 1f) : new Vector4(0f, 0f, 1f, this.value));
				this.mFG.enabled = true;
				flag = (this.value < 0.001f);
			}
		}
		if (this.thumb != null && (this.mFG != null || this.mBG != null))
		{
			Vector3[] array = (this.mFG != null) ? this.mFG.localCorners : this.mBG.localCorners;
			Vector4 vector = (this.mFG != null) ? this.mFG.border : this.mBG.border;
			Vector3[] array2 = array;
			int num = 0;
			array2[num].x = array2[num].x + vector.x;
			Vector3[] array3 = array;
			int num2 = 1;
			array3[num2].x = array3[num2].x + vector.x;
			Vector3[] array4 = array;
			int num3 = 2;
			array4[num3].x = array4[num3].x - vector.z;
			Vector3[] array5 = array;
			int num4 = 3;
			array5[num4].x = array5[num4].x - vector.z;
			Vector3[] array6 = array;
			int num5 = 0;
			array6[num5].y = array6[num5].y + vector.y;
			Vector3[] array7 = array;
			int num6 = 1;
			array7[num6].y = array7[num6].y - vector.w;
			Vector3[] array8 = array;
			int num7 = 2;
			array8[num7].y = array8[num7].y - vector.w;
			Vector3[] array9 = array;
			int num8 = 3;
			array9[num8].y = array9[num8].y + vector.y;
			Transform transform = (this.mFG != null) ? this.mFG.cachedTransform : this.mBG.cachedTransform;
			for (int i = 0; i < 4; i++)
			{
				array[i] = transform.TransformPoint(array[i]);
			}
			if (this.isHorizontal)
			{
				Vector3 a = Vector3.Lerp(array[0], array[1], 0.5f);
				Vector3 b = Vector3.Lerp(array[2], array[3], 0.5f);
				this.SetThumbPosition(Vector3.Lerp(a, b, this.isInverted ? (1f - this.value) : this.value));
			}
			else
			{
				Vector3 a2 = Vector3.Lerp(array[0], array[3], 0.5f);
				Vector3 b2 = Vector3.Lerp(array[1], array[2], 0.5f);
				this.SetThumbPosition(Vector3.Lerp(a2, b2, this.isInverted ? (1f - this.value) : this.value));
			}
		}
		if (flag)
		{
			this.mFG.enabled = false;
		}
	}

	// Token: 0x06000279 RID: 633 RVA: 0x0001BA24 File Offset: 0x00019C24
	protected void SetThumbPosition(Vector3 worldPos)
	{
		Transform parent = this.thumb.parent;
		if (parent != null)
		{
			worldPos = parent.InverseTransformPoint(worldPos);
			worldPos.x = Mathf.Round(worldPos.x);
			worldPos.y = Mathf.Round(worldPos.y);
			worldPos.z = 0f;
			if (Vector3.Distance(this.thumb.localPosition, worldPos) > 0.001f)
			{
				this.thumb.localPosition = worldPos;
				return;
			}
		}
		else if (Vector3.Distance(this.thumb.position, worldPos) > 1E-05f)
		{
			this.thumb.position = worldPos;
		}
	}

	// Token: 0x0600027A RID: 634 RVA: 0x0001BAC8 File Offset: 0x00019CC8
	public virtual void OnPan(Vector2 delta)
	{
		if (base.enabled)
		{
			switch (this.mFill)
			{
			case UIProgressBar.FillDirection.LeftToRight:
			{
				float value = Mathf.Clamp01(this.mValue + delta.x);
				this.value = value;
				this.mValue = value;
				return;
			}
			case UIProgressBar.FillDirection.RightToLeft:
			{
				float value2 = Mathf.Clamp01(this.mValue - delta.x);
				this.value = value2;
				this.mValue = value2;
				return;
			}
			case UIProgressBar.FillDirection.BottomToTop:
			{
				float value3 = Mathf.Clamp01(this.mValue + delta.y);
				this.value = value3;
				this.mValue = value3;
				return;
			}
			case UIProgressBar.FillDirection.TopToBottom:
			{
				float value4 = Mathf.Clamp01(this.mValue - delta.y);
				this.value = value4;
				this.mValue = value4;
				break;
			}
			default:
				return;
			}
		}
	}

	// Token: 0x040003FB RID: 1019
	public static UIProgressBar current;

	// Token: 0x040003FC RID: 1020
	public UIProgressBar.OnDragFinished onDragFinished;

	// Token: 0x040003FD RID: 1021
	public Transform thumb;

	// Token: 0x040003FE RID: 1022
	[HideInInspector]
	[SerializeField]
	protected UIWidget mBG;

	// Token: 0x040003FF RID: 1023
	[HideInInspector]
	[SerializeField]
	protected UIWidget mFG;

	// Token: 0x04000400 RID: 1024
	[HideInInspector]
	[SerializeField]
	protected float mValue = 1f;

	// Token: 0x04000401 RID: 1025
	[HideInInspector]
	[SerializeField]
	protected UIProgressBar.FillDirection mFill;

	// Token: 0x04000402 RID: 1026
	[NonSerialized]
	protected bool mStarted;

	// Token: 0x04000403 RID: 1027
	[NonSerialized]
	protected Transform mTrans;

	// Token: 0x04000404 RID: 1028
	[NonSerialized]
	protected bool mIsDirty;

	// Token: 0x04000405 RID: 1029
	[NonSerialized]
	protected Camera mCam;

	// Token: 0x04000406 RID: 1030
	[NonSerialized]
	protected float mOffset;

	// Token: 0x04000407 RID: 1031
	public int numberOfSteps;

	// Token: 0x04000408 RID: 1032
	public List<EventDelegate> onChange = new List<EventDelegate>();

	// Token: 0x020005D5 RID: 1493
	[DoNotObfuscateNGUI]
	public enum FillDirection
	{
		// Token: 0x04004D05 RID: 19717
		LeftToRight,
		// Token: 0x04004D06 RID: 19718
		RightToLeft,
		// Token: 0x04004D07 RID: 19719
		BottomToTop,
		// Token: 0x04004D08 RID: 19720
		TopToBottom
	}

	// Token: 0x020005D6 RID: 1494
	// (Invoke) Token: 0x060024FA RID: 9466
	public delegate void OnDragFinished();
}
