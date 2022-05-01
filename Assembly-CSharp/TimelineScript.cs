﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200047C RID: 1148
public class TimelineScript : MonoBehaviour
{
	// Token: 0x06001EF2 RID: 7922 RVA: 0x001B5170 File Offset: 0x001B3370
	private void Start()
	{
		base.transform.localPosition = new Vector3(0f, -0.6f, 1f);
		this.MaxHeight = base.transform.localPosition.y;
		this.Darkness.alpha = 0f;
		this.SpawnYear(1780);
		this.SpawnAishiData("The First Aishi is born.");
		this.Height -= 100;
		this.SpawnYear(1928);
		this.SpawnSaikouData("Saisho Saikou is born.");
		this.Height -= 100;
		this.SpawnYear(1933);
		this.SpawnAishiData("Ryoba's grandmother is born.");
		this.Height -= 100;
		this.SpawnYear(1939);
		this.SpawnMiscData("World War 2 begins.");
		this.Height -= 100;
		this.SpawnYear(1945);
		this.SpawnMiscData("The United States of America invades the Japanese island of Okinawa.");
		this.SpawnSaikouData("Saisho Saikou is present at the Battle of Okinawa.");
		this.Height -= 200;
		this.SpawnMiscData("World War 2 ends.");
		this.SpawnSaikouData("Saisho Saikou becomes very active in helping to rebuild post-war Japan.");
		this.Height -= 150;
		this.SpawnYear(1946);
		this.SpawnSaikouData("Saisho Saikou decides that the best way to help his country is with his engineering knowledge.");
		this.Height -= 200;
		this.SpawnSaikouData("Saisho Saikou starts an electronics repair shop.");
		this.Height -= 150;
		this.SpawnSaikouData("Saisho Saikou starts a company named Saikou Corp.");
		this.Height -= 150;
		this.SpawnSaikouData("Saisho Saikou invents Japan's first tape recorder.");
		this.Height -= 150;
		this.SpawnYear(1950);
		this.SpawnAishiData("Ryoba's grandmother finds her Senpai.");
		this.Height -= 150;
		this.SpawnYear(1953);
		this.SpawnAishiData("Ryoba's grandmother buys a house in Buraza, a small town near Tokyo.");
		this.Height -= 150;
		this.SpawnAishiData("Ryoba's mother is born.");
		this.Height -= 100;
		this.SpawnYear(1954);
		this.SpawnSaikouData("Saikou Corp releases the world's first transistor radio.");
		this.Height -= 150;
		this.SpawnYear(1960);
		this.SpawnMiscData("Kocho Shuyona is born.");
		this.Height -= 100;
		this.SpawnYear(1961);
		this.SpawnSaikouData("Saikou Corp releases the world's first compact video tape recorder.");
		this.Height -= 150;
		this.SpawnYear(1967);
		this.SpawnSaikouData("Saikou Corp releases the world's first integrated circuit radio.");
		this.Height -= 150;
		this.SpawnYear(1968);
		this.SpawnSaikouData("Saikou Corp releases the world's first color television set.");
		this.Height -= 150;
		this.SpawnYear(1969);
		this.SpawnMiscData("A man is born who would later become an investigative journalist.");
		this.SpawnSaikouData("Saikou Corp releases the world's first compact cassette recorder.");
		this.Height -= 150;
		this.SpawnYear(1970);
		this.SpawnAishiData("Ryoba's grandmother adds a basement to her house.");
		this.SpawnSaikouData("Saisho Saikou's daughter is born. She is named Ichiko.");
		this.Height -= 150;
		this.SpawnAishiData("Ryoba's mother finds her Senpai, kidnaps him, and keeps him prisoner in her basement.");
		this.Height -= 200;
		this.SpawnYear(1971);
		this.SpawnAishiData("Ryoba is born.");
		this.Height -= 100;
		this.SpawnYear(1976);
		this.SpawnAishiData("Ryoba's sister is born.");
		this.Height -= 100;
		this.SpawnYear(1979);
		this.SpawnSaikouData("Saikou Corp releases the world's first portable cassette tape player.");
		this.Height -= 150;
		this.SpawnSaikouData("Saisho Saikou's son is born. He is named Ichirou.");
		this.Height -= 150;
		this.SpawnYear(1981);
		this.SpawnSaikouData("Saikou Corp releases the world's first compact disc player.");
		this.Height -= 150;
		this.SpawnYear(1984);
		this.SpawnSaikouData("Saisho Saikou orders the construction of a post-highschool academy near Buraza Town.");
		this.Height -= 200;
		this.SpawnSaikouData("The academy is named Akademi.");
		this.Height -= 100;
		this.SpawnSaikouData("Saikou Corp renovates numerous houses in Buraza Town for free, including Ryoba's home.");
		this.Height -= 200;
		this.SpawnYear(1985);
		this.SpawnMiscData("Kocho Shuyona is interviewed by Saisho Saikou and is appointed the headmaster of Akademi.");
		this.Height -= 200;
		this.SpawnYear(1986);
		this.SpawnMiscData("Akademi officially opens.");
		this.SpawnSaikouData("Ichiko Saikou enrolls in Akademi.");
		this.Height -= 100;
		this.SpawnYear(1988);
		this.SpawnAishiData("Ryoba enrolls in Akademi.");
		this.SpawnSaikouData("Ichiko Saikou graduates from Akademi.");
		this.Height -= 150;
		this.SpawnAishiData("Ryoba finds her Senpai.");
		this.Height -= 100;
		this.SpawnYear(1989);
		this.SpawnAishiData("Ryoba eliminates every girl who seeks to enter a relationship with her Senpai.");
		this.SpawnSaikouData("Saikou Corp begins manufacturing handheld electronic gaming devices.");
		this.Height -= 150;
		this.SpawnMiscData("An investigative journalist accuses Ryoba of murder.");
		this.Height -= 150;
		this.SpawnAishiData("Ryoba stands trial in a highly televised court case.");
		this.Height -= 150;
		this.SpawnAishiData("Ryoba is declared innocent.");
		this.SpawnMiscData("The investigative journalist loses all credibility.");
		this.Height -= 150;
		this.SpawnAishiData("Ryoba kidnaps her Senpai and keeps him prisoner in her basement.");
		this.Height -= 150;
		this.SpawnMiscData("Ryoba's Senpai is abducted by Saikou Corp.");
		this.Height -= 150;
		this.SpawnMiscData("?????");
		this.SpawnAishiData("?????");
		this.SpawnSaikouData("?????");
		this.Height -= 100;
		this.SpawnAishiData("Ryoba marries her Senpai.");
		this.Height -= 100;
		this.SpawnYear(1990);
		this.SpawnSaikouData("Ichiko Saikou mysteriously disappears.");
		this.Height -= 150;
		this.SpawnYear(1994);
		this.SpawnAishiData("Ryoba's sister finds her Senpai.");
		this.SpawnSaikouData("Saikou Corp begins manufacturing video game consoles.");
		this.Height -= 150;
		this.SpawnAishiData("Ryoba's sister eliminates every girl who seeks to enter a relationship with her Senpai.");
		this.Height -= 200;
		this.SpawnAishiData("Ryoba's sister marries her Senpai.");
		this.Height -= 150;
		this.SpawnYear(1999);
		this.SpawnMiscData("Kocho Shuyona observes Ryoba entering the office of Saisho Saikou.");
		this.SpawnSaikouData("Ichirou Saikou enrolls in Akademi.");
		this.Height -= 150;
		this.SpawnYear(2004);
		this.SpawnMiscData("A woman falls in love with the investigative journalist who accused Ryoba of murder.");
		this.Height -= 200;
		this.SpawnMiscData("Taro Yamada is born.");
		this.Height -= 100;
		this.SpawnYear(2005);
		this.SpawnSaikouData("Ichirou Saikou's daughter is born. She is named Megami.");
		this.SpawnMiscData("The investigative journalist's daughter is born.");
		this.SpawnAishiData("Ryoba gives birth to a daughter. She is named Ayano.");
		this.Height -= 150;
		this.SpawnAishiData("Ryoba's sister gives birth to a daughter.");
		this.Height -= 150;
		this.SpawnYear(2007);
		this.SpawnSaikouData("Ichirou Saikou's son is born. He is named Kencho.");
		this.Height -= 150;
		this.SpawnYear(2020);
		this.SpawnSaikouData("Saisho Saikou steps down as CEO of Saikou Corp and appoints his son Ichirou as the new CEO.");
		this.Height -= 200;
		this.SpawnYear(2021);
		this.SpawnMiscData("An urban legend is born about a mysterious hacker and information broker named ''Info-chan.''");
		this.Height -= 200;
		this.SpawnYear(2022);
		this.SpawnAishiData("Ayano Aishi enrolls in Akademi.");
		this.Height -= 100;
		this.SpawnYear(2023);
		this.Long = true;
		this.Height -= 100;
		this.SpawnMiscData("The Saikou family announces to the world that Saisho Saikou has passed away at the age of 95.");
		this.Height -= 150;
		this.Hide = true;
		this.SpawnMiscData("Ayano Aishi finds her Senpai.");
	}

