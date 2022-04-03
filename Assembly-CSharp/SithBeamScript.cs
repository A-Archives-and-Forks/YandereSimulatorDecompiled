﻿using System;
using UnityEngine;

// Token: 0x0200042D RID: 1069
public class SithBeamScript : MonoBehaviour
{
	// Token: 0x06001CC7 RID: 7367 RVA: 0x00155DB0 File Offset: 0x00153FB0
	private void Update()
	{
		if (this.Projectile)
		{
			base.transform.Translate(base.transform.forward * Time.deltaTime * 15f, Space.World);
		}
		this.Lifespan = Mathf.MoveTowards(this.Lifespan, 0f, Time.deltaTime);
		if (this.Lifespan == 0f)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x06001CC8 RID: 7368 RVA: 0x00155E24 File Offset: 0x00154024
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == 9)
		{
			StudentScript component = other.gameObject.GetComponent<StudentScript>();
			if (component != null && component.StudentID > 1)
			{
				AudioSource.PlayClipAtPoint(this.Hit, base.transform.position);
				this.RandomNumber = UnityEngine.Random.Range(0, 3);
				if (this.MalePain.Length != 0)
				{
					if (component.Male)
					{
						AudioSource.PlayClipAtPoint(this.MalePain[this.RandomNumber], base.transform.position);
					}
					else
					{
						AudioSource.PlayClipAtPoint(this.FemalePain[this.RandomNumber], base.transform.position);
					}
				}
				UnityEngine.Object.Instantiate<GameObject>(this.BloodEffect, component.transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
				component.Health -= this.Damage;
				component.HealthBar.transform.parent.gameObject.SetActive(true);
				component.HealthBar.transform.localScale = new Vector3(component.Health / 100f, 1f, 1f);
				component.Character.transform.localScale = new Vector3(component.Character.transform.localScale.x * -1f, component.Character.transform.localScale.y, component.Character.transform.localScale.z);
				if (component.Health <= 0f)
				{
					component.DeathType = DeathType.EasterEgg;
					component.HealthBar.transform.parent.gameObject.SetActive(false);
					component.BecomeRagdoll();
					component.Ragdoll.AllRigidbodies[0].isKinematic = false;
				}
				else
				{
					component.CharacterAnimation[component.SithReactAnim].time = 0f;
					component.CharacterAnimation.Play(component.SithReactAnim);
					component.Pathfinding.canSearch = false;
					component.Pathfinding.canMove = false;
					component.HitReacting = true;
					component.Routine = false;
					component.Fleeing = false;
				}
				if (this.Projectile)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
		}
	}

	// Token: 0x040033C6 RID: 13254
	public GameObject BloodEffect;

	// Token: 0x040033C7 RID: 13255
	public Collider MyCollider;

	// Token: 0x040033C8 RID: 13256
	public float Damage = 10f;

	// Token: 0x040033C9 RID: 13257
	public float Lifespan;

	// Token: 0x040033CA RID: 13258
	public int RandomNumber;

	// Token: 0x040033CB RID: 13259
	public AudioClip Hit;

	// Token: 0x040033CC RID: 13260
	public AudioClip[] FemalePain;

	// Token: 0x040033CD RID: 13261
	public AudioClip[] MalePain;

	// Token: 0x040033CE RID: 13262
	public bool Projectile;
}
