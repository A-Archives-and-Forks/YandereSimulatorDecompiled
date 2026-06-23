using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RuntimeWorldLabels : MonoBehaviour
{
	public StalkerYandereScript Yandere;

	public Transform[] targets;

	public string[] labelTexts;

	private Canvas canvas;

	private TextMeshProUGUI[] labels;

	public Camera cam;

	public bool YandereVision;

	public int FontSize;

	private void Awake()
	{
		if (cam == null)
		{
			cam = Camera.main;
		}
		GameObject gameObject = new GameObject("RuntimeCanvas");
		canvas = gameObject.AddComponent<Canvas>();
		canvas.renderMode = RenderMode.ScreenSpaceOverlay;
		gameObject.AddComponent<CanvasScaler>();
		gameObject.AddComponent<GraphicRaycaster>();
		labels = new TextMeshProUGUI[targets.Length];
		for (int i = 0; i < targets.Length; i++)
		{
			GameObject obj = new GameObject("Label_" + i);
			obj.transform.SetParent(canvas.transform);
			TextMeshProUGUI textMeshProUGUI = obj.AddComponent<TextMeshProUGUI>();
			textMeshProUGUI.text = labelTexts[i];
			textMeshProUGUI.fontSize = FontSize;
			textMeshProUGUI.alignment = TextAlignmentOptions.Center;
			labels[i] = textMeshProUGUI;
		}
	}

	private void LateUpdate()
	{
		if (!YandereVision || (YandereVision && Yandere.CanMove && Input.GetButton(InputNames.Xbox_RB)))
		{
			for (int i = 0; i < targets.Length; i++)
			{
				if (!(targets[i] == null))
				{
					Vector3 position = cam.WorldToScreenPoint(targets[i].position);
					if (position.z < 0f)
					{
						labels[i].gameObject.SetActive(value: false);
						continue;
					}
					labels[i].gameObject.SetActive(value: true);
					labels[i].rectTransform.position = position;
				}
			}
		}
		else
		{
			HideLabels();
		}
	}

	public void HideLabels()
	{
		for (int i = 0; i < targets.Length; i++)
		{
			labels[i].gameObject.SetActive(value: false);
		}
	}
}
