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

    enum ETurnState
    {
        eStateNone = 0,
        eStateWaitForPlayers,
        eStateTurnStarted
    }

    /*enum EActivityState
    {
        eState0 = 0,
        eState1,
        eState2,
        eStateCount
    }*/

    /*public int m_StartFoodAmount = 500;
    public int[] m_FoodCostForStateChange;
    public int m_MaxSpeed = 5;
    public int m_RunDistance = 40;*/

    float m_TurnTime;
    float m_TurnDuration;

    /*int m_CurrentFoodAmount;
    int m_CurrentSpeed;
    int m_CurrentDistance;*/

    ETurnState m_TurnState;
    bool[] m_Activities;

    /*EActivityState[] m_NeededStates;
    EActivityState[] m_CurrentStates;
    EActivityState[] m_PreviousStates;*/

    // Use this for initialization
    void Start ()
    {
        m_TurnDuration = 60.0f;
        m_TurnState = ETurnState.eStateWaitForPlayers;

        m_Activities = new bool[(int)EActivities.eActivityCount];

        for (int i = 0; i < (int)EActivities.eActivityCount; i++)
            m_Activities[i] = false;
    }

    bool IsServer()
    {
        if (PlayerMgr.Instance && PlayerMgr.Instance.GetMyPlayer())
        {
            if (PlayerMgr.Instance.GetMyPlayer().isServer)
            {
                return true;
            }
        }

        return false;
    }
	
	// Update is called once per frame
	public void Update ()
    {
        if (IsServer())
        {
            if (m_TurnState == ETurnState.eStateWaitForPlayers)
            {
                if (PlayerMgr.Instance.IsEveryoneReady())
                {
                    PlayerMgr.Instance.StartTurn();
                    m_TurnState = ETurnState.eStateTurnStarted;
                }
            }
            else if (m_TurnState == ETurnState.eStateTurnStarted)
            {
                m_TurnTime += Time.deltaTime;

                if (m_TurnTime >= m_TurnDuration)
                {
                    m_TurnState = ETurnState.eStateWaitForPlayers;

                    for (int i = 0; i < (int)EActivities.eActivityCount; i++)
                        m_Activities[i] = false;

                    PlayerMgr.Instance.EndTurn();
                }
            }
        }
    }

    public void SetActivity(PlayerBehavior Player, int ActivityId)
    {
        if (m_Activities[ActivityId] == false)
        {
            m_Activities[ActivityId] = true;
            Player.ValidateActivity();
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

}
