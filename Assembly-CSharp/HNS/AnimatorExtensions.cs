using UnityEngine;

namespace HNS
{
	public static class AnimatorExtensions
	{
		public static bool IsPlaying(this Animator animator, int stateHash, int layer = 0)
		{
			if (animator.IsInTransition(layer))
			{
				return animator.GetNextAnimatorStateInfo(layer).shortNameHash == stateHash;
			}
			return animator.GetCurrentAnimatorStateInfo(layer).shortNameHash == stateHash;
		}

		public static bool Finished(this Animator animator, float offset = 0f, int layer = 0)
		{
			if (animator.IsInTransition(layer))
			{
				return animator.GetNextAnimatorStateInfo(layer).normalizedTime >= 1f - offset;
			}
			return animator.GetCurrentAnimatorStateInfo(layer).normalizedTime >= 1f - offset;
		}

		public static float NormalizedTime(this Animator animator, int layer = 0)
		{
			if (animator.IsInTransition(layer))
			{
				return animator.GetNextAnimatorStateInfo(layer).normalizedTime;
			}
			return animator.GetCurrentAnimatorStateInfo(layer).normalizedTime;
		}

		public static float FixedTime(this Animator animator, int layer)
		{
			if (animator.IsInTransition(layer))
			{
				AnimatorStateInfo nextAnimatorStateInfo = animator.GetNextAnimatorStateInfo(layer);
				return nextAnimatorStateInfo.normalizedTime * nextAnimatorStateInfo.length;
			}
			AnimatorStateInfo currentAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(layer);
			return currentAnimatorStateInfo.normalizedTime * currentAnimatorStateInfo.length;
		}

		public static bool InHitFrame(this Animator animator, float start, float end, int layer = 0)
		{
			float num = animator.NormalizedTime(layer) % 1f;
			if (num >= start)
			{
				return num <= end;
			}
			return false;
		}
	}
}
