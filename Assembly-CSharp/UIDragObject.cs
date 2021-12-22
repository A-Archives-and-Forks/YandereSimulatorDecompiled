﻿using System;
using UnityEngine;

// Token: 0x02000051 RID: 81
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Drag Object")]
public class UIDragObject : MonoBehaviour
{
	// Token: 0x17000014 RID: 20
	// (get) Token: 0x06000185 RID: 389 RVA: 0x00015F3F File Offset: 0x0001413F
	// (set) Token: 0x06000186 RID: 390 RVA: 0x00015F47 File Offset: 0x00014147
	public Vector3 dragMovement
	{
		get
		{
			return this.scale;
		}
		set
		{
			this.scale = value;
		}
	}

	// Token: 0x06000187 RID: 391 RVA: 0x00015F50 File Offset: 0x00014150
	private void OnEnable()
	{
		if (this.scrollWheelFactor != 0f)
		{
			this.scrollMomentum = this.scale * this.scrollWheelFactor;
			this.scrollWheelFactor = 0f;
		}
		if (this.contentRect == null && this.target != null && Application.isPlaying)
		{
			UIWidget component = this.target.GetComponent<UIWidget>();
			if (component != null)
			{
				this.contentRect = component;
			}
		}
		this.mTargetPos = ((this.target != null) ? this.target.position : Vector3.zero);
	}

	// Token: 0x06000188 RID: 392 RVA: 0x00015FF1 File Offset: 0x000141F1
	private void OnDisable()
	{
		this.mStarted = false;
	}

	// Token: 0x06000189 RID: 393 RVA: 0x00015FFC File Offset: 0x000141FC
	private void FindPanel()
	{
		this.panelRegion = ((this.target != null) ? UIPanel.Find(this.target.transform.parent) : null);
		if (this.panelRegion == null)
		{
			this.restrictWithinPanel = false;
		}
	}

	// Token: 0x0600018A RID: 394 RVA: 0x0001604C File Offset: 0x0001424C
	private void UpdateBounds()
	{
		if (this.contentRect)
		{
			Matrix4x4 worldToLocalMatrix = this.panelRegion.cachedTransform.worldToLocalMatrix;
			Vector3[] worldCorners = this.contentRect.worldCorners;
			for (int i = 0; i < 4; i++)
			{
				worldCorners[i] = worldToLocalMatrix.MultiplyPoint3x4(worldCorners[i]);
			}
			this.mBounds = new Bounds(worldCorners[0], Vector3.zero);
			for (int j = 1; j < 4; j++)
			{
				this.mBounds.Encapsulate(worldCorners[j]);
			}
			return;
		}
		this.mBounds = NGUIMath.CalculateRelativeWidgetBounds(this.panelRegion.cachedTransform, this.target);
	}

	// Token: 0x0600018B RID: 395 RVA: 0x000160F8 File Offset: 0x000142F8
	private void OnPress(bool pressed)
	{
		if (UICamera.currentTouchID == -2 || UICamera.currentTouchID == -3)
		{
			return;
		}
		float timeScale = Time.timeScale;
		if (timeScale < 0.01f && timeScale != 0f)
		{
			return;
		}
		if (base.enabled && NGUITools.GetActive(base.gameObject) && this.target != null)
		{
			if (pressed)
			{
				if (!this.mPressed)
				{
					this.mTouchID = UICamera.currentTouchID;
					this.mPressed = true;
					this.mStarted = false;
					this.CancelMovement();
					if (this.restrictWithinPanel && this.panelRegion == null)
					{
						this.FindPanel();
					}
					if (this.restrictWithinPanel)
					{
						this.UpdateBounds();
					}
					this.CancelSpring();
					Transform transform = UICamera.currentCamera.transform;
					this.mPlane = new Plane(((this.panelRegion != null) ? this.panelRegion.cachedTransform.rotation : transform.rotation) * Vector3.back, UICamera.lastWorldPosition);
					return;
				}
			}
			else if (this.mPressed && this.mTouchID == UICamera.currentTouchID)
			{
				this.mPressed = false;
				if (this.restrictWithinPanel && this.dragEffect == UIDragObject.DragEffect.MomentumAndSpring && this.panelRegion.ConstrainTargetToBounds(this.target, ref this.mBounds, false))
				{
					this.CancelMovement();
				}
			}
		}
	}

