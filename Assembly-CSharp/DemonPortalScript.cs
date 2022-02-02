﻿using System;
using UnityEngine;

// Token: 0x0200027C RID: 636
public class DemonPortalScript : MonoBehaviour
{
	// Token: 0x06001375 RID: 4981 RVA: 0x000B2B30 File Offset: 0x000B0D30
	private void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Yandere.Character.GetComponent<Animation>().CrossFade(this.Yandere.IdleAnim);
			this.Yandere.CanMove = false;
			UnityEngine.Object.Instantiate<GameObject>(this.DarkAura, this.Yandere.transform.position + Vector3.up * 0.81f, Quaternion.identity);
			this.Timer += Time.deltaTime;
		}
		this.DemonRealmAudio.volume = Mathf.MoveTowards(this.DemonRealmAudio.volume, (this.Yandere.transform.position.y > 1000f) ? 0.5f : 0f, Time.deltaTime * 0.1f);
		if (this.Timer > 0f)
		{
			if (this.Yandere.transform.position.y > 1000f)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 4f)
				{
					this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 1f, Time.deltaTime));
					if (this.Darkness.color.a == 1f)
					{
						this.Yandere.transform.position = new Vector3(12f, 0f, 28f);
						this.Yandere.Character.SetActive(true);
						this.Yandere.SetAnimationLayers();
						this.HeartbeatCamera.SetActive(true);
						this.FPS.SetActive(true);
						this.HUD.SetActive(true);
						return;
					}
				}
				else if (this.Timer > 1f)
				{
					this.Yandere.Character.SetActive(false);
					return;
				}
			}
			else
			{
				this.Jukebox.Volume = Mathf.MoveTowards(this.Jukebox.Volume, 0.5f, Time.deltaTime * 0.5f);
				if (this.Jukebox.Volume == 0.5f)
				{
					this.Darkness.color = new Color(this.Darkness.color.r, this.Darkness.color.g, this.Darkness.color.b, Mathf.MoveTowards(this.Darkness.color.a, 0f, Time.deltaTime));
					if (this.Darkness.color.a == 0f)
					{
						base.transform.parent.gameObject.SetActive(false);
						this.Darkness.enabled = false;
						this.Yandere.CanMove = true;
						this.Clock.StopTime = false;
						this.Timer = 0f;
					}
				}
			}
		}
	}

	// Token: 0x04001C9C RID: 7324
	public YandereScript Yandere;

	// Token: 0x04001C9D RID: 7325
	public JukeboxScript Jukebox;

	// Token: 0x04001C9E RID: 7326
	public PromptScript Prompt;

	// Token: 0x04001C9F RID: 7327
	public ClockScript Clock;

	// Token: 0x04001CA0 RID: 7328
	public AudioSource DemonRealmAudio;

	// Token: 0x04001CA1 RID: 7329
	public GameObject HeartbeatCamera;

	// Token: 0x04001CA2 RID: 7330
	public GameObject DarkAura;

	// Token: 0x04001CA3 RID: 7331
	public GameObject FPS;

	// Token: 0x04001CA4 RID: 7332
	public GameObject HUD;

	// Token: 0x04001CA5 RID: 7333
	public UISprite Darkness;

	// Token: 0x04001CA6 RID: 7334
	public float Timer;
}
