using UnityEngine;

public class SimpleLookScript : MonoBehaviour
{
	public StudentScript Student;

	public PerfectLookAt HeadLookAt;

	public PerfectLookAt NeckLookAt;

	public PerfectLookAt SpineLookAt;

	public Transform EyeL;

	public Transform EyeR;

	public Transform Head;

	public Transform Neck;

	public Transform Spine;

	public Transform YandereHead;

	public Transform MyHead;

	public Transform Forward;

	public Transform LookTarget;

	public Transform Yandere;

	public float PreviousEye;

	public float PreviousHead;

	public float PreviousNeck;

	public float PreviousSpine;

	public float Rotation;

	public float IgnoreTimer;

	public float LookTimer;

	public float Speed;

	public float Timer;

	public bool Ignore;

	public bool Look;

	private void Start()
	{
		LookTarget.parent = base.transform.parent;
		HeadLookAt.enabled = false;
		NeckLookAt.enabled = false;
		SpineLookAt.enabled = false;
		Yandere = Student.Yandere.transform;
		YandereHead = Student.Yandere.Head;
	}

	private void LateUpdate()
	{
		if (Student.Routine)
		{
			if (Student.DistanceToPlayer < 2f || Look)
			{
				if (Mathf.Abs(Vector3.Angle(-base.transform.forward, Yandere.transform.position - base.transform.position)) >= 90f && Student.DistanceToPlayer < 2f && !Ignore)
				{
					LookTimer += Time.deltaTime;
					if (LookTimer > 5f)
					{
						LookTimer = 0f;
						Ignore = true;
					}
					Look = true;
					Timer = 0f;
				}
				else
				{
					if (Ignore)
					{
						IgnoreTimer += Time.deltaTime;
						if (IgnoreTimer > 5f)
						{
							IgnoreTimer = 0f;
							Ignore = false;
						}
					}
					if (Look)
					{
						Timer += Time.deltaTime;
						if (Timer > 2f)
						{
							Look = false;
							Timer = 0f;
						}
					}
				}
			}
		}
		else
		{
			Look = false;
		}
		if (Look)
		{
			float f = Vector3.Angle(base.transform.forward, Yandere.transform.position - base.transform.position);
			Vector3 vector = YandereHead.transform.position - MyHead.transform.position;
			float num = Vector3.Angle(base.transform.right, new Vector3(vector.x, 0f, vector.z));
			if (Mathf.Abs(f) <= 90f && Student.DistanceToPlayer < 2f && !Ignore)
			{
				if (num <= 90f)
				{
					float num2 = (90f - num) / 90f;
					Rotation = Mathf.Lerp(Rotation, 10f * num2, Time.deltaTime * 3.6f);
				}
				else
				{
					float num3 = (90f - (180f - num)) / 90f;
					Rotation = Mathf.Lerp(Rotation, -10f * num3, Time.deltaTime * 3.6f);
				}
			}
			else
			{
				Rotation = Mathf.Lerp(Rotation, 0f, Time.deltaTime * 3.6f * 0.5f);
			}
			if (EyeL.localEulerAngles.y != PreviousEye)
			{
				EyeL.localEulerAngles += new Vector3(0f, Rotation, 0f);
				EyeR.localEulerAngles += new Vector3(0f, Rotation, 0f);
			}
			if (Head.localEulerAngles.y != PreviousHead)
			{
				Head.localEulerAngles += new Vector3(0f, Rotation * 2f, 0f);
			}
			if (Neck.localEulerAngles.y != PreviousNeck)
			{
				Neck.localEulerAngles += new Vector3(0f, Rotation * 1.5f, 0f);
			}
			if (Spine.localEulerAngles.y != PreviousSpine)
			{
				Spine.localEulerAngles += new Vector3(0f, Rotation * 1f, 0f);
			}
			PreviousEye = EyeL.localEulerAngles.y;
			PreviousHead = Head.localEulerAngles.y;
			PreviousNeck = Neck.localEulerAngles.y;
			PreviousSpine = Spine.localEulerAngles.y;
		}
		if (!Student.Alive)
		{
			base.enabled = false;
		}
	}
}
