﻿using System;
using UnityEngine;

// Token: 0x020002C2 RID: 706
public class FalconPunchScript : MonoBehaviour
{
	// Token: 0x0600147C RID: 5244 RVA: 0x000C7CAB File Offset: 0x000C5EAB
	private void Start()
	{
		if (this.Mecha)
		{
			this.MyRigidbody.AddForce(base.transform.forward * this.Speed * 10f);
		}
	}

	// Token: 0x0600147D RID: 5245 RVA: 0x000C7CE0 File Offset: 0x000C5EE0
	private void Update()
	{
		if (!this.IgnoreTime)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > this.TimeLimit)
			{
				this.MyCollider.enabled = false;
			}
		}
		if (this.Shipgirl)
		{
			this.MyRigidbody.AddForce(base.transform.forward * this.Speed);
		}
	}

	// Token: 0x0600147E RID: 5246 RVA: 0x000C7D4C File Offset: 0x000C5F4C
	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("A punch collided with something.");
		if (other.gameObject.layer == 9)
		{
			Debug.Log("A punch collided with something on the Characters layer.");
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null)
			{
				Debug.Log("A punch collided with a student.");
				if (component.StudentID > 1)
				{
					Debug.Log("A punch collided with a student and killed them.");
					UnityEngine.Object.Instantiate<GameObject>(this.FalconExplosion, component.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
					component.DeathType = DeathType.EasterEgg;
					component.BecomeRagdoll();
					Rigidbody rigidbody = component.Ragdoll.AllRigidbodies[0];
					rigidbody.isKinematic = false;
					Vector3 vector = rigidbody.transform.position - component.Yandere.transform.position;
					if (this.Falcon)
					{
						rigidbody.AddForce(vector * this.Strength);
					}
					else if (this.Bancho)
					{
						rigidbody.AddForce(vector.x * this.Strength, 5000f, vector.z * this.Strength);
					}
					else
					{
						rigidbody.AddForce(vector.x * this.Strength, 10000f, vector.z * this.Strength);
					}
				}
			}
		}
		if (this.Destructive && other.gameObject.layer != 2 && other.gameObject.layer != 8 && other.gameObject.layer != 9 && other.gameObject.layer != 13 && other.gameObject.layer != 17)
		{
			GameObject gameObject = null;
			StudentScript component2 = other.gameObject.transform.root.GetComponent<StudentScript>();
			if (component2 != null)
			{
				if (component2.StudentID <= 1)
				{
					gameObject = component2.gameObject;
				}
			}
			else
			{
				gameObject = other.gameObject;
			}
			if (gameObject != null)
			{
				UnityEngine.Object.Instantiate<GameObject>(this.FalconExplosion, base.transform.position + new Vector3(0f, 0f, 0f), Quaternion.identity);
				UnityEngine.Object.Destroy(gameObject);
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}
	}

	// Token: 0x04001FBD RID: 8125
	public GameObject FalconExplosion;

	// Token: 0x04001FBE RID: 8126
	public Rigidbody MyRigidbody;

	// Token: 0x04001FBF RID: 8127
	public Collider MyCollider;

	// Token: 0x04001FC0 RID: 8128
	public float Strength = 100f;

	// Token: 0x04001FC1 RID: 8129
	public float Speed = 100f;

	// Token: 0x04001FC2 RID: 8130
	public bool Destructive;

	// Token: 0x04001FC3 RID: 8131
	public bool IgnoreTime;

	// Token: 0x04001FC4 RID: 8132
	public bool Shipgirl;

	// Token: 0x04001FC5 RID: 8133
	public bool Bancho;

	// Token: 0x04001FC6 RID: 8134
	public bool Falcon;

	// Token: 0x04001FC7 RID: 8135
	public bool Mecha;

	// Token: 0x04001FC8 RID: 8136
	public float TimeLimit = 0.5f;

	// Token: 0x04001FC9 RID: 8137
	public float Timer;
}
