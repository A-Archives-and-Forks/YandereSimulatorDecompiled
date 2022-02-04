﻿using System;
using UnityEngine;

// Token: 0x02000271 RID: 625
public class DayNightController : MonoBehaviour
{
	// Token: 0x06001343 RID: 4931 RVA: 0x000ADFC0 File Offset: 0x000AC1C0
	private void Initialize()
	{
		this.quarterDay = this.dayCycleLength * 0.25f;
		this.dawnTime = 0f;
		this.dayTime = this.dawnTime + this.quarterDay;
		this.duskTime = this.dayTime + this.quarterDay;
		this.nightTime = this.duskTime + this.quarterDay;
		Light component = base.GetComponent<Light>();
		if (component != null)
		{
			this.lightIntensity = component.intensity;
		}
	}

	// Token: 0x06001344 RID: 4932 RVA: 0x000AE040 File Offset: 0x000AC240
	private void Reset()
	{
		this.dayCycleLength = 120f;
		this.hoursPerDay = 24f;
		this.dawnTimeOffset = 3f;
		this.fullDark = new Color(0.1254902f, 0.10980392f, 0.18039216f);
		this.fullLight = new Color(0.99215686f, 0.972549f, 0.8745098f);
		this.dawnDuskFog = new Color(0.52156866f, 0.4862745f, 0.4f);
		this.dayFog = new Color(0.7058824f, 0.8156863f, 0.81960785f);
		this.nightFog = new Color(0.047058824f, 0.05882353f, 0.35686275f);
		foreach (Skybox skybox in Resources.FindObjectsOfTypeAll<Skybox>())
		{
			if (skybox.name == "DawnDusk Skybox")
			{
				this.dawnDuskSkybox = skybox.material;
			}
			else if (skybox.name == "StarryNight Skybox")
			{
				this.nightSkybox = skybox.material;
			}
			else if (skybox.name == "Sunny2 Skybox")
			{
				this.daySkybox = skybox.material;
			}
		}
	}

	// Token: 0x06001345 RID: 4933 RVA: 0x000AE166 File Offset: 0x000AC366
	private void Start()
	{
		this.Initialize();
	}

	// Token: 0x06001346 RID: 4934 RVA: 0x000AE170 File Offset: 0x000AC370
	private void Update()
	{
		if (this.currentCycleTime > this.nightTime && this.currentPhase == DayNightController.DayPhase.Dusk)
		{
			this.SetNight();
		}
		else if (this.currentCycleTime > this.duskTime && this.currentPhase == DayNightController.DayPhase.Day)
		{
			this.SetDusk();
		}
		else if (this.currentCycleTime > this.dayTime && this.currentPhase == DayNightController.DayPhase.Dawn)
		{
			this.SetDay();
		}
		else if (this.currentCycleTime > this.dawnTime && this.currentCycleTime < this.dayTime && this.currentPhase == DayNightController.DayPhase.Night)
		{
			this.SetDawn();
		}
		this.UpdateWorldTime();
		this.UpdateDaylight();
		this.UpdateFog();
		this.currentCycleTime += Time.deltaTime;
		this.currentCycleTime %= this.dayCycleLength;
	}

	// Token: 0x06001347 RID: 4935 RVA: 0x000AE23C File Offset: 0x000AC43C
	public void SetDawn()
	{
		RenderSettings.skybox = this.dawnDuskSkybox;
		Light component = base.GetComponent<Light>();
		if (component != null)
		{
			component.enabled = true;
		}
		this.currentPhase = DayNightController.DayPhase.Dawn;
	}

	// Token: 0x06001348 RID: 4936 RVA: 0x000AE274 File Offset: 0x000AC474
	public void SetDay()
	{
		RenderSettings.skybox = this.daySkybox;
		RenderSettings.ambientLight = this.fullLight;
		Light component = base.GetComponent<Light>();
		if (component != null)
		{
			component.intensity = this.lightIntensity;
		}
		this.currentPhase = DayNightController.DayPhase.Day;
	}

	// Token: 0x06001349 RID: 4937 RVA: 0x000AE2BA File Offset: 0x000AC4BA
	public void SetDusk()
	{
		RenderSettings.skybox = this.dawnDuskSkybox;
		this.currentPhase = DayNightController.DayPhase.Dusk;
	}

	// Token: 0x0600134A RID: 4938 RVA: 0x000AE2D0 File Offset: 0x000AC4D0
	public void SetNight()
	{
		RenderSettings.skybox = this.nightSkybox;
		RenderSettings.ambientLight = this.fullDark;
		Light component = base.GetComponent<Light>();
		if (component != null)
		{
			component.enabled = false;
		}
		this.currentPhase = DayNightController.DayPhase.Night;
	}

