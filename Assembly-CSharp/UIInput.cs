﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Token: 0x020000A2 RID: 162
[AddComponentMenu("NGUI/UI/Input Field")]
public class UIInput : MonoBehaviour
{
	// Token: 0x1700014D RID: 333
	// (get) Token: 0x06000736 RID: 1846 RVA: 0x0003E24E File Offset: 0x0003C44E
	// (set) Token: 0x06000737 RID: 1847 RVA: 0x0003E264 File Offset: 0x0003C464
	public string defaultText
	{
		get
		{
			if (this.mDoInit)
			{
				this.Init();
			}
			return this.mDefaultText;
		}
		set
		{
			if (this.mDoInit)
			{
				this.Init();
			}
			this.mDefaultText = value;
			this.UpdateLabel();
		}
	}

	// Token: 0x1700014E RID: 334
	// (get) Token: 0x06000738 RID: 1848 RVA: 0x0003E281 File Offset: 0x0003C481
	// (set) Token: 0x06000739 RID: 1849 RVA: 0x0003E297 File Offset: 0x0003C497
	public Color defaultColor
	{
		get
		{
			if (this.mDoInit)
			{
				this.Init();
			}
			return this.mDefaultColor;
		}
		set
		{
			this.mDefaultColor = value;
			if (!this.isSelected)
			{
				this.label.color = value;
			}
		}
	}

	// Token: 0x1700014F RID: 335
	// (get) Token: 0x0600073A RID: 1850 RVA: 0x0003E2B4 File Offset: 0x0003C4B4
	public bool inputShouldBeHidden
	{
		get
		{
			return this.hideInput && this.label != null && !this.label.multiLine && this.inputType != UIInput.InputType.Password;
		}
	}

	// Token: 0x17000150 RID: 336
	// (get) Token: 0x0600073B RID: 1851 RVA: 0x0003E2E7 File Offset: 0x0003C4E7
	// (set) Token: 0x0600073C RID: 1852 RVA: 0x0003E2EF File Offset: 0x0003C4EF
	[Obsolete("Use UIInput.value instead")]
	public string text
	{
		get
		{
			return this.value;
		}
		set
		{
			this.value = value;
		}
	}

	// Token: 0x17000151 RID: 337
	// (get) Token: 0x0600073D RID: 1853 RVA: 0x0003E2F8 File Offset: 0x0003C4F8
	// (set) Token: 0x0600073E RID: 1854 RVA: 0x0003E30E File Offset: 0x0003C50E
	public string value
	{
		get
		{
			if (this.mDoInit)
			{
				this.Init();
			}
			return this.mValue;
		}
		set
		{
			this.Set(value, true);
		}
	}

	// Token: 0x0600073F RID: 1855 RVA: 0x0003E318 File Offset: 0x0003C518
	public void Set(string value, bool notify = true)
	{
		if (this.mDoInit)
		{
			this.Init();
		}
		if (value == this.value)
		{
			return;
		}
		UIInput.mDrawStart = 0;
		value = this.Validate(value);
		if (this.mValue != value)
		{
			this.mValue = value;
			this.mLoadSavedValue = false;
			if (this.isSelected)
			{
				if (string.IsNullOrEmpty(value))
				{
					this.mSelectionStart = 0;
					this.mSelectionEnd = 0;
				}
				else
				{
					this.mSelectionStart = value.Length;
					this.mSelectionEnd = this.mSelectionStart;
				}
			}
			else if (this.mStarted)
			{
				this.SaveToPlayerPrefs(value);
			}
			this.UpdateLabel();
			if (notify)
			{
				this.ExecuteOnChange();
			}
		}
	}

	// Token: 0x17000152 RID: 338
	// (get) Token: 0x06000740 RID: 1856 RVA: 0x0003E3C5 File Offset: 0x0003C5C5
	// (set) Token: 0x06000741 RID: 1857 RVA: 0x0003E3CD File Offset: 0x0003C5CD
	[Obsolete("Use UIInput.isSelected instead")]
	public bool selected
	{
		get
		{
			return this.isSelected;
		}
		set
		{
			this.isSelected = value;
		}
	}

	// Token: 0x17000153 RID: 339
	// (get) Token: 0x06000742 RID: 1858 RVA: 0x0003E3D6 File Offset: 0x0003C5D6
	// (set) Token: 0x06000743 RID: 1859 RVA: 0x0003E3E3 File Offset: 0x0003C5E3
	public bool isSelected
	{
		get
		{
			return UIInput.selection == this;
		}
		set
		{
			if (!value)
			{
				if (this.isSelected)
				{
					UICamera.selectedObject = null;
					return;
				}
			}
			else
			{
				UICamera.selectedObject = base.gameObject;
			}
		}
	}

	// Token: 0x17000154 RID: 340
	// (get) Token: 0x06000744 RID: 1860 RVA: 0x0003E402 File Offset: 0x0003C602
	// (set) Token: 0x06000745 RID: 1861 RVA: 0x0003E41E File Offset: 0x0003C61E
	public int cursorPosition
	{
		get
		{
			if (!this.isSelected)
			{
				return this.value.Length;
			}
			return this.mSelectionEnd;
		}
		set
		{
			if (this.isSelected)
			{
				this.mSelectionEnd = value;
				this.UpdateLabel();
			}
		}
	}

	// Token: 0x17000155 RID: 341
	// (get) Token: 0x06000746 RID: 1862 RVA: 0x0003E435 File Offset: 0x0003C635
	// (set) Token: 0x06000747 RID: 1863 RVA: 0x0003E451 File Offset: 0x0003C651
	public int selectionStart
	{
		get
		{
			if (!this.isSelected)
			{
				return this.value.Length;
			}
			return this.mSelectionStart;
		}
		set
		{
			if (this.isSelected)
			{
				this.mSelectionStart = value;
				this.UpdateLabel();
			}
		}
	}

