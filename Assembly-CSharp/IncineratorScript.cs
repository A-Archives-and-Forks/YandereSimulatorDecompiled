﻿using System;
using UnityEngine;

// Token: 0x02000332 RID: 818
public class IncineratorScript : MonoBehaviour
{
	// Token: 0x060018D4 RID: 6356 RVA: 0x000F46E4 File Offset: 0x000F28E4
	private void Start()
	{
		this.Panel.SetActive(false);
		this.Prompt.enabled = true;
		if (!GameGlobals.Eighties && DateGlobals.Week == 2)
		{
			this.OutOfOrderSign.SetActive(true);
			this.Prompt.enabled = false;
			this.Prompt.Hide();
			base.enabled = false;
		}
		this.MyAudio = base.GetComponent<AudioSource>();
	}

	// Token: 0x060018D5 RID: 6357 RVA: 0x000F4750 File Offset: 0x000F2950
	private void Update()
	{
		if (this.Animate)
		{
			if (this.Open)
			{
				if (this.RightDoor.transform.localEulerAngles.y == 0f)
				{
					this.MyAudio.clip = this.IncineratorOpen;
					this.MyAudio.Play();
				}
				this.RightDoor.transform.localEulerAngles = new Vector3(this.RightDoor.transform.localEulerAngles.x, Mathf.Lerp(this.RightDoor.transform.localEulerAngles.y, 135f, Time.deltaTime * 5f), this.RightDoor.transform.localEulerAngles.z);
				this.LeftDoor.transform.localEulerAngles = new Vector3(this.LeftDoor.transform.localEulerAngles.x, Mathf.Lerp(this.LeftDoor.transform.localEulerAngles.y, 135f, Time.deltaTime * 5f), this.LeftDoor.transform.localEulerAngles.z);
				if (this.RightDoor.transform.localEulerAngles.y > 134f)
				{
					this.RightDoor.transform.localEulerAngles = new Vector3(this.RightDoor.transform.localEulerAngles.x, 135f, this.RightDoor.transform.localEulerAngles.z);
				}
			}
			else
			{
				this.RightDoor.transform.localEulerAngles = new Vector3(this.RightDoor.transform.localEulerAngles.x, Mathf.MoveTowards(this.RightDoor.transform.localEulerAngles.y, 0f, Time.deltaTime * 360f), this.RightDoor.transform.localEulerAngles.z);
				this.LeftDoor.transform.localEulerAngles = new Vector3(this.LeftDoor.transform.localEulerAngles.x, Mathf.MoveTowards(this.LeftDoor.transform.localEulerAngles.y, 0f, Time.deltaTime * 360f), this.LeftDoor.transform.localEulerAngles.z);
				if (this.RightDoor.transform.localEulerAngles.y < 1f)
				{
					this.MyAudio.clip = this.IncineratorClose;
					this.MyAudio.Play();
					this.Animate = false;
					this.RightDoor.transform.localEulerAngles = new Vector3(this.RightDoor.transform.localEulerAngles.x, 0f, this.RightDoor.transform.localEulerAngles.z);
					this.LeftDoor.transform.localEulerAngles = new Vector3(this.LeftDoor.transform.localEulerAngles.x, 0f, this.LeftDoor.transform.localEulerAngles.z);
				}
			}
		}
		if (this.OpenTimer > 0f)
		{
			this.OpenTimer -= Time.deltaTime;
			if (this.OpenTimer <= 1f)
			{
				this.Open = false;
			}
			if (this.OpenTimer <= 0f)
			{
				this.Prompt.enabled = true;
			}
		}
		else if (!this.Smoke.isPlaying)
		{
			this.YandereHoldingEvidence = (this.Yandere.Ragdoll != null);
			if (!this.YandereHoldingEvidence)
			{
				if (this.Yandere.PickUp != null)
				{
					this.YandereHoldingEvidence = (this.Yandere.PickUp.Evidence || this.Yandere.PickUp.Garbage);
				}
				else
				{
					this.YandereHoldingEvidence = false;
				}
			}
			if (!this.YandereHoldingEvidence)
			{
				if (this.Yandere.EquippedWeapon != null)
				{
					this.YandereHoldingEvidence = this.Yandere.EquippedWeapon.MurderWeapon;
				}
				else
				{
					this.YandereHoldingEvidence = false;
				}
			}
			if (!this.YandereHoldingEvidence)
			{
				if (!this.Prompt.HideButton[3])
				{
					this.Prompt.HideButton[3] = true;
				}
			}
			else if (this.Prompt.HideButton[3])
			{
				this.Prompt.HideButton[3] = false;
			}
			if ((this.Yandere.Chased || this.Yandere.Chasers > 0 || !this.YandereHoldingEvidence) && !this.Prompt.HideButton[3])
			{
				this.Prompt.HideButton[3] = true;
			}
			if (this.Ready)
			{
				if (!this.Smoke.isPlaying)
				{
					if (this.CannotIncinerate)
					{
						this.Prompt.HideButton[0] = true;
					}
					if (!this.CannotIncinerate && this.Prompt.HideButton[0])
					{
						this.Prompt.HideButton[0] = false;
					}
				}
				else if (!this.Prompt.HideButton[0])
				{
					this.Prompt.HideButton[0] = true;
				}
			}
		}
		if (this.Prompt.Circle[3].fillAmount == 0f)
		{
			Time.timeScale = 1f;
			if (this.Yandere.Ragdoll != null)
			{
				RagdollScript component = this.Yandere.Ragdoll.GetComponent<RagdollScript>();
				if (this.Yandere.Dragging)
				{
					this.Yandere.EmptyHands();
					component.Prompt.Circle[3].fillAmount = 0f;
				}
				this.Yandere.CharacterAnimation.CrossFade(this.Yandere.Carrying ? "f02_carryIdleA_00" : "f02_dragIdle_00");
				this.Yandere.Incinerator = this;
				this.Yandere.YandereVision = false;
				this.Yandere.CanMove = false;
				this.Yandere.Dumping = true;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.Victims++;
				this.VictimList[this.Victims] = component.StudentID;
				this.Open = true;
			}
			if (this.Yandere.PickUp != null)
			{
				Debug.Log("The " + this.Yandere.PickUp.gameObject.name + " that Yandere-chan was carrying is now being dumped into the incinerator.");
				if (this.Yandere.PickUp.BodyPart != null)
				{
					this.Limbs++;
					this.LimbList[this.Limbs] = this.Yandere.PickUp.GetComponent<BodyPartScript>().StudentID;
				}
				this.Yandere.PickUp.Incinerator = this;
				this.Yandere.PickUp.Dumped = true;
				this.Yandere.PickUp.Drop();
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.OpenTimer = 2f;
				this.Ready = true;
				this.Open = true;
			}
			WeaponScript equippedWeapon = this.Yandere.EquippedWeapon;
			if (equippedWeapon != null)
			{
				this.DestroyedEvidence++;
				this.EvidenceList[this.DestroyedEvidence] = equippedWeapon.WeaponID;
				equippedWeapon.Incinerator = this;
				equippedWeapon.Dumped = true;
				equippedWeapon.Drop();
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.OpenTimer = 2f;
				this.Ready = true;
				this.Open = true;
			}
			this.Animate = true;
		}
		if (this.Prompt.Circle[0].fillAmount == 0f)
		{
			int num = 0;
			this.ID = 1;
			while (this.ID < this.Limbs + 1)
			{
				if (this.LimbList[this.ID] == this.Yandere.StudentManager.RivalID)
				{
					num++;
					if (num == 6)
					{
						this.Yandere.StudentManager.Police.EndOfDay.RivalDismemberedAndIncinerated = true;
						Debug.Log("The player dismembered and incinerated Osana.");
					}
				}
				this.ID++;
			}
			this.Prompt.Circle[0].fillAmount = 1f;
			this.Panel.SetActive(true);
			this.Timer = 60f;
			this.MyAudio.clip = this.IncineratorActivate;
			this.MyAudio.Play();
			this.Flames.Play();
			this.Smoke.Play();
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			Debug.Log("Incinerating " + this.BloodyClothing.ToString() + " bloody clothing.");
			this.Yandere.Police.IncineratedWeapons += this.MurderWeapons;
			this.Yandere.Police.BloodyClothing -= this.BloodyClothing;
			this.Yandere.Police.BloodyWeapons -= this.MurderWeapons;
			this.Yandere.Police.BodyParts -= this.BodyParts;
			this.Yandere.Police.Corpses -= this.Corpses;
			this.Yandere.Police.RedPaintClothing -= this.ClothingWithRedPaint;
			if (this.Yandere.Police.SuicideScene && this.Yandere.Police.Corpses == 1)
			{
				this.Yandere.Police.MurderScene = false;
			}
			if (this.Yandere.Police.Corpses == 0)
			{
				this.Yandere.Police.MurderScene = false;
			}
			this.BloodyClothing = 0;
			this.MurderWeapons = 0;
			this.BodyParts = 0;
			this.Corpses = 0;
			this.ID = 0;
			while (this.ID < 101)
			{
				if (this.Yandere.StudentManager.Students[this.CorpseList[this.ID]] != null)
				{
					this.Yandere.StudentManager.Students[this.CorpseList[this.ID]].Ragdoll.Disposed = true;
					this.ConfirmedDead[this.ID] = this.CorpseList[this.ID];
					if (this.Yandere.StudentManager.Students[this.CorpseList[this.ID]].Ragdoll.Drowned)
					{
						this.Yandere.Police.DrownVictims--;
					}
				}
				this.ID++;
			}
			if (this.Yandere.StudentManager.Students[this.Yandere.StudentManager.RivalID] != null && this.Yandere.StudentManager.Students[this.Yandere.StudentManager.RivalID].Ragdoll.Disposed)
			{
				Debug.Log("Just incinerated Osana's corpse.");
				this.Yandere.StudentManager.Police.EndOfDay.RivalEliminationMethod = RivalEliminationType.Vanished;
			}
			this.Yandere.StudentManager.UpdateStudents(0);
		}
		if (this.Smoke.isPlaying)
		{
			this.Timer -= Time.deltaTime * (this.Clock.TimeSpeed / 60f);
			this.FlameSound.volume += Time.deltaTime;
			this.Circle.fillAmount = 1f - this.Timer / 60f;
			if (this.Timer <= 0f)
			{
				this.Prompt.HideButton[0] = true;
				this.Prompt.enabled = true;
				this.Panel.SetActive(false);
				this.Ready = false;
				this.Flames.Stop();
				this.Smoke.Stop();
			}
		}
		else
		{
			this.FlameSound.volume -= Time.deltaTime;
		}
		if (this.Panel.activeInHierarchy)
		{
			float num2 = (float)Mathf.CeilToInt(this.Timer * 60f);
			float num3 = Mathf.Floor(num2 / 60f);
			float num4 = (float)Mathf.RoundToInt(num2 % 60f);
			this.TimeLabel.text = string.Format("{0:00}:{1:00}", num3, num4);
		}
	}

