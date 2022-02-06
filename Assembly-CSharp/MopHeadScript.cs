﻿using System;
using UnityEngine;

// Token: 0x0200036B RID: 875
public class MopHeadScript : MonoBehaviour
{
	// Token: 0x060019AD RID: 6573 RVA: 0x00106838 File Offset: 0x00104A38
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

	// Token: 0x04002920 RID: 10528
	public BloodPoolScript BloodPool;

	// Token: 0x04002921 RID: 10529
	public MopScript Mop;
}