	// Token: 0x0600018C RID: 396 RVA: 0x00016254 File Offset: 0x00014454
	private void OnDrag(Vector2 delta)
	{
		if (this.mPressed && this.mTouchID == UICamera.currentTouchID && base.enabled && NGUITools.GetActive(base.gameObject) && this.target != null)
		{
			UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;
			Ray ray = UICamera.currentCamera.ScreenPointToRay(UICamera.currentTouch.pos);
			float distance = 0f;
			if (this.mPlane.Raycast(ray, out distance))
			{
				Vector3 point = ray.GetPoint(distance);
				Vector3 vector = point - this.mLastPos;
				this.mLastPos = point;
				if (!this.mStarted)
				{
					this.mStarted = true;
					vector = Vector3.zero;
				}
				if (vector.x != 0f || vector.y != 0f)
				{
					vector = this.target.InverseTransformDirection(vector);
					vector.Scale(this.scale);
					vector = this.target.TransformDirection(vector);
				}
				if (this.dragEffect != UIDragObject.DragEffect.None)
				{
					this.mMomentum = Vector3.Lerp(this.mMomentum, this.mMomentum + vector * (0.01f * this.momentumAmount), 0.67f);
				}
				Vector3 localPosition = this.target.localPosition;
				this.Move(vector);
				if (this.restrictWithinPanel)
				{
					this.mBounds.center = this.mBounds.center + (this.target.localPosition - localPosition);
					if (this.dragEffect != UIDragObject.DragEffect.MomentumAndSpring && this.panelRegion.ConstrainTargetToBounds(this.target, ref this.mBounds, true))
					{
						this.CancelMovement();
					}
				}
			}
		}
	}

	// Token: 0x0600018D RID: 397 RVA: 0x00016408 File Offset: 0x00014608
	private void Move(Vector3 worldDelta)
	{
		if (this.panelRegion != null)
		{
			this.mTargetPos += worldDelta;
			Transform parent = this.target.parent;
			Rigidbody component = this.target.GetComponent<Rigidbody>();
			if (parent != null)
			{
				Vector3 vector = parent.worldToLocalMatrix.MultiplyPoint3x4(this.mTargetPos);
				vector.x = Mathf.Round(vector.x);
				vector.y = Mathf.Round(vector.y);
				if (component != null)
				{
					vector = parent.localToWorldMatrix.MultiplyPoint3x4(vector);
					component.position = vector;
				}
				else
				{
					this.target.localPosition = vector;
				}
			}
			else if (component != null)
			{
				component.position = this.mTargetPos;
			}
			else
			{
				this.target.position = this.mTargetPos;
			}
			UIScrollView component2 = this.panelRegion.GetComponent<UIScrollView>();
			if (component2 != null)
			{
				component2.UpdateScrollbars(true);
				return;
			}
		}
		else
		{
			this.target.position += worldDelta;
		}
	}

