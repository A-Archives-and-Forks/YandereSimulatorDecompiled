﻿using System;
using UnityEngine;

// Token: 0x0200005C RID: 92
[AddComponentMenu("NGUI/Interaction/Play Sound")]
public class UIPlaySound : MonoBehaviour
{
	// Token: 0x1700001D RID: 29
	// (get) Token: 0x06000214 RID: 532 RVA: 0x00018EB8 File Offset: 0x000170B8
	private bool canPlay
	{
		get
		{
			if (!base.enabled)
			{
				return false;
			}
			UIButton component = base.GetComponent<UIButton>();
			return component == null || component.isEnabled;
		}
	}

	// Token: 0x06000215 RID: 533 RVA: 0x00018EE7 File Offset: 0x000170E7
	private void OnEnable()
	{
		if (this.trigger == UIPlaySound.Trigger.OnEnable)
		{
			NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
		}
	}

	// Token: 0x06000216 RID: 534 RVA: 0x00018F0A File Offset: 0x0001710A
	private void OnDisable()
	{
		if (this.trigger == UIPlaySound.Trigger.OnDisable)
		{
			NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
		}
	}

	// Token: 0x06000217 RID: 535 RVA: 0x00018F30 File Offset: 0x00017130
	private void OnHover(bool isOver)
	{
		if (this.trigger == UIPlaySound.Trigger.OnMouseOver)
		{
			if (this.mIsOver == isOver)
			{
				return;
			}
			this.mIsOver = isOver;
		}
		if (this.canPlay && ((isOver && this.trigger == UIPlaySound.Trigger.OnMouseOver) || (!isOver && this.trigger == UIPlaySound.Trigger.OnMouseOut)))
		{
			NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
		}
	}

	// Token: 0x06000218 RID: 536 RVA: 0x00018F90 File Offset: 0x00017190
	private void OnPress(bool isPressed)
	{
		if (this.trigger == UIPlaySound.Trigger.OnPress)
		{
			if (this.mIsOver == isPressed)
			{
				return;
			}
			this.mIsOver = isPressed;
		}
		if (this.canPlay && ((isPressed && this.trigger == UIPlaySound.Trigger.OnPress) || (!isPressed && this.trigger == UIPlaySound.Trigger.OnRelease)))
		{
			NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
		}
	}

	// Token: 0x06000219 RID: 537 RVA: 0x00018FEF File Offset: 0x000171EF
	private void OnClick()
	{
		if (this.canPlay && this.trigger == UIPlaySound.Trigger.OnClick)
		{
			NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
		}
	}

	// Token: 0x0600021A RID: 538 RVA: 0x00019019 File Offset: 0x00017219
	private void OnSelect(bool isSelected)
	{
		if (this.canPlay && (!isSelected || UICamera.currentScheme == UICamera.ControlScheme.Controller))
		{
			this.OnHover(isSelected);
		}
	}

	// Token: 0x0600021B RID: 539 RVA: 0x00019035 File Offset: 0x00017235
	public void Play()
	{
		NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
	}

	// Token: 0x040003B5 RID: 949
	public AudioClip audioClip;

	// Token: 0x040003B6 RID: 950
	public UIPlaySound.Trigger trigger;

	// Token: 0x040003B7 RID: 951
	[Range(0f, 1f)]
	public float volume = 1f;

	// Token: 0x040003B8 RID: 952
	[Range(0f, 2f)]
	public float pitch = 1f;

	// Token: 0x040003B9 RID: 953
	private bool mIsOver;

	// Token: 0x020005CE RID: 1486
	[DoNotObfuscateNGUI]
	public enum Trigger
	{
		// Token: 0x04004D3B RID: 19771
		OnClick,
		// Token: 0x04004D3C RID: 19772
		OnMouseOver,
		// Token: 0x04004D3D RID: 19773
		OnMouseOut,
		// Token: 0x04004D3E RID: 19774
		OnPress,
		// Token: 0x04004D3F RID: 19775
		OnRelease,
		// Token: 0x04004D40 RID: 19776
		Custom,
		// Token: 0x04004D41 RID: 19777
		OnEnable,
		// Token: 0x04004D42 RID: 19778
		OnDisable
	}
}
