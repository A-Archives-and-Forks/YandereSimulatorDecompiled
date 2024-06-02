using UnityEngine;

public class PoolSignScript : MonoBehaviour
{
	public StudentManagerScript StudentManager;

	public float Timer;

	private void Update()
	{
		Timer = Mathf.MoveTowards(Timer, 5f, Time.deltaTime);
		if (Timer != 5f)
		{
			return;
		}
		Timer = 0f;
		for (int i = 1; i < 101; i++)
		{
			if (!(StudentManager.Students[i] != null) || !StudentManager.Students[i].Alive || StudentManager.Students[i].Schoolwear != 2 || !(Vector3.Distance(StudentManager.Students[i].transform.position, base.transform.position) < 5f))
			{
				continue;
			}
			if (StudentManager.Eighties && i == 15)
			{
				StudentManager.Students[i].Subtitle.CustomText = "This sign can't stop me, because I don't care.";
				StudentManager.Students[i].Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
				continue;
			}
			Debug.Log("Student's current Phase is: " + StudentManager.Students[i].Phase);
			Debug.Log("And student's current Action is: " + StudentManager.Students[i].Actions[StudentManager.Students[i].Phase]);
			if (StudentManager.Students[i].Actions[StudentManager.Students[i].Phase] == StudentActionType.Sunbathe)
			{
				Debug.Log("Met criteria to react to pool sign.");
				StudentManager.Students[i].Subtitle.CustomText = "Oh...it's closed? Sigh...never mind, then...";
				StudentManager.Students[i].Subtitle.UpdateLabel(SubtitleType.Custom, 0, 5f);
				StudentManager.ForgetAboutSunbathing(i);
			}
		}
	}
}