	// Token: 0x0600018E RID: 398 RVA: 0x00016520 File Offset: 0x00014720
	private void LateUpdate()
	{
		if (this.target == null)
		{
			return;
		}
		float deltaTime = RealTime.deltaTime;
		this.mMomentum -= this.mScroll;
		this.mScroll = NGUIMath.SpringLerp(this.mScroll, Vector3.zero, 20f, deltaTime);
		if (this.mMomentum.magnitude < 0.0001f)
		{
			return;
		}
		if (!this.mPressed)
		{
			if (this.panelRegion == null)
			{
				this.FindPanel();
			}
			this.Move(NGUIMath.SpringDampen(ref this.mMomentum, 9f, deltaTime));
			if (this.restrictWithinPanel && this.panelRegion != null)
			{
				this.UpdateBounds();
				if (this.panelRegion.ConstrainTargetToBounds(this.target, ref this.mBounds, this.dragEffect == UIDragObject.DragEffect.None))
				{
					this.CancelMovement();
				}
				else
				{
					this.CancelSpring();
				}
			}
			NGUIMath.SpringDampen(ref this.mMomentum, 9f, deltaTime);
			if (this.mMomentum.magnitude < 0.0001f)
			{
				this.CancelMovement();
				return;
			}
		}
		else
		{
			NGUIMath.SpringDampen(ref this.mMomentum, 9f, deltaTime);
		}
	}

	// Token: 0x0600018F RID: 399 RVA: 0x00016648 File Offset: 0x00014848
	public void CancelMovement()
	{
		if (this.target != null)
		{
			Vector3 localPosition = this.target.localPosition;
			localPosition.x = (float)Mathf.RoundToInt(localPosition.x);
			localPosition.y = (float)Mathf.RoundToInt(localPosition.y);
			localPosition.z = (float)Mathf.RoundToInt(localPosition.z);
			this.target.localPosition = localPosition;
		}
		this.mTargetPos = ((this.target != null) ? this.target.position : Vector3.zero);
		this.mMomentum = Vector3.zero;
		this.mScroll = Vector3.zero;
	}

	// Token: 0x06000190 RID: 400 RVA: 0x000166F0 File Offset: 0x000148F0
	public void CancelSpring()
	{
		SpringPosition component = this.target.GetComponent<SpringPosition>();
		if (component != null)
		{
			component.enabled = false;
		}
	}

	// Token: 0x06000191 RID: 401 RVA: 0x00016719 File Offset: 0x00014919
	private void OnScroll(float delta)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject))
		{
			this.mScroll -= this.scrollMomentum * (delta * 0.05f);
		}
	}

	// Token: 0x04000330 RID: 816
	public Transform target;

	// Token: 0x04000331 RID: 817
	public UIPanel panelRegion;

	// Token: 0x04000332 RID: 818
	public Vector3 scrollMomentum = Vector3.zero;

	// Token: 0x04000333 RID: 819
	public bool restrictWithinPanel;

	// Token: 0x04000334 RID: 820
	public UIRect contentRect;

	// Token: 0x04000335 RID: 821
	public UIDragObject.DragEffect dragEffect = UIDragObject.DragEffect.MomentumAndSpring;

	// Token: 0x04000336 RID: 822
	public float momentumAmount = 35f;

	// Token: 0x04000337 RID: 823
	[SerializeField]
	protected Vector3 scale = new Vector3(1f, 1f, 0f);

	// Token: 0x04000338 RID: 824
	[SerializeField]
	[HideInInspector]
	private float scrollWheelFactor;

	// Token: 0x04000339 RID: 825
	private Plane mPlane;

	// Token: 0x0400033A RID: 826
	private Vector3 mTargetPos;

	// Token: 0x0400033B RID: 827
	private Vector3 mLastPos;

	// Token: 0x0400033C RID: 828
	private Vector3 mMomentum = Vector3.zero;

	// Token: 0x0400033D RID: 829
	private Vector3 mScroll = Vector3.zero;

	// Token: 0x0400033E RID: 830
	private Bounds mBounds;

	// Token: 0x0400033F RID: 831
	private int mTouchID;

	// Token: 0x04000340 RID: 832
	private bool mStarted;

	// Token: 0x04000341 RID: 833
	private bool mPressed;

	// Token: 0x020005C9 RID: 1481
	[DoNotObfuscateNGUI]
	public enum DragEffect
	{
		// Token: 0x04004D0B RID: 19723
		None,
		// Token: 0x04004D0C RID: 19724
		Momentum,
		// Token: 0x04004D0D RID: 19725
		MomentumAndSpring
	}
}
