﻿using System;
using System.Reflection;

// Token: 0x0200051B RID: 1307
public static class YanSaveHelpers
{
	// Token: 0x0600219D RID: 8605 RVA: 0x001F1BBC File Offset: 0x001EFDBC
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
