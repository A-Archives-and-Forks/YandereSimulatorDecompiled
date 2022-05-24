﻿using System;
using UnityEngine;

// Token: 0x0200005C RID: 92
[AddComponentMenu("NGUI/Interaction/Play Sound")]
public class UIPlaySound : MonoBehaviour
{
	// Token: 0x1700001D RID: 29
	// (get) Token: 0x06000214 RID: 532 RVA: 0x000191A8 File Offset: 0x000173A8
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

	// Token: 0x06000215 RID: 533 RVA: 0x000191D7 File Offset: 0x000173D7
	private void OnEnable()
	{
		if (this.trigger == UIPlaySound.Trigger.OnEnable)
		{
			NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
		}
	}

	// Token: 0x06000216 RID: 534 RVA: 0x000191FA File Offset: 0x000173FA
	private void OnDisable()
	{
		if (this.trigger == UIPlaySound.Trigger.OnDisable)
		{
			NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
		}
	}

	// Token: 0x06000217 RID: 535 RVA: 0x00019220 File Offset: 0x00017420
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

	// Token: 0x06000218 RID: 536 RVA: 0x00019280 File Offset: 0x00017480
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

	// Token: 0x06000219 RID: 537 RVA: 0x000192DF File Offset: 0x000174DF
	private void OnClick()
	{
		if (this.canPlay && this.trigger == UIPlaySound.Trigger.OnClick)
		{
			NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
		}
	}

	// Token: 0x0600021A RID: 538 RVA: 0x00019309 File Offset: 0x00017509
	private void OnSelect(bool isSelected)
	{
		if (this.canPlay && (!isSelected || UICamera.currentScheme == UICamera.ControlScheme.Controller))
		{
			this.OnHover(isSelected);
		}
	}

	// Token: 0x0600021B RID: 539 RVA: 0x00019325 File Offset: 0x00017525
	public void Play()
	{
		NGUITools.PlaySound(this.audioClip, this.volume, this.pitch);
	}

	// Token: 0x040003C0 RID: 960
	public AudioClip audioClip;

	// Token: 0x040003C1 RID: 961
	public UIPlaySound.Trigger trigger;

	// Token: 0x040003C2 RID: 962
	[Range(0f, 1f)]
	public float volume = 1f;

	// Token: 0x040003C3 RID: 963
	[Range(0f, 2f)]
	public float pitch = 1f;

	// Token: 0x040003C4 RID: 964
	private bool mIsOver;

	// Token: 0x020005DC RID: 1500
	[DoNotObfuscateNGUI]
	public enum Trigger
	{
		// Token: 0x04004E5D RID: 20061
		OnClick,
		// Token: 0x04004E5E RID: 20062
		OnMouseOver,
		// Token: 0x04004E5F RID: 20063
		OnMouseOut,
		// Token: 0x04004E60 RID: 20064
		OnPress,
		// Token: 0x04004E61 RID: 20065
		OnRelease,
		// Token: 0x04004E62 RID: 20066
		Custom,
		// Token: 0x04004E63 RID: 20067
		OnEnable,
		// Token: 0x04004E64 RID: 20068
		OnDisable
	}
}
