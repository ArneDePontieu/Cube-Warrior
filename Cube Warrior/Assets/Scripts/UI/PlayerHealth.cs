using System;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Character.Character playerCharacter;
    [SerializeField] private TextMeshProUGUI healthValue;

    private void Update()
    {
        healthValue.text = playerCharacter.CurrentHealth.ToString();
    }
}