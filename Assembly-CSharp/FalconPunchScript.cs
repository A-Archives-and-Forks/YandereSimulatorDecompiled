﻿using System;
using UnityEngine;

// Token: 0x020002C4 RID: 708
public class FalconPunchScript : MonoBehaviour
{
	// Token: 0x06001486 RID: 5254 RVA: 0x000C86E3 File Offset: 0x000C68E3
	private void Start()
	{
		if (this.Mecha)
		{
			this.MyRigidbody.AddForce(base.transform.forward * this.Speed * 10f);
		}
	}

	// Token: 0x06001487 RID: 5255 RVA: 0x000C8718 File Offset: 0x000C6918
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

	// Token: 0x06001488 RID: 5256 RVA: 0x000C8784 File Offset: 0x000C6984
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

	// Token: 0x04001FD3 RID: 8147
	public GameObject FalconExplosion;

	// Token: 0x04001FD4 RID: 8148
	public Rigidbody MyRigidbody;

	// Token: 0x04001FD5 RID: 8149
	public Collider MyCollider;

	// Token: 0x04001FD6 RID: 8150
	public float Strength = 100f;

	// Token: 0x04001FD7 RID: 8151
	public float Speed = 100f;

	// Token: 0x04001FD8 RID: 8152
	public bool Destructive;

	// Token: 0x04001FD9 RID: 8153
	public bool IgnoreTime;

	// Token: 0x04001FDA RID: 8154
	public bool Shipgirl;

	// Token: 0x04001FDB RID: 8155
	public bool Bancho;

	// Token: 0x04001FDC RID: 8156
	public bool Falcon;

	// Token: 0x04001FDD RID: 8157
	public bool Mecha;

	// Token: 0x04001FDE RID: 8158
	public float TimeLimit = 0.5f;

	// Token: 0x04001FDF RID: 8159
	public float Timer;
}
