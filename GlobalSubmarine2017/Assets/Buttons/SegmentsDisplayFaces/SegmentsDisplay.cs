using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SegmentsDisplay : MonoBehaviour {

	[Tooltip("The sprites representing the digits (0 to 9)")]
	public Sprite[] faces = new Sprite[10];

	[Tooltip("The digit images that are part of the display")]
	public Image[] digits;

	[Tooltip("Current value of the display")]
	public string _currentValue;
	public string currentValue
	{
		get { return _currentValue; }
		set
		{
			_currentValue = value;
			UpdateDisplay();
		}
	}

	[Tooltip("Character that will be used for padding values (eg: '1' => '0001')")]
	public int paddingChar;//Id of the char that will be used for padding values (eg: 0 => "0001")

	// Use this for initialization
	void Start () {
		UpdateDisplay();
	}

	public void Increment()
	{
		int temp = int.Parse(currentValue);
		temp++;

		if(temp >= Mathf.Pow(10, digits.Length))
		{
			temp = 0;
		}

		currentValue = temp.ToString();
	}

	void UpdateDisplay()
	{
		SetValue(currentValue);
	}

	public void SetValue(string v)
	{
		while(v.Length < digits.Length)
		{
			v = paddingChar+v;
		}

	
		for(int i = 0; i < v.Length; i++)
		{
			SetDigit(i, int.Parse(v[i].ToString()));
		}
	}
	void SetDigit(int id, int face)
	{
		if(face > faces.Length)
		{

			Debug.LogError("Face id out of range: "+face);
		}
		if(id > digits.Length)
		{
			Debug.LogError("Digit id out of range: "+id);
		}
		digits[id].sprite = faces[face];
	}
}
