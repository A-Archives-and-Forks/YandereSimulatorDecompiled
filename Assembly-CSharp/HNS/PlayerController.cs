using UnityEngine;

namespace HNS
{
	public class PlayerController : MonoBehaviour
	{
		private void Update()
		{
			if (Player.instance.State == PlayerState.Default)
			{
				UpdateDefault();
			}
		}

		private void UpdateDefault()
		{
			if (Player.instance.Stance == PlayerStance.Default)
			{
				UpdateMovement();
			}
			UpdateGravity();
			if (Player.instance.State == PlayerState.Default && Player.instance.Stance != PlayerStance.Ultimate && Player.instance.Stance != PlayerStance.Hit)
			{
				Vector2 movement = InputQuery.Movement;
				PlayerProfile profile = Player.instance.Profile;
				if (Player.instance.AbsoluteMovement)
				{
					Player.instance.MyAnimator.SetFloat(AnimationHashes.Vertical, (Player.instance.Stance == PlayerStance.Dodge) ? 1f : movement.magnitude, profile.MovementDampingAbsolute, Time.deltaTime);
					return;
				}
				Player.instance.MyAnimator.SetFloat(AnimationHashes.Horizontal, movement.x, profile.MovementDampingRelative, Time.deltaTime);
				Player.instance.MyAnimator.SetFloat(AnimationHashes.Vertical, movement.y, profile.MovementDampingRelative, Time.deltaTime);
			}
		}

		private void UpdateGravity()
		{
			if (base.transform.position.y > 0.05f)
			{
				Player.instance.MyController.Move(Physics.gravity * Time.deltaTime);
			}
		}

		private void UpdateMovement()
		{
			Vector2 movement = InputQuery.Movement;
			Camera myCamera = Player.instance.MyCamera;
			float rotationSpeed = Player.instance.Profile.RotationSpeed;
			if (Player.instance.AbsoluteMovement)
			{
				Vector3 vector = myCamera.transform.TransformDirection(Vector3.forward);
				vector.y = 0f;
				vector = vector.normalized;
				Vector3 vector2 = new Vector3(vector.z, 0f, 0f - vector.x);
				Vector3 forward = movement.x * vector2 + movement.y * vector;
				if (forward.magnitude > 0.1f)
				{
					Quaternion b = Quaternion.LookRotation(forward);
					Player.instance.transform.rotation = Quaternion.Lerp(Player.instance.transform.rotation, b, Time.deltaTime * rotationSpeed);
				}
			}
			else
			{
				Quaternion b2 = Quaternion.Euler(0f, myCamera.transform.eulerAngles.y, 0f);
				Player.instance.transform.rotation = Quaternion.Lerp(Player.instance.transform.rotation, b2, Time.deltaTime * rotationSpeed);
			}
		}
	}
}
