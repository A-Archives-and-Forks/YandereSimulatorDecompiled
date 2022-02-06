﻿using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000068 RID: 104
[ExecuteInEditMode]
[RequireComponent(typeof(UIToggle))]
[AddComponentMenu("NGUI/Interaction/Toggled Components")]
public class UIToggledComponents : MonoBehaviour
{
	// Token: 0x060002DB RID: 731 RVA: 0x0001ECA4 File Offset: 0x0001CEA4
	private void Awake()
	{
		if (this.target != null)
		{
			if (this.activate.Count == 0 && this.deactivate.Count == 0)
			{
				if (this.inverse)
				{
					this.deactivate.Add(this.target);
				}
				else
				{
					this.activate.Add(this.target);
				}
			}
			else
			{
				this.target = null;
			}
		}
		EventDelegate.Add(base.GetComponent<UIToggle>().onChange, new EventDelegate.Callback(this.Toggle));
	}

	// Token: 0x060002DC RID: 732 RVA: 0x0001ED2C File Offset: 0x0001CF2C
	public void Toggle()
	{
		if (base.enabled)
		{
			for (int i = 0; i < this.activate.Count; i++)
			{
				this.activate[i].enabled = UIToggle.current.value;
			}
			for (int j = 0; j < this.deactivate.Count; j++)
			{
				this.deactivate[j].enabled = !UIToggle.current.value;
			}
		}
	}

	// Token: 0x04000461 RID: 1121
	public List<MonoBehaviour> activate;

	// Token: 0x04000462 RID: 1122
	public List<MonoBehaviour> deactivate;

	// Token: 0x04000463 RID: 1123
	[HideInInspector]
	[SerializeField]
	private MonoBehaviour target;

	// Token: 0x04000464 RID: 1124
	[HideInInspector]
	[SerializeField]
	private bool inverse;
}
