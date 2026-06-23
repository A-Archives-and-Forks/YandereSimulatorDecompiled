using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
	public GameObject Disclaimer;

	public GameObject NiceBoat;

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.N))
		{
			Disclaimer.SetActive(!Disclaimer.activeInHierarchy);
			NiceBoat.SetActive(!NiceBoat.activeInHierarchy);
		}
	}
}
