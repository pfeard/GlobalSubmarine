using UnityEngine;
using System.Collections;

public class FuckMyShitUp : MonoBehaviour {

	public AbstractSubmarineLevel[] levels;
	public AbstractSubmarineRuler[] rulers;
	public AbstractSubmarineController[] controllers;
	// Use this for initialization
	void Start () {
		for(int i = 0; i < controllers.Length; i++)
		{
			controllers[i].onStateChanged.AddListener(v => {DoSomething();});
		}
	}

	void DoSomething()
	{
		if(Random.Range(0.0f, 1.0f) > 0.5f)
		{
			levels[Random.Range(0, levels.Length)].level = Random.Range(0.0f, 1.0f);
		} else 
		{
			rulers[Random.Range(0, rulers.Length)].state = Mathf.FloorToInt(Random.Range(0.0f, 1.99f));
		}
	}

}
