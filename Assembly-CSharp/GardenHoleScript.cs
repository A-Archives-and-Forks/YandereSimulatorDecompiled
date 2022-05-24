﻿using System;
using UnityEngine;

// Token: 0x020002DB RID: 731
public class GardenHoleScript : MonoBehaviour
{
	// Token: 0x060014DD RID: 5341 RVA: 0x000CDF68 File Offset: 0x000CC168
	private void Start()
	{
		if (SchoolGlobals.GetGardenGraveOccupied(this.ID))
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			base.enabled = false;
		}
	}

	// Token: 0x060014DE RID: 5342 RVA: 0x000CDF98 File Offset: 0x000CC198
	private void Update()
	{
		if (this.Prompt.DistanceSqr < 10f)
		{
			if (this.Yandere.Armed)
			{
				if (this.Yandere.EquippedWeapon.WeaponID == 10)
				{
					this.Prompt.HideButton[0] = false;
				}
				else if (this.Prompt.enabled)
				{
					this.Prompt.HideButton[0] = true;
				}
			}
			else if (this.Prompt.enabled)
			{
				this.Prompt.HideButton[0] = true;
			}
		}
		else if (this.Prompt.enabled)
		{
			this.Prompt.HideButton[0] = true;
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			this.Prompt.Circle[0].fillAmount = 1f;
			if (!this.Yandere.Chased && this.Yandere.Chasers == 0)
			{
				foreach (string name in this.Yandere.ArmedAnims)
				{
					this.Yandere.CharacterAnimation[name].weight = 0f;
				}
				this.Yandere.transform.rotation = Quaternion.LookRotation(new Vector3(base.transform.position.x, this.Yandere.transform.position.y, base.transform.position.z) - this.Yandere.transform.position);
				this.Yandere.RPGCamera.transform.eulerAngles = this.Yandere.DigSpot.eulerAngles;
				this.Yandere.RPGCamera.transform.position = this.Yandere.DigSpot.position;
				this.Yandere.EquippedWeapon.gameObject.SetActive(false);
				this.Yandere.CharacterAnimation["f02_shovelBury_00"].time = 0f;
				this.Yandere.CharacterAnimation["f02_shovelDig_00"].time = 0f;
				this.Yandere.FloatingShovel.SetActive(true);
				this.Yandere.RPGCamera.enabled = false;
				this.Yandere.CanMove = false;
				this.Yandere.DigPhase = 1;
				this.Carrots.SetActive(false);
				this.Prompt.Circle[0].fillAmount = 1f;
				if (!this.Dug)
				{
					this.Yandere.FloatingShovel.GetComponent<Animation>()["Dig"].time = 0f;
					this.Yandere.FloatingShovel.GetComponent<Animation>().Play("Dig");
					this.Yandere.Character.GetComponent<Animation>().Play("f02_shovelDig_00");
					this.Yandere.Digging = true;
					this.Prompt.Label[0].text = "     Fill";
					this.MyCollider.isTrigger = true;
					this.MyMesh.mesh = this.HoleMesh;
					this.Pile.SetActive(true);
					this.Dug = true;
				}
				else
				{
					this.Yandere.FloatingShovel.GetComponent<Animation>()["Bury"].time = 0f;
					this.Yandere.FloatingShovel.GetComponent<Animation>().Play("Bury");
					this.Yandere.CharacterAnimation.Play("f02_shovelBury_00");
					this.Yandere.Burying = true;
					this.Prompt.Label[0].text = "     Dig";
					this.MyCollider.isTrigger = false;
					this.MyMesh.mesh = this.MoundMesh;
					this.Pile.SetActive(false);
					this.Dug = false;
				}
				if (this.Bury)
				{
					this.Yandere.Police.Corpses--;
					if (this.Yandere.Police.SuicideScene && this.Yandere.Police.Corpses == 1)
					{
						this.Yandere.Police.MurderScene = false;
					}
					if (this.Yandere.Police.Corpses == 0)
					{
						this.Yandere.Police.MurderScene = false;
					}
					this.VictimID = this.Corpse.StudentID;
					this.Corpse.Remove();
					if (this.Corpse.StudentID == this.Yandere.StudentManager.RivalID)
					{
						Debug.Log("Just buried Osana's corpse.");
						this.Yandere.Police.EndOfDay.RivalBuried = true;
					}
					this.Prompt.Hide();
					this.Prompt.enabled = false;
					base.enabled = false;
					this.Prompt.Yandere.StudentManager.UpdateStudents(0);
				}
			}
		}
	}

	// Token: 0x060014DF RID: 5343 RVA: 0x000CE498 File Offset: 0x000CC698
	private void OnTriggerEnter(Collider other)
	{
		if (this.Dug && other.gameObject.layer == 11)
		{
			this.Prompt.Label[0].text = "     Bury";
			this.Corpse = other.transform.root.gameObject.GetComponent<RagdollScript>();
			this.Bury = true;
		}
	}

	// Token: 0x060014E0 RID: 5344 RVA: 0x000CE4F5 File Offset: 0x000CC6F5
	private void OnTriggerExit(Collider other)
	{
		if (this.Dug && other.gameObject.layer == 11)
		{
			this.Prompt.Label[0].text = "     Fill";
			this.Corpse = null;
			this.Bury = false;
		}
	}

	// Token: 0x060014E1 RID: 5345 RVA: 0x000CE533 File Offset: 0x000CC733
	public void EndOfDayCheck()
	{
		if (this.VictimID > 0)
		{
			StudentGlobals.SetStudentMissing(this.VictimID, true);
			SchoolGlobals.SetGardenGraveOccupied(this.ID, true);
		}
	}

	// Token: 0x040020DF RID: 8415
	public YandereScript Yandere;

	// Token: 0x040020E0 RID: 8416
	public RagdollScript Corpse;

	// Token: 0x040020E1 RID: 8417
	public PromptScript Prompt;

	// Token: 0x040020E2 RID: 8418
	public Collider MyCollider;

	// Token: 0x040020E3 RID: 8419
	public MeshFilter MyMesh;

	// Token: 0x040020E4 RID: 8420
	public GameObject Carrots;

	// Token: 0x040020E5 RID: 8421
	public GameObject Pile;

	// Token: 0x040020E6 RID: 8422
	public Mesh MoundMesh;

	// Token: 0x040020E7 RID: 8423
	public Mesh HoleMesh;

	// Token: 0x040020E8 RID: 8424
	public bool Bury;

	// Token: 0x040020E9 RID: 8425
	public bool Dug;

	// Token: 0x040020EA RID: 8426
	public int VictimID;

	// Token: 0x040020EB RID: 8427
	public int ID;
}
