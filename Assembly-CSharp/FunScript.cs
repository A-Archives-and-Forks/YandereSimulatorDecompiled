﻿using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020002D5 RID: 725
public class FunScript : MonoBehaviour
{
	// Token: 0x060014B7 RID: 5303 RVA: 0x000CB5C8 File Offset: 0x000C97C8
	private void Start()
	{
		if (PlayerPrefs.GetInt("DebugNumber") > 0)
		{
			if (PlayerPrefs.GetInt("DebugNumber") > 10)
			{
				PlayerPrefs.SetInt("DebugNumber", 0);
			}
			this.DebugNumber = PlayerPrefs.GetInt("DebugNumber");
		}
		if (this.VeryFun)
		{
			if (this.DebugNumber != -1)
			{
				this.Text = (this.DebugNumber.ToString() ?? "");
			}
			else
			{
				this.Text = File.ReadAllText(Application.streamingAssetsPath + "/Fun.txt");
			}
			if (this.Text == "0")
			{
				this.ID = 0;
			}
			else if (this.Text == "1")
			{
				this.ID = 1;
			}
			else if (this.Text == "2")
			{
				this.ID = 2;
			}
			else if (this.Text == "3")
			{
				this.ID = 3;
			}
			else if (this.Text == "4")
			{
				this.ID = 4;
			}
			else if (this.Text == "5")
			{
				this.ID = 5;
			}
			else if (this.Text == "6")
			{
				this.ID = 6;
			}
			else if (this.Text == "7")
			{
				this.ID = 7;
			}
			else if (this.Text == "8")
			{
				this.ID = 8;
			}
			else if (this.Text == "9")
			{
				this.ID = 9;
			}
			else if (this.Text == "10")
			{
				this.ID = 10;
			}
			else if (this.Text == "69")
			{
				this.Label.text = "( ͡° ͜ʖ ͡°) ";
				this.ID = 8;
			}
			else if (this.Text == "666")
			{
				this.Label.text = "Sometimes, I lie. It's just too fun. You eat up everything I say. I wonder what else I can trick you into believing? ";
				this.Girl.color = new Color(1f, 0f, 0f, 0f);
				this.Label.color = new Color(1f, 0f, 0f, 1f);
				this.ID = 5;
			}
			else
			{
				Debug.Log("Booting the player back to the WelcomeScene.");
				Application.LoadLevel("WelcomeScene");
			}
		}
		if (this.Text != "666" && this.Text != "69")
		{
			this.Label.text = this.Lines[this.ID];
		}
		if (SceneManager.GetActiveScene().name == "VeryFunScene" || this.Text == "666")
		{
			this.G = 0f;
			this.B = 0f;
			this.Label.color = new Color(this.R, this.G, this.B, 1f);
			this.Skip.SetActive(false);
		}
		this.Skip.SetActive(false);
		this.Controls.SetActive(false);
		this.Label.gameObject.SetActive(false);
		this.Girl.color = new Color(this.R, this.G, this.B, 0f);
	}

	// Token: 0x060014B8 RID: 5304 RVA: 0x000CB958 File Offset: 0x000C9B58
	private void Update()
	{
		if (Input.GetKeyDown(",") && PlayerPrefs.GetInt("DebugNumber") > 0)
		{
			PlayerPrefs.SetInt("DebugNumber", PlayerPrefs.GetInt("DebugNumber") - 1);
			Application.LoadLevel(Application.loadedLevel);
		}
		if (Input.GetKeyDown(".") && PlayerPrefs.GetInt("DebugNumber") < 10)
		{
			PlayerPrefs.SetInt("DebugNumber", PlayerPrefs.GetInt("DebugNumber") + 1);
			Application.LoadLevel(Application.loadedLevel);
		}
		this.Timer += Time.deltaTime;
		if (this.Timer > 3f)
		{
			if (!this.Typewriter.mActive)
			{
				this.Controls.SetActive(true);
			}
		}
		else if (this.Timer > 2f)
		{
			this.Girl.mainTexture = this.Portraits[this.ID];
			this.Label.gameObject.SetActive(true);
		}
		else if (this.Timer > 1f)
		{
			this.Girl.color = new Color(this.R, this.G, this.B, Mathf.MoveTowards(this.Girl.color.a, 1f, Time.deltaTime));
		}
		if (this.Controls.activeInHierarchy)
		{
			if (Input.GetButtonDown("B"))
			{
				if (this.Skip.activeInHierarchy)
				{
					this.ID = 19;
					this.Skip.SetActive(false);
					this.Girl.mainTexture = this.Portraits[this.ID];
					this.Typewriter.ResetToBeginning();
					this.Typewriter.mFullText = this.Lines[this.ID];
					return;
				}
			}
			else if (Input.GetButtonDown("A"))
			{
				if (this.ID < this.Lines.Length - 1 && !this.VeryFun)
				{
					if (this.Typewriter.mCurrentOffset < this.Typewriter.mFullText.Length)
					{
						this.Typewriter.Finish();
						return;
					}
					this.ID++;
					if (this.ID == 19)
					{
						this.Skip.SetActive(false);
					}
					this.Girl.mainTexture = this.Portraits[this.ID];
					this.Typewriter.ResetToBeginning();
					this.Typewriter.mFullText = this.Lines[this.ID];
					return;
				}
				else
				{
					Application.Quit();
				}
			}
		}
	}

	// Token: 0x0400207B RID: 8315
	public TypewriterEffect Typewriter;

	// Token: 0x0400207C RID: 8316
	public GameObject Controls;

	// Token: 0x0400207D RID: 8317
	public GameObject Skip;

	// Token: 0x0400207E RID: 8318
	public Texture[] Portraits;

	// Token: 0x0400207F RID: 8319
	public string[] Lines;

	// Token: 0x04002080 RID: 8320
	public UITexture Girl;

	// Token: 0x04002081 RID: 8321
	public UILabel Label;

	// Token: 0x04002082 RID: 8322
	public float OutroTimer;

	// Token: 0x04002083 RID: 8323
	public float Timer;

	// Token: 0x04002084 RID: 8324
	public int DebugNumber;

	// Token: 0x04002085 RID: 8325
	public int ID;

	// Token: 0x04002086 RID: 8326
	public bool VeryFun;

	// Token: 0x04002087 RID: 8327
	public float R = 1f;

	// Token: 0x04002088 RID: 8328
	public float G = 1f;

	// Token: 0x04002089 RID: 8329
	public float B = 1f;

	// Token: 0x0400208A RID: 8330
	public string Text;
}
