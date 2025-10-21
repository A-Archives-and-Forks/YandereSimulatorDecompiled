using UnityEngine;

public class BoneLookAtCamera : MonoBehaviour
{
	public Transform targetCamera;

	public Vector3 localAxis = Vector3.forward;

	private void LateUpdate()
	{
		if (!(targetCamera == null))
		{
			Vector3 fromDirection = base.transform.TransformDirection(localAxis);
			Vector3 toDirection = targetCamera.position - base.transform.position;
			Quaternion quaternion = Quaternion.FromToRotation(fromDirection, toDirection);
			base.transform.rotation = quaternion * base.transform.rotation;
		}
	}
}
