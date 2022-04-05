using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance;

    public static Player Instance
    {
        get { return instance; }
    }

    public int level;
    public int xpPoints;
    public Vector3 currentPosition;
    public int coins;

    public Player(Player player)
    {
        level = player.level;
        xpPoints = player.xpPoints;
        currentPosition = player.currentPosition;
        coins = player.coins;
    }

    private void Awake()
    {
        if( instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void GrantCoins(int coinsToGrant)
    {
        coins += coinsToGrant;
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayerData(SaveData data)
    {
        level = data.level;
        xpPoints = data.xpPoints;
        currentPosition = new Vector3(data.currentPositionX, data.currentPositionY, data.currentPositionZ);
        coins = data.coins;
    }

    private void OnApplicationQuit()
    {
        SaveSystem.SavePlayer(instance);
    }

}
