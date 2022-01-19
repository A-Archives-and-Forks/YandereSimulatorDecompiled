﻿using System;
using UnityEngine;

// Token: 0x0200004D RID: 77
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Drag Camera")]
public class UIDragCamera : MonoBehaviour
{
	// Token: 0x06000162 RID: 354 RVA: 0x00015328 File Offset: 0x00013528
	private void Awake()
	{
		if (this.draggableCamera == null)
		{
			this.draggableCamera = NGUITools.FindInParents<UIDraggableCamera>(base.gameObject);
		}
	}

	// Token: 0x06000163 RID: 355 RVA: 0x00015349 File Offset: 0x00013549
	private void OnPress(bool isPressed)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject) && this.draggableCamera != null && this.draggableCamera.enabled)
		{
			this.draggableCamera.Press(isPressed);
		}
	}

	// Token: 0x06000164 RID: 356 RVA: 0x00015387 File Offset: 0x00013587
	private void OnDrag(Vector2 delta)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject) && this.draggableCamera != null && this.draggableCamera.enabled)
		{
			this.draggableCamera.Drag(delta);
		}
	}

	// Token: 0x06000165 RID: 357 RVA: 0x000153C5 File Offset: 0x000135C5
	private void OnScroll(float delta)
	{
		if (base.enabled && NGUITools.GetActive(base.gameObject) && this.draggableCamera != null && this.draggableCamera.enabled)
		{
			this.draggableCamera.Scroll(delta);
		}
	}

	// Token: 0x0400031A RID: 794
	public UIDraggableCamera draggableCamera;
}
