﻿using System;
using UnityEngine;

// Token: 0x02000272 RID: 626
public class DayNightController : MonoBehaviour
{
	// Token: 0x0600134F RID: 4943 RVA: 0x000AEF24 File Offset: 0x000AD124
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

	// Token: 0x06001350 RID: 4944 RVA: 0x000AEFA4 File Offset: 0x000AD1A4
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

	// Token: 0x06001351 RID: 4945 RVA: 0x000AF0CA File Offset: 0x000AD2CA
	private void Start()
	{
		this.Initialize();
	}

	// Token: 0x06001352 RID: 4946 RVA: 0x000AF0D4 File Offset: 0x000AD2D4
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

	// Token: 0x06001353 RID: 4947 RVA: 0x000AF1A0 File Offset: 0x000AD3A0
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

	// Token: 0x06001354 RID: 4948 RVA: 0x000AF1D8 File Offset: 0x000AD3D8
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

	// Token: 0x06001355 RID: 4949 RVA: 0x000AF21E File Offset: 0x000AD41E
	public void SetDusk()
	{
		RenderSettings.skybox = this.dawnDuskSkybox;
		this.currentPhase = DayNightController.DayPhase.Dusk;
	}

	// Token: 0x06001356 RID: 4950 RVA: 0x000AF234 File Offset: 0x000AD434
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

	// Token: 0x06001357 RID: 4951 RVA: 0x000AF278 File Offset: 0x000AD478
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

	// Token: 0x06001358 RID: 4952 RVA: 0x000AF36C File Offset: 0x000AD56C
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

	// Token: 0x06001359 RID: 4953 RVA: 0x000AF44F File Offset: 0x000AD64F
	private void UpdateWorldTime()
	{
		this.worldTimeHour = (int)((Mathf.Ceil(this.currentCycleTime / this.dayCycleLength * this.hoursPerDay) + this.dawnTimeOffset) % this.hoursPerDay) + 1;
	}

	// Token: 0x04001C14 RID: 7188
	public float dayCycleLength;

	// Token: 0x04001C15 RID: 7189
	public float currentCycleTime;

	// Token: 0x04001C16 RID: 7190
	public DayNightController.DayPhase currentPhase;

	// Token: 0x04001C17 RID: 7191
	public float hoursPerDay;

	// Token: 0x04001C18 RID: 7192
	public float dawnTimeOffset;

	// Token: 0x04001C19 RID: 7193
	public int worldTimeHour;

	// Token: 0x04001C1A RID: 7194
	public Color fullLight;

	// Token: 0x04001C1B RID: 7195
	public Color fullDark;

	// Token: 0x04001C1C RID: 7196
	public Material dawnDuskSkybox;

	// Token: 0x04001C1D RID: 7197
	public Color dawnDuskFog;

	// Token: 0x04001C1E RID: 7198
	public Material daySkybox;

	// Token: 0x04001C1F RID: 7199
	public Color dayFog;

	// Token: 0x04001C20 RID: 7200
	public Material nightSkybox;

	// Token: 0x04001C21 RID: 7201
	public Color nightFog;

	// Token: 0x04001C22 RID: 7202
	private float dawnTime;

	// Token: 0x04001C23 RID: 7203
	private float dayTime;

	// Token: 0x04001C24 RID: 7204
	private float duskTime;

	// Token: 0x04001C25 RID: 7205
	private float nightTime;

	// Token: 0x04001C26 RID: 7206
	private float quarterDay;

	// Token: 0x04001C27 RID: 7207
	private float lightIntensity;

	// Token: 0x0200065D RID: 1629
	public enum DayPhase
	{
		// Token: 0x04004FEE RID: 20462
		Night,
		// Token: 0x04004FEF RID: 20463
		Dawn,
		// Token: 0x04004FF0 RID: 20464
		Day,
		// Token: 0x04004FF1 RID: 20465
		Dusk
	}
}
