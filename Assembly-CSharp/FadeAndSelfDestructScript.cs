using UnityEngine;

public class FadeAndSelfDestructScript : MonoBehaviour
{
	public float Timer;

	public Renderer MyRenderer;

	private void Update()
	{
		Timer += Time.deltaTime;
		if (Timer > 0.1f)
		{
			MyRenderer.material.color = new Color(0f, 0f, 0f, MyRenderer.material.color.a - Time.deltaTime);
			if (MyRenderer.material.color.a <= 0f)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}
}
