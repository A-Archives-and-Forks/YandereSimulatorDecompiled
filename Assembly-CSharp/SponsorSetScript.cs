using UnityEngine;

public class SponsorSetScript : MonoBehaviour
{
	public float Distance;

	public float Height;

	public int Sponsors;

	public UITexture[] LogoTextures;

	public UILabel[] NameLabels;

	public Transform[] Sponsor;

	public Texture[] Logos;

	public string[] Names;

	private void Start()
	{
		Sponsors = 0;
		for (int i = 1; i < LogoTextures.Length; i++)
		{
			Sponsor[i].gameObject.SetActive(value: false);
			if (Logos[i] != null)
			{
				LogoTextures[i].mainTexture = Logos[i];
				NameLabels[i].text = Names[i];
				Sponsor[i].gameObject.SetActive(value: true);
				Sponsors++;
			}
		}
		if (Sponsors < 5)
		{
			Height = 0f;
		}
		else
		{
			base.transform.localPosition = new Vector3(0f, 0.05f, 1f);
		}
		if (Sponsors == 1)
		{
			Sponsor[1].transform.localPosition = Vector3.zero;
		}
		else if (Sponsors == 2)
		{
			Sponsor[1].transform.localPosition = new Vector3(Distance * -1f, Height, 0f);
			Sponsor[2].transform.localPosition = new Vector3(Distance * 1f, Height, 0f);
		}
		else if (Sponsors == 3)
		{
			Sponsor[1].transform.localPosition = new Vector3(Distance * 2f, Height, 0f);
			Sponsor[2].transform.localPosition = new Vector3(0f, Height, 0f);
			Sponsor[3].transform.localPosition = new Vector3(Distance * 2f, Height, 0f);
		}
		if (Sponsors > 3)
		{
			Sponsor[1].transform.localPosition = new Vector3(Distance * -3f, Height, 0f);
			Sponsor[2].transform.localPosition = new Vector3(Distance * -1f, Height, 0f);
			Sponsor[3].transform.localPosition = new Vector3(Distance * 1f, Height, 0f);
			Sponsor[4].transform.localPosition = new Vector3(Distance * 3f, Height, 0f);
		}
		if (Sponsors == 5)
		{
			Sponsor[5].transform.localPosition = new Vector3(0f, Height * -1f, 0f);
		}
		else if (Sponsors == 6)
		{
			Sponsor[5].transform.localPosition = new Vector3(Distance * -1f, Height * -1f, 0f);
			Sponsor[6].transform.localPosition = new Vector3(Distance * 1f, Height * -1f, 0f);
		}
		else if (Sponsors == 7)
		{
			Sponsor[5].transform.localPosition = new Vector3(Distance * -2f, Height * -1f, 0f);
			Sponsor[6].transform.localPosition = new Vector3(0f, Height * -1f, 0f);
			Sponsor[7].transform.localPosition = new Vector3(Distance * 2f, Height * -1f, 0f);
		}
		else if (Sponsors == 8)
		{
			Sponsor[5].transform.localPosition = new Vector3(Distance * -3f, Height * -1f, 0f);
			Sponsor[6].transform.localPosition = new Vector3(Distance * -1f, Height * -1f, 0f);
			Sponsor[7].transform.localPosition = new Vector3(Distance * 1f, Height * -1f, 0f);
			Sponsor[8].transform.localPosition = new Vector3(Distance * 3f, Height * -1f, 0f);
		}
	}
}
