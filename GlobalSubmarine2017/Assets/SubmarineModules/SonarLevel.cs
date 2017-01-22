using UnityEngine;
using System.Collections;

public class SonarLevel : AbstractSubmarineLevel {

	public Sonar sonar;

	// Use this for initialization
	void Start () {
	
	}
	
	override public void UpdateDisplay()
	{
		sonar.level = level;
	}
}
