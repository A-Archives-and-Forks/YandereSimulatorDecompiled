﻿// Decompiled with JetBrains decompiler
// Type: MopScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class MopScript : MonoBehaviour
{
  public ParticleSystem Sparkles;
  public YandereScript Yandere;
  public PromptScript Prompt;
  public PickUpScript PickUp;
  public Collider HeadCollider;
  public AudioSource MyAudio;
  public Vector3 Rotation;
  public Renderer Blood;
  public Transform Head;
  public float Bloodiness;
  public int StudentBloodID;
  public bool Bleached;

  private void Start()
  {
    this.Yandere = GameObject.Find("YandereChan").GetComponent<YandereScript>();
    this.MyAudio = this.GetComponent<AudioSource>();
    this.HeadCollider.enabled = false;
    this.UpdateBlood();
  }

  private void Update()
  {
    if ((Object) this.PickUp.Clock != (Object) null)
      this.PickUp.Suspicious = this.PickUp.Clock.Period != 5;
    if (this.Prompt.PauseScreen.Show)
      return;
    if ((Object) this.Yandere.PickUp == (Object) this.PickUp)
    {
      if (this.Prompt.HideButton[0])
      {
        this.Prompt.HideButton[0] = false;
        this.Prompt.HideButton[3] = true;
        this.Yandere.Mop = this;
      }
      if ((Object) this.Yandere.Bucket == (Object) null)
      {
        if (this.Bleached)
        {
          this.Prompt.HideButton[0] = false;
          if ((double) this.Prompt.Button[0].color.a > 0.0)
          {
            this.Prompt.Label[0].text = "     Sweep";
            if (Input.GetButtonDown("A"))
            {
              this.Yandere.Mopping = true;
              this.HeadCollider.enabled = true;
            }
          }
        }
        else
        {
          this.Prompt.Label[0].text = "     Dip In Bucket First!";
          this.Prompt.HideButton[0] = false;
        }
      }
      else if ((double) this.Prompt.Button[0].color.a > 0.0 && !this.Yandere.Chased && this.Yandere.Chasers == 0)
      {
        if (this.Yandere.Bucket.Full)
        {
          if (!this.Yandere.Bucket.Gasoline && !this.Yandere.Bucket.DyedBrown)
          {
            if (this.Yandere.Bucket.Bleached)
            {
              if ((double) this.Yandere.Bucket.Bloodiness < 100.0)
              {
                this.Prompt.Label[0].text = "     Dip";
                if (Input.GetButtonDown("A"))
                {
                  if ((double) this.Yandere.Bucket.transform.position.y < (double) this.Yandere.transform.position.y + 0.10000000149011612)
                  {
                    this.Dip();
                  }
                  else
                  {
                    Debug.Log((object) "Cannot Dip Now.");
                    this.Yandere.NotificationManager.CustomText = "Lower Bucket First";
                    this.Yandere.NotificationManager.DisplayNotification(NotificationType.Custom);
                  }
                }
              }
              else
                this.Prompt.Label[0].text = "     Water Too Bloody!";
            }
            else
              this.Prompt.Label[0].text = "     Add Bleach First!";
          }
          else
            this.Prompt.Label[0].text = !this.Yandere.Bucket.Gasoline ? "     Can't Use Brown Paint!" : "     Can't Use Gasoline!";
        }
        else
          this.Prompt.Label[0].text = "     Fill Bucket First!";
      }
      if (this.Yandere.Mopping)
      {
        this.Head.LookAt(this.Head.position + Vector3.down);
        this.Head.localEulerAngles = new Vector3(this.Head.localEulerAngles.x + 90f, this.Head.localEulerAngles.y, 180f);
        if (!this.MyAudio.isPlaying)
          this.MyAudio.Play();
      }
      else
      {
        this.Rotation = Vector3.Lerp(this.Head.localEulerAngles, Vector3.zero, Time.deltaTime * 10f);
        this.Head.localEulerAngles = this.Rotation;
        this.MyAudio.Stop();
      }
    }
    else
    {
      this.Prompt.HideButton[0] = true;
      this.Prompt.HideButton[3] = false;
      if ((Object) this.Yandere.Mop == (Object) this)
        this.Yandere.Mop = (MopScript) null;
    }
    if (this.Yandere.Mopping || !this.HeadCollider.enabled)
      return;
    this.HeadCollider.enabled = false;
  }

  public void UpdateBlood()
  {
    if ((double) this.Bloodiness > 100.0)
    {
      this.Bloodiness = 100f;
      this.Sparkles.Stop();
      this.Bleached = false;
    }
    this.Blood.material.color = new Color(this.Blood.material.color.r, this.Blood.material.color.g, this.Blood.material.color.b, (float) ((double) this.Bloodiness / 100.0 * 0.89999997615814209));
  }

  public void Dip()
  {
    this.Yandere.YandereVision = false;
    this.Yandere.CanMove = false;
    this.Yandere.Dipping = true;
    this.Prompt.Hide();
    this.Prompt.enabled = false;
  }
}
