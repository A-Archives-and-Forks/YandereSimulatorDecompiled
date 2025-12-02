using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.DualShock;
using XInputDotNetPure;

namespace HNS
{
	public class Rumble : MonoBehaviour
	{
		[Header("Directional Settings")]
		[Tooltip("Enable directional haptics based on 3D position")]
		public bool useDirectionalHaptics = true;

		[Tooltip("How much directional bias affects motor balance (0 = none, 1 = full)")]
		[Range(0f, 1f)]
		public float directionalStrength = 0.6f;

		[Header("Debug")]
		public bool logConnectionStatus;

		private bool playerIndexSet;

		private PlayerIndex playerIndex;

		private GamePadState state;

		private GamePadState prevState;

		private float lastConnectionCheckTime;

		private const float connectionCheckInterval = 0.5f;

		private Coroutine pulseConstantCoroutine;

		public static Rumble Instance { get; private set; }

		private void OnEnable()
		{
			Instance = this;
			ForceControllerRefresh();
		}

		private void OnDisable()
		{
			if (Instance == this)
			{
				Instance = null;
			}
			StopAll();
		}

		private void Update()
		{
			if (Time.time - lastConnectionCheckTime > 0.5f)
			{
				CheckControllerConnection();
				lastConnectionCheckTime = Time.time;
			}
			if (!playerIndexSet)
			{
				return;
			}
			prevState = state;
			state = GamePad.GetState(playerIndex);
			if (!state.IsConnected && prevState.IsConnected)
			{
				if (logConnectionStatus)
				{
					Debug.Log("Controller disconnected, attempting to reconnect...");
				}
				playerIndexSet = false;
			}
		}

		private void CheckControllerConnection()
		{
			if (playerIndexSet && state.IsConnected)
			{
				return;
			}
			for (int i = 0; i < 4; i++)
			{
				PlayerIndex playerIndex = (PlayerIndex)i;
				GamePadState gamePadState = GamePad.GetState(playerIndex);
				if (!gamePadState.IsConnected)
				{
					continue;
				}
				if (!playerIndexSet || this.playerIndex != playerIndex)
				{
					this.playerIndex = playerIndex;
					playerIndexSet = true;
					state = gamePadState;
					if (logConnectionStatus)
					{
						Debug.Log($"Controller connected on PlayerIndex: {playerIndex}");
					}
				}
				break;
			}
		}

		private void ForceControllerRefresh()
		{
			playerIndexSet = false;
			CheckControllerConnection();
		}

		public void Play(float lowFrequency, float highFrequency, float duration, Vector3? worldPosition = null)
		{
			if (playerIndexSet)
			{
				StartCoroutine(PlayCoroutine(lowFrequency, highFrequency, duration, worldPosition));
			}
		}

		public void PlayConstant(float lowFrequency, float highFrequency, Vector3? worldPosition = null)
		{
			if (playerIndexSet)
			{
				SetVibration(lowFrequency, highFrequency, worldPosition);
			}
		}

		public void PlayPulse(float lowFrequency, float highFrequency, float onTime, float offTime, float duration, Vector3? worldPosition = null)
		{
			if (playerIndexSet)
			{
				StartCoroutine(PulseCoroutine(lowFrequency, highFrequency, onTime, offTime, duration, worldPosition));
			}
		}

		public void PlayPulseConstant(float lowFrequency, float highFrequency, float onTime, float offTime, Vector3? worldPosition = null)
		{
			if (playerIndexSet)
			{
				if (pulseConstantCoroutine != null)
				{
					StopCoroutine(pulseConstantCoroutine);
				}
				pulseConstantCoroutine = StartCoroutine(PulseConstantCoroutine(lowFrequency, highFrequency, onTime, offTime, worldPosition));
			}
		}

		public void PlayFade(float lowFrequency, float highFrequency, float duration, Vector3? worldPosition = null)
		{
			if (playerIndexSet)
			{
				StartCoroutine(FadeCoroutine(lowFrequency, highFrequency, duration, worldPosition));
			}
		}

		public void StopAll()
		{
			StopAllCoroutines();
			pulseConstantCoroutine = null;
			if (playerIndexSet)
			{
				SetVibration(0f, 0f, null);
			}
		}

		private void SetVibration(float low, float high, Vector3? worldPosition)
		{
			if (playerIndexSet)
			{
				float num = low;
				float num2 = high;
				if (useDirectionalHaptics && worldPosition.HasValue && CameraStateMachine.Instance != null)
				{
					Vector3 position = CameraStateMachine.Instance.transform.position;
					Vector3 right = CameraStateMachine.Instance.transform.right;
					float num3 = Mathf.Abs(Vector3.Dot((worldPosition.Value - position).normalized, right));
					float num4 = Mathf.Lerp(1f, 0.3f, num3 * directionalStrength);
					num = low * num4;
					num2 = high * num4;
				}
				GamePad.SetVibration(playerIndex, num, num2);
				if (Gamepad.current is DualShockGamepad dualShockGamepad)
				{
					dualShockGamepad.SetMotorSpeeds(num, num2);
				}
			}
		}

		private IEnumerator PlayCoroutine(float low, float high, float duration, Vector3? worldPosition)
		{
			SetVibration(low, high, worldPosition);
			yield return new WaitForSecondsRealtime(duration);
			SetVibration(0f, 0f, null);
		}

		private IEnumerator PulseCoroutine(float low, float high, float onTime, float offTime, float duration, Vector3? worldPosition)
		{
			float elapsed;
			for (elapsed = 0f; elapsed < duration; elapsed += offTime)
			{
				SetVibration(low, high, worldPosition);
				yield return new WaitForSecondsRealtime(onTime);
				elapsed += onTime;
				if (elapsed >= duration)
				{
					break;
				}
				SetVibration(0f, 0f, null);
				yield return new WaitForSecondsRealtime(offTime);
			}
			SetVibration(0f, 0f, null);
		}

		private IEnumerator PulseConstantCoroutine(float low, float high, float onTime, float offTime, Vector3? worldPosition)
		{
			while (true)
			{
				SetVibration(low, high, worldPosition);
				yield return new WaitForSecondsRealtime(onTime);
				SetVibration(0f, 0f, null);
				yield return new WaitForSecondsRealtime(offTime);
			}
		}

		private IEnumerator FadeCoroutine(float low, float high, float duration, Vector3? worldPosition)
		{
			float elapsed = 0f;
			while (elapsed < duration)
			{
				float num = 1f - elapsed / duration;
				SetVibration(low * num, high * num, worldPosition);
				elapsed += Time.unscaledDeltaTime;
				yield return null;
			}
			SetVibration(0f, 0f, null);
		}

		public bool IsConnected()
		{
			if (playerIndexSet)
			{
				return state.IsConnected;
			}
			return false;
		}
	}
}
