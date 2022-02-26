﻿using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x020003B5 RID: 949
public static class PoseSerializer
{
	// Token: 0x06001AF0 RID: 6896 RVA: 0x0012A008 File Offset: 0x00128208
	public static void SerializePose(CosmeticScript cosmeticScript, Transform root, string poseName)
	{
		StudentCosmeticSheet studentCosmeticSheet = cosmeticScript.CosmeticSheet();
		SerializedPose serializedPose;
		serializedPose.CosmeticData = JsonUtility.ToJson(studentCosmeticSheet);
		serializedPose.BoneData = PoseSerializer.getBoneData(root);
		string contents = JsonUtility.ToJson(serializedPose);
		string text = string.Format("{0}/Poses/{1}", Application.streamingAssetsPath, poseName + ".txt");
		new FileInfo(text).Directory.Create();
		File.WriteAllText(text, contents);
	}

	// Token: 0x06001AF1 RID: 6897 RVA: 0x0012A078 File Offset: 0x00128278
	private static BoneData[] getBoneData(Transform root)
	{
		List<BoneData> list = new List<BoneData>();
		foreach (Transform transform in root.GetComponentsInChildren<Transform>())
		{
			list.Add(new BoneData
			{
				BoneName = ((transform == root) ? "StudentRoot" : transform.name),
				LocalPosition = transform.localPosition,
				LocalRotation = transform.localRotation,
				LocalScale = transform.localScale
			});
		}
		return list.ToArray();
	}

	// Token: 0x06001AF2 RID: 6898 RVA: 0x0012A100 File Offset: 0x00128300
	public static void DeserializePose(CosmeticScript cosmeticScript, Transform root, string poseName)
	{
		string path = string.Format("{0}/Poses/{1}", Application.streamingAssetsPath, poseName + ".txt");
		if (File.Exists(path))
		{
			SerializedPose serializedPose = JsonUtility.FromJson<SerializedPose>(File.ReadAllText(path));
			StudentCosmeticSheet studentCosmeticSheet = JsonUtility.FromJson<StudentCosmeticSheet>(serializedPose.CosmeticData);
			cosmeticScript.LoadCosmeticSheet(studentCosmeticSheet);
			cosmeticScript.CharacterAnimation.Stop();
			bool flag = cosmeticScript.Male == studentCosmeticSheet.Male;
			Transform[] componentsInChildren = root.GetComponentsInChildren<Transform>();
			foreach (BoneData boneData2 in serializedPose.BoneData)
			{
				foreach (Transform transform in componentsInChildren)
				{
					if (transform.name == boneData2.BoneName && transform != cosmeticScript.LeftEyeRenderer.transform && transform != cosmeticScript.RightEyeRenderer.transform)
					{
						transform.localRotation = boneData2.LocalRotation;
						if (flag)
						{
							transform.localPosition = boneData2.LocalPosition;
							transform.localScale = boneData2.LocalScale;
						}
					}
					else if (boneData2.BoneName == "StudentRoot" && transform == root)
					{
						transform.localPosition = boneData2.LocalPosition;
						transform.localRotation = boneData2.LocalRotation;
						transform.localScale = boneData2.LocalScale;
					}
				}
			}
		}
	}

	// Token: 0x06001AF3 RID: 6899 RVA: 0x0012A274 File Offset: 0x00128474
	public static string[] GetSavedPoses()
	{
		string[] files = Directory.GetFiles(string.Format("{0}/Poses/{1}", Application.streamingAssetsPath, ""));
		List<string> list = new List<string>();
		foreach (string text in files)
		{
			if (text.EndsWith(".txt"))
			{
				list.Add(text);
			}
		}
		return list.ToArray();
	}

	// Token: 0x04002D5C RID: 11612
	public const string SavePath = "{0}/Poses/{1}";
}
