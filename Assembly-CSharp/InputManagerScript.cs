﻿using System;
using UnityEngine;

// Token: 0x02000334 RID: 820
public class InputManagerScript : MonoBehaviour
{
	// Token: 0x060018CD RID: 6349 RVA: 0x000F4BD8 File Offset: 0x000F2DD8
	private void Update()
	{
		this.TappedUp = false;
		this.TappedDown = false;
		this.TappedRight = false;
		this.TappedLeft = false;
		if (Input.GetAxisRaw("DpadY") > 0.5f)
		{
			this.TappedUp = !this.DPadUp;
			this.DPadUp = true;
		}
		else if (Input.GetAxisRaw("DpadY") < -0.5f)
		{
			this.TappedDown = !this.DPadDown;
			this.DPadDown = true;
		}
		else
		{
			this.DPadUp = false;
			this.DPadDown = false;
		}
		if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
		{
			if (Input.GetAxisRaw("Vertical") > 0.5f)
			{
				this.TappedUp = !this.StickUp;
				this.StickUp = !this.TappedDown;
			}
			else if (Input.GetAxisRaw("Vertical") < -0.5f)
			{
				this.TappedDown = !this.StickDown;
				this.StickDown = !this.TappedUp;
			}
			else
			{
				this.StickUp = false;
				this.StickDown = false;
			}
		}
		if (Input.GetAxisRaw("DpadX") > 0.5f)
		{
			this.TappedRight = !this.DPadRight;
			this.DPadRight = true;
		}
		else if (Input.GetAxisRaw("DpadX") < -0.5f)
		{
			this.TappedLeft = !this.DPadLeft;
			this.DPadLeft = true;
		}
		else
		{
			this.DPadRight = false;
			this.DPadLeft = false;
		}
		if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
		{
			if (Input.GetAxisRaw("Horizontal") > 0.5f)
			{
				this.TappedRight = !this.StickRight;
				this.StickRight = true;
			}
			else if (Input.GetAxisRaw("Horizontal") < -0.5f)
			{
				this.TappedLeft = !this.StickLeft;
				this.StickLeft = true;
			}
			else
			{
				this.StickRight = false;
				this.StickLeft = false;
			}
		}
		if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f && Input.GetAxisRaw("DpadX") < 0.5f && Input.GetAxisRaw("DpadX") > -0.5f)
		{
			this.TappedRight = false;
			this.TappedLeft = false;
		}
		if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f && Input.GetAxisRaw("DpadY") < 0.5f && Input.GetAxisRaw("DpadY") > -0.5f)
		{
			this.TappedUp = false;
			this.TappedDown = false;
		}
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
		{
			this.TappedUp = true;
			this.NoStick();
		}
		if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
		{
			this.TappedDown = true;
			this.NoStick();
		}
		if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			this.TappedLeft = true;
			this.NoStick();
		}
		if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
		{
			this.TappedRight = true;
			this.NoStick();
		}
	}

	// Token: 0x060018CE RID: 6350 RVA: 0x000F4EE1 File Offset: 0x000F30E1
	private void NoStick()
	{
		this.StickUp = false;
		this.StickDown = false;
		this.StickLeft = false;
		this.StickRight = false;
	}

	// Token: 0x04002604 RID: 9732
	public bool TappedUp;

	// Token: 0x04002605 RID: 9733
	public bool TappedDown;

	// Token: 0x04002606 RID: 9734
	public bool TappedRight;

	// Token: 0x04002607 RID: 9735
	public bool TappedLeft;

	// Token: 0x04002608 RID: 9736
	public bool DPadUp;

	// Token: 0x04002609 RID: 9737
	public bool DPadDown;

	// Token: 0x0400260A RID: 9738
	public bool DPadRight;

	// Token: 0x0400260B RID: 9739
	public bool DPadLeft;

	// Token: 0x0400260C RID: 9740
	public bool StickUp;

	// Token: 0x0400260D RID: 9741
	public bool StickDown;

	// Token: 0x0400260E RID: 9742
	public bool StickRight;

	// Token: 0x0400260F RID: 9743
	public bool StickLeft;
}
