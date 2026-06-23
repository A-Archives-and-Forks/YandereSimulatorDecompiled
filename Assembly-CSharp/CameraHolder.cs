using UnityEngine;

public class CameraHolder : MonoBehaviour
{
	private float windowDpi;

	private GUIStyle screenGUI = new GUIStyle();

	public GameObject[] Prefabs;

	private int Prefab;

	private GameObject Instance;

	private void Start()
	{
		if (Screen.dpi < 1f)
		{
			windowDpi = 1f;
		}
		if (Screen.dpi < 200f)
		{
			windowDpi = 1f;
		}
		else
		{
			windowDpi = Screen.dpi / 200f;
		}
		screenGUI.fontSize = (int)(15f * windowDpi);
		screenGUI.normal.textColor = new Color(0.5f, 0f, 0f);
		Counter(0);
	}

	private void OnGUI()
	{
		if (GUI.Button(new Rect(5f * windowDpi, 5f * windowDpi, 110f * windowDpi, 30f * windowDpi), "Previous effect"))
		{
			Counter(-1);
		}
		if (GUI.Button(new Rect(120f * windowDpi, 5f * windowDpi, 110f * windowDpi, 30f * windowDpi), "Next effect"))
		{
			Counter(1);
		}
	}

	private void Counter(int count)
	{
		Prefab += count;
		if (Prefab > Prefabs.Length - 1)
		{
			Prefab = 0;
		}
		else if (Prefab < 0)
		{
			Prefab = Prefabs.Length - 1;
		}
		if (Instance != null)
		{
			Object.Destroy(Instance);
		}
		Instance = Object.Instantiate(Prefabs[Prefab]);
	}
}
