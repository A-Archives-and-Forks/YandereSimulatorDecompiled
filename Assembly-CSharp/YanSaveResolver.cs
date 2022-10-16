﻿// Decompiled with JetBrains decompiler
// Type: YanSaveResolver
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

internal class YanSaveResolver : DefaultContractResolver
{
  protected override IList<JsonProperty> CreateProperties(
    System.Type type,
    MemberSerialization memberSerialization)
  {
    IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);
    PropertyInfo readableInfo = (PropertyInfo) null;
    foreach (MemberInfo memberInfo in type.GetMember("isReadable"))
    {
      if (memberInfo.MemberType == MemberTypes.Property)
        readableInfo = (PropertyInfo) memberInfo;
    }
    foreach (JsonProperty jsonProperty in (IEnumerable<JsonProperty>) properties)
      jsonProperty.ShouldSerialize = (Predicate<object>) (instance =>
      {
        if (type == typeof (Material))
          return false;
        return !(readableInfo != (PropertyInfo) null) || (bool) readableInfo.GetValue(instance);
      });
    return (IList<JsonProperty>) properties.Where<JsonProperty>((Func<JsonProperty, bool>) (p => p.Writable)).ToList<JsonProperty>();
  }
}
