﻿using System;
using System.Collections;
using UnityEngine;

// Token: 0x020003A7 RID: 935
public class PhotoGalleryScript : MonoBehaviour
{
	// Token: 0x06001AB0 RID: 6832 RVA: 0x0011FF5A File Offset: 0x0011E15A
	private void Start()
	{
		if (this.HomeCursor != null)
		{
			this.HomeCursor.gameObject.SetActive(false);
			base.enabled = false;
		}
		if (this.Corkboard)
		{
			base.StartCoroutine(this.GetPhotos());
		}
	}

	// Token: 0x1700049A RID: 1178
	// (get) Token: 0x06001AB1 RID: 6833 RVA: 0x0011FF97 File Offset: 0x0011E197
	private int CurrentIndex
	{
		get
		{
			return this.Column + (this.Row - 1) * 5;
		}
	}

	// Token: 0x1700049B RID: 1179
	// (get) Token: 0x06001AB2 RID: 6834 RVA: 0x0011FFAA File Offset: 0x0011E1AA
	private float LerpSpeed
	{
		get
		{
			return Time.unscaledDeltaTime * 10f;
		}
	}

	// Token: 0x1700049C RID: 1180
	// (get) Token: 0x06001AB3 RID: 6835 RVA: 0x0011FFB7 File Offset: 0x0011E1B7
	private float HighlightX
	{
		get
		{
			return -450f + 150f * (float)this.Column;
		}
	}

	// Token: 0x1700049D RID: 1181
	// (get) Token: 0x06001AB4 RID: 6836 RVA: 0x0011FFCC File Offset: 0x0011E1CC
	private float HighlightY
	{
		get
		{
			return 225f - 75f * (float)this.Row;
		}
	}

	// Token: 0x1700049E RID: 1182
	// (get) Token: 0x06001AB5 RID: 6837 RVA: 0x0011FFE4 File Offset: 0x0011E1E4
	// (set) Token: 0x06001AB6 RID: 6838 RVA: 0x0012001C File Offset: 0x0011E21C
	private float MovingPhotoXPercent
	{
		get
		{
			float num = -this.MaxPhotoX;
			float maxPhotoX = this.MaxPhotoX;
			return (this.MovingPhotograph.transform.localPosition.x - num) / (maxPhotoX - num);
		}
		set
		{
			this.MovingPhotograph.transform.localPosition = new Vector3(-this.MaxPhotoX + 2f * (this.MaxPhotoX * Mathf.Clamp01(value)), this.MovingPhotograph.transform.localPosition.y, this.MovingPhotograph.transform.localPosition.z);
		}
	}

	// Token: 0x1700049F RID: 1183
	// (get) Token: 0x06001AB7 RID: 6839 RVA: 0x00120084 File Offset: 0x0011E284
	// (set) Token: 0x06001AB8 RID: 6840 RVA: 0x001200BC File Offset: 0x0011E2BC
	private float MovingPhotoYPercent
	{
		get
		{
			float num = -this.MaxPhotoY;
			float maxPhotoY = this.MaxPhotoY;
			return (this.MovingPhotograph.transform.localPosition.y - num) / (maxPhotoY - num);
		}
		set
		{
			this.MovingPhotograph.transform.localPosition = new Vector3(this.MovingPhotograph.transform.localPosition.x, -this.MaxPhotoY + 2f * (this.MaxPhotoY * Mathf.Clamp01(value)), this.MovingPhotograph.transform.localPosition.z);
		}
	}

	// Token: 0x170004A0 RID: 1184
	// (get) Token: 0x06001AB9 RID: 6841 RVA: 0x00120123 File Offset: 0x0011E323
	// (set) Token: 0x06001ABA RID: 6842 RVA: 0x0012013C File Offset: 0x0011E33C
	private float MovingPhotoRotation
	{
		get
		{
			return this.MovingPhotograph.transform.localEulerAngles.z;
		}
		set
		{
			this.MovingPhotograph.transform.localEulerAngles = new Vector3(this.MovingPhotograph.transform.localEulerAngles.x, this.MovingPhotograph.transform.localEulerAngles.y, value);
		}
	}

	// Token: 0x170004A1 RID: 1185
	// (get) Token: 0x06001ABB RID: 6843 RVA: 0x0012018C File Offset: 0x0011E38C
	// (set) Token: 0x06001ABC RID: 6844 RVA: 0x001201C0 File Offset: 0x0011E3C0
	private float CursorXPercent
	{
		get
		{
			float num = -4788f;
			float num2 = 4788f;
			return (this.HomeCursor.transform.localPosition.x - num) / (num2 - num);
		}
		set
		{
			this.HomeCursor.transform.localPosition = new Vector3(-4788f + 2f * (4788f * Mathf.Clamp01(value)), this.HomeCursor.transform.localPosition.y, this.HomeCursor.transform.localPosition.z);
		}
	}

	// Token: 0x170004A2 RID: 1186
	// (get) Token: 0x06001ABD RID: 6845 RVA: 0x00120224 File Offset: 0x0011E424
	// (set) Token: 0x06001ABE RID: 6846 RVA: 0x00120258 File Offset: 0x0011E458
	private float CursorYPercent
	{
		get
		{
			float num = -3122f;
			float num2 = 3122f;
			return (this.HomeCursor.transform.localPosition.y - num) / (num2 - num);
		}
		set
		{
			this.HomeCursor.transform.localPosition = new Vector3(this.HomeCursor.transform.localPosition.x, -3122f + 2f * (3122f * Mathf.Clamp01(value)), this.HomeCursor.transform.localPosition.z);
		}
	}

