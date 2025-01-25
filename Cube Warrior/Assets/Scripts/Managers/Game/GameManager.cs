using Character;
using TigerForge;
using UI.Menus;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Character.Character player;
    
    [SerializeField] private StatBuffSelectionPopup buffSelectionPopup;

    public void OnEnable()
    {
        EventManager.StartListening(EventNames.PlayerCharacterDied, EndGame);
        EventManager.StartListening(EventNames.PlayerCharacterLeveled, PlayerCharacterLeveled);
    }

    public void OnDisable()
    {
        EventManager.StopListening(EventNames.PlayerCharacterDied, EndGame);
        EventManager.StopListening(EventNames.PlayerCharacterLeveled, PlayerCharacterLeveled);
    }

    private void EndGame()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    private void PlayerCharacterLeveled()
    {
        buffSelectionPopup.PlayerGainedLevel();
        buffSelectionPopup.Open();
    }
}