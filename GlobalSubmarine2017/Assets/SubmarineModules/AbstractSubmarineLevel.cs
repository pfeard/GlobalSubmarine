using UnityEngine;

public abstract class AbstractSubmarineLevel : MonoBehaviour
{
	float _level;
	public float level
	{
		get { return _level; }
		set {
			_level = Mathf.Clamp01(value);
			UpdateDisplay();
		}
	}

	abstract public void UpdateDisplay();
}