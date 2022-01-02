﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x02000377 RID: 887
public class NoAnimationWarningScript : MonoBehaviour
{
	// Token: 0x060019EF RID: 6639 RVA: 0x0010F3C6 File Offset: 0x0010D5C6
	private void Start()
	{
		this.Darkness.color = new Color(0f, 0f, 0f, 1f);
	}

	// Token: 0x060019F0 RID: 6640 RVA: 0x0010F3EC File Offset: 0x0010D5EC
	private void Update()
	{
		if (!this.FadeOut)
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 0f, Time.deltaTime);
			this.Darkness.color = new Color(0f, 0f, 0f, this.Alpha);
			if (this.Alpha == 0f && Input.GetButtonDown("A"))
			{
				this.FadeOut = true;
				return;
			}
		}
		else
		{
			this.Alpha = Mathf.MoveTowards(this.Alpha, 1f, Time.deltaTime);
			this.Darkness.color = new Color(0f, 0f, 0f, this.Alpha);
			if (this.Alpha == 1f)
			{
				SceneManager.LoadScene("BusStopScene");
			}
		}
	}

	// Token: 0x040029F2 RID: 10738
	public UISprite Darkness;

	// Token: 0x040029F3 RID: 10739
	public bool FadeOut;

	// Token: 0x040029F4 RID: 10740
	public float Alpha;
}
