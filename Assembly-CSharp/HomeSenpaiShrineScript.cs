﻿using System;
using UnityEngine;

// Token: 0x02000323 RID: 803
public class HomeSenpaiShrineScript : MonoBehaviour
{
	// Token: 0x0600188E RID: 6286 RVA: 0x000F106C File Offset: 0x000EF26C
	public void Start()
	{
		this.UpdateText(this.GetCurrentIndex());
		for (int i = 1; i < 11; i++)
		{
			if (PlayerGlobals.GetShrineCollectible(i))
			{
				this.Collectibles[i].SetActive(true);
			}
		}
	}

	// Token: 0x0600188F RID: 6287 RVA: 0x000F10A8 File Offset: 0x000EF2A8
	private bool InUpperHalf()
	{
		return this.Y < 2;
	}

	// Token: 0x06001890 RID: 6288 RVA: 0x000F10B3 File Offset: 0x000EF2B3
	private int GetCurrentIndex()
	{
		if (this.InUpperHalf())
		{
			return this.Y;
		}
		return 2 + (this.X + (this.Y - 2) * this.Columns);
	}

	// Token: 0x06001891 RID: 6289 RVA: 0x000F10DC File Offset: 0x000EF2DC
	private void Update()
	{
		if (!this.HomeYandere.CanMove && !this.PauseScreen.Show)
		{
			if (this.HomeCamera.ID == 6)
			{
				this.Rotation = Mathf.Lerp(this.Rotation, 135f, Time.deltaTime * 10f);
				this.RightDoor.localEulerAngles = new Vector3(this.RightDoor.localEulerAngles.x, this.Rotation, this.RightDoor.localEulerAngles.z);
				this.LeftDoor.localEulerAngles = new Vector3(this.LeftDoor.localEulerAngles.x, -this.Rotation, this.LeftDoor.localEulerAngles.z);
				if (this.InputManager.TappedUp)
				{
					this.Y = ((this.Y > 0) ? (this.Y - 1) : (this.Rows - 1));
				}
				if (this.InputManager.TappedDown)
				{
					this.Y = ((this.Y < this.Rows - 1) ? (this.Y + 1) : 0);
				}
				if (this.InputManager.TappedRight && !this.InUpperHalf())
				{
					this.X = ((this.X < this.Columns - 1) ? (this.X + 1) : 0);
				}
				if (this.InputManager.TappedLeft && !this.InUpperHalf())
				{
					this.X = ((this.X > 0) ? (this.X - 1) : (this.Columns - 1));
				}
				if (this.InUpperHalf())
				{
					this.X = 1;
				}
				int currentIndex = this.GetCurrentIndex();
				this.HomeCamera.Destination = this.Destinations[currentIndex];
				this.HomeCamera.Target = this.Targets[currentIndex];
				if (this.InputManager.TappedUp || this.InputManager.TappedDown || this.InputManager.TappedRight || this.InputManager.TappedLeft)
				{
					this.UpdateText(currentIndex - 1);
				}
				if (Input.GetButtonDown("B"))
				{
					this.HomeCamera.Destination = this.HomeCamera.Destinations[0];
					this.HomeCamera.Target = this.HomeCamera.Targets[0];
					this.HomeYandere.CanMove = true;
					this.HomeYandere.gameObject.SetActive(true);
					this.HomeWindow.Show = false;
				}
			}
		}
		else if (!this.Open)
		{
			this.Rotation = Mathf.Lerp(this.Rotation, 0f, Time.deltaTime * 10f);
			this.RightDoor.localEulerAngles = new Vector3(this.RightDoor.localEulerAngles.x, this.Rotation, this.RightDoor.localEulerAngles.z);
			this.LeftDoor.localEulerAngles = new Vector3(this.LeftDoor.localEulerAngles.x, this.Rotation, this.LeftDoor.localEulerAngles.z);
		}
		if (this.Open)
		{
			this.Rotation = Mathf.Lerp(this.Rotation, 135f, Time.deltaTime * 10f);
			this.RightDoor.localEulerAngles = new Vector3(this.RightDoor.localEulerAngles.x, this.Rotation, this.RightDoor.localEulerAngles.z);
			this.LeftDoor.localEulerAngles = new Vector3(this.LeftDoor.localEulerAngles.x, -this.Rotation, this.LeftDoor.localEulerAngles.z);
		}
	}

	// Token: 0x06001892 RID: 6290 RVA: 0x000F148C File Offset: 0x000EF68C
	private void UpdateText(int newIndex)
	{
		if (newIndex == -1)
		{
			newIndex = 10;
		}
		if (newIndex == 0)
		{
			this.NameLabel.text = this.Names[newIndex];
			this.DescLabel.text = this.Descs[newIndex];
			return;
		}
		if (PlayerGlobals.GetShrineCollectible(newIndex))
		{
			this.NameLabel.text = this.Names[newIndex];
			this.DescLabel.text = this.Descs[newIndex];
			return;
		}
		this.NameLabel.text = "???";
		this.DescLabel.text = "I'd like to find something that Senpai touched and keep it here...";
	}

	// Token: 0x0400253E RID: 9534
	public InputManagerScript InputManager;

	// Token: 0x0400253F RID: 9535
	public PauseScreenScript PauseScreen;

	// Token: 0x04002540 RID: 9536
	public HomeYandereScript HomeYandere;

	// Token: 0x04002541 RID: 9537
	public HomeCameraScript HomeCamera;

	// Token: 0x04002542 RID: 9538
	public HomeWindowScript HomeWindow;

	// Token: 0x04002543 RID: 9539
	public GameObject[] Collectibles;

	// Token: 0x04002544 RID: 9540
	public Transform[] Destinations;

	// Token: 0x04002545 RID: 9541
	public Transform[] Targets;

	// Token: 0x04002546 RID: 9542
	public Transform RightDoor;

	// Token: 0x04002547 RID: 9543
	public Transform LeftDoor;

	// Token: 0x04002548 RID: 9544
	public UILabel NameLabel;

	// Token: 0x04002549 RID: 9545
	public UILabel DescLabel;

	// Token: 0x0400254A RID: 9546
	public string[] Names;

	// Token: 0x0400254B RID: 9547
	public string[] Descs;

	// Token: 0x0400254C RID: 9548
	public float Rotation;

	// Token: 0x0400254D RID: 9549
	private int Rows = 5;

	// Token: 0x0400254E RID: 9550
	private int Columns = 3;

	// Token: 0x0400254F RID: 9551
	private int X = 1;

	// Token: 0x04002550 RID: 9552
	private int Y = 3;

	// Token: 0x04002551 RID: 9553
	public bool Open;
}
