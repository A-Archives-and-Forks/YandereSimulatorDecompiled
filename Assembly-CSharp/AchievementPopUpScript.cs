using UnityEngine;

public class AchievementPopUpScript : MonoBehaviour
{
	public string[] AchievementFancyNames;

	public string[] AchievementNames;

	public Texture[] AchievementIcons;

	public int[] PreviousNumber;

	public float ShowTimer;

	public float Timer;

	public Camera MyCamera;

	public UITexture Icon;

	public UILabel Label;

	public bool Show;

	public int DebugID;

	private static AchievementPopUpScript instance;

	private void Start()
	{
		if (instance != null)
		{
			Object.Destroy(base.gameObject);
			Object.Destroy(base.transform.parent.parent.gameObject);
			return;
		}
		Object.DontDestroyOnLoad(base.gameObject);
		Object.DontDestroyOnLoad(base.transform.parent.parent.gameObject);
		instance = this;
		base.transform.localPosition = new Vector3(637f, -613f, 0f);
		for (int i = 1; i < AchievementNames.Length; i++)
		{
			PreviousNumber[i] = PlayerPrefs.GetInt(AchievementNames[i]);
		}
		MyCamera.enabled = false;
	}

	private void Update()
	{
		if (Show)
		{
			ShowTimer += Time.deltaTime;
			if (ShowTimer < 5f)
			{
				base.transform.localPosition = Vector3.Lerp(base.transform.localPosition, new Vector3(base.transform.localPosition.x, -413f, 0f), Time.unscaledDeltaTime * 10f);
				return;
			}
			base.transform.localPosition = Vector3.MoveTowards(base.transform.localPosition, new Vector3(base.transform.localPosition.x, -613f, 0f), Time.unscaledDeltaTime * 100f);
			if (base.transform.localPosition == new Vector3(base.transform.localPosition.x, -613f, 0f))
			{
				MyCamera.enabled = false;
				ShowTimer = 0f;
				Show = false;
			}
			return;
		}
		Timer = Mathf.MoveTowards(Timer, 1f, Time.deltaTime);
		if (Timer != 1f)
		{
			return;
		}
		Timer = 0f;
		if (PlayerPrefs.GetInt("a") != 1)
		{
			return;
		}
		PlayerPrefs.SetInt("a", 0);
		for (int i = 1; i < AchievementNames.Length; i++)
		{
			if (PlayerPrefs.GetInt(AchievementNames[i]) != PreviousNumber[i])
			{
				PreviousNumber[i] = PlayerPrefs.GetInt(AchievementNames[i]);
				Label.text = AchievementFancyNames[i] ?? "";
				Icon.mainTexture = AchievementIcons[i];
				MyCamera.enabled = true;
				Show = true;
				i = 99;
			}
		}
	}

	public void Reset()
	{
		for (int i = 1; i < AchievementNames.Length; i++)
		{
			PreviousNumber[i] = 0;
		}
	}
}
