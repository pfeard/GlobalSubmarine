using UnityEngine;

public abstract class AbstractSubmarineRuler : MonoBehaviour
{
	int _state;
	public int state
	{
		get { return _state; }	
		set {
			_state = value;
			UpdateDisplay();
		}
	}
	abstract public void UpdateDisplay();
}
