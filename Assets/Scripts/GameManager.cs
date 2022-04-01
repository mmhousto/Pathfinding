using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    private Player playerData;

    private void Awake()
    {
        playerData = GameObject.FindWithTag("PlayerData").GetComponent<Player>();
    }

    public void SavePlayerData()
    {
        SaveSystem.SavePlayer(Player.Instance);
    }

    private void Start()
    {
        Instantiate(playerPrefab, playerData.currentPosition, playerPrefab.transform.rotation);
    }
}
