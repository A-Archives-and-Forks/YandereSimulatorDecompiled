﻿using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000024 RID: 36
public abstract class UIItemSlot : MonoBehaviour
{
	// Token: 0x17000002 RID: 2
	// (get) Token: 0x0600008F RID: 143
	protected abstract InvGameItem observedItem { get; }

	// Token: 0x06000090 RID: 144
	protected abstract InvGameItem Replace(InvGameItem item);

	// Token: 0x06000091 RID: 145 RVA: 0x000114E0 File Offset: 0x0000F6E0
	private void OnTooltip(bool show)
	{
		InvGameItem invGameItem = show ? this.mItem : null;
		if (invGameItem != null)
		{
			InvBaseItem baseItem = invGameItem.baseItem;
			if (baseItem != null)
			{
				string text = string.Concat(new string[]
				{
					"[",
					NGUIText.EncodeColor(invGameItem.color),
					"]",
					invGameItem.name,
					"[-]\n"
				});
				text = string.Concat(new string[]
				{
					text,
					"[AFAFAF]Level ",
					invGameItem.itemLevel.ToString(),
					" ",
					baseItem.slot.ToString()
				});
				List<InvStat> list = invGameItem.CalculateStats();
				int i = 0;
				int count = list.Count;
				while (i < count)
				{
					InvStat invStat = list[i];
					if (invStat.amount != 0)
					{
						if (invStat.amount < 0)
						{
							text = text + "\n[FF0000]" + invStat.amount.ToString();
						}
						else
						{
							text = text + "\n[00FF00]+" + invStat.amount.ToString();
						}
						if (invStat.modifier == InvStat.Modifier.Percent)
						{
							text += "%";
						}
						text = text + " " + invStat.id.ToString();
						text += "[-]";
					}
					i++;
				}
				if (!string.IsNullOrEmpty(baseItem.description))
				{
					text = text + "\n[FF9900]" + baseItem.description;
				}
				UITooltip.Show(text);
				return;
			}
		}
		UITooltip.Hide();
	}

	// Token: 0x06000092 RID: 146 RVA: 0x0001166A File Offset: 0x0000F86A
	private void OnClick()
	{
		if (UIItemSlot.mDraggedItem != null)
		{
			this.OnDrop(null);
			return;
		}
		if (this.mItem != null)
		{
			UIItemSlot.mDraggedItem = this.Replace(null);
			if (UIItemSlot.mDraggedItem != null)
			{
				NGUITools.PlaySound(this.grabSound);
			}
			this.UpdateCursor();
		}
	}

	// Token: 0x06000093 RID: 147 RVA: 0x000116A8 File Offset: 0x0000F8A8
	private void OnDrag(Vector2 delta)
	{
		if (UIItemSlot.mDraggedItem == null && this.mItem != null)
		{
			UICamera.currentTouch.clickNotification = UICamera.ClickNotification.BasedOnDelta;
			UIItemSlot.mDraggedItem = this.Replace(null);
			NGUITools.PlaySound(this.grabSound);
			this.UpdateCursor();
		}
	}

	// Token: 0x06000094 RID: 148 RVA: 0x000116E4 File Offset: 0x0000F8E4
	private void OnDrop(GameObject go)
	{
		InvGameItem invGameItem = this.Replace(UIItemSlot.mDraggedItem);
		if (UIItemSlot.mDraggedItem == invGameItem)
		{
			NGUITools.PlaySound(this.errorSound);
		}
		else if (invGameItem != null)
		{
			NGUITools.PlaySound(this.grabSound);
		}
		else
		{
			NGUITools.PlaySound(this.placeSound);
		}
		UIItemSlot.mDraggedItem = invGameItem;
		this.UpdateCursor();
	}

	// Token: 0x06000095 RID: 149 RVA: 0x0001173C File Offset: 0x0000F93C
	private void UpdateCursor()
	{
		if (UIItemSlot.mDraggedItem != null && UIItemSlot.mDraggedItem.baseItem != null)
		{
			UICursor.Set(UIItemSlot.mDraggedItem.baseItem.iconAtlas as INGUIAtlas, UIItemSlot.mDraggedItem.baseItem.iconName);
			return;
		}
		UICursor.Clear();
	}

	// Token: 0x06000096 RID: 150 RVA: 0x0001178C File Offset: 0x0000F98C
	private void Update()
	{
		InvGameItem observedItem = this.observedItem;
		if (this.mItem != observedItem)
		{
			this.mItem = observedItem;
			InvBaseItem invBaseItem = (observedItem != null) ? observedItem.baseItem : null;
			if (this.label != null)
			{
				string text = (observedItem != null) ? observedItem.name : null;
				if (string.IsNullOrEmpty(this.mText))
				{
					this.mText = this.label.text;
				}
				this.label.text = ((text != null) ? text : this.mText);
			}
			if (this.icon != null)
			{
				if (invBaseItem == null || invBaseItem.iconAtlas == null)
				{
					this.icon.enabled = false;
				}
				else
				{
					this.icon.atlas = (invBaseItem.iconAtlas as INGUIAtlas);
					this.icon.spriteName = invBaseItem.iconName;
					this.icon.enabled = true;
					this.icon.MakePixelPerfect();
				}
			}
			if (this.background != null)
			{
				this.background.color = ((observedItem != null) ? observedItem.color : Color.white);
			}
		}
	}

	// Token: 0x04000269 RID: 617
	public UISprite icon;

	// Token: 0x0400026A RID: 618
	public UIWidget background;

	// Token: 0x0400026B RID: 619
	public UILabel label;

	// Token: 0x0400026C RID: 620
	public AudioClip grabSound;

	// Token: 0x0400026D RID: 621
	public AudioClip placeSound;

	// Token: 0x0400026E RID: 622
	public AudioClip errorSound;

	// Token: 0x0400026F RID: 623
	private InvGameItem mItem;

	// Token: 0x04000270 RID: 624
	private string mText = "";

	// Token: 0x04000271 RID: 625
	private static InvGameItem mDraggedItem;
}
