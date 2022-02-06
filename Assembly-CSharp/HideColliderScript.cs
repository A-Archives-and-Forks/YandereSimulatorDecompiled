﻿using System;
using UnityEngine;

// Token: 0x02000310 RID: 784
public class HideColliderScript : MonoBehaviour
{
	// Token: 0x06001845 RID: 6213 RVA: 0x000EA204 File Offset: 0x000E8404
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 11)
		{
			GameObject gameObject = other.gameObject.transform.root.gameObject;
			if (!gameObject.GetComponent<StudentScript>().Alive)
			{
				this.Corpse = gameObject.GetComponent<RagdollScript>();
				if (!this.Corpse.Hidden && !this.Corpse.Concealed)
				{
					this.Corpse.HideCollider = this.MyCollider;
					this.Corpse.Police.HiddenCorpses++;
					this.Corpse.Hidden = true;
				}
			}
		}
	}

	// Token: 0x040023F5 RID: 9205
	public RagdollScript Corpse;

	// Token: 0x040023F6 RID: 9206
	public Collider MyCollider;
}