	// Token: 0x06001EF3 RID: 7923 RVA: 0x001B5A08 File Offset: 0x001B3C08
	private void Update()
	{
		if (base.transform.localPosition.y > 9.75f)
		{
			this.Speed = Mathf.MoveTowards(this.Speed, 0f, Time.deltaTime * 0.01f);
			this.Ambience.volume = Mathf.MoveTowards(this.Ambience.volume, 0f, Time.deltaTime * 0.1f);
			if (this.Speed == 0f)
			{
				this.Timer += Time.deltaTime;
				if (this.Timer > 6f)
				{
					this.Darkness.alpha = Mathf.MoveTowards(this.Darkness.alpha, 1f, Time.deltaTime * 0.2f);
					if (this.Darkness.alpha == 1f)
					{
						OptionGlobals.Fog = false;
						GameGlobals.TrueEnding = false;
						SceneManager.LoadScene("NewTitleScene");
					}
				}
				else if (this.Timer > 1f)
				{
					if (this.FinalLabel.alpha == 0f)
					{
						this.MyAudio.Play();
					}
					this.FinalLabel.alpha = Mathf.MoveTowards(this.FinalLabel.alpha, 1f, Time.deltaTime);
				}
			}
		}
		else
		{
			if (base.transform.localPosition.y > 9.25f && base.transform.localPosition.y < 9.75f)
			{
				this.Speed = Mathf.Lerp(this.Speed, 0.05f, Time.deltaTime * 10f);
			}
			else if (base.transform.localPosition.y < 9.5f)
			{
				if (Input.GetKey("down") || Input.GetKey("s") || this.InputManager.DPadDown || this.InputManager.StickDown)
				{
					this.Speed += Time.deltaTime;
				}
				else if (Input.GetKey("up") || Input.GetKey("w") || this.InputManager.DPadUp || this.InputManager.StickUp)
				{
					this.Speed -= Time.deltaTime;
				}
			}
			this.Ambience.volume = Mathf.MoveTowards(this.Ambience.volume, 0.5f, Time.deltaTime);
		}
		base.transform.localPosition += new Vector3(0f, this.Speed * Time.deltaTime, 0f);
		if (base.transform.localPosition.y < this.MaxHeight)
		{
			base.transform.localPosition = new Vector3(0f, this.MaxHeight, 1f);
			this.Speed = 0f;
			return;
		}
		if (base.transform.localPosition.y < 0.5f)
		{
			this.MaxHeight = base.transform.localPosition.y;
		}
	}

