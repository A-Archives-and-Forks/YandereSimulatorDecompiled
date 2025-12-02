using UnityEngine;

namespace HNS
{
	public class AxisStates
	{
		private readonly AxisProcessor _movementProcessor;

		private readonly AxisProcessor _lookProcessor;

		private readonly AxisProcessor _scrollProcessor;

		public Vector2 Movement { get; private set; }

		public Vector2 Look { get; private set; }

		public Vector2 ScrollWheel { get; private set; }

		public AxisStates()
		{
			_movementProcessor = new AxisProcessor(0.1f);
			_lookProcessor = new AxisProcessor(0.1f);
			_scrollProcessor = new AxisProcessor(0f);
		}

		public void Update()
		{
			Movement = _movementProcessor.Process(GetMovementRaw());
			Look = _lookProcessor.Process(GetLookRaw());
			ScrollWheel = _scrollProcessor.Process(GetScrollWheelRaw());
		}

		private Vector2 GetMovementRaw()
		{
			return new Vector2(GetAxisRaw("Horizontal"), GetAxisRaw("Vertical"));
		}

		private Vector2 GetLookRaw()
		{
			if (InputManager.IsUsingKeyboardMouse)
			{
				return new Vector2(GetAxis("Mouse X"), GetAxis("Mouse Y"));
			}
			return new Vector2(GetAxis("Joystick X"), GetAxis("Joystick Y"));
		}

		private Vector2 GetScrollWheelRaw()
		{
			return new Vector2(0f, GetAxis("Mouse ScrollWheel"));
		}

		private float GetAxis(string axisName)
		{
			try
			{
				return Input.GetAxis(axisName);
			}
			catch
			{
				return 0f;
			}
		}

		private float GetAxisRaw(string axisName)
		{
			try
			{
				return Input.GetAxisRaw(axisName);
			}
			catch
			{
				return 0f;
			}
		}
	}
}
