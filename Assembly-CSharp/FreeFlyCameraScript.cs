using UnityEngine;

public class FreeFlyCameraScript : MonoBehaviour
{
	[Header("Movement")]
	public float moveSpeed = 10f;

	public float fastMoveMultiplier = 3f;

	public float verticalSpeed = 10f;

	[Header("Mouse Look")]
	public float mouseSensitivity = 2.5f;

	public bool invertY;

	[Header("Controls")]
	public KeyCode fastMoveKey = KeyCode.LeftShift;

	public KeyCode toggleCursorKey = KeyCode.Escape;

	private float yaw;

	private float pitch;

	private bool cursorLocked = true;

	public DebugMenuScript DebugMenu;

	private void Start()
	{
		Vector3 eulerAngles = base.transform.eulerAngles;
		yaw = eulerAngles.y;
		pitch = eulerAngles.x;
		LockCursor(lockCursor: true);
	}

	private void Update()
	{
		HandleCursorToggle();
		HandleMouseLook();
		HandleMovement();
		if (Input.GetButtonDown(InputNames.Xbox_B))
		{
			DebugMenu.MainCamera.SetActive(value: true);
			DebugMenu.UICamera.SetActive(value: true);
			DebugMenu.Yandere.Invisible = false;
			DebugMenu.Yandere.CanMove = true;
			base.gameObject.SetActive(value: false);
		}
	}

	private void HandleCursorToggle()
	{
		if (Input.GetKeyDown(toggleCursorKey))
		{
			cursorLocked = !cursorLocked;
			LockCursor(cursorLocked);
		}
	}

	private void LockCursor(bool lockCursor)
	{
		Cursor.lockState = (lockCursor ? CursorLockMode.Locked : CursorLockMode.None);
		Cursor.visible = !lockCursor;
	}

	private void HandleMouseLook()
	{
		if (cursorLocked)
		{
			string axisName = "Mouse X";
			string axisName2 = "Mouse Y";
			if (DebugMenu.Yandere.InputDevice.Type == InputDeviceType.Gamepad)
			{
				axisName = InputNames.Xbox_JoyX;
				axisName2 = InputNames.Xbox_JoyY;
			}
			float num = Input.GetAxis(axisName) * mouseSensitivity * 100f * Time.deltaTime;
			float num2 = Input.GetAxis(axisName2) * mouseSensitivity * 100f * Time.deltaTime;
			yaw += num;
			pitch += (invertY ? num2 : (0f - num2));
			pitch = Mathf.Clamp(pitch, -89f, 89f);
			base.transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
		}
	}

	private void HandleMovement()
	{
		float num = moveSpeed;
		if (Input.GetKey(fastMoveKey))
		{
			num *= fastMoveMultiplier;
		}
		Vector3 zero = Vector3.zero;
		zero += base.transform.forward * Input.GetAxis("Vertical");
		zero += base.transform.right * Input.GetAxis("Horizontal");
		if (Input.GetKey(KeyCode.E))
		{
			zero += Vector3.up;
		}
		if (Input.GetKey(KeyCode.Q))
		{
			zero += Vector3.down;
		}
		base.transform.position += zero * num * Time.deltaTime;
	}
}
