﻿using System;
using UnityEngine;
using UnityEngine.PostProcessing;
using XInputDotNetPure;

// Token: 0x02000234 RID: 564
public class CameraEffectsScript : MonoBehaviour
{
	// Token: 0x06001216 RID: 4630 RVA: 0x0008AA7C File Offset: 0x00088C7C
	private void Start()
	{
		this.MurderStreaks.color = new Color(this.MurderStreaks.color.r, this.MurderStreaks.color.g, this.MurderStreaks.color.b, 0f);
		this.Streaks.color = new Color(this.Streaks.color.r, this.Streaks.color.g, this.Streaks.color.b, 0f);
		this.Profile.colorGrading.enabled = false;
		this.SmartphoneCamera.depthTextureMode = DepthTextureMode.DepthNormals;
	}

	// Token: 0x06001217 RID: 4631 RVA: 0x0008AB30 File Offset: 0x00088D30
	private void Update()
	{
		if (this.VibrationCheck)
		{
			this.VibrationTimer = Mathf.MoveTowards(this.VibrationTimer, 0f, Time.deltaTime);
			if (this.VibrationTimer == 0f)
			{
				GamePad.SetVibration(PlayerIndex.One, 0f, 0f);
				this.VibrationCheck = false;
			}
		}
		if (this.Streaks.color.a > 0f)
		{
			this.Streaks.color = new Color(this.Streaks.color.r, this.Streaks.color.g, this.Streaks.color.b, this.Streaks.color.a - Time.deltaTime);
			this.UpdateBloom(1f + this.Streaks.color.a * 4f);
			if (this.Streaks.color.a <= 0f)
			{
				this.UpdateBloom(1f);
			}
		}
		if (this.MurderStreaks.color.a > 0f)
		{
			this.MurderStreaks.color = new Color(this.MurderStreaks.color.r, this.MurderStreaks.color.g, this.MurderStreaks.color.b, this.MurderStreaks.color.a - Time.deltaTime);
		}
		float num = 1f - this.Yandere.Sanity * 0.01f;
		if (this.EffectStrength != num)
		{
			this.EffectStrength = Mathf.MoveTowards(this.EffectStrength, num, Time.deltaTime * 10f);
			this.UpdateVignette(this.EffectStrength);
			this.UpdateChroma(this.EffectStrength);
		}
	}

	// Token: 0x06001218 RID: 4632 RVA: 0x0008ACFC File Offset: 0x00088EFC
	public void Alarm()
	{
		GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
		this.VibrationCheck = true;
		this.VibrationTimer = 0.1f;
		this.UpdateBloom(2f);
		this.Streaks.color = new Color(this.Streaks.color.r, this.Streaks.color.g, this.Streaks.color.b, 1f);
		AudioSource.PlayClipAtPoint(this.Noticed, this.Yandere.Head.position);
	}

	// Token: 0x06001219 RID: 4633 RVA: 0x0008AD98 File Offset: 0x00088F98
	public void MurderWitnessed()
	{
		GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
		this.VibrationCheck = true;
		this.VibrationTimer = 0.1f;
		this.MurderStreaks.color = new Color(this.MurderStreaks.color.r, this.MurderStreaks.color.g, this.MurderStreaks.color.b, 1f);
		this.Yandere.Jukebox.SFX.PlayOneShot(this.Yandere.Noticed ? this.SenpaiNoticed : this.MurderNoticed);
	}

	// Token: 0x0600121A RID: 4634 RVA: 0x0008AE3C File Offset: 0x0008903C
	public void DisableCamera()
	{
		if (!this.OneCamera)
		{
			this.OneCamera = true;
			return;
		}
		this.OneCamera = false;
	}

	// Token: 0x0600121B RID: 4635 RVA: 0x0008AE58 File Offset: 0x00089058
	public void UpdateBloom(float Bloom)
	{
		BloomModel.Settings settings = this.Profile.bloom.settings;
		settings.bloom.intensity = Bloom;
		this.Profile.bloom.settings = settings;
	}

