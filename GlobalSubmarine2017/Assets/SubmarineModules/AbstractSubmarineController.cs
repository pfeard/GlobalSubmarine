using UnityEngine;
using UnityEngine.Events;

public abstract class AbstractSubmarineController : MonoBehaviour
{
	public class ControllerStateEvent : UnityEvent<int>{};
	public ControllerStateEvent onStateChanged = new ControllerStateEvent();

	int _currentState;
	public int currentState
	{
		get { return _currentState; }
		set {
			bool notify = _currentState != value;
			_currentState = value;

			if(notify)
			{
			Debug.Log("State changed :"+_currentState);
				onStateChanged.Invoke(_currentState);
			}
		}
	}
}

