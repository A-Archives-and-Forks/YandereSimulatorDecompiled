using UnityEngine;

namespace HNS
{
	[CreateAssetMenu(fileName = "PlayerProfile", menuName = "HNS/Player Profile", order = 1)]
	public class PlayerProfile : ScriptableObject
	{
		[Header("Attack")]
		public Combo[] Combos;

		[Header("Combat Timing")]
		[Range(0f, 1f)]
		public float InterruptTime = 0.9f;

		[Range(0f, 1f)]
		public float ColorSwitchMovementInterruptTime = 0.6f;

		[Range(0f, 1f)]
		public float ColorSwitchInterruptTime = 0.4f;

		public float QuickSwitchFadeInTime = 0.05f;

		public float QuickSwitchFadeOutTime = 0.15f;

		public float VelocityDecayRate = 10f;

		[Header("Dodge")]
		[Range(0f, 1f)]
		public float DodgeMovementInterruptTime = 0.9f;

		[Range(0f, 1f)]
		public float DodgeInterruptTime = 0.5f;

		public float DodgeForce = 10f;

		public float DodgeForceSlowdown = 10f;

		public GameObject DodgeParticle;

		[Header("Ultimate")]
		public float UltimateActivationRange = 2f;

		public float UltimateFlashSpeed = 1f;

		[Header("Movement")]
		public float MovementDampingAbsolute = 0.2f;

		public float MovementDampingRelative = 0.15f;

		public float RotationSpeed = 20f;

		[Range(0f, 1f)]
		[Tooltip("Percentage of rotation control during combo attacks (0 = locked, 1 = full control)")]
		public float ComboRotationControl = 0.3f;

		[Range(0f, 1f)]
		[Tooltip("Percentage of rotation control during dodge roll (0 = locked, 1 = full control)")]
		public float DodgeRotationControl = 0.5f;

		[Header("Resources")]
		public float StaminaCost = 50f;

		public float StaminaPauseDuration = 1.5f;

		public float StaminaRegenRate = 20f;

		public float HealthRegenRate = 1f;

		public float VignetteLerpSpeed = 10f;

		[Header("Weapon")]
		public float HitCooldown = 0.1f;

		public float CollisionRadius = 0.1f;

		[Header("Animation")]
		public float DefaultCrossFade = 0.3f;
	}
}
