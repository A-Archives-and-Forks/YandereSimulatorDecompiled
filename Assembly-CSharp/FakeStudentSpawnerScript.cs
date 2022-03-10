﻿using System;
using UnityEngine;

// Token: 0x020002C4 RID: 708
public class FakeStudentSpawnerScript : MonoBehaviour
{
	// Token: 0x0600148D RID: 5261 RVA: 0x000C8E58 File Offset: 0x000C7058
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

	// Token: 0x04001FDA RID: 8154
	public Transform FakeStudentParent;

	// Token: 0x04001FDB RID: 8155
	public GameObject NewStudent;

	// Token: 0x04001FDC RID: 8156
	public GameObject FakeFemale;

	// Token: 0x04001FDD RID: 8157
	public GameObject FakeMale;

	// Token: 0x04001FDE RID: 8158
	public GameObject Student;

	// Token: 0x04001FDF RID: 8159
	public bool AlreadySpawned;

	// Token: 0x04001FE0 RID: 8160
	public int CurrentFloor;

	// Token: 0x04001FE1 RID: 8161
	public int CurrentRow;

	// Token: 0x04001FE2 RID: 8162
	public int FloorLimit;

	// Token: 0x04001FE3 RID: 8163
	public int RowLimit;

	// Token: 0x04001FE4 RID: 8164
	public int StudentIDLimit;

	// Token: 0x04001FE5 RID: 8165
	public int StudentID;

	// Token: 0x04001FE6 RID: 8166
	public int Spawned;

	// Token: 0x04001FE7 RID: 8167
	public int Height;

	// Token: 0x04001FE8 RID: 8168
	public int NESW;

	// Token: 0x04001FE9 RID: 8169
	public int ID;

	// Token: 0x04001FEA RID: 8170
	public GameObject[] SuspiciousObjects;
}
