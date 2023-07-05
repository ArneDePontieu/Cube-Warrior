using System;
using Character;
using TigerForge;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Character.Character player;


    public void OnEnable()
    {
        EventManager.StartListening(EventNames.PlayerCharacterDied, EndGame);
    }

    public void OnDisable()
    {
        EventManager.StopListening(EventNames.PlayerCharacterDied, EndGame);
    }

    private void EndGame()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}