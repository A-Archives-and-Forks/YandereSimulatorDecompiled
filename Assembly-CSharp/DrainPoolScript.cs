using UnityEngine;

public class DrainPoolScript : MonoBehaviour
{
	public OsanaPoolEventScript OsanaPoolEvent;

	public StudentManagerScript SM;

	public UISprite SubDarkness;

	public PromptScript Prompt;

	public AudioSource MyAudio;

	public int Phase;

	public bool Fade;

	private void Update()
	{
		if (Prompt.Circle[0].fillAmount == 0f)
		{
			Prompt.Circle[0].fillAmount = 1f;
			if (SM.Students[SM.RivalID] != null && SM.Students[SM.RivalID].DeathType == DeathType.Drowning)
			{
				Prompt.Yandere.CharacterAnimation.CrossFade(Prompt.Yandere.IdleAnim);
				Prompt.Yandere.CanMove = false;
				Fade = true;
				Phase = 1;
			}
			else
			{
				Prompt.Yandere.NotificationManager.CustomText = "No Corpse In Pool.";
				Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
			}
		}
		if (!Fade)
		{
			return;
		}
		if (Phase == 1)
		{
			SubDarkness.alpha += Time.deltaTime;
			if (SubDarkness.alpha >= 1f)
			{
				MyAudio.Play();
				Phase++;
			}
		}
		else if (Phase == 2)
		{
			if (!MyAudio.isPlaying)
			{
				SM.Students[SM.RivalID].transform.position = Prompt.Yandere.transform.position + new Vector3(0f, 0.1f, 0f);
				Physics.SyncTransforms();
				SM.Students[SM.RivalID].CharacterAnimation.Play("f02_knifeHighSanityB_00");
				if (SM.RivalID == 11)
				{
					OsanaPoolEvent.AttachHair();
				}
				SM.Students[SM.RivalID].CharacterAnimation["f02_knifeHighSanityB_00"].time = SM.Students[SM.RivalID].CharacterAnimation["f02_knifeHighSanityB_00"].length;
				Phase++;
			}
		}
		else if (Phase == 3)
		{
			SM.Students[SM.RivalID].Ragdoll.enabled = true;
			Phase++;
		}
		else if (Phase == 4)
		{
			SubDarkness.alpha -= Time.deltaTime;
			if (SubDarkness.alpha <= 0f)
			{
				Prompt.Yandere.CanMove = true;
				Fade = false;
				Prompt.enabled = false;
				Prompt.Hide();
				base.enabled = false;
			}
		}
	}
}
