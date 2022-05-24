﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x020000EB RID: 235
public class BloodPoolSpawnerScript : MonoBehaviour
{
	// Token: 0x06000A3E RID: 2622 RVA: 0x0005B224 File Offset: 0x00059424
	public void Start()
	{
		if (SceneManager.GetActiveScene().name == "SchoolScene")
		{
			this.PoolsSpawned = this.Ragdoll.Student.BloodPoolsSpawned;
			if (this.StudentManager == null)
			{
				this.StudentManager = this.Ragdoll.Student.StudentManager;
			}
			this.GardenArea = this.StudentManager.GardenArea;
			this.TreeArea = this.StudentManager.TreeArea;
			this.NEStairs = this.StudentManager.NEStairs;
			this.NWStairs = this.StudentManager.NWStairs;
			this.SEStairs = this.StudentManager.SEStairs;
			this.SWStairs = this.StudentManager.SWStairs;
		}
		this.BloodParent = GameObject.Find("BloodParent").transform;
		this.Positions = new Vector3[5];
		this.Positions[0] = Vector3.zero;
		this.Positions[1] = new Vector3(0.5f, 0.012f, 0f);
		this.Positions[2] = new Vector3(-0.5f, 0.012f, 0f);
		this.Positions[3] = new Vector3(0f, 0.012f, 0.5f);
		this.Positions[4] = new Vector3(0f, 0.012f, -0.5f);
	}