	// Token: 0x17000156 RID: 342
	// (get) Token: 0x06000748 RID: 1864 RVA: 0x0003E468 File Offset: 0x0003C668
	// (set) Token: 0x06000749 RID: 1865 RVA: 0x0003E484 File Offset: 0x0003C684
	public int selectionEnd
	{
		get
		{
			if (!this.isSelected)
			{
				return this.value.Length;
			}
			return this.mSelectionEnd;
		}
		set
		{
			if (this.isSelected)
			{
				this.mSelectionEnd = value;
				this.UpdateLabel();
			}
		}
	}

	// Token: 0x17000157 RID: 343
	// (get) Token: 0x0600074A RID: 1866 RVA: 0x0003E49B File Offset: 0x0003C69B
	public UITexture caret
	{
		get
		{
			return this.mCaret;
		}
	}

	// Token: 0x0600074B RID: 1867 RVA: 0x0003E4A4 File Offset: 0x0003C6A4
	public string Validate(string val)
	{
		if (string.IsNullOrEmpty(val))
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder(val.Length);
		foreach (char c in val)
		{
			if (this.onValidate != null)
			{
				c = this.onValidate(stringBuilder.ToString(), stringBuilder.Length, c);
			}
			else if (this.validation != UIInput.Validation.None)
			{
				c = this.Validate(stringBuilder.ToString(), stringBuilder.Length, c);
			}
			if (c != '\0')
			{
				stringBuilder.Append(c);
			}
		}
		if (this.characterLimit > 0 && stringBuilder.Length > this.characterLimit)
		{
			return stringBuilder.ToString(0, this.characterLimit);
		}
		return stringBuilder.ToString();
	}

	// Token: 0x0600074C RID: 1868 RVA: 0x0003E55C File Offset: 0x0003C75C
	public void Start()
	{
		if (this.mStarted)
		{
			return;
		}
		if (this.selectOnTab != null)
		{
			if (base.GetComponent<UIKeyNavigation>() == null)
			{
				base.gameObject.AddComponent<UIKeyNavigation>().onDown = this.selectOnTab;
			}
			this.selectOnTab = null;
			NGUITools.SetDirty(this, "last change");
		}
		if (this.mLoadSavedValue && !string.IsNullOrEmpty(this.savedAs))
		{
			this.LoadValue();
		}
		else
		{
			this.value = this.mValue.Replace("\\n", "\n");
		}
		this.mStarted = true;
	}

	// Token: 0x0600074D RID: 1869 RVA: 0x0003E5F8 File Offset: 0x0003C7F8
	protected void Init()
	{
		if (this.mDoInit && this.label != null)
		{
			this.mDoInit = false;
			this.mDefaultText = this.label.text;
			this.mDefaultColor = this.label.color;
			this.mEllipsis = this.label.overflowEllipsis;
			if (this.label.alignment == NGUIText.Alignment.Justified)
			{
				this.label.alignment = NGUIText.Alignment.Left;
				Debug.LogWarning("Input fields using labels with justified alignment are not supported at this time", this);
			}
			this.mAlignment = this.label.alignment;
			this.mPosition = this.label.cachedTransform.localPosition.x;
			this.UpdateLabel();
		}
	}

	// Token: 0x0600074E RID: 1870 RVA: 0x0003E6B2 File Offset: 0x0003C8B2
	protected void SaveToPlayerPrefs(string val)
	{
		if (!string.IsNullOrEmpty(this.savedAs))
		{
			if (string.IsNullOrEmpty(val))
			{
				PlayerPrefs.DeleteKey(this.savedAs);
				return;
			}
			PlayerPrefs.SetString(this.savedAs, val);
		}
	}

	// Token: 0x0600074F RID: 1871 RVA: 0x0003E6E4 File Offset: 0x0003C8E4
	protected virtual void OnSelect(bool isSelected)
	{
		if (isSelected)
		{
			if (this.label != null)
			{
				this.label.supportEncoding = false;
			}
			if (this.mOnGUI == null)
			{
				this.mOnGUI = base.gameObject.AddComponent<UIInputOnGUI>();
			}
			this.OnSelectEvent();
			return;
		}
		if (this.mOnGUI != null)
		{
			UnityEngine.Object.Destroy(this.mOnGUI);
			this.mOnGUI = null;
		}
		this.OnDeselectEvent();
	}

	// Token: 0x06000750 RID: 1872 RVA: 0x0003E75C File Offset: 0x0003C95C
	protected void OnSelectEvent()
	{
		this.mSelectTime = Time.frameCount;
		UIInput.selection = this;
		if (this.mDoInit)
		{
			this.Init();
		}
		if (this.label != null)
		{
			this.mEllipsis = this.label.overflowEllipsis;
			this.label.overflowEllipsis = false;
		}
		if (this.label != null && NGUITools.GetActive(this))
		{
			this.mSelectMe = Time.frameCount;
		}
	}

	// Token: 0x06000751 RID: 1873 RVA: 0x0003E7D4 File Offset: 0x0003C9D4
	protected void OnDeselectEvent()
	{
		if (this.mDoInit)
		{
			this.Init();
		}
		if (this.label != null)
		{
			this.label.overflowEllipsis = this.mEllipsis;
		}
		if (this.label != null && NGUITools.GetActive(this))
		{
			this.mValue = this.value;
			if (string.IsNullOrEmpty(this.mValue))
			{
				this.label.text = this.mDefaultText;
				this.label.color = this.mDefaultColor;
			}
			else
			{
				this.label.text = this.mValue;
			}
			Input.imeCompositionMode = IMECompositionMode.Auto;
			this.label.alignment = this.mAlignment;
		}
		UIInput.selection = null;
		this.UpdateLabel();
		if (this.submitOnUnselect)
		{
			this.Submit();
		}
	}