	// Token: 0x060018D6 RID: 6358 RVA: 0x000F53D0 File Offset: 0x000F35D0
	public void SetVictimsMissing()
	{
		foreach (int num in this.ConfirmedDead)
		{
			if (num > 0)
			{
				Debug.Log("Student #" + num.ToString() + " was incinerated and is now considered ''missing'.");
				StudentGlobals.SetStudentMissing(num, true);
			}
		}
	}

	// Token: 0x060018D7 RID: 6359 RVA: 0x000F541C File Offset: 0x000F361C
	public void DumpGarbageBag(PickUpScript PickUp)
	{
		Debug.Log("A garbage bag was dumped into the incinerator!");
		this.Limbs++;
		this.LimbList[this.Limbs] = PickUp.GetComponent<BodyPartScript>().StudentID;
		PickUp.Incinerator = this;
		PickUp.Dumped = true;
		PickUp.Drop();
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.OpenTimer = 2f;
		this.Animate = true;
		this.Ready = true;
		this.Open = true;
	}

	// Token: 0x040025E1 RID: 9697
	public YandereScript Yandere;

	// Token: 0x040025E2 RID: 9698
	public PromptScript Prompt;

	// Token: 0x040025E3 RID: 9699
	public ClockScript Clock;

	// Token: 0x040025E4 RID: 9700
	public AudioClip IncineratorActivate;

