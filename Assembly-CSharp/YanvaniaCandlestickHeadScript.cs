﻿using System;
using UnityEngine;

// Token: 0x020004D4 RID: 1236
public class YanvaniaCandlestickHeadScript : MonoBehaviour
{
	// Token: 0x0600207F RID: 8319 RVA: 0x001DCEF8 File Offset: 0x001DB0F8
	private void Start()
	{
		Rigidbody component = base.GetComponent<Rigidbody>();
		component.AddForce(base.transform.up * 100f);
		component.AddForce(base.transform.right * 100f);
		this.Value = UnityEngine.Random.Range(-1f, 1f);
	}

	// Token: 0x06002080 RID: 8320 RVA: 0x001DCF58 File Offset: 0x001DB158
	private void Update()
	{
		this.Rotation += new Vector3(this.Value, this.Value, this.Value);
		base.transform.localEulerAngles = this.Rotation;
		if (base.transform.localPosition.y < 0.23f)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.Fire, base.transform.position, Quaternion.identity);
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x04004715 RID: 18197
	public GameObject Fire;

	// Token: 0x04004716 RID: 18198
	public Vector3 Rotation;

	// Token: 0x04004717 RID: 18199
	public float Value;
}
