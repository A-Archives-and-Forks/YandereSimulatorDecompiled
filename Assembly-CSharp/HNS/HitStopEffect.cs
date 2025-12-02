using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HNS
{
	public class HitStopEffect : MonoBehaviour
	{
		private static Dictionary<Animator, float> lastHitStopTime = new Dictionary<Animator, float>();

		private static Dictionary<Animator, HitStopEffect> activeEffects = new Dictionary<Animator, HitStopEffect>();

		private Transform shakeTarget;

		private Vector3 shakeOffset;

		private Vector3 originalLocalPos;

		private bool isActive;

		public static void Apply(Animator animator, Transform target, float duration, float animSpeed, float shakeIntensity, AnimationCurve shakeCurve, bool isVictim)
		{
			if ((bool)animator && (bool)target && !activeEffects.ContainsKey(animator) && (!lastHitStopTime.ContainsKey(animator) || !(Time.unscaledTime - lastHitStopTime[animator] < 0.3f)))
			{
				GameObject obj = new GameObject("HitStopEffect");
				obj.transform.SetParent(target);
				obj.transform.localPosition = Vector3.zero;
				obj.transform.localRotation = Quaternion.identity;
				HitStopEffect hitStopEffect = obj.AddComponent<HitStopEffect>();
				activeEffects[animator] = hitStopEffect;
				lastHitStopTime[animator] = Time.unscaledTime;
				hitStopEffect.StartCoroutine(hitStopEffect.Execute(animator, target, duration, animSpeed, shakeIntensity, shakeCurve));
			}
		}

		private IEnumerator Execute(Animator animator, Transform target, float duration, float animSpeed, float shakeIntensity, AnimationCurve shakeCurve)
		{
			animator.speed = animSpeed;
			HitStopShakeTarget component = target.GetComponent<HitStopShakeTarget>();
			shakeTarget = (component ? component.ShakeBone : target);
			if ((bool)shakeTarget)
			{
				originalLocalPos = shakeTarget.localPosition;
				isActive = true;
			}
			float elapsed = 0f;
			float nextShake = 0f;
			while (elapsed < duration)
			{
				float time = elapsed / duration;
				float num = shakeCurve.Evaluate(time);
				if ((bool)HitStopManager.Instance && HitStopManager.Instance.ShakeEnabled && (bool)shakeTarget)
				{
					nextShake -= Time.unscaledDeltaTime;
					if (nextShake <= 0f)
					{
						nextShake = HitStopManager.Instance.ShakeInterval;
						float num2 = CalculateDistanceMultiplier(shakeTarget);
						shakeOffset = GenerateShakeOffset(shakeIntensity * num * num2, shakeTarget);
					}
				}
				elapsed += Time.unscaledDeltaTime;
				yield return null;
			}
			isActive = false;
			if ((bool)shakeTarget)
			{
				shakeTarget.localPosition = originalLocalPos;
			}
			animator.speed = 1f;
			if (activeEffects.ContainsKey(animator))
			{
				activeEffects.Remove(animator);
			}
			Object.Destroy(base.gameObject);
		}

		private void LateUpdate()
		{
			if (isActive && (bool)shakeTarget)
			{
				shakeTarget.localPosition = originalLocalPos + shakeOffset;
			}
		}

		private float CalculateDistanceMultiplier(Transform target)
		{
			if (!Player.instance || !Player.instance.MyCamera)
			{
				return 1f;
			}
			float t = Mathf.Clamp01((Vector3.Distance(Player.instance.MyCamera.transform.position, target.position) - 3f) / 7f);
			return Mathf.Lerp(1f, 1.8f, t);
		}

		private Vector3 GenerateShakeOffset(float intensity, Transform target)
		{
			if (IsGrounded(target))
			{
				return new Vector3(Random.Range(0f - intensity, intensity), 0f, Random.Range(0f - intensity, intensity));
			}
			return new Vector3(Random.Range(0f - intensity, intensity), Random.Range(0f - intensity, intensity), Random.Range(0f - intensity, intensity));
		}

		private bool IsGrounded(Transform target)
		{
			CharacterController component = target.GetComponent<CharacterController>();
			if ((bool)component)
			{
				return component.isGrounded;
			}
			return Mathf.Abs(target.position.y) < 0.1f;
		}
	}
}
