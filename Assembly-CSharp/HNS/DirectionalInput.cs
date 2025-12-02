using UnityEngine;

namespace HNS
{
	public class DirectionalInput
	{
		private DirectionalState _leftStick;

		private DirectionalState _rightStick;

		private DirectionalState _dpad;

		public DirectionalInput()
		{
			_leftStick = new DirectionalState(0.5f);
			_rightStick = new DirectionalState(0.5f);
			_dpad = new DirectionalState(0.5f);
		}

		public void Update()
		{
			_leftStick.Update(GetLeftStick());
			_rightStick.Update(GetRightStick());
			_dpad.Update(GetDPad());
		}

		public bool GetDirectionDown(Direction direction, StickType stick = StickType.LeftStick)
		{
			return GetState(stick).WasPressed(direction);
		}

		public bool GetDirectionUp(Direction direction, StickType stick = StickType.LeftStick)
		{
			return GetState(stick).WasReleased(direction);
		}

		public bool GetDirection(Direction direction, StickType stick = StickType.LeftStick)
		{
			return GetState(stick).IsHeld(direction);
		}

		private DirectionalState GetState(StickType stick)
		{
			return stick switch
			{
				StickType.RightStick => _rightStick, 
				StickType.DPad => _dpad, 
				_ => _leftStick, 
			};
		}

		private Vector2 GetLeftStick()
		{
			float x = 0f;
			float y = 0f;
			try
			{
				x = Input.GetAxisRaw("Horizontal");
			}
			catch
			{
			}
			try
			{
				y = Input.GetAxisRaw("Vertical");
			}
			catch
			{
			}
			return new Vector2(x, y);
		}

		private Vector2 GetRightStick()
		{
			float x = 0f;
			float y = 0f;
			try
			{
				x = Input.GetAxis("Joystick X");
			}
			catch
			{
			}
			try
			{
				y = Input.GetAxis("Joystick Y");
			}
			catch
			{
			}
			return new Vector2(x, y);
		}

		private Vector2 GetDPad()
		{
			float x = 0f;
			float y = 0f;
			try
			{
				x = Input.GetAxis("DpadX");
			}
			catch
			{
			}
			try
			{
				y = Input.GetAxis("DpadY");
			}
			catch
			{
			}
			return new Vector2(x, y);
		}
	}
}
