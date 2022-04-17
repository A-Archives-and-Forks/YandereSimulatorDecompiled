﻿using System;
using UnityEngine;

// Token: 0x02000047 RID: 71
[AddComponentMenu("NGUI/Interaction/Button Message (Legacy)")]
public class UIButtonMessage : MonoBehaviour
{
	// Token: 0x06000136 RID: 310 RVA: 0x000145DC File Offset: 0x000127DC
	private void Start()
	{
		this.mStarted = true;
	}

	// Token: 0x06000137 RID: 311 RVA: 0x000145E5 File Offset: 0x000127E5
	private void OnEnable()
	{
		if (this.mStarted)
		{
			this.OnHover(UICamera.IsHighlighted(base.gameObject));
		}
	}

	// Token: 0x06000138 RID: 312 RVA: 0x00014600 File Offset: 0x00012800
	private void OnHover(bool isOver)
	{
		if (base.enabled && ((isOver && this.trigger == UIButtonMessage.Trigger.OnMouseOver) || (!isOver && this.trigger == UIButtonMessage.Trigger.OnMouseOut)))
		{
			this.Send();
		}
	}

	// Token: 0x06000139 RID: 313 RVA: 0x00014628 File Offset: 0x00012828
	private void OnPress(bool isPressed)
	{
		if (base.enabled && ((isPressed && this.trigger == UIButtonMessage.Trigger.OnPress) || (!isPressed && this.trigger == UIButtonMessage.Trigger.OnRelease)))
		{
			this.Send();
		}
	}

	// Token: 0x0600013A RID: 314 RVA: 0x00014650 File Offset: 0x00012850
	private void OnSelect(bool isSelected)
	{
		if (base.enabled && (!isSelected || UICamera.currentScheme == UICamera.ControlScheme.Controller))
		{
			this.OnHover(isSelected);
		}
	}

	// Token: 0x0600013B RID: 315 RVA: 0x0001466C File Offset: 0x0001286C
	private void OnClick()
	{
		if (base.enabled && this.trigger == UIButtonMessage.Trigger.OnClick)
		{
			this.Send();
		}
	}

	// Token: 0x0600013C RID: 316 RVA: 0x00014684 File Offset: 0x00012884
	private void OnDoubleClick()
	{
		if (base.enabled && this.trigger == UIButtonMessage.Trigger.OnDoubleClick)
		{
			this.Send();
		}
	}

	// Token: 0x0600013D RID: 317 RVA: 0x000146A0 File Offset: 0x000128A0
	private void Send()
	{
		if (string.IsNullOrEmpty(this.functionName))
		{
			return;
		}
		if (this.target == null)
		{
			this.target = base.gameObject;
		}
		if (this.includeChildren)
		{
			Transform[] componentsInChildren = this.target.GetComponentsInChildren<Transform>();
			int i = 0;
			int num = componentsInChildren.Length;
			while (i < num)
			{
				componentsInChildren[i].gameObject.SendMessage(this.functionName, base.gameObject, SendMessageOptions.DontRequireReceiver);
				i++;
			}
			return;
		}
		this.target.SendMessage(this.functionName, base.gameObject, SendMessageOptions.DontRequireReceiver);
	}

	// Token: 0x04000306 RID: 774
	public GameObject target;

	// Token: 0x04000307 RID: 775
	public string functionName;

	// Token: 0x04000308 RID: 776
	public UIButtonMessage.Trigger trigger;

	// Token: 0x04000309 RID: 777
	public bool includeChildren;

	// Token: 0x0400030A RID: 778
	private bool mStarted;

	// Token: 0x020005D0 RID: 1488
	[DoNotObfuscateNGUI]
	public enum Trigger
	{
		// Token: 0x04004DE6 RID: 19942
		OnClick,
		// Token: 0x04004DE7 RID: 19943
		OnMouseOver,
		// Token: 0x04004DE8 RID: 19944
		OnMouseOut,
		// Token: 0x04004DE9 RID: 19945
		OnPress,
		// Token: 0x04004DEA RID: 19946
		OnRelease,
		// Token: 0x04004DEB RID: 19947
		OnDoubleClick
	}
}
