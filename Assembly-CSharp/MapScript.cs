﻿using System;
using UnityEngine;

// Token: 0x0200035B RID: 859
public class MapScript : MonoBehaviour
{
	// Token: 0x0600197E RID: 6526 RVA: 0x001033AC File Offset: 0x001015AC
	private void Start()
	{
		if (GameGlobals.Eighties)
		{
			this.YandereMapMarker.GetComponent<Renderer>().material.mainTexture = this.RyobaFace;
			this.Labels[0].text = "Newspaper Club";
			if (DateGlobals.Week > 10)
			{
				base.gameObject.SetActive(false);
			}
		}
		this.DisableCamera();
		this.X = 0.5f;
		this.Y = 0.5f;
	}

	// Token: 0x0600197F RID: 6527 RVA: 0x00103420 File Offset: 0x00101620
	private void Update()
	{
		if (Input.GetButtonDown("Back") && this.Yandere.CanMove && !this.Yandere.StudentManager.TutorialWindow.Show && this.Yandere.Police.Darkness.color.a <= 0f)
		{
			if (!this.Show)
			{
				if (!this.PauseScreen.Show)
				{
					this.PauseScreen.Show = true;
					this.Yandere.RPGCamera.enabled = false;
					this.ElevationLabel.enabled = true;
					this.Yandere.Blur.enabled = true;
					this.MyCamera.enabled = true;
					this.Compass.SetActive(true);
					Time.timeScale = 0.001f;
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[1].text = "Exit";
					this.PromptBar.Label[2].text = "Lower Floor";
					this.PromptBar.Label[3].text = "Higher Floor";
					this.PromptBar.UpdateButtons();
					this.PromptBar.Show = true;
					this.Show = true;
				}
			}
			else
			{
				this.Yandere.RPGCamera.enabled = true;
				this.ElevationLabel.enabled = false;
				this.Yandere.Blur.enabled = false;
				this.PauseScreen.Show = false;
				this.Compass.SetActive(false);
				Time.timeScale = 1f;
				this.PromptBar.ClearButtons();
				this.PromptBar.Show = false;
				this.Show = false;
			}
		}
		if (this.Show)
		{
			this.Border.transform.localScale = Vector3.Lerp(this.Border.transform.localScale, new Vector3(1.3f, 1.315f, 1.3f), Time.unscaledDeltaTime * 10f);
			this.X = Mathf.Lerp(this.X, 0.1f, Time.unscaledDeltaTime * 10f);
			this.Y = Mathf.Lerp(this.Y, 0.1f, Time.unscaledDeltaTime * 10f);
			this.W = Mathf.Lerp(this.W, 0.8f, Time.unscaledDeltaTime * 10f);
			this.H = Mathf.Lerp(this.H, 0.8f, Time.unscaledDeltaTime * 10f);
			this.MyCamera.rect = new Rect(this.X, this.Y, this.W, this.H);
			if (this.Border.transform.localScale.x > 1.2f)
			{
				if (this.InputDevice.Type == InputDeviceType.MouseAndKeyboard)
				{
					float axis = Input.GetAxis("Mouse Y");
					float axis2 = Input.GetAxis("Mouse X");
					base.transform.position += new Vector3(axis2 * Time.unscaledDeltaTime * 50f, 0f, axis * Time.unscaledDeltaTime * 50f);
					this.MyCamera.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * Time.unscaledDeltaTime * 1000f;
				}
				else
				{
					float axis = Input.GetAxis("Vertical");
					float axis2 = Input.GetAxis("Horizontal");
					base.transform.position += new Vector3(axis2 * Time.unscaledDeltaTime * 100f, 0f, axis * Time.unscaledDeltaTime * 100f);
					this.MyCamera.orthographicSize -= Input.GetAxis("Mouse Y") * Time.unscaledDeltaTime * 100f;
				}
				if (this.MyCamera.orthographicSize < 4f)
				{
					this.MyCamera.orthographicSize = 4f;
				}
				if (this.MyCamera.orthographicSize > 40.75f)
				{
					this.MyCamera.orthographicSize = 40.75f;
				}
				if (Input.GetButtonDown("X"))
				{
					base.transform.position += new Vector3(0f, -4f, 0f);
					if (base.transform.position.y < 3f)
					{
						base.transform.position = new Vector3(base.transform.position.x, 3f, base.transform.position.z);
					}
				}
				if (Input.GetButtonDown("Y"))
				{
					base.transform.position += new Vector3(0f, 4f, 0f);
					if (base.transform.position.y > 15f)
					{
						base.transform.position = new Vector3(base.transform.position.x, 15f, base.transform.position.z);
					}
				}
				if (base.transform.position.y == 3f)
				{
					this.ElevationLabel.text = "Floor 1";
				}
				else if (base.transform.position.y == 7f)
				{
					this.ElevationLabel.text = "Floor 2";
				}
				else if (base.transform.position.y == 11f)
				{
					this.ElevationLabel.text = "Floor 3";
				}
				else if (base.transform.position.y == 15f)
				{
					this.ElevationLabel.text = "The Rooftop";
				}
				this.HorizontalLimit = 70.72f - this.MyCamera.orthographicSize / 40.75f * 70.72f;
				if (base.transform.position.x > this.HorizontalLimit)
				{
					base.transform.position = new Vector3(this.HorizontalLimit, base.transform.position.y, base.transform.position.z);
				}
				if (base.transform.position.x < this.HorizontalLimit * -1f)
				{
					base.transform.position = new Vector3(this.HorizontalLimit * -1f, base.transform.position.y, base.transform.position.z);
				}
				this.VerticalLimit = 102f - this.MyCamera.orthographicSize / 40.75f;
				if (base.transform.position.z > this.VerticalLimit)
				{
					base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, this.VerticalLimit);
				}
				if (base.transform.position.z < this.VerticalLimit * -1f)
				{
					base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, this.VerticalLimit * -1f);
				}
				this.YandereMapMarker.localScale = new Vector3(this.MyCamera.orthographicSize / 40.75f * 10f, this.MyCamera.orthographicSize / 40.75f * 10f, this.MyCamera.orthographicSize / 40.75f * 10f);
				this.PortalMapMarker.localScale = new Vector3(this.MyCamera.orthographicSize / 40.75f * 10f, this.MyCamera.orthographicSize / 40.75f * 10f, this.MyCamera.orthographicSize / 40.75f * 10f);
				if (this.StudentManager.Students[1] != null)
				{
					this.StudentManager.Students[1].MapMarker.localScale = new Vector3(this.MyCamera.orthographicSize / 40.75f * 10f, this.MyCamera.orthographicSize / 40.75f * 10f, this.MyCamera.orthographicSize / 40.75f * 10f);
					this.StudentManager.Students[1].MapMarker.eulerAngles = new Vector3(90f, 0f, 0f);
				}
				if (Input.GetButtonDown("B"))
				{
					this.ElevationLabel.enabled = false;
					this.Compass.SetActive(false);
					this.PauseScreen.Show = false;
					this.Yandere.Blur.enabled = false;
					Time.timeScale = 1f;
					this.PromptBar.ClearButtons();
					this.PromptBar.Show = false;
					this.Yandere.RPGCamera.enabled = true;
					this.Show = false;
					return;
				}
			}
		}
		else if (this.MyCamera.enabled)
		{
			this.Border.transform.localScale = Vector3.Lerp(this.Border.transform.localScale, new Vector3(0f, 0f, 0f), Time.unscaledDeltaTime * 10f);
			this.X = Mathf.Lerp(this.X, 0.5f, Time.unscaledDeltaTime * 10f);
			this.Y = Mathf.Lerp(this.Y, 0.5f, Time.unscaledDeltaTime * 10f);
			this.W = Mathf.Lerp(this.W, 0f, Time.unscaledDeltaTime * 10f);
			this.H = Mathf.Lerp(this.H, 0f, Time.unscaledDeltaTime * 10f);
			this.MyCamera.rect = new Rect(this.X, this.Y, this.W, this.H);
			if (this.W < 0.01f)
			{
				this.DisableCamera();
			}
		}
	}

	// Token: 0x06001980 RID: 6528 RVA: 0x00103E60 File Offset: 0x00102060
	private void DisableCamera()
	{
		this.Border.transform.localScale = new Vector3(0f, 0f, 0f);
		this.MyCamera.rect = new Rect(0.5f, 0.5f, 0f, 0f);
		this.ElevationLabel.enabled = false;
		this.MyCamera.enabled = false;
	}

	// Token: 0x040028A7 RID: 10407
	public StudentManagerScript StudentManager;

	// Token: 0x040028A8 RID: 10408
	public InputDeviceScript InputDevice;

	// Token: 0x040028A9 RID: 10409
	public PauseScreenScript PauseScreen;

	// Token: 0x040028AA RID: 10410
	public PromptBarScript PromptBar;

	// Token: 0x040028AB RID: 10411
	public YandereScript Yandere;

	// Token: 0x040028AC RID: 10412
	public GameObject Compass;

	// Token: 0x040028AD RID: 10413
	public Transform YandereMapMarker;

	// Token: 0x040028AE RID: 10414
	public Transform PortalMapMarker;

	// Token: 0x040028AF RID: 10415
	public UILabel ElevationLabel;

	// Token: 0x040028B0 RID: 10416
	public UISprite Border;

	// Token: 0x040028B1 RID: 10417
	public Camera MyCamera;

	// Token: 0x040028B2 RID: 10418
	public float HorizontalLimit;

	// Token: 0x040028B3 RID: 10419
	public float VerticalLimit;

	// Token: 0x040028B4 RID: 10420
	public float X;

	// Token: 0x040028B5 RID: 10421
	public float Y;

	// Token: 0x040028B6 RID: 10422
	public float W;

	// Token: 0x040028B7 RID: 10423
	public float H;

	// Token: 0x040028B8 RID: 10424
	public bool Show;

	// Token: 0x040028B9 RID: 10425
	public Texture RyobaFace;

	// Token: 0x040028BA RID: 10426
	public UILabel[] Labels;
}
