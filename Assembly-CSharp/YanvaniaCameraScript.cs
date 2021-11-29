﻿using System;
using UnityEngine;
using UnityEngine.PostProcessing;

// Token: 0x020004CD RID: 1229
public class YanvaniaCameraScript : MonoBehaviour
{
	// Token: 0x0600204B RID: 8267 RVA: 0x001D8684 File Offset: 0x001D6884
	private void Start()
	{
		DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
		settings.focusDistance = 2f;
		this.Profile.depthOfField.settings = settings;
		base.transform.position = this.Yanmont.transform.position + new Vector3(0f, 1.5f, -5.85f);
	}

	// Token: 0x0600204C RID: 8268 RVA: 0x001D86F4 File Offset: 0x001D68F4
	private void FixedUpdate()
	{
		this.TargetZoom += Input.GetAxis("Mouse ScrollWheel") * 10f;
		if (this.TargetZoom < 0f)
		{
			this.TargetZoom = 0f;
		}
		if (this.TargetZoom > 3.85f)
		{
			this.TargetZoom = 3.85f;
		}
		this.Zoom = Mathf.Lerp(this.Zoom, this.TargetZoom, Time.deltaTime);
		if (!this.Cutscene)
		{
			this.TargetZoom += Input.GetAxis("Mouse ScrollWheel") * 10f;
			base.transform.position = this.Yanmont.transform.position + new Vector3(0f, 1.5f, -5.85f + this.Zoom);
			if (base.transform.position.x > 47.9f)
			{
				base.transform.position = new Vector3(47.9f, base.transform.position.y, base.transform.position.z);
				return;
			}
		}
		else
		{
			if (this.StopMusic)
			{
				if (this.Yanmont.Dracula.Health > 0f)
				{
					this.TargetZoom = 3.85f;
				}
				AudioSource component = this.Jukebox.GetComponent<AudioSource>();
				component.volume -= Time.deltaTime * ((this.Yanmont.Health > 0f) ? 0.2f : 0.025f);
				if (component.volume <= 0f)
				{
					this.StopMusic = false;
				}
			}
			base.transform.position = new Vector3(Mathf.MoveTowards(base.transform.position.x, -34.675f, Time.deltaTime * this.Yanmont.walkSpeed), 8f, -5.85f + this.Zoom);
		}
	}

	// Token: 0x0400468E RID: 18062
	public PostProcessingProfile Profile;

	// Token: 0x0400468F RID: 18063
	public YanvaniaYanmontScript Yanmont;

	// Token: 0x04004690 RID: 18064
	public GameObject Jukebox;

	// Token: 0x04004691 RID: 18065
	public bool Cutscene;

	// Token: 0x04004692 RID: 18066
	public bool StopMusic = true;

	// Token: 0x04004693 RID: 18067
	public float TargetZoom;

	// Token: 0x04004694 RID: 18068
	public float Zoom;
}
