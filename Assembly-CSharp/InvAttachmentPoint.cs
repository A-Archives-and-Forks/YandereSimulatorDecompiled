﻿// Decompiled with JetBrains decompiler
// Type: InvAttachmentPoint
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("NGUI/Examples/Item Attachment Point")]
public class InvAttachmentPoint : MonoBehaviour
{
  public InvBaseItem.Slot slot;
  private GameObject mPrefab;
  private GameObject mChild;

  public GameObject Attach(GameObject prefab)
  {
    if ((Object) this.mPrefab != (Object) prefab)
    {
      this.mPrefab = prefab;
      if ((Object) this.mChild != (Object) null)
        Object.Destroy((Object) this.mChild);
      if ((Object) this.mPrefab != (Object) null)
      {
        Transform transform1 = this.transform;
        this.mChild = Object.Instantiate<GameObject>(this.mPrefab, transform1.position, transform1.rotation);
        Transform transform2 = this.mChild.transform;
        transform2.parent = transform1;
        transform2.localPosition = Vector3.zero;
        transform2.localRotation = Quaternion.identity;
        transform2.localScale = Vector3.one;
      }
    }
    return this.mChild;
  }
}
