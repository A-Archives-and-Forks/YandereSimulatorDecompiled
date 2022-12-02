using UnityEngine;

public class EvilPhotographerScript : MonoBehaviour
{
	public StalkerYandereScript Yandere;

	public DetectionMarkerScript Marker;

	public AudioClip ShockedGameOverLine;

	public AudioClip GameOverSound;

	public AudioClip GameOverLine;

	public AudioClip SpottedSound;

	public GameObject Heartbroken;

	public GameObject Fire;

	public Animation MyAnimation;

	public Transform YandereHead;

	public Transform Head;

	public AudioSource Jukebox;

	public AudioSource MyAudio;

	public Renderer Darkness;

	public UILabel Subtitle;

	public Transform[] PanicNode;

	public Transform[] Node;

	public AudioClip[] SpeechClip;

	public string[] SpeechText;

	public float[] SpeechTime;

	public AudioClip[] ShockClip;

	public string[] ShockText;

	public float[] ShockTime;

	public string ShockedGameOverText;

	public string GameOverText;

	public string WaitAnim;

	public string WalkAnim;

	public string RunAnim;

	public float MinimumDistance;

	public float SpeechTimer;

	public float NoticeSpeed;

	public float ShockTimer;

	public float Awareness;

	public float WaitTimer;

	public float Distance;

	public float Alpha;

	public float Scale;

	public float Timer;

	public float TargetRotation;

	public float Rotation;

	public int GameOverPhase;

	public int CurrentNode;

	public int SpeechPhase;

	public bool Searching;

	public bool GameOver;

	public bool Started;

	public bool Shocked;

	public Vector3 DistractionPoint;

	public float DistractionTimer;

	public bool Distracted;

	private void Start()
	{
		Subtitle.transform.localScale = new Vector3(0f, 0f, 0f);
	}

