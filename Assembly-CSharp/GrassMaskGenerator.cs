﻿using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020004EE RID: 1262
[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class GrassMaskGenerator : MonoBehaviour
{
	// Token: 0x060020E2 RID: 8418 RVA: 0x001E55C8 File Offset: 0x001E37C8
	public void Start()
	{
		UnityEngine.Object.Destroy(base.gameObject);
	}

	// Token: 0x060020E3 RID: 8419 RVA: 0x001E55D8 File Offset: 0x001E37D8
	private void Update()
	{
		if (this.camera == null)
		{
			this.camera = base.GetComponent<Camera>();
		}
		this.aspectWidth = Mathf.Clamp(this.aspectWidth, 1f, 2.1474836E+09f);
		this.aspectHeight = Mathf.Clamp(this.aspectHeight, 1f, 2.1474836E+09f);
		this.mapUpscale = Mathf.Clamp(this.mapUpscale, 1, 1000);
		if (this.targetTexture == null || (float)this.targetTexture.width != this.aspectWidth * (float)this.mapUpscale || (float)this.targetTexture.height != this.aspectHeight * (float)this.mapUpscale)
		{
			if (this.targetTexture != null)
			{
				this.targetTexture.Release();
			}
			this.targetTexture = new RenderTexture(Mathf.RoundToInt(this.aspectWidth) * this.mapUpscale, Mathf.RoundToInt(this.aspectHeight) * this.mapUpscale, 1);
		}
		this.camera.enabled = false;
		this.camera.farClipPlane = 0.1f;
		this.camera.orthographic = true;
		this.camera.orthographicSize = this.mapScale;
		this.camera.targetTexture = this.targetTexture;
	}

	// Token: 0x060020E4 RID: 8420 RVA: 0x001E5728 File Offset: 0x001E3928
	[ContextMenu("Generate and save the grass occlusion map")]
	public void GenerateMap()
	{
		base.GetComponent<Camera>().Render();
		if (this.targetTexture == null || (float)this.targetTexture.width != this.aspectWidth * (float)this.mapUpscale || (float)this.targetTexture.height != this.aspectHeight * (float)this.mapUpscale)
		{
			if (this.targetTexture != null)
			{
				this.targetTexture.Release();
			}
			this.targetTexture = new RenderTexture(Mathf.RoundToInt(this.aspectWidth) * this.mapUpscale, Mathf.RoundToInt(this.aspectHeight) * this.mapUpscale, 1);
		}
		RenderTexture active = RenderTexture.active;
		RenderTexture.active = this.targetTexture;
		Texture2D texture2D = new Texture2D(this.targetTexture.width, this.targetTexture.height);
		texture2D.ReadPixels(new Rect(0f, 0f, (float)this.targetTexture.width, (float)this.targetTexture.height), 0, 0);
		RenderTexture.active = active;
		List<Vector3> list = new List<Vector3>();
		List<int> list2 = new List<int>();
		int num = 0;
		for (int i = 0; i < texture2D.width; i++)
		{
			for (int j = 0; j < texture2D.height; j++)
			{
				if (texture2D.GetPixel(i, j).a == 0f)
				{
					Vector3 b = new Vector3((float)i, 0f, (float)j) / 3f;
					list.Add(new Vector3(0f, 0f, 0f) + b);
					list.Add(new Vector3(0f, 0f, 1f) + b);
					list.Add(new Vector3(1f, 0f, 1f) + b);
					list.Add(new Vector3(1f, 0f, 0f) + b);
					list2.Add(num);
					list2.Add(num + 1);
					list2.Add(num + 2);
					list2.Add(num);
					list2.Add(num + 2);
					list2.Add(num + 3);
					num += 4;
				}
			}
		}
		Mesh mesh = new Mesh();
		mesh.subMeshCount = 1;
		mesh.SetVertices(list);
		mesh.SetIndices(list2.ToArray(), MeshTopology.Triangles, 0);
		mesh.RecalculateNormals();
		new GameObject("GrassMesh")
		{
			transform = 
			{
				position = base.transform.position
			}
		}.AddComponent<MeshRenderer>().gameObject.AddComponent<MeshFilter>().mesh = mesh;
	}

	// Token: 0x060020E5 RID: 8421 RVA: 0x001E59C8 File Offset: 0x001E3BC8
	private void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Matrix4x4 matrix = Gizmos.matrix;
		Gizmos.matrix = Matrix4x4.TRS(base.transform.position, base.transform.rotation, Vector3.one);
		float z = this.camera.farClipPlane - this.camera.nearClipPlane;
		float z2 = (this.camera.farClipPlane + this.camera.nearClipPlane) * 0.5f;
		Gizmos.DrawWireCube(new Vector3(0f, 0f, z2), new Vector3(this.camera.orthographicSize * 2f * this.camera.aspect, this.camera.orthographicSize * 2f, z));
	}

	// Token: 0x04004890 RID: 18576
	[SerializeField]
	private float aspectWidth;

	// Token: 0x04004891 RID: 18577
	[SerializeField]
	private float aspectHeight;

	// Token: 0x04004892 RID: 18578
	[SerializeField]
	private float mapScale;

	// Token: 0x04004893 RID: 18579
	[SerializeField]
	private int mapUpscale;

	// Token: 0x04004894 RID: 18580
	private Camera camera;

	// Token: 0x04004895 RID: 18581
	private RenderTexture targetTexture;
}
