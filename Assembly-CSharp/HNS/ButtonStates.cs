using System;
using System.Collections.Generic;
using UnityEngine;

namespace HNS
{
	public class ButtonStates
	{
		private Dictionary<ButtonInput, ButtonState> _states;

		public ButtonStates()
		{
			_states = new Dictionary<ButtonInput, ButtonState>();
			foreach (ButtonInput value in Enum.GetValues(typeof(ButtonInput)))
			{
				_states[value] = new ButtonState();
			}
		}

		public void Update()
		{
			foreach (ButtonInput value in Enum.GetValues(typeof(ButtonInput)))
			{
				bool rawButtonState = GetRawButtonState(value);
				_states[value].Update(rawButtonState);
			}
		}

		public bool GetButton(ButtonInput button)
		{
			if (InputManager.IsUsingKeyboardMouse)
			{
				return GetKeyboardButtonHeld(button);
			}
			return _states[button].IsHeld;
		}

		public bool GetButtonDown(ButtonInput button)
		{
			if (InputManager.IsUsingKeyboardMouse)
			{
				return GetKeyboardButtonDown(button);
			}
			return _states[button].WasPressed;
		}

		public bool GetButtonUp(ButtonInput button)
		{
			if (InputManager.IsUsingKeyboardMouse)
			{
				return GetKeyboardButtonUp(button);
			}
			return _states[button].WasReleased;
		}

		private bool GetRawButtonState(ButtonInput button)
		{
			string buttonName = GetButtonName(button);
			try
			{
				return Input.GetButton(buttonName);
			}
			catch
			{
				return false;
			}
		}

		private bool GetKeyboardButtonDown(ButtonInput button)
		{
			switch (button)
			{
			case ButtonInput.B:
				return Input.GetMouseButtonDown(0);
			case ButtonInput.A:
				return Input.GetKeyDown(KeyCode.LeftShift);
			case ButtonInput.X:
				return Input.GetKeyDown(KeyCode.Q);
			case ButtonInput.RightStick:
				return Input.GetMouseButtonDown(1);
			case ButtonInput.Number1:
				return Input.GetKeyDown(KeyCode.Alpha1);
			case ButtonInput.Number2:
				return Input.GetKeyDown(KeyCode.Alpha2);
			case ButtonInput.Number3:
				return Input.GetKeyDown(KeyCode.Alpha3);
			case ButtonInput.Number4:
				return Input.GetKeyDown(KeyCode.Alpha4);
			case ButtonInput.Start:
				if (!Input.GetKeyDown(KeyCode.Escape))
				{
					return Input.GetKeyDown(KeyCode.Return);
				}
				return true;
			case ButtonInput.Select:
				return Input.GetKeyDown(KeyCode.Escape);
			default:
				return false;
			}
		}

		private bool GetKeyboardButtonUp(ButtonInput button)
		{
			switch (button)
			{
			case ButtonInput.B:
				return Input.GetMouseButtonUp(0);
			case ButtonInput.A:
				return Input.GetKeyUp(KeyCode.LeftShift);
			case ButtonInput.X:
				return Input.GetKeyUp(KeyCode.Q);
			case ButtonInput.RightStick:
				return Input.GetMouseButtonUp(1);
			case ButtonInput.Number1:
				return Input.GetKeyUp(KeyCode.Alpha1);
			case ButtonInput.Number2:
				return Input.GetKeyUp(KeyCode.Alpha2);
			case ButtonInput.Number3:
				return Input.GetKeyUp(KeyCode.Alpha3);
			case ButtonInput.Number4:
				return Input.GetKeyUp(KeyCode.Alpha4);
			case ButtonInput.Start:
				if (!Input.GetKeyUp(KeyCode.Escape))
				{
					return Input.GetKeyUp(KeyCode.Return);
				}
				return true;
			case ButtonInput.Select:
				return Input.GetKeyUp(KeyCode.Escape);
			default:
				return false;
			}
		}

		private bool GetKeyboardButtonHeld(ButtonInput button)
		{
			switch (button)
			{
			case ButtonInput.B:
				return Input.GetMouseButton(0);
			case ButtonInput.A:
				return Input.GetKey(KeyCode.LeftShift);
			case ButtonInput.X:
				return Input.GetKey(KeyCode.Q);
			case ButtonInput.RightStick:
				return Input.GetMouseButton(1);
			case ButtonInput.Number1:
				return Input.GetKey(KeyCode.Alpha1);
			case ButtonInput.Number2:
				return Input.GetKey(KeyCode.Alpha2);
			case ButtonInput.Number3:
				return Input.GetKey(KeyCode.Alpha3);
			case ButtonInput.Number4:
				return Input.GetKey(KeyCode.Alpha4);
			case ButtonInput.Start:
				if (!Input.GetKey(KeyCode.Escape))
				{
					return Input.GetKey(KeyCode.Return);
				}
				return true;
			case ButtonInput.Select:
				return Input.GetKey(KeyCode.Escape);
			default:
				return false;
			}
		}

		private string GetButtonName(ButtonInput button)
		{
			return InputConfig.GetButtonName(button);
		}
	}
}
