using UnityEngine;

public class BodyHidingLockerScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public OutlineScript Outline;

	public RagdollScript Corpse;

	public PromptScript Prompt;

	public AudioClip LockerClose;

	public AudioClip LockerOpen;

	public float Rotation;

	public float Speed;

	public Transform Door;

	public int StudentID;

	public bool Locker = true;

	public bool Freezer;

	public bool Coffin;

	public bool Chest;

	public bool ABC;

	private void Start()
	{
		Outline = GetComponentInChildren<OutlineScript>();
	}

	private void Update()
	{
		if (Locker)
		{
			if (Rotation != 0f)
			{
				Speed += Time.deltaTime * 100f;
				Rotation = Mathf.MoveTowards(Rotation, 0f, Speed * Time.deltaTime);
				if (Rotation > -1f)
				{
					AudioSource.PlayClipAtPoint(LockerClose, Prompt.Yandere.MainCamera.transform.position);
					if (Corpse != null)
					{
						Corpse.gameObject.SetActive(value: false);
					}
					Prompt.enabled = true;
					Rotation = 0f;
					Speed = 0f;
					if (ABC)
					{
						Prompt.Hide();
						Prompt.enabled = false;
						base.enabled = false;
					}
				}
				Door.transform.localEulerAngles = new Vector3(0f, Rotation, 0f);
			}
		}
		else if (Coffin)
		{
			if (Rotation != -90f)
			{
				Door.transform.localEulerAngles = new Vector3(Rotation, 90f, 90f);
				Speed += Time.deltaTime * 2f;
				Rotation = Mathf.Lerp(Rotation, -90f, Speed * Time.deltaTime);
				if (Rotation < -89.9f)
				{
					if (Corpse != null)
					{
						Corpse.gameObject.SetActive(value: false);
					}
					Prompt.enabled = true;
					Rotation = -90f;
					Speed = 0f;
					if (ABC)
					{
						Prompt.Hide();
						Prompt.enabled = false;
						base.enabled = false;
					}
				}
				Door.transform.localEulerAngles = new Vector3(Rotation, 90f, 90f);
			}
		}
		else if (Chest)
		{
			if (Rotation != -90f)
			{
				Speed += Time.deltaTime * 100f;
				Rotation = Mathf.MoveTowards(Rotation, -90f, Speed * Time.deltaTime);
				if (Rotation < -89.9f)
				{
					AudioSource.PlayClipAtPoint(LockerClose, Prompt.Yandere.MainCamera.transform.position);
					if (Corpse != null)
					{
						Corpse.gameObject.SetActive(value: false);
					}
					Prompt.enabled = true;
					Rotation = -90f;
					Speed = 0f;
					if (ABC)
					{
						Prompt.Hide();
						Prompt.enabled = false;
						base.enabled = false;
					}
				}
				Door.transform.localEulerAngles = new Vector3(Rotation, -90f, -90f);
			}
		}
		else if (Freezer && Rotation < 0f)
		{
			Speed += Time.deltaTime * 100f;
			Rotation = Mathf.MoveTowards(Rotation, 0f, Speed * Time.deltaTime);
			if (Rotation > -0.1f)
			{
				AudioSource.PlayClipAtPoint(LockerClose, Prompt.Yandere.MainCamera.transform.position);
				if (Corpse != null)
				{
					Corpse.gameObject.SetActive(value: false);
				}
				Prompt.enabled = true;
				Rotation = 0f;
				Speed = 0f;
				if (ABC)
				{
					Prompt.Hide();
					Prompt.enabled = false;
					base.enabled = false;
				}
			}
			Door.transform.localEulerAngles = new Vector3(Rotation, 0f, 0f);
		}
		if (Corpse == null)
		{
			if (Prompt.Yandere.Carrying || Prompt.Yandere.Dragging)
			{
				Prompt.enabled = true;
				if (Prompt.Circle[0].fillAmount != 0f)
				{
					return;
				}
				Debug.Log("Putting corpse into container now.");
				Prompt.Circle[0].fillAmount = 1f;
				AudioSource.PlayClipAtPoint(LockerOpen, Prompt.Yandere.MainCamera.transform.position);
				if (Prompt.Yandere.Carrying)
				{
					Corpse = Prompt.Yandere.CurrentRagdoll;
				}
				else
				{
					Corpse = Prompt.Yandere.Ragdoll.GetComponent<RagdollScript>();
				}
				Prompt.Label[0].text = "     Remove Corpse";
				Prompt.Hide();
				Prompt.enabled = false;
				Prompt.Yandere.EmptyHands();
				if (Corpse.AddingToCount)
				{
					Prompt.Yandere.NearBodies--;
					Corpse.AddingToCount = false;
				}
				Prompt.Yandere.NearestCorpseID = 0;
				Prompt.Yandere.CorpseWarning = false;
				Prompt.Yandere.StudentManager.UpdateStudents();
				Corpse.transform.parent = base.transform;
				if (!Corpse.Concealed)
				{
					if (Corpse.Police == null)
					{
						Corpse.Police = Corpse.Student.Police;
					}
					Corpse.Police.HiddenCorpses++;
				}
				Corpse.enabled = false;
				Corpse.Hidden = true;
				StudentID = Corpse.StudentID;
				if (ABC)
				{
					Corpse.DestroyRigidbodies();
				}
				else
				{
					Corpse.BloodSpawnerCollider.enabled = false;
					Corpse.Prompt.MyCollider.enabled = false;
					Corpse.BloodPoolSpawner.enabled = false;
					Corpse.DisableRigidbodies();
				}
				Corpse.Student.CharacterAnimation.enabled = true;
				if (Corpse.Decapitated)
				{
					Corpse.Head.transform.localScale = Vector3.zero;
				}
				if (Locker)
				{
					Corpse.transform.position = base.transform.position + new Vector3(0f, 0.1f, 0f);
					Corpse.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
					Corpse.Student.CharacterAnimation.Play("f02_lockerPose_00");
					Rotation = -180f;
				}
				else if (Coffin)
				{
					Corpse.transform.localPosition = new Vector3(0f, 0.01433333f, 0f);
					Corpse.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
					Corpse.Student.CharacterAnimation.Play("f02_hidden_00");
					Rotation = -35f;
					Door.transform.localEulerAngles = new Vector3(-35f, 90f, 90f);
				}
				else if (Chest)
				{
					Corpse.transform.localPosition = new Vector3(-0.01436667f, 0f, -0.001f);
					Corpse.transform.localEulerAngles = new Vector3(0f, 90f, 90f);
					Corpse.Student.CharacterAnimation.Play("f02_hidden_00");
					Rotation = -45f;
					Door.transform.localEulerAngles = new Vector3(-45f, -90f, -90f);
				}
				else if (Freezer)
				{
					Corpse.transform.localPosition = new Vector3(0f, -0.0085f, -0.000365f);
					Corpse.transform.localEulerAngles = new Vector3(-90f, 180f, 0f);
					Corpse.Student.CharacterAnimation.Play("f02_hidden_00");
					Rotation = -52f;
					Door.transform.localEulerAngles = new Vector3(-52f, 0f, 0f);
				}
				if (Outline != null)
				{
					Outline.color = new Color(1f, 0.5f, 0f, 1f);
				}
				Corpse.Locker = this;
			}
			else if (Prompt.enabled)
			{
				Prompt.Hide();
				Prompt.enabled = false;
			}
		}
		else if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Hide();
			Prompt.enabled = false;
			Prompt.Label[0].text = "     Hide Corpse";
			AudioSource.PlayClipAtPoint(LockerOpen, Prompt.Yandere.MainCamera.transform.position);
			Corpse.enabled = true;
			Corpse.CharacterAnimation.enabled = false;
			Corpse.BloodSpawnerCollider.enabled = true;
			Corpse.Prompt.MyCollider.enabled = true;
			Corpse.BloodPoolSpawner.NearbyBlood = 0;
			Corpse.AddingToCount = false;
			Corpse.EnableRigidbodies();
			if (!Corpse.Cauterized && !Corpse.Concealed)
			{
				Corpse.BloodPoolSpawner.enabled = true;
			}
			for (int i = 0; i < Corpse.Student.FireEmitters.Length; i++)
			{
				Corpse.Student.FireEmitters[i].gameObject.SetActive(value: false);
			}
			if (Locker)
			{
				Corpse.transform.localPosition = new Vector3(0f, 0f, 0.5f);
				Corpse.transform.localEulerAngles = new Vector3(0f, -90f, 0.5f);
				Corpse.transform.parent = null;
				Rotation = -180f;
			}
			else if (Coffin)
			{
				Corpse.transform.parent = null;
				Corpse.transform.position = base.transform.position + new Vector3(-1f, 0f, 0f);
				Corpse.Student.Hips.position = base.transform.position + new Vector3(-1f, 0.5f, 0f);
				Corpse.transform.eulerAngles = new Vector3(0f, 0f, 0f);
				Rotation = -35f;
				Door.transform.localEulerAngles = new Vector3(-35f, 90f, 90f);
			}
			else if (Chest)
			{
				Corpse.transform.parent = null;
				Corpse.transform.position = Prompt.Yandere.transform.position;
				Corpse.Student.Hips.position = Prompt.Yandere.transform.position + new Vector3(0f, 0.5f, 0f);
				Corpse.transform.eulerAngles = new Vector3(0f, 0f, 0f);
				Rotation = -45f;
				Door.transform.localEulerAngles = new Vector3(-45f, -90f, -90f);
			}
			else if (Freezer)
			{
				Corpse.transform.parent = null;
				Corpse.transform.position = Prompt.Yandere.transform.position;
				Corpse.Student.Hips.position = Prompt.Yandere.transform.position + new Vector3(0f, 0.5f, 0f);
				Corpse.transform.eulerAngles = new Vector3(0f, 0f, 0f);
				Rotation = -52f;
				Door.transform.localEulerAngles = new Vector3(-52f, 0f, 0f);
			}
			Corpse.transform.localScale = new Vector3(1f, 1f, 1f);
			Corpse.gameObject.SetActive(value: true);
			Corpse.Locker = null;
			Corpse = null;
			Outline.color = new Color(0f, 1f, 1f, 1f);
			StudentID = 0;
		}
	}

	public void LateUpdate()
	{
		if (Rotation != 0f && Corpse != null && Corpse.Decapitated)
		{
			Debug.Log("Trying to shrink Corpse head?");
			Corpse.Head.transform.localScale = Vector3.zero;
		}
	}

	public void UpdateCorpse()
	{
		Corpse = StudentManager.Students[StudentID].Ragdoll;
		Corpse.transform.parent = base.transform;
		Prompt.Label[0].text = "     Remove Corpse";
		Prompt.enabled = true;
	}
}
