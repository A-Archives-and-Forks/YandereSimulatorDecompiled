using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using UnityEngine.SceneManagement;

public class PauseScreenScript : MonoBehaviour
{
	public StudentInfoMenuScript StudentInfoMenu;

	public YouTubeChatMenuScript YouTubeChatMenu;

	public InventoryMenuScript InventoryMenu;

	public InputManagerScript InputManager;

	public PhotoGalleryScript PhotoGallery;

	public SaveLoadMenuScript SaveLoadMenu;

	public FreezerKillScript FreezerKill;

	public HomeYandereScript HomeYandere;

	public InputDeviceScript InputDevice;

	public MissionModeScript MissionMode;

	public NewSettingsScript NewSettings;

	public SocialMediaScript SocialMedia;

	public HomeCameraScript HomeCamera;

	public IronMaidenScript IronMaiden;

	public ServicesScript ServiceMenu;

	public FavorMenuScript FavorMenu;

	public AudioMenuScript AudioMenu;

	public IdeasMenuScript IdeasMenu;

	public PromptBarScript PromptBar;

	public TaskListScript Tutorials;

	public PassTimeScript PassTime;

	public ScheduleScript Schedule;

	public TaskListScript TaskList;

	public SchemesScript Schemes;

	public YandereScript Yandere;

	public RPG_Camera RPGCamera;

	public PoliceScript Police;

	public ClockScript Clock;

	public StatsScript Stats;

	public HintScript Hint;

	public MapScript Map;

	public UILabel SelectionLabel;

	public UILabel QuitLabel;

	public UILabel YesLabel;

	public UIPanel Panel;

	public UISprite Wifi;

	public GameObject NewMissionModeWindow;

	public GameObject MissionModeLabel;

	public GameObject MissionModeIcons;

	public GameObject LoadingScreen;

	public GameObject ControlMenu;

	public GameObject SchemesMenu;

	public GameObject StudentInfo;

	public GameObject HomeButton;

	public GameObject DropsMenu;

	public GameObject MainMenu;

	public GameObject GamepadSony;

	public GameObject GamepadXbox;

	public GameObject Keyboard;

	public GameObject Notepad;

	public GameObject Phone;

	public Transform SubtitlePanel;

	public Transform PromptParent;

	public UISprite[] PhoneIcons;

	public UISprite[] PhoneShadows;

	public UITexture[] EightiesPhoneIcons;

	public UITexture[] EightiesPhoneShadows;

	public string[] SelectionNames;

	public Transform[] Eggs;

	public float Speed;

	public int Selected = 1;

	public int Prompts;

	public int Secret;

	public int Focus;

	public bool ShowMissionModeDetails;

	public bool ViewingControlMenu;

	public bool CorrectingTime;

	public bool MultiMission;

	public bool ResettingDay;

	public bool BypassPhone;

	public bool EggsChecked;

	public bool AtSchool;

	public bool PressedA;

	public bool PressedB;

	public bool Quitting;

	public bool Sideways;

	public bool InEditor;

	public bool Eighties;

	public bool NoInfo;

	public bool Home;

	public bool Show;

	public bool Zoom;

	public int Row = 1;

	public int Column = 2;

	public string Reason;

