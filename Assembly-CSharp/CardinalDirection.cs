﻿// Decompiled with JetBrains decompiler
// Type: CardinalDirection
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

public static class CardinalDirection
{
  public static Direction Reversed(Direction direction)
  {
    switch (direction)
    {
      case Direction.North:
        return Direction.South;
      case Direction.East:
        return Direction.West;
      case Direction.South:
        return Direction.North;
      default:
        return Direction.East;
    }
  }

  public static Direction LeftPerp(Direction direction)
  {
    switch (direction)
    {
      case Direction.North:
        return Direction.West;
      case Direction.East:
        return Direction.North;
      case Direction.South:
        return Direction.East;
      default:
        return Direction.South;
    }
  }

  public static Direction RightPerp(Direction direction)
  {
    switch (direction)
    {
      case Direction.North:
        return Direction.East;
      case Direction.East:
        return Direction.South;
      case Direction.South:
        return Direction.West;
      default:
        return Direction.North;
    }
  }
}
