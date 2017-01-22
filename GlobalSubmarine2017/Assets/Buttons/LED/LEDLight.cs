using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LEDLight : MonoBehaviour {

	public Image lightImage;
	public Image bgImage;
	public Color lightColorOn;
	public Color bgColorOn;
	public Color lightColorOff;
	public Color bgColorOff;

	public bool _isOn;
	public bool isOn
	{
		get {
			return _isOn;
		}
		set {
			_isOn = value;
			UpdateDisplay();
		}
	}

	// Use this for initialization
	void Start () {
		UpdateDisplay();
	}

	void UpdateDisplay()
	{
		lightImage.color = isOn?lightColorOn:lightColorOff;
		bgImage.color = isOn?bgColorOn:bgColorOff;
	}

	public void Toggle()
	{
		isOn = !isOn;
	}

	public void Set(bool b)
	{
		isOn = b;
	}
}
