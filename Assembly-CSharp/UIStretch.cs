﻿using System;
using UnityEngine;

// Token: 0x020000AD RID: 173
[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Stretch")]
public class UIStretch : MonoBehaviour
{
	// Token: 0x060008AC RID: 2220 RVA: 0x00046EDC File Offset: 0x000450DC
	private void Awake()
	{
		this.mAnim = base.GetComponent<Animation>();
		this.mRect = default(Rect);
		this.mTrans = base.transform;
		this.mWidget = base.GetComponent<UIWidget>();
		this.mSprite = base.GetComponent<UISprite>();
		this.mPanel = base.GetComponent<UIPanel>();
		UICamera.onScreenResize = (UICamera.OnScreenResize)Delegate.Combine(UICamera.onScreenResize, new UICamera.OnScreenResize(this.ScreenSizeChanged));
	}

	// Token: 0x060008AD RID: 2221 RVA: 0x00046F51 File Offset: 0x00045151
	private void OnDestroy()
	{
		UICamera.onScreenResize = (UICamera.OnScreenResize)Delegate.Remove(UICamera.onScreenResize, new UICamera.OnScreenResize(this.ScreenSizeChanged));
	}

	// Token: 0x060008AE RID: 2222 RVA: 0x00046F73 File Offset: 0x00045173
	private void ScreenSizeChanged()
	{
		if (this.mStarted && this.runOnlyOnce)
		{
			this.Update();
		}
	}

	// Token: 0x060008AF RID: 2223 RVA: 0x00046F8C File Offset: 0x0004518C
	private void Start()
	{
		if (this.container == null && this.widgetContainer != null)
		{
			this.container = this.widgetContainer.gameObject;
			this.widgetContainer = null;
		}
		if (this.uiCamera == null)
		{
			this.uiCamera = NGUITools.FindCameraForLayer(base.gameObject.layer);
		}
		this.mRoot = NGUITools.FindInParents<UIRoot>(base.gameObject);
		this.Update();
		this.mStarted = true;
	}

	// Token: 0x060008B0 RID: 2224 RVA: 0x00047010 File Offset: 0x00045210
	private void Update()
	{
		if (this.mAnim != null && this.mAnim.isPlaying)
		{
			return;
		}
		if (this.style != UIStretch.Style.None)
		{
			UIWidget uiwidget = (this.container == null) ? null : this.container.GetComponent<UIWidget>();
			UIPanel uipanel = (this.container == null && uiwidget == null) ? null : this.container.GetComponent<UIPanel>();
			float num = 1f;
			if (uiwidget != null)
			{
				Bounds bounds = uiwidget.CalculateBounds(base.transform.parent);
				this.mRect.x = bounds.min.x;
				this.mRect.y = bounds.min.y;
				this.mRect.width = bounds.size.x;
				this.mRect.height = bounds.size.y;
			}
			else if (uipanel != null)
			{
				if (uipanel.clipping == UIDrawCall.Clipping.None)
				{
					float num2 = (this.mRoot != null) ? ((float)this.mRoot.activeHeight / (float)Screen.height * 0.5f) : 0.5f;
					this.mRect.xMin = (float)(-(float)Screen.width) * num2;
					this.mRect.yMin = (float)(-(float)Screen.height) * num2;
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
				Transform parent = base.transform.parent;
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
				this.mRect = this.uiCamera.pixelRect;
				if (this.mRoot != null)
				{
					num = this.mRoot.pixelSizeAdjustment;
				}
			}
			float num3 = this.mRect.width;
			float num4 = this.mRect.height;
			if (num != 1f && num4 > 1f)
			{
				float num5 = (float)this.mRoot.activeHeight / num4;
				num3 *= num5;
				num4 *= num5;
			}
			Vector3 vector = (this.mWidget != null) ? new Vector3((float)this.mWidget.width, (float)this.mWidget.height) : this.mTrans.localScale;
			if (this.style == UIStretch.Style.BasedOnHeight)
			{
				vector.x = this.relativeSize.x * num4;
				vector.y = this.relativeSize.y * num4;
			}
			else if (this.style == UIStretch.Style.FillKeepingRatio)
			{
				float num6 = num3 / num4;
				if (this.initialSize.x / this.initialSize.y < num6)
				{
					float num7 = num3 / this.initialSize.x;
					vector.x = num3;
					vector.y = this.initialSize.y * num7;
				}
				else
				{
					float num8 = num4 / this.initialSize.y;
					vector.x = this.initialSize.x * num8;
					vector.y = num4;
				}
			}
			else if (this.style == UIStretch.Style.FitInternalKeepingRatio)
			{
				float num9 = num3 / num4;
				if (this.initialSize.x / this.initialSize.y > num9)
				{
					float num10 = num3 / this.initialSize.x;
					vector.x = num3;
					vector.y = this.initialSize.y * num10;
				}
				else
				{
					float num11 = num4 / this.initialSize.y;
					vector.x = this.initialSize.x * num11;
					vector.y = num4;
				}
			}
			else
			{
				if (this.style != UIStretch.Style.Vertical)
				{
					vector.x = this.relativeSize.x * num3;
				}
				if (this.style != UIStretch.Style.Horizontal)
				{
					vector.y = this.relativeSize.y * num4;
				}
			}
			if (this.mSprite != null)
			{
				float num12 = (this.mSprite.atlas != null) ? this.mSprite.pixelSize : 1f;
				vector.x -= this.borderPadding.x * num12;
				vector.y -= this.borderPadding.y * num12;
				if (this.style != UIStretch.Style.Vertical)
				{
					this.mSprite.width = Mathf.RoundToInt(vector.x);
				}
				if (this.style != UIStretch.Style.Horizontal)
				{
					this.mSprite.height = Mathf.RoundToInt(vector.y);
				}
				vector = Vector3.one;
			}
			else if (this.mWidget != null)
			{
				if (this.style != UIStretch.Style.Vertical)
				{
					this.mWidget.width = Mathf.RoundToInt(vector.x - this.borderPadding.x);
				}
				if (this.style != UIStretch.Style.Horizontal)
				{
					this.mWidget.height = Mathf.RoundToInt(vector.y - this.borderPadding.y);
				}
				vector = Vector3.one;
			}
			else if (this.mPanel != null)
			{
				Vector4 baseClipRegion = this.mPanel.baseClipRegion;
				if (this.style != UIStretch.Style.Vertical)
				{
					baseClipRegion.z = vector.x - this.borderPadding.x;
				}
				if (this.style != UIStretch.Style.Horizontal)
				{
					baseClipRegion.w = vector.y - this.borderPadding.y;
				}
				this.mPanel.baseClipRegion = baseClipRegion;
				vector = Vector3.one;
			}
			else
			{
				if (this.style != UIStretch.Style.Vertical)
				{
					vector.x -= this.borderPadding.x;
				}
				if (this.style != UIStretch.Style.Horizontal)
				{
					vector.y -= this.borderPadding.y;
				}
			}
			if (this.mTrans.localScale != vector)
			{
				this.mTrans.localScale = vector;
			}
			if (this.runOnlyOnce && Application.isPlaying)
			{
				base.enabled = false;
			}
		}
	}

	// Token: 0x04000779 RID: 1913
	public Camera uiCamera;

	// Token: 0x0400077A RID: 1914
	public GameObject container;

	// Token: 0x0400077B RID: 1915
	public UIStretch.Style style;

	// Token: 0x0400077C RID: 1916
	public bool runOnlyOnce = true;

	// Token: 0x0400077D RID: 1917
	public Vector2 relativeSize = Vector2.one;

	// Token: 0x0400077E RID: 1918
	public Vector2 initialSize = Vector2.one;

	// Token: 0x0400077F RID: 1919
	public Vector2 borderPadding = Vector2.zero;

	// Token: 0x04000780 RID: 1920
	[HideInInspector]
	[SerializeField]
	private UIWidget widgetContainer;

	// Token: 0x04000781 RID: 1921
	private Transform mTrans;

	// Token: 0x04000782 RID: 1922
	private UIWidget mWidget;

	// Token: 0x04000783 RID: 1923
	private UISprite mSprite;

	// Token: 0x04000784 RID: 1924
	private UIPanel mPanel;

	// Token: 0x04000785 RID: 1925
	private UIRoot mRoot;

	// Token: 0x04000786 RID: 1926
	private Animation mAnim;

	// Token: 0x04000787 RID: 1927
	private Rect mRect;

	// Token: 0x04000788 RID: 1928
	private bool mStarted;

	// Token: 0x02000642 RID: 1602
	[DoNotObfuscateNGUI]
	public enum Style
	{
		// Token: 0x04004E8D RID: 20109
		None,
		// Token: 0x04004E8E RID: 20110
		Horizontal,
		// Token: 0x04004E8F RID: 20111
		Vertical,
		// Token: 0x04004E90 RID: 20112
		Both,
		// Token: 0x04004E91 RID: 20113
		BasedOnHeight,
		// Token: 0x04004E92 RID: 20114
		FillKeepingRatio,
		// Token: 0x04004E93 RID: 20115
		FitInternalKeepingRatio
	}
}
