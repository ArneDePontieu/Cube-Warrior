using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace UI.Menus
{
    public class StatBuffSelectionItem : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI title;
        
        private Action onBuffSelected;
        
        public void Initialize(Action onBuffSelectedCallback)
        {
            onBuffSelected = onBuffSelectedCallback;
            title.text = Random.value.ToString();
        }
        
        public void Select()
        {
            onBuffSelected.Invoke();
        }
    }
}