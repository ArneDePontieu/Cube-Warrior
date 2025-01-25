using System.Collections.Generic;
using Kryz.CharacterStats;
using UnityEngine;

namespace UI.Menus
{
    public class StatBuffSelectionPopup : UIPopup
    {
        [SerializeField] private StatBuffSelectionItem buffPrefab;
        [SerializeField] private Transform parent;
        [SerializeField] private int buffSelectionCount = 3;

        private int buffsToGive = 0;
        private List<StatBuffSelectionItem> buffSelectionItems = new();

        public void PlayerGainedLevel()
        {
            buffsToGive++;
        }

        protected override void OnWindowOpened()
        {
            if (buffsToGive <= 0)
            {
                Close();
                return;
            }

            GenerateBuffs();
        }

        private void GenerateBuffs()
        {
            Debug.Log("Generating Buffs");

            for (int i = 0; i < buffSelectionItems.Count; i++)
            {
                Destroy(buffSelectionItems[i].gameObject);
            }

            buffSelectionItems.Clear();

            for (int i = 0; i < buffSelectionCount; i++)
            {
                StatBuffSelectionItem buffItem = Instantiate(buffPrefab, parent);
                buffItem.Initialize(SelectBuff);
                buffSelectionItems.Add(buffItem);
            }
        }

        private void SelectBuff()
        {
            buffsToGive--;

            FindFirstObjectByType<Character.Character>().CurrentStats.WeaponModifiers.AreaMultiplier
                .AddModifier(new StatModifier(0.5f, StatModType.PercentAdd));
            
            if (buffsToGive > 0)
            {
                GenerateBuffs();
                return;
            }

            Close();
        }
    }
}