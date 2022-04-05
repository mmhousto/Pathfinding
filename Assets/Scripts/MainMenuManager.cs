using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public GameObject restoreButton;

    private void Awake()
    {
#if UNITY_IOS
    restoreButton.SetActive(true);
#else
        restoreButton.SetActive(false);
#endif
    }

    private void Start()
    {
        Player.Instance.LoadPlayerData(SaveSystem.LoadPlayer());
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
}
