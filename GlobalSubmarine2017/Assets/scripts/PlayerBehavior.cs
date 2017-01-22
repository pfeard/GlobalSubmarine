using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerBehavior : NetworkBehaviour
{
    /*public int m_CurrentFood;
    public int m_CurrentSpeed;
    public int m_CurrentDistance;*/

    public int m_CurrentActivity;
    //public int m_CurrentState;

    public bool m_ReadyForNextTurn = false;
	public bool m_NoConflict = false;
	public bool m_AmReady = false;

	public delegate void onTurnStart();
	public onTurnStart _onTurnStart;

    public delegate void onTurnEnd();
    public onTurnEnd _onTurnEnd;

    public delegate void onPostSelected(int PostId);
    public onPostSelected _onPostSelected;
	
	public delegate void setInstrumentValueDelegate(string instrument, float value);
	public setInstrumentValueDelegate _setInstrumentValue;
	
	public delegate void setControllerValueDelegate(string controller, int value);
	public setControllerValueDelegate _setControllerValue;
	
	public delegate void setInfoValueDelegate(string info, int value);
	public setInfoValueDelegate _setInfoValue;
	
	/*public Dictionary<string, bool> buttons = new Dictionary<string, bool>();
	public Dictionary<string, float> instruments = new Dictionary<string, float>();*/

    /*public delegate void Conflict();
	public Conflict _Conflict;*/

    // Use this for initialization
    void Start ()
    {
		/*buttons.Add("Toggle", false);
		views.Add("Thermometer", 0);
		views.Add("Sonar",0);*/
		
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

        if (PlayerMgr.Instance)
            PlayerMgr.Instance.AddPlayer(this);

        DontDestroyOnLoad(this);
    }

    public override void OnNetworkDestroy()
    {
        if (PlayerMgr.Instance)
            PlayerMgr.Instance.RemovePlayer(this);
    }

    // Local SetReady
    public void SetReady()
    {
        CmdSetReady(m_CurrentActivity);
    }

    // Only called on server
    [Command]
    void CmdSetReady(int Activity)
    {
        TurnMgr.Instance.SetActivity(this, Activity);
    }

    public void ValidateActivity()
    {
        m_ReadyForNextTurn = true;

        RpcValidateActivity();
    }

    [ClientRpc]
    void RpcValidateActivity()
    {
        m_ReadyForNextTurn = true;
    }

    public void StartTurn()
    {
        RpcStartTurn();
    }

    [ClientRpc]
    void RpcStartTurn()
    {
        if (_onTurnStart != null)
        {
            _onTurnStart();
        }
    }

    public void EndTurn()
    {
        m_ReadyForNextTurn = false;
        m_CurrentActivity = -1;

        RpcEndTurn();
    }

    [ClientRpc]
    void RpcEndTurn()
    {
        m_ReadyForNextTurn = false;
        m_CurrentActivity = -1;

        if (_onTurnEnd != null)
        {
            _onTurnEnd();
        }
    }
	
	public void SetInstrumentValue(string instrument, float value)
	{
        /*if(instruments.ContainsKey(instrument))
		{
			instruments[instrument]=value;
			RpcSetInstrumentValue(instrument, value);
		}
		else
		{
			instruments.Add(instrument, value);
			RpcSetInstrumentValue(instrument, value);
		}*/
        RpcSetInstrumentValue(instrument, value);
    }

	[ClientRpc]
	void RpcSetInstrumentValue(string instrument, float value)
	{
		if (_setInstrumentValue != null)
		{
			_setInstrumentValue(instrument, value);
		}
		
	}
	
	public void SetRulerValue(string info, int value)
	{
		RpcSetInfoValue(info, value);
	}
	[ClientRpc]
	void RpcSetInfoValue(string info, int value)
	{
		if(_setInfoValue != null)
		{
			_setInfoValue(info, value);
		}
	}
	
	public void SetControllerValue(string controller, int value)
	{
        CmdSetControllerValue(controller, value);
	}

	[Command]
	public void CmdSetControllerValue(string controller, int value)
	{
		switch(controller)
		{
			case "Controller1":
				SubmarineMgr.Instance.Controller1 = value;
				break;
			case "Controller2":
				SubmarineMgr.Instance.Controller2 = value;
				break;
			case "Controller3":
				SubmarineMgr.Instance.Controller3 = value;
				break;
		}
		
	}
	[ClientRpc]
	void RpcSetControllerValue(string controller, int value)
	{
		if (_setControllerValue != null)
		{
			_setControllerValue(controller, value);
		}
	}
}

