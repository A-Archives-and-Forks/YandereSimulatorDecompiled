﻿using System;
using Pathfinding;
using UnityEngine;

// Token: 0x020000E7 RID: 231
public class BloodCleanerScript : MonoBehaviour
{
	// Token: 0x06000A32 RID: 2610 RVA: 0x0005A4E0 File Offset: 0x000586E0
	private void Start()
	{
		if (this.Super)
		{
			Physics.IgnoreLayerCollision(11, 15, true);
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	// Token: 0x06000A33 RID: 2611 RVA: 0x0005A50C File Offset: 0x0005870C
	private void Update()
	{
		if (this.Blood < 100f)
		{
			if (this.BloodParent.childCount > 0)
			{
				this.Pathfinding.target = this.BloodParent.GetChild(0);
				this.Pathfinding.speed = 4f;
				if (this.Pathfinding.target.position.y < 4f)
				{
					this.Label.text = "1";
				}
				else if (this.Pathfinding.target.position.y < 8f)
				{
					this.Label.text = "2";
				}
				else if (this.Pathfinding.target.position.y < 12f)
				{
					this.Label.text = "3";
				}
				else
				{
					this.Label.text = "R";
				}
				if (this.Pathfinding.target != null)
				{
					this.Distance = Vector3.Distance(base.transform.position, this.Pathfinding.target.position);
					if (this.Distance >= 1f)
					{
						this.Pathfinding.speed = 4f;
						return;
					}
					this.Pathfinding.speed = 0f;
					Transform child = this.BloodParent.GetChild(0);
					if (!(child.GetComponent("BloodPoolScript") != null))
					{
						UnityEngine.Object.Destroy(child.gameObject);
						return;
					}
					child.localScale = new Vector3(child.localScale.x - Time.deltaTime, child.localScale.y - Time.deltaTime, child.localScale.z);
					this.Blood += Time.deltaTime;
					if (this.Blood >= 100f)
					{
						this.Lens.SetActive(true);
					}
					if (child.transform.localScale.x < 0.1f)
					{
						UnityEngine.Object.Destroy(child.gameObject);
						return;
					}
				}
			}
			else if (this.Super)
			{
				this.Pathfinding.target = this.Prompt.Yandere.transform;
				this.Pathfinding.speed = 4f;
			}
		}
	}

	// Token: 0x04000B85 RID: 2949
	public Transform BloodParent;

	// Token: 0x04000B86 RID: 2950
	public PromptScript Prompt;

	// Token: 0x04000B87 RID: 2951
	public AIPath Pathfinding;

	// Token: 0x04000B88 RID: 2952
	public GameObject Lens;

	// Token: 0x04000B89 RID: 2953
	public UILabel Label;

	// Token: 0x04000B8A RID: 2954
	public float Distance;

	// Token: 0x04000B8B RID: 2955
	public float Blood;

	// Token: 0x04000B8C RID: 2956
	public bool Super;
}
