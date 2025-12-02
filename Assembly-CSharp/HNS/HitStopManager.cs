using UnityEngine;

namespace HNS
{
	public class HitStopManager : MonoBehaviour
	{
		[Header("Global Settings")]
		public bool Enabled = true;

		public bool ShakeEnabled = true;

		[Header("Timing")]
		[Range(0.05f, 0.2f)]
		public float Duration = 0.1f;

		[Range(0.05f, 0.2f)]
		public float FinalBlowDuration = 0.15f;

		[Header("Animator Speed")]
		[Range(0f, 0.5f)]
		public float AnimatorSpeed = 0.1f;

		[Range(0f, 0.5f)]
		public float FinalBlowAnimatorSpeed = 0.05f;

		[Header("Shake Settings")]
		[Range(0.001f, 0.1f)]
		public float AttackerShakeIntensity = 0.01f;

		[Range(0.001f, 0.1f)]
		public float VictimShakeIntensity = 0.03f;

		[Range(0.001f, 0.1f)]
		public float FinalBlowAttackerShakeIntensity = 0.02f;

		[Range(0.001f, 0.1f)]
		public float FinalBlowVictimShakeIntensity = 0.05f;

		[Range(0.001f, 0.05f)]
		public float ShakeInterval = 0.01f;

		[Header("Shake Curves")]
		public AnimationCurve AttackerShakeCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

		public AnimationCurve VictimShakeCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

		public static HitStopManager Instance { get; private set; }

		private void Awake()
		{
			if ((bool)Instance && Instance != this)
			{
				Object.Destroy(base.gameObject);
			}
			else
			{
				Instance = this;
			}
		}

		private void OnDestroy()
		{
			if (Instance == this)
			{
				Instance = null;
			}
		}

		public void TriggerHitStop(Animator attacker, Animator victim, Transform attackerTransform, Transform victimTransform, bool isFinalBlow = false)
		{
			if (Enabled)
			{
				float duration = (isFinalBlow ? FinalBlowDuration : Duration);
				float animSpeed = (isFinalBlow ? FinalBlowAnimatorSpeed : AnimatorSpeed);
				float shakeIntensity = (isFinalBlow ? FinalBlowAttackerShakeIntensity : AttackerShakeIntensity);
				float shakeIntensity2 = (isFinalBlow ? FinalBlowVictimShakeIntensity : VictimShakeIntensity);
				HitStopEffect.Apply(attacker, attackerTransform, duration, animSpeed, shakeIntensity, AttackerShakeCurve, isVictim: false);
				HitStopEffect.Apply(victim, victimTransform, duration, animSpeed, shakeIntensity2, VictimShakeCurve, isVictim: true);
			}
		}
	}
}
