using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
	public event Action JumpEvent;
	public event Action DodgeEvent;
	public event Action TargetEvent;
	public event Action CancelEvent;
	private Controls controls;

	public Vector2 MovementValue { get; private set; }
	private void Start()
	{
		controls = new Controls();
		controls.Player.SetCallbacks(this);
		controls.Player.Enable();
	}

	private void OnDestroy()
	{
		controls.Player.Disable();
	}
	public void OnJump(InputAction.CallbackContext context)
	{
		JumpEvent?.Invoke();
	}

	public void OnDodge(InputAction.CallbackContext context)
	{
		DodgeEvent?.Invoke();
	}

	public void OnMove(InputAction.CallbackContext context)
	{
		MovementValue = context.ReadValue<Vector2>();
	}

	public void OnLook(InputAction.CallbackContext context)
	{
		//throw new NotImplementedException();
	}

	public void OnTarget(InputAction.CallbackContext context)
	{
		if (!context.performed) return;
		TargetEvent?.Invoke();
	}

	public void OnCancel(InputAction.CallbackContext context)
	{
		if (!context.performed) return;
		CancelEvent?.Invoke();
	}
}
