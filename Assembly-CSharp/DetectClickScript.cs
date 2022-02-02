﻿using System;
using UnityEngine;

// Token: 0x0200027F RID: 639
public class DetectClickScript : MonoBehaviour
{
	// Token: 0x0600137D RID: 4989 RVA: 0x000B35FB File Offset: 0x000B17FB
	private void Start()
	{
		this.OriginalPosition = base.transform.localPosition;
		this.OriginalColor = this.Sprite.color;
	}

	// Token: 0x0600137E RID: 4990 RVA: 0x000B3620 File Offset: 0x000B1820
	private void Update()
	{
		RaycastHit raycastHit;
		if (Input.GetMouseButtonDown(0) && Physics.Raycast(this.GUICamera.ScreenPointToRay(Input.mousePosition), out raycastHit, 100f) && raycastHit.collider == this.MyCollider && this.Label.color.a == 1f)
		{
			this.Sprite.color = new Color(1f, 1f, 1f, 1f);
			this.Clicked = true;
		}
	}

	// Token: 0x0600137F RID: 4991 RVA: 0x000B36A9 File Offset: 0x000B18A9
	private void OnTriggerEnter()
	{
		if (this.Label.color.a == 1f)
		{
			this.Sprite.color = Color.white;
		}
	}

	// Token: 0x06001380 RID: 4992 RVA: 0x000B36D2 File Offset: 0x000B18D2
	private void OnTriggerExit()
	{
		this.Sprite.color = this.OriginalColor;
	}

	// Token: 0x04001CBE RID: 7358
	public Vector3 OriginalPosition;

	// Token: 0x04001CBF RID: 7359
	public Color OriginalColor;

	// Token: 0x04001CC0 RID: 7360
	public Collider MyCollider;

	// Token: 0x04001CC1 RID: 7361
	public Camera GUICamera;

	// Token: 0x04001CC2 RID: 7362
	public UISprite Sprite;

	// Token: 0x04001CC3 RID: 7363
	public UILabel Label;

	// Token: 0x04001CC4 RID: 7364
	public bool Clicked;
}