	// Token: 0x06001ABF RID: 6847 RVA: 0x001202BC File Offset: 0x0011E4BC
	private void UpdatePhotoSelection()
	{
		if (Input.GetButtonDown("A"))
		{
			if (!this.NamingBully)
			{
				UITexture uitexture = this.Photographs[this.CurrentIndex];
				if (uitexture.mainTexture != this.NoPhoto)
				{
					this.ViewPhoto.mainTexture = uitexture.mainTexture;
					this.ViewPhoto.transform.position = uitexture.transform.position;
					this.ViewPhoto.transform.localScale = uitexture.transform.localScale;
					this.Destination.position = uitexture.transform.position;
					this.Viewing = true;
					if (!this.Corkboard)
					{
						for (int i = 1; i < 26; i++)
						{
							this.Hearts[i].gameObject.SetActive(false);
						}
					}
					this.CanAdjust = false;
				}
				this.UpdateButtonPrompts();
			}
			else if (this.Photographs[this.CurrentIndex].mainTexture != this.NoPhoto && PlayerGlobals.GetBullyPhoto(this.CurrentIndex) > 0)
			{
				this.Yandere.Police.EndOfDay.FragileTarget = PlayerGlobals.GetBullyPhoto(this.CurrentIndex);
				this.Yandere.StudentManager.FragileOfferHelp.Continue();
				this.PauseScreen.MainMenu.SetActive(true);
				this.Yandere.RPGCamera.enabled = true;
				base.gameObject.SetActive(false);
				this.PauseScreen.Show = false;
				this.PromptBar.Show = false;
				this.NamingBully = false;
				Time.timeScale = 1f;
			}
		}
		if (!this.NamingBully && Input.GetButtonDown("B"))
		{
			this.PromptBar.ClearButtons();
			this.PromptBar.Label[0].text = "Accept";
			this.PromptBar.Label[1].text = "Exit";
			this.PromptBar.Label[4].text = "Choose";
			this.PromptBar.Label[5].text = "Choose";
			this.PromptBar.UpdateButtons();
			this.PauseScreen.MainMenu.SetActive(true);
			this.PauseScreen.Sideways = false;
			this.PauseScreen.PressedB = true;
			base.gameObject.SetActive(false);
			this.UpdateButtonPrompts();
		}
		if (Input.GetButtonDown("X"))
		{
			this.ViewPhoto.mainTexture = null;
			int currentIndex = this.CurrentIndex;
			if (this.Photographs[currentIndex].mainTexture != this.NoPhoto)
			{
				this.Photographs[currentIndex].mainTexture = this.NoPhoto;
				PlayerGlobals.SetPhoto(currentIndex, false);
				PlayerGlobals.SetSenpaiPhoto(currentIndex, false);
				TaskGlobals.SetGuitarPhoto(currentIndex, false);
				TaskGlobals.SetKittenPhoto(currentIndex, false);
				this.Hearts[currentIndex].gameObject.SetActive(false);
				this.TaskManager.UpdateTaskStatus();
			}
			this.UpdateButtonPrompts();
		}
		if (this.Corkboard)
		{
			if (Input.GetButtonDown("Y"))
			{
				this.CanAdjust = false;
				this.HomeCursor.gameObject.SetActive(true);
				this.Adjusting = true;
				this.UpdateButtonPrompts();
			}
		}
		else if (Input.GetButtonDown("Y") && PlayerGlobals.GetSenpaiPhoto(this.CurrentIndex))
		{
			int currentIndex2 = this.CurrentIndex;
			PlayerGlobals.SenpaiShots--;
			this.Yandere.Inventory.SenpaiShots--;
			PlayerGlobals.SetPhoto(currentIndex2, false);
			PlayerGlobals.SetSenpaiPhoto(currentIndex2, false);
			this.Hearts[currentIndex2].gameObject.SetActive(false);
			this.Photographs[currentIndex2].mainTexture = this.NoPhoto;
			this.TaskManager.UpdateTaskStatus();
			this.CanAdjust = false;
			this.Yandere.Sanity += 20f;
			this.UpdateButtonPrompts();
			AudioSource.PlayClipAtPoint(this.Sighs[UnityEngine.Random.Range(0, this.Sighs.Length)], this.Yandere.Head.position);
		}
		if (this.InputManager.TappedRight)
		{
			this.Column = ((this.Column < 5) ? (this.Column + 1) : 1);
		}
		if (this.InputManager.TappedLeft)
		{
			this.Column = ((this.Column > 1) ? (this.Column - 1) : 5);
		}
		if (this.InputManager.TappedUp)
		{
			this.Row = ((this.Row > 1) ? (this.Row - 1) : 5);
		}
		if (this.InputManager.TappedDown)
		{
			this.Row = ((this.Row < 5) ? (this.Row + 1) : 1);
		}
		bool flag = this.InputManager.TappedRight || this.InputManager.TappedLeft;
		bool flag2 = this.InputManager.TappedUp || this.InputManager.TappedDown;
		if (flag || flag2)
		{
			this.Highlight.transform.localPosition = new Vector3(this.HighlightX, this.HighlightY, this.Highlight.transform.localPosition.z);
			this.UpdateButtonPrompts();
		}
		this.ViewPhoto.transform.localScale = Vector3.Lerp(this.ViewPhoto.transform.localScale, new Vector3(1f, 1f, 1f), this.LerpSpeed);
		this.ViewPhoto.transform.position = Vector3.Lerp(this.ViewPhoto.transform.position, this.Destination.position, this.LerpSpeed);
		if (this.Corkboard)
		{
			this.Gallery.transform.localPosition = new Vector3(this.Gallery.transform.localPosition.x, Mathf.Lerp(this.Gallery.transform.localPosition.y, 0f, Time.deltaTime * 10f), this.Gallery.transform.localPosition.z);
		}
	}

