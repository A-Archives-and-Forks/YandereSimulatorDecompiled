﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Token: 0x0200032C RID: 812
public class HomeYandereScript : MonoBehaviour
{
	// Token: 0x060018BC RID: 6332 RVA: 0x000F31B8 File Offset: 0x000F13B8
	public void Start()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		Debug.Log("Here at the Home scene, GameGlobals.RivalEliminationID is currently: " + GameGlobals.RivalEliminationID.ToString());
		if (this.CutsceneYandere != null)
		{
			this.CutsceneYandere.GetComponent<Animation>()["f02_midoriTexting_00"].speed = 0.1f;
		}
		if (SceneManager.GetActiveScene().name == "HomeScene")
		{
			if (!YanvaniaGlobals.DraculaDefeated && !HomeGlobals.MiyukiDefeated)
			{
				base.transform.position = Vector3.zero;
				base.transform.eulerAngles = Vector3.zero;
				if (!GameGlobals.Eighties && DateGlobals.Weekday == DayOfWeek.Sunday)
				{
					this.Nude();
				}
				else if (!HomeGlobals.Night)
				{
					if (DateGlobals.Weekday == DayOfWeek.Sunday)
					{
						this.WearPajamas();
					}
					else
					{
						this.ChangeSchoolwear();
						base.StartCoroutine(this.ApplyCustomCostume());
					}
				}
				else
				{
					this.WearPajamas();
				}
			}
			else if (HomeGlobals.StartInBasement)
			{
				HomeGlobals.StartInBasement = false;
				base.transform.position = new Vector3(0f, -135f, 0f);
				base.transform.eulerAngles = Vector3.zero;
			}
			else if (HomeGlobals.MiyukiDefeated)
			{
				base.transform.position = new Vector3(1f, 0f, 0f);
				base.transform.eulerAngles = new Vector3(0f, 90f, 0f);
				this.CharacterAnimation.Play("f02_discScratch_00");
				this.Controller.transform.localPosition = new Vector3(0.09425f, 0.0095f, 0.01878f);
				this.Controller.transform.localEulerAngles = new Vector3(0f, 0f, -180f);
				this.HomeCamera.Destination = this.HomeCamera.Destinations[5];
				this.HomeCamera.Target = this.HomeCamera.Targets[5];
				this.Disc.SetActive(true);
				this.WearPajamas();
				this.MyAudio.clip = this.MiyukiReaction;
			}
			else
			{
				base.transform.position = new Vector3(1f, 0f, 0f);
				base.transform.eulerAngles = new Vector3(0f, 90f, 0f);
				this.CharacterAnimation.Play("f02_discScratch_00");
				this.Controller.transform.localPosition = new Vector3(0.09425f, 0.0095f, 0.01878f);
				this.Controller.transform.localEulerAngles = new Vector3(0f, 0f, -180f);
				this.HomeCamera.Destination = this.HomeCamera.Destinations[5];
				this.HomeCamera.Target = this.HomeCamera.Targets[5];
				this.Disc.SetActive(true);
				this.WearPajamas();
			}
			if (GameGlobals.BlondeHair)
			{
				this.PonytailRenderer.material.mainTexture = this.BlondePony;
				this.LongHairRenderer.material.mainTexture = this.BlondeLong;
			}
		}
		Time.timeScale = 1f;
		this.IdleAnim = "f02_idleShort_00";
		this.WalkAnim = "f02_newWalk_00";
		this.RunAnim = "f02_newSprint_00";
		if (GameGlobals.Eighties)
		{
			this.StudentManager.Eighties = true;
			this.RyobaHair.SetActive(true);
			this.Hairstyle = 0;
			this.UpdateHair();
			this.IdleAnim = "f02_ryobaIdle_00";
			this.WalkAnim = "f02_ryobaWalk_00";
			this.RunAnim = "f02_ryobaRun_00";
			if (DateGlobals.Weekday != DayOfWeek.Sunday)
			{
				if (!this.Pajamas.gameObject.activeInHierarchy)
				{
					this.MyRenderer.SetBlendShapeWeight(0, 50f);
					this.MyRenderer.SetBlendShapeWeight(5, 25f);
					this.MyRenderer.SetBlendShapeWeight(9, 0f);
					this.MyRenderer.SetBlendShapeWeight(12, 100f);
					this.ChangeSchoolwear();
				}
				this.MyRenderer.materials[0].mainTexture = this.EightiesSocks;
			}
			this.BreastSize = 1.5f;
			this.BreastR.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
			this.BreastL.localScale = new Vector3(this.BreastSize, this.BreastSize, this.BreastSize);
		}
		else
		{
			this.PonytailRenderer.transform.parent.gameObject.SetActive(true);
			this.RyobaHair.SetActive(false);
			if (HomeGlobals.Night)
			{
				this.Hairstyle = 2;
				this.UpdateHair();
			}
			else
			{
				this.Hairstyle = 1;
				this.UpdateHair();
			}
		}
		if (DateGlobals.Week != 1 || DateGlobals.Weekday != DayOfWeek.Monday)
		{
			this.CannotAlphabet = true;
		}
		PlayerGlobals.BringingItem = 0;
	}

	// Token: 0x060018BD RID: 6333 RVA: 0x000F36B0 File Offset: 0x000F18B0
	private void Update()
	{
		if (this.UpdateFace && this.Pajamas.newRenderer != null)
		{
			this.Pajamas.newRenderer.SetBlendShapeWeight(0, 50f);
			this.Pajamas.newRenderer.SetBlendShapeWeight(5, 25f);
			this.Pajamas.newRenderer.SetBlendShapeWeight(9, 0f);
			this.Pajamas.newRenderer.SetBlendShapeWeight(12, 100f);
			this.UpdateFace = false;
		}
		if (!this.Disc.activeInHierarchy)
		{
			if (this.CanMove)
			{
				if (!OptionGlobals.ToggleRun)
				{
					this.Running = false;
					if (Input.GetButton("LB"))
					{
						this.Running = true;
					}
				}
				else if (Input.GetButtonDown("LB"))
				{
					this.Running = !this.Running;
				}
				this.MyController.Move(Physics.gravity * 0.01f);
				float axis = Input.GetAxis("Vertical");
				float axis2 = Input.GetAxis("Horizontal");
				Vector3 vector = Camera.main.transform.TransformDirection(Vector3.forward);
				vector.y = 0f;
				vector = vector.normalized;
				Vector3 a = new Vector3(vector.z, 0f, -vector.x);
				Vector3 vector2 = axis2 * a + axis * vector;
				if (vector2 != Vector3.zero)
				{
					Quaternion b = Quaternion.LookRotation(vector2);
					base.transform.rotation = Quaternion.Lerp(base.transform.rotation, b, Time.deltaTime * 10f);
				}
				if (axis != 0f || axis2 != 0f)
				{
					if (this.Running)
					{
						this.CharacterAnimation.CrossFade(this.RunAnim);
						this.MyController.Move(base.transform.forward * this.RunSpeed * Time.deltaTime);
					}
					else
					{
						this.CharacterAnimation.CrossFade(this.WalkAnim);
						this.MyController.Move(base.transform.forward * this.WalkSpeed * Time.deltaTime);
					}
				}
				else
				{
					this.CharacterAnimation.CrossFade(this.IdleAnim);
				}
			}
			else
			{
				this.CharacterAnimation.CrossFade(this.IdleAnim);
			}
		}
		else if (this.HomeDarkness.color.a == 0f)
		{
			if (this.Timer == 0f)
			{
				this.MyAudio.Play();
			}
			else if (this.Timer > this.MyAudio.clip.length + 1f)
			{
				YanvaniaGlobals.DraculaDefeated = false;
				HomeGlobals.MiyukiDefeated = false;
				this.Disc.SetActive(false);
				this.HomeVideoGames.Quit();
			}
			this.Timer += Time.deltaTime;
		}
		Rigidbody component = base.GetComponent<Rigidbody>();
		if (component != null)
		{
			component.velocity = Vector3.zero;
		}
		if (base.transform.position.y < -10f)
		{
			base.transform.position = new Vector3(base.transform.position.x, -10f, base.transform.position.z);
		}
	}

	// Token: 0x060018BE RID: 6334 RVA: 0x000F3A10 File Offset: 0x000F1C10
	private void LateUpdate()
	{
		if (!this.CannotAlphabet && Input.GetKeyDown(this.Letter[this.AlphabetID]))
		{
			this.AlphabetID++;
			if (this.AlphabetID == this.Letter.Length)
			{
				GameGlobals.AlphabetMode = true;
				StudentGlobals.MemorialStudents = 0;
				for (int i = 1; i < 101; i++)
				{
					StudentGlobals.SetStudentDead(i, false);
					StudentGlobals.SetStudentKidnapped(i, false);
					StudentGlobals.SetStudentArrested(i, false);
					StudentGlobals.SetStudentExpelled(i, false);
				}
				SceneManager.LoadScene("LoadingScene");
			}
		}
	}

	// Token: 0x060018BF RID: 6335 RVA: 0x000F3A98 File Offset: 0x000F1C98
	private void UpdateHair()
	{
		if (this.Hairstyle == 0)
		{
			this.LongHairRenderer.gameObject.SetActive(false);
			this.PonytailRenderer.enabled = false;
			return;
		}
		if (this.Hairstyle == 1)
		{
			this.LongHairRenderer.gameObject.SetActive(false);
			this.PonytailRenderer.enabled = true;
			return;
		}
		if (this.Hairstyle == 2)
		{
			this.LongHairRenderer.gameObject.SetActive(true);
			this.PonytailRenderer.enabled = false;
		}
	}

	// Token: 0x060018C0 RID: 6336 RVA: 0x000F3B18 File Offset: 0x000F1D18
	private void ChangeSchoolwear()
	{
		this.MyRenderer.sharedMesh = this.Uniforms[StudentGlobals.FemaleUniform];
		this.MyRenderer.materials[0].mainTexture = this.UniformTextures[StudentGlobals.FemaleUniform];
		this.MyRenderer.materials[1].mainTexture = this.UniformTextures[StudentGlobals.FemaleUniform];
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		base.StartCoroutine(this.ApplyCustomCostume());
	}

	// Token: 0x060018C1 RID: 6337 RVA: 0x000F3BA0 File Offset: 0x000F1DA0
	private void WearPajamas()
	{
		this.Pajamas.gameObject.SetActive(true);
		this.MyRenderer.sharedMesh = null;
		this.MyRenderer.materials[0].mainTexture = this.PajamaTexture;
		this.MyRenderer.materials[1].mainTexture = this.PajamaTexture;
		this.MyRenderer.materials[2].mainTexture = this.FaceTexture;
		base.StartCoroutine(this.ApplyCustomFace());
		if (GameGlobals.Eighties)
		{
			this.UpdateFace = true;
		}
	}

	// Token: 0x060018C2 RID: 6338 RVA: 0x000F3C30 File Offset: 0x000F1E30
	private void Nude()
	{
		this.MyRenderer.sharedMesh = this.NudeMesh;
		this.MyRenderer.materials[0].mainTexture = this.NudeTexture;
		this.MyRenderer.materials[1].mainTexture = this.NudeTexture;
		this.MyRenderer.materials[2].mainTexture = this.NudeTexture;
	}

	// Token: 0x060018C3 RID: 6339 RVA: 0x000F3C96 File Offset: 0x000F1E96
	private IEnumerator ApplyCustomCostume()
	{
		if (StudentGlobals.FemaleUniform == 1)
		{
			WWW CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomUniform.png");
			yield return CustomUniform;
			if (CustomUniform.error == null)
			{
				this.MyRenderer.materials[0].mainTexture = CustomUniform.texture;
				this.MyRenderer.materials[1].mainTexture = CustomUniform.texture;
			}
			CustomUniform = null;
		}
		else if (StudentGlobals.FemaleUniform == 2)
		{
			WWW CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomLong.png");
			yield return CustomUniform;
			if (CustomUniform.error == null)
			{
				this.MyRenderer.materials[0].mainTexture = CustomUniform.texture;
				this.MyRenderer.materials[1].mainTexture = CustomUniform.texture;
			}
			CustomUniform = null;
		}
		else if (StudentGlobals.FemaleUniform == 3)
		{
			WWW CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomSweater.png");
			yield return CustomUniform;
			if (CustomUniform.error == null)
			{
				this.MyRenderer.materials[0].mainTexture = CustomUniform.texture;
				this.MyRenderer.materials[1].mainTexture = CustomUniform.texture;
			}
			CustomUniform = null;
		}
		else if (StudentGlobals.FemaleUniform == 4 || StudentGlobals.FemaleUniform == 5)
		{
			WWW CustomUniform = new WWW("file:///" + Application.streamingAssetsPath + "/CustomBlazer.png");
			yield return CustomUniform;
			if (CustomUniform.error == null)
			{
				this.MyRenderer.materials[0].mainTexture = CustomUniform.texture;
				this.MyRenderer.materials[1].mainTexture = CustomUniform.texture;
			}
			CustomUniform = null;
		}
		base.StartCoroutine(this.ApplyCustomFace());
		yield break;
	}

	// Token: 0x060018C4 RID: 6340 RVA: 0x000F3CA5 File Offset: 0x000F1EA5
	private IEnumerator ApplyCustomFace()
	{
		WWW CustomFace = new WWW("file:///" + Application.streamingAssetsPath + "/CustomFace.png");
		yield return CustomFace;
		if (CustomFace.error == null)
		{
			this.MyRenderer.materials[2].mainTexture = CustomFace.texture;
			this.FaceTexture = CustomFace.texture;
		}
		WWW CustomHair = new WWW("file:///" + Application.streamingAssetsPath + "/CustomHair.png");
		yield return CustomHair;
		if (CustomHair.error == null)
		{
			this.PonytailRenderer.material.mainTexture = CustomHair.texture;
		}
		yield break;
	}

	// Token: 0x0400259B RID: 9627
	public CharacterController MyController;

	// Token: 0x0400259C RID: 9628
	public StudentManagerScript StudentManager;

	// Token: 0x0400259D RID: 9629
	public HomeVideoGamesScript HomeVideoGames;

	// Token: 0x0400259E RID: 9630
	public HomeCameraScript HomeCamera;

	// Token: 0x0400259F RID: 9631
	public UISprite HomeDarkness;

	// Token: 0x040025A0 RID: 9632
	public Animation CharacterAnimation;

	// Token: 0x040025A1 RID: 9633
	public GameObject CutsceneYandere;

	// Token: 0x040025A2 RID: 9634
	public GameObject Controller;

	// Token: 0x040025A3 RID: 9635
	public GameObject Character;

	// Token: 0x040025A4 RID: 9636
	public GameObject RyobaHair;

	// Token: 0x040025A5 RID: 9637
	public GameObject Disc;

	// Token: 0x040025A6 RID: 9638
	public Renderer LongHairRenderer;

	// Token: 0x040025A7 RID: 9639
	public Renderer PonytailRenderer;

	// Token: 0x040025A8 RID: 9640
	public AudioClip MiyukiReaction;

	// Token: 0x040025A9 RID: 9641
	public AudioClip DiscScratch;

	// Token: 0x040025AA RID: 9642
	public AudioSource MyAudio;

	// Token: 0x040025AB RID: 9643
	public Texture EightiesSocks;

	// Token: 0x040025AC RID: 9644
	public Texture BlondePony;

	// Token: 0x040025AD RID: 9645
	public Texture BlondeLong;

	// Token: 0x040025AE RID: 9646
	public float WalkSpeed;

	// Token: 0x040025AF RID: 9647
	public float RunSpeed;

	// Token: 0x040025B0 RID: 9648
	public bool CannotAlphabet;

	// Token: 0x040025B1 RID: 9649
	public bool UpdateFace;

	// Token: 0x040025B2 RID: 9650
	public bool CanMove;

	// Token: 0x040025B3 RID: 9651
	public bool Running;

	// Token: 0x040025B4 RID: 9652
	public bool HidePony;

	// Token: 0x040025B5 RID: 9653
	public string IdleAnim = "";

	// Token: 0x040025B6 RID: 9654
	public string WalkAnim = "";

	// Token: 0x040025B7 RID: 9655
	public string RunAnim = "";

	// Token: 0x040025B8 RID: 9656
	public int Hairstyle;

	// Token: 0x040025B9 RID: 9657
	public int VictimID;

	// Token: 0x040025BA RID: 9658
	public float Timer;

	// Token: 0x040025BB RID: 9659
	public float BreastSize = 1f;

	// Token: 0x040025BC RID: 9660
	public Transform BreastR;

	// Token: 0x040025BD RID: 9661
	public Transform BreastL;

	// Token: 0x040025BE RID: 9662
	public int AlphabetID;

	// Token: 0x040025BF RID: 9663
	public string[] Letter;

	// Token: 0x040025C0 RID: 9664
	public SkinnedMeshRenderer MyRenderer;

	// Token: 0x040025C1 RID: 9665
	public Texture[] UniformTextures;

	// Token: 0x040025C2 RID: 9666
	public Texture FaceTexture;

	// Token: 0x040025C3 RID: 9667
	public Mesh[] Uniforms;

	// Token: 0x040025C4 RID: 9668
	public RiggedAccessoryAttacher Pajamas;

	// Token: 0x040025C5 RID: 9669
	public Texture PajamaTexture;

	// Token: 0x040025C6 RID: 9670
	public Mesh PajamaMesh;

	// Token: 0x040025C7 RID: 9671
	public Texture NudeTexture;

	// Token: 0x040025C8 RID: 9672
	public Mesh NudeMesh;
}
