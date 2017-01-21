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

    public bool IsEveryoneReady()
    {
        bool isReady = true;

        foreach (PlayerBehavior player in m_Players)
        {
            if (player.is)
        }
    }
}
