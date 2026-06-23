using UnityEngine;

public class YouTubeFootageCameraScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public YandereScript Yandere;

	public GameObject MainCamera;

	public GameObject UICamera;

	public Transform Senpai;

	public Camera MyCamera;

	public float Rotation;

	public float Target;

	public int Phase;

	public void Update()
	{
		if (Input.GetButtonDown(InputNames.Xbox_RB))
		{
			MyCamera.enabled = true;
			Time.timeScale = 0.1f;
		}
		if (Input.GetKeyDown("x"))
		{
			StudentManager.Students[1].gameObject.SetActive(value: false);
			StudentManager.FPSDisplay.SetActive(value: false);
			MainCamera.SetActive(value: false);
			UICamera.SetActive(value: false);
		}
		if (Phase == 1)
		{
			base.transform.LookAt(Senpai.transform.position);
			base.transform.eulerAngles = new Vector3(0f, base.transform.eulerAngles.y, 0f);
		}
	}
}
