﻿using System;
using UnityEngine;

// Token: 0x0200036B RID: 875
public class MissingPosterManagerScript : MonoBehaviour
{
	// Token: 0x060019D0 RID: 6608 RVA: 0x00108AE4 File Offset: 0x00106CE4
	private void Start()
	{
		while (this.ID < 101)
		{
			if (StudentGlobals.GetStudentMissing(this.ID))
			{
				GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(this.MissingPoster, base.transform.position, Quaternion.identity);
				gameObject.transform.parent = base.transform;
				gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
				gameObject.transform.eulerAngles = new Vector3(0f, 0f, UnityEngine.Random.Range(-15f, 15f));
				WWW www = new WWW(string.Concat(new string[]
				{
					"file:///",
					Application.streamingAssetsPath,
					"/Portraits/Student_",
					this.ID.ToString(),
					".png"
				}));
				gameObject.GetComponent<MissingPosterScript>().MyRenderer.material.mainTexture = www.texture;
				this.RandomID = UnityEngine.Random.Range(1, 3);
				gameObject.transform.localPosition = new Vector3(-16300f + (float)(this.ID * 500), UnityEngine.Random.Range(1300f, 2000f), 0f);
				if (gameObject.transform.localPosition.x > -3700f)
				{
					gameObject.transform.localPosition = new Vector3(gameObject.transform.localPosition.x + 7300f, gameObject.transform.localPosition.y, gameObject.transform.localPosition.z);
				}
				if (gameObject.transform.localPosition.x > 15800f)
				{
					UnityEngine.Object.Destroy(gameObject);
				}
			}
			this.ID++;
		}
	}

	// Token: 0x04002983 RID: 10627
	public GameObject MissingPoster;

	// Token: 0x04002984 RID: 10628
	public int RandomID;

	// Token: 0x04002985 RID: 10629
	public int ID;
}
