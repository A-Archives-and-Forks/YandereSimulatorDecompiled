﻿// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.Timer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace MaidDereMinigame
{
  public class Timer : Meter
  {
    private GameStarter starter;
    private float gameTime;
    private bool isPaused;

    private void Awake()
    {
      this.gameTime = GameController.Instance.activeDifficultyVariables.gameTime;
      this.starter = Object.FindObjectOfType<GameStarter>();
      this.isPaused = true;
    }

    private void OnEnable() => GameController.PauseGame += new BoolParameterEvent(this.SetPause);

    private void OnDisable() => GameController.PauseGame -= new BoolParameterEvent(this.SetPause);

    public void SetPause(bool toPause) => this.isPaused = toPause;

    private void Update()
    {
      if (this.isPaused)
        return;
      this.gameTime -= Time.deltaTime;
      this.SetFill(this.gameTime / GameController.Instance.activeDifficultyVariables.gameTime);
      this.starter.SetGameTime(this.gameTime);
    }
  }
}
