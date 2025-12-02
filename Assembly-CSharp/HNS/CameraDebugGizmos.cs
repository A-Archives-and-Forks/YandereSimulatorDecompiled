using UnityEngine;

namespace HNS
{
	[ExecuteAlways]
	[RequireComponent(typeof(CameraStateMachine), typeof(CameraRig))]
	public class CameraDebugGizmos : MonoBehaviour
	{
		[Header("Gizmo Settings")]
		public bool showGizmos = true;

		public Color innerRangeColor = Color.red;

		public Color outerRangeColor = Color.cyan;

		public Color connectionColor = Color.blue;

		public Color limitArcColor = Color.yellow;

		[Range(32f, 128f)]
		public int circleSegments = 64;

		private CameraStateMachine stateMachine;

		private CameraRig rig;
	}
}
