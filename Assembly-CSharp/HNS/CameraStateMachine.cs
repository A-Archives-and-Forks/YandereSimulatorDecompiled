using System;
using System.Collections.Generic;
using UnityEngine;

namespace HNS
{
	public class CameraStateMachine : MonoBehaviour
	{
		[SerializeField]
		private CameraState initialState;

		private Dictionary<Type, CameraState> stateCache;

		public static CameraStateMachine Instance { get; private set; }

		public CameraState CurrentState { get; private set; }

		public CameraState PreviousState { get; private set; }

		public bool IsEnabled { get; set; } = true;

		private void OnEnable()
		{
			Instance = ((Instance == null) ? this : Instance);
			CacheStates();
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
			if (initialState != null)
			{
				TransitionTo(initialState);
			}
		}

		private void Update()
		{
			if (IsEnabled)
			{
				CurrentState?.OnUpdate();
			}
		}

		private void LateUpdate()
		{
			if (IsEnabled)
			{
				CurrentState?.OnLateUpdate();
			}
		}

		private void CacheStates()
		{
			stateCache = new Dictionary<Type, CameraState>();
			CameraState[] components = GetComponents<CameraState>();
			foreach (CameraState cameraState in components)
			{
				stateCache[cameraState.GetType()] = cameraState;
			}
		}

		public void TransitionTo(CameraState newState)
		{
			if (!(newState == CurrentState))
			{
				CurrentState?.OnExit();
				PreviousState = CurrentState;
				CurrentState = newState;
				CurrentState?.OnEnter();
			}
		}

		public void Enable()
		{
			IsEnabled = true;
		}

		public void Disable()
		{
			IsEnabled = false;
		}

		public T GetState<T>() where T : CameraState
		{
			if (!stateCache.TryGetValue(typeof(T), out var value))
			{
				return null;
			}
			return value as T;
		}

		public bool IsInState<T>() where T : CameraState
		{
			return CurrentState is T;
		}
	}
}
