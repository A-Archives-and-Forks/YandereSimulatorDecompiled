using UnityEngine;
using UnityEngine.Playables;

namespace HNS
{
	public class GameplayManager : MonoBehaviour
	{
		[Header("Cutscene")]
		public PlayableDirector introDirector;

		public bool playCutsceneOnStart = true;

		public static GameplayManager Instance { get; private set; }

		private void OnEnable()
		{
			Instance = this;
		}

		private void OnDisable()
		{
			if (Instance == this)
			{
				Instance = null;
			}
		}

		private void Start()
		{
			PlayIntroCutscene();
		}

		private void Update()
		{
			LockCursor();
		}

		public void PlayIntroCutscene()
		{
			if (introDirector == null)
			{
				Debug.LogWarning("Intro director not assigned, skipping cutscene");
				EnterGameplay();
				return;
			}
			SetCutsceneState(inCutscene: true);
			introDirector.gameObject.SetActive(value: true);
			introDirector.stopped += OnCutsceneComplete;
			introDirector.Play();
		}

		private void OnCutsceneComplete(PlayableDirector director)
		{
			director.stopped -= OnCutsceneComplete;
			director.gameObject.SetActive(value: false);
			EnterGameplay();
		}

		private void LockCursor()
		{
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

		private void EnterGameplay()
		{
			SetCutsceneState(inCutscene: false);
			if (!(Player.instance == null))
			{
				Player.instance.State = PlayerState.Default;
			}
		}

		private void SetCutsceneState(bool inCutscene)
		{
			if (!(Player.instance == null))
			{
				Player.instance.State = (inCutscene ? PlayerState.Cutscene : PlayerState.Default);
				if (CameraStateMachine.Instance != null)
				{
					CameraStateMachine.Instance.IsEnabled = !inCutscene;
				}
			}
		}

		public void PlayCutscene(PlayableDirector director)
		{
			if (!(director == null))
			{
				SetCutsceneState(inCutscene: true);
				director.stopped += OnCutsceneComplete;
				director.Play();
			}
		}

		public void SkipCutscene()
		{
			if (introDirector != null && introDirector.state == PlayState.Playing)
			{
				introDirector.Stop();
				EnterGameplay();
			}
		}
	}
}
