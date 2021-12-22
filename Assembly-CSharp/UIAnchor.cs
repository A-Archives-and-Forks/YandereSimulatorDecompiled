﻿using System;
using UnityEngine;

// Token: 0x0200009D RID: 157
[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Anchor")]
public class UIAnchor : MonoBehaviour
{
	// Token: 0x06000699 RID: 1689 RVA: 0x0003822B File Offset: 0x0003642B
	private void OnEnable()
	{
		this.mTrans = base.transform;
		this.mAnim = base.GetComponent<Animation>();
		UICamera.onScreenResize = (UICamera.OnScreenResize)Delegate.Combine(UICamera.onScreenResize, new UICamera.OnScreenResize(this.ScreenSizeChanged));
	}

	// Token: 0x0600069A RID: 1690 RVA: 0x00038265 File Offset: 0x00036465
	private void OnDisable()
	{
		UICamera.onScreenResize = (UICamera.OnScreenResize)Delegate.Remove(UICamera.onScreenResize, new UICamera.OnScreenResize(this.ScreenSizeChanged));
	}

	// Token: 0x0600069B RID: 1691 RVA: 0x00038287 File Offset: 0x00036487
	private void ScreenSizeChanged()
	{
		if (this.mStarted && this.runOnlyOnce)
		{
			this.Update();
		}
	}

	// Token: 0x0600069C RID: 1692 RVA: 0x000382A0 File Offset: 0x000364A0
	private void Start()
	{
		if (this.container == null && this.widgetContainer != null)
		{
			this.container = this.widgetContainer.gameObject;
			this.widgetContainer = null;
		}
		this.mRoot = NGUITools.FindInParents<UIRoot>(base.gameObject);
		if (this.uiCamera == null)
		{
			this.uiCamera = NGUITools.FindCameraForLayer(base.gameObject.layer);
		}
		this.Update();
		this.mStarted = true;
	}

	// Token: 0x0600069D RID: 1693 RVA: 0x00038324 File Offset: 0x00036524
	private void Update()
	{
		if (this.mAnim != null && this.mAnim.enabled && this.mAnim.isPlaying)
		{
			return;
		}
		if (this.mTrans == null)
		{
			return;
		}
		bool flag = false;
		UIWidget uiwidget = (this.container == null) ? null : this.container.GetComponent<UIWidget>();
		UIPanel uipanel = (this.container == null && uiwidget == null) ? null : this.container.GetComponent<UIPanel>();
		if (uiwidget != null)
		{
			Bounds bounds = uiwidget.CalculateBounds(this.container.transform.parent);
			this.mRect.x = bounds.min.x;
			this.mRect.y = bounds.min.y;
			this.mRect.width = bounds.size.x;
			this.mRect.height = bounds.size.y;
		}
		else if (uipanel != null)
		{
			if (uipanel.clipping == UIDrawCall.Clipping.None)
			{
				float num = (this.mRoot != null) ? ((float)this.mRoot.activeHeight / (float)Screen.height * 0.5f) : 0.5f;
				this.mRect.xMin = (float)(-(float)Screen.width) * num;
				this.mRect.yMin = (float)(-(float)Screen.height) * num;
				this.mRect.xMax = -this.mRect.xMin;
				this.mRect.yMax = -this.mRect.yMin;
			}
			else
			{
				Vector4 finalClipRegion = uipanel.finalClipRegion;
				this.mRect.x = finalClipRegion.x - finalClipRegion.z * 0.5f;
				this.mRect.y = finalClipRegion.y - finalClipRegion.w * 0.5f;
				this.mRect.width = finalClipRegion.z;
				this.mRect.height = finalClipRegion.w;
			}
		}
		else if (this.container != null)
		{
			Transform parent = this.container.transform.parent;
			Bounds bounds2 = (parent != null) ? NGUIMath.CalculateRelativeWidgetBounds(parent, this.container.transform) : NGUIMath.CalculateRelativeWidgetBounds(this.container.transform);
			this.mRect.x = bounds2.min.x;
			this.mRect.y = bounds2.min.y;
			this.mRect.width = bounds2.size.x;
			this.mRect.height = bounds2.size.y;
		}
		else
		{
			if (!(this.uiCamera != null))
			{
				return;
			}
			flag = true;
			this.mRect = this.uiCamera.pixelRect;
		}
		float x = (this.mRect.xMin + this.mRect.xMax) * 0.5f;
		float y = (this.mRect.yMin + this.mRect.yMax) * 0.5f;
		Vector3 vector = new Vector3(x, y, 0f);
		if (this.side != UIAnchor.Side.Center)
		{
			if (this.side == UIAnchor.Side.Right || this.side == UIAnchor.Side.TopRight || this.side == UIAnchor.Side.BottomRight)
			{
				vector.x = this.mRect.xMax;
			}
			else if (this.side == UIAnchor.Side.Top || this.side == UIAnchor.Side.Center || this.side == UIAnchor.Side.Bottom)
			{
				vector.x = x;
			}
			else
			{
				vector.x = this.mRect.xMin;
			}
			if (this.side == UIAnchor.Side.Top || this.side == UIAnchor.Side.TopRight || this.side == UIAnchor.Side.TopLeft)
			{
				vector.y = this.mRect.yMax;
			}
			else if (this.side == UIAnchor.Side.Left || this.side == UIAnchor.Side.Center || this.side == UIAnchor.Side.Right)
			{
				vector.y = y;
			}
			else
			{
				vector.y = this.mRect.yMin;
			}
		}
		float width = this.mRect.width;
		float height = this.mRect.height;
		vector.x += this.pixelOffset.x + this.relativeOffset.x * width;
		vector.y += this.pixelOffset.y + this.relativeOffset.y * height;
		if (flag)
		{
			if (this.uiCamera.orthographic)
			{
				vector.x = Mathf.Round(vector.x);
				vector.y = Mathf.Round(vector.y);
			}
			vector.z = this.uiCamera.WorldToScreenPoint(this.mTrans.position).z;
			vector = this.uiCamera.ScreenToWorldPoint(vector);
		}
		else
		{
			vector.x = Mathf.Round(vector.x);
			vector.y = Mathf.Round(vector.y);
			if (uipanel != null)
			{
				vector = uipanel.cachedTransform.TransformPoint(vector);
			}
			else if (this.container != null)
			{
				Transform parent2 = this.container.transform.parent;
				if (parent2 != null)
				{
					vector = parent2.TransformPoint(vector);
				}
			}
			vector.z = this.mTrans.position.z;
		}
		if (flag && this.uiCamera.orthographic && this.mTrans.parent != null)
		{
			vector = this.mTrans.parent.InverseTransformPoint(vector);
			vector.x = (float)Mathf.RoundToInt(vector.x);
			vector.y = (float)Mathf.RoundToInt(vector.y);
			if (this.mTrans.localPosition != vector)
			{
				this.mTrans.localPosition = vector;
			}
		}
		else if (this.mTrans.position != vector)
		{
			this.mTrans.position = vector;
		}
		if (this.runOnlyOnce && Application.isPlaying)
		{
			base.enabled = false;
		}
	}

	// Token: 0x0400061D RID: 1565
	public Camera uiCamera;

	// Token: 0x0400061E RID: 1566
	public GameObject container;

	// Token: 0x0400061F RID: 1567
	public UIAnchor.Side side = UIAnchor.Side.Center;

	// Token: 0x04000620 RID: 1568
	public bool runOnlyOnce = true;

	// Token: 0x04000621 RID: 1569
	public Vector2 relativeOffset = Vector2.zero;

	// Token: 0x04000622 RID: 1570
	public Vector2 pixelOffset = Vector2.zero;

	// Token: 0x04000623 RID: 1571
	[HideInInspector]
	[SerializeField]
	private UIWidget widgetContainer;

	// Token: 0x04000624 RID: 1572
	private Transform mTrans;

	// Token: 0x04000625 RID: 1573
	private Animation mAnim;

	// Token: 0x04000626 RID: 1574
	private Rect mRect;

	// Token: 0x04000627 RID: 1575
	private UIRoot mRoot;

	// Token: 0x04000628 RID: 1576
	private bool mStarted;

	// Token: 0x0200060F RID: 1551
	[DoNotObfuscateNGUI]
	public enum Side
	{
		// Token: 0x04004DE3 RID: 19939
		BottomLeft,
		// Token: 0x04004DE4 RID: 19940
		Left,
		// Token: 0x04004DE5 RID: 19941
		TopLeft,
		// Token: 0x04004DE6 RID: 19942
		Top,
		// Token: 0x04004DE7 RID: 19943
		TopRight,
		// Token: 0x04004DE8 RID: 19944
		Right,
		// Token: 0x04004DE9 RID: 19945
		BottomRight,
		// Token: 0x04004DEA RID: 19946
		Bottom,
		// Token: 0x04004DEB RID: 19947
		Center
	}
}
