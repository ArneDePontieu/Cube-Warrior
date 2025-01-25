using UnityEngine;

public class GiveExperienceButton : MonoBehaviour
{
    [SerializeField] private int amount;

    private Character.Character playerCharacter;
    
    public void Awake()
    {
        playerCharacter = FindFirstObjectByType<Character.Character>();
    }
    
    public void Give()
    {
        playerCharacter.GiveExperience(amount);
    }
}
