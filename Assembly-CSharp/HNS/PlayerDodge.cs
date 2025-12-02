using UnityEngine;

namespace HNS
{
	public class PlayerDodge : MonoBehaviour
	{
		private bool movementQueued;

		private float velocity;

		private bool collisionDisabled;

		private ParticleSystem dodgeEffect;

		private Vector3 dodgeDirection;

		private void Update()
		{
			if (Player.instance.State != PlayerState.Default || Player.instance.Stance == PlayerStance.Ultimate || Player.instance.Stance == PlayerStance.Hit)
			{
				return;
			}
			Vector2 movement = InputQuery.Movement;
			PlayerProfile profile = Player.instance.Profile;
			if (Player.instance.Stance == PlayerStance.Dodge)
			{
				if (movement.magnitude > 0.1f)
				{
					movementQueued = true;
				}
				if (!movementQueued && PlayerAnimator.Finished())
				{
					Player.instance.Stance = PlayerStance.Default;
					Player.instance.MyAnimator.SetFloat(AnimationHashes.Vertical, 0f);
					RestoreCollision();
					return;
				}
				if (movementQueued && PlayerAnimator.NormalizedTime() >= profile.DodgeMovementInterruptTime)
				{
					Player.instance.Stance = PlayerStance.Default;
					Player.instance.MyAnimator.SetFloat(AnimationHashes.Vertical, 0f, 0.2f, Time.deltaTime);
					movementQueued = false;
					RestoreCollision();
					return;
				}
				if (Player.instance.AbsoluteMovement && movement.magnitude > 0.1f)
				{
					Vector3 forward = Player.instance.transform.forward;
					float num = profile.RotationSpeed * profile.DodgeRotationControl;
					Quaternion b = Quaternion.LookRotation(forward);
					Player.instance.transform.rotation = Quaternion.Lerp(Player.instance.transform.rotation, b, Time.deltaTime * num);
				}
			}
			if (InputQuery.ButtonDown(ButtonInput.A) && Player.instance.Stamina >= profile.StaminaCost)
			{
				if (Player.instance.Stance == PlayerStance.Dodge && PlayerAnimator.NormalizedTime() < profile.DodgeInterruptTime)
				{
					return;
				}
				Player.instance.Stance = PlayerStance.Dodge;
				dodgeEffect = Object.Instantiate(Player.instance.Profile.DodgeParticle, base.transform.position, base.transform.rotation, base.transform).GetComponent<ParticleSystem>();
				PlayerAnimator.Play(AnimationHashes.Dodge);
				velocity = profile.DodgeForce;
				if (Player.instance.AbsoluteMovement)
				{
					dodgeDirection = Player.instance.transform.forward;
				}
				else if (movement.magnitude < 0.1f)
				{
					dodgeDirection = -Player.instance.transform.forward;
				}
				else
				{
					dodgeDirection = (Quaternion.Euler(0f, Player.instance.MyCamera.transform.eulerAngles.y, 0f) * new Vector3(movement.x, 0f, movement.y)).normalized;
				}
				UpdateDodgeEffectPosition();
				DisableCollision();
			}
			velocity -= Time.deltaTime * profile.DodgeForceSlowdown;
			if (velocity < 0f)
			{
				velocity = 0f;
			}
			if (velocity != 0f)
			{
				if (movement.magnitude > 0.1f)
				{
					dodgeDirection = new Vector3(movement.x, 0f, movement.y).normalized;
				}
				if (Player.instance.AbsoluteMovement)
				{
					Player.instance.MyController.Move(Player.instance.transform.forward * velocity * Time.deltaTime);
				}
				else
				{
					Player.instance.MyController.Move(Quaternion.Euler(0f, Player.instance.MyCamera.transform.eulerAngles.y, 0f) * dodgeDirection * velocity * Time.deltaTime);
				}
			}
		}

		private void DisableCollision()
		{
			if (collisionDisabled || WaveManager.Instance == null)
			{
				return;
			}
			foreach (Enemy activeEnemy in WaveManager.Instance.ActiveEnemies)
			{
				if (activeEnemy == null)
				{
					continue;
				}
				CharacterController component = activeEnemy.GetComponent<CharacterController>();
				if (component != null)
				{
					Physics.IgnoreCollision(Player.instance.MyController, component, ignore: true);
				}
				EnemyBodyPart[] componentsInChildren = activeEnemy.GetComponentsInChildren<EnemyBodyPart>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					Collider component2 = componentsInChildren[i].GetComponent<Collider>();
					if (component2 != null)
					{
						Physics.IgnoreCollision(Player.instance.MyController, component2, ignore: true);
					}
				}
			}
			collisionDisabled = true;
		}

		private void RestoreCollision()
		{
			if (!collisionDisabled || WaveManager.Instance == null)
			{
				return;
			}
			foreach (Enemy activeEnemy in WaveManager.Instance.ActiveEnemies)
			{
				if (activeEnemy == null)
				{
					continue;
				}
				CharacterController component = activeEnemy.GetComponent<CharacterController>();
				if (component != null)
				{
					Physics.IgnoreCollision(Player.instance.MyController, component, ignore: false);
				}
				EnemyBodyPart[] componentsInChildren = activeEnemy.GetComponentsInChildren<EnemyBodyPart>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					Collider component2 = componentsInChildren[i].GetComponent<Collider>();
					if (component2 != null)
					{
						Physics.IgnoreCollision(Player.instance.MyController, component2, ignore: false);
					}
				}
			}
			collisionDisabled = false;
		}

		private void UpdateDodgeEffectPosition()
		{
			if (!(dodgeEffect == null))
			{
				dodgeEffect.transform.rotation = Quaternion.LookRotation(dodgeDirection);
			}
		}
	}
}
