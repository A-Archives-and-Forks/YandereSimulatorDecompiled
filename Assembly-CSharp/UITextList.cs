﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x020000AE RID: 174
[AddComponentMenu("NGUI/UI/Text List")]
public class UITextList : MonoBehaviour
{
	// Token: 0x170001CA RID: 458
	// (get) Token: 0x060008B2 RID: 2226 RVA: 0x00047904 File Offset: 0x00045B04
	protected BetterList<UITextList.Paragraph> paragraphs
	{
		get
		{
			if (this.mParagraphs == null && !UITextList.mHistory.TryGetValue(base.name, out this.mParagraphs))
			{
				this.mParagraphs = new BetterList<UITextList.Paragraph>();
				UITextList.mHistory.Add(base.name, this.mParagraphs);
			}
			return this.mParagraphs;
		}
	}

	// Token: 0x170001CB RID: 459
	// (get) Token: 0x060008B3 RID: 2227 RVA: 0x00047958 File Offset: 0x00045B58
	public int paragraphCount
	{
		get
		{
			return this.paragraphs.size;
		}
	}

	// Token: 0x170001CC RID: 460
	// (get) Token: 0x060008B4 RID: 2228 RVA: 0x00047965 File Offset: 0x00045B65
	public bool isValid
	{
		get
		{
			return this.textLabel != null && this.textLabel.ambigiousFont != null;
		}
	}

	// Token: 0x170001CD RID: 461
	// (get) Token: 0x060008B5 RID: 2229 RVA: 0x00047988 File Offset: 0x00045B88
	// (set) Token: 0x060008B6 RID: 2230 RVA: 0x00047990 File Offset: 0x00045B90
	public float scrollValue
	{
		get
		{
			return this.mScroll;
		}
		set
		{
			value = Mathf.Clamp01(value);
			if (this.isValid && this.mScroll != value)
			{
				if (this.scrollBar != null)
				{
					this.scrollBar.value = value;
					return;
				}
				this.mScroll = value;
				this.UpdateVisibleText();
			}
		}
	}

	// Token: 0x170001CE RID: 462
	// (get) Token: 0x060008B7 RID: 2231 RVA: 0x000479DE File Offset: 0x00045BDE
	protected float lineHeight
	{
		get
		{
			if (!(this.textLabel != null))
			{
				return 20f;
			}
			return (float)this.textLabel.fontSize + this.textLabel.effectiveSpacingY;
		}
	}

	// Token: 0x170001CF RID: 463
	// (get) Token: 0x060008B8 RID: 2232 RVA: 0x00047A0C File Offset: 0x00045C0C
	protected int scrollHeight
	{
		get
		{
			if (!this.isValid)
			{
				return 0;
			}
			int num = Mathf.FloorToInt((float)this.textLabel.height / this.lineHeight);
			return Mathf.Max(0, this.mTotalLines - num);
		}
	}

	// Token: 0x060008B9 RID: 2233 RVA: 0x00047A4A File Offset: 0x00045C4A
	public void Clear()
	{
		this.paragraphs.Clear();
		this.UpdateVisibleText();
	}

	// Token: 0x060008BA RID: 2234 RVA: 0x00047A60 File Offset: 0x00045C60
	private void Start()
	{
		if (this.textLabel == null)
		{
			this.textLabel = base.GetComponentInChildren<UILabel>();
		}
		if (this.scrollBar != null)
		{
			EventDelegate.Add(this.scrollBar.onChange, new EventDelegate.Callback(this.OnScrollBar));
		}
		this.textLabel.overflowMethod = UILabel.Overflow.ClampContent;
		if (this.style == UITextList.Style.Chat)
		{
			this.textLabel.pivot = UIWidget.Pivot.BottomLeft;
			this.scrollValue = 1f;
			return;
		}
		this.textLabel.pivot = UIWidget.Pivot.TopLeft;
		this.scrollValue = 0f;
	}

	// Token: 0x060008BB RID: 2235 RVA: 0x00047AF6 File Offset: 0x00045CF6
	private void Update()
	{
		if (this.isValid && (this.textLabel.width != this.mLastWidth || this.textLabel.height != this.mLastHeight))
		{
			this.Rebuild();
		}
	}

	// Token: 0x060008BC RID: 2236 RVA: 0x00047B2C File Offset: 0x00045D2C
	public void OnScroll(float val)
	{
		int scrollHeight = this.scrollHeight;
		if (scrollHeight != 0)
		{
			val *= this.lineHeight;
			this.scrollValue = this.mScroll - val / (float)scrollHeight;
		}
	}

	// Token: 0x060008BD RID: 2237 RVA: 0x00047B60 File Offset: 0x00045D60
	public void OnDrag(Vector2 delta)
	{
		int scrollHeight = this.scrollHeight;
		if (scrollHeight != 0)
		{
			float num = delta.y / this.lineHeight;
			this.scrollValue = this.mScroll + num / (float)scrollHeight;
		}
	}

	// Token: 0x060008BE RID: 2238 RVA: 0x00047B96 File Offset: 0x00045D96
	private void OnScrollBar()
	{
		this.mScroll = UIProgressBar.current.value;
		this.UpdateVisibleText();
	}

