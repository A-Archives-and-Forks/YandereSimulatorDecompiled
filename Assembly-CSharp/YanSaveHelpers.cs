﻿using System;
using System.Reflection;

// Token: 0x0200051A RID: 1306
public static class YanSaveHelpers
{
	// Token: 0x06002191 RID: 8593 RVA: 0x001EFF08 File Offset: 0x001EE108
	public static Type GrabType(string type)
	{
		if (string.IsNullOrEmpty(type))
		{
			return null;
		}
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		for (int i = 0; i < assemblies.Length; i++)
		{
			Type type2 = assemblies[i].GetType(type);
			if (type2 != null)
			{
				return type2;
			}
		}
		return null;
	}
}
