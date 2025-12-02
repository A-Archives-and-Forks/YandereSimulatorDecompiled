using UnityEngine;

namespace HNS
{
	public class CameraController : MonoBehaviour
	{
		private CameraStateMachine stateMachine;

		private OrbitCameraState orbitState;

		private TargetLockCameraState targetLockState;

		private void OnEnable()
		{
			stateMachine = GetComponent<CameraStateMachine>();
		}

		private void Start()
		{
			orbitState = stateMachine.GetState<OrbitCameraState>();
			targetLockState = stateMachine.GetState<TargetLockCameraState>();
		}

		private void Update()
		{
			if (InputQuery.ButtonDown(ButtonInput.RightStick))
			{
				ToggleTargetLock();
			}
		}

		private void ToggleTargetLock()
		{
			if ((!(PauseMenu.Instance != null) || !PauseMenu.Instance.IsPaused) && (!stateMachine.IsInState<OrbitCameraState>() || AreEnemiesAvailable()))
			{
				if (stateMachine.IsInState<OrbitCameraState>())
				{
					stateMachine.TransitionTo(targetLockState);
				}
				else if (stateMachine.IsInState<TargetLockCameraState>())
				{
					stateMachine.TransitionTo(orbitState);
				}
			}
		}

		private bool AreEnemiesAvailable()
		{
			if (WaveManager.Instance != null)
			{
				return WaveManager.Instance.ActiveEnemies.Count > 0;
			}
			return false;
		}
	}
}
