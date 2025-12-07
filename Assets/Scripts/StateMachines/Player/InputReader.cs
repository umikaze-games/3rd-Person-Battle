using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
	public event Action jumpEvent;
	public event Action dodgeEvent;
	private Controls controls;
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
		jumpEvent?.Invoke();
	}

	public void OnDodge(InputAction.CallbackContext context)
	{
		dodgeEvent?.Invoke();
	}
}
