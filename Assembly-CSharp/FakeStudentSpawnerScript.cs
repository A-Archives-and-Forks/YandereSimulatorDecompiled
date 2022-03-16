﻿using System;
using UnityEngine;

// Token: 0x020002C4 RID: 708
public class FakeStudentSpawnerScript : MonoBehaviour
{
	// Token: 0x06001490 RID: 5264 RVA: 0x000C92C8 File Offset: 0x000C74C8
	public void Spawn()
	{
		if (!this.AlreadySpawned)
		{
			this.Student = this.FakeFemale;
			this.NESW = 1;
			while (this.Spawned < 100)
			{
				if (this.NESW == 1)
				{
					this.NewStudent = UnityEngine.Object.Instantiate<GameObject>(this.Student, new Vector3(UnityEngine.Random.Range(-21f, 21f), (float)this.Height, UnityEngine.Random.Range(21f, 19f)), Quaternion.identity);
				}
				else if (this.NESW == 2)
				{
					this.NewStudent = UnityEngine.Object.Instantiate<GameObject>(this.Student, new Vector3(UnityEngine.Random.Range(19f, 21f), (float)this.Height, UnityEngine.Random.Range(29f, -37f)), Quaternion.identity);
				}
				else if (this.NESW == 3)
				{
					this.NewStudent = UnityEngine.Object.Instantiate<GameObject>(this.Student, new Vector3(UnityEngine.Random.Range(-21f, 21f), (float)this.Height, UnityEngine.Random.Range(-21f, -19f)), Quaternion.identity);
				}
				else if (this.NESW == 4)
				{
					this.NewStudent = UnityEngine.Object.Instantiate<GameObject>(this.Student, new Vector3(UnityEngine.Random.Range(-19f, -21f), (float)this.Height, UnityEngine.Random.Range(29f, -37f)), Quaternion.identity);
				}
				this.StudentID++;
				this.NewStudent.GetComponent<PlaceholderStudentScript>().FakeStudentSpawner = this;
				this.NewStudent.GetComponent<PlaceholderStudentScript>().StudentID = this.StudentID;
				this.NewStudent.GetComponent<PlaceholderStudentScript>().NESW = this.NESW;
				this.NewStudent.transform.parent = this.FakeStudentParent;
				this.CurrentFloor++;
				this.CurrentRow++;
				this.Spawned++;
				if (this.CurrentFloor == this.FloorLimit)
				{
					this.CurrentFloor = 0;
					this.Height += 4;
				}
				if (this.CurrentRow == this.RowLimit)
				{
					this.CurrentRow = 0;
					this.NESW++;
					if (this.NESW > 4)
					{
						this.NESW = 1;
					}
				}
				this.Student = ((this.Student == this.FakeFemale) ? this.FakeMale : this.FakeFemale);
			}
			this.StudentIDLimit = this.StudentID;
			this.StudentID = 1;
			this.AlreadySpawned = true;
			return;
		}
		this.FakeStudentParent.gameObject.SetActive(!this.FakeStudentParent.gameObject.activeInHierarchy);
	}

	// Token: 0x04001FEA RID: 8170
	public Transform FakeStudentParent;

	// Token: 0x04001FEB RID: 8171
	public GameObject NewStudent;

	// Token: 0x04001FEC RID: 8172
	public GameObject FakeFemale;

	// Token: 0x04001FED RID: 8173
	public GameObject FakeMale;

	// Token: 0x04001FEE RID: 8174
	public GameObject Student;

	// Token: 0x04001FEF RID: 8175
	public bool AlreadySpawned;

	// Token: 0x04001FF0 RID: 8176
	public int CurrentFloor;

	// Token: 0x04001FF1 RID: 8177
	public int CurrentRow;

	// Token: 0x04001FF2 RID: 8178
	public int FloorLimit;

	// Token: 0x04001FF3 RID: 8179
	public int RowLimit;

	// Token: 0x04001FF4 RID: 8180
	public int StudentIDLimit;

	// Token: 0x04001FF5 RID: 8181
	public int StudentID;

	// Token: 0x04001FF6 RID: 8182
	public int Spawned;

	// Token: 0x04001FF7 RID: 8183
	public int Height;

	// Token: 0x04001FF8 RID: 8184
	public int NESW;

	// Token: 0x04001FF9 RID: 8185
	public int ID;

	// Token: 0x04001FFA RID: 8186
	public GameObject[] SuspiciousObjects;
}