	private void Update()
	{
		if (!GameOver)
		{
			if (Yandere.transform.position.y > base.transform.position.y - 1f && Yandere.transform.position.y < base.transform.position.y + 1f)
			{
				if (Distracted)
				{
					Quaternion b = Quaternion.LookRotation(new Vector3(DistractionPoint.x, base.transform.position.y, DistractionPoint.z) - base.transform.position);
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b, Time.deltaTime * 10f);
					DistractionTimer -= Time.deltaTime;
					if (DistractionTimer < 0f)
					{
						Distracted = false;
					}
				}
				else
				{
					Distance = Vector3.Distance(Yandere.transform.position, base.transform.position);
					if (Distance < MinimumDistance)
					{
						if (!Started)
						{
							Subtitle.text = SpeechText[0];
							MyAudio.Play();
							Started = true;
						}
						else
						{
							MyAudio.pitch = Time.timeScale;
							if (SpeechPhase < SpeechTime.Length)
							{
								SpeechTimer += Time.deltaTime;
								if (SpeechTimer > SpeechTime[SpeechPhase])
								{
									Subtitle.text = SpeechText[SpeechPhase];
									MyAudio.clip = SpeechClip[SpeechPhase];
									MyAudio.Play();
									SpeechPhase++;
									if (Shocked && SpeechPhase > 3)
									{
										WaitAnim = "guardCorpse_00";
										Node = PanicNode;
										Searching = true;
										Shocked = false;
									}
								}
							}
							Scale = Mathf.Abs(1f - (Distance - 5f) / MinimumDistance);
							if (Scale < 0f)
							{
								Scale = 0f;
							}
							if (Scale > 1f)
							{
								Scale = 1f;
							}
							Jukebox.volume = 1f - 0.9f * Scale;
							Subtitle.transform.localScale = new Vector3(Scale, Scale, Scale);
							MyAudio.volume = Scale;
						}
						if (Distance < 0.5f)
						{
							Debug.Log("Got a ''proximity'' game over from " + base.gameObject.name);
							AudioSource.PlayClipAtPoint(SpottedSound, Camera.main.transform.position);
							TransitionToGameOver();
						}
					}
					else if (Distance < MinimumDistance + 1f)
					{
						Jukebox.volume = 1f;
						MyAudio.volume = 0f;
						Subtitle.transform.localScale = new Vector3(0f, 0f, 0f);
						Subtitle.text = "";
					}
				}
				LookForYandere();
			}
			else if (Alpha > 0f)
			{
				Alpha -= Time.deltaTime;
				Marker.Tex.transform.localScale = new Vector3(1f, Alpha, 1f);
				Marker.Tex.color = new Color(1f, 0f, 0f, Alpha);
			}
			if (!Distracted)
			{
				if (Vector3.Distance(base.transform.position, Node[CurrentNode].position) < 0.1f)
				{
					base.transform.rotation = Quaternion.Slerp(base.transform.rotation, Node[CurrentNode].rotation, Time.deltaTime * 10f);
					MyAnimation.CrossFade(WaitAnim);
					WaitTimer += Time.deltaTime;
					if (WaitTimer > 10f && !Shocked)
					{
						WaitTimer = 0f;
						CurrentNode++;
						if (CurrentNode >= Node.Length)
						{
							CurrentNode = 1;
						}
						if (!Searching && Fire != null && Fire.activeInHierarchy)
						{
							SpeechClip = ShockClip;
							SpeechText = ShockText;
							SpeechTime = ShockTime;
							SpeechPhase = 0;
							SpeechTimer = 0f;
							Subtitle.text = SpeechText[0];
							MyAudio.clip = SpeechClip[0];
							MyAudio.Play();
							WaitAnim = "scaredIdle_01";
							CurrentNode = 1;
							ShockTimer = 1f;
							Shocked = true;
						}
					}
					return;
				}
				if (ShockTimer == 0f)
				{
					if (Fire != null && Fire.activeInHierarchy)
					{
						base.transform.position = Vector3.MoveTowards(base.transform.position, Node[CurrentNode].position, Time.deltaTime * 4f);
						MyAnimation.CrossFade(RunAnim);
					}
					else
					{
						base.transform.position = Vector3.MoveTowards(base.transform.position, Node[CurrentNode].position, Time.deltaTime);
						MyAnimation.CrossFade(WalkAnim);
					}
				}
				else
				{
					MyAnimation.CrossFade(WaitAnim);
					ShockTimer = Mathf.MoveTowards(ShockTimer, 0f, Time.deltaTime);
				}
				Quaternion b2 = Quaternion.LookRotation(Node[CurrentNode].position - base.transform.position);
				base.transform.rotation = Quaternion.Slerp(base.transform.rotation, b2, Time.deltaTime * 10f);
			}
			else
			{
				MyAnimation.CrossFade(WaitAnim);
			}
		}
		else if (GameOverPhase == 0)
		{
			Timer += Time.deltaTime;
			if (Timer > 1f && !MyAudio.isPlaying)
			{
				Debug.Log("Should be updating the subtitle with the Game Over text.");
				Subtitle.transform.localScale = new Vector3(1f, 1f, 1f);
				if (Shocked)
				{
					Subtitle.text = ShockedGameOverText;
					MyAudio.clip = ShockedGameOverLine;
				}
				else
				{
					Subtitle.text = GameOverText;
					MyAudio.clip = GameOverLine;
				}
				MyAudio.Play();
				GameOverPhase++;
			}
		}
		else if (!MyAudio.isPlaying || Input.GetButton("A"))
		{
			Heartbroken.SetActive(true);
			Subtitle.text = "";
			base.enabled = false;
			MyAudio.Stop();
		}
	}

	private bool YandereIsInFOV()
	{
		Vector3 to = Yandere.transform.position - Head.position;
		float num = 90f;
		return Vector3.Angle(Head.forward, to) <= num;
	}

	private bool YandereIsInLOS()
	{
		Debug.DrawLine(Head.position, new Vector3(Yandere.transform.position.x, Yandere.transform.position.y + Yandere.MyController.height - 0.2f, Yandere.transform.position.z), Color.red);
		RaycastHit hitInfo;
		if (Physics.Linecast(Head.position, new Vector3(Yandere.transform.position.x, Yandere.transform.position.y + Yandere.MyController.height - 0.2f, Yandere.transform.position.z), out hitInfo) && hitInfo.collider.gameObject.layer == 13)
		{
			return true;
		}
		return false;
	}

	private void TransitionToGameOver()
	{
		Marker.Tex.transform.localScale = new Vector3(1f, 0f, 1f);
		Marker.Tex.color = new Color(1f, 0f, 0f, 0f);
		Darkness.material.color = new Color(0f, 0f, 0f, 1f);
		Yandere.RPGCamera.enabled = false;
		Yandere.CanMove = false;
		Subtitle.text = "";
		GameOver = true;
		Jukebox.Stop();
		MyAudio.Stop();
		Alpha = 0f;
	}

	private void LookForYandere()
	{
		if (!Yandere.Invisible)
		{
			NoticeSpeed = (MinimumDistance - Distance) * Awareness;
			if (YandereIsInFOV())
			{
				if (YandereIsInLOS())
				{
					Alpha = Mathf.MoveTowards(Alpha, 1f, Time.deltaTime * NoticeSpeed);
				}
				else
				{
					Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime);
				}
			}
			else
			{
				Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime);
			}
			if (Alpha == 1f)
			{
				Debug.Log("Got a ''witnessed'' game over from " + base.gameObject.name);
				AudioSource.PlayClipAtPoint(GameOverSound, Camera.main.transform.position);
				TransitionToGameOver();
			}
		}
		else
		{
			Alpha = Mathf.MoveTowards(Alpha, 0f, Time.deltaTime);
		}
		Marker.Tex.transform.localScale = new Vector3(1f, Alpha, 1f);
		Marker.Tex.color = new Color(1f, 0f, 0f, Alpha);
	}
}
