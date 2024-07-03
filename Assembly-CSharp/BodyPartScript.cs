using UnityEngine;

public class BodyPartScript : MonoBehaviour
{
	public bool Sacrifice;

	public int StudentID;

	public int Type;

	public GameObject GarbageBag;

	public PromptScript Prompt;

	public AudioClip WrapSFX;

	public MeshRenderer MyRenderer;

	public MeshFilter MyFilter;

	public Texture[] Textures;

	public Mesh[] Meshes;

	public bool Female;

	private void Start()
	{
		if (Female && Type == 2)
		{
			MyFilter.mesh = Meshes[StudentGlobals.FemaleUniform];
			MyRenderer.materials[0].mainTexture = Textures[StudentGlobals.FemaleUniform];
			MyRenderer.materials[1].mainTexture = Textures[StudentGlobals.FemaleUniform];
		}
	}

	private void Update()
	{
		if (Prompt != null)
		{
			if (Prompt.Yandere.PickUp != null && Prompt.Yandere.PickUp.GarbageBagBox)
			{
				Prompt.HideButton[0] = false;
				if (Prompt.Circle[0].fillAmount == 0f)
				{
					GameObject gameObject = Object.Instantiate(GarbageBag, base.transform.position, Quaternion.identity);
					gameObject.GetComponent<BodyPartScript>().StudentID = StudentID;
					gameObject.transform.parent = Prompt.Yandere.Police.GarbageParent;
					Prompt.Yandere.StudentManager.GarbageBagList[Prompt.Yandere.StudentManager.GarbageBags] = gameObject;
					Prompt.Yandere.StudentManager.GarbageBags++;
					AudioSource.PlayClipAtPoint(WrapSFX, base.transform.position);
					Object.Destroy(base.gameObject);
				}
			}
			else
			{
				Prompt.HideButton[0] = true;
			}
		}
		else
		{
			Prompt = base.gameObject.GetComponent<PromptScript>();
		}
		if (Prompt.Yandere.StudentManager.KokonaTutorialObject.Phase == 2)
		{
			Prompt.Hide();
			Object.Destroy(base.gameObject);
		}
	}
}
