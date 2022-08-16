﻿// Decompiled with JetBrains decompiler
// Type: AudioClipPlayer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FD17A22F-B301-43EA-811A-FA797D0BA442
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public static class AudioClipPlayer
{
  public static void Play(
    AudioClip clip,
    Vector3 position,
    float minDistance,
    float maxDistance,
    out GameObject clipOwner,
    float playerY)
  {
    GameObject gameObject = new GameObject("AudioClip_" + clip.name);
    gameObject.transform.position = position;
    AudioSource audioSource = gameObject.AddComponent<AudioSource>();
    audioSource.clip = clip;
    audioSource.Play();
    Object.Destroy((Object) gameObject, clip.length);
    audioSource.rolloffMode = AudioRolloffMode.Linear;
    audioSource.minDistance = minDistance;
    audioSource.maxDistance = maxDistance;
    audioSource.spatialBlend = 1f;
    clipOwner = gameObject;
    float y = gameObject.transform.position.y;
    audioSource.volume = (double) playerY < (double) y - 2.0 ? 0.0f : 1f;
  }

  public static void PlayAttached(
    AudioClip clip,
    Vector3 position,
    Transform attachment,
    float minDistance,
    float maxDistance,
    out GameObject clipOwner,
    float playerY)
  {
    GameObject gameObject = new GameObject("AudioClip_" + clip.name);
    gameObject.transform.position = position;
    gameObject.transform.parent = attachment;
    AudioSource audioSource = gameObject.AddComponent<AudioSource>();
    audioSource.clip = clip;
    audioSource.Play();
    Object.Destroy((Object) gameObject, clip.length);
    audioSource.rolloffMode = AudioRolloffMode.Linear;
    audioSource.minDistance = minDistance;
    audioSource.maxDistance = maxDistance;
    audioSource.spatialBlend = 1f;
    clipOwner = gameObject;
    float y = gameObject.transform.position.y;
    audioSource.volume = (double) playerY < (double) y - 2.0 ? 0.0f : 1f;
  }

  public static void PlayAttached(
    AudioClip clip,
    Transform attachment,
    float minDistance,
    float maxDistance)
  {
    GameObject gameObject = new GameObject("AudioClip_" + clip.name);
    gameObject.transform.parent = attachment;
    gameObject.transform.localPosition = Vector3.zero;
    AudioSource audioSource = gameObject.AddComponent<AudioSource>();
    audioSource.clip = clip;
    audioSource.Play();
    Object.Destroy((Object) gameObject, clip.length);
    audioSource.rolloffMode = AudioRolloffMode.Linear;
    audioSource.minDistance = minDistance;
    audioSource.maxDistance = maxDistance;
    audioSource.spatialBlend = 1f;
  }

  public static void Play(
    AudioClip clip,
    Vector3 position,
    float minDistance,
    float maxDistance,
    out GameObject clipOwner,
    out float clipLength)
  {
    GameObject gameObject = new GameObject("AudioClip_" + clip.name);
    gameObject.transform.position = position;
    AudioSource audioSource = gameObject.AddComponent<AudioSource>();
    audioSource.clip = clip;
    audioSource.Play();
    Object.Destroy((Object) gameObject, clip.length);
    clipLength = clip.length;
    audioSource.rolloffMode = AudioRolloffMode.Linear;
    audioSource.minDistance = minDistance;
    audioSource.maxDistance = maxDistance;
    audioSource.spatialBlend = 1f;
    clipOwner = gameObject;
  }

  public static void Play(
    AudioClip clip,
    Vector3 position,
    float minDistance,
    float maxDistance,
    out GameObject clipOwner)
  {
    GameObject gameObject = new GameObject("AudioClip_" + clip.name);
    gameObject.transform.position = position;
    AudioSource audioSource = gameObject.AddComponent<AudioSource>();
    audioSource.clip = clip;
    audioSource.Play();
    Object.Destroy((Object) gameObject, clip.length);
    audioSource.rolloffMode = AudioRolloffMode.Linear;
    audioSource.minDistance = minDistance;
    audioSource.maxDistance = maxDistance;
    audioSource.spatialBlend = 1f;
    clipOwner = gameObject;
  }

  public static void Play2D(AudioClip clip, Vector3 position)
  {
    GameObject gameObject = new GameObject("AudioClip_" + clip.name);
    gameObject.transform.position = position;
    AudioSource audioSource = gameObject.AddComponent<AudioSource>();
    audioSource.clip = clip;
    audioSource.Play();
    Object.Destroy((Object) gameObject, clip.length);
  }

  public static void Play2D(AudioClip clip, Vector3 position, float pitch)
  {
    GameObject gameObject = new GameObject("AudioClip_" + clip.name);
    gameObject.transform.position = position;
    AudioSource audioSource = gameObject.AddComponent<AudioSource>();
    audioSource.clip = clip;
    audioSource.Play();
    Object.Destroy((Object) gameObject, clip.length);
    audioSource.pitch = pitch;
  }
}
