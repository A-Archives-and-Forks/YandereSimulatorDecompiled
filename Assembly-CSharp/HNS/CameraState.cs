using UnityEngine;

namespace HNS
{
	public abstract class CameraState : MonoBehaviour
	{
		protected CameraStateMachine stateMachine;

		protected CameraRig rig;

		protected virtual void OnEnable()
		{
			stateMachine = GetComponent<CameraStateMachine>();
			rig = GetComponent<CameraRig>();
		}

		public virtual void OnEnter()
		{
		}

		public virtual void OnUpdate()
		{
		}

		public virtual void OnLateUpdate()
		{
		}

		public virtual void OnExit()
		{
		}
	}
}
