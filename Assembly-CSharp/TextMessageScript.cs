﻿using System;
using UnityEngine;

// Token: 0x0200039B RID: 923
public class TextMessageScript : MonoBehaviour
{
	// Token: 0x06001A64 RID: 6756 RVA: 0x0011AC8C File Offset: 0x00118E8C
	private void Start()
	{
		if (!this.Attachment && this.Image != null)
		{
			this.Image.SetActive(false);
		}
		if (this.Right && EventGlobals.OsanaConversation)
		{
			base.gameObject.GetComponent<UISprite>().color = new Color(1f, 0.5f, 0f);
			this.Label.color = new Color(1f, 1f, 1f);
		}
	}

	// Token: 0x06001A65 RID: 6757 RVA: 0x0011AD0D File Offset: 0x00118F0D
	private void Update()
	{
		base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
	}

	// Token: 0x04002B9F RID: 11167
	public UILabel Label;

	// Token: 0x04002BA0 RID: 11168
	public GameObject Image;

	// Token: 0x04002BA1 RID: 11169
	public bool Attachment;

	// Token: 0x04002BA2 RID: 11170
	public bool Right;
}
