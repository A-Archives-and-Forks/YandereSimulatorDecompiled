using UnityEngine;

namespace HNS
{
	public class InputState
	{
		private ButtonStates _buttonStates;

		private AxisStates _axisStates;

		private DirectionalInput _directionalInput;

		public Vector2 Movement => _axisStates.Movement;

		public Vector2 Look => _axisStates.Look;

		public Vector2 ScrollWheel => _axisStates.ScrollWheel;

		public InputState()
		{
			_buttonStates = new ButtonStates();
			_axisStates = new AxisStates();
			_directionalInput = new DirectionalInput();
		}

		public void Update()
		{
			_buttonStates.Update();
			_axisStates.Update();
			_directionalInput.Update();
		}

		public bool GetButton(ButtonInput button)
		{
			return _buttonStates.GetButton(button);
		}

		public bool GetButtonDown(ButtonInput button)
		{
			return _buttonStates.GetButtonDown(button);
		}

		public bool GetButtonUp(ButtonInput button)
		{
			return _buttonStates.GetButtonUp(button);
		}

		public bool GetDirectionDown(Direction direction, StickType stick = StickType.LeftStick)
		{
			return _directionalInput.GetDirectionDown(direction, stick);
		}

		public bool GetDirectionUp(Direction direction, StickType stick = StickType.LeftStick)
		{
			return _directionalInput.GetDirectionUp(direction, stick);
		}

		public bool GetDirection(Direction direction, StickType stick = StickType.LeftStick)
		{
			return _directionalInput.GetDirection(direction, stick);
		}
	}
}
