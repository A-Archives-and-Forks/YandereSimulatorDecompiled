using UnityEngine;

public class FootprintScript : MonoBehaviour
{
	public YandereScript Yandere;

	public Texture OriginalTexture;

	public Texture Footprint;

	public Texture Flower;

	public int StudentBloodID;

	private void Start()
	{
		Renderer component = base.gameObject.GetComponent<Renderer>();
		OriginalTexture = component.material.mainTexture;
		if (Yandere.Schoolwear == 0 || Yandere.Schoolwear == 2 || (Yandere.ClubAttire && Yandere.Club == ClubType.MartialArts) || Yandere.Hungry || Yandere.LucyHelmet.activeInHierarchy)
		{
			component.material.mainTexture = Footprint;
		}
		if (GameGlobals.CensorBlood)
		{
			component.material.mainTexture = Flower;
			base.transform.localScale = new Vector3(0.2f, 0.2f, 1f);
		}
	}

	public void UpdateBlood()
	{
		Renderer component = base.gameObject.GetComponent<Renderer>();
		if (GameGlobals.CensorBlood)
		{
			component.material.mainTexture = Flower;
			base.transform.localScale = new Vector3(0.2f, 0.2f, 1f);
		}
		else
		{
			component.material.mainTexture = OriginalTexture;
			base.transform.localScale = new Vector3(0.077f, 0.202f, 1f);
		}
	}
}
