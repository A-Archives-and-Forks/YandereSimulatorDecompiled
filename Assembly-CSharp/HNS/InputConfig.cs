using System.Collections.Generic;
using UnityEngine;

namespace HNS
{
	public class InputConfig : MonoBehaviour
	{
		private static Dictionary<ButtonInput, string> _buttonMappings = new Dictionary<ButtonInput, string>
		{
			{
				ButtonInput.A,
				"A"
			},
			{
				ButtonInput.B,
				"B"
			},
			{
				ButtonInput.X,
				"X"
			},
			{
				ButtonInput.Y,
				"Y"
			},
			{
				ButtonInput.Start,
				"Start"
			},
			{
				ButtonInput.Select,
				"Select"
			},
			{
				ButtonInput.LeftBumper,
				"LB"
			},
			{
				ButtonInput.RightBumper,
				"RB"
			},
			{
				ButtonInput.LeftStick,
				"LS"
			},
			{
				ButtonInput.RightStick,
				"RS"
			}
		};

		public static string GetButtonName(ButtonInput button)
		{
			if (!_buttonMappings.TryGetValue(button, out var value))
			{
				return button.ToString();
			}
			return value;
		}

		public void RemapButton(ButtonInput button, string newMapping)
		{
			_buttonMappings[button] = newMapping;
		}
	}
}
