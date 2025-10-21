using UnityEngine;

public class BlinkingLightByScale : MonoBehaviour
{
	[Header("References")]
	public Light targetLight;

	public Transform referenceObject;

	[Header("Intensity Settings")]
	public float intensityMultiplier = 1f;

	public float minIntensity = 0.5f;

	public float maxIntensity = 2f;

	[Header("Blink Settings")]
	public float blinkSpeed = 2f;

	private void Update()
	{
		if (!(targetLight == null) && !(referenceObject == null))
		{
			float x = referenceObject.localScale.x;
			float num = (Mathf.Sin(Time.time * blinkSpeed) + 1f) / 2f;
			float value = Mathf.Lerp(minIntensity, maxIntensity, num * x * intensityMultiplier);
			targetLight.intensity = Mathf.Clamp(value, minIntensity, maxIntensity);
		}
	}
}
