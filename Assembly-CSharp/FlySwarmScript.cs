using UnityEngine;

public class FlySwarmScript : MonoBehaviour
{
	public GameObject[] FlyParent;

	public Transform AllParents;

	public float Speed = 360f;

	private void Start()
	{
		for (int i = 1; i < FlyParent.Length; i++)
		{
			FlyParent[i].transform.localEulerAngles = new Vector3(Random.Range(0f, Speed), Random.Range(0f, Speed), Random.Range(0f, Speed));
		}
		GetComponent<AudioSource>().pitch = Random.Range(0.9f, 1.1f);
	}

	private void Update()
	{
		AllParents.Rotate(Time.deltaTime * Speed, Time.deltaTime * Speed, Time.deltaTime * Speed, Space.Self);
		for (int i = 1; i < FlyParent.Length; i++)
		{
			if (i < 6)
			{
				FlyParent[i].transform.Rotate(0f, Time.deltaTime * Speed, 0f, Space.Self);
			}
			else
			{
				FlyParent[i].transform.Rotate(0f, Time.deltaTime * Speed, 0f, Space.Self);
			}
		}
	}
}
