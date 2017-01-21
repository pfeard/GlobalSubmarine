using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMgr : Singleton<TurnMgr>
{
    enum EActivities
    {
        eA = 0,
        eB,
        eC,
        //eD,
        //eE,
        eActivityCount
    }

    enum EActivityState
    {
        eState0 = 0,
        eState1,
        eState2,
        eStateCount
    }

    public int m_StartFoodAmount = 500;
    public int[] m_FoodCostForStateChange;
    public int m_MaxSpeed = 5;
    public int m_RunDistance = 40;

    int m_CurrentFoodAmount;
    int m_CurrentSpeed;
    int m_CurrentDistance;

    EActivityState[] m_NeededStates;
    EActivityState[] m_CurrentStates;
    EActivityState[] m_PreviousStates;

    // Use this for initialization
    void Start ()
    {
        m_NeededStates = new EActivityState[(int)EActivityState.eStateCount];
        m_CurrentStates = new EActivityState[(int)EActivityState.eStateCount];
        m_PreviousStates = new EActivityState[(int)EActivityState.eStateCount];

        m_CurrentFoodAmount = m_StartFoodAmount;
        m_CurrentSpeed = m_MaxSpeed;

        m_CurrentDistance = 0;

        for (int i = 0; i < (int)EActivityState.eStateCount; i++)
        {
            m_CurrentStates[i] = EActivityState.eState0;
            m_PreviousStates[i] = EActivityState.eState0;
        }

        RandomizeStates();

        m_FoodCostForStateChange = new int[(int)EActivityState.eStateCount];

        for (int i = 0; i < (int)EActivityState.eStateCount; i++)
        {
            m_FoodCostForStateChange[i] = 1;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (PlayerMgr.Instance && PlayerMgr.Instance.GetMyPlayer())
        {
            if (PlayerMgr.Instance.GetMyPlayer().isServer)
            {
                if (PlayerMgr.Instance.IsEveryoneReady())
                {
                    if (OnePlayerPerActivity() == false)
                    {
                        PlayerMgr.Instance.CancelTurn();
                    }
                    else
                    {
                        ManageResources();
                        ManageSpeed();
                        PlayerMgr.Instance.NextTurn(m_CurrentFoodAmount, m_CurrentSpeed, m_CurrentDistance);
                    }
                }
            }
        }
	}

    void RandomizeStates()
    {
        for ( int i = 0; i < (int)EActivities.eActivityCount; i++)
        {
            m_NeededStates[i] = (EActivityState)Random.Range(0, (int)EActivityState.eStateCount);
        }
    }

    bool OnePlayerPerActivity()
    {
        int[]  pCounts;
        pCounts = new int[(int)EActivities.eActivityCount];

        for (int i = 0; i < (int)EActivities.eActivityCount; i++)
            for (int j = 0; j < PlayerMgr.Instance.GetPlayerCount(); j++)
            {
                if (PlayerMgr.Instance.GetPlayer(j).m_CurrentActivity == i)
                {
                    pCounts[i]++;

                    if (pCounts[i] > 1)
                        return false;
                }
            }

        return true;
    }

    void ManageResources()
    {
        m_CurrentSpeed = 5;

        for (int i = 0; i < (int)EActivities.eActivityCount; i++)
        {
            bool activityOK = false;

            for (int j = 0; j < PlayerMgr.Instance.GetPlayerCount(); j++)
            {
                if (PlayerMgr.Instance.GetPlayer(j).m_CurrentActivity == i)
                {
                    m_PreviousStates[i] = m_CurrentStates[i];
                    m_CurrentStates[i] = (EActivityState)PlayerMgr.Instance.GetPlayer(j).m_CurrentState;

                    if (PlayerMgr.Instance.GetPlayer(j).m_CurrentState == (int)m_NeededStates[i])
                    {
                        // Everything's done correctly
                        activityOK = true;
                    }
                }
            }

            if (!activityOK)
            {
                m_FoodCostForStateChange[i] += 1;
                m_CurrentSpeed--;
            }

            if (m_PreviousStates[i] != m_CurrentStates[i])
            {
                m_CurrentFoodAmount -= m_FoodCostForStateChange[i];

                if (m_CurrentFoodAmount <= 0)
                {
                    // Todo: GAME OVER
                }
            }
        }
    }

    void ManageSpeed()
    {
        m_CurrentDistance += m_CurrentSpeed;

        if (m_CurrentDistance >= m_RunDistance)
        {
            // Todo: YOU WIN
        }
    }
}
