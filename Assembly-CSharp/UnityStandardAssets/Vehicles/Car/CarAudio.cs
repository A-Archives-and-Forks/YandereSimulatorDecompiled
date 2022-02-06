﻿using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Car
{
	// Token: 0x02000521 RID: 1313
	[RequireComponent(typeof(CarController))]
	public class CarAudio : MonoBehaviour
	{
		// Token: 0x06002170 RID: 8560 RVA: 0x001EA724 File Offset: 0x001E8924
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

		// Token: 0x06002171 RID: 8561 RVA: 0x001EA798 File Offset: 0x001E8998
		private void StopSound()
		{
			AudioSource[] components = base.GetComponents<AudioSource>();
			for (int i = 0; i < components.Length; i++)
			{
				UnityEngine.Object.Destroy(components[i]);
			}
			this.m_StartedSound = false;
		}

		// Token: 0x06002172 RID: 8562 RVA: 0x001EA7CC File Offset: 0x001E89CC
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

		// Token: 0x06002173 RID: 8563 RVA: 0x001EAA80 File Offset: 0x001E8C80
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

		// Token: 0x06002174 RID: 8564 RVA: 0x001EAAEF File Offset: 0x001E8CEF
		private static float ULerp(float from, float to, float value)
		{
			return (1f - value) * from + value * to;
		}

		// Token: 0x0400496D RID: 18797
		public CarAudio.EngineAudioOptions engineSoundStyle = CarAudio.EngineAudioOptions.FourChannel;

		// Token: 0x0400496E RID: 18798
		public AudioClip lowAccelClip;

		// Token: 0x0400496F RID: 18799
		public AudioClip lowDecelClip;

		// Token: 0x04004970 RID: 18800
		public AudioClip highAccelClip;

		// Token: 0x04004971 RID: 18801
		public AudioClip highDecelClip;

		// Token: 0x04004972 RID: 18802
		public float pitchMultiplier = 1f;

		// Token: 0x04004973 RID: 18803
		public float lowPitchMin = 1f;

		// Token: 0x04004974 RID: 18804
		public float lowPitchMax = 6f;

		// Token: 0x04004975 RID: 18805
		public float highPitchMultiplier = 0.25f;

		// Token: 0x04004976 RID: 18806
		public float maxRolloffDistance = 500f;

		// Token: 0x04004977 RID: 18807
		public float dopplerLevel = 1f;

		// Token: 0x04004978 RID: 18808
		public bool useDoppler = true;

		// Token: 0x04004979 RID: 18809
		private AudioSource m_LowAccel;

		// Token: 0x0400497A RID: 18810
		private AudioSource m_LowDecel;

		// Token: 0x0400497B RID: 18811
		private AudioSource m_HighAccel;

		// Token: 0x0400497C RID: 18812
		private AudioSource m_HighDecel;

		// Token: 0x0400497D RID: 18813
		private bool m_StartedSound;

		// Token: 0x0400497E RID: 18814
		private CarController m_CarController;

		// Token: 0x0200067C RID: 1660
		public enum EngineAudioOptions
		{
			// Token: 0x04004FBA RID: 20410
			Simple,
			// Token: 0x04004FBB RID: 20411
			FourChannel
		}
	}
}
