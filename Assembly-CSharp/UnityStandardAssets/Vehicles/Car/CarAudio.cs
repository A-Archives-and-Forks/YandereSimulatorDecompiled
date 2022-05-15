﻿using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000530 RID: 1328
	[RequireComponent(typeof(CarController))]
	public class CarAudio : MonoBehaviour
	{
		// Token: 0x060021D1 RID: 8657 RVA: 0x001F34CC File Offset: 0x001F16CC
		private void StartSound()
		{
			this.m_CarController = base.GetComponent<CarController>();
			this.m_HighAccel = this.SetUpEngineAudioSource(this.highAccelClip);
			if (this.engineSoundStyle == CarAudio.EngineAudioOptions.FourChannel)
			{
				this.m_LowAccel = this.SetUpEngineAudioSource(this.lowAccelClip);
				this.m_LowDecel = this.SetUpEngineAudioSource(this.lowDecelClip);
				this.m_HighDecel = this.SetUpEngineAudioSource(this.highDecelClip);
			}
			this.m_StartedSound = true;
		}

		// Token: 0x060021D2 RID: 8658 RVA: 0x001F3540 File Offset: 0x001F1740
		private void StopSound()
		{
			AudioSource[] components = base.GetComponents<AudioSource>();
			for (int i = 0; i < components.Length; i++)
			{
				UnityEngine.Object.Destroy(components[i]);
			}
			this.m_StartedSound = false;
		}

		// Token: 0x060021D3 RID: 8659 RVA: 0x001F3574 File Offset: 0x001F1774
		private void Update()
		{
			float sqrMagnitude = (Camera.main.transform.position - base.transform.position).sqrMagnitude;
			if (this.m_StartedSound && sqrMagnitude > this.maxRolloffDistance * this.maxRolloffDistance)
			{
				this.StopSound();
			}
			if (!this.m_StartedSound && sqrMagnitude < this.maxRolloffDistance * this.maxRolloffDistance)
			{
				this.StartSound();
			}
			if (this.m_StartedSound)
			{
				float num = CarAudio.ULerp(this.lowPitchMin, this.lowPitchMax, this.m_CarController.Revs);
				num = Mathf.Min(this.lowPitchMax, num);
				if (this.engineSoundStyle == CarAudio.EngineAudioOptions.Simple)
				{
					this.m_HighAccel.pitch = num * this.pitchMultiplier * this.highPitchMultiplier;
					this.m_HighAccel.dopplerLevel = (this.useDoppler ? this.dopplerLevel : 0f);
					this.m_HighAccel.volume = 1f;
					return;
				}
				this.m_LowAccel.pitch = num * this.pitchMultiplier;
				this.m_LowDecel.pitch = num * this.pitchMultiplier;
				this.m_HighAccel.pitch = num * this.highPitchMultiplier * this.pitchMultiplier;
				this.m_HighDecel.pitch = num * this.highPitchMultiplier * this.pitchMultiplier;
				float num2 = Mathf.Abs(this.m_CarController.AccelInput);
				float num3 = 1f - num2;
				float num4 = Mathf.InverseLerp(0.2f, 0.8f, this.m_CarController.Revs);
				float num5 = 1f - num4;
				num4 = 1f - (1f - num4) * (1f - num4);
				num5 = 1f - (1f - num5) * (1f - num5);
				num2 = 1f - (1f - num2) * (1f - num2);
				num3 = 1f - (1f - num3) * (1f - num3);
				this.m_LowAccel.volume = num5 * num2;
				this.m_LowDecel.volume = num5 * num3;
				this.m_HighAccel.volume = num4 * num2;
				this.m_HighDecel.volume = num4 * num3;
				this.m_HighAccel.dopplerLevel = (this.useDoppler ? this.dopplerLevel : 0f);
				this.m_LowAccel.dopplerLevel = (this.useDoppler ? this.dopplerLevel : 0f);
				this.m_HighDecel.dopplerLevel = (this.useDoppler ? this.dopplerLevel : 0f);
				this.m_LowDecel.dopplerLevel = (this.useDoppler ? this.dopplerLevel : 0f);
			}
		}

		// Token: 0x060021D4 RID: 8660 RVA: 0x001F3828 File Offset: 0x001F1A28
		private AudioSource SetUpEngineAudioSource(AudioClip clip)
		{
			AudioSource audioSource = base.gameObject.AddComponent<AudioSource>();
			audioSource.clip = clip;
			audioSource.volume = 0f;
			audioSource.loop = true;
			audioSource.time = UnityEngine.Random.Range(0f, clip.length);
			audioSource.Play();
			audioSource.minDistance = 5f;
			audioSource.maxDistance = this.maxRolloffDistance;
			audioSource.dopplerLevel = 0f;
			return audioSource;
		}

		// Token: 0x060021D5 RID: 8661 RVA: 0x001F3897 File Offset: 0x001F1A97
		private static float ULerp(float from, float to, float value)
		{
			return (1f - value) * from + value * to;
		}

		// Token: 0x04004A87 RID: 19079
		public CarAudio.EngineAudioOptions engineSoundStyle = CarAudio.EngineAudioOptions.FourChannel;

		// Token: 0x04004A88 RID: 19080
		public AudioClip lowAccelClip;

		// Token: 0x04004A89 RID: 19081
		public AudioClip lowDecelClip;

		// Token: 0x04004A8A RID: 19082
		public AudioClip highAccelClip;

		// Token: 0x04004A8B RID: 19083
		public AudioClip highDecelClip;

		// Token: 0x04004A8C RID: 19084
		public float pitchMultiplier = 1f;

		// Token: 0x04004A8D RID: 19085
		public float lowPitchMin = 1f;

		// Token: 0x04004A8E RID: 19086
		public float lowPitchMax = 6f;

		// Token: 0x04004A8F RID: 19087
		public float highPitchMultiplier = 0.25f;

		// Token: 0x04004A90 RID: 19088
		public float maxRolloffDistance = 500f;

		// Token: 0x04004A91 RID: 19089
		public float dopplerLevel = 1f;

		// Token: 0x04004A92 RID: 19090
		public bool useDoppler = true;

		// Token: 0x04004A93 RID: 19091
		private AudioSource m_LowAccel;

		// Token: 0x04004A94 RID: 19092
		private AudioSource m_LowDecel;

		// Token: 0x04004A95 RID: 19093
		private AudioSource m_HighAccel;

		// Token: 0x04004A96 RID: 19094
		private AudioSource m_HighDecel;

		// Token: 0x04004A97 RID: 19095
		private bool m_StartedSound;

		// Token: 0x04004A98 RID: 19096
		private CarController m_CarController;

		// Token: 0x0200068D RID: 1677
		public enum EngineAudioOptions
		{
			// Token: 0x040050E1 RID: 20705
			Simple,
			// Token: 0x040050E2 RID: 20706
			FourChannel
		}
	}
}