	// Token: 0x06000752 RID: 1874 RVA: 0x0003E8A4 File Offset: 0x0003CAA4
	protected virtual void Update()
	{
		if (!this.isSelected || this.mSelectTime == Time.frameCount)
		{
			return;
		}
		if (this.mDoInit)
		{
			this.Init();
		}
		if (this.mSelectMe != -1 && this.mSelectMe != Time.frameCount)
		{
			this.mSelectMe = -1;
			this.mSelectionEnd = (string.IsNullOrEmpty(this.mValue) ? 0 : this.mValue.Length);
			UIInput.mDrawStart = 0;
			this.mSelectionStart = (this.selectAllTextOnFocus ? 0 : this.mSelectionEnd);
			this.label.color = this.activeTextColor;
			Vector2 vector = (UICamera.current != null && UICamera.current.cachedCamera != null) ? UICamera.current.cachedCamera.WorldToScreenPoint(this.label.worldCorners[0]) : this.label.worldCorners[0];
			vector.y = (float)Screen.height - vector.y;
			Input.imeCompositionMode = IMECompositionMode.On;
			Input.compositionCursorPos = vector;
			this.UpdateLabel();
			if (string.IsNullOrEmpty(Input.inputString))
			{
				return;
			}
		}
		string compositionString = Input.compositionString;
		if (string.IsNullOrEmpty(compositionString) && !string.IsNullOrEmpty(Input.inputString))
		{
			foreach (char c in Input.inputString)
			{
				if (c >= ' ' && c != '' && c != '' && c != '' && c != '' && c != '')
				{
					this.Insert(c.ToString());
				}
			}
		}
		if (UIInput.mLastIME != compositionString)
		{
			this.mSelectionEnd = (string.IsNullOrEmpty(compositionString) ? this.mSelectionStart : (this.mValue.Length + compositionString.Length));
			UIInput.mLastIME = compositionString;
			this.UpdateLabel();
			this.ExecuteOnChange();
		}
		if (this.mCaret != null && this.mNextBlink < RealTime.time)
		{
			this.mNextBlink = RealTime.time + 0.5f;
			this.mCaret.enabled = !this.mCaret.enabled;
		}
		if (this.isSelected && this.mLastAlpha != this.label.finalAlpha)
		{
			this.UpdateLabel();
		}
		if (this.mCam == null)
		{
			this.mCam = UICamera.FindCameraForLayer(base.gameObject.layer);
		}
		if (this.mCam != null)
		{
			bool flag = false;
			if (this.label.multiLine)
			{
				bool flag2 = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
				if (this.onReturnKey == UIInput.OnReturnKey.Submit)
				{
					flag = flag2;
				}
				else
				{
					flag = !flag2;
				}
			}
			if (UICamera.GetKeyDown(this.mCam.submitKey0) || (this.mCam.submitKey0 == KeyCode.Return && UICamera.GetKeyDown(KeyCode.KeypadEnter)))
			{
				if (flag)
				{
					this.Insert("\n");
				}
				else
				{
					if (UICamera.controller.current != null)
					{
						UICamera.controller.clickNotification = UICamera.ClickNotification.None;
					}
					UICamera.currentKey = this.mCam.submitKey0;
					this.Submit();
				}
			}
			if (UICamera.GetKeyDown(this.mCam.submitKey1) || (this.mCam.submitKey1 == KeyCode.Return && UICamera.GetKeyDown(KeyCode.KeypadEnter)))
			{
				if (flag)
				{
					this.Insert("\n");
				}
				else
				{
					if (UICamera.controller.current != null)
					{
						UICamera.controller.clickNotification = UICamera.ClickNotification.None;
					}
					UICamera.currentKey = this.mCam.submitKey1;
					this.Submit();
				}
			}
			if (!this.mCam.useKeyboard && UICamera.GetKeyUp(KeyCode.Tab))
			{
				this.OnKey(KeyCode.Tab);
			}
		}
	}

	// Token: 0x06000753 RID: 1875 RVA: 0x0003EC88 File Offset: 0x0003CE88
	private void OnKey(KeyCode key)
	{
		int frameCount = Time.frameCount;
		if (UIInput.mIgnoreKey == frameCount)
		{
			return;
		}
		if (this.mCam != null && (key == this.mCam.cancelKey0 || key == this.mCam.cancelKey1))
		{
			UIInput.mIgnoreKey = frameCount;
			this.isSelected = false;
			return;
		}
		if (key == KeyCode.Tab)
		{
			UIInput.mIgnoreKey = frameCount;
			this.isSelected = false;
			UIKeyNavigation component = base.GetComponent<UIKeyNavigation>();
			if (component != null)
			{
				component.OnKey(KeyCode.Tab);
			}
		}
	}

	// Token: 0x06000754 RID: 1876 RVA: 0x0003ED06 File Offset: 0x0003CF06
	protected void DoBackspace()
	{
		if (!string.IsNullOrEmpty(this.mValue))
		{
			if (this.mSelectionStart == this.mSelectionEnd)
			{
				if (this.mSelectionStart < 1)
				{
					return;
				}
				this.mSelectionEnd--;
			}
			this.Insert("");
		}
	}

