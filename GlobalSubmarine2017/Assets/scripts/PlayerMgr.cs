using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMgr : Singleton<PlayerMgr>
{
    public static int sPlayerCount = 3;
    public List<PlayerBehavior> m_Players;
    public LEDLight[] m_POk;

    protected PlayerMgr()
    {
        m_POk = new LEDLight[sPlayerCount];
        m_Players = new List<PlayerBehavior>();
    }
    
    public void AddPlayer(PlayerBehavior player)
    {
        m_Players.Add(player);

        if (m_Players.Count < sPlayerCount)
        {
            if (m_POk[m_Players.Count - 1] != null)
            {
                //m_POk[m_Players.Count - 1].color = new Color(0.0f, 1.0f, 0.0f);
				m_POk[m_Players.Count - 1].Set(true);
            }
        }
    }

    public void RemovePlayer(PlayerBehavior player)
    {
        if (m_POk[m_Players.Count - 1] != null)
        {
            //m_POk[m_Players.Count - 1].color = new Color(1.0f, 0.0f, 0.0f);
			m_POk[m_Players.Count - 1].Set(false);
        }

        if (m_Players.Contains(player))
            m_Players.Remove(player);
    }

    public void RemoveMe()
    {
        foreach (PlayerBehavior player in m_Players)
        {
            if (player && player.isLocalPlayer)
            {
                RemovePlayer(player);
                Destroy(player);
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
            if (player && player.isLocalPlayer)
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

    public void StartTurn()
    {
        foreach (PlayerBehavior player in m_Players)
        {
            player.StartTurn();
        }
    }

    public void EndTurn()
    {
        foreach (PlayerBehavior player in m_Players)
        {
            player.EndTurn();
        }
    }
}
