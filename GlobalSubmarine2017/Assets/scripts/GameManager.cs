﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(gameObject);	
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (TurnMgr.Instance)
        {
            TurnMgr.Instance.Update();
        }
		if (SubmarineMgr.Instance)
		{
			SubmarineMgr.Instance.Update();
		}
	}
}