	// Token: 0x06000755 RID: 1877 RVA: 0x0003ED48 File Offset: 0x0003CF48
	public virtual bool ProcessEvent(Event ev)
	{
		if (this.label == null)
		{
			return false;
		}
		RuntimePlatform platform = Application.platform;
		bool flag = (platform == RuntimePlatform.OSXEditor || platform == RuntimePlatform.OSXPlayer) ? ((ev.modifiers & EventModifiers.Command) > EventModifiers.None) : ((ev.modifiers & EventModifiers.Control) > EventModifiers.None);
		if ((ev.modifiers & EventModifiers.Alt) != EventModifiers.None)
		{
			flag = false;
		}
		bool flag2 = (ev.modifiers & EventModifiers.Shift) > EventModifiers.None;
		KeyCode keyCode = ev.keyCode;
		if (keyCode <= KeyCode.C)
		{
			if (keyCode == KeyCode.Backspace)
			{
				ev.Use();
				this.DoBackspace();
				return true;
			}
			if (keyCode == KeyCode.A)
			{
				if (flag)
				{
					ev.Use();
					this.mSelectionStart = 0;
					this.mSelectionEnd = this.mValue.Length;
					this.UpdateLabel();
				}
				return true;
			}
			if (keyCode == KeyCode.C)
			{
				if (flag)
				{
					ev.Use();
					NGUITools.clipboard = this.GetSelection();
				}
				return true;
			}
		}
		else if (keyCode <= KeyCode.X)
		{
			if (keyCode == KeyCode.V)
			{
				if (flag)
				{
					ev.Use();
					this.Insert(NGUITools.clipboard);
				}
				return true;
			}
			if (keyCode == KeyCode.X)
			{
				if (flag)
				{
					ev.Use();
					NGUITools.clipboard = this.GetSelection();
					this.Insert("");
				}
				return true;
			}
		}
		else
		{
			if (keyCode == KeyCode.Delete)
			{
				ev.Use();
				if (!string.IsNullOrEmpty(this.mValue))
				{
					if (this.mSelectionStart == this.mSelectionEnd)
					{
						if (this.mSelectionStart >= this.mValue.Length)
						{
							return true;
						}
						this.mSelectionEnd++;
					}
					this.Insert("");
				}
				return true;
			}
			switch (keyCode)
			{
			case KeyCode.UpArrow:
				ev.Use();
				if (this.onUpArrow != null)
				{
					this.onUpArrow();
				}
				else if (!string.IsNullOrEmpty(this.mValue))
				{
					this.mSelectionEnd = this.label.GetCharacterIndex(this.mSelectionEnd, KeyCode.UpArrow);
					if (this.mSelectionEnd != 0)
					{
						this.mSelectionEnd += UIInput.mDrawStart;
					}
					if (!flag2)
					{
						this.mSelectionStart = this.mSelectionEnd;
					}
					this.UpdateLabel();
				}
				return true;
			case KeyCode.DownArrow:
				ev.Use();
				if (this.onDownArrow != null)
				{
					this.onDownArrow();
				}
				else if (!string.IsNullOrEmpty(this.mValue))
				{
					this.mSelectionEnd = this.label.GetCharacterIndex(this.mSelectionEnd, KeyCode.DownArrow);
					if (this.mSelectionEnd != this.label.processedText.Length)
					{
						this.mSelectionEnd += UIInput.mDrawStart;
					}
					else
					{
						this.mSelectionEnd = this.mValue.Length;
					}
					if (!flag2)
					{
						this.mSelectionStart = this.mSelectionEnd;
					}
					this.UpdateLabel();
				}
				return true;
			case KeyCode.RightArrow:
				ev.Use();
				if (!string.IsNullOrEmpty(this.mValue))
				{
					this.mSelectionEnd = Mathf.Min(this.mSelectionEnd + 1, this.mValue.Length);
					if (!flag2)
					{
						this.mSelectionStart = this.mSelectionEnd;
					}
					this.UpdateLabel();
				}
				return true;
			case KeyCode.LeftArrow:
				ev.Use();
				if (!string.IsNullOrEmpty(this.mValue))
				{
					this.mSelectionEnd = Mathf.Max(this.mSelectionEnd - 1, 0);
					if (!flag2)
					{
						this.mSelectionStart = this.mSelectionEnd;
					}
					this.UpdateLabel();
				}
				return true;
			case KeyCode.Home:
				ev.Use();
				if (!string.IsNullOrEmpty(this.mValue))
				{
					if (this.label.multiLine)
					{
						this.mSelectionEnd = this.label.GetCharacterIndex(this.mSelectionEnd, KeyCode.Home);
					}
					else
					{
						this.mSelectionEnd = 0;
					}
					if (!flag2)
					{
						this.mSelectionStart = this.mSelectionEnd;
					}
					this.UpdateLabel();
				}
				return true;
			case KeyCode.End:
				ev.Use();
				if (!string.IsNullOrEmpty(this.mValue))
				{
					if (this.label.multiLine)
					{
						this.mSelectionEnd = this.label.GetCharacterIndex(this.mSelectionEnd, KeyCode.End);
					}
					else
					{
						this.mSelectionEnd = this.mValue.Length;
					}
					if (!flag2)
					{
						this.mSelectionStart = this.mSelectionEnd;
					}
					this.UpdateLabel();
				}
				return true;
			case KeyCode.PageUp:
				ev.Use();
				if (!string.IsNullOrEmpty(this.mValue))
				{
					this.mSelectionEnd = 0;
					if (!flag2)
					{
						this.mSelectionStart = this.mSelectionEnd;
					}
					this.UpdateLabel();
				}
				return true;
			case KeyCode.PageDown:
				ev.Use();
				if (!string.IsNullOrEmpty(this.mValue))
				{
					this.mSelectionEnd = this.mValue.Length;
					if (!flag2)
					{
						this.mSelectionStart = this.mSelectionEnd;
					}
					this.UpdateLabel();
				}
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000756 RID: 1878 RVA: 0x0003F1B8 File Offset: 0x0003D3B8
	protected virtual void Insert(string text)
	{
		string leftText = this.GetLeftText();
		string rightText = this.GetRightText();
		int length = rightText.Length;
		StringBuilder stringBuilder = new StringBuilder(leftText.Length + rightText.Length + text.Length);
		stringBuilder.Append(leftText);
		int i = 0;
		int length2 = text.Length;
		while (i < length2)
		{
			char c = text[i];
			if (c == '\b')
			{
				this.DoBackspace();
			}
			else
			{
				if (this.characterLimit > 0 && stringBuilder.Length + length >= this.characterLimit)
				{
					break;
				}
				if (this.onValidate != null)
				{
					c = this.onValidate(stringBuilder.ToString(), stringBuilder.Length, c);
				}
				else if (this.validation != UIInput.Validation.None)
				{
					c = this.Validate(stringBuilder.ToString(), stringBuilder.Length, c);
				}
				if (c != '\0')
				{
					stringBuilder.Append(c);
				}
			}
			i++;
		}
		this.mSelectionStart = stringBuilder.Length;
		this.mSelectionEnd = this.mSelectionStart;
		int j = 0;
		int length3 = rightText.Length;
		while (j < length3)
		{
			char c2 = rightText[j];
			if (this.onValidate != null)
			{
				c2 = this.onValidate(stringBuilder.ToString(), stringBuilder.Length, c2);
			}
			else if (this.validation != UIInput.Validation.None)
			{
				c2 = this.Validate(stringBuilder.ToString(), stringBuilder.Length, c2);
			}
			if (c2 != '\0')
			{
				stringBuilder.Append(c2);
			}
			j++;
		}
		this.mValue = stringBuilder.ToString();
		this.UpdateLabel();
		this.ExecuteOnChange();
	}

	// Token: 0x06000757 RID: 1879 RVA: 0x0003F340 File Offset: 0x0003D540
	protected string GetLeftText()
	{
		int num = Mathf.Min(new int[]
		{
			this.mSelectionStart,
			this.mSelectionEnd,
			this.mValue.Length
		});
		if (!string.IsNullOrEmpty(this.mValue) && num >= 0)
		{
			return this.mValue.Substring(0, num);
		}
		return "";
	}

	// Token: 0x06000758 RID: 1880 RVA: 0x0003F3A0 File Offset: 0x0003D5A0
	protected string GetRightText()
	{
		int num = Mathf.Max(this.mSelectionStart, this.mSelectionEnd);
		if (!string.IsNullOrEmpty(this.mValue) && num < this.mValue.Length)
		{
			return this.mValue.Substring(num);
		}
		return "";
	}

	// Token: 0x06000759 RID: 1881 RVA: 0x0003F3EC File Offset: 0x0003D5EC
	protected string GetSelection()
	{
		if (string.IsNullOrEmpty(this.mValue) || this.mSelectionStart == this.mSelectionEnd)
		{
			return "";
		}
		int num = Mathf.Min(this.mSelectionStart, this.mSelectionEnd);
		int num2 = Mathf.Max(this.mSelectionStart, this.mSelectionEnd);
		return this.mValue.Substring(num, num2 - num);
	}

	// Token: 0x0600075A RID: 1882 RVA: 0x0003F450 File Offset: 0x0003D650
	protected int GetCharUnderMouse()
	{
		Vector3[] worldCorners = this.label.worldCorners;
		Ray currentRay = UICamera.currentRay;
		Plane plane = new Plane(worldCorners[0], worldCorners[1], worldCorners[2]);
		float distance;
		if (!plane.Raycast(currentRay, out distance))
		{
			return 0;
		}
		return UIInput.mDrawStart + this.label.GetCharacterIndexAtPosition(currentRay.GetPoint(distance), false);
	}

	// Token: 0x0600075B RID: 1883 RVA: 0x0003F4B4 File Offset: 0x0003D6B4
	protected virtual void OnPress(bool isPressed)
	{
		if (isPressed && this.isSelected && this.label != null && (UICamera.currentScheme == UICamera.ControlScheme.Mouse || UICamera.currentScheme == UICamera.ControlScheme.Touch))
		{
			this.selectionEnd = this.GetCharUnderMouse();
			if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
			{
				this.selectionStart = this.mSelectionEnd;
			}
		}
	}

	// Token: 0x0600075C RID: 1884 RVA: 0x0003F519 File Offset: 0x0003D719
	protected virtual void OnDrag(Vector2 delta)
	{
		if (this.label != null && (UICamera.currentScheme == UICamera.ControlScheme.Mouse || UICamera.currentScheme == UICamera.ControlScheme.Touch))
		{
			this.selectionEnd = this.GetCharUnderMouse();
		}
	}

	// Token: 0x0600075D RID: 1885 RVA: 0x0003F544 File Offset: 0x0003D744
	private void OnDisable()
	{
		this.Cleanup();
	}

	// Token: 0x0600075E RID: 1886 RVA: 0x0003F54C File Offset: 0x0003D74C
	protected virtual void Cleanup()
	{
		if (this.mHighlight)
		{
			this.mHighlight.enabled = false;
		}
		if (this.mCaret)
		{
			this.mCaret.enabled = false;
		}
		if (this.mBlankTex)
		{
			NGUITools.Destroy(this.mBlankTex);
			this.mBlankTex = null;
		}
	}

	// Token: 0x0600075F RID: 1887 RVA: 0x0003F5AC File Offset: 0x0003D7AC
	public void Submit()
	{
		if (NGUITools.GetActive(this))
		{
			this.mValue = this.value;
			if (UIInput.current == null)
			{
				UIInput.current = this;
				EventDelegate.Execute(this.onSubmit);
				UIInput.current = null;
			}
			this.SaveToPlayerPrefs(this.mValue);
		}
	}

	// Token: 0x06000760 RID: 1888 RVA: 0x0003F600 File Offset: 0x0003D800
	public void UpdateLabel()
	{
		if (this.label != null)
		{
			if (this.mDoInit)
			{
				this.Init();
			}
			bool isSelected = this.isSelected;
			string value = this.value;
			bool flag = string.IsNullOrEmpty(value) && string.IsNullOrEmpty(Input.compositionString);
			this.label.color = ((flag && !isSelected) ? this.mDefaultColor : this.activeTextColor);
			string text;
			if (flag)
			{
				text = (isSelected ? "" : this.mDefaultText);
				this.label.alignment = this.mAlignment;
			}
			else
			{
				if (this.inputType == UIInput.InputType.Password)
				{
					text = "";
					string str = "*";
					INGUIFont bitmapFont = this.label.bitmapFont;
					if (bitmapFont != null && bitmapFont.bmFont != null && bitmapFont.bmFont.GetGlyph(42) == null)
					{
						str = "x";
					}
					int i = 0;
					int length = value.Length;
					while (i < length)
					{
						text += str;
						i++;
					}
				}
				else
				{
					text = value;
				}
				int num = isSelected ? Mathf.Min(text.Length, this.cursorPosition) : 0;
				string str2 = text.Substring(0, num);
				if (isSelected)
				{
					str2 += Input.compositionString;
				}
				text = str2 + text.Substring(num, text.Length - num);
				if (isSelected && this.label.overflowMethod == UILabel.Overflow.ClampContent && this.label.maxLineCount == 1)
				{
					int num2 = this.label.CalculateOffsetToFit(text);
					if (num2 == 0)
					{
						UIInput.mDrawStart = 0;
						this.label.alignment = this.mAlignment;
					}
					else if (num < UIInput.mDrawStart)
					{
						UIInput.mDrawStart = num;
						this.label.alignment = NGUIText.Alignment.Left;
					}
					else if (num2 < UIInput.mDrawStart)
					{
						UIInput.mDrawStart = num2;
						this.label.alignment = NGUIText.Alignment.Left;
					}
					else
					{
						num2 = this.label.CalculateOffsetToFit(text.Substring(0, num));
						if (num2 > UIInput.mDrawStart)
						{
							UIInput.mDrawStart = num2;
							this.label.alignment = NGUIText.Alignment.Right;
						}
					}
					if (UIInput.mDrawStart != 0)
					{
						text = text.Substring(UIInput.mDrawStart, text.Length - UIInput.mDrawStart);
					}
				}
				else
				{
					UIInput.mDrawStart = 0;
					this.label.alignment = this.mAlignment;
				}
			}
			this.label.text = text;
			if (isSelected)
			{
				int num3 = this.mSelectionStart - UIInput.mDrawStart;
				int num4 = this.mSelectionEnd - UIInput.mDrawStart;
				if (this.mBlankTex == null)
				{
					this.mBlankTex = new Texture2D(2, 2, TextureFormat.ARGB32, false);
					for (int j = 0; j < 2; j++)
					{
						for (int k = 0; k < 2; k++)
						{
							this.mBlankTex.SetPixel(k, j, Color.white);
						}
					}
					this.mBlankTex.Apply();
				}
				if (num3 != num4)
				{
					if (this.mHighlight == null)
					{
						this.mHighlight = this.label.cachedGameObject.AddWidget(int.MaxValue);
						this.mHighlight.name = "Input Highlight";
						this.mHighlight.mainTexture = this.mBlankTex;
						this.mHighlight.fillGeometry = false;
						this.mHighlight.pivot = this.label.pivot;
						this.mHighlight.SetAnchor(this.label.cachedTransform);
					}
					else
					{
						this.mHighlight.pivot = this.label.pivot;
						this.mHighlight.mainTexture = this.mBlankTex;
						this.mHighlight.MarkAsChanged();
						this.mHighlight.enabled = true;
					}
				}
				if (this.mCaret == null)
				{
					this.mCaret = this.label.cachedGameObject.AddWidget(int.MaxValue);
					this.mCaret.name = "Input Caret";
					this.mCaret.mainTexture = this.mBlankTex;
					this.mCaret.fillGeometry = false;
					this.mCaret.pivot = this.label.pivot;
					this.mCaret.SetAnchor(this.label.cachedTransform);
				}
				else
				{
					this.mCaret.pivot = this.label.pivot;
					this.mCaret.mainTexture = this.mBlankTex;
					this.mCaret.MarkAsChanged();
					this.mCaret.enabled = true;
				}
				if (num3 != num4)
				{
					this.label.PrintOverlay(num3, num4, this.mCaret.geometry, this.mHighlight.geometry, this.caretColor, this.selectionColor);
					this.mHighlight.enabled = this.mHighlight.geometry.hasVertices;
				}
				else
				{
					this.label.PrintOverlay(num3, num4, this.mCaret.geometry, null, this.caretColor, this.selectionColor);
					if (this.mHighlight != null)
					{
						this.mHighlight.enabled = false;
					}
				}
				this.mNextBlink = RealTime.time + 0.5f;
				this.mLastAlpha = this.label.finalAlpha;
				return;
			}
			this.Cleanup();
		}
	}

	// Token: 0x06000761 RID: 1889 RVA: 0x0003FB24 File Offset: 0x0003DD24
	protected char Validate(string text, int pos, char ch)
	{
		if (this.validation == UIInput.Validation.None || !base.enabled)
		{
			return ch;
		}
		if (this.validation == UIInput.Validation.Integer)
		{
			if (ch >= '0' && ch <= '9')
			{
				return ch;
			}
			if (ch == '-' && pos == 0 && !text.Contains("-"))
			{
				return ch;
			}
		}
		else if (this.validation == UIInput.Validation.Float)
		{
			if (ch >= '0' && ch <= '9')
			{
				return ch;
			}
			if (ch == '-' && pos == 0 && !text.Contains("-"))
			{
				return ch;
			}
			if (ch == '.' && !text.Contains("."))
			{
				return ch;
			}
		}
		else if (this.validation == UIInput.Validation.Alphanumeric)
		{
			if (ch >= 'A' && ch <= 'Z')
			{
				return ch;
			}
			if (ch >= 'a' && ch <= 'z')
			{
				return ch;
			}
			if (ch >= '0' && ch <= '9')
			{
				return ch;
			}
		}
		else if (this.validation == UIInput.Validation.Username)
		{
			if (ch >= 'A' && ch <= 'Z')
			{
				return ch - 'A' + 'a';
			}
			if (ch >= 'a' && ch <= 'z')
			{
				return ch;
			}
			if (ch >= '0' && ch <= '9')
			{
				return ch;
			}
		}
		else if (this.validation == UIInput.Validation.Filename)
		{
			if (ch == ':')
			{
				return '\0';
			}
			if (ch == '/')
			{
				return '\0';
			}
			if (ch == '\\')
			{
				return '\0';
			}
			if (ch == '<')
			{
				return '\0';
			}
			if (ch == '>')
			{
				return '\0';
			}
			if (ch == '|')
			{
				return '\0';
			}
			if (ch == '^')
			{
				return '\0';
			}
			if (ch == '*')
			{
				return '\0';
			}
			if (ch == ';')
			{
				return '\0';
			}
			if (ch == '"')
			{
				return '\0';
			}
			if (ch == '`')
			{
				return '\0';
			}
			if (ch == '\t')
			{
				return '\0';
			}
			if (ch == '\n')
			{
				return '\0';
			}
			return ch;
		}
		else if (this.validation == UIInput.Validation.Name)
		{
			char c = (text.Length > 0) ? text[Mathf.Clamp(pos, 0, text.Length - 1)] : ' ';
			char c2 = (text.Length > 0) ? text[Mathf.Clamp(pos + 1, 0, text.Length - 1)] : '\n';
			if (ch >= 'a' && ch <= 'z')
			{
				if (c == ' ')
				{
					return ch - 'a' + 'A';
				}
				return ch;
			}
			else if (ch >= 'A' && ch <= 'Z')
			{
				if (c != ' ' && c != '\'')
				{
					return ch - 'A' + 'a';
				}
				return ch;
			}
			else if (ch == '\'')
			{
				if (c != ' ' && c != '\'' && c2 != '\'' && !text.Contains("'"))
				{
					return ch;
				}
			}
			else if (ch == ' ' && c != ' ' && c != '\'' && c2 != ' ' && c2 != '\'')
			{
				return ch;
			}
		}
		return '\0';
	}

	// Token: 0x06000762 RID: 1890 RVA: 0x0003FD5D File Offset: 0x0003DF5D
	protected void ExecuteOnChange()
	{
		if (UIInput.current == null && EventDelegate.IsValid(this.onChange))
		{
			UIInput.current = this;
			EventDelegate.Execute(this.onChange);
			UIInput.current = null;
		}
	}

	// Token: 0x06000763 RID: 1891 RVA: 0x0003FD90 File Offset: 0x0003DF90
	public void RemoveFocus()
	{
		this.isSelected = false;
	}

	// Token: 0x06000764 RID: 1892 RVA: 0x0003FD99 File Offset: 0x0003DF99
	public void SaveValue()
	{
		this.SaveToPlayerPrefs(this.mValue);
	}

	// Token: 0x06000765 RID: 1893 RVA: 0x0003FDA8 File Offset: 0x0003DFA8
	public void LoadValue()
	{
		if (!string.IsNullOrEmpty(this.savedAs))
		{
			string text = this.mValue.Replace("\\n", "\n");
			this.mValue = "";
			this.value = (PlayerPrefs.HasKey(this.savedAs) ? PlayerPrefs.GetString(this.savedAs) : text);
		}
	}

	// Token: 0x040006B5 RID: 1717
	public static UIInput current;

	// Token: 0x040006B6 RID: 1718
	public static UIInput selection;

	// Token: 0x040006B7 RID: 1719
	public UILabel label;

	// Token: 0x040006B8 RID: 1720
	public UIInput.InputType inputType;

	// Token: 0x040006B9 RID: 1721
	public UIInput.OnReturnKey onReturnKey;

	// Token: 0x040006BA RID: 1722
	public UIInput.KeyboardType keyboardType;

	// Token: 0x040006BB RID: 1723
	public bool hideInput;

	// Token: 0x040006BC RID: 1724
	[NonSerialized]
	public bool selectAllTextOnFocus = true;

	// Token: 0x040006BD RID: 1725
	public bool submitOnUnselect;

	// Token: 0x040006BE RID: 1726
	public UIInput.Validation validation;

	// Token: 0x040006BF RID: 1727
	public int characterLimit;

	// Token: 0x040006C0 RID: 1728
	public string savedAs;

	// Token: 0x040006C1 RID: 1729
	[HideInInspector]
	[SerializeField]
	private GameObject selectOnTab;

	// Token: 0x040006C2 RID: 1730
	public Color activeTextColor = Color.white;

	// Token: 0x040006C3 RID: 1731
	public Color caretColor = new Color(1f, 1f, 1f, 0.8f);

	// Token: 0x040006C4 RID: 1732
	public Color selectionColor = new Color(1f, 0.8745098f, 0.5529412f, 0.5f);

	// Token: 0x040006C5 RID: 1733
	public List<EventDelegate> onSubmit = new List<EventDelegate>();

	// Token: 0x040006C6 RID: 1734
	public List<EventDelegate> onChange = new List<EventDelegate>();

	// Token: 0x040006C7 RID: 1735
	public UIInput.OnValidate onValidate;

	// Token: 0x040006C8 RID: 1736
	[SerializeField]
	[HideInInspector]
	protected string mValue;

	// Token: 0x040006C9 RID: 1737
	[NonSerialized]
	protected string mDefaultText = "";

	// Token: 0x040006CA RID: 1738
	[NonSerialized]
	protected Color mDefaultColor = Color.white;

	// Token: 0x040006CB RID: 1739
	[NonSerialized]
	protected float mPosition;

	// Token: 0x040006CC RID: 1740
	[NonSerialized]
	protected bool mDoInit = true;

	// Token: 0x040006CD RID: 1741
	[NonSerialized]
	protected NGUIText.Alignment mAlignment = NGUIText.Alignment.Left;

	// Token: 0x040006CE RID: 1742
	[NonSerialized]
	protected bool mLoadSavedValue = true;

	// Token: 0x040006CF RID: 1743
	protected static int mDrawStart = 0;

	// Token: 0x040006D0 RID: 1744
	protected static string mLastIME = "";

	// Token: 0x040006D1 RID: 1745
	[NonSerialized]
	protected int mSelectionStart;

	// Token: 0x040006D2 RID: 1746
	[NonSerialized]
	protected int mSelectionEnd;

	// Token: 0x040006D3 RID: 1747
	[NonSerialized]
	protected UITexture mHighlight;

	// Token: 0x040006D4 RID: 1748
	[NonSerialized]
	protected UITexture mCaret;

	// Token: 0x040006D5 RID: 1749
	[NonSerialized]
	protected Texture2D mBlankTex;

	// Token: 0x040006D6 RID: 1750
	[NonSerialized]
	protected float mNextBlink;

	// Token: 0x040006D7 RID: 1751
	[NonSerialized]
	protected float mLastAlpha;

	// Token: 0x040006D8 RID: 1752
	[NonSerialized]
	protected string mCached = "";

	// Token: 0x040006D9 RID: 1753
	[NonSerialized]
	protected int mSelectMe = -1;

	// Token: 0x040006DA RID: 1754
	[NonSerialized]
	protected int mSelectTime = -1;

	// Token: 0x040006DB RID: 1755
	[NonSerialized]
	protected bool mStarted;

	// Token: 0x040006DC RID: 1756
	[NonSerialized]
	private UIInputOnGUI mOnGUI;

	// Token: 0x040006DD RID: 1757
	[NonSerialized]
	private UICamera mCam;

	// Token: 0x040006DE RID: 1758
	[NonSerialized]
	private bool mEllipsis;

	// Token: 0x040006DF RID: 1759
	private static int mIgnoreKey = 0;

	// Token: 0x040006E0 RID: 1760
	[NonSerialized]
	public Action onUpArrow;

	// Token: 0x040006E1 RID: 1761
	[NonSerialized]
	public Action onDownArrow;

	// Token: 0x0200062B RID: 1579
	[DoNotObfuscateNGUI]
	public enum InputType
	{
		// Token: 0x04004DE8 RID: 19944
		Standard,
		// Token: 0x04004DE9 RID: 19945
		AutoCorrect,
		// Token: 0x04004DEA RID: 19946
		Password
	}

	// Token: 0x0200062C RID: 1580
	[DoNotObfuscateNGUI]
	public enum Validation
	{
		// Token: 0x04004DEC RID: 19948
		None,
		// Token: 0x04004DED RID: 19949
		Integer,
		// Token: 0x04004DEE RID: 19950
		Float,
		// Token: 0x04004DEF RID: 19951
		Alphanumeric,
		// Token: 0x04004DF0 RID: 19952
		Username,
		// Token: 0x04004DF1 RID: 19953
		Name,
		// Token: 0x04004DF2 RID: 19954
		Filename
	}

	// Token: 0x0200062D RID: 1581
	[DoNotObfuscateNGUI]
	public enum KeyboardType
	{
		// Token: 0x04004DF4 RID: 19956
		Default,
		// Token: 0x04004DF5 RID: 19957
		ASCIICapable,
		// Token: 0x04004DF6 RID: 19958
		NumbersAndPunctuation,
		// Token: 0x04004DF7 RID: 19959
		URL,
		// Token: 0x04004DF8 RID: 19960
		NumberPad,
		// Token: 0x04004DF9 RID: 19961
		PhonePad,
		// Token: 0x04004DFA RID: 19962
		NamePhonePad,
		// Token: 0x04004DFB RID: 19963
		EmailAddress
	}

	// Token: 0x0200062E RID: 1582
	[DoNotObfuscateNGUI]
	public enum OnReturnKey
	{
		// Token: 0x04004DFD RID: 19965
		Default,
		// Token: 0x04004DFE RID: 19966
		Submit,
		// Token: 0x04004DFF RID: 19967
		NewLine
	}

	// Token: 0x0200062F RID: 1583
	// (Invoke) Token: 0x060025D1 RID: 9681
	public delegate char OnValidate(string text, int charIndex, char addedChar);
}
