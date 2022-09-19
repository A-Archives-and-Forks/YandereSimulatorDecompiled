﻿// Decompiled with JetBrains decompiler
// Type: SciFiTerminalScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 76B31E51-17DB-470B-BEBA-6CF1F4AD2F4E
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SciFiTerminalScript : MonoBehaviour
{
  public StudentScript Student;
  public RobotArmScript RobotArms;
  public Transform OtherFinger;
  public bool Updated;

  private void Start()
  {
    if (this.Student.StudentID != 65)
      this.enabled = false;
    else
      this.RobotArms = this.Student.StudentManager.RobotArms;
  }

  private void Update()
  {
    if (!((Object) this.RobotArms != (Object) null))
      return;
    if ((double) Vector3.Distance(this.RobotArms.TerminalTarget.position, this.transform.position) < 0.3 || (double) Vector3.Distance(this.RobotArms.TerminalTarget.position, this.OtherFinger.position) < 0.3)
    {
      if (this.Updated)
        return;
      this.Updated = true;
      if (!this.RobotArms.On[0])
        this.RobotArms.ActivateArms();
      else
        this.RobotArms.ToggleWork();
    }
    else
      this.Updated = false;
  }
}
