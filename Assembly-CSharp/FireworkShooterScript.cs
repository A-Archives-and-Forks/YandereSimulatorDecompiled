using UnityEngine;

public class FireworkShooterScript : MonoBehaviour
{
	public GameObject[] Fireworks;

	public float Interval;

	public float Timer;

	private void Update()
	{
		Timer -= Time.deltaTime;
		if (Timer <= 0f)
		{
			Object.Instantiate(Fireworks[Random.Range(0, Fireworks.Length)], base.transform.position, Quaternion.identity);
			Timer = Interval + Random.Range(0f, 1f);
		}
	}
}
