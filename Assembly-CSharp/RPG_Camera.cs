﻿using System;
using UnityEngine;

// Token: 0x020000BC RID: 188
public class RPG_Camera : MonoBehaviour
{
	// Token: 0x0600097C RID: 2428 RVA: 0x0004B7CA File Offset: 0x000499CA
	private void Awake()
	{
		RPG_Camera.instance = this;
	}

	// Token: 0x0600097D RID: 2429 RVA: 0x0004B7D4 File Offset: 0x000499D4
	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		this.invertAxisX = OptionGlobals.InvertAxisX;
		this.invertAxisY = OptionGlobals.InvertAxisY;
		this.sensitivity = (float)OptionGlobals.Sensitivity;
		RPG_Camera.MainCamera = base.GetComponent<Camera>();
		this.distance = Mathf.Clamp(this.distance, 0.05f, this.distanceMax);
		this.desiredDistance = this.distance;
		RPG_Camera.halfFieldOfView = RPG_Camera.MainCamera.fieldOfView / 2f * 0.017453292f;
		RPG_Camera.planeAspect = RPG_Camera.MainCamera.aspect;
		RPG_Camera.halfPlaneHeight = RPG_Camera.MainCamera.nearClipPlane * Mathf.Tan(RPG_Camera.halfFieldOfView);
		RPG_Camera.halfPlaneWidth = RPG_Camera.halfPlaneHeight * RPG_Camera.planeAspect;
		this.UpdateRotation();
	}

	// Token: 0x0600097E RID: 2430 RVA: 0x0004B89C File Offset: 0x00049A9C
	public void UpdateRotation()
	{
		this.mouseX = this.cameraPivot.transform.parent.eulerAngles.y;
		this.mouseY = 15f;
	}

	// Token: 0x0600097F RID: 2431 RVA: 0x0004B8CC File Offset: 0x00049ACC
	public static void CameraSetup()
	{
		GameObject gameObject;
		if (RPG_Camera.MainCamera != null)
		{
			gameObject = RPG_Camera.MainCamera.gameObject;
		}
		else
		{
			gameObject = new GameObject("Main Camera");
			gameObject.AddComponent<Camera>();
			gameObject.tag = "MainCamera";
		}
		if (!gameObject.GetComponent("RPG_Camera"))
		{
			gameObject.AddComponent<RPG_Camera>();
		}
		RPG_Camera rpg_Camera = gameObject.GetComponent("RPG_Camera") as RPG_Camera;
		GameObject gameObject2 = GameObject.Find("cameraPivot");
		rpg_Camera.cameraPivot = gameObject2.transform;
	}

	// Token: 0x06000980 RID: 2432 RVA: 0x0004B950 File Offset: 0x00049B50
	private void LateUpdate()
	{
		if (Time.deltaTime > 0f)
		{
			if (this.cameraPivot == null)
			{
				this.cameraPivot = GameObject.Find("CameraPivot").transform;
				return;
			}
			this.GetInput();
			this.GetDesiredPosition();
			this.PositionUpdate();
			this.CharacterFade();
		}
	}

	// Token: 0x06000981 RID: 2433 RVA: 0x0004B9A8 File Offset: 0x00049BA8
	public void GetInput()
	{
		if ((double)this.distance > 0.1)
		{
			this.camBottom = Physics.Linecast(base.transform.position, base.transform.position - Vector3.up * this.camBottomDistance);
		}
		object obj = this.camBottom && base.transform.position.y - this.cameraPivot.transform.position.y <= 0f;
		if (!this.invertAxisX)
		{
			this.mouseX += Input.GetAxis("Mouse X") * this.mouseSpeed * (Time.deltaTime / Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * this.sensitivity * 10f;
		}
		else
		{
			this.mouseX -= Input.GetAxis("Mouse X") * this.mouseSpeed * (Time.deltaTime / Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * this.sensitivity * 10f;
		}
		object obj2 = obj;
		if (obj2 != null)
		{
			if (Input.GetAxis("Mouse Y") < 0f)
			{
				if (!this.invertAxisY)
				{
					this.mouseY -= Input.GetAxis("Mouse Y") * this.mouseSpeed * (Time.deltaTime / Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * this.sensitivity * 10f;
				}
				else
				{
					this.mouseY += Input.GetAxis("Mouse Y") * this.mouseSpeed * (Time.deltaTime / Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * this.sensitivity * 10f;
				}
			}
			else if (!this.invertAxisY)
			{
				this.mouseY -= Input.GetAxis("Mouse Y") * this.mouseSpeed * (Time.deltaTime / Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * this.sensitivity * 10f;
			}
			else
			{
				this.mouseY += Input.GetAxis("Mouse Y") * this.mouseSpeed * (Time.deltaTime / Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * this.sensitivity * 10f;
			}
		}
		else if (!this.invertAxisY)
		{
			this.mouseY -= Input.GetAxis("Mouse Y") * this.mouseSpeed * (Time.deltaTime / Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * this.sensitivity * 10f;
		}
		else
		{
			this.mouseY += Input.GetAxis("Mouse Y") * this.mouseSpeed * (Time.deltaTime / Mathf.Clamp(Time.timeScale, 1E-10f, 1E+10f)) * this.sensitivity * 10f;
		}
		this.mouseY = this.ClampAngle(this.mouseY, -89.5f, 89.5f);
		this.mouseXSmooth = Mathf.SmoothDamp(this.mouseXSmooth, this.mouseX, ref this.mouseXVel, this.mouseSmoothingFactor);
		this.mouseYSmooth = Mathf.SmoothDamp(this.mouseYSmooth, this.mouseY, ref this.mouseYVel, this.mouseSmoothingFactor);
		if (obj2 != null)
		{
			this.mouseYMin = this.mouseY;
		}
		else
		{
			this.mouseYMin = -89.5f;
		}
		this.mouseYSmooth = this.ClampAngle(this.mouseYSmooth, this.mouseYMin, this.mouseYMax);
		this.desiredDistance -= Input.GetAxis("Mouse ScrollWheel") * this.mouseScroll;
		if (this.desiredDistance > this.distanceMax)
		{
			this.desiredDistance = this.distanceMax;
		}
		if (this.desiredDistance < this.distanceMin)
		{
			this.desiredDistance = this.distanceMin;
		}
	}

	// Token: 0x06000982 RID: 2434 RVA: 0x0004BDA8 File Offset: 0x00049FA8
	public void GetDesiredPosition()
	{
		this.distance = this.desiredDistance;
		this.desiredPosition = this.GetCameraPosition(this.mouseYSmooth, this.mouseXSmooth, this.distance);
		this.constraint = false;
		float num = this.CheckCameraClipPlane(this.cameraPivot.position, this.desiredPosition);
		if (num != -1f)
		{
			this.distance = num;
			this.desiredPosition = this.GetCameraPosition(this.mouseYSmooth, this.mouseXSmooth, this.distance);
			this.constraint = true;
		}
		if (RPG_Camera.MainCamera == null)
		{
			RPG_Camera.MainCamera = base.GetComponent<Camera>();
		}
		this.distance -= RPG_Camera.MainCamera.nearClipPlane;
		if (this.lastDistance < this.distance || !this.constraint)
		{
			this.distance = Mathf.SmoothDamp(this.lastDistance, this.distance, ref this.distanceVel, this.camDistanceSpeed);
		}
		if ((double)this.distance < 0.05)
		{
			this.distance = 0.05f;
		}
		this.lastDistance = this.distance;
		this.desiredPosition = this.GetCameraPosition(this.mouseYSmooth, this.mouseXSmooth, this.distance);
	}

	// Token: 0x06000983 RID: 2435 RVA: 0x0004BEE1 File Offset: 0x0004A0E1
	public void PositionUpdate()
	{
		base.transform.position = this.desiredPosition;
		if ((double)this.distance > 0.05)
		{
			base.transform.LookAt(this.cameraPivot);
		}
	}

	// Token: 0x06000984 RID: 2436 RVA: 0x0004BF18 File Offset: 0x0004A118
	private void CharacterFade()
	{
		if (RPG_Animation.instance == null)
		{
			return;
		}
		if (this.distance < this.firstPersonThreshold)
		{
			RPG_Animation.instance.GetComponent<Renderer>().enabled = false;
			return;
		}
		if (this.distance < this.characterFadeThreshold)
		{
			RPG_Animation.instance.GetComponent<Renderer>().enabled = true;
			float num = 1f - (this.characterFadeThreshold - this.distance) / (this.characterFadeThreshold - this.firstPersonThreshold);
			if (RPG_Animation.instance.GetComponent<Renderer>().material.color.a != num)
			{
				RPG_Animation.instance.GetComponent<Renderer>().material.color = new Color(RPG_Animation.instance.GetComponent<Renderer>().material.color.r, RPG_Animation.instance.GetComponent<Renderer>().material.color.g, RPG_Animation.instance.GetComponent<Renderer>().material.color.b, num);
				return;
			}
		}
		else
		{
			RPG_Animation.instance.GetComponent<Renderer>().enabled = true;
			if (RPG_Animation.instance.GetComponent<Renderer>().material.color.a != 1f)
			{
				RPG_Animation.instance.GetComponent<Renderer>().material.color = new Color(RPG_Animation.instance.GetComponent<Renderer>().material.color.r, RPG_Animation.instance.GetComponent<Renderer>().material.color.g, RPG_Animation.instance.GetComponent<Renderer>().material.color.b, 1f);
			}
		}
	}

	// Token: 0x06000985 RID: 2437 RVA: 0x0004C0B4 File Offset: 0x0004A2B4
	private Vector3 GetCameraPosition(float xAxis, float yAxis, float distance)
	{
		Vector3 point = new Vector3(0f, 0f, -distance);
		Quaternion rotation = Quaternion.Euler(xAxis, yAxis, 0f);
		return this.cameraPivot.position + rotation * point;
	}

	// Token: 0x06000986 RID: 2438 RVA: 0x0004C0F8 File Offset: 0x0004A2F8
	private float CheckCameraClipPlane(Vector3 from, Vector3 to)
	{
		float num = -1f;
		RPG_Camera.ClipPlaneVertexes clipPlaneAt = RPG_Camera.GetClipPlaneAt(to);
		int layerMask = 257;
		if (RPG_Camera.MainCamera != null)
		{
			RaycastHit raycastHit;
			if (Physics.Linecast(from, to, out raycastHit, layerMask))
			{
				num = raycastHit.distance - RPG_Camera.MainCamera.nearClipPlane;
			}
			if (Physics.Linecast(from - base.transform.right * RPG_Camera.halfPlaneWidth + base.transform.up * RPG_Camera.halfPlaneHeight, clipPlaneAt.UpperLeft, out raycastHit, layerMask) && (raycastHit.distance < num || num == -1f))
			{
				num = Vector3.Distance(raycastHit.point + base.transform.right * RPG_Camera.halfPlaneWidth - base.transform.up * RPG_Camera.halfPlaneHeight, from);
			}
			if (Physics.Linecast(from + base.transform.right * RPG_Camera.halfPlaneWidth + base.transform.up * RPG_Camera.halfPlaneHeight, clipPlaneAt.UpperRight, out raycastHit, layerMask) && (raycastHit.distance < num || num == -1f))
			{
				num = Vector3.Distance(raycastHit.point - base.transform.right * RPG_Camera.halfPlaneWidth - base.transform.up * RPG_Camera.halfPlaneHeight, from);
			}
			if (Physics.Linecast(from - base.transform.right * RPG_Camera.halfPlaneWidth - base.transform.up * RPG_Camera.halfPlaneHeight, clipPlaneAt.LowerLeft, out raycastHit, layerMask) && (raycastHit.distance < num || num == -1f))
			{
				num = Vector3.Distance(raycastHit.point + base.transform.right * RPG_Camera.halfPlaneWidth + base.transform.up * RPG_Camera.halfPlaneHeight, from);
			}
			if (Physics.Linecast(from + base.transform.right * RPG_Camera.halfPlaneWidth - base.transform.up * RPG_Camera.halfPlaneHeight, clipPlaneAt.LowerRight, out raycastHit, layerMask) && (raycastHit.distance < num || num == -1f))
			{
				num = Vector3.Distance(raycastHit.point - base.transform.right * RPG_Camera.halfPlaneWidth + base.transform.up * RPG_Camera.halfPlaneHeight, from);
			}
		}
		return num;
	}

	// Token: 0x06000987 RID: 2439 RVA: 0x0004C3AC File Offset: 0x0004A5AC
	private float ClampAngle(float angle, float min, float max)
	{
		while (angle < -360f || angle > 360f)
		{
			if (angle < -360f)
			{
				angle += 360f;
			}
			if (angle > 360f)
			{
				angle -= 360f;
			}
		}
		return Mathf.Clamp(angle, min, max);
	}

	// Token: 0x06000988 RID: 2440 RVA: 0x0004C3EC File Offset: 0x0004A5EC
	public static RPG_Camera.ClipPlaneVertexes GetClipPlaneAt(Vector3 pos)
	{
		RPG_Camera.ClipPlaneVertexes result = default(RPG_Camera.ClipPlaneVertexes);
		if (RPG_Camera.MainCamera == null)
		{
			return result;
		}
		Transform transform = RPG_Camera.MainCamera.transform;
		float nearClipPlane = RPG_Camera.MainCamera.nearClipPlane;
		result.UpperLeft = pos - transform.right * RPG_Camera.halfPlaneWidth;
		result.UpperLeft += transform.up * RPG_Camera.halfPlaneHeight;
		result.UpperLeft += transform.forward * nearClipPlane;
		result.UpperRight = pos + transform.right * RPG_Camera.halfPlaneWidth;
		result.UpperRight += transform.up * RPG_Camera.halfPlaneHeight;
		result.UpperRight += transform.forward * nearClipPlane;
		result.LowerLeft = pos - transform.right * RPG_Camera.halfPlaneWidth;
		result.LowerLeft -= transform.up * RPG_Camera.halfPlaneHeight;
		result.LowerLeft += transform.forward * nearClipPlane;
		result.LowerRight = pos + transform.right * RPG_Camera.halfPlaneWidth;
		result.LowerRight -= transform.up * RPG_Camera.halfPlaneHeight;
		result.LowerRight += transform.forward * nearClipPlane;
		return result;
	}

	// Token: 0x06000989 RID: 2441 RVA: 0x0004C5C4 File Offset: 0x0004A7C4
	public void RotateWithCharacter()
	{
		float num = Input.GetAxis("Horizontal") * RPG_Controller.instance.turnSpeed;
		this.mouseX += num;
	}

	// Token: 0x04000814 RID: 2068
	public static RPG_Camera instance;

	// Token: 0x04000815 RID: 2069
	public static Camera MainCamera;

	// Token: 0x04000816 RID: 2070
	public Transform cameraPivot;

	// Token: 0x04000817 RID: 2071
	public float distance = 5f;

	// Token: 0x04000818 RID: 2072
	public float distanceMax = 30f;

	// Token: 0x04000819 RID: 2073
	public float distanceMin = 2f;

	// Token: 0x0400081A RID: 2074
	public float mouseSpeed = 8f;

	// Token: 0x0400081B RID: 2075
	public float mouseScroll = 15f;

	// Token: 0x0400081C RID: 2076
	public float mouseSmoothingFactor = 0.08f;

	// Token: 0x0400081D RID: 2077
	public float camDistanceSpeed = 0.7f;

	// Token: 0x0400081E RID: 2078
	public float camBottomDistance = 1f;

	// Token: 0x0400081F RID: 2079
	public float firstPersonThreshold = 0.8f;

	// Token: 0x04000820 RID: 2080
	public float characterFadeThreshold = 1.8f;

	// Token: 0x04000821 RID: 2081
	public Vector3 desiredPosition;

	// Token: 0x04000822 RID: 2082
	public float desiredDistance;

	// Token: 0x04000823 RID: 2083
	private float lastDistance;

	// Token: 0x04000824 RID: 2084
	public float mouseX;

	// Token: 0x04000825 RID: 2085
	public float mouseXSmooth;

	// Token: 0x04000826 RID: 2086
	private float mouseXVel;

	// Token: 0x04000827 RID: 2087
	public float mouseY;

	// Token: 0x04000828 RID: 2088
	public float mouseYSmooth;

	// Token: 0x04000829 RID: 2089
	private float mouseYVel;

	// Token: 0x0400082A RID: 2090
	private float mouseYMin = -89.5f;

	// Token: 0x0400082B RID: 2091
	private float mouseYMax = 89.5f;

	// Token: 0x0400082C RID: 2092
	private float distanceVel;

	// Token: 0x0400082D RID: 2093
	private bool camBottom;

	// Token: 0x0400082E RID: 2094
	private bool constraint;

	// Token: 0x0400082F RID: 2095
	public bool invertAxisX;

	// Token: 0x04000830 RID: 2096
	public bool invertAxisY;

	// Token: 0x04000831 RID: 2097
	public float sensitivity;

	// Token: 0x04000832 RID: 2098
	private static float halfFieldOfView;

	// Token: 0x04000833 RID: 2099
	private static float planeAspect;

	// Token: 0x04000834 RID: 2100
	private static float halfPlaneHeight;

	// Token: 0x04000835 RID: 2101
	private static float halfPlaneWidth;

	// Token: 0x02000654 RID: 1620
	public struct ClipPlaneVertexes
	{
		// Token: 0x04004F62 RID: 20322
		public Vector3 UpperLeft;

		// Token: 0x04004F63 RID: 20323
		public Vector3 UpperRight;

		// Token: 0x04004F64 RID: 20324
		public Vector3 LowerLeft;

		// Token: 0x04004F65 RID: 20325
		public Vector3 LowerRight;
	}
}
