﻿using System;
using UnityEngine;

// Token: 0x02000354 RID: 852
public class LightSwitchScript : MonoBehaviour
{
	// Token: 0x06001981 RID: 6529 RVA: 0x00100B8B File Offset: 0x000FED8B
	private void Start()
	{
		this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
	}

	// Token: 0x06001982 RID: 6530 RVA: 0x00100BA4 File Offset: 0x000FEDA4
	private void Update()
	{
		if (this.Flicker)
		{
			this.FlickerTimer += Time.deltaTime;
			if (this.FlickerTimer > 0.1f)
			{
				this.FlickerTimer = 0f;
				this.BathroomLight.SetActive(!this.BathroomLight.activeInHierarchy);
			}
		}
		if (!this.Panel.useGravity)
		{
			if (this.Yandere.Armed)
			{
				this.Prompt.HideButton[3] = (this.Yandere.EquippedWeapon.WeaponID != 6);
			}
			else
			{
				this.Prompt.HideButton[3] = true;
			}
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			AudioSource component = base.GetComponent<AudioSource>();
			if (this.BathroomLight.activeInHierarchy)
			{
				this.Prompt.Label[0].text = "     Turn On";
				this.BathroomLight.SetActive(false);
				component.clip = this.Flick[1];
				component.Play();
				if (this.ToiletEvent.EventActive && (this.ToiletEvent.EventPhase == 2 || this.ToiletEvent.EventPhase == 3))
				{
					this.ReactionID = UnityEngine.Random.Range(1, 4);
					AudioClipPlayer.Play(this.ReactionClips[this.ReactionID], this.ToiletEvent.EventStudent.transform.position, 5f, 10f, out this.ToiletEvent.VoiceClip);
					this.ToiletEvent.EventSubtitle.text = this.ReactionTexts[this.ReactionID];
					this.SubtitleTimer += Time.deltaTime;
				}
			}
			else
			{
				this.Prompt.Label[0].text = "     Turn Off";
				this.BathroomLight.SetActive(true);
				component.clip = this.Flick[0];
				component.Play();
			}
		}
		if (this.SubtitleTimer > 0f)
		{
			this.SubtitleTimer += Time.deltaTime;
			if (this.SubtitleTimer > 3f)
			{
				this.ToiletEvent.EventSubtitle.text = string.Empty;
				this.SubtitleTimer = 0f;
			}
		}
		if (this.Prompt.Circle[3].fillAmount == 0f)
		{
			this.Prompt.HideButton[3] = true;
			this.Wires.localScale = new Vector3(this.Wires.localScale.x, this.Wires.localScale.y, 1f);
			this.Panel.useGravity = true;
			this.Panel.AddForce(0f, 0f, 10f);
		}
	}

	// Token: 0x0400287D RID: 10365
	public ToiletEventScript ToiletEvent;

	// Token: 0x0400287E RID: 10366
	public YandereScript Yandere;

	// Token: 0x0400287F RID: 10367
	public PromptScript Prompt;

	// Token: 0x04002880 RID: 10368
	public Transform ElectrocutionSpot;

	// Token: 0x04002881 RID: 10369
	public GameObject BathroomLight;

	// Token: 0x04002882 RID: 10370
	public GameObject Electricity;

	// Token: 0x04002883 RID: 10371
	public Rigidbody Panel;

	// Token: 0x04002884 RID: 10372
	public Transform Wires;

	// Token: 0x04002885 RID: 10373
	public AudioClip[] ReactionClips;

	// Token: 0x04002886 RID: 10374
	public string[] ReactionTexts;

	// Token: 0x04002887 RID: 10375
	public AudioClip[] Flick;

	// Token: 0x04002888 RID: 10376
	public float SubtitleTimer;

	// Token: 0x04002889 RID: 10377
	public float FlickerTimer;

	// Token: 0x0400288A RID: 10378
	public int ReactionID;

	// Token: 0x0400288B RID: 10379
	public bool Flicker;
}