	// Token: 0x0600121C RID: 4636 RVA: 0x0008AE94 File Offset: 0x00089094
	public void UpdateThreshold(float Threshold)
	{
		BloomModel.Settings settings = this.Profile.bloom.settings;
		settings.bloom.threshold = Threshold;
		this.Profile.bloom.settings = settings;
	}

	// Token: 0x0600121D RID: 4637 RVA: 0x0008AED0 File Offset: 0x000890D0
	public void UpdateBloomKnee(float Knee)
	{
		BloomModel.Settings settings = this.Profile.bloom.settings;
		settings.bloom.softKnee = Knee;
		this.Profile.bloom.settings = settings;
	}

	// Token: 0x0600121E RID: 4638 RVA: 0x0008AF0C File Offset: 0x0008910C
	public void UpdateBloomRadius(float Radius)
	{
		BloomModel.Settings settings = this.Profile.bloom.settings;
		settings.bloom.radius = Radius;
		this.Profile.bloom.settings = settings;
	}

	// Token: 0x0600121F RID: 4639 RVA: 0x0008AF48 File Offset: 0x00089148
	public void EnableBloom()
	{
		this.Profile.bloom.enabled = true;
	}

	// Token: 0x06001220 RID: 4640 RVA: 0x0008AF5C File Offset: 0x0008915C
	public void UpdateChroma(float Chroma)
	{
		ChromaticAberrationModel.Settings settings = this.Profile.chromaticAberration.settings;
		settings.intensity = Chroma;
		this.Profile.chromaticAberration.settings = settings;
	}

	// Token: 0x06001221 RID: 4641 RVA: 0x0008AF94 File Offset: 0x00089194
	public void UpdateVignette(float Vignette)
	{
		VignetteModel.Settings settings = this.Profile.vignette.settings;
		if (!this.Yandere.YandereVision)
		{
			settings.intensity = 0.5f - 0.25f * Vignette;
		}
		settings.color = new Color(1f - 1f * Vignette, 0.75f - 0.75f * Vignette, 1f - 1f * Vignette, 1f);
		this.Profile.vignette.settings = settings;
	}

	// Token: 0x06001222 RID: 4642 RVA: 0x0008B01C File Offset: 0x0008921C
	public void SetVignettePink()
	{
		VignetteModel.Settings settings = this.Profile.vignette.settings;
		settings.color = new Color(1f, 0.75f, 1f, 1f);
		this.Profile.vignette.settings = settings;
	}

	// Token: 0x06001223 RID: 4643 RVA: 0x0008B06C File Offset: 0x0008926C
	public void UpdateDOF(float Focus)
	{
		Focus *= ((float)Screen.width / 1280f + (float)Screen.height / 720f) * 0.5f;
		DepthOfFieldModel.Settings settings = this.Profile.depthOfField.settings;
		settings.focusDistance = Focus;
		this.Profile.depthOfField.settings = settings;
	}

	// Token: 0x040016C0 RID: 5824
	public PostProcessingProfile Profile;

	// Token: 0x040016C1 RID: 5825
	public YandereScript Yandere;

	// Token: 0x040016C2 RID: 5826
	public UITexture MurderStreaks;

	// Token: 0x040016C3 RID: 5827
	public UITexture Streaks;

	// Token: 0x040016C4 RID: 5828
	public float EffectStrength;

	// Token: 0x040016C5 RID: 5829
	public float VibrationTimer;

	// Token: 0x040016C6 RID: 5830
	public bool VibrationCheck;

	// Token: 0x040016C7 RID: 5831
	public bool OneCamera;

	// Token: 0x040016C8 RID: 5832
	public AudioClip MurderNoticed;

	// Token: 0x040016C9 RID: 5833
	public AudioClip SenpaiNoticed;

	// Token: 0x040016CA RID: 5834
	public AudioClip Noticed;

	// Token: 0x040016CB RID: 5835
	public Camera SmartphoneCamera;
}
