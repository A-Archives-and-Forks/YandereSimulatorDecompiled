using System;
using UnityEngine;

public class SkinnedMeshUpdater : MonoBehaviour
{
	public ChinaDressScript ChinaDress;

	public SkinnedMeshRenderer MyRenderer;

	public GameObject TransformEffect;

	public GameObject[] Characters;

	public PromptScript Prompt;

	public GameObject BreastR;

	public GameObject BreastL;

	public GameObject FumiGlasses;

	public GameObject NinaGlasses;

	private SkinnedMeshRenderer TempRenderer;

	public Texture[] Bodies;

	public Texture[] Faces;

	public bool Cosplaying;

	public float Timer;

	public int ID;

	public void Start()
	{
		GlassesCheck();
	}

	public void Update()
	{
		if (Prompt.Circle[0].fillAmount != 0f)
		{
			return;
		}
		Prompt.Circle[0].fillAmount = 1f;
		if (!ChinaDress.Chinese)
		{
			UnityEngine.Object.Instantiate(TransformEffect, Prompt.Yandere.Hips.position, Quaternion.identity);
			Prompt.Yandere.CharacterAnimation.Play(Prompt.Yandere.IdleAnim);
			Prompt.Yandere.Egg = true;
			BreastR.name = "RightBreast";
			BreastL.name = "LeftBreast";
			Timer = 1f;
			ID++;
			if (ID == Characters.Length)
			{
				ID = 1;
			}
			Prompt.Yandere.Hairstyle = 120 + ID;
			Prompt.Yandere.UpdateHair();
			ChinaDress.Disable();
			GlassesCheck();
			UpdateSkin();
			Cosplaying = true;
		}
		else
		{
			Prompt.Yandere.NotificationManager.CustomText = "Can't Cosplay While Wearing Dress";
			Prompt.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
		}
	}

	public void UpdateSkin()
	{
		GameObject gameObject = UnityEngine.Object.Instantiate(Characters[ID], Vector3.zero, Quaternion.identity);
		TempRenderer = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
		UpdateMeshRenderer(TempRenderer);
		UnityEngine.Object.Destroy(gameObject);
		MyRenderer.materials[0].mainTexture = Bodies[ID];
		MyRenderer.materials[1].mainTexture = Bodies[ID];
		MyRenderer.materials[2].mainTexture = Faces[ID];
	}

	private void UpdateMeshRenderer(SkinnedMeshRenderer newMeshRenderer)
	{
		SkinnedMeshRenderer myRenderer = Prompt.Yandere.MyRenderer;
		myRenderer.sharedMesh = newMeshRenderer.sharedMesh;
		Transform[] componentsInChildren = Prompt.Yandere.transform.GetComponentsInChildren<Transform>(includeInactive: true);
		Transform[] array = new Transform[newMeshRenderer.bones.Length];
		int boneOrder;
		for (boneOrder = 0; boneOrder < newMeshRenderer.bones.Length; boneOrder++)
		{
			array[boneOrder] = Array.Find(componentsInChildren, (Transform c) => c.name == newMeshRenderer.bones[boneOrder].name);
		}
		myRenderer.bones = array;
	}

	private void GlassesCheck()
	{
		FumiGlasses.SetActive(value: false);
		NinaGlasses.SetActive(value: false);
		if (ID == 7)
		{
			FumiGlasses.SetActive(value: true);
		}
		else if (ID == 8)
		{
			NinaGlasses.SetActive(value: true);
		}
	}
}