	// Token: 0x06001AC0 RID: 6848 RVA: 0x001208D0 File Offset: 0x0011EAD0
	private void UpdatePhotoViewing()
	{
		this.ViewPhoto.transform.localScale = Vector3.Lerp(this.ViewPhoto.transform.localScale, this.Corkboard ? new Vector3(5.8f, 5.8f, 5.8f) : new Vector3(6.5f, 6.5f, 6.5f), this.LerpSpeed);
		this.ViewPhoto.transform.localPosition = Vector3.Lerp(this.ViewPhoto.transform.localPosition, Vector3.zero, this.LerpSpeed);
		if (this.Corkboard && Input.GetButtonDown("A"))
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Photograph, base.transform.position, Quaternion.identity);
			gameObject.transform.parent = this.CorkboardPanel;
			gameObject.transform.localEulerAngles = Vector3.zero;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			gameObject.GetComponent<UITexture>().mainTexture = this.Photographs[this.CurrentIndex].mainTexture;
			this.MovingPhotograph = gameObject;
			this.CanAdjust = false;
			this.Adjusting = true;
			this.Viewing = false;
			this.Moving = true;
			this.CorkboardPhotographs[this.Photos] = gameObject.GetComponent<HomeCorkboardPhotoScript>();
			this.CorkboardPhotographs[this.Photos].ID = this.CurrentIndex;
			this.CorkboardPhotographs[this.Photos].ArrayID = this.Photos;
			this.Photos++;
			this.UpdateButtonPrompts();
		}
		if (Input.GetButtonDown("B"))
		{
			this.Viewing = false;
			if (this.Corkboard)
			{
				this.HomeCursor.Highlight.transform.position = new Vector3(this.HomeCursor.Highlight.transform.position.x, 100f, this.HomeCursor.Highlight.transform.position.z);
				this.CanAdjust = true;
			}
			else
			{
				for (int i = 1; i < 26; i++)
				{
					if (PlayerGlobals.GetSenpaiPhoto(i))
					{
						this.Hearts[i].gameObject.SetActive(true);
						this.CanAdjust = true;
					}
				}
			}
			this.UpdateButtonPrompts();
		}
	}

	// Token: 0x06001AC1 RID: 6849 RVA: 0x00120B38 File Offset: 0x0011ED38
	private void UpdateCorkboardPhoto()
	{
		Cursor.lockState = CursorLockMode.None;
		if (Input.GetMouseButton(1))
		{
			this.MovingPhotoRotation += this.MouseDelta.x;
		}
		else
		{
			this.MovingPhotograph.transform.localPosition = new Vector3(this.MovingPhotograph.transform.localPosition.x + this.MouseDelta.x * 8.66666f, this.MovingPhotograph.transform.localPosition.y + this.MouseDelta.y * 8.66666f, 0f);
		}
		if (Input.GetButton("LB"))
		{
			this.MovingPhotoRotation += Time.deltaTime * 100f;
		}
		if (Input.GetButton("RB"))
		{
			this.MovingPhotoRotation -= Time.deltaTime * 100f;
		}
		if (Input.GetButton("Y"))
		{
			this.MovingPhotograph.transform.localScale += new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
			if (this.MovingPhotograph.transform.localScale.x > 2f)
			{
				this.MovingPhotograph.transform.localScale = new Vector3(2f, 2f, 2f);
			}
		}
		if (Input.GetButton("X"))
		{
			this.MovingPhotograph.transform.localScale -= new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime);
			if (this.MovingPhotograph.transform.localScale.x < 1f)
			{
				this.MovingPhotograph.transform.localScale = new Vector3(1f, 1f, 1f);
			}
		}
		Vector2 vector = new Vector2(this.MovingPhotograph.transform.localPosition.x, this.MovingPhotograph.transform.localPosition.y);
		Vector2 vector2 = new Vector2(Input.GetAxis("Horizontal") * 86.66666f * this.SpeedLimit, Input.GetAxis("Vertical") * 86.66666f * this.SpeedLimit);
		this.MovingPhotograph.transform.localPosition = new Vector3(Mathf.Clamp(vector.x + vector2.x, -this.MaxPhotoX, this.MaxPhotoX), Mathf.Clamp(vector.y + vector2.y, -this.MaxPhotoY, this.MaxPhotoY), this.MovingPhotograph.transform.localPosition.z);
		if (Input.GetButtonDown("A"))
		{
			this.HomeCursor.transform.localPosition = this.MovingPhotograph.transform.localPosition;
			this.HomeCursor.gameObject.SetActive(true);
			this.Moving = false;
			this.UpdateButtonPrompts();
			this.PhotoID++;
		}
	}

	// Token: 0x06001AC2 RID: 6850 RVA: 0x00120E3C File Offset: 0x0011F03C
	private void UpdateString()
	{
		this.MouseDelta.x = this.MouseDelta.x + Input.GetAxis("Horizontal") * 8.66666f * this.SpeedLimit;
		this.MouseDelta.y = this.MouseDelta.y + Input.GetAxis("Vertical") * 8.66666f * this.SpeedLimit;
		Transform transform;
		if (this.StringPhase == 0)
		{
			transform = this.String.Origin;
			this.String.Target.position = this.String.Origin.position;
		}
		else
		{
			transform = this.String.Target;
		}
		transform.localPosition = new Vector3(transform.localPosition.x - this.MouseDelta.x * Time.deltaTime * 0.33333f, transform.localPosition.y + this.MouseDelta.y * Time.deltaTime * 0.33333f, 0f);
		if (transform.localPosition.x > 0.971f)
		{
			transform.localPosition = new Vector3(0.971f, transform.localPosition.y, transform.localPosition.z);
		}
		else if (transform.localPosition.x < -0.971f)
		{
			transform.localPosition = new Vector3(-0.971f, transform.localPosition.y, transform.localPosition.z);
		}
		if (transform.localPosition.y > 0.637f)
		{
			transform.localPosition = new Vector3(transform.localPosition.x, 0.637f, transform.localPosition.z);
		}
		else if (transform.localPosition.y < -0.637f)
		{
			transform.localPosition = new Vector3(transform.localPosition.x, -0.637f, transform.localPosition.z);
		}
		if (Input.GetButtonDown("A"))
		{
			if (this.StringPhase == 0)
			{
				this.StringPhase++;
				return;
			}
			if (this.StringPhase == 1)
			{
				this.HomeCursor.transform.localPosition = transform.localPosition;
				this.HomeCursor.gameObject.SetActive(true);
				this.MovingString = false;
				this.StringPhase = 0;
				this.UpdateButtonPrompts();
			}
		}
	}

	// Token: 0x06001AC3 RID: 6851 RVA: 0x0012107C File Offset: 0x0011F27C
	private void UpdateCorkboardCursor()
	{
		Vector2 vector = new Vector2(this.HomeCursor.transform.localPosition.x, this.HomeCursor.transform.localPosition.y);
		Vector2 vector2 = new Vector2(this.MouseDelta.x * 8.66666f + Input.GetAxis("Horizontal") * 86.66666f * this.SpeedLimit, this.MouseDelta.y * 8.66666f + Input.GetAxis("Vertical") * 86.66666f * this.SpeedLimit);
		this.HomeCursor.transform.localPosition = new Vector3(Mathf.Clamp(vector.x + vector2.x, -4788f, 4788f), Mathf.Clamp(vector.y + vector2.y, -3122f, 3122f), this.HomeCursor.transform.localPosition.z);
		if (Input.GetButtonDown("A") && this.HomeCursor.Photograph != null)
		{
			this.HomeCursor.Highlight.transform.position = new Vector3(this.HomeCursor.Highlight.transform.position.x, 100f, this.HomeCursor.Highlight.transform.position.z);
			this.MovingPhotograph = this.HomeCursor.Photograph;
			this.HomeCursor.gameObject.SetActive(false);
			this.Moving = true;
			this.UpdateButtonPrompts();
		}
		if (Input.GetButtonDown("Y"))
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.StringSet, base.transform.position, Quaternion.identity);
			gameObject.transform.parent = this.StringParent;
			gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			this.String = gameObject.GetComponent<StringScript>();
			this.HomeCursor.gameObject.SetActive(false);
			this.MovingString = true;
			this.CorkboardStrings[this.Strings] = this.String.GetComponent<StringScript>();
			this.CorkboardStrings[this.Strings].ArrayID = this.Strings;
			this.Strings++;
			this.UpdateButtonPrompts();
		}
		if (Input.GetButtonDown("B"))
		{
			if (this.HomeCursor.Photograph != null)
			{
				this.HomeCursor.Photograph = null;
			}
			this.HomeCursor.transform.localPosition = new Vector3(0f, 0f, this.HomeCursor.transform.localPosition.z);
			this.HomeCursor.Highlight.transform.position = new Vector3(this.HomeCursor.Highlight.transform.position.x, 100f, this.HomeCursor.Highlight.transform.position.z);
			this.CanAdjust = true;
			this.HomeCursor.gameObject.SetActive(false);
			this.Adjusting = false;
			this.UpdateButtonPrompts();
		}
		if (Input.GetButtonDown("X"))
		{
			if (this.HomeCursor.Photograph != null)
			{
				this.HomeCursor.Highlight.transform.position = new Vector3(this.HomeCursor.Highlight.transform.position.x, 100f, this.HomeCursor.Highlight.transform.position.z);
				this.Shuffle(this.HomeCursor.Photograph.GetComponent<HomeCorkboardPhotoScript>().ArrayID);
				UnityEngine.Object.Destroy(this.HomeCursor.Photograph);
				this.Photos--;
				this.HomeCursor.Photograph = null;
				this.UpdateButtonPrompts();
			}
			if (this.HomeCursor.Tack != null)
			{
				this.HomeCursor.CircleHighlight.transform.position = new Vector3(this.HomeCursor.CircleHighlight.transform.position.x, 100f, this.HomeCursor.CircleHighlight.transform.position.z);
				this.ShuffleStrings(this.HomeCursor.Tack.transform.parent.GetComponent<StringScript>().ArrayID);
				UnityEngine.Object.Destroy(this.HomeCursor.Tack.transform.parent.gameObject);
				this.Strings--;
				this.HomeCursor.Tack = null;
				this.UpdateButtonPrompts();
			}
		}
	}

	// Token: 0x06001AC4 RID: 6852 RVA: 0x00121568 File Offset: 0x0011F768
	private void Update()
	{
		if (this.GotPhotos && this.Corkboard && !this.SpawnedPhotos)
		{
			this.SpawnPhotographs();
			this.SpawnStrings();
			base.enabled = false;
			base.gameObject.SetActive(false);
			this.PromptBar.Label[0].text = string.Empty;
			this.PromptBar.Label[1].text = string.Empty;
			this.PromptBar.Label[2].text = string.Empty;
			this.PromptBar.Label[3].text = string.Empty;
			this.PromptBar.Label[4].text = string.Empty;
			this.PromptBar.Label[5].text = string.Empty;
			this.PromptBar.UpdateButtons();
			this.PromptBar.Show = false;
		}
		if (!this.Adjusting)
		{
			if (!this.Viewing)
			{
				this.UpdatePhotoSelection();
			}
			else
			{
				this.UpdatePhotoViewing();
			}
		}
		else
		{
			if (this.Corkboard)
			{
				this.Gallery.transform.localPosition = new Vector3(this.Gallery.transform.localPosition.x, Mathf.Lerp(this.Gallery.transform.localPosition.y, 1000f, Time.deltaTime * 10f), this.Gallery.transform.localPosition.z);
			}
			this.MouseDelta = new Vector2(Input.mousePosition.x - this.PreviousPosition.x, Input.mousePosition.y - this.PreviousPosition.y);
			if (this.InputDevice.Type == InputDeviceType.MouseAndKeyboard)
			{
				this.SpeedLimit = 0.1f;
			}
			else
			{
				this.SpeedLimit = 1f;
			}
			if (this.Moving)
			{
				this.UpdateCorkboardPhoto();
			}
			else if (this.MovingString)
			{
				this.UpdateString();
			}
			else
			{
				this.UpdateCorkboardCursor();
			}
		}
		this.PreviousPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
	}

	// Token: 0x06001AC5 RID: 6853 RVA: 0x0012178F File Offset: 0x0011F98F
	public IEnumerator GetPhotos()
	{
		if (!this.Corkboard)
		{
			for (int i = 1; i < 26; i++)
			{
				this.Hearts[i].gameObject.SetActive(false);
			}
		}
		int num;
		for (int ID = 1; ID < 26; ID = num + 1)
		{
			if (PlayerGlobals.GetPhoto(ID))
			{
				string url = string.Concat(new string[]
				{
					"file:///",
					Application.streamingAssetsPath,
					"/Photographs/Photo_",
					ID.ToString(),
					".png"
				});
				WWW www = new WWW(url);
				yield return www;
				if (www.error == null)
				{
					this.Photographs[ID].mainTexture = www.texture;
					if (!this.Corkboard && PlayerGlobals.GetSenpaiPhoto(ID))
					{
						this.Hearts[ID].gameObject.SetActive(true);
					}
				}
				else
				{
					Debug.Log(string.Concat(new string[]
					{
						"Could not retrieve Photo ",
						ID.ToString(),
						". Maybe it was deleted from Streaming Assets? Setting Photo ",
						ID.ToString(),
						" to ''false''."
					}));
					PlayerGlobals.SetPhoto(ID, false);
				}
				www = null;
			}
			num = ID;
		}
		this.LoadingScreen.SetActive(false);
		if (!this.Corkboard)
		{
			this.PauseScreen.Sideways = true;
		}
		this.UpdateButtonPrompts();
		base.enabled = true;
		base.gameObject.SetActive(true);
		this.GotPhotos = true;
		yield break;
	}

	// Token: 0x06001AC6 RID: 6854 RVA: 0x001217A0 File Offset: 0x0011F9A0
	public void UpdateButtonPrompts()
	{
		if (this.NamingBully)
		{
			if (this.Photographs[this.CurrentIndex].mainTexture != this.NoPhoto && PlayerGlobals.GetBullyPhoto(this.CurrentIndex) > 0)
			{
				if (PlayerGlobals.GetBullyPhoto(this.CurrentIndex) > 0)
				{
					this.PromptBar.Label[0].text = "Name Bully";
				}
				else
				{
					this.PromptBar.Label[0].text = string.Empty;
				}
			}
			else
			{
				this.PromptBar.Label[0].text = string.Empty;
			}
			this.PromptBar.Label[1].text = string.Empty;
			this.PromptBar.Label[2].text = string.Empty;
			this.PromptBar.Label[3].text = string.Empty;
			this.PromptBar.Label[4].text = "Move";
			this.PromptBar.Label[5].text = "Move";
		}
		else if (this.Moving || this.MovingString)
		{
			this.PromptBar.Label[0].text = "Place";
			this.PromptBar.Label[1].text = string.Empty;
			this.PromptBar.Label[2].text = string.Empty;
			this.PromptBar.Label[3].text = string.Empty;
			this.PromptBar.Label[4].text = "Move";
			this.PromptBar.Label[5].text = "Move";
			if (!this.MovingString)
			{
				this.PromptBar.Label[2].text = "Resize";
				this.PromptBar.Label[3].text = "Resize";
			}
		}
		else if (this.Adjusting)
		{
			if (this.HomeCursor.Photograph != null)
			{
				this.PromptBar.Label[0].text = "Adjust";
				this.PromptBar.Label[1].text = string.Empty;
				this.PromptBar.Label[2].text = "Remove";
				this.PromptBar.Label[3].text = string.Empty;
			}
			else if (this.HomeCursor.Tack != null)
			{
				this.PromptBar.Label[2].text = "Remove";
			}
			else
			{
				this.PromptBar.Label[0].text = string.Empty;
				this.PromptBar.Label[2].text = string.Empty;
			}
			this.PromptBar.Label[1].text = "Back";
			this.PromptBar.Label[3].text = "Place Pin";
			this.PromptBar.Label[4].text = "Move";
			this.PromptBar.Label[5].text = "Move";
		}
		else if (!this.Viewing)
		{
			int currentIndex = this.CurrentIndex;
			if (this.Photographs[currentIndex].mainTexture != this.NoPhoto)
			{
				this.PromptBar.Label[0].text = "View";
				this.PromptBar.Label[2].text = "Delete";
			}
			else
			{
				this.PromptBar.Label[0].text = string.Empty;
				this.PromptBar.Label[2].text = string.Empty;
			}
			if (!this.Corkboard)
			{
				this.PromptBar.Label[3].text = (PlayerGlobals.GetSenpaiPhoto(currentIndex) ? "Use" : string.Empty);
			}
			else
			{
				this.PromptBar.Label[3].text = "Corkboard";
			}
			this.PromptBar.Label[1].text = "Back";
			this.PromptBar.Label[4].text = "Choose";
			this.PromptBar.Label[5].text = "Choose";
		}
		else
		{
			if (this.Corkboard)
			{
				this.PromptBar.Label[0].text = "Place";
			}
			else
			{
				this.PromptBar.Label[0].text = string.Empty;
			}
			this.PromptBar.Label[2].text = string.Empty;
			this.PromptBar.Label[3].text = string.Empty;
			this.PromptBar.Label[4].text = string.Empty;
			this.PromptBar.Label[5].text = string.Empty;
		}
		this.PromptBar.UpdateButtons();
		this.PromptBar.Show = true;
	}

	// Token: 0x06001AC7 RID: 6855 RVA: 0x00121C8C File Offset: 0x0011FE8C
	private void Shuffle(int Start)
	{
		for (int i = Start; i < this.CorkboardPhotographs.Length - 1; i++)
		{
			if (this.CorkboardPhotographs[i] != null)
			{
				this.CorkboardPhotographs[i].ArrayID--;
				this.CorkboardPhotographs[i] = this.CorkboardPhotographs[i + 1];
			}
		}
	}

	// Token: 0x06001AC8 RID: 6856 RVA: 0x00121CE8 File Offset: 0x0011FEE8
	private void ShuffleStrings(int Start)
	{
		for (int i = Start; i < this.CorkboardPhotographs.Length - 1; i++)
		{
			if (this.CorkboardStrings[i] != null)
			{
				this.CorkboardStrings[i].ArrayID--;
				this.CorkboardStrings[i] = this.CorkboardStrings[i + 1];
			}
		}
	}

	// Token: 0x06001AC9 RID: 6857 RVA: 0x00121D44 File Offset: 0x0011FF44
	public void SaveAllPhotographs()
	{
		for (int i = 0; i < 100; i++)
		{
			if (this.CorkboardPhotographs[i] != null)
			{
				PlayerPrefs.SetInt(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardPhoto_",
					i.ToString(),
					"_Exists"
				}), 1);
				PlayerPrefs.SetInt(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardPhoto_",
					i.ToString(),
					"_PhotoID"
				}), this.CorkboardPhotographs[i].ID);
				PlayerPrefs.SetFloat(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardPhoto_",
					i.ToString(),
					"_PositionX"
				}), this.CorkboardPhotographs[i].transform.localPosition.x);
				PlayerPrefs.SetFloat(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardPhoto_",
					i.ToString(),
					"_PositionY"
				}), this.CorkboardPhotographs[i].transform.localPosition.y);
				PlayerPrefs.SetFloat(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardPhoto_",
					i.ToString(),
					"_PositionZ"
				}), this.CorkboardPhotographs[i].transform.localPosition.z);
				PlayerPrefs.SetFloat(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardPhoto_",
					i.ToString(),
					"_RotationX"
				}), this.CorkboardPhotographs[i].transform.localEulerAngles.x);
				PlayerPrefs.SetFloat(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardPhoto_",
					i.ToString(),
					"_RotationY"
				}), this.CorkboardPhotographs[i].transform.localEulerAngles.y);
				PlayerPrefs.SetFloat(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardPhoto_",
					i.ToString(),
					"_RotationZ"
				}), this.CorkboardPhotographs[i].transform.localEulerAngles.z);
				PlayerPrefs.SetFloat(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardPhoto_",
					i.ToString(),
					"_ScaleX"
				}), this.CorkboardPhotographs[i].transform.localScale.x);
				PlayerPrefs.SetFloat(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardPhoto_",
					i.ToString(),
					"_ScaleY"
				}), this.CorkboardPhotographs[i].transform.localScale.y);
				PlayerPrefs.SetFloat(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardPhoto_",
					i.ToString(),
					"_ScaleZ"
				}), this.CorkboardPhotographs[i].transform.localScale.z);
			}
			else
			{
				PlayerPrefs.SetInt(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardPhoto_",
					i.ToString(),
					"_Exists"
				}), 0);
			}
		}
	}

	// Token: 0x06001ACA RID: 6858 RVA: 0x00122170 File Offset: 0x00120370
	public void SpawnPhotographs()
	{
		for (int i = 0; i < 100; i++)
		{
			if (PlayerPrefs.GetInt(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardPhoto_",
				i.ToString(),
				"_Exists"
			})) == 1)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.Photograph, base.transform.position, Quaternion.identity);
				gameObject.transform.parent = this.CorkboardPanel;
				gameObject.transform.localPosition = new Vector3(PlayerPrefs.GetFloat(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardPhoto_",
					i.ToString(),
					"_PositionX"
				})), PlayerPrefs.GetFloat(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardPhoto_",
					i.ToString(),
					"_PositionY"
				})), PlayerPrefs.GetFloat(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardPhoto_",
					i.ToString(),
					"_PositionZ"
				})));
				gameObject.transform.localEulerAngles = new Vector3(PlayerPrefs.GetFloat(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardPhoto_",
					i.ToString(),
					"_RotationX"
				})), PlayerPrefs.GetFloat(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardPhoto_",
					i.ToString(),
					"_RotationY"
				})), PlayerPrefs.GetFloat(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardPhoto_",
					i.ToString(),
					"_RotationZ"
				})));
				gameObject.transform.localScale = new Vector3(PlayerPrefs.GetFloat(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardPhoto_",
					i.ToString(),
					"_ScaleX"
				})), PlayerPrefs.GetFloat(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardPhoto_",
					i.ToString(),
					"_ScaleY"
				})), PlayerPrefs.GetFloat(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardPhoto_",
					i.ToString(),
					"_ScaleZ"
				})));
				gameObject.GetComponent<UITexture>().mainTexture = this.Photographs[PlayerPrefs.GetInt(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardPhoto_",
					i.ToString(),
					"_PhotoID"
				}))].mainTexture;
				this.CorkboardPhotographs[this.Photos] = gameObject.GetComponent<HomeCorkboardPhotoScript>();
				this.CorkboardPhotographs[this.Photos].ID = PlayerPrefs.GetInt(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardPhoto_",
					i.ToString(),
					"_PhotoID"
				}));
				this.CorkboardPhotographs[this.Photos].ArrayID = this.Photos;
				this.Photos++;
			}
		}
		this.SpawnedPhotos = true;
	}

	// Token: 0x06001ACB RID: 6859 RVA: 0x00122574 File Offset: 0x00120774
	public void SaveAllStrings()
	{
		Debug.Log("Saved strings.");
		for (int i = 0; i < 100; i++)
		{
			if (this.CorkboardStrings[i] != null)
			{
				PlayerPrefs.SetInt(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardString_",
					i.ToString(),
					"_Exists"
				}), 1);
				PlayerPrefs.SetFloat(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardString_",
					i.ToString(),
					"_PositionX"
				}), this.CorkboardStrings[i].Origin.localPosition.x);
				PlayerPrefs.SetFloat(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardString_",
					i.ToString(),
					"_PositionY"
				}), this.CorkboardStrings[i].Origin.localPosition.y);
				PlayerPrefs.SetFloat(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardString_",
					i.ToString(),
					"_PositionZ"
				}), this.CorkboardStrings[i].Origin.localPosition.z);
				PlayerPrefs.SetFloat(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardString2_",
					i.ToString(),
					"_PositionX"
				}), this.CorkboardStrings[i].Target.localPosition.x);
				PlayerPrefs.SetFloat(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardString2_",
					i.ToString(),
					"_PositionY"
				}), this.CorkboardStrings[i].Target.localPosition.y);
				PlayerPrefs.SetFloat(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardString2_",
					i.ToString(),
					"_PositionZ"
				}), this.CorkboardStrings[i].Target.localPosition.z);
			}
			else
			{
				PlayerPrefs.SetInt(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardString_",
					i.ToString(),
					"_Exists"
				}), 0);
			}
		}
	}

	// Token: 0x06001ACC RID: 6860 RVA: 0x00122850 File Offset: 0x00120A50
	public void SpawnStrings()
	{
		for (int i = 0; i < 100; i++)
		{
			if (PlayerPrefs.GetInt(string.Concat(new string[]
			{
				"Profile_",
				GameGlobals.Profile.ToString(),
				"_CorkboardString_",
				i.ToString(),
				"_Exists"
			})) == 1)
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.StringSet, base.transform.position, Quaternion.identity);
				gameObject.transform.parent = this.StringParent;
				gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
				gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
				this.String = gameObject.GetComponent<StringScript>();
				this.String.Origin.localPosition = new Vector3(PlayerPrefs.GetFloat(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardString_",
					i.ToString(),
					"_PositionX"
				})), PlayerPrefs.GetFloat(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardString_",
					i.ToString(),
					"_PositionY"
				})), PlayerPrefs.GetFloat(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardString_",
					i.ToString(),
					"_PositionZ"
				})));
				this.String.Target.localPosition = new Vector3(PlayerPrefs.GetFloat(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardString2_",
					i.ToString(),
					"_PositionX"
				})), PlayerPrefs.GetFloat(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardString2_",
					i.ToString(),
					"_PositionY"
				})), PlayerPrefs.GetFloat(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardString2_",
					i.ToString(),
					"_PositionZ"
				})));
				this.CorkboardStrings[this.Strings] = this.String.GetComponent<StringScript>();
				this.CorkboardStrings[this.Strings].ArrayID = this.Strings;
				this.Strings++;
			}
			else
			{
				PlayerPrefs.SetInt(string.Concat(new string[]
				{
					"Profile_",
					GameGlobals.Profile.ToString(),
					"_CorkboardString_",
					i.ToString(),
					"_Exists"
				}), 0);
			}
		}
	}

	// Token: 0x04002C69 RID: 11369
	public HomeCorkboardPhotoScript[] CorkboardPhotographs;

	// Token: 0x04002C6A RID: 11370
	public StringScript[] CorkboardStrings;

	// Token: 0x04002C6B RID: 11371
	public int PhotoID;

	// Token: 0x04002C6C RID: 11372
	public InputManagerScript InputManager;

	// Token: 0x04002C6D RID: 11373
	public PauseScreenScript PauseScreen;

	// Token: 0x04002C6E RID: 11374
	public TaskManagerScript TaskManager;

	// Token: 0x04002C6F RID: 11375
	public InputDeviceScript InputDevice;

	// Token: 0x04002C70 RID: 11376
	public HomeCursorScript HomeCursor;

	// Token: 0x04002C71 RID: 11377
	public PromptBarScript PromptBar;

	// Token: 0x04002C72 RID: 11378
	public YandereScript Yandere;

	// Token: 0x04002C73 RID: 11379
	public StringScript String;

	// Token: 0x04002C74 RID: 11380
	public GameObject MovingPhotograph;

	// Token: 0x04002C75 RID: 11381
	public GameObject LoadingScreen;

	// Token: 0x04002C76 RID: 11382
	public GameObject Photograph;

	// Token: 0x04002C77 RID: 11383
	public GameObject StringSet;

	// Token: 0x04002C78 RID: 11384
	public Transform CorkboardPanel;

	// Token: 0x04002C79 RID: 11385
	public Transform Destination;

	// Token: 0x04002C7A RID: 11386
	public Transform Highlight;

	// Token: 0x04002C7B RID: 11387
	public Transform Gallery;

	// Token: 0x04002C7C RID: 11388
	public Transform StringParent;

	// Token: 0x04002C7D RID: 11389
	public UITexture[] Photographs;

	// Token: 0x04002C7E RID: 11390
	public UISprite[] Hearts;

	// Token: 0x04002C7F RID: 11391
	public AudioClip[] Sighs;

	// Token: 0x04002C80 RID: 11392
	public UITexture ViewPhoto;

	// Token: 0x04002C81 RID: 11393
	public Texture NoPhoto;

	// Token: 0x04002C82 RID: 11394
	public Vector2 PreviousPosition;

	// Token: 0x04002C83 RID: 11395
	public Vector2 MouseDelta;

	// Token: 0x04002C84 RID: 11396
	public bool DoNotRaisePromptBar;

	// Token: 0x04002C85 RID: 11397
	public bool SpawnedPhotos;

	// Token: 0x04002C86 RID: 11398
	public bool MovingString;

	// Token: 0x04002C87 RID: 11399
	public bool NamingBully;

	// Token: 0x04002C88 RID: 11400
	public bool Adjusting;

	// Token: 0x04002C89 RID: 11401
	public bool CanAdjust;

	// Token: 0x04002C8A RID: 11402
	public bool Corkboard;

	// Token: 0x04002C8B RID: 11403
	public bool GotPhotos;

	// Token: 0x04002C8C RID: 11404
	public bool Viewing;

	// Token: 0x04002C8D RID: 11405
	public bool Moving;

	// Token: 0x04002C8E RID: 11406
	public bool Reset;

	// Token: 0x04002C8F RID: 11407
	public int StringPhase;

	// Token: 0x04002C90 RID: 11408
	public int Strings;

	// Token: 0x04002C91 RID: 11409
	public int Photos;

	// Token: 0x04002C92 RID: 11410
	public int Column;

	// Token: 0x04002C93 RID: 11411
	public int Row;

	// Token: 0x04002C94 RID: 11412
	public float MaxPhotoX = 4150f;

	// Token: 0x04002C95 RID: 11413
	public float MaxPhotoY = 2500f;

	// Token: 0x04002C96 RID: 11414
	private const float MaxCursorX = 4788f;

	// Token: 0x04002C97 RID: 11415
	private const float MaxCursorY = 3122f;

	// Token: 0x04002C98 RID: 11416
	private const float CorkboardAspectRatio = 1.5336323f;

	// Token: 0x04002C99 RID: 11417
	public float SpeedLimit;
}
