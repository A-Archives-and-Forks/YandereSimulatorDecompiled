﻿using System;
using UnityEngine;

// Token: 0x02000359 RID: 857
public class LowPolyStudentScript : MonoBehaviour
{
	// Token: 0x0600197E RID: 6526 RVA: 0x00102893 File Offset: 0x00100A93
	private void Start()
	{
		if (this.Student.StudentManager == null)
		{
			base.enabled = false;
		}
	}

	// Token: 0x0600197F RID: 6527 RVA: 0x001028B0 File Offset: 0x00100AB0
	private void Update()
	{
		if ((float)this.Student.StudentManager.LowDetailThreshold > 0f)
		{
			if (this.Student.Prompt.DistanceSqr > (float)this.Student.StudentManager.LowDetailThreshold)
			{
				if (!this.MyMesh.enabled)
				{
					this.Student.MyRenderer.enabled = false;
					this.MyMesh.enabled = true;
					return;
				}
			}
			else if (this.MyMesh.enabled)
			{
				if (!(this.Student.EightiesTeacherAttacher != null) || !this.Student.EightiesTeacherAttacher.activeInHierarchy || this.Student.StudentID == 90)
				{
					this.Student.MyRenderer.enabled = true;
				}
				this.MyMesh.enabled = false;
				return;
			}
		}
		else if (this.MyMesh.enabled)
		{
			this.Student.MyRenderer.enabled = true;
			this.MyMesh.enabled = false;
		}
	}

	// Token: 0x0400289C RID: 10396
	public StudentScript Student;

	// Token: 0x0400289D RID: 10397
	public Renderer TeacherMesh;

	// Token: 0x0400289E RID: 10398
	public Renderer MyMesh;
}
