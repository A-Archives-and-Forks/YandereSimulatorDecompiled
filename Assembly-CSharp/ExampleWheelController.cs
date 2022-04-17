﻿using System;
using UnityEngine;

// Token: 0x020000B8 RID: 184
public class ExampleWheelController : MonoBehaviour
{
	// Token: 0x06000963 RID: 2403 RVA: 0x0004B47F File Offset: 0x0004967F
	private void Start()
	{
		this.m_Rigidbody = base.GetComponent<Rigidbody>();
		this.m_Rigidbody.maxAngularVelocity = 100f;
	}

	// Token: 0x06000964 RID: 2404 RVA: 0x0004B4A0 File Offset: 0x000496A0
	private void Update()
	{
		if (Input.GetKey(KeyCode.UpArrow))
		{
			this.m_Rigidbody.AddRelativeTorque(new Vector3(-1f * this.acceleration, 0f, 0f), ForceMode.Acceleration);
		}
		else if (Input.GetKey(KeyCode.DownArrow))
		{
			this.m_Rigidbody.AddRelativeTorque(new Vector3(1f * this.acceleration, 0f, 0f), ForceMode.Acceleration);
		}
		float value = -this.m_Rigidbody.angularVelocity.x / 100f;
		if (this.motionVectorRenderer)
		{
			this.motionVectorRenderer.material.SetFloat(ExampleWheelController.Uniforms._MotionAmount, Mathf.Clamp(value, -0.25f, 0.25f));
		}
	}

	// Token: 0x0400080A RID: 2058
	public float acceleration;

	// Token: 0x0400080B RID: 2059
	public Renderer motionVectorRenderer;

	// Token: 0x0400080C RID: 2060
	private Rigidbody m_Rigidbody;

	// Token: 0x02000651 RID: 1617
	private static class Uniforms
	{
		// Token: 0x04004F62 RID: 20322
		internal static readonly int _MotionAmount = Shader.PropertyToID("_MotionAmount");
	}
}
