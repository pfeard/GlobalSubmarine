using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMgr : Singleton<PlayerMgr>
{
    public List<PlayerBehavior> m_Players;
    public UnityEngine.UI.Image[] m_POk;

    protected PlayerMgr()
    {
        m_POk = new UnityEngine.UI.Image[4];
        m_Players = new List<PlayerBehavior>();
    }
    
    public void AddPlayer(PlayerBehavior player)
    {
        m_Players.Add(player);

        if (m_Players.Count < 4)
        {
            if (m_POk[m_Players.Count - 1] != null)
            {
                m_POk[m_Players.Count - 1].color = new Color(0.0f, 1.0f, 0.0f);
            }
        }
    }

    public void ClearPlayers()
    {
        m_Players.Clear();
    }

    public PlayerBehavior GetMyPlayer()
    {
        foreach (PlayerBehavior player in m_Players)
        {
            if (player.isLocalPlayer)
                return player;
        }

        return null;
    }

    public PlayerBehavior GetPlayer(int i)
    {
        if (i < m_Players.Count)
            return m_Players[i];

        return null;
    }

    public int GetPlayerCount()
    {
        return m_Players.Count;
    }

    public bool IsEveryoneReady()
    {
        bool isReady = true;

        foreach (PlayerBehavior player in m_Players)
        {
            if (player.m_ReadyForNextTurn == false)
                isReady = false;
        }

        return isReady;
    }

    public void CancelTurn()
    {
        foreach (PlayerBehavior player in m_Players)
        {
            player.FailedTurn();
        }
    }

    public void NextTurn()
    {
        foreach (PlayerBehavior player in m_Players)
        {
            player.NextTurn();
        }
    }
}
