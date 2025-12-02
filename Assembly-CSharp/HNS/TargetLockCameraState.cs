using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HNS
{
	public class TargetLockCameraState : CameraState
	{
		[Header("Target Lock Settings")]
		[SerializeField]
		private float lockDistance = 3f;

		[SerializeField]
		private float heightOffset = 0.5f;

		[SerializeField]
		private float defaultPitchOffset;

		[SerializeField]
		private float lockOnTransitionDuration = 0.5f;

		[Header("Deadzone Settings")]
		[SerializeField]
		private Vector2 targetScreenPosition = new Vector2(0.5f, 0.5f);

		[SerializeField]
		private float screenDeadzoneRadius = 0.1f;

		[SerializeField]
		private float screenSmoothzoneRadius = 0.2f;

		[SerializeField]
		private float smoothzoneReturnSpeed = 3f;

		[SerializeField]
		private float sideOffset = 1f;

		[SerializeField]
		private float minVerticalHeight = 1f;

		[SerializeField]
		private float maxVerticalHeight = 3f;

		[Header("Vertical Target Tracking")]
		[SerializeField]
		private float flyingCameraHeightOffset = 0.5f;

		[SerializeField]
		private float flyingPitchOffset = 15f;

		[SerializeField]
		private float verticalTrackingSpeed = 5f;

		[Header("Tracking")]
		[SerializeField]
		private float trackingSpeed = 5f;

		[SerializeField]
		private float shoulderSwapSpeed = 2f;

		[SerializeField]
		private float shoulderSwapDeadzone = 0.3f;

		[Header("Target Management")]
		[SerializeField]
		private float cycleThreshold = 0.5f;

		[SerializeField]
		private float cycleCooldown = 0.3f;

		private List<TargetLockIndicator> availableTargets = new List<TargetLockIndicator>();

		private int currentTargetIndex;

		private float lastCycleTime;

		private float currentHeightOffset;

		private float currentPitchOffset;

		private float targetShoulderOffset;

		private Succubus cachedSuccubus;

		private float lockOnTimer;

		public TargetLockIndicator CurrentTarget { get; private set; }

		public override void OnEnter()
		{
			RefreshTargets();
			if (availableTargets.Count == 0)
			{
				stateMachine.TransitionTo(stateMachine.GetState<OrbitCameraState>());
				return;
			}
			CurrentTarget = availableTargets[0];
			currentTargetIndex = 0;
			Player.instance.AbsoluteMovement = false;
			Player.instance.MyAnimator.SetFloat(AnimationHashes.Horizontal, 0f);
			rig.ShoulderOffset = rig.SmoothedShoulderOffset;
			rig.HeightOffset = rig.SmoothedHeightOffset;
			rig.PitchOffset = rig.SmoothedPitchOffset;
			rig.Pitch = rig.SmoothedPitch;
			rig.Yaw = rig.SmoothedYaw;
			rig.Distance = rig.SmoothedDistance;
			currentHeightOffset = 0f;
			currentPitchOffset = defaultPitchOffset;
			targetShoulderOffset = 0f;
			lockOnTimer = 0f;
			cachedSuccubus = CurrentTarget.enemy.GetComponent<Succubus>();
		}

		public override void OnUpdate()
		{
			if (Time.timeScale != 0f)
			{
				if (WaveManager.Instance == null || WaveManager.Instance.ActiveEnemies.Count == 0)
				{
					stateMachine.TransitionTo(stateMachine.GetState<OrbitCameraState>());
					return;
				}
				HandleTargetCycling();
				rig.Distance -= InputQuery.ScrollWheel.y * rig.zoomSensitivity;
			}
		}

		public override void OnLateUpdate()
		{
			RefreshTargets();
			if (availableTargets.Count == 0)
			{
				stateMachine.TransitionTo(stateMachine.GetState<OrbitCameraState>());
				return;
			}
			if (!IsTargetValid(CurrentTarget))
			{
				if (availableTargets.Count <= 0)
				{
					stateMachine.TransitionTo(stateMachine.GetState<OrbitCameraState>());
					return;
				}
				CurrentTarget = availableTargets[0];
				currentTargetIndex = 0;
				cachedSuccubus = CurrentTarget.enemy.GetComponent<Succubus>();
			}
			lockOnTimer += Time.deltaTime;
			UpdateVerticalTracking();
			TrackTarget();
			UpdateShoulderOffset();
			UpdateDistance();
			rig.ApplyConstraints();
			rig.SmoothValues(Time.deltaTime);
			ApplyVerticalHeightClamp();
		}

		public override void OnExit()
		{
			Player.instance.AbsoluteMovement = true;
			Player.instance.MyAnimator.SetFloat(AnimationHashes.Horizontal, 0f);
			CurrentTarget = null;
			availableTargets.Clear();
			cachedSuccubus = null;
		}

		private void UpdateVerticalTracking()
		{
			if (CurrentTarget == null)
			{
				currentHeightOffset = Mathf.Lerp(currentHeightOffset, 0f, verticalTrackingSpeed * Time.deltaTime);
				currentPitchOffset = Mathf.Lerp(currentPitchOffset, defaultPitchOffset, verticalTrackingSpeed * Time.deltaTime);
				return;
			}
			float t = ((cachedSuccubus != null) ? cachedSuccubus.m_heightBlend : 0f);
			float b = Mathf.Lerp(heightOffset, heightOffset + flyingCameraHeightOffset, t);
			float b2 = Mathf.Lerp(defaultPitchOffset, defaultPitchOffset + flyingPitchOffset, t);
			currentHeightOffset = Mathf.Lerp(currentHeightOffset, b, verticalTrackingSpeed * Time.deltaTime);
			currentPitchOffset = Mathf.Lerp(currentPitchOffset, b2, verticalTrackingSpeed * Time.deltaTime);
		}

		private void TrackTarget()
		{
			Vector3 lockPoint = CurrentTarget.GetLockPoint();
			Vector3 position = rig.pivot.position;
			Vector3 normalized = (lockPoint - position).normalized;
			float b = (0f - Mathf.Asin(Mathf.Clamp(normalized.y, -1f, 1f))) * 57.29578f + currentPitchOffset;
			rig.Pitch = Mathf.Lerp(rig.Pitch, b, trackingSpeed * Time.deltaTime);
			Vector3 vector = rig.camera.WorldToScreenPoint(lockPoint);
			Vector3 vector2 = new Vector3(rig.camera.pixelRect.width * targetScreenPosition.x, rig.camera.pixelRect.height * targetScreenPosition.y);
			Vector3 vector3 = vector - vector2;
			float num = Mathf.Max(rig.camera.pixelRect.width, rig.camera.pixelRect.height) * screenDeadzoneRadius;
			float num2 = Mathf.Max(rig.camera.pixelRect.width, rig.camera.pixelRect.height) * screenSmoothzoneRadius;
			float magnitude = vector3.magnitude;
			bool num3 = magnitude <= num;
			bool flag = magnitude <= num2 && magnitude > num;
			float b2 = Mathf.Atan2(normalized.x, normalized.z) * 57.29578f;
			float smoothedYaw = rig.SmoothedYaw;
			if (num3)
			{
				rig.Yaw = Mathf.LerpAngle(rig.Yaw, smoothedYaw, smoothzoneReturnSpeed * Time.deltaTime);
			}
			else if (flag)
			{
				float t = (magnitude - num) / (num2 - num);
				float b3 = Mathf.LerpAngle(smoothedYaw, b2, t);
				rig.Yaw = Mathf.LerpAngle(rig.Yaw, b3, smoothzoneReturnSpeed * Time.deltaTime);
			}
			else
			{
				rig.Yaw = Mathf.LerpAngle(rig.Yaw, b2, trackingSpeed * Time.deltaTime);
			}
		}

		private void UpdateShoulderOffset()
		{
			Vector3 vector = rig.pivot.InverseTransformPoint(CurrentTarget.GetLockPoint());
			targetShoulderOffset = ((vector.x < 0f - shoulderSwapDeadzone) ? (0f - sideOffset) : ((vector.x > shoulderSwapDeadzone) ? sideOffset : 0f));
			rig.ShoulderOffset = Mathf.Lerp(rig.ShoulderOffset, targetShoulderOffset, shoulderSwapSpeed * Time.deltaTime);
			rig.HeightOffset = Mathf.Lerp(rig.HeightOffset, currentHeightOffset, verticalTrackingSpeed * Time.deltaTime);
			rig.PitchOffset = Mathf.Lerp(rig.PitchOffset, currentPitchOffset, verticalTrackingSpeed * Time.deltaTime);
		}

		private void UpdateDistance()
		{
			Vector3 vector = rig.camera.WorldToScreenPoint(CurrentTarget.GetLockPoint());
			Vector3 vector2 = new Vector3(rig.camera.pixelRect.width * targetScreenPosition.x, rig.camera.pixelRect.height * targetScreenPosition.y);
			Vector3 vector3 = vector - vector2;
			float num = Mathf.Max(rig.camera.pixelRect.width, rig.camera.pixelRect.height) * screenDeadzoneRadius;
			float b = ((vector3.magnitude > num) ? lockDistance : rig.Distance);
			rig.Distance = Mathf.Lerp(rig.Distance, b, trackingSpeed * Time.deltaTime);
		}

		private void ApplyVerticalHeightClamp()
		{
			Vector3 position = base.transform.position;
			if (Physics.Raycast(position, Vector3.down, out var hitInfo, 100f, rig.collisionLayers))
			{
				float num = position.y - hitInfo.point.y;
				if (num < minVerticalHeight)
				{
					base.transform.position += Vector3.up * (minVerticalHeight - num);
				}
				else if (num > maxVerticalHeight)
				{
					base.transform.position -= Vector3.up * (num - maxVerticalHeight);
				}
			}
		}

		private void HandleTargetCycling()
		{
			if (availableTargets.Count > 1 && !(Time.time - lastCycleTime < cycleCooldown))
			{
				float num = ((!InputQuery.IsUsingKeyboardMouse) ? InputQuery.Look.x : ((Mathf.Abs(InputQuery.ScrollWheel.y) > 0.01f) ? Mathf.Sign(InputQuery.ScrollWheel.y) : 0f));
				if (Mathf.Abs(num) > cycleThreshold)
				{
					CycleTarget((num > 0f) ? 1 : (-1));
					lastCycleTime = Time.time;
				}
			}
		}

		private void CycleTarget(int direction)
		{
			Vector3 vector = rig.camera.WorldToScreenPoint(CurrentTarget.GetLockPoint());
			List<TargetLockIndicator> list = new List<TargetLockIndicator>();
			foreach (TargetLockIndicator availableTarget in availableTargets)
			{
				if (!(availableTarget == CurrentTarget))
				{
					Vector3 vector2 = rig.camera.WorldToScreenPoint(availableTarget.GetLockPoint());
					if ((direction > 0 && vector2.x > vector.x) || (direction < 0 && vector2.x < vector.x))
					{
						list.Add(availableTarget);
					}
				}
			}
			if (list.Count == 0)
			{
				list = availableTargets.Where((TargetLockIndicator t) => t != CurrentTarget).ToList();
			}
			if (list.Count != 0)
			{
				TargetLockIndicator targetLockIndicator = list.OrderBy((TargetLockIndicator t) => Vector3.Distance(rig.pivot.position, t.GetLockPoint())).FirstOrDefault();
				if (targetLockIndicator != null)
				{
					CurrentTarget = targetLockIndicator;
					currentTargetIndex = availableTargets.IndexOf(targetLockIndicator);
					cachedSuccubus = CurrentTarget.enemy.GetComponent<Succubus>();
				}
			}
		}

		private void RefreshTargets()
		{
			availableTargets.RemoveAll((TargetLockIndicator t) => !IsTargetValid(t));
			TargetLockIndicator[] array = Object.FindObjectsByType<TargetLockIndicator>(FindObjectsInactive.Include, FindObjectsSortMode.None);
			foreach (TargetLockIndicator targetLockIndicator in array)
			{
				if (IsTargetValid(targetLockIndicator) && !availableTargets.Contains(targetLockIndicator))
				{
					availableTargets.Add(targetLockIndicator);
				}
			}
			availableTargets = availableTargets.OrderBy((TargetLockIndicator t) => Vector3.Distance(rig.pivot.position, t.GetLockPoint())).ToList();
		}

		private bool IsTargetValid(TargetLockIndicator target)
		{
			if (target != null && target.gameObject.activeInHierarchy)
			{
				Enemy enemy = target.enemy;
				if ((object)enemy == null)
				{
					return true;
				}
				return enemy.Behaviour.State != EnemyState.Die;
			}
			return false;
		}
	}
}