	// Token: 0x040025E5 RID: 9701
	public AudioClip IncineratorClose;

	// Token: 0x040025E6 RID: 9702
	public AudioClip IncineratorOpen;

	// Token: 0x040025E7 RID: 9703
	public AudioSource FlameSound;

	// Token: 0x040025E8 RID: 9704
	public AudioSource MyAudio;

	// Token: 0x040025E9 RID: 9705
	public ParticleSystem Flames;

	// Token: 0x040025EA RID: 9706
	public ParticleSystem Smoke;

	// Token: 0x040025EB RID: 9707
	public Transform DumpPoint;

	// Token: 0x040025EC RID: 9708
	public Transform RightDoor;

	// Token: 0x040025ED RID: 9709
	public Transform LeftDoor;

	// Token: 0x040025EE RID: 9710
	public GameObject OutOfOrderSign;

	// Token: 0x040025EF RID: 9711
	public GameObject Panel;

	// Token: 0x040025F0 RID: 9712
	public UILabel TimeLabel;

	// Token: 0x040025F1 RID: 9713
	public UISprite Circle;

	// Token: 0x040025F2 RID: 9714
	public bool YandereHoldingEvidence;

	// Token: 0x040025F3 RID: 9715
	public bool ActivateAfterClosing;

	// Token: 0x040025F4 RID: 9716
	public bool CannotIncinerate;

	// Token: 0x040025F5 RID: 9717
	public bool Animate;

	// Token: 0x040025F6 RID: 9718
	public bool Ready;

	// Token: 0x040025F7 RID: 9719
	public bool Open;

	// Token: 0x040025F8 RID: 9720
	public int ClothingWithRedPaint;

	// Token: 0x040025F9 RID: 9721
	public int DestroyedEvidence;

	// Token: 0x040025FA RID: 9722
	public int BloodyClothing;

	// Token: 0x040025FB RID: 9723
	public int MurderWeapons;

	// Token: 0x040025FC RID: 9724
	public int BodyParts;

	// Token: 0x040025FD RID: 9725
	public int Corpses;

	// Token: 0x040025FE RID: 9726
	public int Victims;

	// Token: 0x040025FF RID: 9727
	public int Limbs;

	// Token: 0x04002600 RID: 9728
	public int ID;

	// Token: 0x04002601 RID: 9729
	public float OpenTimer;

	// Token: 0x04002602 RID: 9730
	public float Timer;

	// Token: 0x04002603 RID: 9731
	public int[] EvidenceList;

	// Token: 0x04002604 RID: 9732
	public int[] CorpseList;

	// Token: 0x04002605 RID: 9733
	public int[] VictimList;

	// Token: 0x04002606 RID: 9734
	public int[] LimbList;

	// Token: 0x04002607 RID: 9735
	public int[] ConfirmedDead;
}