	// Token: 0x06000A3F RID: 2623 RVA: 0x0005B39F File Offset: 0x0005959F
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.LastBloodPool = other.gameObject;
			this.NearbyBlood++;
		}
	}

	// Token: 0x06000A40 RID: 2624 RVA: 0x0005B3D2 File Offset: 0x000595D2
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.NearbyBlood--;
		}
	}

	// Token: 0x06000A41 RID: 2625 RVA: 0x0005B3FC File Offset: 0x000595FC
	private void Update()
	{
		if (!this.Falling)
		{
			if (this.MyCollider.enabled)
			{
				if (this.Timer > 0f)
				{
					this.Timer -= Time.deltaTime;
				}
				this.SetHeight();
				Vector3 position = base.transform.position;
				if (SceneManager.GetActiveScene().name == "SchoolScene")
				{
					this.CanSpawn = (!this.GardenArea.bounds.Contains(position) && !this.TreeArea.bounds.Contains(position) && !this.NEStairs.bounds.Contains(position) && !this.NWStairs.bounds.Contains(position) && !this.SEStairs.bounds.Contains(position) && !this.SWStairs.bounds.Contains(position));
				}
				if (this.CanSpawn && position.y < this.Height + 0.33333334f)
				{
					if (this.NearbyBlood > 0 && this.LastBloodPool == null)
					{
						this.NearbyBlood--;
					}
					if (this.NearbyBlood < 1 && this.Timer <= 0f)
					{
						this.Timer = 0.1f;
						GameObject gameObject = null;
						if (this.PoolsSpawned < 10)
						{
							gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BloodPool, new Vector3(position.x, this.Height + 0.012f, position.z), Quaternion.identity);
							gameObject.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
							gameObject.transform.parent = this.BloodParent;
							gameObject.GetComponent<BloodPoolScript>().StudentBloodID = this.Ragdoll.StudentID;
							this.PoolsSpawned++;
							this.Ragdoll.Student.BloodPoolsSpawned++;
						}
						else if (this.PoolsSpawned < 20)
						{
							gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BloodPool, new Vector3(position.x, this.Height + 0.012f, position.z), Quaternion.identity);
							gameObject.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
							gameObject.transform.parent = this.BloodParent;
							gameObject.GetComponent<BloodPoolScript>().StudentBloodID = this.Ragdoll.StudentID;
							this.PoolsSpawned++;
							this.Ragdoll.Student.BloodPoolsSpawned++;
							gameObject.GetComponent<BloodPoolScript>().TargetSize = 1f - (float)(this.PoolsSpawned - 10) * 0.1f;
							if (this.PoolsSpawned == 20)
							{
								base.gameObject.SetActive(false);
							}
						}
						if (gameObject != null && (this.StudentManager.EastBathroomArea.bounds.Contains(base.transform.position) || this.StudentManager.WestBathroomArea.bounds.Contains(base.transform.position)))
						{
							gameObject.GetComponent<BloodPoolScript>().TargetSize = gameObject.GetComponent<BloodPoolScript>().TargetSize * 0.5f;
							return;
						}
					}
				}
			}
		}
		else
		{
			this.FallTimer += Time.deltaTime;
			if (this.FallTimer > 10f)
			{
				this.Falling = false;
			}
		}
	}

	// Token: 0x06000A42 RID: 2626 RVA: 0x0005B7A8 File Offset: 0x000599A8
	public void SpawnBigPool()
	{
		this.SetHeight();
		Vector3 a = new Vector3(this.Hips.position.x, this.Height + 0.012f, this.Hips.position.z);
		for (int i = 0; i < 5; i++)
		{
			if (this.Positions.Length == 0)
			{
				this.Start();
			}
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BloodPool, a + this.Positions[i], Quaternion.identity);
			gameObject.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
			gameObject.transform.parent = this.BloodParent;
			gameObject.GetComponent<BloodPoolScript>().StudentBloodID = this.Ragdoll.StudentID;
		}
	}

	// Token: 0x06000A43 RID: 2627 RVA: 0x0005B880 File Offset: 0x00059A80
	private void SpawnRow(Transform Location)
	{
		Vector3 position = Location.position;
		Vector3 forward = Location.forward;
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BloodPool, position + forward * 2f, Quaternion.identity);
		gameObject.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
		gameObject.transform.parent = this.BloodParent;
		gameObject.GetComponent<BloodPoolScript>().StudentBloodID = this.Ragdoll.StudentID;
		GameObject gameObject2 = UnityEngine.Object.Instantiate<GameObject>(this.BloodPool, position + forward * 2.5f, Quaternion.identity);
		gameObject2.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
		gameObject2.transform.parent = this.BloodParent;
		gameObject2.GetComponent<BloodPoolScript>().StudentBloodID = this.Ragdoll.StudentID;
		GameObject gameObject3 = UnityEngine.Object.Instantiate<GameObject>(this.BloodPool, position + forward * 3f, Quaternion.identity);
		gameObject3.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
		gameObject3.transform.parent = this.BloodParent;
		gameObject3.GetComponent<BloodPoolScript>().StudentBloodID = this.Ragdoll.StudentID;
	}

	// Token: 0x06000A44 RID: 2628 RVA: 0x0005B9EC File Offset: 0x00059BEC
	public void SpawnPool(Transform Location)
	{
		GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.BloodPool, Location.position + Location.forward + new Vector3(0f, 0.0001f, 0f), Quaternion.identity);
		gameObject.transform.localEulerAngles = new Vector3(90f, UnityEngine.Random.Range(0f, 360f), 0f);
		gameObject.transform.parent = this.BloodParent;
		gameObject.GetComponent<BloodPoolScript>().StudentBloodID = this.Ragdoll.StudentID;
	}

	// Token: 0x06000A45 RID: 2629 RVA: 0x0005BA84 File Offset: 0x00059C84
	private void SetHeight()
	{
		float y = base.transform.position.y;
		if (y < 4f)
		{
			this.Height = 0f;
			return;
		}
		if (y < 8f)
		{
			this.Height = 4f;
			return;
		}
		if (y < 12f)
		{
			this.Height = 8f;
			return;
		}
		this.Height = 12f;
	}

	// Token: 0x04000BB5 RID: 2997
	public StudentManagerScript StudentManager;

	// Token: 0x04000BB6 RID: 2998
	public RagdollScript Ragdoll;

	// Token: 0x04000BB7 RID: 2999
	public GameObject LastBloodPool;

	// Token: 0x04000BB8 RID: 3000
	public GameObject BloodPool;

	// Token: 0x04000BB9 RID: 3001
	public Transform BloodParent;

	// Token: 0x04000BBA RID: 3002
	public Transform Hips;

	// Token: 0x04000BBB RID: 3003
	public Collider MyCollider;

	// Token: 0x04000BBC RID: 3004
	public Collider GardenArea;

	// Token: 0x04000BBD RID: 3005
	public Collider TreeArea;

	// Token: 0x04000BBE RID: 3006
	public Collider NEStairs;

	// Token: 0x04000BBF RID: 3007
	public Collider NWStairs;

	// Token: 0x04000BC0 RID: 3008
	public Collider SEStairs;

	// Token: 0x04000BC1 RID: 3009
	public Collider SWStairs;

	// Token: 0x04000BC2 RID: 3010
	public Vector3[] Positions;

	// Token: 0x04000BC3 RID: 3011
	public bool CanSpawn;

	// Token: 0x04000BC4 RID: 3012
	public bool Falling;

	// Token: 0x04000BC5 RID: 3013
	public int PoolsSpawned;

	// Token: 0x04000BC6 RID: 3014
	public int NearbyBlood;

	// Token: 0x04000BC7 RID: 3015
	public float FallTimer;

	// Token: 0x04000BC8 RID: 3016
	public float Height;

	// Token: 0x04000BC9 RID: 3017
	public float Timer;

	// Token: 0x04000BCA RID: 3018
	public LayerMask Mask;
}
