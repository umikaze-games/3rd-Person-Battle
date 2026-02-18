using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
	public State currentState;

	private void Update()
	{
		
		currentState.Tick(Time.deltaTime);

	}

	public void SwitchState(State newState)
	{
		currentState?.Exit();
		currentState = newState;
		currentState?.Enter();
	}
}
