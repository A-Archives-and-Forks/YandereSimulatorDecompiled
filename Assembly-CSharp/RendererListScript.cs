﻿using System;
using UnityEngine;

// Token: 0x020003CE RID: 974
public class RendererListScript : MonoBehaviour
{
	// Token: 0x06001B53 RID: 6995 RVA: 0x001335CC File Offset: 0x001317CC
	private void Start()
	{
		Transform[] componentsInChildren = base.gameObject.GetComponentsInChildren<Transform>();
		int num = 0;
		foreach (Transform transform in componentsInChildren)
		{
			if (transform.gameObject.GetComponent<Renderer>() != null)
			{
				this.Renderers[num] = transform.gameObject.GetComponent<Renderer>();
				num++;
			}
		}
	}

	// Token: 0x06001B54 RID: 6996 RVA: 0x00133624 File Offset: 0x00131824
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			foreach (Renderer renderer in this.Renderers)
			{
				renderer.enabled = !renderer.enabled;
			}
		}
	}

	// Token: 0x04002EB2 RID: 11954
	public Renderer[] Renderers;
}
