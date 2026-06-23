using UnityEngine;

public class CensorBillboard : MonoBehaviour
{
	public float cameraPush = 0.06f;

	private Camera cam;

	private void Start()
	{
		cam = Camera.main;
	}

	private void LateUpdate()
	{
		if (!cam)
		{
			cam = Camera.main;
		}
		if ((bool)cam)
		{
			Vector3 position = (base.transform.parent ? base.transform.parent : base.transform).position;
			Vector3 vector = cam.transform.position - position;
			if (vector.sqrMagnitude < 1E-06f)
			{
				vector = cam.transform.forward;
			}
			else
			{
				vector.Normalize();
			}
			base.transform.position = position + vector * cameraPush;
			base.transform.rotation = Quaternion.LookRotation(base.transform.position - cam.transform.position, cam.transform.up);
		}
	}
}