	// Token: 0x060008BF RID: 2239 RVA: 0x00047BAE File Offset: 0x00045DAE
	public void Add(string text)
	{
		this.Add(text, true);
	}

	// Token: 0x060008C0 RID: 2240 RVA: 0x00047BB8 File Offset: 0x00045DB8
	protected void Add(string text, bool updateVisible)
	{
		UITextList.Paragraph paragraph;
		if (this.paragraphs.size < this.paragraphHistory)
		{
			paragraph = new UITextList.Paragraph();
		}
		else
		{
			paragraph = this.mParagraphs.buffer[0];
			this.mParagraphs.RemoveAt(0);
		}
		paragraph.text = text;
		this.mParagraphs.Add(paragraph);
		this.Rebuild();
	}

	// Token: 0x060008C1 RID: 2241 RVA: 0x00047C18 File Offset: 0x00045E18
	protected void Rebuild()
	{
		if (this.isValid)
		{
			this.mLastWidth = this.textLabel.width;
			this.mLastHeight = this.textLabel.height;
			this.textLabel.UpdateNGUIText();
			NGUIText.rectHeight = 1000000;
			NGUIText.regionHeight = 1000000;
			this.mTotalLines = 0;
			for (int i = 0; i < this.paragraphs.size; i++)
			{
				UITextList.Paragraph paragraph = this.mParagraphs.buffer[i];
				string text;
				NGUIText.WrapText(paragraph.text, out text, false, true, false);
				paragraph.lines = text.Split(new char[]
				{
					'\n'
				});
				this.mTotalLines += paragraph.lines.Length;
			}
			this.mTotalLines = 0;
			int j = 0;
			int size = this.mParagraphs.size;
			while (j < size)
			{
				this.mTotalLines += this.mParagraphs.buffer[j].lines.Length;
				j++;
			}
			if (this.scrollBar != null)
			{
				UIScrollBar uiscrollBar = this.scrollBar as UIScrollBar;
				if (uiscrollBar != null)
				{
					uiscrollBar.barSize = ((this.mTotalLines == 0) ? 1f : (1f - (float)this.scrollHeight / (float)this.mTotalLines));
				}
			}
			this.UpdateVisibleText();
		}
	}

	// Token: 0x060008C2 RID: 2242 RVA: 0x00047D74 File Offset: 0x00045F74
	protected void UpdateVisibleText()
	{
		if (this.isValid)
		{
			if (this.mTotalLines == 0)
			{
				this.textLabel.text = "";
				return;
			}
			int num = Mathf.FloorToInt((float)this.textLabel.height / this.lineHeight);
			int num2 = Mathf.Max(0, this.mTotalLines - num);
			int num3 = Mathf.RoundToInt(this.mScroll * (float)num2);
			if (num3 < 0)
			{
				num3 = 0;
			}
			StringBuilder stringBuilder = new StringBuilder();
			int num4 = 0;
			int size = this.paragraphs.size;
			while (num > 0 && num4 < size)
			{
				UITextList.Paragraph paragraph = this.mParagraphs.buffer[num4];
				int num5 = 0;
				int num6 = paragraph.lines.Length;
				while (num > 0 && num5 < num6)
				{
					string value = paragraph.lines[num5];
					if (num3 > 0)
					{
						num3--;
					}
					else
					{
						if (stringBuilder.Length > 0)
						{
							stringBuilder.Append("\n");
						}
						stringBuilder.Append(value);
						num--;
					}
					num5++;
				}
				num4++;
			}
			this.textLabel.text = stringBuilder.ToString();
		}
	}

	// Token: 0x04000792 RID: 1938
	public UILabel textLabel;

	// Token: 0x04000793 RID: 1939
	public UIProgressBar scrollBar;

	// Token: 0x04000794 RID: 1940
	public UITextList.Style style;

	// Token: 0x04000795 RID: 1941
	public int paragraphHistory = 100;

	// Token: 0x04000796 RID: 1942
	protected char[] mSeparator = new char[]
	{
		'\n'
	};

	// Token: 0x04000797 RID: 1943
	protected float mScroll;

	// Token: 0x04000798 RID: 1944
	protected int mTotalLines;

	// Token: 0x04000799 RID: 1945
	protected int mLastWidth;

	// Token: 0x0400079A RID: 1946
	protected int mLastHeight;

	// Token: 0x0400079B RID: 1947
	private BetterList<UITextList.Paragraph> mParagraphs;

	// Token: 0x0400079C RID: 1948
	private static Dictionary<string, BetterList<UITextList.Paragraph>> mHistory = new Dictionary<string, BetterList<UITextList.Paragraph>>();

	// Token: 0x0200064E RID: 1614
	[DoNotObfuscateNGUI]
	public enum Style
	{
		// Token: 0x04004F59 RID: 20313
		Text,
		// Token: 0x04004F5A RID: 20314
		Chat
	}

	// Token: 0x0200064F RID: 1615
	protected class Paragraph
	{
		// Token: 0x04004F5B RID: 20315
		public string text;

		// Token: 0x04004F5C RID: 20316
		public string[] lines;
	}
}
