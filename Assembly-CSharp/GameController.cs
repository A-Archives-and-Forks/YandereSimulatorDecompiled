﻿using System;
using UnityEngine;

// Token: 0x02000294 RID: 660
public class GameController : MonoBehaviour
{
	// Token: 0x060013C6 RID: 5062 RVA: 0x000BB844 File Offset: 0x000B9A44
	private void Update()
	{
		this.m_Player.transform.Rotate(new Vector3(0f, Input.GetAxis("Horizontal") * Time.deltaTime * 200f, 0f));
		this.m_Player.transform.Translate(base.transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * 4f);
	}

	// Token: 0x060013C7 RID: 5063 RVA: 0x000BB8C4 File Offset: 0x000B9AC4
	private void OnGUI()
	{
		GUI.Label(new Rect(50f, 50f, 200f, 20f), "Press arrow key to move");
		Animation componentInChildren = this.m_Player.GetComponentInChildren<Animation>();
		componentInChildren.enabled = GUI.Toggle(new Rect(50f, 70f, 200f, 20f), componentInChildren.enabled, "Play Animation");
		DynamicBone[] components = this.m_Player.GetComponents<DynamicBone>();
		GUI.Label(new Rect(50f, 100f, 200f, 20f), "Choose dynamic bone:");
		components[0].enabled = (components[1].enabled = GUI.Toggle(new Rect(50f, 120f, 100f, 20f), components[0].enabled, "Breasts"));
		components[2].enabled = GUI.Toggle(new Rect(50f, 140f, 100f, 20f), components[2].enabled, "Tail");
	}

	// Token: 0x04001D80 RID: 7552
	public GameObject m_Player;
}
