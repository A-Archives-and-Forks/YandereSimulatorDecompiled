using UnityEngine;

namespace HNS
{
	[ExecuteInEditMode]
	public class CameraRig : MonoBehaviour
	{
		[Header("References")]
		public Camera camera;

		public Transform pivot;

		[Header("Orbit Settings")]
		[Range(0f, 100f)]
		public float defaultDistance = 100f;

		[Tooltip("Default vertical tilt angle (pitch)")]
		public float defaultTilt = 10f;

		[Tooltip("Minimum and maximum camera distance")]
		public Vector2 distanceRange = new Vector2(1f, 3f);

		[Tooltip("Vertical rotation limits (pitch)")]
		public Vector2 pitchLimits = new Vector2(-90f, 90f);

		[Tooltip("Camera movement smoothing speed")]
		public float smoothSpeed = 15f;

		[Tooltip("Mouse/stick sensitivity")]
		public float lookSensitivity = 1f;

		[Tooltip("Scroll wheel zoom sensitivity")]
		public float zoomSensitivity = 1f;

		[Header("Input Damping")]
		[Tooltip("Damping coefficient for velocity-based smoothing (0.1-0.5 recommended)")]
		public float dampingCoefficient = 0.2f;

		[Header("Collision")]
		[Tooltip("Layers the camera collides with")]
		public LayerMask collisionLayers;

		[Tooltip("Near clip plane margin multiplier")]
		public float clipMargin = 1.4f;

		private float pitchVel;

		private float yawVel;

		private float distanceVel;

		private float shoulderVel;

		private float heightVel;

		private float pitchOffsetVel;

		public float Pitch { get; set; }

		public float Yaw { get; set; }

		public float Distance { get; set; }

		public float SmoothedPitch { get; private set; }

		public float SmoothedYaw { get; private set; }

		public float SmoothedDistance { get; private set; }

		public float ShoulderOffset { get; set; }

		public float HeightOffset { get; set; }

		public float PitchOffset { get; set; }

		public float SmoothedShoulderOffset { get; private set; }

		public float SmoothedHeightOffset { get; private set; }

		public float SmoothedPitchOffset { get; private set; }

		private void Start()
		{
			ResetToStartPosition();
		}

		[ContextMenu("Reset Camera to Start Position")]
		public void ResetToStartPosition()
		{
			float distance = (SmoothedDistance = Mathf.Lerp(distanceRange.x, distanceRange.y, defaultDistance * 0.01f));
			Distance = distance;
			distance = (SmoothedPitch = defaultTilt);
			Pitch = distance;
			distance = (SmoothedYaw = 0f);
			Yaw = distance;
			distance = (SmoothedShoulderOffset = 0f);
			ShoulderOffset = distance;
			distance = (SmoothedHeightOffset = 0f);
			HeightOffset = distance;
			distance = (SmoothedPitchOffset = 0f);
			PitchOffset = distance;
			pitchVel = (yawVel = (distanceVel = (shoulderVel = (heightVel = (pitchOffsetVel = 0f)))));
		}

		[ContextMenu("Update Camera Position (Edit Mode)")]
		public void UpdateCameraPosition()
		{
		}

		private void LateUpdate()
		{
			PositionCamera();
		}

		public void ApplyConstraints()
		{
			Pitch = Mathf.Clamp(Pitch, pitchLimits.x, pitchLimits.y);
			Distance = Mathf.Clamp(Distance, distanceRange.x, distanceRange.y);
		}

		public void SmoothValues(float deltaTime)
		{
			SmoothedPitch = Mathf.SmoothDamp(SmoothedPitch, Pitch, ref pitchVel, 1f / smoothSpeed, float.PositiveInfinity, deltaTime);
			SmoothedYaw = Mathf.SmoothDamp(SmoothedYaw, Yaw, ref yawVel, 1f / smoothSpeed, float.PositiveInfinity, deltaTime);
			SmoothedDistance = Mathf.SmoothDamp(SmoothedDistance, Distance, ref distanceVel, 1f / smoothSpeed, float.PositiveInfinity, deltaTime);
			SmoothedShoulderOffset = Mathf.SmoothDamp(SmoothedShoulderOffset, ShoulderOffset, ref shoulderVel, dampingCoefficient, float.PositiveInfinity, deltaTime);
			SmoothedHeightOffset = Mathf.SmoothDamp(SmoothedHeightOffset, HeightOffset, ref heightVel, dampingCoefficient, float.PositiveInfinity, deltaTime);
			SmoothedPitchOffset = Mathf.SmoothDamp(SmoothedPitchOffset, PitchOffset, ref pitchOffsetVel, dampingCoefficient, float.PositiveInfinity, deltaTime);
		}

		public void SyncSmoothedToRaw()
		{
			SmoothedPitch = Pitch;
			SmoothedYaw = Yaw;
			SmoothedDistance = Distance;
			SmoothedShoulderOffset = ShoulderOffset;
			SmoothedHeightOffset = HeightOffset;
			SmoothedPitchOffset = PitchOffset;
			pitchVel = (yawVel = (distanceVel = (shoulderVel = (heightVel = (pitchOffsetVel = 0f)))));
		}

		private void PositionCamera()
		{
			Vector3 vector = new Vector3(SmoothedShoulderOffset, SmoothedHeightOffset, 0f);
			Vector3 vector2 = Quaternion.Euler(0f, SmoothedYaw, 0f) * vector;
			Vector3 vector3 = Quaternion.Euler(SmoothedPitch + SmoothedPitchOffset, SmoothedYaw, 0f) * Vector3.forward;
			Vector3 position = pivot.position + vector2 - vector3 * SmoothedDistance;
			Quaternion rotation = Quaternion.Euler(SmoothedPitch + SmoothedPitchOffset, SmoothedYaw, 0f);
			base.transform.SetPositionAndRotation(position, rotation);
			HandleCollisions();
		}

		public void HandleCollisions()
		{
			Vector3 position = base.transform.position;
			Vector3 position2 = pivot.position;
			if (Physics.Linecast(position, position2, out var hitInfo, collisionLayers))
			{
				base.transform.position = hitInfo.point + camera.nearClipPlane * clipMargin * base.transform.forward;
			}
			if (Physics.Linecast(position2, position, out hitInfo, collisionLayers))
			{
				base.transform.position = hitInfo.point + camera.nearClipPlane * clipMargin * base.transform.forward;
			}
		}
	}
}
