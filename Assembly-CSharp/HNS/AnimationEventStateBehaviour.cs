using UnityEngine;

namespace HNS
{
	public class AnimationEventStateBehaviour : StateMachineBehaviour
	{
		public GameObject Prefab;

		[Range(0f, 1f)]
		public float triggerTime;

		public bool PlayerHand;

		private bool hasTriggered;

		public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			hasTriggered = false;
		}

		public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
		{
			if (stateInfo.normalizedTime % 1f >= triggerTime && !hasTriggered)
			{
				if (PlayerHand)
				{
					Object.Instantiate(Prefab, PlayerCombo.instance.Hand.position, PlayerCombo.instance.Hand.rotation, PlayerCombo.instance.Hand);
				}
				else
				{
					Object.Instantiate(Prefab, animator.transform.position, animator.transform.rotation, animator.transform);
				}
				hasTriggered = true;
			}
		}
	}
}
