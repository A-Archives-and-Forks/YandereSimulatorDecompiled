using UnityEngine;

public class TownMapScript : MonoBehaviour
{
	public TownManagerScript TownManager;

	public StalkerYandereScript Yandere;

	public RuntimeWorldLabels Labels;

	public float Speed;

	private void Update()
	{
		base.transform.position -= new Vector3(0f, 0f, Input.GetAxis("Vertical") * Speed * Time.deltaTime);
		base.transform.position -= new Vector3(Input.GetAxis("Horizontal") * Speed * Time.deltaTime, 0f, 0f);
		if (Input.GetButton(InputNames.Xbox_LB))
		{
			base.transform.localPosition -= new Vector3(0f, 0f, Speed * Time.deltaTime);
		}
		if (Input.GetButton(InputNames.Xbox_RB))
		{
			base.transform.localPosition += new Vector3(0f, 0f, Speed * Time.deltaTime);
		}
		if (base.transform.position.x < -1000f)
		{
			base.transform.position = new Vector3(-1000f, base.transform.position.y, base.transform.position.z);
		}
		if (base.transform.position.x > 1000f)
		{
			base.transform.position = new Vector3(1000f, base.transform.position.y, base.transform.position.z);
		}
		if (base.transform.position.y < 50f)
		{
			base.transform.position = new Vector3(base.transform.position.x, 50f, base.transform.position.z);
		}
		if (base.transform.position.y > 1000f)
		{
			base.transform.position = new Vector3(base.transform.position.x, 1000f, base.transform.position.z);
		}
		if (base.transform.position.z < -1000f)
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, -1000f);
		}
		if (base.transform.position.z > 1000f)
		{
			base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, 1000f);
		}
		if (Input.GetButtonDown(InputNames.Xbox_Back) || Input.GetKeyDown("space"))
		{
			Debug.Log("Now exiting the map screen.");
			base.transform.parent.gameObject.SetActive(value: false);
			base.transform.localPosition = new Vector3(0f, 0f, 0f);
			TownManager.MapTimer = 1;
			Yandere.CanMove = true;
			Labels.HideLabels();
		}
	}
}