	// Token: 0x06001EF4 RID: 7924 RVA: 0x001B5D1C File Offset: 0x001B3F1C
	private void SpawnYear(int Year)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.YearObject);
		gameObject.transform.parent = base.transform;
		gameObject.transform.localPosition = new Vector3(0f, (float)this.Height, 0f);
		gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
		gameObject.GetComponent<UILabel>().text = (Year.ToString() ?? "");
		this.Height -= 50;
	}

	// Token: 0x06001EF5 RID: 7925 RVA: 0x001B5DB0 File Offset: 0x001B3FB0
	private void SpawnAishiData(string Data)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.TextObject);
		gameObject.transform.parent = base.transform;
		gameObject.transform.localPosition = new Vector3(-600f, (float)this.Height, 0f);
		gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
		gameObject.GetComponent<UILabel>().text = (Data ?? "");
	}

	// Token: 0x06001EF6 RID: 7926 RVA: 0x001B5E30 File Offset: 0x001B4030
	private void SpawnSaikouData(string Data)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.TextObject);
		gameObject.transform.parent = base.transform;
		gameObject.transform.localPosition = new Vector3(600f, (float)this.Height, 0f);
		gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
		gameObject.GetComponent<UILabel>().text = (Data ?? "");
	}

	// Token: 0x06001EF7 RID: 7927 RVA: 0x001B5EB0 File Offset: 0x001B40B0
	private void SpawnMiscData(string Data)
	{
		GameObject gameObject;
		if (!this.Long)
		{
			gameObject = UnityEngine.Object.Instantiate<GameObject>(this.TextObject);
		}
		else
		{
			gameObject = UnityEngine.Object.Instantiate<GameObject>(this.LongTextObject);
		}
		gameObject.transform.parent = base.transform;
		gameObject.transform.localPosition = new Vector3(0f, (float)this.Height, 0f);
		gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
		gameObject.GetComponent<UILabel>().text = (Data ?? "");
		if (this.Hide)
		{
			this.FinalLabel = gameObject.GetComponent<UILabel>();
			this.FinalLabel.color = new Color(1f, 0f, 0f, 0f);
			this.Darkness.transform.position = this.FinalLabel.transform.position;
		}
	}

	// Token: 0x04004036 RID: 16438
	public InputManagerScript InputManager;

	// Token: 0x04004037 RID: 16439
	public GameObject LongTextObject;

	// Token: 0x04004038 RID: 16440
	public GameObject TextObject;

	// Token: 0x04004039 RID: 16441
	public GameObject YearObject;

	// Token: 0x0400403A RID: 16442
	public AudioSource Ambience;

	// Token: 0x0400403B RID: 16443
	public AudioSource MyAudio;

	// Token: 0x0400403C RID: 16444
	public UISprite Darkness;

	// Token: 0x0400403D RID: 16445
	public UILabel FinalLabel;

	// Token: 0x0400403E RID: 16446
	public float MaxHeight;

	// Token: 0x0400403F RID: 16447
	public float Speed = 0.05f;

	// Token: 0x04004040 RID: 16448
	public float Timer;

	// Token: 0x04004041 RID: 16449
	public bool Hide;

	// Token: 0x04004042 RID: 16450
	public bool Long;

	// Token: 0x04004043 RID: 16451
	public int Height;
}
