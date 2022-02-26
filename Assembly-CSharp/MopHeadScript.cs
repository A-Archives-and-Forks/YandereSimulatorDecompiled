﻿using System;
using UnityEngine;

// Token: 0x0200036D RID: 877
public class MopHeadScript : MonoBehaviour
{
	// Token: 0x060019BD RID: 6589 RVA: 0x0010748C File Offset: 0x0010568C
	private void OnTriggerStay(Collider other)
	{
		if (this.Mop.Bloodiness < 100f && other.tag == "Puddle")
		{
			this.BloodPool = other.gameObject.GetComponent<BloodPoolScript>();
			if (this.BloodPool != null)
			{
				this.BloodPool.Grow = false;
				other.transform.localScale -= new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
				if (this.BloodPool.Blood)
				{
					this.Mop.Bloodiness += Time.deltaTime * 10f;
					this.Mop.UpdateBlood();
				}
				if (other.transform.localScale.x < 0.1f)
				{
					UnityEngine.Object.Destroy(other.gameObject);
					return;
				}
			}
			else
			{
				UnityEngine.Object.Destroy(other.gameObject);
			}
		}
	}

	// Token: 0x04002935 RID: 10549
	public BloodPoolScript BloodPool;

	// Token: 0x04002936 RID: 10550
	public MopScript Mop;
}
