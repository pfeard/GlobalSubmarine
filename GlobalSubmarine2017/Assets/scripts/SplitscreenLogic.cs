using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class SplitscreenLogic : MonoBehaviour {

	public ToggleButton button1;
	public ToggleButton button2;
	public ToggleButton button3;
	public ToggleButton button4;
	public ToggleButton buttonS;
	public ToggleButton buttonD;
	public ToggleButton buttonL;
	public ToggleButton buttonR;

	public PressureLevel pressureLevel;
	public SonarLevel sonarLevel;
	public ThermometerLevel thermometerLevel;

	public CoolingController coolingController;
	public DiveController diveController;
	public DirectionController directionController;

	public PropellersRuler propellersRuler;
	public CoolingAlarmRuler coolingAlarmRuler;
	public DiveSpeedRuler diveSpeedRuler;

	public CanvasGroup pressureAlert;
	public CanvasGroup sonarAlert;
	public CanvasGroup thermometerAlert;

	float currentPower = 0.02f;
	float powerStep = 0.001f;

	float rulerChangeCooldown = 4.0f;
	float currentRulerCountdown = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1))
		{
			button1.Toggle();
		}
		if(Input.GetKeyDown(KeyCode.Alpha2))
		{
			button2.Toggle();
		}
		if(Input.GetKeyDown(KeyCode.Alpha3))
		{
			button3.Toggle();
		}
		if(Input.GetKeyDown(KeyCode.Alpha4))
		{
			button4.Toggle();
		}
		if(Input.GetKeyDown(KeyCode.D))
		{
			buttonD.Toggle();
		}
		if(Input.GetKeyDown(KeyCode.S))
		{
			buttonS.Toggle();
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow))
		{
			buttonL.Toggle();
		}
		if(Input.GetKeyDown(KeyCode.RightArrow))
		{
			buttonR.Toggle();
		}

		//levels logic
		float thermometerDirection = 1.0f;
		if(coolingAlarmRuler.state == coolingController.currentState || coolingController.currentState == -1)
		{
			thermometerDirection = 1.0f;
		} else 
		{
			thermometerDirection = -1.0f;
		}
		thermometerLevel.level += currentPower * thermometerDirection * Time.deltaTime;

		float sonarDirection = 1.0f;
		if(propellersRuler.state == directionController.currentState)
		{
			sonarDirection = 1.0f;
		} else 
		{
			sonarDirection = -1.0f;
		}
		sonarLevel.level += currentPower * sonarDirection * Time.deltaTime;

		float pressureDirection = 1.0f;
		if(diveSpeedRuler.state == diveController.currentState)
		{
			pressureDirection = 1.0f;
		} else 
		{
			pressureDirection = -1.0f;
		}
		pressureLevel.level += currentPower * pressureDirection * Time.deltaTime;

		//update the variation power
		currentPower += powerStep * Time.deltaTime;

		currentRulerCountdown -= Time.deltaTime;

		//randomize one ruler if the time is elapsed
		if(currentRulerCountdown <= 0.0f)
		{
			currentRulerCountdown = Random.Range(0.0f, rulerChangeCooldown);
			Debug.Log("Rules changed! next change in:"+currentRulerCountdown);

			//Randomly pick one of the ruler and reverse its state
			//(but don't change those who are problematic at the moment,
			//so that the problem don't fix themselves)
			int pick = Mathf.FloorToInt(Random.Range(0.0f, 2.99f));
			switch(pick)
			{
					case 0:
					//Sonar is doing fine... Let's fuck it up.
					if(sonarDirection < 0.0f)
					{
						propellersRuler.state = propellersRuler.state==1?0:1;
					}

					break;
					case 1:
					//Thermometer is doing fine... Let's fuck it up.
					if(thermometerDirection < 0.0f)
					{
						coolingAlarmRuler.state = coolingAlarmRuler.state==1?0:1;
					}
					break;
					case 2:
					//Pressure is doing fine... Let's fuck it up.
					if(pressureDirection < 0.0f)
					{
						diveSpeedRuler.state = diveSpeedRuler.state==1?0:1;
					}
					break;
			}
		}

		//show alerts
		if(pressureLevel.level > 0.9f)
		{
			pressureAlert.alpha = 0.5f;
		} else 
		{
			pressureAlert.alpha = 0.0f;
		}
		if(sonarLevel.level > 0.9f)
		{
			sonarAlert.alpha = 0.5f;
		} else 
		{
			sonarAlert.alpha = 0.0f;
		}

		if(thermometerLevel.level > 0.9f)
		{
			thermometerAlert.alpha = 0.5f;
		} else 
		{
			thermometerAlert.alpha = 0.0f;
		}
	}
}
