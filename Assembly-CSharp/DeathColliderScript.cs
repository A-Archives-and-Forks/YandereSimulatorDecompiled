﻿using System;
using UnityEngine;

// Token: 0x02000273 RID: 627
public class DeathColliderScript : MonoBehaviour
{
	// Token: 0x06001357 RID: 4951 RVA: 0x000AEE94 File Offset: 0x000AD094
	private void OnTriggerEnter(Collider other)
	{
		StudentScript component = other.gameObject.GetComponent<StudentScript>();
		if (component != null)
		{
			Debug.Log("Crushing a student.");
			if (component.ReturningMisplacedWeapon)
			{
				component.DropMisplacedWeapon();
			}
			component.DeathType = DeathType.Weight;
			component.BecomeRagdoll();
			component.Ragdoll.DisableRigidbodies();
			component.CharacterAnimation.enabled = true;
			component.CharacterAnimation.cullingType = AnimationCullingType.AlwaysAnimate;
			if (!component.Male)
			{
				component.CharacterAnimation.Play("f02_crushed_00");
			}
			else
			{
				component.CharacterAnimation.Play("crushed_00");
			}
			component.transform.position = new Vector3(-28.78f, 100f, 10.386f);
			component.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
			component.MapMarker.gameObject.SetActive(false);
			this.GenericPrompt.CrushedStudent = component;
			return;
		}
		if (other.gameObject.layer == 15 && other.gameObject.name == "Radio")
		{
			other.gameObject.GetComponent<RadioScript>().TurnOff();
		}
	}

	// Token: 0x04001C1F RID: 7199
	public GenericPromptScript GenericPrompt;

	// Token: 0x04001C20 RID: 7200
	public AudioSource MyAudio;

	// Token: 0x04001C21 RID: 7201
	public float Force;
}
