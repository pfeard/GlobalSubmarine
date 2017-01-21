using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerBehavior : NetworkBehaviour
{
    public int m_CurrentActivity;
    public int m_CurrentState;

    bool m_ReadyForNextTurn = false;

    // Use this for initialization
    void Start ()
    {
        if (isServer)
        {
            Debug.Log("I am the server");
        }

        if (isLocalPlayer)
        {
            Debug.Log("Local Player");
        }
        else
        {
            Debug.Log("Remote Player");
        }

        PlayerMgr.Instance.AddPlayer(this);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (isLocalPlayer)
        {
            
        }
	}

    // Local SetReady
    public void SetReady()
    {
        m_ReadyForNextTurn = true;
        CmdSetReady(m_CurrentActivity, m_CurrentState);
    }

    // Only called on server
    [Command]
    void CmdSetReady(int Activity, int State)
    {
        m_CurrentState = State;
        m_CurrentActivity = Activity;
        m_ReadyForNextTurn = true;
    }


    [ClientRpc]
    void RpcNextTurn()
    {
        m_ReadyForNextTurn = false;
    }

    // Called when several people chose the same activity
    [ClientRpc]
    void RpcFailedTurn()
    {

    }
}
