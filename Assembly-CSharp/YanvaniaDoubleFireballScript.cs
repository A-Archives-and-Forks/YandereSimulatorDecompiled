﻿using System;
using UnityEngine;

// Token: 0x020004E2 RID: 1250
public class YanvaniaDoubleFireballScript : MonoBehaviour
{
	// Token: 0x060020C3 RID: 8387 RVA: 0x001E2338 File Offset: 0x001E0538
	private void Start()
	{
		UnityEngine.Object.Instantiate<GameObject>(this.LightningEffect, new Vector3(base.transform.position.x, 8f, 0f), Quaternion.identity);
		this.Direction = ((this.Dracula.position.x > base.transform.position.x) ? -1 : 1);
	}

	// Token: 0x060020C4 RID: 8388 RVA: 0x001E23A4 File Offset: 0x001E05A4
	private void Update()
	{
		if (this.Timer > 1f && !this.SpawnedFirst)
		{
			UnityEngine.Object.Instantiate<GameObject>(this.LightningEffect, new Vector3(base.transform.position.x, 7f, 0f), Quaternion.identity);
			this.FirstLavaball = UnityEngine.Object.Instantiate<GameObject>(this.Lavaball, new Vector3(base.transform.position.x, 8f, 0f), Quaternion.identity);
			this.FirstLavaball.transform.localScale = Vector3.zero;
			this.SpawnedFirst = true;
		}
		if (this.FirstLavaball != null)
		{
			this.FirstLavaball.transform.localScale = Vector3.Lerp(this.FirstLavaball.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			this.FirstPosition += ((this.FirstPosition == 0f) ? Time.deltaTime : (this.FirstPosition * this.Speed));
			this.FirstLavaball.transform.position = new Vector3(this.FirstLavaball.transform.position.x + this.FirstPosition * (float)this.Direction, this.FirstLavaball.transform.position.y, this.FirstLavaball.transform.position.z);
			this.FirstLavaball.transform.eulerAngles = new Vector3(this.FirstLavaball.transform.eulerAngles.x, this.FirstLavaball.transform.eulerAngles.y, this.FirstLavaball.transform.eulerAngles.z - this.FirstPosition * (float)this.Direction * 36f);
		}
		if (this.Timer > 2f && !this.SpawnedSecond)
		{
			this.SecondLavaball = UnityEngine.Object.Instantiate<GameObject>(this.Lavaball, new Vector3(base.transform.position.x, 7f, 0f), Quaternion.identity);
			this.SecondLavaball.transform.localScale = Vector3.zero;
			this.SpawnedSecond = true;
		}
		if (this.SecondLavaball != null)
		{
			this.SecondLavaball.transform.localScale = Vector3.Lerp(this.SecondLavaball.transform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 10f);
			if (this.SecondPosition == 0f)
			{
				this.SecondPosition += Time.deltaTime;
			}
			else
			{
				this.SecondPosition += this.SecondPosition * this.Speed;
			}
			this.SecondLavaball.transform.position = new Vector3(this.SecondLavaball.transform.position.x + this.SecondPosition * (float)this.Direction, this.SecondLavaball.transform.position.y, this.SecondLavaball.transform.position.z);
			this.SecondLavaball.transform.eulerAngles = new Vector3(this.SecondLavaball.transform.eulerAngles.x, this.SecondLavaball.transform.eulerAngles.y, this.SecondLavaball.transform.eulerAngles.z - this.SecondPosition * (float)this.Direction * 36f);
		}
		this.Timer += Time.deltaTime;
		if (this.Timer > 10f)
		{
			if (this.FirstLavaball != null)
			{
				UnityEngine.Object.Destroy(this.FirstLavaball);
			}
			if (this.SecondLavaball != null)
			{
				UnityEngine.Object.Destroy(this.SecondLavaball);
			}
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x040047DE RID: 18398
	public GameObject Lavaball;

	// Token: 0x040047DF RID: 18399
	public GameObject FirstLavaball;

	// Token: 0x040047E0 RID: 18400
	public GameObject SecondLavaball;

	// Token: 0x040047E1 RID: 18401
	public GameObject LightningEffect;

	// Token: 0x040047E2 RID: 18402
	public Transform Dracula;

	// Token: 0x040047E3 RID: 18403
	public bool SpawnedFirst;

	// Token: 0x040047E4 RID: 18404
	public bool SpawnedSecond;

	// Token: 0x040047E5 RID: 18405
	public float FirstPosition;

	// Token: 0x040047E6 RID: 18406
	public float SecondPosition;

	// Token: 0x040047E7 RID: 18407
	public int Direction;

	// Token: 0x040047E8 RID: 18408
	public float Timer;

	// Token: 0x040047E9 RID: 18409
	public float Speed;
}
