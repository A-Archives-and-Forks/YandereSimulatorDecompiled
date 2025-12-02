using System;
using UnityEngine;

namespace HNS
{
	public class InputDeviceDetector
	{
		private InputDevice _currentDevice;

		private InputDevice _lastDevice;

		private float _lastInputTime;

		private float _lastConnectionCheck;

		private bool _gamepadConnected;

		private const float INPUT_TIMEOUT = 0.1f;

		private const float CONNECTION_CHECK_INTERVAL = 0.5f;

		public Action<InputDevice> OnDeviceChanged;

		public InputDevice CurrentDevice => _currentDevice;

		public bool DeviceChanged { get; private set; }

		public InputDeviceDetector()
		{
			_gamepadConnected = HasGamepadConnected();
			_currentDevice = GetInitialDevice();
			_lastDevice = _currentDevice;
			_lastConnectionCheck = Time.time;
		}

		public void Update()
		{
			if (Time.time - _lastConnectionCheck >= 0.5f)
			{
				_gamepadConnected = HasGamepadConnected();
				_lastConnectionCheck = Time.time;
			}
			DeviceChanged = false;
			InputDevice inputDevice = DetectActiveDevice();
			if (inputDevice != _currentDevice && Time.time - _lastInputTime > 0.1f)
			{
				_lastDevice = _currentDevice;
				_currentDevice = inputDevice;
				_lastInputTime = Time.time;
				DeviceChanged = true;
				OnDeviceChanged?.Invoke(_currentDevice);
			}
		}

		private InputDevice GetInitialDevice()
		{
			if (!_gamepadConnected)
			{
				return InputDevice.KeyboardMouse;
			}
			return InputDevice.Gamepad;
		}

		private InputDevice DetectActiveDevice()
		{
			if (DetectGamepadInput())
			{
				return InputDevice.Gamepad;
			}
			if (DetectKeyboardMouseInput())
			{
				return InputDevice.KeyboardMouse;
			}
			return _currentDevice;
		}

		private bool DetectGamepadInput()
		{
			if (!_gamepadConnected)
			{
				return false;
			}
			if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D))
			{
				if (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f)
				{
					return true;
				}
				if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
				{
					return true;
				}
			}
			string[] array = new string[4] { "Joystick X", "Joystick Y", "DpadX", "DpadY" };
			foreach (string axisName in array)
			{
				try
				{
					if (Mathf.Abs(Input.GetAxis(axisName)) > 0.1f)
					{
						return true;
					}
				}
				catch
				{
				}
			}
			for (int j = 0; j < 20; j++)
			{
				try
				{
					if (Input.GetKey((KeyCode)(330 + j)))
					{
						return true;
					}
				}
				catch
				{
				}
			}
			return false;
		}

		private bool DetectKeyboardMouseInput()
		{
			if (Input.anyKey && !IsGamepadKey() && IsActualKeyboardInput())
			{
				return true;
			}
			if (Mathf.Abs(Input.GetAxis("Mouse X")) > 0.1f)
			{
				return true;
			}
			if (Mathf.Abs(Input.GetAxis("Mouse Y")) > 0.1f)
			{
				return true;
			}
			if (Input.GetAxis("Mouse ScrollWheel") != 0f)
			{
				return true;
			}
			if (Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2))
			{
				return true;
			}
			return false;
		}

		private bool IsActualKeyboardInput()
		{
			if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
			{
				return true;
			}
			if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.Space))
			{
				return true;
			}
			if (Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.E))
			{
				return true;
			}
			if (Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Alpha4))
			{
				return true;
			}
			if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Return))
			{
				return true;
			}
			if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
			{
				return true;
			}
			return false;
		}

		private bool IsGamepadKey()
		{
			for (int i = 0; i < 20; i++)
			{
				if (Input.GetKey((KeyCode)(330 + i)))
				{
					return true;
				}
			}
			return false;
		}

		private bool HasGamepadConnected()
		{
			string[] joystickNames = Input.GetJoystickNames();
			if (joystickNames != null)
			{
				return joystickNames.Length != 0;
			}
			return false;
		}

		public string GetGamepadName()
		{
			string[] joystickNames = Input.GetJoystickNames();
			if (joystickNames != null && joystickNames.Length != 0)
			{
				return joystickNames[0];
			}
			return string.Empty;
		}

		public GamepadType GetGamepadType()
		{
			return GamepadType.Generic;
		}

		public bool IsXboxController()
		{
			return false;
		}

		public bool IsPlayStationController()
		{
			return false;
		}

		public bool IsSwitchController()
		{
			return false;
		}
	}
}
