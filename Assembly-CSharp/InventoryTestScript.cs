﻿using System;
using UnityEngine;

// Token: 0x02000340 RID: 832
public class InventoryTestScript : MonoBehaviour
{
	// Token: 0x060018FD RID: 6397 RVA: 0x000FA684 File Offset: 0x000F8884
	private void Start()
	{
		this.RightGrid.localScale = new Vector3(0f, 0f, 0f);
		this.LeftGrid.localScale = new Vector3(0f, 0f, 0f);
		Time.timeScale = 1f;
	}

	// Token: 0x060018FE RID: 6398 RVA: 0x000FA6DC File Offset: 0x000F88DC
	private void Update()
	{
		if (Input.GetKeyDown("space"))
		{
			this.Open = !this.Open;
		}
		AnimationState animationState = this.SkirtAnimation["InverseSkirtOpen"];
		AnimationState animationState2 = this.GirlAnimation["f02_inventory_00"];
		if (this.Open)
		{
			this.RightGrid.localScale = Vector3.MoveTowards(this.RightGrid.localScale, new Vector3(0.9f, 0.9f, 0.9f), Time.deltaTime * 10f);
			this.LeftGrid.localScale = Vector3.MoveTowards(this.LeftGrid.localScale, new Vector3(0.9f, 0.9f, 0.9f), Time.deltaTime * 10f);
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, Mathf.Lerp(base.transform.position.z, 0.37f, Time.deltaTime * 10f));
			animationState.time = Mathf.Lerp(animationState2.time, 1f, Time.deltaTime * 10f);
			animationState2.time = animationState.time;
			this.Alpha = Mathf.Lerp(this.Alpha, 1f, Time.deltaTime * 10f);
			this.SkirtRenderer.material.color = new Color(1f, 1f, 1f, this.Alpha);
			this.GirlRenderer.materials[0].color = new Color(0f, 0f, 0f, this.Alpha);
			this.GirlRenderer.materials[1].color = new Color(0f, 0f, 0f, this.Alpha);
			if (Input.GetKeyDown("right"))
			{
				this.Column++;
				this.UpdateHighlight();
			}
			if (Input.GetKeyDown("left"))
			{
				this.Column--;
				this.UpdateHighlight();
			}
			if (Input.GetKeyDown("up"))
			{
				this.Row--;
				this.UpdateHighlight();
			}
			if (Input.GetKeyDown("down"))
			{
				this.Row++;
				this.UpdateHighlight();
			}
		}
		else
		{
			this.RightGrid.localScale = Vector3.MoveTowards(this.RightGrid.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime * 10f);
			this.LeftGrid.localScale = Vector3.MoveTowards(this.LeftGrid.localScale, new Vector3(0f, 0f, 0f), Time.deltaTime * 10f);
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, Mathf.Lerp(base.transform.position.z, 1f, Time.deltaTime * 10f));
			animationState.time = Mathf.Lerp(animationState2.time, 0f, Time.deltaTime * 10f);
			animationState2.time = animationState.time;
			this.Alpha = Mathf.Lerp(this.Alpha, 0f, Time.deltaTime * 10f);
			this.SkirtRenderer.material.color = new Color(1f, 1f, 1f, this.Alpha);
			this.GirlRenderer.materials[0].color = new Color(0f, 0f, 0f, this.Alpha);
			this.GirlRenderer.materials[1].color = new Color(0f, 0f, 0f, this.Alpha);
		}
		for (int i = 0; i < this.Items.Length; i++)
		{
			if (this.Items[i].Clicked)
			{
				Debug.Log(string.Concat(new string[]
				{
					"Item width is ",
					this.Items[i].InventoryItem.Width.ToString(),
					" and item height is ",
					this.Items[i].InventoryItem.Height.ToString(),
					". Open space is: ",
					this.OpenSpace.ToString()
				}));
				if (this.Items[i].InventoryItem.Height * this.Items[i].InventoryItem.Width < this.OpenSpace)
				{
					Debug.Log("We might have enough open space to add the item to the inventory.");
					this.CheckOpenSpace();
					if (this.UseGrid == 1)
					{
						this.Items[i].transform.parent = this.LeftGridItemParent;
						float inventorySize = this.Items[i].InventoryItem.InventorySize;
						this.Items[i].transform.localScale = new Vector3(inventorySize, inventorySize, inventorySize);
						this.Items[i].transform.localEulerAngles = new Vector3(90f, 180f, 0f);
						this.Items[i].transform.localPosition = this.Items[i].InventoryItem.InventoryPosition;
						int j = 1;
						if (this.UseColumn == 1)
						{
							while (j < this.Items[i].InventoryItem.Height + 1)
							{
								this.LeftSpaces1[j] = true;
								j++;
							}
						}
						else if (this.UseColumn == 2)
						{
							while (j < this.Items[i].InventoryItem.Height + 1)
							{
								this.LeftSpaces2[j] = true;
								j++;
							}
						}
						if (this.UseColumn > 1)
						{
							this.Items[i].transform.localPosition -= new Vector3(0.05f * (float)(this.UseColumn - 1), 0f, 0f);
						}
					}
				}
				this.Items[i].Clicked = false;
			}
		}
	}

	// Token: 0x060018FF RID: 6399 RVA: 0x000FAD18 File Offset: 0x000F8F18
	private void CheckOpenSpace()
	{
		this.UseColumn = 0;
		this.UseGrid = 0;
		int i;
		for (i = 1; i < this.LeftSpaces1.Length; i++)
		{
			if (this.UseGrid == 0 && !this.LeftSpaces1[i])
			{
				this.UseColumn = 1;
				this.UseGrid = 1;
			}
		}
		i = 1;
		if (this.UseGrid == 0)
		{
			while (i < this.LeftSpaces2.Length)
			{
				if (this.UseGrid == 0 && !this.LeftSpaces2[i])
				{
					this.UseColumn = 2;
					this.UseGrid = 1;
				}
				i++;
			}
		}
	}

	// Token: 0x06001900 RID: 6400 RVA: 0x000FADA4 File Offset: 0x000F8FA4
	private void UpdateHighlight()
	{
		if (this.Column == 5)
		{
			if (this.Grid == 1)
			{
				this.Grid = 2;
			}
			else
			{
				this.Grid = 1;
			}
			this.Column = 1;
		}
		else if (this.Column == 0)
		{
			if (this.Grid == 1)
			{
				this.Grid = 2;
			}
			else
			{
				this.Grid = 1;
			}
			this.Column = 4;
		}
		if (this.Row == 6)
		{
			this.Row = 1;
		}
		else if (this.Row == 0)
		{
			this.Row = 5;
		}
		if (this.Grid == 1)
		{
			this.Highlight.transform.parent = this.LeftGridHighlightParent;
		}
		else
		{
			this.Highlight.transform.parent = this.RightGridHighlightParent;
		}
		this.Highlight.localPosition = new Vector3((float)this.Column, (float)(this.Row * -1), 0f);
	}

	// Token: 0x04002718 RID: 10008
	public SimpleDetectClickScript[] Items;

	// Token: 0x04002719 RID: 10009
	public Animation SkirtAnimation;

	// Token: 0x0400271A RID: 10010
	public Animation GirlAnimation;

	// Token: 0x0400271B RID: 10011
	public GameObject Skirt;

	// Token: 0x0400271C RID: 10012
	public GameObject Girl;

	// Token: 0x0400271D RID: 10013
	public Renderer SkirtRenderer;

	// Token: 0x0400271E RID: 10014
	public Renderer GirlRenderer;

	// Token: 0x0400271F RID: 10015
	public Transform RightGridHighlightParent;

	// Token: 0x04002720 RID: 10016
	public Transform LeftGridHighlightParent;

	// Token: 0x04002721 RID: 10017
	public Transform RightGridItemParent;

	// Token: 0x04002722 RID: 10018
	public Transform LeftGridItemParent;

	// Token: 0x04002723 RID: 10019
	public Transform Highlight;

	// Token: 0x04002724 RID: 10020
	public Transform RightGrid;

	// Token: 0x04002725 RID: 10021
	public Transform LeftGrid;

	// Token: 0x04002726 RID: 10022
	public float Alpha;

	// Token: 0x04002727 RID: 10023
	public bool Open = true;

	// Token: 0x04002728 RID: 10024
	public int OpenSpace = 1;

	// Token: 0x04002729 RID: 10025
	public int UseColumn;

	// Token: 0x0400272A RID: 10026
	public int UseGrid;

	// Token: 0x0400272B RID: 10027
	public int Column = 1;

	// Token: 0x0400272C RID: 10028
	public int Grid = 1;

	// Token: 0x0400272D RID: 10029
	public int Row = 1;

	// Token: 0x0400272E RID: 10030
	public bool[] LeftSpaces1;

	// Token: 0x0400272F RID: 10031
	public bool[] LeftSpaces2;

	// Token: 0x04002730 RID: 10032
	public bool[] LeftSpaces3;

	// Token: 0x04002731 RID: 10033
	public bool[] LeftSpaces4;

	// Token: 0x04002732 RID: 10034
	public bool[] RightSpaces1;

	// Token: 0x04002733 RID: 10035
	public bool[] RightSpaces2;

	// Token: 0x04002734 RID: 10036
	public bool[] RightSpaces3;

	// Token: 0x04002735 RID: 10037
	public bool[] RightSpaces4;
}
