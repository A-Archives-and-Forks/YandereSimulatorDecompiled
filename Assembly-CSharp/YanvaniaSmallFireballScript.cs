﻿using System;
using UnityEngine;

// Token: 0x020004DF RID: 1247
public class YanvaniaSmallFireballScript : MonoBehaviour
{
	// Token: 0x060020AB RID: 8363 RVA: 0x001E00B4 File Offset: 0x001DE2B4
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "Heart")
		{
			UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
		if (other.gameObject.name == "YanmontChan")
		{
			other.gameObject.GetComponent<YanvaniaYanmontScript>().TakeDamage(10);
			UnityEngine.Object.Instantiate<GameObject>(this.Explosion, base.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04004791 RID: 18321
	public GameObject Explosion;
}
