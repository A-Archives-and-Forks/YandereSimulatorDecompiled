﻿using System;
using UnityEngine;

// Token: 0x0200030E RID: 782
public class HairBladeScript : MonoBehaviour
{
	// Token: 0x06001855 RID: 6229 RVA: 0x000E713D File Offset: 0x000E533D
	private void Update()
	{
	}

	// Token: 0x06001856 RID: 6230 RVA: 0x000E7140 File Offset: 0x000E5340
	private void OnTriggerEnter(Collider other)
	{
		GameObject gameObject = other.gameObject.transform.root.gameObject;
		if (gameObject.GetComponent<StudentScript>() != null)
		{
			this.Student = gameObject.GetComponent<StudentScript>();
			if (this.Student.StudentID != 1 && this.Student.Alive)
			{
				this.Student.DeathType = DeathType.EasterEgg;
				UnityEngine.Object.Instantiate<GameObject>(this.Student.Male ? this.MaleBloodyScream : this.FemaleBloodyScream, this.Student.transform.position + Vector3.up, Quaternion.identity);
				this.Student.BecomeRagdoll();
				this.Student.Ragdoll.Dismember();
				base.GetComponent<AudioSource>().Play();
			}
		}
	}

	// Token: 0x04002375 RID: 9077
	public GameObject FemaleBloodyScream;

	// Token: 0x04002376 RID: 9078
	public GameObject MaleBloodyScream;

	// Token: 0x04002377 RID: 9079
	public Vector3 PreviousPosition;

	// Token: 0x04002378 RID: 9080
	public Collider MyCollider;

	// Token: 0x04002379 RID: 9081
	public float Timer;

	// Token: 0x0400237A RID: 9082
	public StudentScript Student;
}
