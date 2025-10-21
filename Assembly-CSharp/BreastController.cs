using UnityEngine;

public class BreastController : MonoBehaviour
{
	[Header("Referências")]
	public Transform breastRight;

	public Transform breastLeft;

	[Header("Configuração de Escala")]
	[Range(1f, 2f)]
	public float scale = 1f;

	public bool enableScale = true;

	[Header("Rotação Y (Inclinação Lateral)")]
	public bool enableRotationY = true;

	[Header("Rotação X (Peso)")]
	public bool enableRotationX = true;

	private void LateUpdate()
	{
		if (!(breastRight == null) && !(breastLeft == null))
		{
			Vector3 localScale = Vector3.one * scale;
			if (enableScale)
			{
				float t = Mathf.Clamp01((scale - 1f) / 0.5f);
				float num = Mathf.Lerp(1f, 0.8f, t);
				localScale.x = scale * num;
			}
			breastRight.localScale = localScale;
			breastLeft.localScale = localScale;
			float num2 = 0f;
			if (enableRotationY)
			{
				num2 = (scale - 1f) * 17f;
			}
			float x = 0f;
			if (enableRotationX)
			{
				float t2 = Mathf.Clamp01((scale - 1f) / 0.5f);
				x = Mathf.Lerp(0f, 14.5f, t2);
			}
			breastRight.localEulerAngles = new Vector3(x, 0f - num2, 0f);
			breastLeft.localEulerAngles = new Vector3(x, num2, 0f);
		}
	}
}
