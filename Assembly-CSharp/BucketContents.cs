﻿// Decompiled with JetBrains decompiler
// Type: BucketContents
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

public abstract class BucketContents
{
  public abstract BucketContentsType Type { get; }

  public abstract bool IsCleaningAgent { get; }

  public abstract bool IsFlammable { get; }

  public abstract bool CanBeLifted(int strength);
}
