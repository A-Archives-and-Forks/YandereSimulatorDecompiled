﻿using System;
using UnityEngine;

// Token: 0x0200047E RID: 1150
public class TornadoScript : MonoBehaviour
{
	// Token: 0x06001EDD RID: 7901 RVA: 0x001B2448 File Offset: 0x001B0648
	private void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > 0.5f)
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y + Time.deltaTime, base.transform.position.z);
			this.MyCollider.enabled = true;
		}
	}

	// Token: 0x06001EDE RID: 7902 RVA: 0x001B24C8 File Offset: 0x001B06C8
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null && component.StudentID > 1)
			{
				this.Scream = UnityEngine.Object.Instantiate<GameObject>(component.Male ? this.MaleBloodyScream : this.FemaleBloodyScream, component.transform.position + Vector3.up, Quaternion.identity);
				this.Scream.transform.parent = component.HipCollider.transform;
				this.Scream.transform.localPosition = Vector3.zero;
				component.DeathType = DeathType.EasterEgg;
				component.BecomeRagdoll();
				Rigidbody rigidbody = component.Ragdoll.AllRigidbodies[0];
				rigidbody.isKinematic = false;
				rigidbody.AddForce(Vector3.up * this.Strength);
			}
		}
	}

	// Token: 0x0400402D RID: 16429
	public GameObject FemaleBloodyScream;

	// Token: 0x0400402E RID: 16430
	public GameObject MaleBloodyScream;

	// Token: 0x0400402F RID: 16431
	public GameObject Scream;

	// Token: 0x04004030 RID: 16432
	public Collider MyCollider;

	// Token: 0x04004031 RID: 16433
	public float Strength = 10000f;

	// Token: 0x04004032 RID: 16434
	public float Timer;
}
