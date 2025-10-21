using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AnimationSequenceController : MonoBehaviour
{
	public enum AnimationSequence
	{
		Sequence0 = 0,
		Sequence1 = 1,
		Sequence2 = 2,
		Sequence3 = 3,
		Sequence4 = 4,
		Sequence5 = 5,
		Sequence6 = 6,
		Sequence7 = 7
	}

	[Serializable]
	public class SubtitleFrame
	{
		public int frame;

		[TextArea]
		public string text;

		[HideInInspector]
		public bool triggered;
	}

	[Serializable]
	public class SubtitleSequence
	{
		public string name;

		public int sequenceIndex;

		public List<SubtitleFrame> subtitles = new List<SubtitleFrame>();
	}

	[Serializable]
	public class FrameVisibilityTrigger
	{
		public string name;

		public GameObject targetObject;

		public List<int> sequenceIndexes = new List<int>();

		public int frame;

		public bool visible;

		[HideInInspector]
		public bool triggered;
	}

	[Serializable]
	public class CameraShot
	{
		public int frame;

		public Transform referenceTransform;

		[HideInInspector]
		public bool triggered;
	}

	[Serializable]
	public class CameraSequenceShots
	{
		public string name;

		public int sequenceIndex;

		public List<CameraShot> shots = new List<CameraShot>();
	}

	[Header("Yakuza NPC")]
	public Animation yakuzaAnimation;

	public string[] yakuzaAnimationNames;

	[Header("Ryoba NPC")]
	public Animation ryobaAnimation;

	public string[] ryobaAnimationNames;

	[Header("Audio")]
	public AudioSource audioSource;

	public AudioClip[] sequenceAudioClips;

	[Header("Animated Object in Hand")]
	public Animation handObjectAnimation;

	public string[] handObjectAnimationNames;

	[Header("Global Camera Reference")]
	public Camera mainCamera;

	[Header("Subtitle System")]
	public string currentSubtitleText = "";

	public TextMeshProUGUI debugSubtitleDisplay;

	public UILabel Subtitle;

	[Header("Debug Settings")]
	public bool enableFrameLogs;

	[Header("Frame-Based Visibility Triggers")]
	public List<FrameVisibilityTrigger> frameVisibilityTriggers = new List<FrameVisibilityTrigger>();

	[Header("Camera Shots by Sequence")]
	public List<CameraSequenceShots> cameraSequences = new List<CameraSequenceShots>();

	[Header("Subtitle Sequences")]
	public List<SubtitleSequence> subtitleSequences = new List<SubtitleSequence>();

	private int currentSequenceIndex = -1;

	private float sequenceTimer;

	public bool isSequencePlaying;

	private Dictionary<UnityEngine.Object, Mesh> originalMeshes = new Dictionary<UnityEngine.Object, Mesh>();

	public GameObject ryobaHair;

	public SkinnedMeshRenderer ryobaHairRenderer;

	public Mesh ryobaHairMesh;

	private void Update()
	{
		if (Input.GetButtonDown(InputNames.Xbox_X))
		{
			yakuzaAnimation.Stop();
			ryobaAnimation.Stop();
			handObjectAnimation.Stop();
			audioSource.Stop();
			isSequencePlaying = false;
		}
		if (isSequencePlaying)
		{
			sequenceTimer += Time.deltaTime;
			int currentFrame = Mathf.FloorToInt(sequenceTimer * 30f);
			if (currentSequenceIndex >= 0 && currentSequenceIndex < yakuzaAnimationNames.Length)
			{
				_ = yakuzaAnimationNames[currentSequenceIndex];
			}
			_ = enableFrameLogs;
			UpdateFrameVisibility(currentFrame);
			UpdateCameraShots(currentFrame);
			UpdateSubtitles(currentFrame);
		}
	}

	public void PlaySequenceByID(AnimationSequence sequence)
	{
		PlaySequence((int)sequence);
	}

	public void PlaySequence(int index)
	{
		sequenceTimer = 0f;
		isSequencePlaying = true;
		currentSequenceIndex = index;
		ResetVisibilityTriggers();
		ResetCameraShots();
		ResetSubtitles();
		ryobaHair.SetActive(value: true);
		ryobaHairRenderer.sharedMesh = ryobaHairMesh;
		yakuzaAnimation.Stop();
		ryobaAnimation.Stop();
		handObjectAnimation.Stop();
		audioSource.Stop();
		if (index < yakuzaAnimationNames.Length && !string.IsNullOrEmpty(yakuzaAnimationNames[index]))
		{
			yakuzaAnimation[yakuzaAnimationNames[index]].wrapMode = WrapMode.Once;
			yakuzaAnimation.Play(yakuzaAnimationNames[index]);
		}
		if (index < ryobaAnimationNames.Length && !string.IsNullOrEmpty(ryobaAnimationNames[index]))
		{
			ryobaAnimation[ryobaAnimationNames[index]].wrapMode = WrapMode.Once;
			ryobaAnimation.Play(ryobaAnimationNames[index]);
		}
		if (index < handObjectAnimationNames.Length)
		{
			string text = handObjectAnimationNames[index];
			if (!string.IsNullOrEmpty(text) && handObjectAnimation.GetClip(text) != null)
			{
				handObjectAnimation[text].wrapMode = WrapMode.Once;
				handObjectAnimation.Play(text);
			}
		}
		if (index < sequenceAudioClips.Length && sequenceAudioClips[index] != null)
		{
			audioSource.clip = sequenceAudioClips[index];
			audioSource.Play();
		}
	}

	private void UpdateFrameVisibility(int currentFrame)
	{
		foreach (FrameVisibilityTrigger frameVisibilityTrigger in frameVisibilityTriggers)
		{
			if (frameVisibilityTrigger != null && !(frameVisibilityTrigger.targetObject == null) && frameVisibilityTrigger.sequenceIndexes.Contains(currentSequenceIndex) && !frameVisibilityTrigger.triggered && currentFrame >= frameVisibilityTrigger.frame)
			{
				ApplyVisibility(frameVisibilityTrigger.targetObject, frameVisibilityTrigger.visible);
				frameVisibilityTrigger.triggered = true;
				_ = frameVisibilityTrigger.visible;
			}
		}
		if (!yakuzaAnimation.IsPlaying(yakuzaAnimationNames[currentSequenceIndex]))
		{
			isSequencePlaying = false;
		}
	}

	private void UpdateCameraShots(int currentFrame)
	{
		if (mainCamera == null)
		{
			return;
		}
		foreach (CameraSequenceShots cameraSequence in cameraSequences)
		{
			if (cameraSequence.sequenceIndex != currentSequenceIndex)
			{
				continue;
			}
			foreach (CameraShot shot in cameraSequence.shots)
			{
				if (!shot.triggered && !(shot.referenceTransform == null) && currentFrame >= shot.frame)
				{
					mainCamera.transform.position = shot.referenceTransform.position;
					mainCamera.transform.rotation = shot.referenceTransform.rotation;
					shot.triggered = true;
				}
			}
		}
	}

	private void UpdateSubtitles(int currentFrame)
	{
		foreach (SubtitleSequence subtitleSequence in subtitleSequences)
		{
			if (subtitleSequence.sequenceIndex != currentSequenceIndex)
			{
				continue;
			}
			foreach (SubtitleFrame subtitle in subtitleSequence.subtitles)
			{
				if (!subtitle.triggered && currentFrame >= subtitle.frame)
				{
					currentSubtitleText = subtitle.text;
					if (debugSubtitleDisplay != null)
					{
						debugSubtitleDisplay.text = currentSubtitleText;
					}
					Subtitle.text = currentSubtitleText;
					subtitle.triggered = true;
					if (!string.IsNullOrEmpty(subtitle.text))
					{
						_ = "\"" + subtitle.text + "\"";
					}
				}
			}
		}
	}

	private void ResetVisibilityTriggers()
	{
		foreach (FrameVisibilityTrigger frameVisibilityTrigger in frameVisibilityTriggers)
		{
			frameVisibilityTrigger.triggered = false;
		}
	}

	private void ResetCameraShots()
	{
		foreach (CameraSequenceShots cameraSequence in cameraSequences)
		{
			foreach (CameraShot shot in cameraSequence.shots)
			{
				shot.triggered = false;
			}
		}
	}

	private void ResetSubtitles()
	{
		foreach (SubtitleSequence subtitleSequence in subtitleSequences)
		{
			foreach (SubtitleFrame subtitle in subtitleSequence.subtitles)
			{
				subtitle.triggered = false;
			}
		}
		currentSubtitleText = "";
		if (debugSubtitleDisplay != null)
		{
			debugSubtitleDisplay.text = "";
		}
		Subtitle.text = "";
	}

	private void ApplyVisibility(GameObject obj, bool makeVisible)
	{
		if (obj == null)
		{
			return;
		}
		MeshFilter[] componentsInChildren = obj.GetComponentsInChildren<MeshFilter>(includeInactive: true);
		foreach (MeshFilter meshFilter in componentsInChildren)
		{
			if (makeVisible)
			{
				if (meshFilter.sharedMesh == null && originalMeshes.ContainsKey(meshFilter))
				{
					meshFilter.sharedMesh = originalMeshes[meshFilter];
				}
				continue;
			}
			if (!originalMeshes.ContainsKey(meshFilter))
			{
				originalMeshes[meshFilter] = meshFilter.sharedMesh;
			}
			meshFilter.sharedMesh = null;
		}
		SkinnedMeshRenderer[] componentsInChildren2 = obj.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren2)
		{
			if (makeVisible)
			{
				if (skinnedMeshRenderer.sharedMesh == null && originalMeshes.ContainsKey(skinnedMeshRenderer))
				{
					skinnedMeshRenderer.sharedMesh = originalMeshes[skinnedMeshRenderer];
				}
				continue;
			}
			if (!originalMeshes.ContainsKey(skinnedMeshRenderer))
			{
				originalMeshes[skinnedMeshRenderer] = skinnedMeshRenderer.sharedMesh;
			}
			skinnedMeshRenderer.sharedMesh = null;
		}
	}
}
