using UnityEngine;

namespace HNS
{
	public class OrbitCameraState : CameraState
	{
		[Header("Orbit Settings")]
		public float transitionDuration = 0.25f;

		private bool isTransitioning;

		private float transitionTimer;

		public override void OnEnter()
		{
			Player.instance.AbsoluteMovement = true;
			rig.Pitch = rig.SmoothedPitch;
			rig.Yaw = rig.SmoothedYaw;
			rig.Distance = rig.SmoothedDistance;
			rig.ShoulderOffset = rig.SmoothedShoulderOffset;
			rig.HeightOffset = rig.SmoothedHeightOffset;
			rig.PitchOffset = rig.SmoothedPitchOffset;
			rig.SyncSmoothedToRaw();
			isTransitioning = true;
			transitionTimer = 0f;
		}

		public override void OnUpdate()
		{
			if (Time.timeScale != 0f)
			{
				Vector2 look = InputQuery.Look;
				float num = (InputQuery.IsUsingKeyboardMouse ? 500f : 100f);
				rig.Pitch -= look.y * rig.lookSensitivity * num * Time.deltaTime;
				rig.Yaw += look.x * rig.lookSensitivity * num * Time.deltaTime;
				rig.Distance -= InputQuery.ScrollWheel.y * rig.zoomSensitivity;
			}
		}

		public override void OnLateUpdate()
		{
			if (isTransitioning)
			{
				transitionTimer += Time.deltaTime;
				if (transitionTimer >= transitionDuration)
				{
					isTransitioning = false;
				}
				rig.ShoulderOffset = Mathf.Lerp(rig.ShoulderOffset, 0f, 8f * Time.deltaTime);
				rig.HeightOffset = Mathf.Lerp(rig.HeightOffset, 0f, 8f * Time.deltaTime);
				rig.PitchOffset = Mathf.Lerp(rig.PitchOffset, 0f, 8f * Time.deltaTime);
			}
			else
			{
				rig.ShoulderOffset = 0f;
				rig.HeightOffset = 0f;
				rig.PitchOffset = 0f;
			}
			rig.ApplyConstraints();
			rig.SmoothValues(Time.deltaTime);
		}
	}
}
