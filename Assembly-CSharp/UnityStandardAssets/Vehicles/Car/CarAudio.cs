﻿using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000528 RID: 1320
	[RequireComponent(typeof(CarController))]
	public class CarAudio : MonoBehaviour
	{
		// Token: 0x0600219E RID: 8606 RVA: 0x001EE0F8 File Offset: 0x001EC2F8
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

		// Token: 0x0600219F RID: 8607 RVA: 0x001EE16C File Offset: 0x001EC36C
		private void StopSound()
		{
			AudioSource[] components = base.GetComponents<AudioSource>();
			for (int i = 0; i < components.Length; i++)
			{
				UnityEngine.Object.Destroy(components[i]);
			}
			this.m_StartedSound = false;
		}

		// Token: 0x060021A0 RID: 8608 RVA: 0x001EE1A0 File Offset: 0x001EC3A0
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

		// Token: 0x060021A1 RID: 8609 RVA: 0x001EE454 File Offset: 0x001EC654
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

		// Token: 0x060021A2 RID: 8610 RVA: 0x001EE4C3 File Offset: 0x001EC6C3
		private static float ULerp(float from, float to, float value)
		{
			return (1f - value) * from + value * to;
		}

		// Token: 0x04004A02 RID: 18946
		public CarAudio.EngineAudioOptions engineSoundStyle = CarAudio.EngineAudioOptions.FourChannel;

		// Token: 0x04004A03 RID: 18947
		public AudioClip lowAccelClip;

		// Token: 0x04004A04 RID: 18948
		public AudioClip lowDecelClip;

		// Token: 0x04004A05 RID: 18949
		public AudioClip highAccelClip;

		// Token: 0x04004A06 RID: 18950
		public AudioClip highDecelClip;

		// Token: 0x04004A07 RID: 18951
		public float pitchMultiplier = 1f;

		// Token: 0x04004A08 RID: 18952
		public float lowPitchMin = 1f;

		// Token: 0x04004A09 RID: 18953
		public float lowPitchMax = 6f;

		// Token: 0x04004A0A RID: 18954
		public float highPitchMultiplier = 0.25f;

		// Token: 0x04004A0B RID: 18955
		public float maxRolloffDistance = 500f;

		// Token: 0x04004A0C RID: 18956
		public float dopplerLevel = 1f;

		// Token: 0x04004A0D RID: 18957
		public bool useDoppler = true;

		// Token: 0x04004A0E RID: 18958
		private AudioSource m_LowAccel;

		// Token: 0x04004A0F RID: 18959
		private AudioSource m_LowDecel;

		// Token: 0x04004A10 RID: 18960
		private AudioSource m_HighAccel;

		// Token: 0x04004A11 RID: 18961
		private AudioSource m_HighDecel;

		// Token: 0x04004A12 RID: 18962
		private bool m_StartedSound;

		// Token: 0x04004A13 RID: 18963
		private CarController m_CarController;

		// Token: 0x02000685 RID: 1669
		public enum EngineAudioOptions
		{
			// Token: 0x04005054 RID: 20564
			Simple,
			// Token: 0x04005055 RID: 20565
			FourChannel
		}
	}
}
