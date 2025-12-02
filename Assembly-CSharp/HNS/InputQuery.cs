using System;
using UnityEngine;

namespace HNS
{
	public static class InputQuery
	{
		public static Vector2 Movement => InputManager.State.Movement;

		public static Vector2 Look => InputManager.State.Look;

		public static Vector2 ScrollWheel => InputManager.State.ScrollWheel;

		public static InputDevice CurrentDevice => InputManager.CurrentDevice;

		public static GamepadType GamepadType => InputManager.GamepadType;

		public static bool IsUsingGamepad => InputManager.IsUsingGamepad;

		public static bool IsUsingKeyboardMouse => InputManager.IsUsingKeyboardMouse;

		public static bool IsXboxController => InputManager.IsXboxController;

		public static bool IsPlayStationController => InputManager.IsPlayStationController;

		public static string GamepadName => InputManager.GamepadName;

		public static bool Button(ButtonInput button)
		{
			return InputManager.State.GetButton(button);
		}

		public static bool ButtonDown(ButtonInput button)
		{
			return InputManager.State.GetButtonDown(button);
		}

		public static bool ButtonUp(ButtonInput button)
		{
			return InputManager.State.GetButtonUp(button);
		}

		public static bool DirectionDown(Direction direction, StickType stick = StickType.LeftStick)
		{
			return InputManager.State.GetDirectionDown(direction, stick);
		}

		public static bool DirectionUp(Direction direction, StickType stick = StickType.LeftStick)
		{
			return InputManager.State.GetDirectionUp(direction, stick);
		}

		public static bool Direction(Direction direction, StickType stick = StickType.LeftStick)
		{
			return InputManager.State.GetDirection(direction, stick);
		}

		public static bool AnyButton()
		{
			foreach (ButtonInput value in Enum.GetValues(typeof(ButtonInput)))
			{
				if (ButtonDown(value))
				{
					return true;
				}
			}
			return false;
		}

		public static bool AnyMovement()
		{
			return Movement.sqrMagnitude > 0.01f;
		}
	}
}