	private void Start()
	{
		NewSettings.HairPhysics = !OptionGlobals.HairPhysics;
		if (SceneManager.GetActiveScene().name != "SchoolScene")
		{
			MissionModeGlobals.MultiMission = false;
		}
		else
		{
			AtSchool = true;
		}
		if (!MissionModeGlobals.MultiMission)
		{
			MissionModeLabel.SetActive(value: false);
		}
		MultiMission = MissionModeGlobals.MultiMission;
		base.transform.localPosition = new Vector3(1351f, 0f, 0f);
		base.transform.localScale = new Vector3(0.9133334f, 0.9133334f, 0.9133334f);
		base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, 0f);
		if (!Home)
		{
			YouTubeChatMenu.CommandChecker.CountdownCircle.transform.parent.gameObject.SetActive(value: false);
		}
		DisableEverything();
		YouTubeChatMenu.InitializeWindow.SetActive(value: true);
		YouTubeChatMenu.CommandWindow.SetActive(value: false);
		if (GameGlobals.Eighties)
		{
			Eighties = true;
			for (int i = 1; i < 19; i++)
			{
				EightiesPhoneIcons[i].enabled = true;
				EightiesPhoneShadows[i].enabled = true;
				PhoneIcons[i].enabled = false;
				PhoneShadows[i].enabled = false;
				EightiesPhoneIcons[i].color = PhoneIcons[i].color;
			}
			SelectionNames[5] = "Ideas";
			SelectionNames[18] = "Nothing";
			UISprite uISprite = PhoneIcons[17];
			uISprite.color = new Color(uISprite.color.r, uISprite.color.g, uISprite.color.b, 0.5f);
			UISprite uISprite2 = PhoneIcons[18];
			uISprite2.color = new Color(uISprite2.color.r, uISprite2.color.g, uISprite2.color.b, 0.5f);
			Notepad.SetActive(value: true);
			Phone.SetActive(value: false);
			Wifi.gameObject.SetActive(value: false);
		}
		else
		{
			for (int j = 1; j < 19; j++)
			{
				EightiesPhoneIcons[j].enabled = false;
				EightiesPhoneShadows[j].enabled = false;
			}
			NoInfo = ChallengeGlobals.NoInfo;
		}
		if (!(SceneManager.GetActiveScene().name == "SchoolScene"))
		{
			MissionModeIcons.SetActive(value: false);
			if (!Eighties)
			{
				UISprite uISprite3 = PhoneIcons[5];
				uISprite3.color = new Color(uISprite3.color.r, uISprite3.color.g, uISprite3.color.b, 0.5f);
			}
			UISprite uISprite4 = PhoneIcons[8];
			uISprite4.color = new Color(uISprite4.color.r, uISprite4.color.g, uISprite4.color.b, 0.5f);
			UISprite uISprite5 = PhoneIcons[9];
			uISprite5.color = new Color(uISprite5.color.r, uISprite5.color.g, uISprite5.color.b, 0.5f);
			UISprite uISprite6 = PhoneIcons[10];
			uISprite6.color = new Color(uISprite6.color.r, uISprite6.color.g, uISprite6.color.b, 0.5f);
			UISprite uISprite7 = PhoneIcons[11];
			uISprite7.color = new Color(uISprite7.color.r, uISprite7.color.g, uISprite7.color.b, 0.5f);
			UISprite uISprite8 = PhoneIcons[13];
			uISprite8.color = new Color(uISprite8.color.r, uISprite8.color.g, uISprite8.color.b, 0.5f);
			UISprite uISprite9 = PhoneIcons[15];
			uISprite9.color = new Color(uISprite9.color.r, uISprite9.color.g, uISprite9.color.b, 0.5f);
			UISprite uISprite10 = PhoneIcons[16];
			uISprite10.color = new Color(uISprite10.color.r, uISprite10.color.g, uISprite10.color.b, 0.5f);
			UISprite uISprite11 = PhoneIcons[17];
			uISprite11.color = new Color(uISprite11.color.r, uISprite11.color.g, uISprite11.color.b, 0.5f);
			UISprite uISprite12 = PhoneIcons[18];
			uISprite12.color = new Color(uISprite12.color.r, uISprite12.color.g, uISprite12.color.b, 0.5f);
			if (NewMissionModeWindow != null)
			{
				NewMissionModeWindow.SetActive(value: false);
			}
		}
		if (MissionModeGlobals.MissionMode)
		{
			UISprite uISprite13 = PhoneIcons[7];
			uISprite13.color = new Color(uISprite13.color.r, uISprite13.color.g, uISprite13.color.b, 0.5f);
			UISprite uISprite14 = PhoneIcons[9];
			uISprite14.color = new Color(uISprite14.color.r, uISprite14.color.g, uISprite14.color.b, 0.5f);
			UISprite uISprite15 = PhoneIcons[10];
			uISprite15.color = new Color(uISprite15.color.r, uISprite15.color.g, uISprite15.color.b, 1f);
			UISprite uISprite16 = PhoneIcons[17];
			uISprite16.color = new Color(uISprite16.color.r, uISprite16.color.g, uISprite16.color.b, 0.5f);
			UISprite uISprite17 = PhoneIcons[18];
			uISprite17.color = new Color(uISprite17.color.r, uISprite17.color.g, uISprite17.color.b, 0.5f);
		}
		if (NoInfo)
		{
			UISprite uISprite18 = PhoneIcons[5];
			uISprite18.color = new Color(uISprite18.color.r, uISprite18.color.g, uISprite18.color.b, 0.5f);
		}
		for (int k = 1; k < PhoneIcons.Length; k++)
		{
			if (PhoneIcons[k].alpha == 0.5f)
			{
				PhoneShadows[k].enabled = false;
				EightiesPhoneShadows[k].enabled = false;
			}
		}
		for (int k = 1; k < EightiesPhoneIcons.Length; k++)
		{
			if (EightiesPhoneIcons[k].alpha == 0.5f)
			{
				EightiesPhoneShadows[k].enabled = false;
			}
		}
		if (DateGlobals.Week < 2)
		{
			UISprite uISprite19 = PhoneIcons[18];
			uISprite19.color = new Color(uISprite19.color.r, uISprite19.color.g, uISprite19.color.b, 0.5f);
			PhoneShadows[18].enabled = false;
		}
		UpdateSelection();
		CorrectingTime = false;
		QuitLabel.text = "Do you wish to return to the main menu?";
		YesLabel.text = "Yes";
		HomeButton.SetActive(value: false);
	}

	private void Update()
	{
		Speed = Time.unscaledDeltaTime * 10f;
		if (Police.FadeOut || Map.Show)
		{
			return;
		}
		if (!Show)
		{
			if (base.transform.localPosition.x > 1350f)
			{
				if (Panel.enabled)
				{
					Panel.enabled = false;
					base.transform.localPosition = new Vector3(1351f, 50f, 0f);
					base.transform.localScale = new Vector3(0.9133334f, 0.9133334f, 0.9133334f);
					base.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				}
			}
			else
			{
				base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(1351f, 50f, 0f), Speed);
				base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(0.9133334f, 0.9133334f, 0.9133334f), Speed);
				base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, Mathf.Lerp(base.transform.localEulerAngles.z, 0f, Speed));
			}
			if (CorrectingTime && Time.timeScale < 0.9f)
			{
				Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, Speed);
				if (Time.timeScale > 0.9f)
				{
					CorrectingTime = false;
					Time.timeScale = 1f;
				}
			}
			if (!Input.GetButtonDown(InputNames.Xbox_Start))
			{
				return;
			}
			if (Police.StudentManager != null)
			{
				Police.StudentManager.Portal.GetComponent<PortalScript>().OsanaEvent.EventSubtitle.text = "";
				Yandere.Subtitle.Label.text = "";
			}
			if (Eighties)
			{
				BlackenAllText();
			}
			if (!Home)
			{
				if (!Yandere.Shutter.Snapping && !Yandere.TimeSkipping && !Yandere.Talking && !Yandere.Noticed && !Yandere.InClass && !Yandere.Struggling && !Yandere.Won && !Yandere.Dismembering && !Yandere.Attacked && Yandere.CanMove && !Yandere.Chased && Yandere.Chasers == 0 && !Yandere.YandereVision && Time.timeScale > 0.0001f && Hint.transform.localPosition.x == 0.2043f && !Schedule.gameObject.activeInHierarchy)
				{
					Yandere.StopAiming();
					PromptParent.localScale = Vector3.zero;
					Yandere.YandereVision = false;
					Yandere.Blur.enabled = true;
					Yandere.YandereTimer = 0f;
					Yandere.Mopping = false;
					Panel.enabled = true;
					Sideways = false;
					Show = true;
					PromptBar.ClearButtons();
					PromptBar.Label[0].text = "Accept";
					PromptBar.Label[1].text = "Exit";
					PromptBar.Label[4].text = "Choose";
					PromptBar.Label[5].text = "Choose";
					PromptBar.UpdateButtons();
					PromptBar.Show = true;
					UISprite uISprite = PhoneIcons[3];
					if (!Yandere.CanMove || Yandere.Dragging || Yandere.Carrying)
					{
						uISprite.color = new Color(uISprite.color.r, uISprite.color.g, uISprite.color.b, 0.5f);
						PhoneShadows[3].enabled = false;
						EightiesPhoneShadows[3].enabled = false;
					}
					else
					{
						uISprite.color = new Color(uISprite.color.r, uISprite.color.g, uISprite.color.b, 1f);
						PhoneShadows[3].enabled = true;
						EightiesPhoneShadows[3].enabled = true;
					}
					CheckIfSavePossible();
					UpdateSelection();
					DisableEverything();
				}
			}
			else if (HomeYandere.CanMove)
			{
				PromptBar.ClearButtons();
				PromptBar.Label[0].text = "Accept";
				PromptBar.Label[1].text = "Exit";
				PromptBar.Label[4].text = "Choose";
				PromptBar.UpdateButtons();
				PromptBar.Show = true;
				HomeYandere.CanMove = false;
				UISprite uISprite2 = PhoneIcons[3];
				uISprite2.color = new Color(uISprite2.color.r, uISprite2.color.g, uISprite2.color.b, 0.5f);
				PhoneShadows[3].enabled = false;
				EightiesPhoneShadows[3].enabled = false;
				Panel.enabled = true;
				Sideways = false;
				Show = true;
			}
			return;
		}
		if (!EggsChecked)
		{
			float num = 99999f;
			for (int i = 0; i < Eggs.Length; i++)
			{
				if (Eggs[i] != null)
				{
					float num2 = Vector3.Distance(Yandere.transform.position, Eggs[i].position);
					if (num2 < num)
					{
						num = num2;
					}
				}
			}
			if (num < 5f)
			{
				Wifi.spriteName = "5Bars";
			}
			else if (num < 10f)
			{
				Wifi.spriteName = "4Bars";
			}
			else if (num < 15f)
			{
				Wifi.spriteName = "3Bars";
			}
			else if (num < 20f)
			{
				Wifi.spriteName = "2Bars";
			}
			else if (num < 25f)
			{
				Wifi.spriteName = "1Bars";
			}
			else
			{
				Wifi.spriteName = "0Bars";
			}
			EggsChecked = true;
		}
		if (!Home)
		{
			Time.timeScale = Mathf.Lerp(Time.timeScale, 0f, Speed);
			RPGCamera.enabled = false;
		}
		if (ShowMissionModeDetails)
		{
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Speed);
			base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(0f, 1200f, 0f), Speed);
			base.transform.localEulerAngles = Vector3.Lerp(base.transform.localEulerAngles, new Vector3(0f, 0f, 0f), Speed);
		}
		else if (Quitting)
		{
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1f, 1f, 1f), Speed);
			base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(0f, -1200f, 0f), Speed);
		}
		else if (!Sideways)
		{
			if (!Zoom)
			{
				if (!NewSettings.gameObject.activeInHierarchy)
				{
					base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(0f, 49f, 0f), Speed);
				}
				else
				{
					base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(1320f, 49f, 0f), Speed);
				}
				base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(0.915f, 0.915f, 0.915f), Speed);
			}
			else
			{
				float y = 0f;
				if (Focus == 0)
				{
					y = -576.6667f;
				}
				else if (Focus == 1)
				{
					y = 0f;
				}
				else if (Focus == 2)
				{
					y = 675f;
				}
				else if (Focus == 3)
				{
					y = 0f;
				}
				base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(0f, y, 0f), Speed);
				base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(2f, 2f, 2f), Speed);
			}
			base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, Mathf.Lerp(base.transform.localEulerAngles.z, 0f, Speed));
		}
		else
		{
			base.transform.localScale = Vector3.Lerp(base.transform.localScale, new Vector3(1.78f, 1.78f, 1.78f), Speed);
			base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(0f, 35f, 0f), Speed);
			base.transform.localEulerAngles = new Vector3(base.transform.localEulerAngles.x, base.transform.localEulerAngles.y, Mathf.Lerp(base.transform.localEulerAngles.z, 90f, Speed));
		}
		if (MainMenu.activeInHierarchy && !Quitting)
		{
			if (InputManager.TappedUp)
			{
				Row--;
				UpdateSelection();
			}
			if (InputManager.TappedDown)
			{
				Row++;
				UpdateSelection();
			}
			if (InputManager.TappedRight)
			{
				Column++;
				UpdateSelection();
			}
			if (InputManager.TappedLeft)
			{
				Column--;
				UpdateSelection();
			}
			if (Input.GetKeyDown("space") && MultiMission)
			{
				ShowMissionModeDetails = !ShowMissionModeDetails;
			}
			if (ShowMissionModeDetails && Input.GetButtonDown(InputNames.Xbox_B))
			{
				ShowMissionModeDetails = false;
			}
			for (int j = 1; j < PhoneIcons.Length; j++)
			{
				if (PhoneIcons[j] != null)
				{
					Vector3 b = ((Selected != j) ? new Vector3(1f, 1f, 1f) : new Vector3(1.5f, 1.5f, 1.5f));
					PhoneIcons[j].transform.localScale = Vector3.Lerp(PhoneIcons[j].transform.localScale, b, Speed);
				}
			}
			if (!ShowMissionModeDetails)
			{
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					PressedA = true;
					if (Eighties)
					{
						BlackenAllText();
					}
					if (PhoneIcons[Selected].color.a == 1f)
					{
						if (Selected == 1)
						{
							MainMenu.SetActive(value: false);
							LoadingScreen.SetActive(value: true);
							PromptBar.ClearButtons();
							PromptBar.Label[1].text = "Back";
							PromptBar.Label[4].text = "Change";
							PromptBar.Label[5].text = "Change";
							PromptBar.UpdateButtons();
							StartCoroutine(PhotoGallery.GetPhotos());
						}
						else if (Selected == 2)
						{
							TaskList.gameObject.SetActive(value: true);
							MainMenu.SetActive(value: false);
							Sideways = true;
							TaskList.ListPosition = 0;
							TaskList.ID = 1;
							PromptBar.ClearButtons();
							PromptBar.Label[1].text = "Back";
							PromptBar.Label[2].text = "Visit Profile";
							PromptBar.Label[4].text = "Change";
							PromptBar.UpdateButtons();
							TaskList.UpdateTaskList();
							StartCoroutine(TaskList.UpdateTaskInfo());
						}
						else if (Selected == 3)
						{
							if (PhoneIcons[3].color.a == 1f && Yandere.CanMove && !Yandere.Dragging)
							{
								for (int k = 0; k < Yandere.ArmedAnims.Length; k++)
								{
									Yandere.CharacterAnimation[Yandere.ArmedAnims[k]].weight = 0f;
								}
								MainMenu.SetActive(value: false);
								PromptBar.ClearButtons();
								PromptBar.Label[0].text = "Begin";
								PromptBar.Label[1].text = "Back";
								PromptBar.Label[4].text = "Adjust";
								PromptBar.Label[5].text = "Change";
								PromptBar.UpdateButtons();
								PassTime.gameObject.SetActive(value: true);
								PassTime.GetCurrentTime();
							}
						}
						else if (Selected == 4)
						{
							PromptBar.ClearButtons();
							PromptBar.Label[1].text = "Exit";
							PromptBar.UpdateButtons();
							Stats.gameObject.SetActive(value: true);
							Stats.UpdateStats();
							MainMenu.SetActive(value: false);
							Sideways = true;
						}
						else if (Selected == 5)
						{
							if (PhoneIcons[5].color.a == 1f)
							{
								if (!Eighties)
								{
									PromptBar.ClearButtons();
									PromptBar.Label[0].text = "Confirm";
									PromptBar.Label[1].text = "Back";
									PromptBar.Label[5].text = "Change";
									PromptBar.UpdateButtons();
									FavorMenu.gameObject.SetActive(value: true);
									FavorMenu.gameObject.GetComponent<AudioSource>().Play();
									MainMenu.SetActive(value: false);
									Sideways = true;
								}
								else
								{
									PromptBar.ClearButtons();
									PromptBar.Label[0].text = "Confirm";
									PromptBar.Label[1].text = "Back";
									PromptBar.Label[4].text = "Change";
									PromptBar.UpdateButtons();
									PromptBar.Show = true;
									IdeasMenu.gameObject.SetActive(value: true);
									MainMenu.SetActive(value: false);
								}
							}
						}
						else if (Selected == 6)
						{
							StudentInfoMenu.gameObject.SetActive(value: true);
							StudentInfoMenu.Start();
							StartCoroutine(StudentInfoMenu.UpdatePortraits());
							StudentInfoMenu.GrabbedPortraits = true;
							MainMenu.SetActive(value: false);
							Sideways = true;
							PromptBar.ClearButtons();
							PromptBar.Label[0].text = "View Info";
							PromptBar.Label[1].text = "Back";
							PromptBar.UpdateButtons();
							PromptBar.Show = true;
							StudentInfoMenu.UpdateHighlight();
						}
						else if (Selected == 7)
						{
							SaveLoadMenu.gameObject.SetActive(value: true);
							SaveLoadMenu.Header.text = "Load Data";
							SaveLoadMenu.Loading = true;
							SaveLoadMenu.Saving = false;
							SaveLoadMenu.Column = 1;
							SaveLoadMenu.Row = 1;
							SaveLoadMenu.UpdateHighlight();
							StartCoroutine(SaveLoadMenu.GetThumbnails());
							MainMenu.SetActive(value: false);
							Sideways = true;
							PromptBar.ClearButtons();
							PromptBar.Label[0].text = "Choose";
							PromptBar.Label[1].text = "Back";
							PromptBar.Label[2].text = "Delete";
							PromptBar.Label[4].text = "Change";
							PromptBar.Label[5].text = "Change";
							PromptBar.UpdateButtons();
							PromptBar.Show = true;
						}
						else if (Selected == 8)
						{
							NewSettings.gameObject.SetActive(value: true);
							if (Yandere.Blur != null)
							{
								Yandere.Blur.enabled = false;
							}
							NewSettings.NewTitleScreen.Speed = 3f;
							NewSettings.enabled = true;
							NewSettings.Cursor.alpha = 0f;
							NewSettings.Selection = 1;
							NewSettings.UpdateLabels();
							MainMenu.SetActive(value: false);
						}
						else if (Selected == 9)
						{
							SaveLoadMenu.gameObject.SetActive(value: true);
							SaveLoadMenu.Header.text = "Save Data";
							SaveLoadMenu.Loading = false;
							SaveLoadMenu.Saving = true;
							SaveLoadMenu.Column = 1;
							SaveLoadMenu.Row = 1;
							SaveLoadMenu.UpdateHighlight();
							StartCoroutine(SaveLoadMenu.GetThumbnails());
							MainMenu.SetActive(value: false);
							Sideways = true;
							PromptBar.ClearButtons();
							PromptBar.Label[0].text = "Choose";
							PromptBar.Label[1].text = "Back";
							PromptBar.Label[2].text = "Delete";
							PromptBar.Label[4].text = "Change";
							PromptBar.Label[5].text = "Change";
							PromptBar.UpdateButtons();
							PromptBar.Show = true;
						}
						else if (Selected == 10)
						{
							if (!Yandere.StudentManager.MissionMode)
							{
								AudioMenu.gameObject.SetActive(value: true);
								AudioMenu.UpdateText();
								MainMenu.SetActive(value: false);
								PromptBar.ClearButtons();
								PromptBar.Label[0].text = "Play";
								PromptBar.Label[1].text = "Back";
								PromptBar.Label[4].text = "Change";
								PromptBar.UpdateButtons();
								PromptBar.Show = true;
							}
							else
							{
								PhoneIcons[Selected].transform.localScale = new Vector3(1f, 1f, 1f);
								MissionMode.ChangeMusic();
							}
						}
						else if (Selected == 11)
						{
							Tutorials.gameObject.SetActive(value: true);
							MainMenu.SetActive(value: false);
							Sideways = true;
							PromptBar.ClearButtons();
							PromptBar.Label[0].text = "Confirm";
							PromptBar.Label[1].text = "Back";
							PromptBar.Label[4].text = "Change";
							PromptBar.UpdateButtons();
							Tutorials.UpdateTaskList();
							StartCoroutine(Tutorials.UpdateTaskInfo());
						}
						else if (Selected == 12)
						{
							GamepadSony.SetActive(value: false);
							GamepadXbox.SetActive(value: false);
							Keyboard.SetActive(value: false);
							if (InputDevice.Type == InputDeviceType.Gamepad)
							{
								if (Gamepad.current is DualShockGamepad)
								{
									GamepadSony.SetActive(value: true);
								}
								else
								{
									GamepadXbox.SetActive(value: true);
								}
							}
							else
							{
								Keyboard.SetActive(value: true);
							}
							ControlMenu.SetActive(value: false);
							ControlMenu.SetActive(value: true);
							MainMenu.SetActive(value: false);
							ViewingControlMenu = true;
							Sideways = true;
							PromptBar.ClearButtons();
							PromptBar.Label[1].text = "Back";
							PromptBar.UpdateButtons();
							PromptBar.Show = true;
						}
						else if (Selected == 13)
						{
							InventoryMenu.UpdateLabels();
							InventoryMenu.gameObject.SetActive(value: true);
							MainMenu.SetActive(value: false);
							Sideways = true;
							PromptBar.ClearButtons();
							PromptBar.Label[1].text = "Back";
							PromptBar.Label[5].text = "Change Category";
							PromptBar.UpdateButtons();
							PromptBar.Show = true;
						}
						else if (Selected == 14)
						{
							QuitLabel.text = "Do you wish to return to the main menu?";
							YesLabel.text = "Yes";
							PromptBar.ClearButtons();
							PromptBar.Show = false;
							ResettingDay = false;
							Quitting = true;
							HomeButton.SetActive(value: false);
						}
						else if (Selected == 15)
						{
							QuitLabel.text = "Do you wish to restart the day?";
							if (Yandere.StudentManager.MissionMode)
							{
								YesLabel.text = "Yes";
								HomeButton.SetActive(value: false);
							}
							else
							{
								YesLabel.text = "Yes, at school";
								HomeButton.SetActive(value: true);
							}
							PromptBar.ClearButtons();
							PromptBar.Show = false;
							ResettingDay = true;
							Quitting = true;
						}
						else if (Selected == 16)
						{
							YouTubeChatMenu.gameObject.SetActive(value: true);
							MainMenu.SetActive(value: false);
							Sideways = true;
							PromptBar.ClearButtons();
							PromptBar.Label[0].text = "Confirm";
							PromptBar.Label[1].text = "Back";
							if (!YouTubeChatMenu.InitializeWindow.activeInHierarchy)
							{
								PromptBar.Label[0].text = "Toggle";
								PromptBar.Label[2].text = "Connect";
								PromptBar.Label[4].text = "Scroll";
								Cursor.lockState = CursorLockMode.None;
								Cursor.visible = true;
							}
							PromptBar.UpdateButtons();
							PromptBar.Show = true;
						}
						else if (Selected == 17)
						{
							ShowScheduleScreen();
						}
						else if (Selected == 18)
						{
							SocialMedia.gameObject.SetActive(value: true);
							MainMenu.SetActive(value: false);
							SocialMedia.Selected = 1;
							SocialMedia.Column = 1;
							SocialMedia.Row = 1;
							SocialMedia.UpdateHighlight();
						}
					}
				}
				else if (!PressedB)
				{
					if (Input.GetButtonDown(InputNames.Xbox_Start) || Input.GetButtonDown(InputNames.Xbox_B))
					{
						ExitPhone();
					}
				}
				else if (Input.GetButtonUp(InputNames.Xbox_B))
				{
					PressedB = false;
				}
			}
		}
		if (!PressedA)
		{
			if (PassTime.gameObject.activeInHierarchy)
			{
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					if (Yandere.PickUp != null)
					{
						Yandere.PickUp.Drop();
					}
					Yandere.Unequip();
					Yandere.Blur.enabled = false;
					RPGCamera.enabled = true;
					PassTime.gameObject.SetActive(value: false);
					MainMenu.SetActive(value: true);
					Show = false;
					PromptBar.ClearButtons();
					PromptBar.Label[0].text = "Minigame";
					PromptBar.Label[1].text = "Stop";
					PromptBar.UpdateButtons();
					Clock.TargetTime = PassTime.TargetTime;
					Clock.StopTime = false;
					Clock.TimeSkip = true;
					Time.timeScale = 1f;
					Yandere.ResetYandereEffects();
					Yandere.Phone.SetActive(value: true);
				}
				else if (Input.GetButtonDown(InputNames.Xbox_B))
				{
					MainMenu.SetActive(value: true);
					PromptBar.ClearButtons();
					PromptBar.Label[0].text = "Accept";
					PromptBar.Label[1].text = "Exit";
					PromptBar.Label[4].text = "Choose";
					PromptBar.Label[5].text = "Choose";
					PromptBar.UpdateButtons();
					PassTime.gameObject.SetActive(value: false);
				}
			}
			if (ViewingControlMenu)
			{
				GamepadSony.SetActive(value: false);
				GamepadXbox.SetActive(value: false);
				Keyboard.SetActive(value: false);
				if (InputDevice.Type == InputDeviceType.Gamepad)
				{
					if (Gamepad.current is DualShockGamepad)
					{
						GamepadSony.SetActive(value: true);
					}
					else
					{
						GamepadXbox.SetActive(value: true);
					}
				}
				else
				{
					Keyboard.SetActive(value: true);
				}
				if (Input.GetButtonDown(InputNames.Xbox_B))
				{
					MainMenu.SetActive(value: true);
					PromptBar.ClearButtons();
					PromptBar.Label[0].text = "Accept";
					PromptBar.Label[1].text = "Exit";
					PromptBar.Label[4].text = "Choose";
					PromptBar.Label[5].text = "Choose";
					PromptBar.UpdateButtons();
					ControlMenu.SetActive(value: false);
					ViewingControlMenu = false;
					Sideways = false;
				}
			}
			if (Quitting)
			{
				if (Input.GetButtonDown(InputNames.Xbox_A))
				{
					if (ResettingDay)
					{
						SceneManager.LoadScene("LoadingScene");
					}
					else
					{
						GameGlobals.AlphabetMode = false;
						SceneManager.LoadScene("NewTitleScene");
					}
				}
				else if (Input.GetButtonDown(InputNames.Xbox_X))
				{
					if (ResettingDay && !Yandere.StudentManager.MissionMode)
					{
						Debug.Log("We're returning home. StudentGlobals.StudentSlave is: " + StudentGlobals.StudentSlave);
						Debug.Log("and StudentGlobals.PreviousPrisoner is: " + StudentGlobals.PreviousPrisoner);
						if (StudentGlobals.StudentSlave > 0)
						{
							StudentGlobals.SetStudentKidnapped(StudentGlobals.StudentSlave, value: true);
							StudentGlobals.PrisonerChosen = 0;
							StudentGlobals.StudentSlave = 0;
						}
						else if (StudentGlobals.PreviousPrisoner > 0)
						{
							Debug.Log("StudentGlobals.PreviousSanity is: " + StudentGlobals.PreviousSanity);
							StudentGlobals.SetStudentSanity(StudentGlobals.PreviousPrisoner, StudentGlobals.PreviousSanity);
							StudentGlobals.PreviousPrisoner = 0;
							StudentGlobals.PreviousSanity = 0;
							Debug.Log("So, StudentGlobals.GetStudentSanity(StudentGlobals.PreviousPrisoner) should now be: " + StudentGlobals.GetStudentSanity(StudentGlobals.PreviousPrisoner));
						}
						HomeGlobals.LateForSchool = false;
						HomeGlobals.Night = false;
						Yandere.Sanity = 100f;
						Yandere.ResetYandereEffects();
						Yandere.CameraEffects.UpdateChroma(0f);
						SceneManager.LoadScene("HomeScene");
					}
				}
				else if (Input.GetButtonDown(InputNames.Xbox_B))
				{
					PromptBar.ClearButtons();
					PromptBar.Label[0].text = "Accept";
					PromptBar.Label[1].text = "Exit";
					PromptBar.Label[4].text = "Choose";
					PromptBar.Label[5].text = "Choose";
					PromptBar.UpdateButtons();
					PromptBar.Show = true;
					Quitting = false;
					if (BypassPhone)
					{
						base.transform.localPosition = new Vector3(1351f, 0f, 0f);
						ExitPhone();
					}
				}
			}
		}
		if (Eighties)
		{
			for (int l = 1; l < PhoneIcons.Length; l++)
			{
				EightiesPhoneIcons[l].color = PhoneIcons[l].color;
			}
		}
		if (Input.GetButtonUp(InputNames.Xbox_A))
		{
			PressedA = false;
		}
	}

	public void ShowScheduleScreen()
	{
		Schedule.gameObject.SetActive(value: true);
		Schedule.Start();
		MainMenu.SetActive(value: false);
		Panel.enabled = true;
		Sideways = true;
		Show = true;
		PromptBar.ClearButtons();
		PromptBar.Label[1].text = "Back";
		if (!ChallengeGlobals.NoInfo && DateGlobals.Week == 1)
		{
			PromptBar.Label[2].text = "View Schemes";
		}
		PromptBar.Label[3].text = (Hint.enabled ? "Disable Hints" : "Enable Hints");
		PromptBar.Label[6].text = "Change Day";
		PromptBar.UpdateButtons();
		PromptBar.Show = true;
	}

	public void JumpToQuit()
	{
		if (Home || (!Police.FadeOut && !Clock.TimeSkip && !Yandere.Noticed))
		{
			base.transform.localPosition = new Vector3(0f, -1200f, 0f);
			Yandere.YandereVision = false;
			if (!Yandere.Talking && !Yandere.Dismembering && RPGCamera != null)
			{
				RPGCamera.enabled = false;
				Yandere.StopAiming();
			}
			QuitLabel.text = "Do you wish to return to the main menu?";
			PromptBar.ClearButtons();
			PromptBar.Show = false;
			if (Yandere.Blur != null)
			{
				Yandere.Blur.enabled = true;
			}
			ResettingDay = false;
			Panel.enabled = true;
			BypassPhone = true;
			Quitting = true;
			Show = true;
		}
	}

	public void ExitPhone()
	{
		if (!Home)
		{
			PromptParent.localScale = new Vector3(1f, 1f, 1f);
			Yandere.Blur.enabled = false;
			CorrectingTime = true;
			if (!Yandere.Talking && !Yandere.Dismembering)
			{
				RPGCamera.enabled = true;
			}
			if (Yandere.Laughing)
			{
				Yandere.GetComponent<AudioSource>().volume = 1f;
			}
		}
		else
		{
			HomeYandere.CanMove = true;
		}
		PromptBar.ClearButtons();
		PromptBar.Show = false;
		BypassPhone = false;
		EggsChecked = false;
		PressedA = false;
		Show = false;
	}

	private void UpdateSelection()
	{
		if (Row < 0)
		{
			Row = 5;
		}
		else if (Row > 5)
		{
			Row = 0;
		}
		if (Column < 1)
		{
			Column = 3;
		}
		else if (Column > 3)
		{
			Column = 1;
		}
		Selected = Row * 3 + Column;
		SelectionLabel.text = SelectionNames[Selected];
		if (AtSchool && Selected == 9 && PhoneIcons[9].color.a == 0.5f)
		{
			SelectionLabel.text = Reason;
		}
	}

	private void CheckIfSavePossible()
	{
		PhoneIcons[9].color = new Color(1f, 1f, 1f, 1f);
		if (!Eighties)
		{
			PhoneShadows[9].enabled = true;
			EightiesPhoneShadows[9].enabled = false;
		}
		else
		{
			PhoneShadows[9].enabled = false;
			EightiesPhoneShadows[9].enabled = true;
		}
		if (AtSchool)
		{
			for (int i = 1; i < Yandere.StudentManager.Students.Length; i++)
			{
				if (Yandere.StudentManager.Students[i] != null && Yandere.StudentManager.Students[i].Alive)
				{
					if (Yandere.StudentManager.Students[i].Alarmed)
					{
						PhoneIcons[9].color = new Color(1f, 1f, 1f, 0.5f);
						Reason = "You cannot save the game while a student is alarmed.";
					}
					if (Yandere.StudentManager.Students[i].Fleeing)
					{
						PhoneIcons[9].color = new Color(1f, 1f, 1f, 0.5f);
						Reason = "You cannot save the game while a student is fleeing in fear.";
					}
					if (FreezerKill.ShovePhase > 0)
					{
						PhoneIcons[9].color = new Color(1f, 1f, 1f, 0.5f);
						Reason = "You cannot save the game while a student is freezing to death.";
					}
					if (Yandere.StudentManager.Students[i].Guarding && Yandere.StudentManager.Students[i].Alive)
					{
						Debug.Log("The student who is Guarding is: Student #" + Yandere.StudentManager.Students[i].StudentID + ", " + Yandere.StudentManager.Students[i].Name);
						PhoneIcons[9].color = new Color(1f, 1f, 1f, 0.5f);
						Reason = "You cannot save the game while a student is guarding a corpse.";
					}
					if (Yandere.StudentManager.Students[i].Electrocuted || Yandere.StudentManager.Students[i].Electrified)
					{
						PhoneIcons[9].color = new Color(1f, 1f, 1f, 0.5f);
						Reason = "You cannot save the game while a student is being electrocuted.";
					}
					if (Yandere.StudentManager.Students[i].Hunting || Yandere.StudentManager.RobotChan.Hunting)
					{
						PhoneIcons[9].color = new Color(1f, 1f, 1f, 0.5f);
						Reason = "You cannot save the game when a student is about to be murdered.";
					}
					if (Yandere.StudentManager.Students[i].Confessing)
					{
						PhoneIcons[9].color = new Color(1f, 1f, 1f, 0.5f);
						Reason = "You cannot save the game while a student is confessing their love.";
					}
					if (Yandere.StudentManager.Students[i].Investigating)
					{
						PhoneIcons[9].color = new Color(1f, 1f, 1f, 0.5f);
						Reason = "You cannot save the game while a student is investigating something.";
					}
					if (Yandere.StudentManager.Students[i].CameraReacting)
					{
						PhoneIcons[9].color = new Color(1f, 1f, 1f, 0.5f);
						Reason = "You cannot save the game while a student is posing for a photograph.";
					}
					if (Yandere.StudentManager.Students[i].SearchingForPhone)
					{
						PhoneIcons[9].color = new Color(1f, 1f, 1f, 0.5f);
						Reason = "You cannot save the game while a student is searching for a lost phone.";
					}
					if (Yandere.StudentManager.Police.LimbParent.childCount > 0)
					{
						PhoneIcons[9].color = new Color(1f, 1f, 1f, 0.5f);
						Reason = "You cannot save the game while dismembered limbs are present at school.";
					}
					if (Yandere.StudentManager.Students[i].Wet)
					{
						PhoneIcons[9].color = new Color(1f, 1f, 1f, 0.5f);
						Reason = "You cannot save the game while a student is wet with any kind of liquid.";
					}
					if (Yandere.StudentManager.Students[i].Ragdoll.Zs.activeInHierarchy && Yandere.StudentManager.Police.EndOfDay.TranqCase.VictimID != i)
					{
						PhoneIcons[9].color = new Color(1f, 1f, 1f, 0.5f);
						Reason = "You cannot save the game while a student is tranquilized and sleeping on the ground.";
					}
					if (Police.PhotoEvidence > 0)
					{
						PhoneIcons[9].color = new Color(1f, 1f, 1f, 0.5f);
						Reason = "You cannot save the game while a smartphone containing incriminating evidence is present at school.";
					}
				}
			}
			if (Yandere.Dragging)
			{
				PhoneIcons[9].color = new Color(1f, 1f, 1f, 0.5f);
				Reason = "You cannot save the game while dragging a dead body.";
			}
			if (Yandere.StudentManager.Students[Yandere.StudentManager.RivalID] != null && Yandere.StudentManager.Students[Yandere.StudentManager.RivalID].InEvent)
			{
				PhoneIcons[9].color = new Color(1f, 1f, 1f, 0.5f);
				Reason = "You cannot save the game while a Rival Event is occuring.";
			}
			if (Yandere.PickUp != null)
			{
				PhoneIcons[9].color = new Color(1f, 1f, 1f, 0.5f);
				Reason = "You cannot save the game while you are holding that object.";
			}
			if (Police.BloodyClothing > 0)
			{
				PhoneIcons[9].color = new Color(1f, 1f, 1f, 0.5f);
				Reason = "You cannot save the game while bloody clothing is present at school.";
			}
			if (IronMaiden.Corpse != null)
			{
				PhoneIcons[9].color = new Color(1f, 1f, 1f, 0.5f);
				Reason = "You cannot save the game while a corpse is inside the iron maiden.";
			}
		}
		if (PhoneIcons[9].alpha == 0.5f)
		{
			PhoneShadows[9].enabled = false;
			EightiesPhoneShadows[9].enabled = false;
		}
		PhoneIcons[3].alpha = 1f;
		if (!Eighties)
		{
			PhoneShadows[3].enabled = true;
			EightiesPhoneShadows[3].enabled = false;
		}
		else
		{
			PhoneShadows[3].enabled = false;
			EightiesPhoneShadows[3].enabled = true;
		}
		if (Yandere.transform.position.y > 100f || Yandere.LunaAttacher.activeInHierarchy || Yandere.Carrying || Yandere.Dragging)
		{
			PhoneIcons[3].alpha = 0.5f;
			PhoneShadows[3].enabled = false;
			EightiesPhoneShadows[3].enabled = false;
		}
	}

	public void UpdateSubtitleSize()
	{
		if (OptionGlobals.SubtitleSize == 1)
		{
			SubtitlePanel.localPosition = new Vector3(0f, 1f, 0f);
			SubtitlePanel.localScale = new Vector3(0f, 0f, 0f);
		}
		else if (OptionGlobals.SubtitleSize == 2)
		{
			SubtitlePanel.localPosition = new Vector3(0f, 0f, 1f);
			SubtitlePanel.localScale = new Vector3(0.001f, 0.001f, 0.001f);
		}
		else if (OptionGlobals.SubtitleSize == 3)
		{
			SubtitlePanel.localPosition = new Vector3(0f, 0.1133333f, 1f);
			SubtitlePanel.localScale = new Vector3(0.00133333f, 0.00133333f, 0.00133333f);
		}
	}

	public void BlackenAllText()
	{
		UILabel[] componentsInChildren = GetComponentsInChildren<UILabel>();
		foreach (UILabel obj in componentsInChildren)
		{
			obj.color = new Color(0f, 0f, 0f, 1f);
			obj.effectStyle = UILabel.Effect.None;
		}
	}

	public void DisableEverything()
	{
		FavorMenu.BountyMenu.gameObject.SetActive(value: false);
		StudentInfoMenu.gameObject.SetActive(value: false);
		YouTubeChatMenu.gameObject.SetActive(value: false);
		InventoryMenu.gameObject.SetActive(value: false);
		PhotoGallery.gameObject.SetActive(value: false);
		SaveLoadMenu.gameObject.SetActive(value: false);
		NewSettings.gameObject.SetActive(value: false);
		ServiceMenu.gameObject.SetActive(value: false);
		SocialMedia.gameObject.SetActive(value: false);
		AudioMenu.gameObject.SetActive(value: false);
		FavorMenu.gameObject.SetActive(value: false);
		IdeasMenu.gameObject.SetActive(value: false);
		Tutorials.gameObject.SetActive(value: false);
		PassTime.gameObject.SetActive(value: false);
		Schedule.gameObject.SetActive(value: false);
		TaskList.gameObject.SetActive(value: false);
		Stats.gameObject.SetActive(value: false);
		LoadingScreen.SetActive(value: false);
		ControlMenu.SetActive(value: false);
		SchemesMenu.SetActive(value: false);
		StudentInfo.SetActive(value: false);
		DropsMenu.SetActive(value: false);
		MainMenu.SetActive(value: true);
	}
}
