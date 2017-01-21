using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMgr : MonoBehaviour
{
    enum EActivities
    {
        eA = 0,
        eB,
        eC,
        eD,
        eE,
        eActivityCount
    }

    enum EActivityState
    {
        eState0 = 0,
        eState1,
        eState2,
        eStateCount
    }

    EActivityState[] m_AllStates;

    // Use this for initialization
    void Start ()
    {
        m_AllStates = new EActivityState[(int)EActivityState.eStateCount];
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (PlayerMgr.Instance.GetMyPlayer())
        {
            if (PlayerMgr.Instance.GetMyPlayer().isServer)
            {
                if (PlayerMgr.Instance.IsEveryoneReady())
                {
                    
                }
            }
        }
	}

    void RandomizeStates()
    {
        for ( int i = 0; i < (int)EActivities.eActivityCount; i++)
        {
            m_AllStates[i] = (EActivityState)Random.Range(0, 3);
        }
    }
}
