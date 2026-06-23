using UnityEngine;

public class HS_BackgroundsChanger : MonoBehaviour
{
	[Header("GUI")]
	private float windowDpi;

	public GameObject[] SceneObjects;

	private int Prefab;

	private int ActiveObject;

	private bool GUIswitcher = true;

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
		Counter(0);
	}

	private void Update()
	{
		if (Input.GetKeyDown("h"))
		{
			GUIswitcher = !GUIswitcher;
		}
	}

	private void OnGUI()
	{
		if (GUIswitcher)
		{
			if (GUI.Button(new Rect(5f * windowDpi, 5f * windowDpi, 110f * windowDpi, 35f * windowDpi), "Previous effect"))
			{
				Counter(-1);
			}
			if (GUI.Button(new Rect(120f * windowDpi, 5f * windowDpi, 110f * windowDpi, 35f * windowDpi), "Play again"))
			{
				Counter(0);
			}
			if (GUI.Button(new Rect(235f * windowDpi, 5f * windowDpi, 110f * windowDpi, 35f * windowDpi), "Next effect"))
			{
				Counter(1);
			}
		}
	}

	private void Counter(int count)
	{
		Prefab += count;
		if (Prefab > SceneObjects.Length - 1)
		{
			Prefab = 0;
		}
		else if (Prefab < 0)
		{
			Prefab = SceneObjects.Length - 1;
		}
		if (SceneObjects[ActiveObject].activeInHierarchy)
		{
			SceneObjects[ActiveObject].SetActive(value: false);
		}
		ActiveObject = Prefab;
		SceneObjects[Prefab].SetActive(value: true);
	}
}