	// Token: 0x0600134B RID: 4939 RVA: 0x000AE314 File Offset: 0x000AC514
	private void UpdateDaylight()
	{
		if (this.currentPhase == DayNightController.DayPhase.Dawn)
		{
			float num = this.currentCycleTime - this.dawnTime;
			RenderSettings.ambientLight = Color.Lerp(this.fullDark, this.fullLight, num / this.quarterDay);
			Light component = base.GetComponent<Light>();
			if (component != null)
			{
				component.intensity = this.lightIntensity * (num / this.quarterDay);
			}
		}
		else if (this.currentPhase == DayNightController.DayPhase.Dusk)
		{
			float num2 = this.currentCycleTime - this.duskTime;
			RenderSettings.ambientLight = Color.Lerp(this.fullLight, this.fullDark, num2 / this.quarterDay);
			Light component2 = base.GetComponent<Light>();
			if (component2 != null)
			{
				component2.intensity = this.lightIntensity * ((this.quarterDay - num2) / this.quarterDay);
			}
		}
		base.transform.Rotate(Vector3.up * (Time.deltaTime / this.dayCycleLength * 360f), Space.Self);
	}

	// Token: 0x0600134C RID: 4940 RVA: 0x000AE408 File Offset: 0x000AC608
	private void UpdateFog()
	{
		if (this.currentPhase == DayNightController.DayPhase.Dawn)
		{
			float num = this.currentCycleTime - this.dawnTime;
			RenderSettings.fogColor = Color.Lerp(this.dawnDuskFog, this.dayFog, num / this.quarterDay);
			return;
		}
		if (this.currentPhase == DayNightController.DayPhase.Day)
		{
			float num2 = this.currentCycleTime - this.dayTime;
			RenderSettings.fogColor = Color.Lerp(this.dayFog, this.dawnDuskFog, num2 / this.quarterDay);
			return;
		}
		if (this.currentPhase == DayNightController.DayPhase.Dusk)
		{
			float num3 = this.currentCycleTime - this.duskTime;
			RenderSettings.fogColor = Color.Lerp(this.dawnDuskFog, this.nightFog, num3 / this.quarterDay);
			return;
		}
		if (this.currentPhase == DayNightController.DayPhase.Night)
		{
			float num4 = this.currentCycleTime - this.nightTime;
			RenderSettings.fogColor = Color.Lerp(this.nightFog, this.dawnDuskFog, num4 / this.quarterDay);
		}
	}

	// Token: 0x0600134D RID: 4941 RVA: 0x000AE4EB File Offset: 0x000AC6EB
	private void UpdateWorldTime()
	{
		this.worldTimeHour = (int)((Mathf.Ceil(this.currentCycleTime / this.dayCycleLength * this.hoursPerDay) + this.dawnTimeOffset) % this.hoursPerDay) + 1;
	}

	// Token: 0x04001BEB RID: 7147
	public float dayCycleLength;

	// Token: 0x04001BEC RID: 7148
	public float currentCycleTime;

	// Token: 0x04001BED RID: 7149
	public DayNightController.DayPhase currentPhase;

	// Token: 0x04001BEE RID: 7150
	public float hoursPerDay;

	// Token: 0x04001BEF RID: 7151
	public float dawnTimeOffset;

	// Token: 0x04001BF0 RID: 7152
	public int worldTimeHour;

	// Token: 0x04001BF1 RID: 7153
	public Color fullLight;

	// Token: 0x04001BF2 RID: 7154
	public Color fullDark;

	// Token: 0x04001BF3 RID: 7155
	public Material dawnDuskSkybox;

	// Token: 0x04001BF4 RID: 7156
	public Color dawnDuskFog;

	// Token: 0x04001BF5 RID: 7157
	public Material daySkybox;

	// Token: 0x04001BF6 RID: 7158
	public Color dayFog;

	// Token: 0x04001BF7 RID: 7159
	public Material nightSkybox;

	// Token: 0x04001BF8 RID: 7160
	public Color nightFog;

	// Token: 0x04001BF9 RID: 7161
	private float dawnTime;

	// Token: 0x04001BFA RID: 7162
	private float dayTime;

	// Token: 0x04001BFB RID: 7163
	private float duskTime;

	// Token: 0x04001BFC RID: 7164
	private float nightTime;

	// Token: 0x04001BFD RID: 7165
	private float quarterDay;

	// Token: 0x04001BFE RID: 7166
	private float lightIntensity;

	// Token: 0x0200064F RID: 1615
	public enum DayPhase
	{
		// Token: 0x04004EF0 RID: 20208
		Night,
		// Token: 0x04004EF1 RID: 20209
		Dawn,
		// Token: 0x04004EF2 RID: 20210
		Day,
		// Token: 0x04004EF3 RID: 20211
		Dusk
	}
}
